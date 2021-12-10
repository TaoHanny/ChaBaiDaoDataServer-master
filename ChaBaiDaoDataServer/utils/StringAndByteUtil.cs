using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChaBaiDaoDataServer.utils
{
    public class StringAndByteUtil
    {

        private static string TAG = "StringAndByteUtil";
        public static byte[] intToByteArray(int value)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)value;
            bytes[1] = (byte)(value >> 8);
            bytes[2] = (byte)(value >> 16);
            bytes[3] = (byte)(value >> 24);
            return bytes;
        }

        /**
         * String 转字节数组
         * @param s
         * @return
         */
        public static byte[] stringToByteArray(string s)
        {

            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            //byte[] bytes = Encoding.Default.GetBytes("gb2312");
            byte[] bytes = gb2312.GetBytes(s);

            return bytes;
        }

        /**
         * @param bytes 所有字节数组
         * @return
         */
        public static byte[] combineByte(params object[] bytes)
        {
            int length = 0;
           
            foreach (byte[] b in bytes)
            {
                length += b.Length;
            }
            byte[] allByte = new byte[length];
            List<byte> tempList = new List<byte>();
            for (int i = 0; i < bytes.Length; i++)
            {
                byte[] b = (byte[])bytes[i];
                tempList.AddRange(b);
            }
            return tempList.ToArray();
        }

        /**
         * 读取输入流中指定字节的长度
         * @param buffer 总内容
         * @param from 开始位置
         * @param length 指定长度
         * @return 截取的字节数组
         */
        public static byte[] readBytesFromTo(byte[] buffer, int from, int length)
        {
            byte[] sub = new byte[length];
            int cur = 0;
            for (int i = from; i < length + from; i++)
            {
                sub[cur] = buffer[i];
                cur++;
            }
            return sub;
        }

        /**
         * 字节转int整型
         * @param bytes 需要转换的字节数组
         * @return int
         */
        public static int byteArrayToInt(byte[] bytes, int start, int length)
        {
            byte[] sub = readBytesFromTo(bytes, start, length);
            int value = sub[0] & 0xFF |
                    (sub[1] & 0xFF) << 8 |
                    (sub[2] & 0xFF) << 16 |
                    (sub[3] & 0xFF) << 24;
                   //Logcat.d(TAG, "byteArrayToInt() value = "+value);
            return value;
        }

        /**
         * 字节转字符串
         * @param bytes 需转换的字节数组
         * @param start 开始位置
         * @param length 结束位置
         * @return String
         */
        public static string byteArrayToString(byte[] bytes, int start, int length)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            string str = gb2312.GetString(bytes, start, length);
            //Logcat.d(TAG, "byteArrayToString() str = "+ str);
            return  str;
        }

        public static string GB2312ToUtf8(string gb2312String)
        {
            Encoding fromEncoding = Encoding.GetEncoding("gb2312");
            Encoding toEncoding = Encoding.UTF8;
            return EncodingConvert(gb2312String, fromEncoding, toEncoding);
        }

        public static string Utf8ToGB2312(string utf8String)
        {
            Encoding fromEncoding = Encoding.UTF8;
            Encoding toEncoding = Encoding.GetEncoding("gb2312");
            return EncodingConvert(utf8String, fromEncoding, toEncoding);
        } 

        private static string EncodingConvert(string fromString, Encoding fromEncoding, Encoding toEncoding)
        {
            byte[] fromBytes = fromEncoding.GetBytes(fromString);
            byte[] toBytes = Encoding.Convert(fromEncoding, toEncoding, fromBytes);

            string toString = toEncoding.GetString(toBytes);
            return toString;
        }
    }
}
