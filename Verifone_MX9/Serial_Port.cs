using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
//using TFTPClient;
using System.IO.Ports;
using System.Windows.Forms;

namespace Verifone_MX9
{
    public class Serial
    {

        public SerialPort _serialPort;
        static bool _continue = true;
        public string output;
        static int unit_ID;
        static int readtimeout = 120000;
        public string Port;

        public Serial(int unit_id, string port)
        {
            Port = port;

            _serialPort = new SerialPort();

            unit_ID = unit_id;

            _serialPort.PortName = port;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            output = "";
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();

            _serialPort.Close();
        }

        public void Write_Serial(string com_port, string command)
        {
            _serialPort.Open();

            //send command
            _serialPort.WriteLine(command);
            //

            _serialPort.Close();
        }

        public void refreshPort(string port)
        {
            _serialPort.Dispose();

            _serialPort = new SerialPort();

            _serialPort.PortName = port;
            _serialPort.BaudRate = 115200;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            output = "";
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();

            _serialPort.Close();
        }

        public bool timerEnded, stopped;

        public void timerEnd(object o, System.Timers.ElapsedEventArgs e)
        {
            timerEnded = true;
        }

        public bool Write_Serial_COM1_Test(string com_port, string command, Form1 form, int timeout)
        {
            bool result = false;
            stopped = false;
            timerEnded = false;
            System.Timers.Timer t = new System.Timers.Timer(1);
            if (timeout != -1)
            {
                t = new System.Timers.Timer(timeout * 1000);
                t.Elapsed += timerEnd;
            }

            if (_serialPort.IsOpen) _serialPort.Close();
            _serialPort.Open();
            _serialPort.DiscardOutBuffer();
            _serialPort.DiscardInBuffer();
            //send command

            Thread.Sleep(5000);

            

            _serialPort.WriteLine(command);
            //

            Thread.Sleep(3000);
            if (timeout != -1) t.Start();
            while (_continue)
            {
                if (form.stopTest) { result = false; break; }   
                string new_line = "";

                try
                {
                    new_line = _serialPort.ReadExisting();
                    output = output + new_line;
                }
                catch (TimeoutException e) { }

                //SendToLog(new_line);
                try
                {
                    output = output.Substring(output.IndexOf("test"));
                }
                catch
                {
                    output = "";
                }
                if ((output.Contains("FAIL")) || (output.Contains("PASS")))
                {
                    if (output.Contains("PASS"))
                        result = true;
                    break;
                }

                if (timerEnded) break;

                Application.DoEvents();
                Thread.Sleep(1000);
            }
            _serialPort.Close();
            return result;
        }

        public void Read(Form1 form, int timeout)
        {
            refreshPort(Port);

            _serialPort.Open();

            stopped = false;
            timerEnded = false;
            System.Timers.Timer t = new System.Timers.Timer(1);
            if (timeout != -1)
            {
                t = new System.Timers.Timer(timeout * 1000);
                t.Elapsed += timerEnd;
                t.Enabled = true;
                t.Start();
            }
            if (_serialPort.IsOpen) _serialPort.Close();
            _serialPort.Open();
            while (_continue)
            {
                string new_line = "";

                try
                {
                    new_line = _serialPort.ReadLine();
                    output = output + new_line;
                }
                catch (TimeoutException e) { }

                //SendToLog(new_line);

                if ((output.Contains("FAIL") || output.Contains("PASS")))
                {
                    break;
                }

                Application.DoEvents();

                if (form.stopTest || timerEnded) { stopped = true; break; }
            }
            _serialPort.Close();
        }
    }

}
