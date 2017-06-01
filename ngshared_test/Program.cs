using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Globalization;
using System.Windows;

namespace ngshared_test
{
    public class Init
    {
        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            string message = Marshal.PtrToStringAnsi(param0);

            Console.WriteLine("lib {0}: {1}", param1, message);
            return 1;
        }
        private static int cbSendStat(IntPtr param0, int param1, IntPtr param2)
        {
            string stat = Marshal.PtrToStringAnsi(param0);

            Console.WriteLine("lib {0}: {1}", param1, stat);
            return 1;
        }
        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
        {
            Console.WriteLine("contolled exit");
            return param0;
        }
        private static int cbSendData(IntPtr param0, int param1, int param2, IntPtr param3)
        {
            return 1;
        }
        private static int cbSendInitData(IntPtr param0, int param1, IntPtr param2)
        {
            return 1;
        }
        private static int cbBGThreadRunnig([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2)
        {
            return 1;
        }


        public Init()
        {
            SendChar sc = new SendChar(cbSendChar);
            SendStat ss = new SendStat(cbSendStat);
            ControlledExit ce = new ControlledExit(cbControlledExit);
            SendData sd = new SendData(cbSendData);
            SendInitData sid = new SendInitData(cbSendInitData);
            BGThreadRunning bgtrun = new BGThreadRunning(cbBGThreadRunnig);

            IntPtr caller = Marshal.AllocHGlobal(Marshal.SizeOf(this));
            Marshal.StructureToPtr(this, caller, false);

            NativeMethods.ngSpice_Init(
                Marshal.GetFunctionPointerForDelegate(sc),
                Marshal.GetFunctionPointerForDelegate(ss),
                Marshal.GetFunctionPointerForDelegate(ce),
                Marshal.GetFunctionPointerForDelegate(sd),
                Marshal.GetFunctionPointerForDelegate(sid),
                Marshal.GetFunctionPointerForDelegate(bgtrun), 
                caller);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ControlledExit ce = new ControlledExit(cbControlledExit);
            //NativeMethods.ngSpice_Init(null, null, ce, null, null, null, Marshal.GetIUnknownForObject(this));
            SendChar sc = new SendChar(cbSendChar);
            SendStat ss = new SendStat(cbSendStat);
            ControlledExit ce = new ControlledExit(cbControlledExit);
            SendData sd = new SendData(cbSendData);
            SendInitData sid = new SendInitData(cbSendInitData);
            BGThreadRunning bgtrun = new BGThreadRunning(cbBGThreadRunnig);
            int thread = Thread.CurrentThread.ManagedThreadId;

            IntPtr caller = Marshal.AllocHGlobal(Marshal.SizeOf(thread));
            Marshal.StructureToPtr(thread, caller, false);

            NativeMethods.ngSpice_Init(
                Marshal.GetFunctionPointerForDelegate(sc),
                Marshal.GetFunctionPointerForDelegate(ss),
                Marshal.GetFunctionPointerForDelegate(ce),
                Marshal.GetFunctionPointerForDelegate(sd),
                Marshal.GetFunctionPointerForDelegate(sid),
                Marshal.GetFunctionPointerForDelegate(bgtrun),
                caller);
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
        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            string message = Marshal.PtrToStringAnsi(param0);

            Console.WriteLine("lib {0}: {1}", param1, message);
            return 1;
        }
        private static int cbSendStat(IntPtr param0, int param1, IntPtr param2)
        {
            string stat = Marshal.PtrToStringAnsi(param0);

            Console.WriteLine("lib {0}: {1}", param1, stat);
            return 1;
        }
        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
        {
            Console.WriteLine("contolled exit");
            return param0;
        }
        private static int cbSendData(IntPtr param0, int param1, int param2, IntPtr param3)
        {
            return 1;
        }
        private static int cbSendInitData(IntPtr param0, int param1, IntPtr param2)
        {
            return 1;
        }
        private static int cbBGThreadRunnig([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2)
        {
            return 1;
        }

    }
}
