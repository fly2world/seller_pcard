using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace recharege.DLL
{
    /// <summary>
    /// recharge.dll调用
    /// </summary>
    static class Recharge
    {
        /*
        1.0 打开设备
        函数名： InitRecharge
        原型： int InitRecharge()
        返回值：0 成功 其他 失败
        说明： 打开打卡器，开机时调用一次即可
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int InitRecharge();

        /*
        1.1 设置设备号
        函数名： SetDeviceNumber
        原型： int SetDeviceNumber(unsigned char* deviceNumber)
        说明： 设置设备号，第一次使用时调用即可

        参数名 参数类型 参数说明
        unsigned char* deviceNumber 入参 4字节设备号
        返回值：0 成功 其他 失败        
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int SetDeviceNumber([In]string deviceNumber);

        /* new
        1.2 获取设备号
        函数名： GetDeviceNumber
        原型： int GetDeviceNumber(unsigned char* deviceNumber)
        unsigned char* deviceNumber 出参 4字节设备号
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int GetDeviceNumber([Out]string deviceNumber);

        /*
        1.3 寻卡
        函数名： SearchCard
        原型： int SearchCard(unsigned char *appsnr)
        说明： 获取卡号和卡类型

        参数名 参数类型 参数说明
        unsigned char *appsnr 出参 JSON字符串
        
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int SearchCard([Out]Byte[] result); // 寻卡

        /*new
        1.4 CPU卡钱包圈存初始化
        函数名： CpuCardRechargeInit
        原型： int CpuCardRechargeInit(unsigned int money, unsigned char* resultString)
        unsigned int money 入参 充值金额
        unsigned char* resultString 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CpuCardRechargeInit([In]uint money, [Out]Byte[] result); //

        /*
        1.5 CPU卡钱包充值
        函数名： CpuCardRecharge
        原型： int CpuCardRecharge(unsigned char* rechargeCmdString, unsigned char* resultString)
        unsigned char* rechargeCmdString 入参 服务器返回充值字符串
        unsigned char* resultString 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CpuCardRecharge([In]string rechargeCmdString, [Out]Byte[] result); // 充值

        /*
        1.6 CPU卡月票充值初始化
        函数名： CpuMonthInit
        原型： int CpuMonthInit( unsigned char* resultString)
        unsigned char* resultString 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CpuMonthInit([Out]Byte[] resultString);

        /*
        1.7 CPU卡月票充值
        函数名： CpuMonthRecharge
        原型： int CpuMonthRecharge(unsigned char* rechargeCmdString, unsigned char* resultString)

        unsigned char* rechargeCmdString 入参 服务器返回充值字符串
        unsigned char* resultString 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CpuMonthRecharge([In]string rechargeCmdString, [Out]Byte[] result); // 充值

        /*
        1.8 CPU卡异常处理
        函数名： CpuExceptionHandle
        原型： int CpuExceptionHandle(unsigned char* resultString)
        unsigned char* resultString 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CpuExceptionHandle([Out]Byte[] result);

        /*
        1.9 M1获取余额信息
        函数名： M1GetBalance
        原型： int M1GetBalance(unsigned char* keyString, unsigned char* cardInfo)

        参数名 参数
        类型 参数说明
        unsigned char*
        keyString
        入参 记录中的余额和计数器
        unsigned char* KeyA密钥 
        unsigned char* cardInfo 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1GetBalance([In]string keyString, [Out]Byte[] cardInfo);

        /*
        1.10 M1卡获取账户信息
        函数名： M1ReadAccountInfo
        原型： int M1ReadAccountInfo(unsinged int money, unsigned char* keyString, unsigned int type,  unsigned char* cardInfo)
        
        unsigned int money 入参 充值金额 单位分
        unsigned char* keyString 入参 KeyA密钥
        unsigned int type 入参 1充值月票 0充值钱包
        unsigned char* cardInfo 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1ReadAccountInfo([In]uint money, [In]string keyString, [In]uint type, [Out]Byte[] cardInfo);

        /*
        1.11 M1卡二次寻卡
        函数名： M1SecondSearchCard
        原型： int M1SecondSearchCard()

        00 寻到卡，且是同一张卡
        01 未寻到卡
        21 非同一张卡
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1SecondSearchCard();

        /*
        1.12 M1卡充值
        函数名： M1Recharge
        原型： int M1Recharge(unsigned char* keyString, unsigned char* rechargeResult)

        参数名 参数类型 参数说明
        int money 入参 充值金额，单位分
        unsigned char* keyString 入参 KeyB密钥
        unsigned char* rechargeResult 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1Recharge([In]string keyString, [Out]Byte[] rechargeResult);

        /*
        1.13 M1卡修改启用标志
        函数名： M1UpdateDate
        原型： int M1UpdateDate()

        返回值：
        00 成功
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1UpdateDate();

        /*
        1.14 M1异常处理
        函数名： M1Exception
        原型： int M1Exception(unsigned char* rechargeRecordInfo, unsigned char* rechargeResult)

        参数名 参数
        类型 参数说明
        unsigned char*
        keyString
        入参 记录中的余额和计数器
        {"hasRecord":1,"count":"24","balance":"12"}
        unsigned char*
        rechargeResult 出参 JSON字符串
        */
        [DllImport("recharge.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int M1Exception([In]string rechargeRecordInfo, [Out]Byte[] rechargeResult);

    }
}
