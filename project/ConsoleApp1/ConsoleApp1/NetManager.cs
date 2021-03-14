using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class NetManager
    {
        private Socket socket;

        private Thread threadWatcher;


        /*
        public void CreateNet()
        {
            // 1. 创建一个 站点管理员
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. 创建一个ip地址认证卡
            IPAddress ipaddress = IPAddress.Parse("192.168.31.31");

            // 3. 创建一个网络节点
            IPEndPoint endpoint = new IPEndPoint(ipaddress, int.Parse("7999"));

            // 4. 分配站点管理员到电脑岛屿的码头的端口上
            socket.Bind(endpoint);
            socket.Listen(20); //将套接字的监听队列长度限制为20


            // 5. 创建一个监听线程 
            threadWatcher = new Thread(WatchConnecting);
            threadWatcher.IsBackground = true; //将窗体线程设置为与后台同步
            threadWatcher.Start(); //启动线程

            // 6. 启动线程后 在控制台输出
            Console.WriteLine($"开始监听客户端传来的信息!");
        }
        */


    }
}