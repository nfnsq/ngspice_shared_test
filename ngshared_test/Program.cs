using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Globalization;
using System.Windows;
using System.Text.RegularExpressions;

namespace ngshared_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1.000000e-02";
            double x = double.Parse(str, CultureInfo.InvariantCulture);
            Console.WriteLine(str + "\n" + x);
            Console.ReadLine();
            /*
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
            //NativeMethods.ngSpice_Command("bg_run");
            NativeMethods.ngSpice_Command("source ../../../test.cir");
            NativeMethods.ngSpice_Command("run");
            NativeMethods.ngSpice_Command("ac dec 10 0.01 100");
            NativeMethods.ngSpice_Command("print vdb(2)");

            if (NativeMethods.ngSpice_running())
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            var re = new Regex("stdout ");
            _text = re.Replace(_text, "");
            int index = _text.IndexOf("\t");
            _text = _text.Substring(index - 1);
            char delimiter = '\t';
            string[] substrings = _text.Split(delimiter);
            for (int i = 0; i < substrings.Length - 3; i += 3)
            {
                double x = double.Parse(substrings[i + 1]);
                double y = double.Parse(substrings[i + 2]);

            }
            Console.ReadLine();
        }
        private static string _text;
        private static bool _write = false;
        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            string message = Marshal.PtrToStringAnsi(param0);
            if (Regex.IsMatch(message, "AC Analysis"))
            {
                _write = true;
            }
            if (_write)
            {

                _text += message;
            }

            //Console.WriteLine("lib {0}: {1}", param1, message);
            return 1;
        }
        private static int cbSendStat(IntPtr param0, int param1, IntPtr param2)
        {
            string stat = Marshal.PtrToStringAnsi(param0);

            //Console.WriteLine("lib {0}: {1}", param1, stat);
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
        */
        }
    }
}
