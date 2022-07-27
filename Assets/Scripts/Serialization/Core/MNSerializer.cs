using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
struct MNFloat
{
    [FieldOffset(0)]
    public byte b0;
    [FieldOffset(1)]
    public byte b1;
    [FieldOffset(2)]
    public byte b2;
    [FieldOffset(3)]
    public byte b3;

    [FieldOffset(0)]
    public float floatVal;

    public static float Read(byte[] b, ref int cnt)
    {
        MNFloat s = new MNFloat();
        s.b0 = b[cnt++];
        s.b1 = b[cnt++];
        s.b2 = b[cnt++];
        s.b3 = b[cnt++];
        return s.floatVal;
    }
    public static void Write(ref byte[] b, ref int cnt, float value)
    {
        MNFloat s = new MNFloat();
        s.floatVal = value;
        b[cnt++] = s.b0;
        b[cnt++] = s.b1;
        b[cnt++] = s.b2;
        b[cnt++] = s.b3;
    }
}
public class MNSerializer
{

    public static void Write(short value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
    }

    public static void Write(ushort value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
    }

    public static void Write(byte value, ref int position, ref byte[] b)
    {
        b[position++] = value;
    }

    public static void Write(sbyte value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
    }

    public static void Write(bool value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)(value ? 1 : 0);
    }

    public static void Write(int value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
        b[position++] = (byte)(value >> 16);
        b[position++] = (byte)(value >> 24);
    }

    public static void Write(uint value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
        b[position++] = (byte)(value >> 16);
        b[position++] = (byte)(value >> 24);
    }

    [System.Security.SecuritySafeCritical]
    public static unsafe void Write(float value, ref int position, ref byte[] b)
    {
        uint TmpValue = *(uint*)&value;
        b[position++] = (byte)TmpValue;
        b[position++] = (byte)(TmpValue >> 8);
        b[position++] = (byte)(TmpValue >> 16);
        b[position++] = (byte)(TmpValue >> 24);
    }

    [System.Security.SecuritySafeCritical]  // auto-generated
    public static unsafe void Write(double value, ref int position, ref byte[] b)
    {
        ulong TmpValue = *(ulong*)&value;
        b[position++] = (byte)TmpValue;
        b[position++] = (byte)(TmpValue >> 8);
        b[position++] = (byte)(TmpValue >> 16);
        b[position++] = (byte)(TmpValue >> 24);
        b[position++] = (byte)(TmpValue >> 32);
        b[position++] = (byte)(TmpValue >> 40);
        b[position++] = (byte)(TmpValue >> 48);
        b[position++] = (byte)(TmpValue >> 56);
    }

    public static void Write(long value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
        b[position++] = (byte)(value >> 16);
        b[position++] = (byte)(value >> 24);
        b[position++] = (byte)(value >> 32);
        b[position++] = (byte)(value >> 40);
        b[position++] = (byte)(value >> 48);
        b[position++] = (byte)(value >> 56);
    }

    public static void Write(ulong value, ref int position, ref byte[] b)
    {
        b[position++] = (byte)value;
        b[position++] = (byte)(value >> 8);
        b[position++] = (byte)(value >> 16);
        b[position++] = (byte)(value >> 24);
        b[position++] = (byte)(value >> 32);
        b[position++] = (byte)(value >> 40);
        b[position++] = (byte)(value >> 48);
        b[position++] = (byte)(value >> 56);
    }

    /// <summary>
    /// Write to a precalculated array
    /// </summary>
    /// 
    public static ushort ReadUShort(ref int position, ref byte[] b)
    {
        unsafe
        {
            fixed (byte* pSource = b, pTarget = MNArrays.b2)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < 2; i++)
                {
                    pTarget[i] = pSource[position++];
                }
            }
        }
   
        return (ushort)((MNArrays.b2[1] << 8) | (MNArrays.b2[0] << 0));
    }


}


