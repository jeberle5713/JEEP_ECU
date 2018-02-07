using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Http;

using System.Security.Principal;


namespace Jeep_CSM_R1
{
    public partial class Form1 : Form
    {
       
        ECUData ECUVars = new ECUData();    //Hold the latest ECU Variables for display
        public enum ConnectionStateEnums { eDisconnected, eConnecting, eConnected };
        Byte fails = 0;
        CsvFile LogFile = new CsvFile();
        bool needSave = false;
       

        private ConnectionStateEnums _ConnectionState;
        public ConnectionStateEnums ConnectionState {
            get{ return _ConnectionState; }
            private set
            { _ConnectionState = value;
                switch (ConnectionState)
                {
                    case ConnectionStateEnums.eConnected:
                        lblConnecState.Text = "Connected";
                        break;
                    case ConnectionStateEnums.eConnecting:
                        lblConnecState.Text = "Connecting";
                        break;
                    case ConnectionStateEnums.eDisconnected:
                        lblConnecState.Text = "Disconnected";
                        break;
                    default:
                        lblConnecState.Text = "Error";
                        break;
                }
            }
        }

        UInt32 SuccessfulReads = 0;


        public Form1()
        {
            InitializeComponent();
            System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
           
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            IPAddress ip = GetDefaultGateway();
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate {
                    if(ip != null)
                         lblCurrentGateWay.Text = ip.ToString();
                    // load the control with the appropriate data
                }));
                return;
            }

            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cSVIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CSVImportExport dlgSCV = new CSVImportExport())
            {
                dlgSCV.ShowDialog();
            }
        }

       // private UpdateBadReads

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            bool status;
            if (cbConnect.Checked)
            {
                status = JeepECUData.ReadECUData(ref ECUVars,lblCurrentGateWay.Text);
                if (status)
                {
                    ConnectionState = ConnectionStateEnums.eConnected;
                    fails = 0;
                    ++SuccessfulReads;
                    tsStatLblSuccess.Text = SuccessfulReads.ToString();
                    ECUVars.LogTime = DateTime.Now;     //Timestamp record
                    //Handle Logging
                    if(cbLog.Checked)
                    {
                        CsvRecord cr = new CsvRecord();               //Get a new CSV Record
                        List<String> dataStringList = ECUVars.GetDataValueStringList();
                        foreach (String item in dataStringList)
                        {
                            cr.Fields.Add(item);
                        }
                        LogFile.Records.Add(cr);
                        needSave = true;
                    }
                }
                else
                {
                    ConnectionState = ConnectionStateEnums.eConnecting;
                    ++fails;
                    if(fails > 5)
                    {
                        
                        status = CheckConnection(lblCurrentGateWay.Text);
                        if (!status)
                        {
                            tmrUpdate.Enabled = false;  //Disable timer since it runs asynchroniously and will continue to run this
                                                        //method while MessageBox is up.
                            MessageBox.Show("Lost Connection. Still Connected to SSID RenixECU?", "Error", MessageBoxButtons.OK);
                            cbConnect.Checked = false;
                        }

                    }
                }

            }
        }

        private void cbConnect_CheckedChanged(object sender, EventArgs e)
        {
            if(cbConnect.Checked )
            {
               
                ConnectionState = ConnectionStateEnums.eConnecting;
                bool status = CheckConnection(lblCurrentGateWay.Text);
                if(!status)
                {
                    MessageBox.Show("Connection Failed.  Ensure you're connected to SSID RenixECU.", "Error", MessageBoxButtons.OK);
                    cbConnect.Checked = false;
                }
                else
                    tmrUpdate.Enabled = true;
            }
            else
            {
                tmrUpdate.Enabled = false;
                ConnectionState = ConnectionStateEnums.eDisconnected;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionState = ConnectionStateEnums.eDisconnected;
            lblProgramVersion.DataBindings.Add(new Binding("Text", ECUVars, "sProgramVersion"));
            lblPromVersion.DataBindings.Add(new Binding("Text", ECUVars, "sPromVersion"));
            //lblCalibrationCode.DataBindings.Add(new Binding("Text", ECUVars, "sCalibrationCode"));

            lblACRequest.DataBindings.Add(new Binding("Text", ECUVars, "sACRequest"));

            lblMapRaw.DataBindings.Add(new Binding("Text", ECUVars, "sMAP"));
            lblCTSRaw.DataBindings.Add(new Binding("Text", ECUVars, "sCTS"));
            lblIAT.DataBindings.Add(new Binding("Text", ECUVars, "sIAT"));
            lblVolts.DataBindings.Add(new Binding("Text", ECUVars, "sVolts"));
            lblO2.DataBindings.Add(new Binding("Text", ECUVars, "sLambda"));
            lblRPM.DataBindings.Add(new Binding("Text", ECUVars, "sRPM"));
            
            lblTPS.DataBindings.Add(new Binding("Text", ECUVars, "sTPS"));
            lblSparkAdv.DataBindings.Add(new Binding("Text", ECUVars, "sSparkAdvance"));
            lblInitialMAP.DataBindings.Add(new Binding("Text", ECUVars, "sInitialMAP"));
            lblLoopExhaust.DataBindings.Add(new Binding("Text", ECUVars, "sLoopStatusExhaust"));
            lblInjPulse.DataBindings.Add(new Binding("Text", ECUVars, "sInjPulseMs"));
            lblFuelSync.DataBindings.Add(new Binding("Text", ECUVars, "sfuelsync"));
           
            lblSTFuel.DataBindings.Add(new Binding("Text", ECUVars, "sSTFuelTrim"));
            lblLTFuel.DataBindings.Add(new Binding("Text", ECUVars, "sLTFuelTrim"));
            lblKnock.DataBindings.Add(new Binding("Text", ECUVars, "sKnock"));
           
            lblVacHg.DataBindings.Add(new Binding("Text", ECUVars, "sVacHg"));
            lblECUMode.DataBindings.Add(new Binding("Text", ECUVars, "ECUMode"));
            lblFuelMix.DataBindings.Add(new Binding("Text", ECUVars, "O2State"));
            lblThrottle.DataBindings.Add(new Binding("Text", ECUVars, "ThrottlePos"));
            lblLogTime.DataBindings.Add(new Binding("Text", ECUVars, "sLogTime"));

            lblACClutch.DataBindings.Add(new Binding("Text", ECUVars, "ACClutch"));
         
            lblACSwitch.DataBindings.Add(new Binding("Text", ECUVars, "ACState"));
            lblEGR.DataBindings.Add(new Binding("Text", ECUVars, "EGR"));

            lblbadFrames.DataBindings.Add(new Binding("Text", ECUVars, "sBadFrames"));

            IPAddress ip = GetDefaultGateway();
            lblCurrentGateWay.Text = ip.ToString();
            tmrUpdate.Interval = 5000;
            nudUpdateRate.Value = 5;

            tsStatLblSuccess.Text = SuccessfulReads.ToString();
        }

       
        public static IPAddress GetDefaultGateway()
        {
            
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }


        public static bool CheckConnection(String url)
        {
            HttpClient client = new HttpClient();
            bool retval = false;
            url = "http://" + url + "/checkconnection";
            try
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result == null)
                        retval = false;
                    else if (result == "")
                        retval = false;
                    else if(result == "Jeep ECU Reader Connected!")
                        retval = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retval;
        }



        private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tmrUpdate.Interval = (int)(1000 * nudUpdateRate.Value);
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            SaveLogFile();
        }

        private void SaveLogFile()
        {
            DialogResult result;
            bool bAppend = false; ;

            saveFileDialogLogging.AddExtension = true;
            saveFileDialogLogging.DefaultExt = "csv";
            saveFileDialogLogging.OverwritePrompt = false;
            if (saveFileDialogLogging.ShowDialog() != DialogResult.OK)
                return;
            String fname = saveFileDialogLogging.FileName;


            if ((System.IO.File.Exists(fname)))
            {
                result = MessageBox.Show("File Exists - Append to Existing file?", "File Check", MessageBoxButtons.YesNoCancel);
                switch(result)
                {
                    case DialogResult.Yes:
                        bAppend = true;
                        break;
                    case DialogResult.No:
                        bAppend = false;
                        break;
                    default:
                        return;
                        break;
                }
            }

            //If time to write the CSV file
            LogFile.Headers.Clear();
            List<String> dataNameList = ECUData.GetDataValueNameList();
            foreach (String s in dataNameList)
            {
                LogFile.Headers.Add(s);
            }
            CsvWriter cw = new CsvWriter();
            cw.WriteCsv(LogFile, fname, Encoding.ASCII, bAppend); //Write The CSV File
            needSave = false;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(needSave)
            {
                DialogResult result = MessageBox.Show("Save Logging File?", "Application Closing", MessageBoxButtons.YesNoCancel);
                switch(result)
                {
                    case DialogResult.Yes:
                        SaveLogFile();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void cbLog_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
