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
    class COM_2
    {
        Serial serial = new Serial(1, "COM");
        Form1 form;
        SerialPort probe_port = new SerialPort();

        public COM_2(Form1 form_1)
        {
            form = form_1;
            probe_port.PortName = File.ReadAllText("C:\\Verifone_related\\serial.txt");
            probe_port.BaudRate = 115200;
        }

        public void Start_Test()
        {
            serial.output = "";
            form.AppendText(form.logs, System.Drawing.Color.Blue, "Starting COM2 Test \n");
            form.testLog += "Starting COM2 Test\n";

            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("COM2"))
                    Check_Results.Set_Progress(i, form.testTable, form);
            }

            probe_port.Open();
            probe_port.WriteLine("test com2");
            Thread.Sleep(500);
            serial.output = probe_port.ReadExisting();


            probe_port.Close();

            //send the command
            //serial.Write_Serial(probe_port.PortName, "test coin");

            //call robot
            //Form1.writeAds("Trigger1", true);


            //read results
            while (!(serial.output.Contains("FAIL") || serial.output.Contains("PASS")))
            {
                Thread.Sleep(200);
                //serial.Read();
                Application.DoEvents();
            }

            //check results
            //Serial.output = "PASS";
            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("COM2"))
                    Check_Results.Check(serial.output, i, form.testTable, form, 1);
            }
        }
    }
}
