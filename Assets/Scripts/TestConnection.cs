using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TestConnection : MonoBehaviour
{

    SerialPort data_stream = new SerialPort("COM3", 9600);
    public string receivedstring;
    public GameObject test_data;
    public Rigidbody rb;
    public float sensitivity = 0.1f;

    public string[] datas;
    // Start is called before the first frame update
    void Start()
    {
        try { 
            data_stream.Open(); //Initiate the Serial stream
        }
        catch
        {
            Debug.Log("No Port Connected!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            receivedstring = data_stream.ReadLine();
            //Debug.Log(receivedstring);
        }
        catch
        {
           // Debug.Log("No really not");
        }
            if (receivedstring != "")
        {
            float forceX;
            float.TryParse(receivedstring, out float ardData);
            //Debug.Log(forceX);
            forceX = (ardData - 620);
            rb.AddForce((forceX - 625) * -sensitivity * Time.deltaTime, 0, 0, ForceMode.Force);
        }
    }
}


