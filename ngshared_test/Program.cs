using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ngshared_test
{
    public class Init
    {
        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
        {
            Console.WriteLine("contolled exit");
            return param0;
        }
        public void InitNgSpice(SendChar sc, SendStat ss, SendData sd, SendInitData sid, BGThreadRunning bgtrun)
        {

            ControlledExit ce = new ControlledExit(cbControlledExit);

            NativeMethods.ngSpice_Init(ref sc, ref ss, ref ce, ref sd, ref sid, ref bgtrun, Marshal.GetIUnknownForObject(this));
        }
    }
    class Program
    {
        

        

        static void Main(string[] args)
        {
            //ControlledExit ce = new ControlledExit(cbControlledExit);
            //NativeMethods.ngSpice_Init(null, null, ce, null, null, null, Marshal.GetIUnknownForObject(this));
            Init initialization = new Init();
            initialization.InitNgSpice(null, null, null, null, null);
            IntPtr command = Marshal.GetIUnknownForObject("bg_run");
            NativeMethods.ngSpice_Command(command);
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
