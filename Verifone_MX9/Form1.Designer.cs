using Verifone_MX9.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using Verifone_MX9.Tests;
using System.Threading;

namespace Verifone_MX9
{
    partial class Form1
    {
        public bool is_all_pass = true;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        System.Timers.Timer Timer_ = new System.Timers.Timer();
        System.Timers.Timer Timer_2 = new System.Timers.Timer();

        //private Rectangle screen;
        //public static string[] tests = new string[] { /*"RTC",*/ "COM1", "COIN", "IOE", "USB", "MBEE", "ECR", "LAN", /*"SAM",*/ "Keypad", "Touchscreen", "LED", "Display", "Backlight", "Audio",  "MSR", "SmartCard", "ContactLess"};

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.finalResultLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.testTable = new System.Windows.Forms.TableLayoutPanel();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.serialNumberBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detamperButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.Button();
            this.uncheckAll = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.logs2 = new System.Windows.Forms.RichTextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkAll2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.detamperButton2 = new System.Windows.Forms.Button();
            this.startButton2 = new System.Windows.Forms.Button();
            this.clearButton2 = new System.Windows.Forms.Button();
            this.stopButton2 = new System.Windows.Forms.Button();
            this.timerLabel2 = new System.Windows.Forms.Label();
            this.finalResultLabel2 = new System.Windows.Forms.Label();
            this.testTable2 = new System.Windows.Forms.TableLayoutPanel();
            this.uncheckAll2 = new System.Windows.Forms.Button();
            this.modelComboBox2 = new System.Windows.Forms.ComboBox();
            this.serialNumber2Box = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // modelComboBox
            // 
            this.modelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(565, 25);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(170, 28);
            this.modelComboBox.TabIndex = 1;
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedModelChanged);
            // 
            // modelLabel
            // 
            this.modelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modelLabel.BackColor = System.Drawing.Color.White;
            this.modelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelLabel.Location = new System.Drawing.Point(565, 2);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(52, 20);
            this.modelLabel.TabIndex = 3;
            this.modelLabel.Text = "Model";
            // 
            // finalResultLabel
            // 
            this.finalResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalResultLabel.BackColor = System.Drawing.Color.White;
            this.finalResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalResultLabel.Location = new System.Drawing.Point(54, 2);
            this.finalResultLabel.Name = "finalResultLabel";
            this.finalResultLabel.Size = new System.Drawing.Size(518, 56);
            this.finalResultLabel.TabIndex = 20;
            this.finalResultLabel.Text = "START";
            this.finalResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(578, 2);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(143, 37);
            this.timerLabel.TabIndex = 20;
            this.timerLabel.Text = "00:00:00";
            // 
            // testTable
            // 
            this.testTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testTable.ColumnCount = 3;
            this.testTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.testTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.testTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.testTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.testTable.Location = new System.Drawing.Point(1, 61);
            this.testTable.Name = "testTable";
            this.testTable.RowCount = 20;
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable.Size = new System.Drawing.Size(715, 553);
            this.testTable.TabIndex = 20;
            // 
            // logs
            // 
            this.logs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs.Location = new System.Drawing.Point(3, 3);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(721, 707);
            this.logs.TabIndex = 20;
            this.logs.Text = "";
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(173, 85);
            this.startButton.TabIndex = 20;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start_button_Click);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(361, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(173, 85);
            this.clearButton.TabIndex = 20;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // serialNumberBox
            // 
            this.serialNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumberBox.Location = new System.Drawing.Point(1, 25);
            this.serialNumberBox.Name = "serialNumberBox";
            this.serialNumberBox.Size = new System.Drawing.Size(160, 28);
            this.serialNumberBox.TabIndex = 0;
            this.serialNumberBox.Text = "";
            this.serialNumberBox.TextChanged += new System.EventHandler(this.serialNumberChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Serial Number";
            // 
            // detamperButton
            // 
            this.detamperButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detamperButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detamperButton.Location = new System.Drawing.Point(540, 3);
            this.detamperButton.Name = "detamperButton";
            this.detamperButton.Size = new System.Drawing.Size(173, 85);
            this.detamperButton.TabIndex = 20;
            this.detamperButton.Text = "Detamper";
            this.detamperButton.UseVisualStyleBackColor = true;
            this.detamperButton.Click += new System.EventHandler(this.detamperButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(182, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(173, 85);
            this.stopButton.TabIndex = 20;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // checkAll
            // 
            this.checkAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAll.Location = new System.Drawing.Point(3, 2);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(45, 25);
            this.checkAll.TabIndex = 20;
            this.checkAll.UseVisualStyleBackColor = false;
            this.checkAll.Click += new System.EventHandler(this.checkAll_Click);
            // 
            // uncheckAll
            // 
            this.uncheckAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.uncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uncheckAll.Location = new System.Drawing.Point(3, 33);
            this.uncheckAll.Name = "uncheckAll";
            this.uncheckAll.Size = new System.Drawing.Size(45, 25);
            this.uncheckAll.TabIndex = 20;
            this.uncheckAll.UseVisualStyleBackColor = false;
            this.uncheckAll.Click += new System.EventHandler(this.uncheckAll_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(667, 2);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(66, 13);
            this.versionLabel.TabIndex = 17;
            this.versionLabel.Text = "version label";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.detamperButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.stopButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 620);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 91);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkAll);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.timerLabel);
            this.panel2.Controls.Add(this.finalResultLabel);
            this.panel2.Controls.Add(this.testTable);
            this.panel2.Controls.Add(this.uncheckAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(721, 713);
            this.panel2.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 745);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 719);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Testing Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.logs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 713);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logs2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 713);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Testing Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // logs2
            // 
            this.logs2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logs2.Location = new System.Drawing.Point(3, 3);
            this.logs2.Name = "logs2";
            this.logs2.Size = new System.Drawing.Size(722, 707);
            this.logs2.TabIndex = 20;
            this.logs2.Text = "";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(736, 745);
            this.tabControl2.TabIndex = 31;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(728, 719);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Testing Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkAll2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.timerLabel2);
            this.panel1.Controls.Add(this.finalResultLabel2);
            this.panel1.Controls.Add(this.testTable2);
            this.panel1.Controls.Add(this.uncheckAll2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 713);
            this.panel1.TabIndex = 24;
            // 
            // checkAll2
            // 
            this.checkAll2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAll2.Location = new System.Drawing.Point(3, 2);
            this.checkAll2.Name = "checkAll2";
            this.checkAll2.Size = new System.Drawing.Size(45, 25);
            this.checkAll2.TabIndex = 20;
            this.checkAll2.UseVisualStyleBackColor = false;
            this.checkAll2.Click += new System.EventHandler(this.checkAll_Click2);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.detamperButton2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.startButton2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.clearButton2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.stopButton2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 620);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(715, 91);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // detamperButton2
            // 
            this.detamperButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detamperButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detamperButton2.Location = new System.Drawing.Point(537, 3);
            this.detamperButton2.Name = "detamperButton2";
            this.detamperButton2.Size = new System.Drawing.Size(175, 85);
            this.detamperButton2.TabIndex = 20;
            this.detamperButton2.Text = "Detamper";
            this.detamperButton2.UseVisualStyleBackColor = true;
            this.detamperButton2.Click += new System.EventHandler(this.detamperButton_Click2);
            // 
            // startButton2
            // 
            this.startButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton2.Enabled = false;
            this.startButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton2.Location = new System.Drawing.Point(3, 3);
            this.startButton2.Name = "startButton2";
            this.startButton2.Size = new System.Drawing.Size(172, 85);
            this.startButton2.TabIndex = 20;
            this.startButton2.Text = "Start";
            this.startButton2.UseVisualStyleBackColor = true;
            this.startButton2.Click += new System.EventHandler(this.start_button_Click2);
            // 
            // clearButton2
            // 
            this.clearButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton2.Location = new System.Drawing.Point(359, 3);
            this.clearButton2.Name = "clearButton2";
            this.clearButton2.Size = new System.Drawing.Size(172, 85);
            this.clearButton2.TabIndex = 20;
            this.clearButton2.Text = "Clear";
            this.clearButton2.UseVisualStyleBackColor = true;
            this.clearButton2.Click += new System.EventHandler(this.clear_button_Click2);
            // 
            // stopButton2
            // 
            this.stopButton2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stopButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton2.Enabled = false;
            this.stopButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton2.Location = new System.Drawing.Point(181, 3);
            this.stopButton2.Name = "stopButton2";
            this.stopButton2.Size = new System.Drawing.Size(172, 85);
            this.stopButton2.TabIndex = 20;
            this.stopButton2.Text = "Stop";
            this.stopButton2.UseVisualStyleBackColor = false;
            this.stopButton2.Click += new System.EventHandler(this.stopButton_Click2);
            // 
            // timerLabel2
            // 
            this.timerLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLabel2.AutoSize = true;
            this.timerLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel2.Location = new System.Drawing.Point(579, 2);
            this.timerLabel2.Name = "timerLabel2";
            this.timerLabel2.Size = new System.Drawing.Size(143, 37);
            this.timerLabel2.TabIndex = 20;
            this.timerLabel2.Text = "00:00:00";
            // 
            // finalResultLabel2
            // 
            this.finalResultLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalResultLabel2.BackColor = System.Drawing.Color.White;
            this.finalResultLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalResultLabel2.Location = new System.Drawing.Point(54, 2);
            this.finalResultLabel2.Name = "finalResultLabel2";
            this.finalResultLabel2.Size = new System.Drawing.Size(519, 56);
            this.finalResultLabel2.TabIndex = 20;
            this.finalResultLabel2.Text = "START";
            this.finalResultLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testTable2
            // 
            this.testTable2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testTable2.ColumnCount = 3;
            this.testTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.testTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.testTable2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.testTable2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.testTable2.Location = new System.Drawing.Point(1, 61);
            this.testTable2.Name = "testTable2";
            this.testTable2.RowCount = 20;
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.testTable2.Size = new System.Drawing.Size(716, 553);
            this.testTable2.TabIndex = 20;
            // 
            // uncheckAll2
            // 
            this.uncheckAll2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.uncheckAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uncheckAll2.Location = new System.Drawing.Point(3, 33);
            this.uncheckAll2.Name = "uncheckAll2";
            this.uncheckAll2.Size = new System.Drawing.Size(45, 25);
            this.uncheckAll2.TabIndex = 20;
            this.uncheckAll2.UseVisualStyleBackColor = false;
            this.uncheckAll2.Click += new System.EventHandler(this.uncheckAll_Click2);
            // 
            // modelComboBox2
            // 
            this.modelComboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modelComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelComboBox2.FormattingEnabled = true;
            this.modelComboBox2.Location = new System.Drawing.Point(566, 25);
            this.modelComboBox2.Name = "modelComboBox2";
            this.modelComboBox2.Size = new System.Drawing.Size(170, 28);
            this.modelComboBox2.TabIndex = 27;
            this.modelComboBox2.SelectedIndexChanged += new System.EventHandler(this.selectedModel2Changed);
            // 
            // serialNumber2Box
            // 
            this.serialNumber2Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber2Box.Location = new System.Drawing.Point(0, 25);
            this.serialNumber2Box.Name = "serialNumber2Box";
            this.serialNumber2Box.Size = new System.Drawing.Size(160, 28);
            this.serialNumber2Box.TabIndex = 26;
            this.serialNumber2Box.Text = "";
            this.serialNumber2Box.TextChanged += new System.EventHandler(this.serialNumber2Changed);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(566, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Model";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Serial Number";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.398274F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.60172F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1483, 811);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(744, 63);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(736, 745);
            this.panel6.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(735, 745);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.serialNumber2Box);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.modelComboBox2);
            this.panel4.Controls.Add(this.versionLabel);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(744, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(736, 54);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.serialNumberBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.modelComboBox);
            this.panel3.Controls.Add(this.modelLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(735, 54);
            this.panel3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 811);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(-10, 0);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verifone MX9";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public ComboBox modelComboBox;
        public Label modelLabel;
        public Label finalResultLabel;
        public Label timerLabel;
        public TableLayoutPanel testTable;
        public RichTextBox logs;
        private Button startButton;
        private Button clearButton;
        private RichTextBox serialNumberBox;
        public Label label1;
        private Button detamperButton;
        private Button stopButton;
        private Button checkAll;
        private Button uncheckAll;
        private Label versionLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        public RichTextBox logs2;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private Panel panel1;
        private Button checkAll2;
        private TableLayoutPanel tableLayoutPanel2;
        private Button detamperButton2;
        private Button startButton2;
        private Button clearButton2;
        private Button stopButton2;
        public Label timerLabel2;
        public Label finalResultLabel2;
        public TableLayoutPanel testTable2;
        private Button uncheckAll2;
        public ComboBox modelComboBox2;
        private RichTextBox serialNumber2Box;
        public Label label5;
        public Label label6;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;

        #endregion


        /*
        //functions-------------------------------------------------------------------------------------------
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




        //this method add borders to the table
        private void tableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            Rectangle r = e.CellBounds;
            //e.Graphics.DrawLine(Pens.Black, e.CellBounds.Location, new Point(e.CellBounds.Right, e.CellBounds.Top));
            ControlPaint.DrawBorder(e.Graphics, r, Color.Black, ButtonBorderStyle.Inset);
        }


        public void build_table(TableLayoutPanel table, string[] tests)
        {
            for (int i = 0; i < tests.Length+1; i++)//row
            {
                for (int j = 0; j < 2; j++)//column
                {
                    
                    
                    Panel p = new Panel();
                    p.Margin = new Padding(1);
                    p.Size = new Size(Convert.ToInt32(screen.Width * .3), 30);
                    p.BackColor = Color.White;
                    table.Controls.Add(p, j, i);


                    //add the labels
                    if (i > 0 && j == 0)
                    {
                        Label l = new Label();
                        l.Size = new Size(Convert.ToInt32(screen.Width * .3), 30);
                        l.Text = tests[i - 1];
                        l.BackColor = Color.CadetBlue;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Font = new Font("Arial", 15, FontStyle.Bold);

                        table.GetControlFromPosition(0, i).Controls.Add(l);
                    }
                    else if(i > 0 && j  > 0)
                    {
                        Label l = new Label();
                        l.Size = new Size(Convert.ToInt32(screen.Width * .3), 30);
                        l.Text = "";
                        l.BackColor = Color.White;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        l.Font = new Font("Arial", 15, FontStyle.Bold);

                        table.GetControlFromPosition(j, i).Controls.Add(l);
                    }
                    
                }
            }

            //add titles
            Label test_column = new Label();
            test_column.Size = new Size(Convert.ToInt32(screen.Width * .3), 30);
            test_column.Text = "Tests";
            test_column.BackColor = Color.CadetBlue;
            test_column.TextAlign = ContentAlignment.MiddleCenter;
            test_column.Font = new Font("Arial", 20, FontStyle.Bold);

            table.GetControlFromPosition(0, 0).Controls.Add(test_column);

            Label test_results = new Label();
            test_results.Size = new Size(Convert.ToInt32(screen.Width * .3), 30);
            test_results.Text = "Results";
            test_results.BackColor = Color.CadetBlue;
            test_results.TextAlign = ContentAlignment.MiddleCenter;
            test_results.Font = new Font("Arial", 20, FontStyle.Bold);

            table.GetControlFromPosition(1, 0).Controls.Add(test_results);

        }
        */


    }
}

