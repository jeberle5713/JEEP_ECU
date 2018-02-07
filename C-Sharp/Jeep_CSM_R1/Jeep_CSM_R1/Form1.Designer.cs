namespace Jeep_CSM_R1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.gbECUConnect = new System.Windows.Forms.GroupBox();
            this.cbConnect = new System.Windows.Forms.CheckBox();
            this.nudUpdateRate = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblCurrentGateWay = new System.Windows.Forms.Label();
            this.lblConnecState = new System.Windows.Forms.Label();
            this.gbLogging = new System.Windows.Forms.GroupBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.cbLog = new System.Windows.Forms.CheckBox();
            this.gbECUData = new System.Windows.Forms.GroupBox();
            this.lblACClutch = new System.Windows.Forms.Label();
            this.lblACRequest = new System.Windows.Forms.Label();
            this.lblACSwitch = new System.Windows.Forms.Label();
            this.lblEGR = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLogTime = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.lblProgramVersion = new System.Windows.Forms.Label();
            this.lblInjPulse = new System.Windows.Forms.Label();
            this.lblFuelMix = new System.Windows.Forms.Label();
            this.lblLoopExhaust = new System.Windows.Forms.Label();
            this.lblPromVersion = new System.Windows.Forms.Label();
            this.lblInitialMAP = new System.Windows.Forms.Label();
            this.lblECUMode = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVacHg = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSparkAdv = new System.Windows.Forms.Label();
            this.lblKnock = new System.Windows.Forms.Label();
            this.lblMapRaw = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLTFuel = new System.Windows.Forms.Label();
            this.lblTPS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSTFuel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCTSRaw = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFuelSync = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIAT = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblVolts = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblO2 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblRPM = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusInfo = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatLblSuccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialogLogging = new System.Windows.Forms.SaveFileDialog();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblbadFrames = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.gbECUConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateRate)).BeginInit();
            this.gbLogging.SuspendLayout();
            this.gbECUData.SuspendLayout();
            this.statusInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cSVIOToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // cSVIOToolStripMenuItem
            // 
            this.cSVIOToolStripMenuItem.Name = "cSVIOToolStripMenuItem";
            this.cSVIOToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.cSVIOToolStripMenuItem.Text = "CSV I/O";
            this.cSVIOToolStripMenuItem.Click += new System.EventHandler(this.cSVIOToolStripMenuItem_Click);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 24);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.gbECUConnect);
            this.splitMain.Panel1.Controls.Add(this.gbLogging);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.gbECUData);
            this.splitMain.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitMain_Panel2_Paint);
            this.splitMain.Size = new System.Drawing.Size(794, 421);
            this.splitMain.SplitterDistance = 268;
            this.splitMain.TabIndex = 4;
            // 
            // gbECUConnect
            // 
            this.gbECUConnect.Controls.Add(this.cbConnect);
            this.gbECUConnect.Controls.Add(this.nudUpdateRate);
            this.gbECUConnect.Controls.Add(this.label27);
            this.gbECUConnect.Controls.Add(this.lblUpdate);
            this.gbECUConnect.Controls.Add(this.lblCurrentGateWay);
            this.gbECUConnect.Controls.Add(this.lblConnecState);
            this.gbECUConnect.Location = new System.Drawing.Point(12, 33);
            this.gbECUConnect.Name = "gbECUConnect";
            this.gbECUConnect.Size = new System.Drawing.Size(200, 137);
            this.gbECUConnect.TabIndex = 52;
            this.gbECUConnect.TabStop = false;
            this.gbECUConnect.Text = "ECU Connection";
            // 
            // cbConnect
            // 
            this.cbConnect.AutoSize = true;
            this.cbConnect.Location = new System.Drawing.Point(11, 39);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(66, 17);
            this.cbConnect.TabIndex = 0;
            this.cbConnect.Text = "Connect";
            this.cbConnect.UseVisualStyleBackColor = true;
            this.cbConnect.CheckedChanged += new System.EventHandler(this.cbConnect_CheckedChanged);
            // 
            // nudUpdateRate
            // 
            this.nudUpdateRate.DecimalPlaces = 1;
            this.nudUpdateRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudUpdateRate.Location = new System.Drawing.Point(96, 91);
            this.nudUpdateRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateRate.Name = "nudUpdateRate";
            this.nudUpdateRate.Size = new System.Drawing.Size(65, 20);
            this.nudUpdateRate.TabIndex = 0;
            this.nudUpdateRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateRate.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.DarkBlue;
            this.label27.Location = new System.Drawing.Point(10, 66);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 13);
            this.label27.TabIndex = 53;
            this.label27.Text = "Gateway Address:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblUpdate.Location = new System.Drawing.Point(8, 94);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(82, 13);
            this.lblUpdate.TabIndex = 0;
            this.lblUpdate.Text = "Update Rate (s)";
            // 
            // lblCurrentGateWay
            // 
            this.lblCurrentGateWay.AutoSize = true;
            this.lblCurrentGateWay.Location = new System.Drawing.Point(109, 65);
            this.lblCurrentGateWay.Name = "lblCurrentGateWay";
            this.lblCurrentGateWay.Size = new System.Drawing.Size(22, 13);
            this.lblCurrentGateWay.TabIndex = 52;
            this.lblCurrentGateWay.Text = "NA";
            // 
            // lblConnecState
            // 
            this.lblConnecState.AutoSize = true;
            this.lblConnecState.Location = new System.Drawing.Point(93, 39);
            this.lblConnecState.Name = "lblConnecState";
            this.lblConnecState.Size = new System.Drawing.Size(35, 13);
            this.lblConnecState.TabIndex = 10;
            this.lblConnecState.Text = "label6";
            // 
            // gbLogging
            // 
            this.gbLogging.Controls.Add(this.btnSaveLog);
            this.gbLogging.Controls.Add(this.cbLog);
            this.gbLogging.Location = new System.Drawing.Point(12, 186);
            this.gbLogging.Name = "gbLogging";
            this.gbLogging.Size = new System.Drawing.Size(200, 149);
            this.gbLogging.TabIndex = 52;
            this.gbLogging.TabStop = false;
            this.gbLogging.Text = "Data Logging";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(7, 67);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLog.TabIndex = 52;
            this.btnSaveLog.Text = "Save";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // cbLog
            // 
            this.cbLog.AutoSize = true;
            this.cbLog.CausesValidation = false;
            this.cbLog.Location = new System.Drawing.Point(7, 35);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(70, 17);
            this.cbLog.TabIndex = 1;
            this.cbLog.Text = "Log Data";
            this.cbLog.UseVisualStyleBackColor = true;
            this.cbLog.CheckedChanged += new System.EventHandler(this.cbLog_CheckedChanged);
            // 
            // gbECUData
            // 
            this.gbECUData.Controls.Add(this.label3);
            this.gbECUData.Controls.Add(this.lblbadFrames);
            this.gbECUData.Controls.Add(this.lblACClutch);
            this.gbECUData.Controls.Add(this.lblACRequest);
            this.gbECUData.Controls.Add(this.lblACSwitch);
            this.gbECUData.Controls.Add(this.lblEGR);
            this.gbECUData.Controls.Add(this.label22);
            this.gbECUData.Controls.Add(this.label18);
            this.gbECUData.Controls.Add(this.label13);
            this.gbECUData.Controls.Add(this.label11);
            this.gbECUData.Controls.Add(this.lblLogTime);
            this.gbECUData.Controls.Add(this.label28);
            this.gbECUData.Controls.Add(this.label1);
            this.gbECUData.Controls.Add(this.lblThrottle);
            this.gbECUData.Controls.Add(this.lblProgramVersion);
            this.gbECUData.Controls.Add(this.lblInjPulse);
            this.gbECUData.Controls.Add(this.lblFuelMix);
            this.gbECUData.Controls.Add(this.lblLoopExhaust);
            this.gbECUData.Controls.Add(this.lblPromVersion);
            this.gbECUData.Controls.Add(this.lblInitialMAP);
            this.gbECUData.Controls.Add(this.lblECUMode);
            this.gbECUData.Controls.Add(this.label26);
            this.gbECUData.Controls.Add(this.label2);
            this.gbECUData.Controls.Add(this.label16);
            this.gbECUData.Controls.Add(this.lblVacHg);
            this.gbECUData.Controls.Add(this.label15);
            this.gbECUData.Controls.Add(this.label14);
            this.gbECUData.Controls.Add(this.lblSparkAdv);
            this.gbECUData.Controls.Add(this.lblKnock);
            this.gbECUData.Controls.Add(this.lblMapRaw);
            this.gbECUData.Controls.Add(this.label12);
            this.gbECUData.Controls.Add(this.lblLTFuel);
            this.gbECUData.Controls.Add(this.lblTPS);
            this.gbECUData.Controls.Add(this.label4);
            this.gbECUData.Controls.Add(this.lblSTFuel);
            this.gbECUData.Controls.Add(this.label10);
            this.gbECUData.Controls.Add(this.lblCTSRaw);
            this.gbECUData.Controls.Add(this.label5);
            this.gbECUData.Controls.Add(this.lblFuelSync);
            this.gbECUData.Controls.Add(this.label6);
            this.gbECUData.Controls.Add(this.label7);
            this.gbECUData.Controls.Add(this.label8);
            this.gbECUData.Controls.Add(this.label9);
            this.gbECUData.Controls.Add(this.lblIAT);
            this.gbECUData.Controls.Add(this.label25);
            this.gbECUData.Controls.Add(this.lblVolts);
            this.gbECUData.Controls.Add(this.label24);
            this.gbECUData.Controls.Add(this.lblO2);
            this.gbECUData.Controls.Add(this.label23);
            this.gbECUData.Controls.Add(this.lblRPM);
            this.gbECUData.Controls.Add(this.label17);
            this.gbECUData.Controls.Add(this.label21);
            this.gbECUData.Controls.Add(this.label20);
            this.gbECUData.Controls.Add(this.label19);
            this.gbECUData.Location = new System.Drawing.Point(24, 35);
            this.gbECUData.Name = "gbECUData";
            this.gbECUData.Size = new System.Drawing.Size(464, 355);
            this.gbECUData.TabIndex = 52;
            this.gbECUData.TabStop = false;
            this.gbECUData.Text = "ECU Data";
            // 
            // lblACClutch
            // 
            this.lblACClutch.AutoSize = true;
            this.lblACClutch.Location = new System.Drawing.Point(378, 287);
            this.lblACClutch.Name = "lblACClutch";
            this.lblACClutch.Size = new System.Drawing.Size(22, 13);
            this.lblACClutch.TabIndex = 61;
            this.lblACClutch.Text = "NA";
            // 
            // lblACRequest
            // 
            this.lblACRequest.AutoSize = true;
            this.lblACRequest.Location = new System.Drawing.Point(378, 269);
            this.lblACRequest.Name = "lblACRequest";
            this.lblACRequest.Size = new System.Drawing.Size(22, 13);
            this.lblACRequest.TabIndex = 60;
            this.lblACRequest.Text = "NA";
            // 
            // lblACSwitch
            // 
            this.lblACSwitch.AutoSize = true;
            this.lblACSwitch.Location = new System.Drawing.Point(378, 252);
            this.lblACSwitch.Name = "lblACSwitch";
            this.lblACSwitch.Size = new System.Drawing.Size(22, 13);
            this.lblACSwitch.TabIndex = 59;
            this.lblACSwitch.Text = "NA";
            // 
            // lblEGR
            // 
            this.lblEGR.AutoSize = true;
            this.lblEGR.Location = new System.Drawing.Point(130, 218);
            this.lblEGR.Name = "lblEGR";
            this.lblEGR.Size = new System.Drawing.Size(22, 13);
            this.lblEGR.TabIndex = 58;
            this.lblEGR.Text = "NA";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 218);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 13);
            this.label22.TabIndex = 57;
            this.label22.Text = "EGR";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(245, 287);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 56;
            this.label18.Text = "AC Clutch:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(245, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "AC Switch:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(245, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "AC Request:";
            // 
            // lblLogTime
            // 
            this.lblLogTime.AutoSize = true;
            this.lblLogTime.Location = new System.Drawing.Point(130, 26);
            this.lblLogTime.Name = "lblLogTime";
            this.lblLogTime.Size = new System.Drawing.Size(22, 13);
            this.lblLogTime.TabIndex = 53;
            this.lblLogTime.Text = "NA";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 26);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(33, 13);
            this.label28.TabIndex = 52;
            this.label28.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program Version:";
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(378, 200);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(22, 13);
            this.lblThrottle.TabIndex = 51;
            this.lblThrottle.Text = "NA";
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Location = new System.Drawing.Point(130, 45);
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size(22, 13);
            this.lblProgramVersion.TabIndex = 0;
            this.lblProgramVersion.Text = "NA";
            // 
            // lblInjPulse
            // 
            this.lblInjPulse.AutoSize = true;
            this.lblInjPulse.Location = new System.Drawing.Point(130, 320);
            this.lblInjPulse.Name = "lblInjPulse";
            this.lblInjPulse.Size = new System.Drawing.Size(22, 13);
            this.lblInjPulse.TabIndex = 41;
            this.lblInjPulse.Text = "NA";
            // 
            // lblFuelMix
            // 
            this.lblFuelMix.AutoSize = true;
            this.lblFuelMix.Location = new System.Drawing.Point(378, 178);
            this.lblFuelMix.Name = "lblFuelMix";
            this.lblFuelMix.Size = new System.Drawing.Size(22, 13);
            this.lblFuelMix.TabIndex = 50;
            this.lblFuelMix.Text = "NA";
            // 
            // lblLoopExhaust
            // 
            this.lblLoopExhaust.AutoSize = true;
            this.lblLoopExhaust.Location = new System.Drawing.Point(130, 303);
            this.lblLoopExhaust.Name = "lblLoopExhaust";
            this.lblLoopExhaust.Size = new System.Drawing.Size(22, 13);
            this.lblLoopExhaust.TabIndex = 40;
            this.lblLoopExhaust.Text = "NA";
            // 
            // lblPromVersion
            // 
            this.lblPromVersion.AutoSize = true;
            this.lblPromVersion.Location = new System.Drawing.Point(130, 63);
            this.lblPromVersion.Name = "lblPromVersion";
            this.lblPromVersion.Size = new System.Drawing.Size(22, 13);
            this.lblPromVersion.TabIndex = 2;
            this.lblPromVersion.Text = "NA";
            // 
            // lblInitialMAP
            // 
            this.lblInitialMAP.AutoSize = true;
            this.lblInitialMAP.Location = new System.Drawing.Point(130, 287);
            this.lblInitialMAP.Name = "lblInitialMAP";
            this.lblInitialMAP.Size = new System.Drawing.Size(22, 13);
            this.lblInitialMAP.TabIndex = 39;
            this.lblInitialMAP.Text = "NA";
            // 
            // lblECUMode
            // 
            this.lblECUMode.AutoSize = true;
            this.lblECUMode.Location = new System.Drawing.Point(378, 159);
            this.lblECUMode.Name = "lblECUMode";
            this.lblECUMode.Size = new System.Drawing.Size(22, 13);
            this.lblECUMode.TabIndex = 49;
            this.lblECUMode.Text = "NA";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(245, 200);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 13);
            this.label26.TabIndex = 38;
            this.label26.Text = "Throttle State:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prom Version:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Injection Pulse (ms):";
            // 
            // lblVacHg
            // 
            this.lblVacHg.AutoSize = true;
            this.lblVacHg.Location = new System.Drawing.Point(378, 140);
            this.lblVacHg.Name = "lblVacHg";
            this.lblVacHg.Size = new System.Drawing.Size(22, 13);
            this.lblVacHg.TabIndex = 48;
            this.lblVacHg.Text = "NA";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 303);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Loop Exhaust Status:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 287);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Initial MAP (inHg):";
            // 
            // lblSparkAdv
            // 
            this.lblSparkAdv.AutoSize = true;
            this.lblSparkAdv.Location = new System.Drawing.Point(130, 269);
            this.lblSparkAdv.Name = "lblSparkAdv";
            this.lblSparkAdv.Size = new System.Drawing.Size(22, 13);
            this.lblSparkAdv.TabIndex = 24;
            this.lblSparkAdv.Text = "NA";
            // 
            // lblKnock
            // 
            this.lblKnock.AutoSize = true;
            this.lblKnock.Location = new System.Drawing.Point(378, 102);
            this.lblKnock.Name = "lblKnock";
            this.lblKnock.Size = new System.Drawing.Size(22, 13);
            this.lblKnock.TabIndex = 46;
            this.lblKnock.Text = "NA";
            // 
            // lblMapRaw
            // 
            this.lblMapRaw.AutoSize = true;
            this.lblMapRaw.Location = new System.Drawing.Point(130, 99);
            this.lblMapRaw.Name = "lblMapRaw";
            this.lblMapRaw.Size = new System.Drawing.Size(22, 13);
            this.lblMapRaw.TabIndex = 6;
            this.lblMapRaw.Text = "NA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Throttle Position (%):";
            // 
            // lblLTFuel
            // 
            this.lblLTFuel.AutoSize = true;
            this.lblLTFuel.Location = new System.Drawing.Point(378, 83);
            this.lblLTFuel.Name = "lblLTFuel";
            this.lblLTFuel.Size = new System.Drawing.Size(22, 13);
            this.lblLTFuel.TabIndex = 45;
            this.lblLTFuel.Text = "NA";
            // 
            // lblTPS
            // 
            this.lblTPS.AutoSize = true;
            this.lblTPS.Location = new System.Drawing.Point(130, 252);
            this.lblTPS.Name = "lblTPS";
            this.lblTPS.Size = new System.Drawing.Size(22, 13);
            this.lblTPS.TabIndex = 21;
            this.lblTPS.Text = "NA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "MAP (inHg)";
            // 
            // lblSTFuel
            // 
            this.lblSTFuel.AutoSize = true;
            this.lblSTFuel.Location = new System.Drawing.Point(378, 64);
            this.lblSTFuel.Name = "lblSTFuel";
            this.lblSTFuel.Size = new System.Drawing.Size(22, 13);
            this.lblSTFuel.TabIndex = 44;
            this.lblSTFuel.Text = "NA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Spark Advance (deg):";
            // 
            // lblCTSRaw
            // 
            this.lblCTSRaw.AutoSize = true;
            this.lblCTSRaw.Location = new System.Drawing.Point(130, 121);
            this.lblCTSRaw.Name = "lblCTSRaw";
            this.lblCTSRaw.Size = new System.Drawing.Size(22, 13);
            this.lblCTSRaw.TabIndex = 8;
            this.lblCTSRaw.Text = "NA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Coolant Temp (F):";
            // 
            // lblFuelSync
            // 
            this.lblFuelSync.AutoSize = true;
            this.lblFuelSync.Location = new System.Drawing.Point(378, 26);
            this.lblFuelSync.Name = "lblFuelSync";
            this.lblFuelSync.Size = new System.Drawing.Size(22, 13);
            this.lblFuelSync.TabIndex = 42;
            this.lblFuelSync.Text = "NA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Intake Air Temp (F):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Volts (Vdc)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "RPM:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "O2 (millivolts)";
            // 
            // lblIAT
            // 
            this.lblIAT.AutoSize = true;
            this.lblIAT.Location = new System.Drawing.Point(130, 140);
            this.lblIAT.Name = "lblIAT";
            this.lblIAT.Size = new System.Drawing.Size(22, 13);
            this.lblIAT.TabIndex = 14;
            this.lblIAT.Text = "NA";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(245, 178);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 13);
            this.label25.TabIndex = 37;
            this.label25.Text = "Fuel Mixture:";
            // 
            // lblVolts
            // 
            this.lblVolts.AutoSize = true;
            this.lblVolts.Location = new System.Drawing.Point(130, 159);
            this.lblVolts.Name = "lblVolts";
            this.lblVolts.Size = new System.Drawing.Size(22, 13);
            this.lblVolts.TabIndex = 15;
            this.lblVolts.Text = "NA";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(245, 159);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 36;
            this.label24.Text = "ECU Mode:";
            // 
            // lblO2
            // 
            this.lblO2.AutoSize = true;
            this.lblO2.Location = new System.Drawing.Point(130, 178);
            this.lblO2.Name = "lblO2";
            this.lblO2.Size = new System.Drawing.Size(22, 13);
            this.lblO2.TabIndex = 16;
            this.lblO2.Text = "NA";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(245, 140);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 35;
            this.label23.Text = "Vac (inHg):";
            // 
            // lblRPM
            // 
            this.lblRPM.AutoSize = true;
            this.lblRPM.Location = new System.Drawing.Point(130, 197);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(22, 13);
            this.lblRPM.TabIndex = 17;
            this.lblRPM.Text = "NA";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(245, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "fuel sync:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(245, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 33;
            this.label21.Text = "Knock:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(245, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "Long Term Fuel Trim:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(245, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Short Term Fuel Trim:";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 5000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // statusInfo
            // 
            this.statusInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsStatLblSuccess,
            this.toolStripStatusLabel2});
            this.statusInfo.Location = new System.Drawing.Point(0, 423);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(794, 22);
            this.statusInfo.TabIndex = 5;
            this.statusInfo.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel1.Text = "Successful Reads:";
            // 
            // tsStatLblSuccess
            // 
            this.tsStatLblSuccess.Name = "tsStatLblSuccess";
            this.tsStatLblSuccess.Size = new System.Drawing.Size(118, 17);
            this.tsStatLblSuccess.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel2.Text = "B";
            // 
            // lblbadFrames
            // 
            this.lblbadFrames.AutoSize = true;
            this.lblbadFrames.Location = new System.Drawing.Point(378, 320);
            this.lblbadFrames.Name = "lblbadFrames";
            this.lblbadFrames.Size = new System.Drawing.Size(22, 13);
            this.lblbadFrames.TabIndex = 62;
            this.lblbadFrames.Text = "NA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Bad ECU Reads:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 445);
            this.Controls.Add(this.statusInfo);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Jeep Rennix ECU Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.gbECUConnect.ResumeLayout(false);
            this.gbECUConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateRate)).EndInit();
            this.gbLogging.ResumeLayout(false);
            this.gbLogging.PerformLayout();
            this.gbECUData.ResumeLayout(false);
            this.gbECUData.PerformLayout();
            this.statusInfo.ResumeLayout(false);
            this.statusInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVIOToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.CheckBox cbLog;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.CheckBox cbConnect;
        private System.Windows.Forms.NumericUpDown nudUpdateRate;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPromVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMapRaw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCTSRaw;
        private System.Windows.Forms.Label lblConnecState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblO2;
        private System.Windows.Forms.Label lblVolts;
        private System.Windows.Forms.Label lblIAT;
        private System.Windows.Forms.Label lblRPM;
        private System.Windows.Forms.Label lblTPS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSparkAdv;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblInitialMAP;
        private System.Windows.Forms.Label lblLoopExhaust;
        private System.Windows.Forms.Label lblInjPulse;
        private System.Windows.Forms.Label lblFuelSync;
        private System.Windows.Forms.Label lblSTFuel;
        private System.Windows.Forms.Label lblLTFuel;
        private System.Windows.Forms.Label lblKnock;
        private System.Windows.Forms.Label lblVacHg;
        private System.Windows.Forms.Label lblECUMode;
        private System.Windows.Forms.Label lblFuelMix;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblCurrentGateWay;
        private System.Windows.Forms.StatusStrip statusInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatLblSuccess;
        private System.Windows.Forms.GroupBox gbECUConnect;
        private System.Windows.Forms.GroupBox gbLogging;
        private System.Windows.Forms.GroupBox gbECUData;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLogging;
        private System.Windows.Forms.Label lblLogTime;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblACClutch;
        private System.Windows.Forms.Label lblACRequest;
        private System.Windows.Forms.Label lblACSwitch;
        private System.Windows.Forms.Label lblEGR;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblbadFrames;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

