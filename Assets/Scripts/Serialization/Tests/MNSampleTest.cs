using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MNSampleTest : MonoBehaviour
{
    [System.Serializable]
    public class SubclassData : MNSerializable
    {
        public int ArraySize = 4;
        public ushort myUShort1;
        public ushort myUShort2;
        public SubclassData()
        {
            ArraySize = 4;
        }

        public void Write(SubclassData data, byte[] bytes)
        {
            int pos = 0;
            MNSerializer.Write(data.myUShort1, ref pos, ref bytes);
            MNSerializer.Write(data.myUShort2, ref pos, ref bytes);
        }

        public void Read(byte[] bytes)
        {
            int pos = 0;
            this.myUShort1 = MNSerializer.ReadUShort(ref pos, ref bytes);
            this.myUShort2 = MNSerializer.ReadUShort(ref pos, ref bytes);
        }

        public void ReadFast(byte[] bytes)
        {
            int position = 0;
            unsafe
            {
                fixed (byte* pSource = bytes, pTarget = MNArrays.b2)
                {
                    // Copy the specified number of bytes from source to target.
                    for (int i = 0; i < 2; i++)
                    {
                        pTarget[i] = pSource[position++];
                    }
                }
            }

            this.myUShort1 = (ushort)((MNArrays.b2[1] << 8) | (MNArrays.b2[0] << 0));
            unsafe
            {
                fixed (byte* pSource = bytes, pTarget = MNArrays.b2)
                {
                    // Copy the specified number of bytes from source to target.
                    for (int i = 0; i < 2; i++)
                    {
                        pTarget[i] = pSource[position++];
                    }
                }
            }

            this.myUShort2 = (ushort)((MNArrays.b2[1] << 8) | (MNArrays.b2[0] << 0));
        }
        public void Serialize(MNStream stream)
        {
            stream.Write(myUShort1);
            stream.Write(myUShort2);
        }
        public void Deserialize(MNStream stream)
        {
            myUShort1 = stream.ReadUShort();
            myUShort2 = stream.ReadUShort();
        }
    }
}
