using System;
using System.IO;
using System.Diagnostics;
using UnityEngine;

public class MNSerializerTests : MonoBehaviour
{
    public int intValue;
    public float floatValue;
    public int iterations;

    public bool Test;

    public byte[] ByteArray;
    public char[] chars;
 
    // this actually doesnt get called until first use. hmm
    public MNStream stream = new MNStream();

    //public SubclassData testClassData3;
    //public SubclassData testClassData4;

/*    public MNMessageData message1;
    public MNMessageData message2;

    public MNInputsXRData inputsSendXR;
    public MNInputsXRData inputsReceiveXR;

    public MNInputsData inputsSend;
    public MNInputsData inputsReceive;*/

    Stopwatch stopWatch = new Stopwatch();

    MemoryStream ms;
    BinaryWriter writer;
    BinaryReader reader;

    public int int1;
    public int int2;

    public TestCase Mode;

    public enum TestCase
    {
        BinaryWriterReader,
        MNSerializer,
        Span,
        Direct,
        UnsafeDirect,
        Test
    }

    void Start()
    {
        //Application.targetFrameRate = 60;
         ByteArray = new byte[64];
        chars = new char[64];
         stream = new MNStream();
        // Initialize
        //MNArrays.GetArray(0);
        stream.SetBuffer(33);

        ms = new MemoryStream(stream.buffer);
        writer = new BinaryWriter(ms);
        reader = new BinaryReader(ms);

    }

    // slow
    void NewTest()
    {
/*        stream.SetBuffer(testClassData3.ArraySize);
        //stream.SetBuffer(testClassData3.ArraySize, testClassData3.myString.Length);
        testClassData3.Serialize(stream);
        stream.position = 0;
        testClassData4.Deserialize(stream);*/

    }

    void TestMssage()
    {
   /*     int pos = 0;
        inputsSendXR.Write(inputsSendXR, MNArrays.b72, ref pos);
        message1.Bytes = MNArrays.b72;
        pos = 0;
        message1.Write(message1, MNArrays.b81, ref pos);
        pos = 0;
        message2.Read(MNArrays.b81, ref pos);
        pos = 0;
        inputsReceiveXR.Read(message2.Bytes, ref pos);*/
    }
    // faster
    void Direct()
    {
        int cnt = 0;
/*        testClassData3.Write(testClassData3, MNArrays.b33, ref cnt);
        cnt = 0;
        testClassData4.Read(MNArrays.b33, ref cnt);*/
    }

    // fastest
    void UnsafeDirect()
    {
/*        testClassData3.WriteFast(testClassData3, MNArrays.b4);
        testClassData4.ReadFast(MNArrays.b4);*/
    }


    private void Update()
    {
        if (Test || Input.GetKeyDown(KeyCode.Space))
        {

            //Test = false;
            //stopWatch.Start();
            for (int i = 0; i < iterations; i++)
                switch (Mode)
                {
                    case TestCase.BinaryWriterReader:
                        {
                            TestMemoryStream();

                            break;
                        }
                    case TestCase.MNSerializer:
                        {
                            NewTest();
                            //stream.SetBuffer(testClassData3.ArraySize, testClassData3.myString.Length);
                         /*   stream.SetBuffer(testClassData3.ArraySize);
                            testClassData3.Serialize(stream);
                            stream.position = 0;
                            testClassData4.Deserialize(stream);*/
                            break;
                        }
                    case TestCase.Span:
                        {
                             break;
                        }
                    case TestCase.Direct:
                        {
                            Direct();
                            break;
                        }
                    case TestCase.UnsafeDirect:
                        {
                            UnsafeDirect();
                            break;
                        }
                    case TestCase.Test:
                        {
                            TestMssage();
                            break;
                        }
                }
                //NewTest();
            //TestSpan();
            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime =  (ts.Milliseconds).ToString("F9");
            //UnityEngine.Debug.Log("RunTime " + elapsedTime);

        }
    }

 
    void TestMemoryStream()
    {
        ms.Position = 0;
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);
        writer.Write(4);
        writer.Write(5);
        writer.Write(6);
        writer.Write(7);
        writer.Write(8);
        writer.Write(9);
        ms.Position = 0;
        //UnityEngine.Debug.Log(ms.position);
        int1 = reader.ReadInt32();
        int2 = reader.ReadInt32();
        int int3 = reader.ReadInt32();
        int int4 = reader.ReadInt32();
        int int5 = reader.ReadInt32();
        int int6 = reader.ReadInt32();
        int int7 = reader.ReadInt32();
        int int8 = reader.ReadInt32();
        int int9 = reader.ReadInt32();
    }
 


 



}
