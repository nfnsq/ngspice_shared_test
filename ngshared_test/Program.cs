using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ngshared_test
{
    class Program
    {
        public delegate int SendChar(
            string toCallerOutput,
            int ID,
            IntPtr returnPointer);

        public delegate int SendStat(
            string toCallerOutput,
            int ID,
            IntPtr returnPointer);

        public delegate int ControlledExit(
            int exitStatus,
            bool immeadiateDLL,
            bool quitIsExit,
            int ID,
            IntPtr returnPointer);

        public delegate int SendData(
            Vecvaluesall vecvaluesall,
            int structNumber,
            int ID,
            IntPtr returnPointer);

        public delegate int SendInitData(
            Vecinfoall vecinfoall,
            int ID,
            IntPtr returnPointer);

        public delegate int BGThreadRunning(
            string toCallerOutput,
            int ID,
            IntPtr returnPointer);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Vector_Info
        {
            string v_name;
            int v_type;
            short v_flags;
            double v_realdata;
            Complex c_compdata;
            int v_length;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Vecvalues
        {
            string name;
            double creal;
            double cimag;
            bool is_scale;
            bool is_complex;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Vecvaluesall
        {
            int veccount;
            int vecindex;
            Vecvalues vecsa;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Vecinfo
        {
            int number;
            string vecname;
            bool is_real;
            IntPtr pdvec;
            IntPtr pdvecscale;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Vecinfoall
        {
            string name;
            string title;
            string data;
            string type;
            int veccount;
        }

        [DllImport("../../src/ngspice.dll")]
        public static extern int ngSpice_Init(
            SendChar printfcn,
            SendStat statfcn,
            ControlledExit ngexit,
            SendData sdata,
            SendInitData sinitdata,
            BGThreadRunning bgtrun,
            IntPtr userData);

        [DllImport("../../src/ngspice.dll")]
        public static extern bool ngSpice_Command(string command);

        [DllImport("../../src/ngspice.dll")]
        public static extern bool ngSpice_running();

        static void Main(string[] args)
        {
            ngSpice_Init();
            ngSpice_Command("bg_run");
            //ngSpice_Command("source res_array.cir");
            //ngSpice_Command("run");


            if (ngSpice_running())
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
