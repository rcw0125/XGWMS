using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace WeightApp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PT_DEVLIST
    {
        public UInt32 dwDeviceNum;
        /**/
        /// <summary>
        /// 设备名，50个字符长。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string szDeviceName;
        /**/
        /// <summary>
        /// 设备的端口数，一般为8个端口。
        /// </summary>
        public Int16 nNumOfSubdevices;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PT_DEVLISTARRAY
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Advantech.MaxEntries)]
        public PT_DEVLIST[] Devices;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct PT_DeviceGetFeatures
    {
        public IntPtr Buffer;
        public int Size;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GainListBlob
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
        public byte[] gainArr;
    }

    /**/
    /// <summary>
    /// Define hardware board(device) features.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DEVFEATURES
    {
        /**/
        /// <summary>
        /// device driver version, array[0..7]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string szDriverVer;
        /**/
        /// <summary>
        /// device driver name, array[0..MAX_DRIVER_NAME_LEN-1]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Advantech.MAX_DRIVER_NAME_LEN)]
        public string szDriverName;
        /**/
        /// <summary>
        /// board ID, DWORD 4 bytes
        /// </summary>
        public uint dwBoardID;
        /**/
        /// <summary>
        /// Max. number of differential channel
        /// </summary>
        public ushort usMaxAIDiffChl;
        /**/
        /// <summary>
        /// Max. number of single-end channel
        /// </summary>
        public ushort usMaxAISiglChl;
        /**/
        /// <summary>
        /// Max. number of D/A channel
        /// </summary>
        public ushort usMaxAOChl;
        /**/
        /// <summary>
        /// Max. number of digital out channel
        /// </summary>
        public ushort usMaxDOChl;
        /**/
        /// <summary>
        /// Max. number of digital input channel
        /// </summary>
        public ushort usMaxDIChl;
        /**/
        /// <summary>
        /// specifies if programmable or not
        /// </summary>
        public ushort usDIOPort;
        /**/
        /// <summary>
        /// Max. number of Counter/Timer channel
        /// </summary>
        public ushort usMaxTimerChl;
        /**/
        /// <summary>
        /// Max number of   alram channel
        /// </summary>
        public ushort usMaxAlarmChl;
        /**/
        /// <summary>
        /// number of bits for A/D converter
        /// </summary>
        public ushort usNumADBit;
        /**/
        /// <summary>
        /// A/D channel width in bytes.
        /// </summary>
        public ushort usNumADByte;
        /**/
        /// <summary>
        /// number of bits for D/A converter. 
        /// </summary>
        public ushort usNumDABit;
        /**/
        /// <summary>
        /// D/A channel width in bytes.
        /// </summary>
        public ushort usNumDAByte;
        /**/
        /// <summary>
        /// Max. number of gain code
        /// </summary>
        public ushort usNumGain;
        /**/
        /// <summary>
        /// Gain listing array[0..15]
        /// </summary>
        public GainListBlob glGainList;
        /**/
        /// <summary>
        /// Permutation array[0..3]
        ///    Bit 0: Software AI                                           
        ///    Bit 1: DMA AI                                                
        ///    Bit 2: Interrupt AI                                          
        ///    Bit 3: Condition AI
        ///    Bit 4: Software AO
        ///    Bit 5: DMA AO
        ///    Bit 6: Interrupt AO
        ///    Bit 7: Condition AO
        ///    Bit 8: Software DI
        ///    Bit 9: DMA DI
        ///    Bit 10: Interrupt DI
        ///    Bit 11: Condition DI
        ///    Bit 12: Software DO
        ///    Bit 13: DMA DO
        ///    Bit 14: Interrupt DO
        ///    Bit 15: Condition DO
        ///    Bit 16: High Gain
        ///    Bit 17: Auto Channel Scan
        ///    Bit 18: Pacer Trigger
        ///    Bit 19: External Trigger
        ///    Bit 20: Down Counter
        ///    Bit 21: Dual DMA
        ///    Bit 22: Monitoring
        ///    Bit 23: QCounter                                             
        /// </summary>
        public uint dwPermutation0;
        public uint dwPermutation1;
        public uint dwPermutation2;
        public uint dwPermutation3;
    }



    /**/
    /// <summary>
    /// 写入设备的数据结构。
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct PT_DioWritePortByte
    {
        [FieldOffset(0)]
        public short Port;
        [FieldOffset(2)]
        public short Mask;
        [FieldOffset(4)]
        public short State;
    }

    /**/
    /// <summary>
    /// 读取IO设备的数据结构。
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct PT_DioReadPortByte
    {
        [FieldOffset(0)]
        public short Port;
        [FieldOffset(4)]
        public IntPtr value;
    }
    public class Advantech
    {

        /**/
        ///  <summary>  
        ///  /// 最大设备个数  
        ///  ///  </summary>  
        ///  
        public const short MaxEntries = 255;
        public const short MaxDevices = 255;
        public const short MAX_DRIVER_NAME_LEN = 16;

        /**/
        ///  <summary>  
        ///  /// 获取设备列表。  
        ///  ///  </summary>  
        ///  ///  <param name="deviceList">返回的设备列表清单数组 </param>  
        ///  ///  <param name="maxEntries">最大的设备数 </param>  
        ///  ///  <param name="outEntries">返回的设备数 </param>  
        ///  ///  <returns>返回值为 0 则表示执行成功，否则执行失败。 </returns>  
        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        static extern int DRV_DeviceGetList(IntPtr deviceList, Int16 maxEntries, ref short outEntries);

        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        static extern int DRV_DeviceGetFeatures(int DriverHandle, ref PT_DeviceGetFeatures lpDeviceGetFeatures);

        /**/
        ///  <summary>  
        ///  /// 获取设备列表个数，就基本用不到它，姑且留着。  
        ///  ///  </summary>  
        ///  ///  <param name="numOfDevices"> </param>  
        ///  ///  <returns> </returns>  
        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        public static extern int DRV_DeviceGetNumOfList(ref short numOfDevices);

        /**/
        ///  <summary>  232         /// 打开设备。  
        ///  ///  </summary>  
        ///  ///  <param name="deviceNum">设备号 </param>  
        ///  ///  <param name="driverHandle">设备句柄 </param>  
        ///  ///  <returns> </returns>  
        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        public static extern int DRV_DeviceOpen(uint deviceNum, ref int driverHandle);

        /**/
        ///  <summary>  
        ///  /// 向端口写数字信号。  
        ///  ///  </summary>  
        ///  ///  <param name="DriverHandle"> </param>  
        ///  ///  <param name="lpDioWritePortByte"> </param>  
        ///  ///  <returns> </returns>  
        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        static extern int DRV_DioWritePortByte(int driverHandle, ref PT_DioWritePortByte lpDioWritePortByte);

        [DllImport("adsapi32.dll", CharSet = CharSet.Ansi)]
        static extern int DRV_DioReadPortByte(int driverHandle, ref PT_DioReadPortByte lpDioReadPortByte);

        /**/
        ///  <summary>  
        ///  /// 获取主机上安装的设备列表。  
        ///  ///  </summary>  
        ///  ///  <returns>返回错误代码，如果无错误，则返回0。 </returns>  
        public static int GetDeviceList(out PT_DEVLISTARRAY deviceList, ref short outEntries)
        {
            deviceList = new PT_DEVLISTARRAY();
            int _DeviceListLenght = Marshal.SizeOf(deviceList);
            IntPtr _DeviceListPoint = Marshal.AllocHGlobal(_DeviceListLenght);
            //打开设备的检查过程  
            int errorCode = Advantech.DRV_DeviceGetList(_DeviceListPoint, MaxEntries, ref outEntries);
            deviceList = (PT_DEVLISTARRAY)Marshal.PtrToStructure(_DeviceListPoint, typeof(PT_DEVLISTARRAY));
            Marshal.FreeHGlobal(_DeviceListPoint);
            return errorCode;
        }
        public static int GetFeatures(int deviceHandle, out DEVFEATURES outDevFeatures)
        {
            int iLength;
            int ErrCde = 0;
            PT_DeviceGetFeatures ptDevGetFeatures = new PT_DeviceGetFeatures();
            outDevFeatures = new DEVFEATURES();

            outDevFeatures.szDriverVer = "?";
            outDevFeatures.szDriverName = "?";
            iLength = Marshal.SizeOf(outDevFeatures);
            //and reserve the space   
            IntPtr DevFeaturesPointer = Marshal.AllocHGlobal(iLength);
            //Copy the pointer into the struct  
            ptDevGetFeatures.Buffer = DevFeaturesPointer;
            //and get the features  
            ErrCde = DRV_DeviceGetFeatures(deviceHandle, ref ptDevGetFeatures);
            if (ErrCde == 0)
            {
                outDevFeatures = (DEVFEATURES)Marshal.PtrToStructure(DevFeaturesPointer, typeof(DEVFEATURES));
            }
            else
            {
                //Error  
            }
            Marshal.FreeHGlobal(DevFeaturesPointer);
            return ErrCde;
        }

        /**/
        ///  <summary>  
        ///  /// 数字信号按端口输出。  
        ///  ///  </summary>  
        ///  ///  <param name="deviceHandle"> </param>  
        ///  ///  <param name="port"> </param>  
        ///  ///  <param name="value"> </param>  
        ///  ///  <param name="mask"> </param>  
        ///  ///  <returns> </returns>  
        ///  
        public static int Digital_WriteByteToPort(int deviceHandle, short port, short value, short mask)
        {
            PT_DioWritePortByte data = new PT_DioWritePortByte();
            data.Port = port;
            data.State = value;
            data.Mask = mask;
            return DRV_DioWritePortByte(deviceHandle, ref data);
        }

        public static int Digital_WriteByteToPort(int deviceHandle, short port, short value)
        {
            return Digital_WriteByteToPort(deviceHandle, port, value, 255);
        }

        /**/
        ///  <summary>  
        ///  /// 从指定的端口获取数据。  
        ///  ///  </summary>
        ///  
        ///  <param name="deviceHandle"> </param>  
        ///  ///  <param name="port"> </param>  
        ///  ///  <param name="value"> </param>  
        ///  ///  <returns> </returns>  
        ///  
        public static int Digital_ReadByteFromPort(int deviceHandle, short port, out short value)
        {
            int error = 0;
            short tempValue = 0;
            IntPtr vpoint = Marshal.AllocHGlobal(Marshal.SizeOf(tempValue));
            try
            {
                Marshal.StructureToPtr(tempValue, vpoint, false);
                PT_DioReadPortByte data = new PT_DioReadPortByte();
                data.Port = port;
                data.value = vpoint;
                error = DRV_DioReadPortByte(deviceHandle, ref data);
                tempValue = (short)Marshal.PtrToStructure(vpoint, typeof(short));
                value = tempValue;
            }
            finally
            {
                Marshal.FreeHGlobal(vpoint);
            }
            return error;
        }

    }
}

