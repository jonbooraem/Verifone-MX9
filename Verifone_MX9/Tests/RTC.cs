using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verifone_MX9.Tests
{
    class RTC
    {
        Serial serial = new Serial(1, "");
        Form1 form;
        SerialPort probe_port = new SerialPort();

        public RTC(Form1 form_1)
        {
            form = form_1;
            probe_port.PortName = "COM1";// File.ReadAllText("C:\\Verifone_related\\serial.txt");
            probe_port.BaudRate = 115200;
        }

        public void Start_Test()
        {
            form.AppendText(form.logs, System.Drawing.Color.Blue, "Starting RTC Test \n");
            form.testLog += "Starting RTC Test\n";
            serial.output = "";

            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("RTC"))
                    Check_Results.Set_Progress(i, form.testTable, form);
            }

            if (probe_port.IsOpen)
            {
                probe_port.Close();
            }
            probe_port.Open();
            probe_port.WriteLine("test rtc");
            Thread.Sleep(500);
            serial.output = probe_port.ReadExisting();


            probe_port.Close();

            //send the command
            //serial.Write_Serial(probe_port.PortName, "test coin");

            //call robot
            //Form1.writeAds("Trigger1", true);


            //read results
            //while (!(Serial.output.Contains("FAIL") || Serial.output.Contains("PASS")))
            //{
            //    Thread.Sleep(500);
            //    serial.Read();
            //    Application.DoEvents();
            //}

            //check results
            //Serial.output = "PASS";
            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("RTC"))
                    Check_Results.Check(serial.output, i, form.testTable, form, 1);
            }
        }
    }
}
