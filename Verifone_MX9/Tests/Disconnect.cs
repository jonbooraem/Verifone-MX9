using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;

namespace Verifone_MX9.Tests
{
    class Disconnect
    {
        Serial serial = new Serial(1, "");
        Form1 form;
        SerialPort probe_port = new SerialPort();

        public Disconnect(Form1 form_1)
        {
            form = form_1;
            probe_port.PortName = File.ReadAllText("C:\\Verifone_related\\serial.txt");
            probe_port.BaudRate = 115200;
            probe_port.Close();
        }

        public void Start_Test()
        {
        }

    }
}
