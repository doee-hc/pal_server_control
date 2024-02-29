using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace ServerApplication
{

    class Program
    {
        static List<TcpClient> connectedClients = new List<TcpClient>(); // 存储已连接的客户端
        static private PerformanceCounter cpuCounter;
        static private PerformanceCounter ramCounter;

        // 创建 TCP 服务器套接字
        static TcpListener server;

        static void Main(string[] args)
        {
            // 设置服务器 IP 地址和端口号
            string ipAddress = "127.0.0.1";
            int port = 8210;

            server = new TcpListener(IPAddress.Parse(ipAddress), port);

            // 注册退出事件处理程序
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancelKeyPress);

            try
            {
                // 开始监听传入的连接请求
                server.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                // 初始化 CPU 计数器
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue(); // 首次调用 NextValue() 会返回 0，所以我们先调用一次以获取非零值

                // 初始化内存计数器
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                ramCounter.NextValue(); // 同样，首次调用 NextValue() 也会返回 0，需要先调用一次以获取非零值

                // 创建一个定时器，每秒发送一次系统资源信息给客户端
                Timer timer = new Timer(SendSystemInfoToClients, server, TimeSpan.Zero, TimeSpan.FromSeconds(1));



                while (true)
                {
                    // 接受一个客户端连接
                    TcpClient client = server.AcceptTcpClient();

                    // 获取客户端的地址
                    IPAddress clientAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                    int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                    Console.WriteLine($"Client connected: {clientAddress}:{clientPort}");

                    // 添加客户端到已连接列表
                    connectedClients.Add(client);

                    // 创建一个新线程来处理客户端请求
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // 等待退出
            Console.ReadLine();
        }

        // 处理退出事件
        static void OnCancelKeyPress(object sender, EventArgs e)
        {
            foreach (TcpClient client in connectedClients)
            {
                NetworkStream stream = client.GetStream();
                stream?.Close();
            }
            // 停止服务器
            server.Stop();

        }

        // 处理客户端请求，保持连接
        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received message from client: " + message);

                    string response = "Operation: '" + message + "' is doing, Pealse wait...";

                    // 向客户端发送响应
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);

                    // 根据收到的命令执行相应的操作
                    response = HandleCommand(message);

                    // 向客户端发送响应
                    responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // 关闭连接
                IPAddress clientAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                Console.WriteLine($"Client disconnected: {clientAddress}:{clientPort}");
                client.Close();

                // 从已连接列表中移除客户端
                connectedClients.Remove(client);
            }
        }

        // 根据收到的命令执行相应的操作
        static string HandleCommand(string command)
        {
            string response;
            string processNameToCheck = "PalServer-Win64-Test-Cmd";
            // 在这里添加根据收到的命令执行的具体操作
            switch (command)
            {
                case "Open Server":

                    if (IsProcessRunning(processNameToCheck))
                    {
                        response = $"PalServer-Win64-Test-Cmd.exe is already opened.";
                        Console.WriteLine(response);
                    }
                    else
                    {
                        response = ExecuteBatchScript("open_server.bat");
                    }

                    return response;

                case "Update Server":
                    response = ExecuteBatchScript("update_server.bat");
                    return response;

                case "Close Server":
 
                    if (IsProcessRunning(processNameToCheck))
                    {
                        response = ExecuteBatchScript("close_server.bat");
                    }
                    else
                    {
                        response = $"PalServer-Win64-Test-Cmd.exe is already closed.";
                        Console.WriteLine(response);

                    }
                    return response;

                default:
                    return "Unknown command.";
            }
        }
        static bool IsProcessRunning(string processName)
        {
            // 获取所有具有指定进程名称的进程
            Process[] processes = Process.GetProcessesByName(processName);

            // 如果存在具有指定名称的进程，则返回 true
            return processes.Length > 0;
        }

        // 执行批处理脚本
        static string ExecuteBatchScript(string scriptPath)
        {
            string response;
            try
            {
                // 检查批处理脚本是否存在
                if (!File.Exists(scriptPath))
                {
                    response = $"Batch script '{scriptPath}' does not exist.";
                    Console.WriteLine(response);
                    return response;
                }

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/c {scriptPath}";
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // 隐藏命令行窗口
                process.Start();
                process.WaitForExit();
                response = $"Batch script '{scriptPath}' executed successfully.";
                Console.WriteLine(response);
                return response;
            }
            catch (Exception ex)
            {
                response = $"Error executing batch script: {ex.Message}";
                Console.WriteLine(response);
                return response;
            }
        }

        // 发送系统资源信息给客户端
        static void SendSystemInfoToClients(object state)
        {
            TcpListener server = (TcpListener)state;

            // 获取系统的 CPU 和内存占用信息
            float cpuUsage = GetCPUUsage();
            float memoryUsage = GetMemoryUsage();

            string message = $"CPU Usage: {cpuUsage}%\r\nMemory Available: {memoryUsage}MB";

            // 向所有已连接的客户端发送系统资源信息
            foreach (TcpClient client in connectedClients)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        // 获取系统的 CPU 使用率
        static float GetCPUUsage()
        {
            float cpuUsage = cpuCounter.NextValue();

            // 这里可以使用系统性能计数器或其他方法获取 CPU 使用率
            // 此处仅作示例，返回随机值
            return cpuUsage; // 返回0到100之间的随机数
        }

        // 获取系统的内存使用率
        static float GetMemoryUsage()
        {
            float availableMemory = ramCounter.NextValue();
            // 这里可以使用系统性能计数器或其他方法获取内存使用率
            // 此处仅作示例，返回随机值
            return availableMemory; // 返回0到100之间的随机数
        }
    }
}
