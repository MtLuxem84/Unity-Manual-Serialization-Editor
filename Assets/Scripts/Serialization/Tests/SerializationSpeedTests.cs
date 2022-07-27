using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SerializationSpeedTests : MonoBehaviour
{
    public int intValue;
    public float floatValue;
    public int iterations;

    // Only works after class has been serialized 
    public ExampleMessageData ExampleMessage;

    public TestCase Mode;

    Stopwatch stopWatch = new Stopwatch();

    public enum TestCase
    {
        BinaryWriterReader,
        MNSerializer
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //Test = false;
            stopWatch.Start();
            for (int i = 0; i < iterations; i++)
                switch (Mode)
                {
                    case TestCase.BinaryWriterReader:
                        {

                            break;
                        }
                    case TestCase.MNSerializer:
                        {
                            MNSerializer();
                            break;
                        }
        
                }
            //NewTest();
            //TestSpan();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime =  (ts.Milliseconds).ToString();
            UnityEngine.Debug.Log("RunTime ms: " + elapsedTime);
            stopWatch.Reset();
        }
    }

    private void MNSerializer()
    {
        int pos = 0;
        ExampleMessage.Write(ExampleMessage, MNArrays.b9, ref pos);
    }
}
