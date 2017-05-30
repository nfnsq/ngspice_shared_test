using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ngshared_test
{
    public partial class NativeConstants
    {

        /// NGSPICE_DLL_H -> 
        /// Error generating expression: Значение не может быть неопределенным.
        ///Имя параметра: node
        public const string NGSPICE_DLL_H = "";

        /// IMPEXP -> __declspec(dllimport)
        /// Error generating expression: Error generating function call.  Operation not implemented
        public const string IMPEXP = "__declspec(dllimport)";
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ngcomplex
    {

        /// double
        public double cx_real;

        /// double
        public double cx_imag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vector_info
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string v_name;

        /// int
        public int v_type;

        /// short
        public short v_flags;

        /// double*
        public IntPtr v_realdata;

        /// ngcomplex_t*
        public IntPtr v_compdata;

        /// int
        public int v_length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecvalues
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;

        /// double
        public double creal;

        /// double
        public double cimag;

        /// boolean
        [MarshalAs(UnmanagedType.U1)]
        public bool is_scale;

        /// boolean
        [MarshalAs(UnmanagedType.U1)]
        public bool is_complex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecvaluesall
    {

        /// int
        public int veccount;

        /// int
        public int vecindex;

        /// pvecvalues*
        public IntPtr vecsa;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecinfo
    {

        /// int
        public int number;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string vecname;

        /// boolean
        public bool is_real;

        /// void*
        public IntPtr pdvec;

        /// void*
        public IntPtr pdvecscale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecinfoall
    {

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string title;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string date;

        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string type;

        /// int
        public int veccount;

        /// pvecinfo*
        public IntPtr vecs;
    }

    /// Return Type: int
    ///param0: char*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendChar(IntPtr param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: char*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendStat(IntPtr param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: int
    ///param1: boolean
    ///param2: boolean
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int ControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: pvecvaluesall->vecvaluesall*
    ///param1: int
    ///param2: int
    ///param3: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendData(ref vecvaluesall param0, int param1, int param2, IntPtr param3);

    /// Return Type: int
    ///param0: pvecinfoall->vecinfoall*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendInitData(ref vecinfoall param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: boolean
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int BGThreadRunning([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: double*
    ///param1: double
    ///param2: char*
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetVSRCData(ref double param0, double param1, IntPtr param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: double*
    ///param1: double
    ///param2: char*
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetISRCData(ref double param0, double param1, IntPtr param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: double
    ///param1: double*
    ///param2: double
    ///param3: int
    ///param4: int
    ///param5: int
    ///param6: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetSyncData(double param0, ref double param1, double param2, int param3, int param4, int param5, IntPtr param6);

    public partial class NativeMethods
    {

        /// Return Type: int
        ///printfcn: SendChar*
        ///statfcn: SendStat*
        ///ngexit: ControlledExit*
        ///sdata: SendData*
        ///sinitdata: SendInitData*
        ///bgtrun: BGThreadRunning*
        ///userData: void*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_Init", 
            SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Init(ref SendChar printfcn, ref SendStat statfcn, ref ControlledExit ngexit, ref SendData sdata, ref SendInitData sinitdata, ref BGThreadRunning bgtrun, IntPtr userData);


        /// Return Type: int
        ///vsrcdat: GetVSRCData*
        ///isrcdat: GetISRCData*
        ///syncdat: GetSyncData*
        ///ident: int*
        ///userData: void*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll",
            EntryPoint = "ngSpice_Init_Sync",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Init_Sync(ref GetVSRCData vsrcdat, ref GetISRCData isrcdat, ref GetSyncData syncdat, ref int ident, IntPtr userData);


        /// Return Type: int
        ///command: char*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_Command",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Command(IntPtr command);


        /// Return Type: pvector_info->vector_info*
        ///vecname: char*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngGet_Vec_Info",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngGet_Vec_Info(IntPtr vecname);


        /// Return Type: int
        ///circarray: char**
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_Circ",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Circ(ref IntPtr circarray);


        /// Return Type: char*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_CurPlot",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_CurPlot();


        /// Return Type: char**
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_AllPlots",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_AllPlots();


        /// Return Type: char**
        ///plotname: char*
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_AllVecs",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_AllVecs(IntPtr plotname);


        /// Return Type: boolean
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_running",
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ngSpice_running();


        /// Return Type: boolean
        ///time: double
        [DllImport("C:/ngspice/visualc/sharedspice/Debug.Win32/ngspice.dll", 
            EntryPoint = "ngSpice_SetBkpt",
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ngSpice_SetBkpt(double time);

    }
}
