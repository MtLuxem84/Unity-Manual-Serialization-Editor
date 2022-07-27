using System;
using System.Text;
using System.Runtime.InteropServices;

//method.
public interface MNSerializable
{
    public void Serialize(MNStream stream);
    public void Deserialize(MNStream stream);
}

public interface MNReference
{
    public void Serialize(byte [] bytes);
    public void Deserialize(byte[] bytes);
}

[System.Serializable]
public class MNStream
{

    public byte[] buffer;
    public int position;
    public int Length;

    //private List<Object> ObjectList = new List<object>();

    public enum TextEncoding
    {
        UTF8
    }

    public MNStream()
    {

    }

    /// <summary>
    /// Create new buffer. Maybe have two buffers? one precalculated and one for dynamic arrays.
    /// </summary>
    /// 
    public MNStream(int size)
    {
        buffer = new byte[size];
        position = 0;
    }

    /// <summary>
    /// Setbuffer with precalculated array. No strings
    /// </summary>
    /// 
    public void SetBuffer(int size)
    {
        position = 0;
        buffer = MNArrays.GetArray(size);
    }

    /// <summary>
    /// Setbuffer with precalculated array and fixed array string
    /// </summary>
    /// 
    public void SetBuffer(int size, int stringSize)
    {
        position = 0;
        buffer = MNArrays.GetArray(size + stringSize);
    }

    public MNStream(byte[] bytes)
    {
        buffer = bytes;
        position = 0;
    }
     
    public void Write(byte value)
    {
        buffer[position++] = value;
    }

    public void Write(sbyte value)
    {
        buffer[position++] = (byte)value;
    }

    public void Write(bool value)
    {
        buffer[position++] = (byte)(value ? 1 : 0);
    }

    public void Write(int value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
        buffer[position++] = (byte)(value >> 16);
        buffer[position++] = (byte)(value >> 24);
    }

    public void Write(uint value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
        buffer[position++] = (byte)(value >> 16);
        buffer[position++] = (byte)(value >> 24);
    }

 
    [System.Security.SecuritySafeCritical]   
    public unsafe virtual void Write(float value)
    {
        uint TmpValue = *(uint*)&value;
        buffer[position++] = (byte)TmpValue;
        buffer[position++] = (byte)(TmpValue >> 8);
        buffer[position++] = (byte)(TmpValue >> 16);
        buffer[position++] = (byte)(TmpValue >> 24);
    }


    [System.Security.SecuritySafeCritical]  // auto-generated
    public unsafe virtual void Write(double value)
    {
        ulong TmpValue = *(ulong*)&value;
        buffer[position++] = (byte)TmpValue;
        buffer[position++] = (byte)(TmpValue >> 8);
        buffer[position++] = (byte)(TmpValue >> 16);
        buffer[position++] = (byte)(TmpValue >> 24);
        buffer[position++] = (byte)(TmpValue >> 32);
        buffer[position++] = (byte)(TmpValue >> 40);
        buffer[position++] = (byte)(TmpValue >> 48);
        buffer[position++] = (byte)(TmpValue >> 56);
    }

    public void Write(long value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
        buffer[position++] = (byte)(value >> 16);
        buffer[position++] = (byte)(value >> 24);
        buffer[position++] = (byte)(value >> 32);
        buffer[position++] = (byte)(value >> 40);
        buffer[position++] = (byte)(value >> 48);
        buffer[position++] = (byte)(value >> 56);
    }

    public void Write(ulong value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
        buffer[position++] = (byte)(value >> 16);
        buffer[position++] = (byte)(value >> 24);
        buffer[position++] = (byte)(value >> 32);
        buffer[position++] = (byte)(value >> 40);
        buffer[position++] = (byte)(value >> 48);
        buffer[position++] = (byte)(value >> 56);
    }

    public void Write(short value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
    }

    public void Write(ushort value)
    {
        buffer[position++] = (byte)value;
        buffer[position++] = (byte)(value >> 8);
    }

    /// <summary>
    /// Write to a precalculated array
    /// </summary>
    public void Write(string value)
    {
        byte length = (byte)value.Length;
        Write(length);
        if (length > 0)
        {
            byte[] b = MNArrays.GetArray(length);
            Encoding.UTF8.GetBytes(value, 0, value.Length, b, 0);
            //UnityEngine.Debug.Log(position);
            for (int i = 0; i < b.Length; i++)
            {
                buffer[position++] = b[i];
            }
        }
    }

    public byte ReadByte()
    {
        return buffer[position++];
    }

    public bool ReadBool()
    {
        position++;
        if (buffer[position] == 0)
            return false;
        else return true;
    }

    public short ReadShort()
    {
        unsafe
        {
            fixed (byte* pSource = buffer, pTarget = MNArrays.b2)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < 2; i++)
                {
                    pTarget[i] = pSource[position++];
                }
            }
        }
        return (short)((MNArrays.b2[1] << 8) | (MNArrays.b2[0] << 0));
    }

    public ushort ReadUShort()
    {
        unsafe
        {
            fixed (byte* pSource = buffer, pTarget = MNArrays.b2)
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

    public int ReadInt()
    {
        unsafe
        {
            fixed (byte* pSource = buffer, pTarget = MNArrays.b4)
            {
                for (int i = 0; i < 4; i++)
                {
                    pTarget[i] = pSource[position++];
                }
            }
        }
        return MNArrays.b4[0] | (MNArrays.b4[1] << 8) | (MNArrays.b4[2] << 16) | (MNArrays.b4[3] << 24);
    }

    public uint ReadUInt()
    {
        unsafe
        {
            fixed (byte* pSource = buffer, pTarget = MNArrays.b4)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < 4; i++)
                {
                    pTarget[i] = pSource[position++];
                }
            }
        }
        return (uint)(MNArrays.b4[0] | (MNArrays.b4[1] << 8) | (MNArrays.b4[2] << 16) | (MNArrays.b4[3] << 24));
    }

    public long ReadLong()
    {
        MNArrays.b8[0] = buffer[position++];
        MNArrays.b8[1] = buffer[position++];
        MNArrays.b8[2] = buffer[position++];
        MNArrays.b8[3] = buffer[position++];
        MNArrays.b8[4] = buffer[position++];
        MNArrays.b8[5] = buffer[position++];
        MNArrays.b8[6] = buffer[position++];
        MNArrays.b8[7] = buffer[position++];

        uint lo = (uint)(MNArrays.b8[0] | MNArrays.b8[1] << 8 |
                     MNArrays.b8[2] << 16 | MNArrays.b8[3] << 24);
        uint hi = (uint)(MNArrays.b8[4] | MNArrays.b8[5] << 8 |
                         MNArrays.b8[6] << 16 | MNArrays.b8[7] << 24);
        return (long)((ulong)hi) << 32 | lo;
    }

    public ulong ReadUlong()
    {
        MNArrays.b8[0] = buffer[position++];
        MNArrays.b8[1] = buffer[position++];
        MNArrays.b8[2] = buffer[position++];
        MNArrays.b8[3] = buffer[position++];
        MNArrays.b8[4] = buffer[position++];
        MNArrays.b8[5] = buffer[position++];
        MNArrays.b8[6] = buffer[position++];
        MNArrays.b8[7] = buffer[position++];

        uint lo = (uint)(MNArrays.b8[0] | MNArrays.b8[1] << 8 |
                     MNArrays.b8[2] << 16 | MNArrays.b8[3] << 24);
        uint hi = (uint)(MNArrays.b8[4] | MNArrays.b8[5] << 8 |
                         MNArrays.b8[6] << 16 | MNArrays.b8[7] << 24);
        return ((ulong)hi) << 32 | lo;
    }

    [System.Security.SecuritySafeCritical]  // auto-generated
    public virtual unsafe double ReadDouble()
    {
        unsafe
        {
            fixed (byte* pSource = buffer, pTarget = MNArrays.b8)
            {
                // Copy the specified number of bytes from source to target.
                for (int i = 0; i < 8; i++)
                {
                    pTarget[i] = pSource[position++];
                }
            }
        }

        uint lo = (uint)(MNArrays.b8[0] | MNArrays.b8[1] << 8 |
            MNArrays.b8[2] << 16 | MNArrays.b8[3] << 24);
        uint hi = (uint)(MNArrays.b8[4] | MNArrays.b8[5] << 8 |
            MNArrays.b8[6] << 16 | MNArrays.b8[7] << 24);

        ulong tmpBuffer = ((ulong)hi) << 32 | lo;
        return *((double*)&tmpBuffer);
    }

    [System.Security.SecuritySafeCritical]  
    public virtual unsafe float ReadFloat()
    {
        MNArrays.b4[0] = buffer[position++];
        MNArrays.b4[1] = buffer[position++];
        MNArrays.b4[2] = buffer[position++];
        MNArrays.b4[3] = buffer[position++];
        uint tmpBuffer = (uint)(MNArrays.b4[0] | MNArrays.b4[1] << 8 | MNArrays.b4[2] << 16 | MNArrays.b4[3] << 24);
        return *(float*)&tmpBuffer;
    }

    public string ReadString()
    {
        byte length = buffer[position++];
        if (length > 0)
        {
            byte[] b = MNArrays.GetArray(length);
            for (int i = 0; i < length; i++)
            {
                b[i] = buffer[position++];
            }            
            return Encoding.UTF8.GetString(b);

        }

        return string.Empty;
    }

 
}

// types 0 byte 1 sbyte 2 bool 3 short 4 ushort 5 int 6 uint 7 long 8 ulong 9 float 10 double 