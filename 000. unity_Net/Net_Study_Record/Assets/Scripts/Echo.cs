using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Echo : MonoBehaviour
{
    /// <summary>
    /// 套接字
    /// </summary>
    private Socket socket;


    public Text text;

    public InputField inputFeld;

    /// <summary>
    /// 连接按钮触发事件
    /// </summary>
    public void Connection()
    {
        //Socket
        socket = new Socket(
            AddressFamily.InterNetwork
            , SocketType.Stream
            , ProtocolType.Tcp);
        
        
        //Connect
        socket.Connect("127.0.0.1",8888);
    }

    /// <summary>
    /// 点击发送按钮
    /// </summary>
    public void Send()
    {
        //Send
        string sendStr = inputFeld.text;

        byte[] bytes = System.Text.Encoding.Default.GetBytes(sendStr);

        socket.Send(bytes);//阻塞方法  等收到接收消息后执行下一行
        
        //Recv
        byte[] readBuff = new byte[1024];

        int count = socket.Receive(readBuff);//阻塞发方法
        
        string s = System.Text.Encoding.Default.GetString(readBuff,0,count);

        text.text = s;
        
        //Close
        socket.Close();
    }
    
}
