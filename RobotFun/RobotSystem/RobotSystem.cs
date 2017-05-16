using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace RobotSystem
{ 
    public static class NetTool
    {
        static public bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";//建立正規化運算式字串
            return Regex.IsMatch(IP,//使用正規化運算式判斷是否匹配
                ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }

        static public bool PingServer(string IP)
        {
            // Ping server to ensure connectable
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 10, retry = 0;
            PingReply reply;
            do
            {
                reply = pingSender.Send(IP, timeout, buffer, options);
                retry++;
                Thread.Sleep(1000);
            } while (retry <= 3);

            return (reply.Status == IPStatus.Success);
        }
    }

    public abstract class RobotPort
    {
        abstract public void Open();
        abstract public void Close();
        abstract public int  Read (byte[] buffer, int offset, int count);
        abstract public void Write(byte[] buffer, int offset, int count);
        abstract public void Write(String command);
        abstract public int BytesToRead();
        abstract public bool IsOpen();
        abstract public void DiscardOutBuffer();
        abstract public void DiscardInBuffer();
        abstract public void Flush();
        abstract public void SetReceivedBytesThreshold(int n);

        public String PortStatus;
        public String PortName;
        public byte[] TxPacket, RxPacket;
        public static int MaxWait = 30;

        Object LockFlag = new Object();

        public RobotPort()  
        { 
        }

        ~RobotPort() 
        { 
        }
    }

    public class RobotSerial : RobotPort
    {
        public SerialPort serialPort;  // 每一個bus佔用一個Port, 不能為static

        public RobotSerial(string PortName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            // Init Serial Port
            // Modbus 只有N-8-2, E-8-1 或 O-8-1 三種格式, 預設用N-8-1
            serialPort = new SerialPort();
            serialPort.PortName = PortName;
            serialPort.BaudRate = baudRate;
            serialPort.DataBits = dataBits;
            serialPort.Parity = parity;
            serialPort.StopBits = stopBits;
            serialPort.DiscardNull = false;
            serialPort.ReadTimeout = 300;
            serialPort.WriteTimeout = 300;
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            MaxWait = 30;
        }            
 
        #region implementation of abstract funcitons

        override public void Open()
        {
            //Ensure Port isn't already opened:
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    PortStatus = serialPort.PortName + " opened successfully";
                }
                catch (Exception err)
                {
                    PortStatus = "Error opening " + serialPort.PortName + ": " + err.Message;
                }
            }
            else
            {
                PortStatus = serialPort.PortName + " already opened";
            }
        }

        override public void Close()
        {
            //Ensure Port is opened before attempting to close:
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    PortStatus = serialPort.PortName + " closed successfully";
                }
                catch (Exception err)
                {
                    PortStatus = "Error closing " + serialPort.PortName + ": " + err.Message;
                }
            }
            else
            {
                PortStatus = serialPort.PortName + " is not already opened";
            }
        }
           
        override public int Read(byte[] buffer, int offset, int count)
        {
            return serialPort.Read(buffer, offset, count);
        }

        override public void Write(byte[] buffer, int offset, int count)
        {
            serialPort.Write(buffer, offset, count);
        }

        override public void Write(String command)
        {
            serialPort.Write(command);
        }

        override public int BytesToRead()
        {
            return serialPort.BytesToRead;
        }

        override public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        override public void DiscardOutBuffer()
        {
            serialPort.DiscardOutBuffer();
        }

        override public void DiscardInBuffer()
        {
            serialPort.DiscardInBuffer();
        }

        override public void Flush()
        {
            //serialPort.Flush();
        }
        
        override public void SetReceivedBytesThreshold(int n)
        {
            serialPort.ReceivedBytesThreshold = n;
        }

        #endregion
    }

    public class RobotWiFi : RobotPort
    {
        TcpClient client;
        String server;
        Int32 port;
        NetworkStream stream;

        public RobotWiFi(String server, Int32 port)
        {
            this.server = server;
            this.port = port;
            MaxWait = 50;
        }

        override public void Open()
        {
            try
            {
                client = new System.Net.Sockets.TcpClient(server, port);
            }
            catch (ArgumentNullException e)
            {
                PortStatus = "ArgumentNullException: {0}" + e;
            }
            catch (SocketException e)
            {
                PortStatus = "SocketException: {0}" + e;
            }
            if (client.Connected)
            {
                stream = client.GetStream();
                PortStatus = "Server is connected";
            }
            else
            {
                PortStatus = "Server is not connected";
            }
        }

        override public void Close()
        {
            try
            {
                stream.Close();
                client.Close();
                PortStatus = "Closed";
            }
            catch (ArgumentNullException e)
            {
                PortStatus = "ArgumentNullException: {0}" + e;
            }
            catch (SocketException e)
            {
                PortStatus = "SocketException: {0}" + e;
            }
        }

        public String Read()
        {

            String responseData = String.Empty;

            try
            {
                Byte[] data = new Byte[1500];
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            catch (ArgumentNullException e)
            {
                PortStatus = "ArgumentNullException: {0}" + e;
            }
            catch (SocketException e)
            {
                PortStatus = "SocketException: {0}" + e;
            }
            return responseData;
        }

        override public int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        override public void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, 0, count);
        }

        override public void Write(String message)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            try
            {
                Write(data, 0, data.Length); // Send the message to the connected TcpServer. 
            }
            catch (ArgumentNullException e)
            {
                PortStatus = "ArgumentNullException: {0}" + e;
            }
            catch (SocketException e)
            {
                PortStatus = "SocketException: {0}" + e;
            }
        }

        override public int BytesToRead()
        {
            return client.Available;
        }

        override public bool IsOpen()
        {
            if (client == null) return false;
            return client.Connected;
        }

        override public void DiscardOutBuffer()
        {
            //
        }

        override public void DiscardInBuffer()
        {
            while (stream.DataAvailable)
            {
                stream.ReadByte();
            }
        }

        override public void Flush()
        {
            stream.Flush();
        }
        
        override public void SetReceivedBytesThreshold(int n)
        {
        }

    }
 }
