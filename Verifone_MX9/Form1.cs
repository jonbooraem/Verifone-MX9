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
    public partial class Form1 : Form
    {
        #region Public Variables
        public static string[] tests = new string[] { /*"RTC",*/ "COM1", "COIN", "IOE", "USB", "MBEE", "ECR", "LAN", "SD", "SAM", "Keypad", "Touchscreen", "LED", "Display", "Backlight", "Audio", "MSRL", "MSRH", "SmartCard", "Contactless" };
        public Button COM1,  COIN,  IOE,  USB,  MBEE,  ECR,  LAN,  Keypad,  Touchscreen,  LED,  Display,  Backlight,  Audio,  MSRH, MSRL,  SmartCard,  Contactless,  SAM, SD,
                      COM12, COIN2, IOE2, USB2, MBEE2, ECR2, LAN2, Keypad2, Touchscreen2, LED2, Display2, Backlight2, Audio2, MSRH2, MSRL2, SmartCard2, Contactless2, SAM2, SD2;
        public CheckBox COM1Check, COINCheck, IOECheck, USBCheck, MBEECheck, ECRCheck, LANCheck, KeypadCheck, TouchscreenCheck, LEDCheck, DisplayCheck, BacklightCheck,
                        AudioCheck, MSRLCheck, MSRHCheck, SmartCardCheck, ContactlessCheck, SAMCheck, SDCheck,
                        COM1Check2, COINCheck2, IOECheck2, USBCheck2, MBEECheck2, ECRCheck2, LANCheck2, KeypadCheck2, TouchscreenCheck2, LEDCheck2, DisplayCheck2, BacklightCheck2,
                        AudioCheck2, MSRLCheck2, MSRHCheck2, SmartCardCheck2, ContactlessCheck2, SAMCheck2, SDCheck2;
        public Panel COM1Result, COINResult, IOEResult, USBResult, MBEEResult, ECRResult, LANResult, KeypadResult, TouchscreenResult, LEDResult, DisplayResult, BacklightResult, AudioResult, MSRLResult, MSRHResult, SmartCardResult, ContactlessResult,
                     COM1Result2, COINResult2, IOEResult2, USBResult2, MBEEResult2, ECRResult2, LANResult2, KeypadResult2, TouchscreenResult2, LEDResult2, DisplayResult2, BacklightResult2, AudioResult2, MSRLResult2, MSRHResult2, SmartCardResult2, ContactlessResult2,
                     SAMResult, SAMResult2, SDResult, SDResult2;
        public Button[] testButtons, testButtons2;
        public MX9Tester Tester1, Tester2;
        public bool[] testResults, testResults2;
        public string testLog, testLog2;
        public bool stopTest = false;
        public bool stopTest2 = false;
        #endregion

        public Form1()
        {
            Tester1 = new MX9Tester(this, 1);
            Tester2 = new MX9Tester(this, 2);

            testButtons = new Button[tests.Length];
            testButtons2 = new Button[tests.Length];
            testResults = new bool[tests.Length];
            testResults2 = new bool[tests.Length];
            for (int i = 0; i < tests.Length; i++)
            {
                testButtons[i] = new Button();
                testButtons2[i] = new Button();
                testResults[i] = false;
                testResults2[i] = false;
            }

            InitializeComponent();
            build_table(this.testTable,  tests);
            build_table2(this.testTable2, tests);
            string modelsPath = @"C:\Verifone_related\models.txt";
            populate_combobox(modelsPath, this.modelComboBox);
            populate_combobox(modelsPath, this.modelComboBox2);


            buttonEnabler(clearButton, false);
            buttonEnabler(clearButton2, false);
            buttonEnabler(detamperButton, false);
            buttonEnabler(detamperButton2, false);
            enableTestButtons(false);
            enableTestButtons2(false);
            enableChecks(false);
            enableChecks2(false);
            enableCheckAll2(false);
            enableUncheckAll2(false);

            Timer_.Elapsed += new ElapsedEventHandler((sender, EventArgs) => { OnTimedEvent(sender, EventArgs, this, timerLabel.Text, timerLabel); });
            Timer_.Interval = 1000;
            Timer_.Enabled = false; 
            Timer_2.Elapsed += new ElapsedEventHandler((sender, EventArgs) => { OnTimedEvent(sender, EventArgs, this, timerLabel2.Text, timerLabel2); });
            Timer_2.Interval = 1000;
            Timer_2.Enabled = false;
            timerLabel.Text = "00:00:00";
            timerLabel2.Text = "00:00:00";
            testButtons = new Button[tests.Length];

            this.versionLabel.Text = ConfigurationManager.AppSettings.Get("ProgramVersion");//testVersion;
        }

        #region Start Button Checks
        public bool modelSelected
        {
            get { return _modelSelected; }
            set
            {
                _modelSelected = value;
                if (_modelSelected == true && serialEntered == true)
                {
                    buttonEnabler(startButton, true);
                    buttonEnabler(detamperButton, true);
                    enableChecks(true);
                    enableCheckAll(true);
                    enableUncheckAll(true);
                }
                else
                {
                    buttonEnabler(startButton, false);
                    buttonEnabler(detamperButton, false);
                    enableChecks(false);
                    enableCheckAll(false);
                    enableUncheckAll(false);
                }
            }
        }

        public bool serialEntered
        {
            get { return _serialEntered; }
            set
            {
                _serialEntered = value;
                if (_serialEntered == true && modelSelected == true)
                {
                    buttonEnabler(startButton, true);
                    buttonEnabler(detamperButton, true);
                    enableChecks(true);
                    enableCheckAll(true);
                    enableUncheckAll(true);
                }
                else
                {
                    buttonEnabler(startButton, false);
                    buttonEnabler(detamperButton, false);
                    enableChecks(false);
                    enableCheckAll(false);
                    enableUncheckAll(false);
                }
            }
        }
        
        public bool modelSelected2
        {
            get { return _modelSelected2; }
            set
            {
                _modelSelected2 = value;
                if (_modelSelected2 == true && serialEntered2 == true)
                {
                    buttonEnabler(startButton2, true);
                    buttonEnabler(detamperButton2, true);
                    enableChecks2(true);
                    enableCheckAll2(true);
                    enableUncheckAll2(true);
                }
                else
                {
                    buttonEnabler(startButton2, false);
                    buttonEnabler(detamperButton2, false);
                    enableChecks2(false);
                    enableCheckAll2(false);
                    enableUncheckAll2(false);
                }
            }
        }

        public bool serialEntered2
        {
            get { return _serialEntered2; }
            set
            {
                _serialEntered2 = value;
                if (_serialEntered2 == true && _modelSelected2 == true)
                {
                    buttonEnabler(startButton2, true);
                    buttonEnabler(detamperButton2, true);
                    enableChecks2(true);
                    enableCheckAll2(true);
                    enableUncheckAll2(true); 
                }
                else
                {
                    buttonEnabler(startButton2, false);
                    buttonEnabler(detamperButton2, false);
                    enableChecks2(false);
                    enableCheckAll2(false);
                    enableUncheckAll2(false); 
                }
            }
        }

        public bool _serialEntered, _modelSelected, _serialEntered2, _modelSelected2;
        public string selectedModel, selectedModel2;

        public void selectedModelChanged(object sender, EventArgs e)
        {
            if (this.modelComboBox.SelectedIndex == 0) { modelSelected = false; selectedModel = ""; }
            else { modelSelected = true; selectedModel = (this.modelComboBox.SelectedIndex == 1) ? ("MX915") : ("MX925"); }
        }

        public bool isNumeric(char input)
        {
            if (input.Equals('0') || input.Equals('1') || input.Equals('2') || input.Equals('3') || input.Equals('4') ||
                input.Equals('5') || input.Equals('6') || input.Equals('7') || input.Equals('8') || input.Equals('9')) return true;
            return false;
        }

        public void serialNumberChanged(object sender, EventArgs e)
        {
            string text = this.serialNumberBox.Text;
            if (text.Length == 0) { }
            else if (text[0].Equals('V') || text[0].Equals('v'))
            {
                Match m = Regex.Match(text, @"^[vV]{1}[0-9]{10}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered = true; }
                else { serialEntered = false; }
            }
            else if (text[0].Equals('T') || text[0].Equals('t'))
            {
                Match m = Regex.Match(text, @"^[tT]{1}[0-9]{10}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered = true; }
                else { serialEntered = false; }
            }
            else if (isNumeric(text[0]))
            {
                Match m = Regex.Match(text, @"^[0-9]{3}[-]{1}[0-9]{3}[-]{1}[0-9]{3}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered = true; }
                else { serialEntered = false; }
            }
        }

        public void selectedModel2Changed(object sender, EventArgs e)
        {
            if (this.modelComboBox2.SelectedIndex == 0) { modelSelected2 = false; selectedModel2 = ""; }
            else { modelSelected2 = true; selectedModel2 = (this.modelComboBox2.SelectedIndex == 1) ? ("MX915") : ("MX925"); }
        }

        public void serialNumber2Changed(object sender, EventArgs e)
        {
            string text = this.serialNumber2Box.Text;
            if (text.Length == 0) { }
            else if (text[0].Equals('V') || text[0].Equals('v'))
            {
                Match m = Regex.Match(text, @"^[vV]{1}[0-9]{10}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered2 = true; }
                else { serialEntered2 = false; }
            }
            else if (text[0].Equals('T') || text[0].Equals('t'))
            {
                Match m = Regex.Match(text, @"^[tT]{1}[0-9]{10}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered2 = true; }
                else { serialEntered2 = false; }
            }
            else if (isNumeric(text[0]))
            {
                Match m = Regex.Match(text, @"^[0-9]{3}[-]{1}[0-9]{3}[-]{1}[0-9]{3}$");
                if (m.Length == 11 && text.Length == 11) { serialEntered2 = true; }
                else { serialEntered2 = false; }
            }
        }
        #endregion

        #region Thread Safe GUI Functions
        delegate void buttonEnablerDelegate(Button inputButton, bool enabled);
        public void buttonEnabler(Button inputButton, bool enabled)
        {
            if (inputButton.InvokeRequired)
            {
                buttonEnablerDelegate del = new buttonEnablerDelegate(buttonEnabler);
                this.Invoke(del, new object[] { inputButton, enabled });
            }
            else
            {
                inputButton.Enabled = enabled;
            }
        }

        delegate void checkBoxEnablerDelegate(CheckBox inputCheck, bool enabled);
        public void checkBoxEnabler(CheckBox inputCheck, bool enabled)
        {
            if (inputCheck.InvokeRequired)
            {
                checkBoxEnablerDelegate del = new checkBoxEnablerDelegate(checkBoxEnabler);
                this.Invoke(del, new object[] { inputCheck, enabled });
            }
            else
            {
                inputCheck.Enabled = enabled;
            }
        }

        delegate void updatePanelColorDelegate(Panel inputPanel, Color inputColor);
        public void updatePanelColor(Panel inputPanel, Color inputColor)
        {
            if (inputPanel.InvokeRequired)
            {
                updatePanelColorDelegate del = new updatePanelColorDelegate(updatePanelColor);
                this.Invoke(del, new object[] { inputPanel, inputColor });
            }
            else
            {
                inputPanel.BackColor = inputColor;
            }
        }

        delegate bool getCheckStatusDelegate(CheckBox inputCheck);
        public bool getCheckStatus(CheckBox inputCheck)
        {
            if (inputCheck.InvokeRequired)
            {
                getCheckStatusDelegate del = new getCheckStatusDelegate(getCheckStatus);
                return (bool)this.Invoke(del, new object[] { inputCheck });
            }
            else
            {
                return inputCheck.Checked;
            }
        }

        delegate string getSelectedModelDelegate(ComboBox inputCombo);
        public string getSelectedModel(ComboBox inputCombo)
        {
            if (inputCombo.InvokeRequired)
            {
                getSelectedModelDelegate del = new getSelectedModelDelegate(getSelectedModel);
                return (string)this.Invoke(del, new object[] { inputCombo });
            }
            else
            {
                return inputCombo.SelectedText;
            }
        }

        public void clearTestResults()
        {
            updatePanelColor(COM1Result, Color.White);
            updatePanelColor(COINResult, Color.White);
            updatePanelColor(IOEResult, Color.White);
            updatePanelColor(USBResult, Color.White);
            updatePanelColor(MBEEResult, Color.White);
            updatePanelColor(ECRResult, Color.White);
            updatePanelColor(LANResult, Color.White);
            updatePanelColor(SAMResult, Color.White);
            updatePanelColor(KeypadResult, Color.White);
            updatePanelColor(TouchscreenResult, Color.White);
            updatePanelColor(LEDResult, Color.White);
            updatePanelColor(DisplayResult, Color.White);
            updatePanelColor(BacklightResult, Color.White);
            updatePanelColor(AudioResult, Color.White);
            updatePanelColor(MSRLResult, Color.White);
            updatePanelColor(MSRHResult, Color.White);
            updatePanelColor(SmartCardResult, Color.White);
            updatePanelColor(ContactlessResult, Color.White);
            updatePanelColor(SDResult, Color.White);
        }

        public void clearTestResults2()
        {
            updatePanelColor(COM1Result2, Color.White);
            updatePanelColor(COINResult2, Color.White);
            updatePanelColor(IOEResult2, Color.White);
            updatePanelColor(USBResult2, Color.White);
            updatePanelColor(MBEEResult2, Color.White);
            updatePanelColor(ECRResult2, Color.White);
            updatePanelColor(LANResult2, Color.White);
            updatePanelColor(SAMResult2, Color.White);
            updatePanelColor(KeypadResult2, Color.White);
            updatePanelColor(TouchscreenResult2, Color.White);
            updatePanelColor(LEDResult2, Color.White);
            updatePanelColor(DisplayResult2, Color.White);
            updatePanelColor(BacklightResult2, Color.White);
            updatePanelColor(AudioResult2, Color.White);
            updatePanelColor(MSRLResult2, Color.White);
            updatePanelColor(MSRHResult2, Color.White);
            updatePanelColor(SmartCardResult2, Color.White);
            updatePanelColor(ContactlessResult2, Color.White);
            updatePanelColor(SDResult2, Color.White);
        }


        #region GUI Button Enablers
        delegate void enableCheckAllDelegate(bool enabled);
        public void enableCheckAll(bool enabled)
        {
            if (this.checkAll.InvokeRequired)
            {
                enableCheckAllDelegate del = new enableCheckAllDelegate(enableCheckAll);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                checkAll.Enabled = enabled;
                if (enabled) { checkAll.BackColor = Color.Lime; }
                else { checkAll.BackColor = Color.FromArgb(192, 255, 192); }
            }
        }

        delegate void enableUncheckAllDelegate(bool enabled);
        public void enableUncheckAll(bool enabled)
        {
            if (this.uncheckAll.InvokeRequired)
            {
                enableUncheckAllDelegate del = new enableUncheckAllDelegate(enableUncheckAll);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                uncheckAll.Enabled = enabled;
                if (enabled) { uncheckAll.BackColor = Color.Red; }
                else { uncheckAll.BackColor = Color.FromArgb(255, 192, 192); }
            }
        }

        delegate void enableCheckAll2Delegate(bool enabled);
        public void enableCheckAll2(bool enabled)
        {
            if (this.checkAll2.InvokeRequired)
            {
                enableCheckAll2Delegate del = new enableCheckAll2Delegate(enableCheckAll2);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                checkAll2.Enabled = enabled;
                if (enabled) { checkAll2.BackColor = Color.Lime; }
                else { checkAll2.BackColor = Color.FromArgb(192, 255, 192); }
            }
        }

        delegate void enableUncheckAll2Delegate(bool enabled);
        public void enableUncheckAll2(bool enabled)
        {
            if (this.uncheckAll2.InvokeRequired)
            {
                enableUncheckAll2Delegate del = new enableUncheckAll2Delegate(enableUncheckAll2);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                uncheckAll2.Enabled = enabled;
                if (enabled) { uncheckAll2.BackColor = Color.Red; }
                else { uncheckAll2.BackColor = Color.FromArgb(255, 192, 192); }
            }
        }

        delegate void enableModelDelegate(bool enabled);
        public void enableModel(bool enabled)
        {
            if (this.modelComboBox.InvokeRequired)
            {
                enableModelDelegate del = new enableModelDelegate(enableModel);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                modelComboBox.Enabled = enabled;
            }
        }

        delegate void enableSerialDelegate(bool enabled);
        public void enableSerial(bool enabled)
        {
            if (this.serialNumberBox.InvokeRequired)
            {
                enableSerialDelegate del = new enableSerialDelegate(enableSerial);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                serialNumberBox.Enabled = enabled;
            }
        }

        delegate void enableModelDelegate2(bool enabled);
        public void enableModel2(bool enabled)
        {
            if (this.modelComboBox2.InvokeRequired)
            {
                enableModelDelegate2 del = new enableModelDelegate2(enableModel2);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                modelComboBox2.Enabled = enabled;
            }
        }

        delegate void enableSerialDelegate2(bool enabled);
        public void enableSerial2(bool enabled)
        {
            if (this.serialNumber2Box.InvokeRequired)
            {
                enableSerialDelegate2 del = new enableSerialDelegate2(enableSerial2);
                this.Invoke(del, new object[] { enabled });
            }
            else
            {
                serialNumber2Box.Enabled = enabled;
            }
        }
        #endregion

        #region Test Check Box Enablers
        public void enableChecks(bool enabled)
        {
            checkBoxEnabler(COM1Check, enabled);
            checkBoxEnabler(COINCheck, enabled);
            checkBoxEnabler(IOECheck, enabled);
            checkBoxEnabler(USBCheck, enabled);
            checkBoxEnabler(MBEECheck, enabled);
            checkBoxEnabler(ECRCheck, enabled);
            checkBoxEnabler(LANCheck, enabled);
            checkBoxEnabler(SAMCheck, enabled);
            checkBoxEnabler(KeypadCheck, enabled);
            checkBoxEnabler(TouchscreenCheck, enabled);
            checkBoxEnabler(LEDCheck, enabled);
            checkBoxEnabler(DisplayCheck, enabled);
            checkBoxEnabler(BacklightCheck, enabled);
            checkBoxEnabler(AudioCheck, enabled);
            checkBoxEnabler(MSRLCheck, enabled);
            checkBoxEnabler(MSRHCheck, enabled);
            checkBoxEnabler(SmartCardCheck, enabled);
            checkBoxEnabler(ContactlessCheck, enabled);
            checkBoxEnabler(SDCheck, enabled);
        }
        public void enableChecks2(bool enabled)
        {
            checkBoxEnabler(COM1Check2, enabled);
            checkBoxEnabler(COINCheck2, enabled);
            checkBoxEnabler(IOECheck2, enabled);
            checkBoxEnabler(USBCheck2, enabled);
            checkBoxEnabler(MBEECheck2, enabled);
            checkBoxEnabler(ECRCheck2, enabled);
            checkBoxEnabler(LANCheck2, enabled);
            checkBoxEnabler(SAMCheck2, enabled);
            checkBoxEnabler(KeypadCheck2, enabled);
            checkBoxEnabler(TouchscreenCheck2, enabled);
            checkBoxEnabler(LEDCheck2, enabled);
            checkBoxEnabler(DisplayCheck2, enabled);
            checkBoxEnabler(BacklightCheck2, enabled);
            checkBoxEnabler(AudioCheck2, enabled);
            checkBoxEnabler(MSRLCheck2, enabled);
            checkBoxEnabler(MSRHCheck2, enabled);
            checkBoxEnabler(SmartCardCheck2, enabled);
            checkBoxEnabler(ContactlessCheck2, enabled);
            checkBoxEnabler(SDCheck2, enabled);
        }
        #endregion

        #region Single Test Button Enablers
        public void enableTestButtons(bool enabled)
        {
            buttonEnabler(COM1, enabled);
            buttonEnabler(COIN, enabled);
            buttonEnabler(IOE, enabled);
            buttonEnabler(USB, enabled);
            buttonEnabler(MBEE, enabled);
            buttonEnabler(ECR, enabled);
            buttonEnabler(LAN, enabled);
            buttonEnabler(SAM, enabled);
            buttonEnabler(Keypad, enabled);
            buttonEnabler(Touchscreen, enabled);
            buttonEnabler(LED, enabled);
            buttonEnabler(Display, enabled);
            buttonEnabler(Backlight, enabled);
            buttonEnabler(Audio, enabled);
            buttonEnabler(MSRL, enabled);
            buttonEnabler(MSRH, enabled);
            buttonEnabler(SmartCard, enabled);
            buttonEnabler(Contactless, enabled);
            buttonEnabler(SD, enabled);
        }
        public void enableTestButtons2(bool enabled)
        {
            buttonEnabler(COM12, enabled);
            buttonEnabler(COIN2, enabled);
            buttonEnabler(IOE2, enabled);
            buttonEnabler(USB2, enabled);
            buttonEnabler(MBEE2, enabled);
            buttonEnabler(ECR2, enabled);
            buttonEnabler(LAN2, enabled);
            buttonEnabler(SAM2, enabled);
            buttonEnabler(Keypad2, enabled);
            buttonEnabler(Touchscreen2, enabled);
            buttonEnabler(LED2, enabled);
            buttonEnabler(Display2, enabled);
            buttonEnabler(Backlight2, enabled);
            buttonEnabler(Audio2, enabled);
            buttonEnabler(MSRL2, enabled);
            buttonEnabler(MSRH2, enabled);
            buttonEnabler(SmartCard2, enabled);
            buttonEnabler(Contactless2, enabled);
            buttonEnabler(SD2, enabled);
        }
        #endregion
        #endregion

        #region Single Test Button Handlers 1
        public void runCOM1(object sender, EventArgs e)
        {
            Tester1.RunCOM1Test(true, false);
        }
        public void runCOIN(object sender, EventArgs e)
        {
            Tester1.RunCOINTest(true, false);
        }
        public void runIOE(object sender, EventArgs e)
        {
            Tester1.RunIOETest(true, false);
        }
        public void runUSB(object sender, EventArgs e)
        {
            Tester1.RunUSBTest(true, false);
        }
        public void runMBEE(object sender, EventArgs e)
        {
            Tester1.RunMBEETest(true, false);
        }
        public void runECR(object sender, EventArgs e)
        {
            Tester1.RunECRTest(true, false);
        }
        public void runLAN(object sender, EventArgs e)
        {
            Tester1.RunLANTest(true, false);
        }
        public void runSAM(object sender, EventArgs e)
        {
            Tester1.RunSAMTest(true, false);
        }
        public void runKeypad(object sender, EventArgs e)
        {
            Tester1.RunKeypadTest(true, false);
        }
        public void runTouchscreen(object sender, EventArgs e)
        {
            Tester1.RunTouchscreenTest(true, false);
        }
        public void runLED(object sender, EventArgs e)
        {
            Tester1.RunLEDTest(true, false);
        }
        public void runDisplay(object sender, EventArgs e)
        {
            Tester1.RunDisplayTest(true, false);
        }
        public void runBacklight(object sender, EventArgs e)
        {
            Tester1.RunBacklightTest(true, false);
        }
        public void runAudio(object sender, EventArgs e)
        {
            Tester1.RunAudioTest(true, false);
        }
        public void runMSRL(object sender, EventArgs e)
        {
            Tester1.RunMSRLTest(true, false);
        }
        public void runMSRH(object sender, EventArgs e)
        {
            Tester1.RunMSRHTest(true, false);
        }
        public void runSmartCard(object sender, EventArgs e)
        {
            Tester1.RunSmartCardTest(true, false);
        }
        public void runContactless(object sender, EventArgs e)
        {
            Tester1.RunContactlessTest(true, false);
        }
        public void runSD(object sender, EventArgs e)
        {
            Tester1.RunSDTest(true, false);
        }
        #endregion

        #region Single Test Button Handlers 2
        public void runCOM12(object sender, EventArgs e)
        {
            Tester2.RunCOM1Test(true, false);
        }
        public void runCOIN2(object sender, EventArgs e)
        {
            Tester2.RunCOINTest(true, false);
        }
        public void runIOE2(object sender, EventArgs e)
        {
            Tester2.RunIOETest(true, false);
        }
        public void runUSB2(object sender, EventArgs e)
        {
            Tester2.RunUSBTest(true, false);
        }
        public void runMBEE2(object sender, EventArgs e)
        {
            Tester2.RunMBEETest(true, false);
        }
        public void runECR2(object sender, EventArgs e)
        {
            Tester2.RunECRTest(true, false);
        }
        public void runLAN2(object sender, EventArgs e)
        {
            Tester2.RunLANTest(true, false);
        }
        public void runSAM2(object sender, EventArgs e)
        {
            Tester2.RunSAMTest(true, false);
        }
        public void runKeypad2(object sender, EventArgs e)
        {
            Tester2.RunKeypadTest(true, false);
        }
        public void runTouchscreen2(object sender, EventArgs e)
        {
            Tester2.RunTouchscreenTest(true, false);
        }
        public void runLED2(object sender, EventArgs e)
        {
            Tester2.RunLEDTest(true, false);
        }
        public void runDisplay2(object sender, EventArgs e)
        {
            Tester2.RunDisplayTest(true, false);
        }
        public void runBacklight2(object sender, EventArgs e)
        {
            Tester2.RunBacklightTest(true, false);
        }
        public void runAudio2(object sender, EventArgs e)
        {
            Tester2.RunAudioTest(true, false);
        }
        public void runMSRL2(object sender, EventArgs e)
        {
            Tester2.RunMSRLTest(true, false);
        }
        public void runMSRH2(object sender, EventArgs e)
        {
            Tester2.RunMSRHTest(true, false);
        }
        public void runSmartCard2(object sender, EventArgs e)
        {
            Tester2.RunSmartCardTest(true, false);
        }
        public void runContactless2(object sender, EventArgs e)
        {
            Tester2.RunContactlessTest(true, false);
        }
        public void runSD2(object sender, EventArgs e)
        {
            Tester2.RunSDTest(true, false);
        }
        #endregion

        #region GUI Button Handlers 1
        public void clear_button_Click(object sender, EventArgs e)
        {
            clearTestResults();
            saveResults();
            for (int i = 0; i < tests.Length; i++)
            {
                testTable.GetControlFromPosition(2, i + 1).Controls.Clear();

            }
            timerLabel.Text = "00:00:00";
            finalResultLabel.Text = "START";
            finalResultLabel.BackColor = Color.White;
            logs.Text = "";
            serialNumberBox.Text = "";
            modelComboBox.SelectedIndex = 0;
            enableSerial(true);
            enableModel(true);
            enableTestButtons(false);
            buttonEnabler(clearButton, false);
            buttonEnabler(startButton, false);
        }
        public void start_button_Click(object sender_, EventArgs e)
        {
            enableSerial(false);
            enableModel(false);

            for (int i = 0; i < tests.Length; i++)
            {
                testTable.GetControlFromPosition(2, i + 1).Controls.Clear();

            }

            if (modelComboBox.SelectedItem.ToString().Contains("MX"))
            {

                finalResultLabel.Text = "TESTING";
                finalResultLabel.BackColor = Color.Orange;

                Thread th = new Thread(new ThreadStart(StartTest));
                th.Start();

            }

            else
            {
                MessageBox.Show("Missing Parameter(s)");
            }
        }
        private void uncheckAll_Click(object sender, EventArgs e)
        {
            COM1Check.Checked = false;
            COINCheck.Checked = false;
            IOECheck.Checked = false;
            USBCheck.Checked = false;
            MBEECheck.Checked = false;
            ECRCheck.Checked = false;
            LANCheck.Checked = false;
            SAMCheck.Checked = false;
            KeypadCheck.Checked = false;
            TouchscreenCheck.Checked = false;
            LEDCheck.Checked = false;
            DisplayCheck.Checked = false;
            BacklightCheck.Checked = false;
            AudioCheck.Checked = false;
            MSRLCheck.Checked = false;
            MSRHCheck.Checked = false;
            SmartCardCheck.Checked = false;
            ContactlessCheck.Checked = false;
            SDCheck.Checked = false;
        }
        private void checkAll_Click(object sender, EventArgs e)
        {
            COM1Check.Checked = true;
            COINCheck.Checked = true;
            IOECheck.Checked = true;
            USBCheck.Checked = true;
            MBEECheck.Checked = true;
            ECRCheck.Checked = true;
            LANCheck.Checked = true;
            SAMCheck.Checked = true;
            KeypadCheck.Checked = true;
            TouchscreenCheck.Checked = true;
            LEDCheck.Checked = true;
            DisplayCheck.Checked = true;
            BacklightCheck.Checked = true;
            AudioCheck.Checked = true;
            MSRLCheck.Checked = true;
            MSRHCheck.Checked = true;
            SmartCardCheck.Checked = true;
            ContactlessCheck.Checked = true;
            SDCheck.Checked = true;
        }
        private void detamperButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
           {
               this.AppendText(this.logs, System.Drawing.Color.Blue, "Beginning Detamper Process \n");
               enableSerial(false);
               enableModel(false);
               enableTestButtons(false);
               enableChecks(false);
               enableCheckAll(false);
               enableUncheckAll(false);
               buttonEnabler(detamperButton, false);
               buttonEnabler(startButton, false);
               buttonEnabler(clearButton, false);

               ProcessStartInfo start = new ProcessStartInfo();
               start.Arguments = "";
               start.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + (@"\COM1 DOSBox");//@"C:\Program Files (x86)\DOSBox-0.74-2 COM2\DOSBox.exe";
                start.WindowStyle = ProcessWindowStyle.Maximized;
               int exitCode;

               using (Process proc = Process.Start(start.FileName, "-conf dosbox.conf"))
               {
                   proc.WaitForExit();
                   exitCode = proc.ExitCode;
               }
               this.AppendText(this.logs, System.Drawing.Color.Green, "Detamper Process Completed \n");

               enableTestButtons(false);
               enableChecks(true);
               enableCheckAll(true);
               enableUncheckAll(true);
               buttonEnabler(detamperButton, true);
               buttonEnabler(startButton, true);
               buttonEnabler(clearButton, true);
           }).Start();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            stopTest = true;
        }
        #endregion

        #region GUI Button Handlers 2
        public void clear_button_Click2(object sender, EventArgs e)
        {
            clearTestResults2();
            saveResults2();
            for (int i = 0; i < tests.Length; i++)
            {
                testTable2.GetControlFromPosition(2, i + 1).Controls.Clear();

            }
            timerLabel2.Text = "00:00:00";
            finalResultLabel2.Text = "START";
            finalResultLabel2.BackColor = Color.White;
            logs2.Text = "";
            serialNumber2Box.Text = "";
            modelComboBox2.SelectedIndex = 0;
            enableSerial2(true);
            enableModel2(true);
            enableTestButtons2(false);
            buttonEnabler(clearButton2, false);
            buttonEnabler(startButton2, false);
        }
        public void start_button_Click2(object sender_, EventArgs e)
        {
            enableSerial2(false);
            enableModel2(false);

            for (int i = 0; i < tests.Length; i++)
            {
                testTable2.GetControlFromPosition(2, i + 1).Controls.Clear();
                
            }

            if (modelComboBox2.SelectedItem.ToString().Contains("MX"))
            {

                finalResultLabel2.Text = "TESTING";
                finalResultLabel2.BackColor = Color.Orange;

                Thread th = new Thread(new ThreadStart(StartTest2));
                th.Start();

            }

            else
            {
                MessageBox.Show("Missing Parameter(s)");
            }
        }
        private void uncheckAll_Click2(object sender, EventArgs e)
        {
            COM1Check2.Checked = false;
            COINCheck2.Checked = false;
            IOECheck2.Checked = false;
            USBCheck2.Checked = false;
            MBEECheck2.Checked = false;
            ECRCheck2.Checked = false;
            LANCheck2.Checked = false;
            SAMCheck2.Checked = false;
            KeypadCheck2.Checked = false;
            TouchscreenCheck2.Checked = false;
            LEDCheck2.Checked = false;
            DisplayCheck2.Checked = false;
            BacklightCheck2.Checked = false;
            AudioCheck2.Checked = false;
            MSRLCheck2.Checked = false;
            MSRHCheck2.Checked = false;
            SmartCardCheck2.Checked = false;
            ContactlessCheck2.Checked = false;
            SDCheck2.Checked = false;
        }
        private void checkAll_Click2(object sender, EventArgs e)
        {
            COM1Check2.Checked = true;
            COINCheck2.Checked = true;
            IOECheck2.Checked = true;
            USBCheck2.Checked = true;
            MBEECheck2.Checked = true;
            ECRCheck2.Checked = true;
            LANCheck2.Checked = true;
            SAMCheck2.Checked = true;
            KeypadCheck2.Checked = true;
            TouchscreenCheck2.Checked = true;
            LEDCheck2.Checked = true;
            DisplayCheck2.Checked = true;
            BacklightCheck2.Checked = true;
            AudioCheck2.Checked = true;
            MSRLCheck2.Checked = true;
            MSRHCheck2.Checked = true;
            SmartCardCheck2.Checked = true;
            ContactlessCheck2.Checked = true;
            SDCheck2.Checked = true;
        }
        private void detamperButton_Click2(object sender, EventArgs e)
        {
            new Thread(() =>
           {
               this.AppendText(this.logs2, System.Drawing.Color.Blue, "Beginning Detamper Process \n");
               enableSerial2(false);
               enableModel2(false);
               enableTestButtons2(false);
               enableChecks2(false);
               enableCheckAll2(false);
               enableUncheckAll2(false);
               buttonEnabler(detamperButton2, false);
               buttonEnabler(startButton2, false);
               buttonEnabler(clearButton2, false);

               ProcessStartInfo start = new ProcessStartInfo();
               start.Arguments = "";
               start.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + (@"\COM2 DOSBox");//@"C:\Program Files (x86)\DOSBox-0.74-2 COM2\DOSBox.exe";
                start.WindowStyle = ProcessWindowStyle.Maximized;
               int exitCode;

               using (Process proc = Process.Start(start.FileName, "-conf dosbox.conf"))
               {
                   proc.WaitForExit();
                   exitCode = proc.ExitCode;
               }
               this.AppendText(this.logs2, System.Drawing.Color.Green, "Detamper Process Completed \n");

               enableTestButtons2(false);
               enableChecks2(true);
               enableCheckAll2(true);
               enableUncheckAll2(true);
               buttonEnabler(detamperButton2, true);
               buttonEnabler(startButton2, true);
               buttonEnabler(clearButton2, true);
           }).Start();
        }
        private void stopButton_Click2(object sender, EventArgs e)
        {
            stopTest2 = true;
        }
        #endregion

        #region Other GUI Functions
        public void UpdateFinalResult()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {

                    if (allPassed())
                    {
                        finalResultLabel.Text = "PASS";
                        finalResultLabel.BackColor = Color.Green;
                    }
                    else
                    {
                        finalResultLabel.Text = "FAIL";
                        finalResultLabel.BackColor = Color.Red;
                    }
                    testLog = this.logs.Text + "\n\n";
                }));
            }
            else
            {
                if (allPassed())
                {
                    finalResultLabel.Text = "PASS";
                    finalResultLabel.BackColor = Color.Green;
                }
                else
                {
                    finalResultLabel.Text = "FAIL";
                    finalResultLabel.BackColor = Color.Red;
                }
                testLog = this.logs.Text + "\n\n";
            }
        }

        public void UpdateFinalResult2()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {

                    if (allPassed2())
                    {
                        finalResultLabel2.Text = "PASS";
                        finalResultLabel2.BackColor = Color.Green;
                    }
                    else
                    {
                        finalResultLabel2.Text = "FAIL";
                        finalResultLabel2.BackColor = Color.Red;
                    }
                    testLog2 = this.logs2.Text + "\n\n";
                }));
            }
            else
            {
                if (allPassed2())
                {
                    finalResultLabel2.Text = "PASS";
                    finalResultLabel2.BackColor = Color.Green;
                }
                else
                {
                    finalResultLabel2.Text = "FAIL";
                    finalResultLabel2.BackColor = Color.Red;
                }
                testLog2 = this.logs2.Text + "\n\n";
            }
        }

        public void AppendText(RichTextBox box, Color color, string text)
        {



            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {

                    box.SelectionStart = box.TextLength;
                    box.SelectionLength = 0;

                    box.SelectionColor = color;
                    box.AppendText(text);
                    box.SelectionColor = box.ForeColor;
                }));
            }
            else
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;

            }
        }

        private void mainFormClosing(object sender, FormClosingEventArgs e)
        {
            saveResults();
            saveResults2();
        }

        public void populate_combobox(string textFilePath, ComboBox combobox)
        {
            string lineOfText;
            //string textFilePath = @"C:\ProbeDataRecorder\signal_type.txt";

            var filestream = new System.IO.FileStream(textFilePath,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
            var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            while ((lineOfText = file.ReadLine()) != null)
            {
                //Do something with the lineOfText
                //MessageBox.Show(lineOfText);
                combobox.Items.Add(lineOfText);
            }

        }

        public void build_table(TableLayoutPanel table, string[] tests)
        {
            for (int i = 0; i < tests.Length + 1; i++)//row
            {
                for (int j = 0; j < 3; j++)//column
                {


                    Panel p = new Panel();
                    p.Margin = new Padding(1);
                    p.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                    p.BackColor = Color.White;
                    p.Dock = DockStyle.Fill;
                    table.Controls.Add(p, j, i);

                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            Label l = new Label();
                            l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                            l.BackColor = Color.CadetBlue;
                            l.Dock = DockStyle.Fill;
                            table.GetControlFromPosition(j, i).Controls.Add(l);
                        }
                        else
                        {
                            CheckBox c = new CheckBox();
                            c.AutoSize = false;
                            c.Size = new Size(this.testTable.GetColumnWidths()[0], this.testTable.GetRowHeights()[1]);
                            c.BackColor = Color.CadetBlue;
                            c.CheckAlign = ContentAlignment.MiddleCenter;
                            c.Dock = DockStyle.Fill;
                            c.Checked = true;

                            switch (tests[i - 1])
                            {
                                case ("COM1"): COM1Check = c; break;
                                case ("COIN"): COINCheck = c; break;
                                case ("IOE"): IOECheck = c; break;
                                case ("USB"): USBCheck = c; break;
                                case ("MBEE"): MBEECheck = c; break;
                                case ("ECR"): ECRCheck = c; break;
                                case ("LAN"): LANCheck = c; break;
                                case ("SAM"): SAMCheck = c; break;
                                case ("Keypad"): KeypadCheck = c; break;
                                case ("Touchscreen"): TouchscreenCheck = c; break;
                                case ("LED"): LEDCheck = c; break;
                                case ("Display"): DisplayCheck = c; break;
                                case ("Backlight"): BacklightCheck = c; break;
                                case ("Audio"): AudioCheck = c; break;
                                case ("MSRL"): MSRLCheck = c; break;
                                case ("MSRH"): MSRHCheck = c; break;
                                case ("SmartCard"): SmartCardCheck = c; break;
                                case ("Contactless"): ContactlessCheck = c; break;
                                case ("SD"): SDCheck = c; break;
                            }

                            table.GetControlFromPosition(j, i).Controls.Add(c);
                        }
                    }

                    //"Tests" label
                    else if (i == 0 && j == 1)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        l.Text = "Tests";
                        l.BackColor = Color.CadetBlue;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }


                    //"Results" label
                    else if (i == 0 && j == 2)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        l.Text = "Results";
                        l.BackColor = Color.CadetBlue;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }


                    //add the labels
                    else if (i > 0 && j == 1)
                    { 
                        Button b = new Button();
                        b.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        b.Text = tests[i - 1];
                        b.BackColor = Color.CadetBlue;
                        b.TextAlign = ContentAlignment.MiddleCenter;
                        b.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                        b.FlatStyle = FlatStyle.Flat;
                        b.Dock = DockStyle.Fill;
                        b.FlatAppearance.BorderSize = 0;
                        switch (tests[i - 1])
                        {
                            case ("COM1"): b.Click += new System.EventHandler(this.runCOM1); COM1 = b; break;
                            case ("COIN"): b.Click += new System.EventHandler(this.runCOIN); COIN = b; break;
                            case ("IOE"): b.Click += new System.EventHandler(this.runIOE); IOE = b; break;
                            case ("USB"): b.Click += new System.EventHandler(this.runUSB); USB = b; break;
                            case ("MBEE"): b.Click += new System.EventHandler(this.runMBEE); MBEE = b; break;
                            case ("ECR"): b.Click += new System.EventHandler(this.runECR); ECR = b; break;
                            case ("LAN"): b.Click += new System.EventHandler(this.runLAN); LAN = b; break;
                            case ("SAM"): b.Click += new System.EventHandler(this.runSAM); SAM = b; break;
                            case ("Keypad"): b.Click += new System.EventHandler(this.runKeypad); Keypad = b; break;
                            case ("Touchscreen"): b.Click += new System.EventHandler(this.runTouchscreen); Touchscreen = b; break;
                            case ("LED"): b.Click += new System.EventHandler(this.runLED); LED = b; break;
                            case ("Display"): b.Click += new System.EventHandler(this.runDisplay); Display = b; break;
                            case ("Backlight"): b.Click += new System.EventHandler(this.runBacklight); Backlight = b; break;
                            case ("Audio"): b.Click += new System.EventHandler(this.runAudio); Audio = b; break;
                            case ("MSRL"): b.Click += new System.EventHandler(this.runMSRL); MSRL = b; break;
                            case ("MSRH"): b.Click += new System.EventHandler(this.runMSRH); MSRH = b; break;
                            case ("SmartCard"): b.Click += new System.EventHandler(this.runSmartCard); SmartCard = b; break;
                            case ("Contactless"): b.Click += new System.EventHandler(this.runContactless); Contactless = b; break;
                            case ("SD"): b.Click += new System.EventHandler(this.runSD); SD = b; break;
                        }


                        table.GetControlFromPosition(j, i).Controls.Add(b);
                    }
                    else if (i > 0 && j == 2)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[2], this.testTable.GetRowHeights()[1]);
                        l.Text = "";
                        l.BackColor = Color.White;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);

                        switch (tests[i - 1])
                        {
                            case ("COM1"): COM1Result = p; break;
                            case ("COIN"): COINResult = p; break;
                            case ("IOE"): IOEResult = p; break;
                            case ("USB"): USBResult = p; break;
                            case ("MBEE"): MBEEResult = p; break;
                            case ("ECR"): ECRResult = p; break;
                            case ("LAN"): LANResult = p; break;
                            case ("SAM"): SAMResult = p; break;
                            case ("Keypad"): KeypadResult = p; break;
                            case ("Touchscreen"): TouchscreenResult= p; break;
                            case ("LED"): LEDResult = p; break;
                            case ("Display"): DisplayResult = p; break;
                            case ("Backlight"): BacklightResult = p; break;
                            case ("Audio"): AudioResult = p; break;
                            case ("MSRL"): MSRLResult = p; break;
                            case ("MSRH"): MSRHResult = p; break;
                            case ("SmartCard"): SmartCardResult = p; break;
                            case ("Contactless"): ContactlessResult = p; break;
                            case ("SD"): SDResult = p; break;
                        }

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }

                }
            }
        }

        public void build_table2(TableLayoutPanel table, string[] tests)
        {
            for (int i = 0; i < tests.Length + 1; i++)//row
            {
                for (int j = 0; j < 3; j++)//column
                {


                    Panel p = new Panel();
                    p.Margin = new Padding(1);
                    p.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                    p.BackColor = Color.White;
                    p.Dock = DockStyle.Fill;
                    table.Controls.Add(p, j, i);

                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            Label l = new Label();
                            l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                            l.BackColor = Color.CadetBlue;
                            l.Dock = DockStyle.Fill;
                            table.GetControlFromPosition(j, i).Controls.Add(l);
                        }
                        else
                        {
                            CheckBox c = new CheckBox();
                            c.AutoSize = false;
                            c.Size = new Size(this.testTable.GetColumnWidths()[0], this.testTable.GetRowHeights()[1]);
                            c.BackColor = Color.CadetBlue;
                            c.CheckAlign = ContentAlignment.MiddleCenter;
                            c.Dock = DockStyle.Fill;
                            c.Checked = true;

                            switch (tests[i - 1])
                            {
                                case ("COM1"): COM1Check2 = c; break;
                                case ("COIN"): COINCheck2 = c; break;
                                case ("IOE"): IOECheck2 = c; break;
                                case ("USB"): USBCheck2 = c; break;
                                case ("MBEE"): MBEECheck2 = c; break;
                                case ("ECR"): ECRCheck2 = c; break;
                                case ("LAN"): LANCheck2 = c; break;
                                case ("SAM"): SAMCheck2 = c; break;
                                case ("Keypad"): KeypadCheck2 = c; break;
                                case ("Touchscreen"): TouchscreenCheck2 = c; break;
                                case ("LED"): LEDCheck2 = c; break;
                                case ("Display"): DisplayCheck2 = c; break;
                                case ("Backlight"): BacklightCheck2 = c; break;
                                case ("Audio"): AudioCheck2 = c; break;
                                case ("MSRL"): MSRLCheck2 = c; break;
                                case ("MSRH"): MSRHCheck2 = c; break;
                                case ("SmartCard"): SmartCardCheck2 = c; break;
                                case ("Contactless"): ContactlessCheck2 = c; break;
                                case ("SD"): SDCheck2 = c; break;
                            }

                            table.GetControlFromPosition(j, i).Controls.Add(c);
                        }
                    }

                    //"Tests" label
                    else if (i == 0 && j == 1)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        l.Text = "Tests";
                        l.BackColor = Color.CadetBlue;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }


                    //"Results" label
                    else if (i == 0 && j == 2)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        l.Text = "Results";
                        l.BackColor = Color.CadetBlue;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }


                    //add the labels
                    else if (i > 0 && j == 1)
                    {
                        Button b = new Button();
                        b.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        b.Text = tests[i - 1];
                        b.BackColor = Color.CadetBlue;
                        b.TextAlign = ContentAlignment.MiddleCenter;
                        b.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
                        b.FlatStyle = FlatStyle.Flat;
                        b.Dock = DockStyle.Fill;
                        b.FlatAppearance.BorderSize = 0;
                        switch (tests[i - 1])
                        {
                            case ("COM1"): b.Click += new System.EventHandler(this.runCOM12); COM12 = b; break;
                            case ("COIN"): b.Click += new System.EventHandler(this.runCOIN2); COIN2 = b; break;
                            case ("IOE"): b.Click += new System.EventHandler(this.runIOE2); IOE2 = b; break;
                            case ("USB"): b.Click += new System.EventHandler(this.runUSB2); USB2 = b; break;
                            case ("MBEE"): b.Click += new System.EventHandler(this.runMBEE2); MBEE2 = b; break;
                            case ("ECR"): b.Click += new System.EventHandler(this.runECR2); ECR2 = b; break;
                            case ("LAN"): b.Click += new System.EventHandler(this.runLAN2); LAN2 = b; break;
                            case ("SAM"): b.Click += new System.EventHandler(this.runSAM2); SAM2 = b; break;
                            case ("Keypad"): b.Click += new System.EventHandler(this.runKeypad2); Keypad2 = b; break;
                            case ("Touchscreen"): b.Click += new System.EventHandler(this.runTouchscreen2); Touchscreen2 = b; break;
                            case ("LED"): b.Click += new System.EventHandler(this.runLED2); LED2 = b; break;
                            case ("Display"): b.Click += new System.EventHandler(this.runDisplay2); Display2 = b; break;
                            case ("Backlight"): b.Click += new System.EventHandler(this.runBacklight2); Backlight2 = b; break;
                            case ("Audio"): b.Click += new System.EventHandler(this.runAudio2); Audio2 = b; break;
                            case ("MSRL"): b.Click += new System.EventHandler(this.runMSRL2); MSRL2 = b; break;
                            case ("MSRH"): b.Click += new System.EventHandler(this.runMSRH2); MSRH2 = b; break;
                            case ("SmartCard"): b.Click += new System.EventHandler(this.runSmartCard2); SmartCard2 = b; break;
                            case ("Contactless"): b.Click += new System.EventHandler(this.runContactless2); Contactless2 = b; break;
                            case ("SD"): b.Click += new System.EventHandler(this.runSD2); SD2 = b; break;
                        }


                        table.GetControlFromPosition(j, i).Controls.Add(b);
                    }
                    else if (i > 0 && j == 2)
                    {
                        Label l = new Label();
                        l.Size = new Size(this.testTable.GetColumnWidths()[1], this.testTable.GetRowHeights()[1]);
                        l.Text = "";
                        l.BackColor = Color.White;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Dock = DockStyle.Fill;
                        l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);

                        switch (tests[i - 1])
                        {
                            case ("COM1"): COM1Result2 = p; break;
                            case ("COIN"): COINResult2 = p; break;
                            case ("IOE"): IOEResult2 = p; break;
                            case ("USB"): USBResult2 = p; break;
                            case ("MBEE"): MBEEResult2 = p; break;
                            case ("ECR"): ECRResult2 = p; break;
                            case ("LAN"): LANResult2 = p; break;
                            case ("SAM"): SAMResult2 = p; break;
                            case ("Keypad"): KeypadResult2 = p; break;
                            case ("Touchscreen"): TouchscreenResult2 = p; break;
                            case ("LED"): LEDResult2 = p; break;
                            case ("Display"): DisplayResult2 = p; break;
                            case ("Backlight"): BacklightResult2 = p; break;
                            case ("Audio"): AudioResult2 = p; break;
                            case ("MSRL"): MSRLResult2 = p; break;
                            case ("MSRH"): MSRHResult2 = p; break;
                            case ("SmartCard"): SmartCardResult2 = p; break;
                            case ("Contactless"): ContactlessResult2 = p; break;
                            case ("SD"): SDResult2 = p; break;
                        }

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }

                }
            }
        }
        #endregion

        #region Testing Functions
        public void StartTest()
        {
            clearTestResults();
            Timer_.Enabled = true;
            enableTestButtons(false);
            enableChecks(false);
            enableCheckAll(false);
            enableUncheckAll(false);
            buttonEnabler(startButton, false);
            buttonEnabler(clearButton, false);
            buttonEnabler(detamperButton, false);
            buttonEnabler(stopButton, true);

            //RTC rtc = new RTC(this);
            //rtc.Start_Test();

            Tester1.RunCOM1Test(false, stopTest);
            Tester1.RunCOINTest(false, stopTest);
            Tester1.RunIOETest(false, stopTest);
            Tester1.RunUSBTest(false, stopTest);
            Tester1.RunMBEETest(false, stopTest);
            Tester1.RunECRTest(false, stopTest);
            Tester1.RunLANTest(false, stopTest);
            
            Tester1.RunSAMTest(false, stopTest);
            Thread.Sleep(3000);
            Tester1.RunKeypadTest(false, stopTest);
            Tester1.RunTouchscreenTest(false, stopTest);
            Tester1.RunLEDTest(false, stopTest);
            Tester1.RunDisplayTest(false, stopTest);
            Tester1.RunBacklightTest(false, stopTest);
            Tester1.RunAudioTest(false, stopTest);
            Tester1.RunMSRLTest(false, stopTest);
            Tester1.RunMSRHTest(false, stopTest);
            Thread.Sleep(1000);
            Tester1.RunSmartCardTest(false, stopTest);
            Tester1.RunContactlessTest(false, stopTest);

            stopTest = false;

            UpdateFinalResult();

            Timer_.Enabled = false;

            enableTestButtons(true);
            enableChecks(true);
            enableCheckAll(true);
            enableUncheckAll(true);
            buttonEnabler(stopButton, false);
            buttonEnabler(startButton, true);
            buttonEnabler(clearButton, true);
            buttonEnabler(detamperButton, true);
        }

        public void StartTest2()
        {
            clearTestResults2();
            Timer_2.Enabled = true;
            enableTestButtons2(false);
            enableChecks2(false);
            enableCheckAll2(false);
            enableUncheckAll2(false);
            buttonEnabler(startButton2, false);
            buttonEnabler(clearButton2, false);
            buttonEnabler(detamperButton2, false);
            buttonEnabler(stopButton2, true);

            //RTC rtc = new RTC(this);
            //rtc.Start_Test();

            Tester2.RunCOM1Test(false, stopTest2);
            Tester2.RunCOINTest(false, stopTest2);
            Tester2.RunIOETest(false, stopTest2);
            Tester2.RunUSBTest(false, stopTest2);
            Tester2.RunMBEETest(false, stopTest2);
            Tester2.RunECRTest(false, stopTest2);
            Tester2.RunLANTest(false, stopTest2);
            Tester2.RunSAMTest(false, stopTest2);
            Thread.Sleep(3000);
            Tester2.RunKeypadTest(false, stopTest2);
            Tester2.RunTouchscreenTest(false, stopTest2);
            Tester2.RunLEDTest(false, stopTest2);
            Tester2.RunDisplayTest(false, stopTest2);
            Tester2.RunBacklightTest(false, stopTest2);
            Tester2.RunAudioTest(false, stopTest2);
            Tester2.RunMSRLTest(false, stopTest2);
            Tester2.RunMSRHTest(false, stopTest);
            Thread.Sleep(1000);
            Tester2.RunSmartCardTest(false, stopTest2);
            Tester2.RunContactlessTest(false, stopTest2);

            stopTest2 = false;

            UpdateFinalResult2();

            Timer_2.Enabled = false;

            enableTestButtons2(true);
            enableChecks2(true);
            enableCheckAll2(true);
            enableUncheckAll2(true);
            buttonEnabler(stopButton2, false);
            buttonEnabler(startButton2, true);
            buttonEnabler(clearButton2, true);
            buttonEnabler(detamperButton2, true);
        }
        #endregion

        #region Results Log Building
        public void saveResults()
        {
            string now = System.DateTime.Now.ToString("MM.dd.yy, HH.mm.ss");
            string fileName = serialNumberBox.Text + ", " + now + ".txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MX9 Test Results\\";
            string resultsHeader = buildResultsHeader();
            string[] log = (resultsHeader + "Testing Transcript:\n" + testLog2).Split('\n');
            System.IO.File.WriteAllLines(directory + fileName, log);
            bool OLPResult = saveResultsToOLP(log);
        }

        public void saveResults2()
        {
            string now = System.DateTime.Now.ToString("MM.dd.yy, HH.mm.ss");
            string fileName = serialNumber2Box.Text + ", " + now + ".txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MX9 Test Results\\";
            string resultsHeader = buildResultsHeader2();
            string[] log = (resultsHeader + "Testing Transcript:\n" + testLog2).Split('\n');
            System.IO.File.WriteAllLines(directory + fileName, log);
            bool OLPResult = saveResultsToOLP(log);
        }

        public bool saveResultsToOLP(string[] log)
        {

            return true;
        }

        public string buildResultsHeader()
        {
            string output = "";
            string[] DTC /*dateTime Components*/ = System.DateTime.Now.ToString("dddd.MMMM.dd.yyyy.HH.mm.ss").Split('.');
            output += "Verifone MX9 Test Results\n\n" +
                      "Test Date:\t" + DTC[0] + ", " + DTC[1] + " " + DTC[2] + " " + DTC[3] + "\n" +
                      "Test Time:\t" + DTC[4] + ":" + DTC[5] + ":" + DTC[6] + "\n" +
                      "Unit Variant:\t" + getSelectedModel(modelComboBox) + "\n" +
                      "Serial Number:\t" + serialNumberBox.Text + "\n\n\n";
            int dots = 0;
            string dotString = "";
            for (int i=0; i<testResults.Length; i++)
            {
                dots = 16 - tests[i].Length;
                dotString = "";
                for (int k=0; k<dots; k++)
                {
                    dotString += ".";
                }
                output += tests[i] + dotString + ((testResults[i]) ? ("Pass") : ("Fail **")) + "\n";
            }
            output += "\n\n\n";
            return output;
        }

        public string buildResultsHeader2()
        {
            string output = "";
            string[] DTC /*dateTime Components*/ = System.DateTime.Now.ToString("dddd.MMMM.dd.yyyy.HH.mm.ss").Split('.');
            output += "Verifone MX9 Test Results\n\n" +
                      "Test Date:\t" + DTC[0] + ", " + DTC[1] + " " + DTC[2] + " " + DTC[3] + "\n" +
                      "Test Time:\t" + DTC[4] + ":" + DTC[5] + ":" + DTC[6] + "\n" +
                      "Unit Variant:\t" + getSelectedModel(modelComboBox2) + "\n" +
                      "Serial Number:\t" + serialNumber2Box.Text + "\n\n\n";
            int dots = 0;
            string dotString = "";
            for (int i = 0; i < testResults2.Length; i++)
            {
                dots = 16 - tests[i].Length;
                dotString = "";
                for (int k = 0; k < dots; k++)
                {
                    dotString += ".";
                }
                output += tests[i] + dotString + ((testResults2[i]) ? ("Pass") : ("Fail **")) + "\n";
            }
            output += "\n\n\n";
            return output;
        }
        #endregion

        #region Other Helper Functions
        private static void OnTimedEvent(object source, ElapsedEventArgs e, Form f, String label_text, Label timer_label)
        {
            //MessageBox.Show("check");
            try
            {
                //timer_label1.Text = (Convert.ToInt32(timer_label1.Text) + 1).ToString();
                String seconds = label_text.Substring(6, 2);
                String minutes = label_text.Substring(3, 2);
                String hours = label_text.Substring(0, 2);
                int sec = Convert.ToInt32(seconds);
                int min = Convert.ToInt32(minutes);
                int hour = Convert.ToInt32(hours);
                sec++;
                if (sec == 60 || sec > 60)
                {
                    sec = 0;
                    min++;
                }
                if (min == 60 || min > 60)
                {
                    min = 0;
                    hour++;
                }
                TimeSpan timeSpan = new TimeSpan(hour, min, sec);
                //timer_label1.Text = timeSpan.ToString();

                f.Invoke((MethodInvoker)delegate
                {
                    timer_label.Text = timeSpan.ToString();
                    //f.Controls.Add(timer_label1);
                    //MessageBox.Show(timer_label1.Text);
                });
                //MessageBox.Show(timeSpan.ToString());
            }
            catch
            { }
        }

        public bool allPassed()
        {
            foreach (bool temp in testResults)
            {
                if (temp == false) { return false; }
            }
            return true;
        }
        public bool allPassed2()
        {
            foreach (bool temp in testResults2)
            {
                if (temp == false) { return false; }
            }
            return true;
        }
        #endregion
    }
}
