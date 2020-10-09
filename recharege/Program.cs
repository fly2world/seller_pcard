using recharege.DLL;
using recharege.Entity.Dll;
using recharege.Services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace recharege
{
    class Program
    {
        private static DllRechargeServiceImpl dllRechargeServiceImpl = new DllRechargeServiceImpl();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(936);

            if (args.Length < 1)
            {
                Console.WriteLine("操作失败.参数不能为空.");
                return;
            }

            string identification = args[0].ToString().Trim();

            if ("0".Equals(identification))
            {
                //打开设备
                Console.WriteLine(dllRechargeServiceImpl.InitRechargeHandler());
            }
            else if ("1".Equals(identification))
            {
                //设置设备号
                string deviceNumber = args[1].ToString().Trim();
                Console.WriteLine(dllRechargeServiceImpl.SetDeviceNumberHandler(deviceNumber));
            }
            else if ("2".Equals(identification))
            {
                //获取设备号

                Console.WriteLine(dllRechargeServiceImpl.GetDeviceNumberHandler());
            }
            else if ("3".Equals(identification))
            {
                //寻卡
                Console.WriteLine(dllRechargeServiceImpl.SearchCardHandler());
            }
            else if ("4".Equals(identification))
            {
                //CPU卡钱包圈存初始化
                uint money = uint.Parse(args[1].ToString().Trim());
                Console.WriteLine(dllRechargeServiceImpl.CpuCardRechargeInitHandler(money));
            }
            else if ("5".Equals(identification))
            {
                //CPU卡钱包充值
                string rechargeCmdString = args[1].ToString().Trim();
                Console.WriteLine(dllRechargeServiceImpl.CpuCardRechargeHandler(rechargeCmdString));
            }
            else if ("6".Equals(identification))
            {
                //CPU卡月票充值初始化
                Console.WriteLine(dllRechargeServiceImpl.CpuMonthInitHandler());
            }
            else if ("7".Equals(identification))
            {
                //CPU卡月票充值
                string rechargeCmdString = args[1].ToString().Trim();
                Console.WriteLine(dllRechargeServiceImpl.CpuMonthRecharge(rechargeCmdString));
            }
            else if ("8".Equals(identification))
            {
                //CPU卡异常处理
                Console.WriteLine(dllRechargeServiceImpl.CpuExceptionHandle());
            }
            else if ("9".Equals(identification))
            {
                //M1获取余额
                string keyString = args[1].ToString().Trim();
                Console.WriteLine(dllRechargeServiceImpl.M1GetBalance(keyString));
            }
            else if ("10".Equals(identification))
            {
                //M1卡获取账户信息
                uint rechargeMoney = uint.Parse(args[1].ToString().Trim());
                string keyA = args[2].ToString().Trim();
                uint rechargeType = uint.Parse(args[3].ToString().Trim());

                Console.WriteLine(dllRechargeServiceImpl.M1ReadAccountInfoHandler(rechargeMoney, keyA, rechargeType));
            }
            else if ("11".Equals(identification))
            {
                //M1卡二次寻卡
                Console.WriteLine(dllRechargeServiceImpl.M1SecondSearchCardHandler());
            }
            else if ("12".Equals(identification))
            {
                //M1卡充值
                string keyB = args[1].ToString().Trim();
                Console.WriteLine(dllRechargeServiceImpl.M1RechargeHandler(keyB));
            }
            else if ("13".Equals(identification))
            {
                //M1卡修改启用标志
                Console.WriteLine(dllRechargeServiceImpl.M1UpdateDate());
            }
            else if ("14".Equals(identification))
            {
                //M1异常处理
                DllM1ExceptionIn dllM1ExceptionIn = new DllM1ExceptionIn();
                dllM1ExceptionIn.HasRecord = args[1].ToString().Trim();
                dllM1ExceptionIn.Count = args[2].ToString().Trim();
                dllM1ExceptionIn.Balance = args[3].ToString().Trim();

                Console.WriteLine(dllRechargeServiceImpl.M1Exception(dllM1ExceptionIn));
            }
        }
    }
}
