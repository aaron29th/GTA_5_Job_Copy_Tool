using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA_5_json_editor;
using PS3Lib;

namespace GTA_5_Job_Copy_Tool
{
    class RPC
    {
        public static PS3API PS3;

        private static uint SFA1 = 0x1BE4C80;
        private static uint EFA1 = 0x1BE4D08;
        private static uint BFA1 = 0x18614;
        private static uint BAB1 = 0x18620;

        public static uint CBAB(uint F, uint T)
        {
            if (F > T)
                return 0x4C000000 - (F - T);
            else if (F < T)
                return T - F + 0x48000000;
            else
                return 0x48000000;
        }

        public static void Enable()
        {
            byte[] mem = new byte[] {
            0xF8, 0x21, 0xFF, 0x91,
            0x7C, 0x08, 0x02, 0xA6,
            0xF8, 0x01, 0x00, 0x80,
            0x3C, 0x60, 0x10, 0x04,
            0x81, 0x83, 0x00, 0x4C,
            0x2C, 0x0C, 0x00, 0x00,
            0x41, 0x82, 0x00, 0x64,
            0x80, 0x83, 0x00, 0x04,
            0x80, 0xA3, 0x00, 0x08,
            0x80, 0xC3, 0x00, 0x0C,
            0x80, 0xE3, 0x00, 0x10,
            0x81, 0x03, 0x00, 0x14,
            0x81, 0x23, 0x00, 0x18,
            0x81, 0x43, 0x00, 0x1C,
            0x81, 0x63, 0x00, 0x20,
            0xC0, 0x23, 0x00, 0x24,
            0xc0, 0x43, 0x00, 0x28,
            0xC0, 0x63, 0x00, 0x2C,
            0xC0, 0x83, 0x00, 0x30,
            0xC0, 0xA3, 0x00, 0x34,
            0xc0, 0xC3, 0x00, 0x38,
            0xC0, 0xE3, 0x00, 0x3C,
            0xC1, 0x03, 0x00, 0x40,
            0xC1, 0x23, 0x00, 0x48,
            0x80, 0x63, 0x00, 0x00,
            0x7D, 0x89, 0x03, 0xA6,
            0x4E, 0x80, 0x04, 0x21,
            0x3C, 0x80, 0x10, 0x04,
            0x38, 0xA0, 0x00, 0x00,
            0x90, 0xA4, 0x00, 0x4C,
            0x90, 0x64, 0x00, 0x50,
            0xE8, 0x01, 0x00, 0x80,
            0x7C, 0x08, 0x03, 0xA6,
            0x38, 0x21, 0x00, 0x70 };

            PS3.SetMemory(SFA1, mem);
            PS3.Extension.WriteUInt32(EFA1, CBAB(EFA1, BAB1));
            PS3.Extension.WriteUInt32(BFA1, CBAB(BFA1, SFA1));
        }

        public static int Call(Natives func_address, params object[] parameters)
        {
            uint address = (uint)func_address;
            int length = parameters.Length;
            int index = 0;
            uint num3 = 0;
            uint num4 = 0;
            uint num5 = 0;
            uint num6 = 0;
            while (index < length)
            {
                if (parameters[index] is int)
                {
                    PS3.Extension.WriteInt32(0x10040000 + (num3 * 4), (int)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is uint)
                {
                    PS3.Extension.WriteUInt32(0x10040000 + (num3 * 4), (uint)parameters[index]);
                    num3++;
                }
                else
                {
                    uint num7;
                    if (parameters[index] is string)
                    {
                        num7 = 0x10042000 + (num4 * 0x400);
                        PS3.Extension.WriteString(num7, Convert.ToString(parameters[index]));
                        PS3.Extension.WriteUInt32(0x10040000 + (num3 * 4), num7);
                        num3++;
                        num4++;
                    }
                    else if (parameters[index] is float)
                    {
                        WriteSingle(0x10040024 + (num5 * 4), (float)parameters[index]);
                        num5++;
                    }
                    else if (parameters[index] is float[])
                    {
                        float[] input = (float[])parameters[index];
                        num7 = 0x10041000 + (num6 * 4);
                        WriteSingle(num7, input);
                        PS3.Extension.WriteUInt32(0x10040000 + (num3 * 4), num7);
                        num3++;
                        num6 += (uint)input.Length;
                    }
                }
                index++;
            }
            PS3.Extension.WriteUInt32(0x1004004C, address);
            while (PS3.Extension.ReadUInt32(0x1004004C) != 0) ;

            return PS3.Extension.ReadInt32(0x10040050);
        }

        private static void WriteSingle(uint address, float input)
        {
            byte[] Bytes = new byte[4];
            BitConverter.GetBytes(input).CopyTo((Array)Bytes, 0);
            Array.Reverse((Array)Bytes, 0, 4);
            PS3.SetMemory(address, Bytes);
        }

        private static void WriteSingle(uint address, float[] input)
        {
            int length = input.Length;
            byte[] Bytes = new byte[length * 4];
            for (int index = 0; index < length; ++index)
                ReverseBytes(BitConverter.GetBytes(input[index])).CopyTo((Array)Bytes, index * 4);
            PS3.SetMemory(address, Bytes);
        }

        private static byte[] ReverseBytes(byte[] toReverse)
        {
            Array.Reverse((Array)toReverse);
            return toReverse;
        }
    }
}
