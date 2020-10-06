using Newtonsoft.Json;
using recharege.DLL;
using recharege.Entity.Dll;
using recharege.Util;

namespace recharege.Services.impl
{
    public class DllRechargeServiceImpl : DllRechargeService
    {
        // 1.0 打开设备
        public int InitRechargeHandler()
        {
            int flag;
            flag = Recharge.InitRecharge();
            return flag;
        }

        // 1.1 设置设备号
        public int SetDeviceNumberHandler(string deviceNumber)
        {
            int flag;
            flag = Recharge.SetDeviceNumber(deviceNumber);
            return flag;
        }

        // 1.2 获取设备号
        public string GetDeviceNumberHandler()
        {
            int flag;
            string temp = "";
            flag = Recharge.GetDeviceNumber(temp);
            return flag+";"+temp;
        }

        // 1.3 寻卡
        public string SearchCardHandler()
        {
            byte[] resultByte = new byte[1000];
            string temp = "";
            int flag;
            flag = Recharge.SearchCard(resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + ";" + temp;

        }

        // 1.4 CPU卡钱包圈存初始化
        public string CpuCardRechargeInitHandler(uint money)
        {
            byte[] resultByte = new byte[1000];
            string temp = "";
            int flag;
            flag = Recharge.CpuCardRechargeInit(money, resultByte);
            temp = Convertor.Ascii2Str(resultByte);
            return flag + ";" + temp;
        }

        // 1.5 CPU卡钱包充值
        public string CpuCardRechargeHandler(string rechargeCmdString)
        {
            // rechargeCmdString 服务器返回充值字符串(3.5  公交CPU卡申请充值 中的APDU)
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.CpuCardRecharge(rechargeCmdString, resultByte);
            temp = Convertor.Ascii2Str(resultByte);
            return flag + ";" + temp;
        }

        // 1.6 CPU卡月票充值初始化
        public string CpuMonthInitHandler()
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.CpuMonthInit(resultByte);
            temp = Convertor.Ascii2Str(resultByte);
            return flag + ";" + temp;
        }

        // 1.7 CPU卡月票充值
        public string CpuMonthRecharge(string rechargeCmdString)
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.CpuMonthRecharge(rechargeCmdString, resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + "" + temp;
        }

        // 1.8 CPU卡异常处理
        public string CpuExceptionHandle()
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.CpuExceptionHandle(resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + ";" + temp;
        }

        //1.9 M1获取余额
        public string M1GetBalance(string keyString)
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.M1GetBalance(keyString, resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + ";" + temp;
        }

        // 1.10 M1卡获取账户信息
        public string M1ReadAccountInfoHandler(uint rechargeMoney, string keyA, uint rechargeType)
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.M1ReadAccountInfo(rechargeMoney, keyA, rechargeType, resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + ";" + temp;
        }

        // 1.11 M1卡二次寻卡
        public int M1SecondSearchCardHandler()
        {
            int flag;
            flag = Recharge.M1SecondSearchCard();
            return flag;
        }

        // 1.12 M1卡充值
        public string M1RechargeHandler(string keyB)
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            flag = Recharge.M1Recharge(keyB, resultByte);
            temp = Convertor.Ascii2Str(resultByte);

            return flag + ";" + temp;
        }

        // 1.13 M1卡修改启用标志
        public int M1UpdateDate()
        {
            int flag;
            flag = Recharge.M1UpdateDate();
            return flag;
        }

        // 1.14 M1异常处理
        public string M1Exception(DllM1ExceptionIn dllM1ExceptionIn)
        {
            string temp = "";
            int flag;
            byte[] resultByte = new byte[1000];
            temp = JsonConvert.SerializeObject(dllM1ExceptionIn);
            flag = Recharge.M1Exception(temp, resultByte);
            temp = Convertor.Ascii2Str(resultByte);
            return flag + ";" + temp;
        }
    }
}
