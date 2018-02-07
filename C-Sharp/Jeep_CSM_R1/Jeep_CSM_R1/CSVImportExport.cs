using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Utility;

namespace Jeep_CSM_R1
{
    public partial class CSVImportExport : Form
    {
        public struct badreadrec
        {
            public UInt32 pos;
            public String val;
        }

        public struct engineDataRecord
        {
            public DateTime timeStamp;
            public Int16 data;
        }

        CsvFile _dataFile = new CsvFile();

        List<badreadrec> BadRecs = new List<badreadrec>();


        //List<System.IO.FileInfo> LBFiles = new List<System.IO.FileInfo>();
        //BindingSource bs = new BindingSource();

        List<engineDataRecord> rawEngineData = new List<engineDataRecord>();
        UInt16 ShortFrameErrors = 0;    //A short frame is one in which a new start of frame was
                                        //received before the current frame was finished (data likely dropped)
        UInt16 BadFrameErrors = 0;      //A bad frame is one where there was bad data


        public CSVImportExport()
        {
            InitializeComponent();
        }

        private void CSVImportExport_Load(object sender, EventArgs e)
        {
            lbCSVFiles.DisplayMember = "Name";

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            dlgSelectCSVFile.Multiselect = true;
            dlgSelectCSVFile.DefaultExt = ".csv";
            dlgSelectCSVFile.Filter = "CSV Files (*.csv)|*.csv";
            if (dlgSelectCSVFile.ShowDialog() == DialogResult.OK)
            {
                // foreach (String file in dlgSelectCSVFile.FileNames)
                // {
                //     lbCSVFiles.Items.Add(file);
                // }
                PopulateFiles(dlgSelectCSVFile.FileNames);
            }
        }


        private void PopulateFiles(string [] filesToAdd)
        {
           
            foreach (string file in filesToAdd)
            {
                System.IO.FileInfo f = new System.IO.FileInfo(file);
               // LBFiles.Add(f);
                lbCSVFiles.Items.Add(f);

            }
            //bs.DataSource = LBFiles;
            //lbCSVFiles.DataSource = bs;
           

        }


        private void lbCSVFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lbCSVFiles.SelectedIndex >= 0)
                {
                    //FileInfo f = (FileInfo)lbCSVFiles.Items[lbCSVFiles.SelectedIndex];
                    //LBFiles.Remove(f);

                    lbCSVFiles.Items.RemoveAt(lbCSVFiles.SelectedIndex);
                }
            }
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnConvert_Click(object sender, EventArgs e)
        {
            //For each file in the LB do this
            foreach (FileInfo FN in lbCSVFiles.Items)
            {
                ReadCSVFile(FN.FullName, ref rawEngineData, true, ref BadRecs);
            }
            //Finish by doing this
            SaveparsedCSVFile();
        }

        private void label1_Click(object sender,EventArgs e)
        {

        }


        private void SaveparsedCSVFile()
        {
            List<ECUData> ECUDataRecords = new List<ECUData>();
            DialogResult result = dlgCSVSave.ShowDialog();
            JeepECUData ecu = new JeepECUData();
            if (result == DialogResult.OK)
            {
                //parse all data from raw Readings into Data Frames
                //Parse Data One Byte at a time into frames
                for (int x = 0; x < rawEngineData.Count; x++)
                {
                    ecu.ReceiveDataFrame(rawEngineData[x].data);
                    if (ecu.bufferError == 1)
                        ++BadFrameErrors;

                    if (ecu.FrameCompleteFlag)
                    {
                        //Note Reading the frame Buffer resets the complete flag and allows parsing
                        //to continue
                        ECUData rec = ecu.ParseFrame(ecu.frameBuffer);
                        if (ecu.bufferCount >= 27)
                        {
                            //Get a date/time stamp for this
                            //use last byte in frame.  Add to recors and
                            //save the record
                            rec.LogTime = rawEngineData[x].timeStamp;
                            ECUDataRecords.Add(rec);
                        }
                        else
                        {
                            ++ShortFrameErrors;
                        }

                    }
                }

                JeepECUData.SaveECUData(dlgCSVSave.FileName, ECUDataRecords);
            }
        }

        

        /// <summary>
        /// Reads the CSV data from the SaleaeLogic protocal export file and puts it into 
        /// A single List of Byte values that indicate the ECU output.  If append is true, then
        /// the OutputData List will be appended with the data, if false, then it will be
        /// overwritten.  Passes bask variable indicating how many bad records were encountered
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public static Boolean ReadCSVFile(String fName, ref List<engineDataRecord> OutputData, Boolean append, ref List<badreadrec> BadReads)
        {
            DataTable DT;
            //List<Byte> runData = new List<byte>();
            CsvReader reader = new CsvReader(fName);

            if (append == false)
            {
                OutputData.Clear();
            }

            DT = reader.ReadIntoDataTable();
            UInt32 pos = 1;
            foreach (DataRow row in DT.Rows)
            {
                //Read in the Value and convert
                engineDataRecord rec = new engineDataRecord();
                try
                {
                     string s = (string)row[2];  //Get Data Value
                    rec.data = Int16.Parse(s);

                    s = (string)row[0]; //Get timestamp
                                        //Timestamp is in seconds
                    Double dtime = Double.Parse(s);
                    DateTime date1 = new DateTime(2000, 1, 1, 0, 0, 0);
                    date1 = date1.AddSeconds(dtime);
                    rec.timeStamp = date1;
                    OutputData.Add(rec);
                }
                catch (FormatException e)
                {
                    rec.data = -1;
                    rec.timeStamp = DateTime.Now;
                    OutputData.Add(rec); //This indicates a bad read.  Data is normally Byte data.  We read as Int16
                                        //So bad data can be flagged and entire record removed
                    badreadrec brr;
                    brr.pos = pos;
                    brr.val = (string)row[2];
                    BadReads.Add(brr);
                    Console.WriteLine(e.Message);
                }
                ++pos;
            }

            return true;
        }



    }
}
