using recharege.Entity.Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace recharege.Services
{
    public interface DllRechargeService
    {
        // 1.0 打开设备
        int InitRechargeHandler();

        // 1.1 设置设备号
        int SetDeviceNumberHandler(string deviceNumber);

        // 1.2 获取设备号
        string GetDeviceNumberHandler();

        // 1.3 寻卡
        string SearchCardHandler();

        // 1.4 CPU卡钱包圈存初始化
        string CpuCardRechargeInitHandler(uint money);

        // 1.5 CPU卡钱包充值
        string CpuCardRechargeHandler(string rechargeCmdString);

        // 1.6 CPU卡月票充值初始化
        string CpuMonthInitHandler();

        // 1.7 CPU卡月票充值
        string CpuMonthRecharge(string rechargeCmdString);

        // 1.8 CPU卡异常处理
        string CpuExceptionHandle();

        // 1.9 M1获取余额
        string M1GetBalance(string keyString);

        // 1.10 M1卡获取账户信息
        string M1ReadAccountInfoHandler(uint rechargeMoney, string keyA, uint rechargeType);

        // 1.11 M1卡二次寻卡
        int M1SecondSearchCardHandler();

        // 1.12 M1卡充值
        string M1RechargeHandler(string keyB);

        // 1.13 M1卡修改启用标志
        int M1UpdateDate();

        // 1.14 M1异常处理
        string M1Exception(DllM1ExceptionIn dllM1ExceptionIn);
    }
}
