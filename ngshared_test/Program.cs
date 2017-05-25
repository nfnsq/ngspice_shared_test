using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ngshared_test
{
    public class Init
    {
        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            //param0 += 7;
            return 0;
        }
        private static int cbSendStat(IntPtr param0, int param1, IntPtr param2)
        {
            return 0;
        }
        private static int cbSendData(ref vecvaluesall param0, int param1, int param2, IntPtr param3)
        {
            return 0;
        }
        private static int cbSendInitData(ref vecinfoall param0, int param1, IntPtr param2)
        {
            return 0;
        }
        private static int cbBGThreadRunnig([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2)
        {
            return 0;
        }

        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
        {
            Console.WriteLine("contolled exit");
            return param0;
        }

        public Init()
        {
            SendChar sc = new SendChar(cbSendChar);
            SendStat ss = new SendStat(cbSendStat);
            ControlledExit ce = new ControlledExit(cbControlledExit);
            SendData sd = new SendData(cbSendData);
            SendInitData sid = new SendInitData(cbSendInitData);
            BGThreadRunning bgtrun = new BGThreadRunning(cbBGThreadRunnig);
        //  sc = null;
        //  ss = null;
        //  sd = null;
        //  sid = null;
        //  bgtrun = null;
            //NativeMethods.ngSpice_Init(ref sc, ref ss, ref ce, ref sd, ref sid, ref bgtrun, IntPtr.Zero);
            NativeMethods.ngSpice_Init(ref sc, ref ss, ref ce, ref sd, ref sid, ref bgtrun, IntPtr.Zero);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ControlledExit ce = new ControlledExit(cbControlledExit);
            //NativeMethods.ngSpice_Init(null, null, ce, null, null, null, Marshal.GetIUnknownForObject(this));
            Init initialization = new Init();
            //IntPtr command = Marshal.GetIUnknownForObject("bg_run");
            //NativeMethods.ngSpice_Command(command);
            //ngSpice_Command("source res_array.cir");
            //ngSpice_Command("run");

         if (NativeMethods.ngSpice_running())
         {
             Console.WriteLine("true");
         }
         else
         {
             Console.WriteLine("false");
         }
         Console.ReadLine();
        }

    }
}
