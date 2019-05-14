using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verifone_MX9.Properties;

namespace Verifone_MX9
{
   
    class Check_Results
    {
        
        
        public Check_Results()
        {
        }

        public static void Check(string output, int test_index, TableLayoutPanel table, Form1 form, int port)
        {
            Form1 f = form;
            
            if (output.Contains("PASS"))
            {
                form.testResults[test_index] = true;
                form.AppendText(form.logs, System.Drawing.Color.Green, Form1.tests[test_index] + " test passed at time = " + form.timerLabel.Text + "\n");
                form.testLog += Form1.tests[test_index] + " Test Passed at time = " + form.timerLabel.Text + "\n";
                PictureBox pictureBox_ = new System.Windows.Forms.PictureBox();
                pictureBox_.Name = "pass";
                pictureBox_.SizeMode = PictureBoxSizeMode.StretchImage;
                //Bitmap image = new Bitmap(Resources.Pass);
                pictureBox_.Dock = DockStyle.Fill;
                //pictureBox_.Image = (Image)image;

                switch (test_index)
                {
                    case (0): form.updatePanelColor((port == 1) ? (form.COM1Result) : (form.COM1Result2), Color.Green); break;
                    case (1): form.updatePanelColor((port == 1) ? (form.COINResult) : (form.COINResult2), Color.Green); break;
                    case (2): form.updatePanelColor((port == 1) ? (form.IOEResult) : (form.IOEResult2), Color.Green); break;
                    case (3): form.updatePanelColor((port == 1) ? (form.USBResult) : (form.USBResult2), Color.Green); break;
                    case (4): form.updatePanelColor((port == 1) ? (form.MBEEResult) : (form.MBEEResult2), Color.Green); break;
                    case (5): form.updatePanelColor((port == 1) ? (form.ECRResult) : (form.ECRResult2), Color.Green); break;
                    case (6): form.updatePanelColor((port == 1) ? (form.LANResult) : (form.LANResult2), Color.Green); break;
                    case (7): form.updatePanelColor((port == 1) ? (form.SAMResult) : (form.SAMResult2), Color.Green); break;
                    case (8): form.updatePanelColor((port == 1) ? (form.KeypadResult) : (form.KeypadResult2), Color.Green); break;
                    case (9): form.updatePanelColor((port == 1) ? (form.TouchscreenResult) : (form.TouchscreenResult2), Color.Green); break;
                    case (10): form.updatePanelColor((port == 1) ? (form.LEDResult) : (form.LEDResult2), Color.Green); break;
                    case (11): form.updatePanelColor((port == 1) ? (form.DisplayResult) : (form.DisplayResult2), Color.Green); break;
                    case (12): form.updatePanelColor((port == 1) ? (form.BacklightResult) : (form.BacklightResult2), Color.Green); break;
                    case (13): form.updatePanelColor((port == 1) ? (form.AudioResult) : (form.AudioResult2), Color.Green); break;
                    case (14): form.updatePanelColor((port == 1) ? (form.MSRLResult) : (form.MSRLResult2), Color.Green); break;
                    case (15): form.updatePanelColor((port == 1) ? (form.MSRHResult) : (form.MSRHResult2), Color.Green); break;
                    case (16): form.updatePanelColor((port == 1) ? (form.SmartCardResult) : (form.SmartCardResult2), Color.Green); break;
                    case (17): form.updatePanelColor((port == 1) ? (form.ContactlessResult) : (form.ContactlessResult2), Color.Green); break;
                }
                
            }
            else
            {
                form.testResults[test_index] = false;
                f.is_all_pass = false;
                form.AppendText(form.logs, System.Drawing.Color.Red, Form1.tests[test_index] + " Test Failed at time = " + form.timerLabel.Text + "\n");
                form.testLog += Form1.tests[test_index] + " Test Failedat time = " + form.timerLabel.Text + "\n";
                PictureBox pictureBox_ = new System.Windows.Forms.PictureBox();
                pictureBox_.Name = "fail";
                pictureBox_.SizeMode = PictureBoxSizeMode.StretchImage;
                //Bitmap image = new Bitmap(Resources.Fail);
                pictureBox_.Dock = DockStyle.Fill;
                //pictureBox_.Image = (Image)image;

                switch (test_index)
                {
                    case (0): form.updatePanelColor((port == 1) ? (form.COM1Result) : (form.COM1Result2), Color.Red); break;
                    case (1): form.updatePanelColor((port == 1) ? (form.COINResult) : (form.COINResult2), Color.Red); break;
                    case (2): form.updatePanelColor((port == 1) ? (form.IOEResult) : (form.IOEResult2), Color.Red); break;
                    case (3): form.updatePanelColor((port == 1) ? (form.USBResult) : (form.USBResult2), Color.Red); break;
                    case (4): form.updatePanelColor((port == 1) ? (form.MBEEResult) : (form.MBEEResult2), Color.Red); break;
                    case (5): form.updatePanelColor((port == 1) ? (form.ECRResult) : (form.ECRResult2), Color.Red); break;
                    case (6): form.updatePanelColor((port == 1) ? (form.LANResult) : (form.LANResult2), Color.Red); break;
                    case (7): form.updatePanelColor((port == 1) ? (form.SAMResult) : (form.SAMResult2), Color.Red); break;
                    case (8): form.updatePanelColor((port == 1) ? (form.KeypadResult) : (form.KeypadResult2), Color.Red); break;
                    case (9): form.updatePanelColor((port == 1) ? (form.TouchscreenResult) : (form.TouchscreenResult2), Color.Red); break;
                    case (10): form.updatePanelColor((port == 1) ? (form.LEDResult) : (form.LEDResult2), Color.Red); break;
                    case (11): form.updatePanelColor((port == 1) ? (form.DisplayResult) : (form.DisplayResult2), Color.Red); break;
                    case (12): form.updatePanelColor((port == 1) ? (form.BacklightResult) : (form.BacklightResult2), Color.Red); break;
                    case (13): form.updatePanelColor((port == 1) ? (form.AudioResult) : (form.AudioResult2), Color.Red); break;
                    case (14): form.updatePanelColor((port == 1) ? (form.MSRLResult) : (form.MSRLResult2), Color.Red); break;
                    case (15): form.updatePanelColor((port == 1) ? (form.MSRHResult) : (form.MSRHResult2), Color.Red); break;
                    case (16): form.updatePanelColor((port == 1) ? (form.SmartCardResult) : (form.SmartCardResult2), Color.Red); break;
                    case (17): form.updatePanelColor((port == 1) ? (form.ContactlessResult) : (form.ContactlessResult2), Color.Red); break;
                }

            }
        }

        public static void Set_Progress(int test_index, TableLayoutPanel table, Form1 form)
        {

        }
    }
}

