using System.IO;
using System.Net.Sockets;
using System.Text;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.Logging;
using System.Text.RegularExpressions;

namespace pal_server_control_client_winform
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.txtServerAddressPort = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.buttonOpenServer = new System.Windows.Forms.Button();
            this.buttonUpdateServer = new System.Windows.Forms.Button();
            this.buttonCloseServer = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.bntAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServerAddressPort
            // 
            this.txtServerAddressPort.Location = new System.Drawing.Point(107, 23);
            this.txtServerAddressPort.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtServerAddressPort.Name = "txtServerAddressPort";
            this.txtServerAddressPort.Size = new System.Drawing.Size(161, 23);
            this.txtServerAddressPort.TabIndex = 0;
            this.txtServerAddressPort.Text = "127.0.0.1:8210";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(9, 25);
            this.label_ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(87, 17);
            this.label_ip.TabIndex = 2;
            this.label_ip.Text = "Server IP:Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(284, 22);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(111, 25);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(2, 366);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(86, 17);
            this.lblServerStatus.TabIndex = 5;
            this.lblServerStatus.Text = "Disconnected";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(9, 52);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(387, 155);
            this.txtLog.TabIndex = 6;
            // 
            // buttonOpenServer
            // 
            this.buttonOpenServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenServer.Location = new System.Drawing.Point(407, 25);
            this.buttonOpenServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonOpenServer.Name = "buttonOpenServer";
            this.buttonOpenServer.Size = new System.Drawing.Size(124, 25);
            this.buttonOpenServer.TabIndex = 7;
            this.buttonOpenServer.Text = "Open Server";
            this.buttonOpenServer.UseVisualStyleBackColor = true;
            this.buttonOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // buttonUpdateServer
            // 
            this.buttonUpdateServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateServer.Location = new System.Drawing.Point(407, 54);
            this.buttonUpdateServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonUpdateServer.Name = "buttonUpdateServer";
            this.buttonUpdateServer.Size = new System.Drawing.Size(124, 25);
            this.buttonUpdateServer.TabIndex = 8;
            this.buttonUpdateServer.Text = "Update Server";
            this.buttonUpdateServer.UseVisualStyleBackColor = true;
            this.buttonUpdateServer.Click += new System.EventHandler(this.btnUpdateServer_Click);
            // 
            // buttonCloseServer
            // 
            this.buttonCloseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseServer.Location = new System.Drawing.Point(407, 84);
            this.buttonCloseServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCloseServer.Name = "buttonCloseServer";
            this.buttonCloseServer.Size = new System.Drawing.Size(124, 25);
            this.buttonCloseServer.TabIndex = 9;
            this.buttonCloseServer.Text = "Close Server";
            this.buttonCloseServer.UseVisualStyleBackColor = true;
            this.buttonCloseServer.Click += new System.EventHandler(this.btnCloseServer_Click);
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(9, 212);
            this.chart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(524, 151);
            this.chart.TabIndex = 10;
            this.chart.Text = "chart1";
            // 
            // timerStatusUpdate
            // 
            this.timerStatusUpdate.Interval = 500;
            this.timerStatusUpdate.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // bntAbout
            // 
            this.bntAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntAbout.Location = new System.Drawing.Point(407, 114);
            this.bntAbout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bntAbout.Name = "bntAbout";
            this.bntAbout.Size = new System.Drawing.Size(127, 25);
            this.bntAbout.TabIndex = 11;
            this.bntAbout.Text = "About";
            this.bntAbout.UseVisualStyleBackColor = true;
            this.bntAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 385);
            this.Controls.Add(this.bntAbout);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.buttonCloseServer);
            this.Controls.Add(this.buttonUpdateServer);
            this.Controls.Add(this.buttonOpenServer);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.txtServerAddressPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(559, 424);
            this.Name = "Form_Main";
            this.Text = "Pal Control Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_FormLoading);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private bool connected = false;

        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        private float cpuUsage;
        private float availableMemory;

        private int xAxisCounter = 0;
        private DateTime Heart_tick;

        private void InitializePerformanceCounters()
        {
            //// 初始化 CPU 计数器
            //cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            //cpuCounter.NextValue(); // 首次调用 NextValue() 会返回 0，所以我们先调用一次以获取非零值

            //// 初始化内存计数器
            //ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            //ramCounter.NextValue(); // 同样，首次调用 NextValue() 也会返回 0，需要先调用一次以获取非零值

            // 设置 Chart 控件
            chart.Series.Clear();

            chart.Series.Add("CPU Usage(%)");
            chart.Series.Add("Available Memory(MB)");

            chart.Series["CPU Usage(%)"].ChartType = SeriesChartType.Spline;
            chart.Series["Available Memory(MB)"].ChartType = SeriesChartType.Spline;

            // 添加左右两个坐标轴
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            // 设置 CPU 系列使用左坐标轴，内存系列使用右坐标轴
            chart.Series["CPU Usage(%)"].YAxisType = AxisType.Primary;
            chart.Series["Available Memory(MB)"].YAxisType = AxisType.Secondary;

            // 初始化30个数据点，初始值设置为0
            for (int i = 0; i < 30; i++)
            {
                xAxisCounter++;
                chart.Series["CPU Usage(%)"].Points.AddXY(xAxisCounter, 0);
                chart.Series["Available Memory(MB)"].Points.AddXY(xAxisCounter, 0);
            }


            // 设置坐标线颜色为浅灰色
            //chart.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.LightGray;
            //chart.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.LightGray;
            //chart.ChartAreas[0].AxisY2.LineColor = System.Drawing.Color.LightGray;

            // 设置网格线颜色为浅灰色
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas[0].AxisY2.MinorGrid.LineColor = System.Drawing.Color.LightGray;

            // 隐藏横坐标的标签
            chart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        }



        private void UpdatePerformanceCounters()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdatePerformanceCounters));
                return;
            }
            chart.Series["CPU Usage(%)"].Points.AddXY(xAxisCounter++, cpuUsage);
            chart.Series["Available Memory(MB)"].Points.AddXY(xAxisCounter, availableMemory);

            //chart.Series["CPU Usage(%)"].Points.AddY(cpuUsage);
            //chart.Series["Available Memory(MB)"].Points.AddY(availableMemory);
            // 限制数据点数量，防止图表数据过于拥挤
            while (chart.Series["CPU Usage(%)"].Points.Count > 30)
            {
                chart.Series["CPU Usage(%)"].Points.RemoveAt(0);
            }

            while (chart.Series["Available Memory(MB)"].Points.Count > 30)
            {
                chart.Series["Available Memory(MB)"].Points.RemoveAt(0);
            }

            chart.ResetAutoValues();
            chart.Invalidate();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan heart_time = DateTime.Now - Heart_tick;
           
            if (heart_time.TotalSeconds > 2)
            {
                // 3s未收到heart beat
                Disconnect();
            }

            if (connected == false && lblServerStatus.Text == "Connected")
            {
                Disconnect();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                string[] addressParts = txtServerAddressPort.Text.Split(':');
                if (addressParts.Length != 2)
                {
                    MessageBox.Show("Invalid IP:Port format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string serverAddress = addressParts[0];
                int port;
                if (!int.TryParse(addressParts[1], out port))
                {
                    MessageBox.Show("Invalid port number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    btnConnect.Text = "Connecting...";
                    btnConnect.BackColor = System.Drawing.Color.Gray;
                    btnConnect.Enabled = false;

                    client = new TcpClient(serverAddress, port);
                    stream = client.GetStream();
                    connected = true;
                    SetServerStatus("Connected");
                    btnConnect.Text = "Disconnect";
                    btnConnect.BackColor = System.Drawing.Color.Green;
                    btnConnect.Enabled = true;

                    receiveThread = new Thread(Receive);
                    receiveThread.Start();
                    timerStatusUpdate.Enabled = true;

                    Heart_tick = DateTime.Now;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connecting to server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnConnect.Text = "Connect";
                    btnConnect.BackColor = System.Drawing.Color.Empty;
                    btnConnect.Enabled = true;
                }
            }
            else
            {
                Disconnect();
            }
        }
        private void Disconnect()
        {
            timerStatusUpdate.Enabled = false;
            connected = false;
            stream?.Close();
            client?.Close();
            receiveThread?.Join();

            SetServerStatus("Disconnected");
            btnConnect.Text = "Connect";
            btnConnect.BackColor = System.Drawing.Color.Empty;
            btnConnect.Enabled = true;
        }

        private void Receive()
        {
            byte[] buffer = new byte[1024];
            while (connected)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead != 0 && connected)    // 再次判断connected避免死锁
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        

                        // 使用正则表达式提取 CPU 使用率和内存信息
                        string cpuUsagePattern = @"CPU Usage: ([0-9.]+)%";
                        string memoryAvailablePattern = @"Memory Available: ([0-9]+)MB";

                        // 提取 CPU 使用率
                        Match cpuMatch = Regex.Match(message, cpuUsagePattern);

                        // 提取内存可用信息
                        Match memoryMatch = Regex.Match(message, memoryAvailablePattern);

                        if (cpuMatch.Success)
                        {
                            string cpuUsageString = cpuMatch.Groups[1].Value;
                            float.TryParse(cpuUsageString, out cpuUsage);
                        }
                        else
                        {
                            Console.WriteLine("CPU Usage not found in message.");
                        }

                        if (memoryMatch.Success)
                        {
                            string memoryAvailableString = memoryMatch.Groups[1].Value;
                            float.TryParse(memoryAvailableString, out availableMemory);
                        }
                        else
                        {
                            Console.WriteLine("Memory Available not found in message.");
                        }

                        if(cpuMatch.Success || memoryMatch.Success)
                        {
                            Heart_tick = DateTime.Now;
                            // 委托UI线程更新chart
                            UpdatePerformanceCounters();
                        }
                        else
                        {
                            AddLog(message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error receiving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (connected == true)      // 防止死锁
                    {
                        connected = false;
                    }
                    break;
                }
            }
        }

        private void SendMessage(string message)
        {
            if (connected)
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not connected to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetServerStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetServerStatus), status);
                return;
            }
            lblServerStatus.Text = status;
        }



        private void AddLog(string log)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), log);
                return;
            }
            txtLog.AppendText(log + Environment.NewLine);
        }
        private void MainForm_FormLoading(object sender, EventArgs e)
        {
            txtServerAddressPort.Text = Properties.Settings.Default.address;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.address = txtServerAddressPort.Text;
            Properties.Settings.Default.Save();
            connected = false;
            client?.Close();
            stream?.Close();
            receiveThread?.Join();
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            // 显示提示框
            MessageBox.Show("A simple remote controller for windows game server(Pal world).\r\nVersion：0.1\r\nAuthor：doee\r\nGithub:  https://github.com/doee-hc", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            SendMessage("Open Server");
        }

        private void btnUpdateServer_Click(object sender, EventArgs e)
        {
            SendMessage("Update Server");
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            SendMessage("Close Server");
        }

        private TextBox txtServerAddressPort;
        private Label label_ip;
        private Button btnConnect;
        private Label lblServerStatus;
        private TextBox txtLog;
        private Button buttonOpenServer;
        private Button buttonUpdateServer;
        private Button buttonCloseServer;
        private Chart chart;
        private System.Windows.Forms.Timer timerStatusUpdate;
        private Button bntAbout;
    }
}


