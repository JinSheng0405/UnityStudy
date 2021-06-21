using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
public class ShareScale : MonoBehaviour
{
    private Transform Parking;
    private float scalex;
    private float scaley;
    private float scalez;
    private string ip = string.Empty;
    private int port = 0;
    private Socket _socket = null;
    private byte[] buffer = new byte[12];
    private float[] data = new float[3];
    private bool isHost=false;
    private bool isHeared = false;
    private Vector3 newScale;
    // Start is called before the first frame update
    public void StartShareScale()
    {
        if (_socket == null)
        {
            Parking = GameObject.Find("Parking(Clone)").GetComponent<Transform>();
            scalex = Parking.localScale.x;
            scaley = Parking.localScale.y;
            scalez = Parking.localScale.z;
            newScale = Parking.localScale;
            ip = "192.168.0.9";
            port = 8889;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2.0 创建IP对象
            IPAddress address = IPAddress.Parse(ip);
            //3.0 创建网络端口包括ip和端口
            IPEndPoint endPoint = new IPEndPoint(address, port);
            //4.0 建立连接

            _socket.Connect(endPoint);
            Debug.Log("连接服务器成功");
            int length = _socket.Receive(buffer);
            data = BytesToFloats(buffer);
            if (data[0] == 0)
            {
                isHost = true;
            }
            else
            {
                isHost = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_socket != null) {
            if (isHost == true)
            {
                if (scalex != Parking.localScale.x || scaley != Parking.localScale.y || scalez != Parking.localScale.z)
                {
                    data[0] = Parking.localScale.x;
                    data[1] = Parking.localScale.y;
                    data[2] = Parking.localScale.z;
                    buffer = FloatsToBytes(data);
                    _socket.Send(buffer);
                    Debug.Log("像服务发送的消息");
                    scalex = Parking.localScale.x;
                    scaley = Parking.localScale.y;
                    scalez = Parking.localScale.z;
                }

            }
            else
            {
                if (isHeared == false)
                {
                    Thread thread1 = new Thread(new ThreadStart(ForHear));
                    thread1.Start();
                    isHeared = true;
                }
                if (newScale!= Parking.localScale)
                {
                    Parking.localScale = newScale;
                }
                

            }
        }


    }

    void ForHear()
    {
        while (true)
        {
            int length = _socket.Receive(buffer);
            data = BytesToFloats(buffer);
            if (data[0] == 0)
            {
                isHost = true;
                isHeared = false;
                break;
            }
            else
            {
                newScale = new Vector3(data[0], data[1], data[2]);
            }
        }

    }
    float[] BytesToFloats(byte[] Bytes)
    {
        float[] floats = new float[Bytes.Length / 4];
        for (int i = 0; i < floats.Length; i++)
        {
            floats[i] = BitConverter.ToSingle(Bytes, i * 4);
        }
        return floats;
    }
    byte[] FloatsToBytes(float[] floats)
    {
        byte[] bytes = new byte[floats.Length * 4];
        for (int i = 0; i < floats.Length; i++)
        {
            for(int j=0;j<4;j++)
                bytes[i*4+j] = BitConverter.GetBytes(floats[i])[j];
        }
        return bytes;
    }
}
