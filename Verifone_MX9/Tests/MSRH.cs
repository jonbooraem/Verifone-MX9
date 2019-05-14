﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace Verifone_MX9.Tests
{
    class MSRH
    {
        Serial serial;
        Form1 form;
        SerialPort probe_port;
        int portNum;

        public MSRH(Form1 form_1, int port)
        {
            serial = new Serial(1, "COM" + port.ToString());
            probe_port = new SerialPort();
            form = form_1;
            probe_port.PortName = "COM" + port.ToString();//File.ReadAllText("C:\\Verifone_related\\serial.txt");
            probe_port.BaudRate = 115200;
            portNum = port;
        }

        public void Start_Test()
        {
            form.updatePanelColor((portNum == 1) ? (form.MSRHResult) : (form.MSRHResult2), Color.Yellow);
            serial.output = "";
            form.AppendText(form.logs, System.Drawing.Color.Blue, "Starting Magnetic Strip Reader High Test \n");
            form.testLog += "Starting Magnetic Strip Reader High Test\n";
            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("MSRH"))
                    Check_Results.Set_Progress(i, form.testTable, form);
            }

            //send the command
            serial.Write_Serial(probe_port.PortName, "test msr");

            //call robot
            //Form1.writeAds("Trigger1", true);

            int timeout;
            if (ConfigurationManager.AppSettings.Get("MSRTimeout").Equals("NONE")) timeout = -1;
            else timeout = Int32.Parse(ConfigurationManager.AppSettings.Get("MSRTimeout"));

            //read results
            while (!(serial.output.Contains("FAIL") || serial.output.Contains("PASS")) && !serial.stopped)
            {
                if (form.stopTest)
                {
                    for (int i = 0; i < Form1.tests.Length; i++)
                    {

                        if (Form1.tests[i].Contains("MSRH"))
                        {
                            form.updatePanelColor((portNum == 1) ? (form.MSRHResult) : (form.MSRHResult2), Color.Red);
                            Check_Results.Check("FAIL", i, form.testTable, form, portNum);
                            return;
                        }
                    }
                }
                Thread.Sleep(200);
                serial.Read(form, timeout);
                Application.DoEvents();
            }

            serial.stopped = false;

            //check results
            //Serial.output = "PASS";
            for (int i = 0; i < Form1.tests.Length; i++)
            {

                if (Form1.tests[i].Contains("MSRH"))
                    Check_Results.Check(serial.output, i, form.testTable, form, portNum);
            }
        }

    }
}
