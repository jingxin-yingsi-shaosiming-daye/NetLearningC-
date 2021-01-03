using System;
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

    byte[] readBuff = new byte[1024];

    public Text text;

    public string resultString;

    public InputField inputFeld;




    #region 01 连接

    

    
    
    /// <summary>
    /// 点击按钮触发事件
    /// </summary>
    public void Connection()
    {
        //Socket
        socket = new Socket(
            AddressFamily.InterNetwork
            , SocketType.Stream
            , ProtocolType.Tcp);
        
        
        //Connect
        socket.BeginConnect("127.0.0.1", 8888, OnConnected, socket);
//        socket.Connect("127.0.0.1",8888);
    }

    
    
    

    private void OnConnected(IAsyncResult asyncResult)
    {
        try
        {
            Socket connectScoket = asyncResult.AsyncState as Socket;
            connectScoket.EndConnect(asyncResult);
            text.text = "连接成功";
            Debug.Log("连接到服务器");
            Debug.Log("开始接受数据");
            connectScoket.BeginReceive(readBuff, 0, 1024
                , 0, OnReceived, connectScoket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion


    #region 03 接收
    

    public void OnReceived(IAsyncResult asyncResult)
    {
        try
        {
            Socket receiveSocket = asyncResult.AsyncState as Socket;
            int count = receiveSocket.EndReceive(asyncResult);
            
            
            resultString = System.Text.Encoding.Default.GetString(readBuff,0,count);
            
            Debug.Log("接收到数据: "+ resultString);
            receiveSocket.BeginReceive(readBuff,0,1024
            ,0,OnReceived,receiveSocket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
    
    #endregion
    
    
    


    #region 02 发送

    


    

    /// <summary>
    /// 点击发送按钮
    /// </summary>
    public void Send()
    {
        //Send
        string sendStr = inputFeld.text;

        byte[] bytes = System.Text.Encoding.Default.GetBytes(sendStr);
        
        Debug.Log("开始发送数据: "+ sendStr);
        socket.BeginSend(bytes, 0,bytes.Length,0, OnSended, socket);
        
        //socket.Send(bytes);//阻塞方法  等收到接收消息后执行下一行
        
       
    }


    public void OnSended(IAsyncResult asyncResult)
    {
        try
        {
             Socket sendedSocket = asyncResult.AsyncState as Socket;
             int count = sendedSocket.EndSend(asyncResult);
             Debug.Log($"发送完成  发送数量 : {count} ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    #endregion

    public void Update()
    {
        text.text = resultString;
    }
}
