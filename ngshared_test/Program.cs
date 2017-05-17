using System;
using System.Runtime.InteropServices;

namespace ngshared_test
{
    class Program
    {
        private delegate int SendChar(string toCallerOutput, int ID, IntPtr callerPointer);

        private delegate int SendStat(string statusAndValue, int ID, IntPtr callerPointer);

        private delegate int ControlledExit(int exitStatus, bool loadingStatus, bool quitStatus, int ID, IntPtr callerPointer);

        private delegate int SendData(vecvluesall ,int StructNumber, int ID, IntPtr callerPointer);

        private delegate int SendInitData(vecinfoall , int ID, IntPtr callerPointer);

        private delegate int BGThreadRunning(bool bg_runCheck, int ID, IntPtr callerPointer);

        [DllImport("../../src/ngspice.dll")]
        public static extern int ngSpice_Init(
            SendChar printfcn,
            SendStat statfcn,
            ControlledExit ngexit,
            SendData sdata,
            SendInitData sinitdata,
            BGThreadRunning bgtrun,
            IntPtr userdata);

        [DllImport("../../src/ngspice.dll")]
        public static extern bool ngSpice_Command(string command);

        [DllImport("../../src/ngspice.dll")]
        public static extern bool ngSpice_running();

        static void Main(string[] args)
        {
            ngSpice_Init(
                );

            ngSpice_Command("cd C:\ngspice\tests\resistance");
            ngSpice_Command("source res_array.cir");
            ngSpice_Command("run");


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
