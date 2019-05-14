using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace Verifone_MX9.Tests
{
    class COM_1
    {
        Serial serial;
        Form1 form;
        SerialPort probe_port;
        System.Timers.Timer timeout;
        int portNum;

        public COM_1(Form1 form_1, int port)
        {
            serial = new Serial(1, "COM" + port.ToString());
            probe_port = new SerialPort();
            form = form_1;
            probe_port.PortName = "COM" + port.ToString();//File.ReadAllText("C:\\Verifone_related\\serial.txt");
            probe_port.BaudRate = 115200;
            timeout = new System.Timers.Timer(15000);
            timeout.AutoReset = true;
            timeout.Enabled = false;
            timeout.Elapsed += endTest;
            portNum = port;
        }

        public void endTest(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.tests.Length; i++)
            {
                form.updatePanelColor((portNum == 1) ? (form.COM1Result) : (form.COM1Result2), Color.Red);
                if (Form1.tests[i].Contains("COM1"))
                    Check_Results.Check("FAIL", i, form.testTable, form, portNum);
            }

            
        }

        public void Start_Test()
        {
            form.updatePanelColor((portNum == 1) ? (form.COM1Result) : (form.COM1Result2), Color.Yellow);
            //timeout.Enabled = true;
            form.AppendText(form.logs, System.Drawing.Color.Blue, "Starting COM1 Test \n");
            form.testLog += "Starting COM1 Test\n";
            serial.output = "";

            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("COM1"))
                    Check_Results.Set_Progress(i, form.testTable, form);
            }

            //if (probe_port.IsOpen)
            //{
            //    probe_port.Close();
            //}
            //probe_port.Open();

            int timeout2;
            if (ConfigurationManager.AppSettings.Get("COM1Timeout").Equals("NONE")) timeout2 = -1;
            else timeout2 = Int32.Parse(ConfigurationManager.AppSettings.Get("COM1Timeout"));

            //send the command
            serial.Write_Serial_COM1_Test(probe_port.PortName, "test com1", form, timeout2);
            //probe_port.WriteLine("test com1");
            //probe_port.Close();

            //call robot
            //Form1.writeAds("Trigger1", true);


            //read results
            //while (!(Serial.output.Contains("FAIL") || Serial.output.Contains("PASS")))
            //{
            //    Thread.Sleep(200);
                /*if (form.stopTest)
                {
                    for (int i = 0; i < Form1.tests.Length; i++)
                    {

                        if (Form1.tests[i].Contains("COM1"))
                            Check_Results.Check("FAIL", i, form.test_grid, form);
                    }
                    return;
                }*/
            //    serial.Read();
            //    Application.DoEvents();
            //}

            //check results
            //Serial.output = "FAIL";
            timeout.Enabled = false;
            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("COM1"))
                {
                    Check_Results.Check(serial.output, i, form.testTable, form, portNum);
                }
              
            }
        }
    }
}
