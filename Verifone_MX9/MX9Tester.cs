using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verifone_MX9.Tests;
using System.Threading;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Verifone_MX9
{
    public class MX9Tester
    {
        #region Public Variables       
        public static string[] tests = new string[] { "COM1", "COIN", "IOE", "USB", "MBEE", "ECR", "LAN", "SAM", "Keypad", "Touchscreen", "LED", "Display", "Backlight", "Audio", "MSR", "SmartCard", "Contactless" };
        public Thread testThread;
        public Form1 F1;
        public int COMPort;
        #endregion

        public MX9Tester(Form1 f1, int port)
        {
            F1 = f1;
            COMPort = port;
        }

        public void RunCOM1Test(bool single, bool stop)
        {
            if (single)
            {
                COM_1 com_1 = new COM_1(F1, COMPort);
                com_1.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.COM1Check) : (F1.COM1Check2)) && !stop)
                {
                    COM_1 com_1 = new COM_1(F1, COMPort);
                    com_1.Start_Test();
                }
            }
        }

        public void RunCOINTest(bool single, bool stop)
        {
            if (single)
            {
                COIN coin = new COIN(F1, COMPort);
                coin.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.COINCheck) : (F1.COINCheck2)) && !stop)
                {
                    COIN coin = new COIN(F1, COMPort);
                    coin.Start_Test();
                }
            }
        }

        public void RunIOETest(bool single, bool stop)
        {
            if (single)
            {
                IOE ioe = new IOE(F1, COMPort);
                ioe.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.IOECheck) : (F1.IOECheck2)) && !stop)
                {
                    IOE ioe = new IOE(F1, COMPort);
                    ioe.Start_Test();
                }
            }
        }

        public void RunUSBTest(bool single, bool stop)
        {
            if (single)
            {
                USB usb = new USB(F1, COMPort);
                usb.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.USBCheck) : (F1.USBCheck2)) && !stop)
                {
                    USB usb = new USB(F1, COMPort);
                    usb.Start_Test();
                }
            }
        }

        public void RunMBEETest(bool single, bool stop)
        {
            if (single)
            {
                MBEE mbee = new MBEE(F1, COMPort);
                mbee.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.MBEECheck) : (F1.MBEECheck2)) && !stop)
                {
                    MBEE mbee = new MBEE(F1, COMPort);
                    mbee.Start_Test();
                }
            }
        }

        public void RunECRTest(bool single, bool stop)
        {
            if (single)
            {
                ECR ecr = new ECR(F1, COMPort);
                ecr.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.ECRCheck) : (F1.ECRCheck2)) && !stop)
                {
                    ECR ecr = new ECR(F1, COMPort);
                    ecr.Start_Test();
                }
            }
        }

        public void RunLANTest(bool single, bool stop)
        {
            if (single)
            {
                Ethernet lan = new Ethernet(F1, COMPort);
                lan.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.LANCheck) : (F1.LANCheck2)) && !stop)
                {
                    Ethernet lan = new Ethernet(F1, COMPort);
                    lan.Start_Test();
                }
            }
        }

        public void RunSAMTest(bool single, bool stop)
        {
            if (single)
            {
                SAM sam = new SAM(F1, COMPort);
                sam.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.SAMCheck) : (F1.SAMCheck2)) && !stop)
                {
                    SAM sam = new SAM(F1, COMPort);
                    sam.Start_Test();
                }
            }
        }

        public void RunKeypadTest(bool single, bool stop)
        {
            if (single)
            {
                Keypad keypad = new Keypad(F1, COMPort);
                keypad.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.KeypadCheck) : (F1.KeypadCheck2)) && !stop)
                {
                    Keypad keypad = new Keypad(F1, COMPort);
                    keypad.Start_Test();
                }
            }
        }

        public void RunTouchscreenTest(bool single, bool stop)
        {
            if (single)
            {
                Touchscreen touchscreen = new Touchscreen(F1, COMPort);
                touchscreen.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.TouchscreenCheck) : (F1.TouchscreenCheck2)) && !stop)
                {
                    Touchscreen touchscreen = new Touchscreen(F1, COMPort);
                    touchscreen.Start_Test();
                }
            }
        }

        public void RunLEDTest(bool single, bool stop)
        {
            if (single)
            {
                LED led = new LED(F1, COMPort);
                led.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.LEDCheck) : (F1.LEDCheck2)) && !stop)
                {
                    LED led = new LED(F1, COMPort);
                    led.Start_Test();
                }
            }
        }

        public void RunDisplayTest(bool single, bool stop)
        {
            if (single)
            {
                Display display = new Display(F1, COMPort);
                display.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.DisplayCheck) : (F1.DisplayCheck2)) && !stop)
                {
                    Display display = new Display(F1, COMPort);
                    display.Start_Test();
                }
            }
        }

        public void RunBacklightTest(bool single, bool stop)
        {
            if (single)
            {
                Backlight backlight = new Backlight(F1, COMPort);
                backlight.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.BacklightCheck) : (F1.BacklightCheck2)) && !stop)
                {
                    Backlight backlight = new Backlight(F1, COMPort);
                    backlight.Start_Test();
                }
            }
        }

        public void RunAudioTest(bool single, bool stop)
        {
            if (single)
            {
                Audio audio = new Audio(F1, COMPort);
                audio.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.AudioCheck) : (F1.AudioCheck2)) && !stop)
                {
                    Audio audio = new Audio(F1, COMPort);
                    audio.Start_Test();
                }
            }
        }

        public void RunMSRLTest(bool single, bool stop)
        {
            if (single)
            {
                MSRL msr = new MSRL(F1, COMPort);
                msr.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.MSRLCheck) : (F1.MSRLCheck2)) && !stop)
                {
                    MSRL msr = new MSRL(F1, COMPort);
                    msr.Start_Test();
                }
            }
        }
        public void RunMSRHTest(bool single, bool stop)
        {
            if (single)
            {
                MSRH msr = new MSRH(F1, COMPort);
                msr.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.MSRHCheck) : (F1.MSRHCheck2)) && !stop)
                {
                    MSRH msr = new MSRH(F1, COMPort);
                    msr.Start_Test();
                }
            }
        }

        public void RunSmartCardTest(bool single, bool stop)
        {
            if (single)
            {
                SmartCard smartcard = new SmartCard(F1, COMPort);
                smartcard.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.SmartCardCheck) : (F1.SmartCardCheck2)) && !stop)
                {
                    SmartCard smartcard = new SmartCard(F1, COMPort);
                    smartcard.Start_Test();
                }
            }
        }

        public void RunContactlessTest(bool single, bool stop)
        {
            if (single)
            {
                Contactless contactless = new Contactless(F1, COMPort);
                contactless.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.ContactlessCheck) : (F1.ContactlessCheck2)) && !stop)
                {
                    Contactless contactless = new Contactless(F1, COMPort);
                    contactless.Start_Test();
                }
            }
        }

        public void RunSDTest(bool single, bool stop)
        {
            if (single)
            {
                SD sd = new SD(F1, COMPort);
                sd.Start_Test();
            }
            else
            {
                if (F1.getCheckStatus((COMPort == 1) ? (F1.SDCheck) : (F1.SDCheck2)) && !stop)
                {
                    SD sd = new SD(F1, COMPort);
                    sd.Start_Test();
                }
            }
        }
    }
}
