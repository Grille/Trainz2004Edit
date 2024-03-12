using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace TRS2004Edit;

public unsafe class BinaryView
{
    byte[] bytes;
    bool write;

    public BinaryView(byte[] bytes, bool write)
    {
        this.bytes = bytes;
        this.write = write;
    }

    public void _<T>(int pos, ref T obj) where T : unmanaged
    {
        fixed (byte* ptr = bytes)
        {
            if (write)
            {
                *(T*)(ptr + pos) = obj;
            }
            else
            {
                obj = *(T*)(ptr + pos);
            }
        }
    }
}
