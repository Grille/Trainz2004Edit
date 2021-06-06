using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRS2004Edit
{
    unsafe struct half
    {
        byte a;
        byte b;
        public static explicit operator half(float f)
        {
            var h = new half();
            var bytes = BitConverter.GetBytes(f);
            h.a = bytes[2];
            h.b = bytes[3];
            return h;
        }
        public static implicit operator float(half h)
        {
            return BitConverter.ToSingle(new byte[] { 0, 0, h.a, h.b }, 0);
        }
    }


}
