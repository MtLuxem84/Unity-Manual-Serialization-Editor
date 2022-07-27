
/// <summary>
/// Test class
/// </summary>
[MNAttributes]
public class ExampleClass
{
    [MNSerializeClass]
    public class ExampleMessage
    {
        public ushort Id;
        public uint tick_number;
        public byte Type;

        public short ArraySize;
        public byte[] Bytes;
    }


    [MNSerializeClass]
    public class ExampleInput
    {
        public float moveX;
        public float moveY;
        public float qX;
        public float qY;
        public float qZ;
        public float qW;
        public float dt;
        public bool fire;
        public bool jump;
    }

    [MNSerializeClass]
    public class ExampleObjectState
    {
        public uint UID;
        public byte Type;
        public float PosX;
        public float PosY;
        public float PosZ; 
        public float RotX;
        public float RotY;
        public float RotZ;
    }
}


