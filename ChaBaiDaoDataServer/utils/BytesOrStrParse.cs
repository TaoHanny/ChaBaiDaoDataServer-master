using System;
using System.Text;

namespace ChaBaiDaoDataServer.utils
{
    public class BytesOrStrParse
    {
        public static byte[] getStrToBytes(string id)
        {
            string screenId = id;
            byte[] ctlMsgBytes = StringAndByteUtil.stringToByteArray(screenId);
            byte[] ctlLengthBytes = StringAndByteUtil.intToByteArray(ctlMsgBytes.Length);
            string shopId = "";
            byte[] shopMsgBytes = StringAndByteUtil.stringToByteArray(shopId);
            byte[] shopLengthBytes = StringAndByteUtil.intToByteArray(shopMsgBytes.Length);
            int firstMsgInt = 999;
            byte[] firstMsgBytes = StringAndByteUtil.intToByteArray(firstMsgInt);
            //        int firstMsg = UDPByteUtil.byteArrayToInt(firstMsgBytes,0,firstMsgBytes.length);
            //        Log.e("TAG", "getStrToBytes: firstMsg = "+firstMsg);
            string twiceMsg = "C";
            byte[] twiceMsgBytes = StringAndByteUtil.stringToByteArray(twiceMsg);
            byte[] twiceLengthBytes = StringAndByteUtil.intToByteArray(twiceMsgBytes.Length);

            byte[] totalByte = StringAndByteUtil.intToByteArray(0);
            string dataStr = "C";
            byte[] dataMsgBytes = StringAndByteUtil.stringToByteArray(dataStr);
            byte[] dataLengthBytes = StringAndByteUtil.intToByteArray(dataMsgBytes.Length);
            byte[] allBytes = StringAndByteUtil.combineByte(
                    ctlLengthBytes, ctlMsgBytes,
                    shopLengthBytes, shopMsgBytes,
                    firstMsgBytes,
                    twiceLengthBytes, twiceMsgBytes,
                    totalByte,
                    dataLengthBytes, dataMsgBytes);
            return allBytes;
        }

        public static Data getBytesToStr(byte[] bytes)
        {
            int position = 0;
            int SIZE_OF = 4;
            Data data = new Data();

            int ctlLengthInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            position = SIZE_OF;
            string ctlMsgStr = StringAndByteUtil.byteArrayToString(bytes, position, ctlLengthInt);
            data.ctlMsg = ctlMsgStr;

            position = ctlLengthInt + position;
            int shopLengthInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            position = position + SIZE_OF;
            string shopMsgStr = StringAndByteUtil.byteArrayToString(bytes, position, shopLengthInt);
            data.shopMsg = shopMsgStr;

            position = position + shopLengthInt;
            int firstMsgInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            data.firstInt = firstMsgInt;

            position = position + SIZE_OF;
            int twiceLengthInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            position = position + SIZE_OF;
            string twiceMSgStr = StringAndByteUtil.byteArrayToString(bytes, position, twiceLengthInt);
            data.twiceMsg = twiceMSgStr;

            position = position + twiceLengthInt;
            int totalMsgInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            data.totalInt = totalMsgInt;

            position += SIZE_OF;
            int dataLengthInt = StringAndByteUtil.byteArrayToInt(bytes, position, SIZE_OF);
            position += SIZE_OF;
            string dataMsgStr = StringAndByteUtil.byteArrayToString(bytes, position, dataLengthInt);
            data.dataMsg = dataMsgStr;
            //         Log.d("UDPStrByteUtil", "getBytesToStr() "+data.toString());
            return data;
        }

        public class Data
        {
            public string ctlMsg;
            public string shopMsg;
            public int firstInt;
            public string twiceMsg;
            public int totalInt;
            public string dataMsg;

           
            public string toString()
            {
                return "Data{" +
                        "ctlMsg='" + ctlMsg + '\'' +
                        ", shopMsg='" + shopMsg + '\'' +
                        ", firstInt=" + firstInt +
                        ", twiceMsg='" + twiceMsg + '\'' +
                        ", totalInt=" + totalInt +
                        ", dataMsg='" + dataMsg + '\'' +
                        '}';
            }
        }
    }
}
