using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace TRS2004Edit
{
    public class BinaryView
    {
        public byte[] Bytes;


        public BinaryView(byte[] bytes)
        {
            Bytes = bytes;
        }

        public unsafe void Write<T>(int pos, T obj) where T : unmanaged
        {
            int size = sizeof(T);
            var ptr = new IntPtr(&obj);
            for (int i = 0; i < size; i++) 
                Bytes[pos+i] = Marshal.ReadByte(ptr, i);
        }

        public unsafe T Read<T>(int pos) where T : unmanaged
        {
            int size = sizeof(T);
            var obj = new T();
            var ptr = new IntPtr(&obj);
            for (int i = 0; i < size; i++) 
                Marshal.WriteByte(ptr, i, Bytes[pos + i]);
            return obj;
        }



    }
}
