using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//Uses JSON.NET package from Newtonsoft (installed via Nu-Get package manager)
//see https://www.newtonsoft.com/json/help for help


namespace Jeep_CSM_R1
{
    [Serializable]
    public class ECUData : INotifyPropertyChanged
    {

        //DateTime currTime = DateTime.Now;
        //StringList.Add(currTime.ToString("HH:mm:ss.ff"));      //Start w/  timestamp
        //    sLogTime

        private DateTime _LogTime = DateTime.Now;
        public DateTime LogTime
        {
            get { return _LogTime; }
            set
            {
                SetField(ref _LogTime, value);
                sLogTime = value.ToString("HH:mm:ss.ff");
            }
        }
        private String _sLogTime;
        public String sLogTime
        {
            get { return _sLogTime; }
            private set { SetField(ref _sLogTime, value); }
        }


        private Byte _ProgramVersion;
        public Byte ProgramVersion
        {
            get { return _ProgramVersion; }
            set { SetField(ref _ProgramVersion, value);
                sProgramVersion = value.ToString();
            }
        }
        private String _sProgramVersion;
        public String sProgramVersion
        {
            get { return _sProgramVersion; }
            private set { SetField(ref _sProgramVersion, value); }
        }


        private Byte _PromVersion;
        public Byte PromVersion
        {
            get { return _PromVersion; }
            set { SetField(ref _PromVersion, value);
                sPromVersion = value.ToString();
            }
        }
        private String _sPromVersion;
        public String sPromVersion
        {
            get { return _sPromVersion; }
            private set { SetField(ref _sPromVersion, value); }
        }


        //private Byte _CalibrationCode;
        //public Byte CalibrationCode
        //{
        //    get { return _CalibrationCode; }
        //    set { SetField(ref _CalibrationCode, value);
        //        _sCalibrationCode = value.ToString();
        //    }
        //}
        //private String _sCalibrationCode;
        //public String sCalibrationCode
       // {
       //     get { return _sCalibrationCode; }
       //     private set { SetField(ref _sCalibrationCode, value); }
       // }

        private Byte _ACRequest;
        public Byte ACRequest
        {
            get { return _ACRequest; }
            set
            {
                SetField(ref _ACRequest, value);
                _sACRequest = value.ToString();
            }
        }
        private String _sACRequest;
        public String sACRequest
        {
            get { return _sACRequest; }
            private set { SetField(ref _sACRequest, value); }
        }


        private Double _MAP;
        public Double MAP
        {
            get { return _MAP; }
            set { SetField(ref _MAP, value);
                sMAP = value.ToString();
            }
        }
        private String _sMAP;
        public String sMAP
        {
            get { return _sMAP; }
            private set { SetField(ref _sMAP, value); }
        }


        private Double _CTS;
        public Double CTS
        {
            get { return _CTS; }
            set { SetField(ref _CTS, value);
                sCTS = value.ToString();
            }
        }
        private String _sCTS;
        public String sCTS
        {
            get { return _sCTS; }
            private set { SetField(ref _sCTS, value); }
        }

        private Double _IAT;
        public Double IAT
        {
            get { return _IAT; }
            set { SetField(ref _IAT, value);
                sIAT = value.ToString();
            }
        }
        private String _sIAT;
        public String sIAT
        {
            get { return _sIAT; }
            private set { SetField(ref _sIAT, value); }
        }



        private Double _Volts;
        public Double Volts
        {
            get { return _Volts; }
            set { SetField(ref _Volts, value);
                sVolts = value.ToString();
            }
        }
        private String _sVolts;
        public String sVolts
        {
            get { return _sVolts; }
            private set { SetField(ref _sVolts, value); }
        }



        private Double _Lambda;
        public Double Lambda
        {
            get { return _Lambda; }
            set { SetField(ref _Lambda, value);
                sLambda = value.ToString();
            }
        }
        private String _sLambda;
        public String sLambda
        {
            get { return _sLambda; }
            private set { SetField(ref _sLambda, value); }
        }

        private UInt16 _RPM;
        public UInt16 RPM
        {
            get { return _RPM; }
            set { SetField(ref _RPM, value);
                sRPM = value.ToString();
            }
        }
        private String _sRPM;
        public String sRPM
        {
            get { return _sRPM; }
            private set { SetField(ref _sRPM, value); }
        }


       
        private Double _TPS;
        public Double TPS
        {
            get { return _TPS; }
            set { SetField(ref _TPS, value);
                sTPS = value.ToString();
            }
        }
        private String _sTPS;
        public String sTPS
        {
            get { return _sTPS; }
            private set { SetField(ref _sTPS, value); }
        }


        private Byte _SparkAdvance;
        public Byte SparkAdvance
        {
            get { return _SparkAdvance; }
            set { SetField(ref _SparkAdvance, value);
                sSparkAdvance = value.ToString();
            }
        }
        private String _sSparkAdvance;
        public String sSparkAdvance
        {
            get { return _sSparkAdvance; }
            private set { SetField(ref _sSparkAdvance, value); }
        }

       


       
        private Double _InitialMAP;
        public Double InitialMAP
        {
            get { return _InitialMAP; }
            set { SetField(ref _InitialMAP, value);
                sInitialMAP = value.ToString();
            }
        }
        private String _sInitialMAP;
        public String sInitialMAP
        {
            get { return _sInitialMAP; }
            private set { SetField(ref _sInitialMAP, value); }
        }



      
        private Byte _LoopStatusExhaust;
        public Byte LoopStatusExhaust
        {
            get { return _LoopStatusExhaust; }
            set { SetField(ref _LoopStatusExhaust, value);
                sLoopStatusExhaust = value.ToString();
            }
        }
        private String _sLoopStatusExhaust;
        public String sLoopStatusExhaust
        {
            get { return _sLoopStatusExhaust; }
            private set { SetField(ref _sLoopStatusExhaust, value); }
        }



        private Double _InjPulseMs;
        public Double InjPulseMs
        {
            get { return _InjPulseMs; }
            set { SetField(ref _InjPulseMs, value);
                sInjPulseMs = value.ToString();
            }
        }
        private String _sInjPulseMs;
        public String sInjPulseMs
        {
            get { return _sInjPulseMs; }
            private set { SetField(ref _sInjPulseMs, value); }
        }




       

        private Byte _fuelsync;
        public Byte fuelsync
        {
            get { return _fuelsync; }
            set { SetField(ref _fuelsync, value);
                sfuelsync = value.ToString();
            }
        }
        private String _sfuelsync;
        public String sfuelsync
        {
            get { return _sfuelsync; }
            private set { SetField(ref _sfuelsync, value); }
        }


        private Byte _STFuelTrim;
        public Byte STFuelTrim
        {
            get { return _STFuelTrim; }
            set { SetField(ref _STFuelTrim, value);
                sSTFuelTrim = value.ToString();
            }
        }
        private String _sSTFuelTrim;
        public String sSTFuelTrim
        {
            get { return _sSTFuelTrim; }
            private set { SetField(ref _sSTFuelTrim, value); }
        }

        


        private Byte _LTFuelTrim;
        public Byte LTFuelTrim
        {
            get { return _LTFuelTrim; }
            set { SetField(ref _LTFuelTrim, value);
                sLTFuelTrim = value.ToString();
            }
        }
        private String _sLTFuelTrim;
        public String sLTFuelTrim
        {
            get { return _sLTFuelTrim; }
            private set { SetField(ref _sLTFuelTrim, value); }
        }



        private Byte _Knock;
        public Byte Knock
        {
            get { return _Knock; }
            set { SetField(ref _Knock, value);
                sKnock = value.ToString();
            }
        }
        private String _sKnock;
        public String sKnock
        {
            get { return _sKnock; }
            private set { SetField(ref _sKnock, value); }
        }


        private Double _VacHg;
        public Double VacHg
        {
            get { return _VacHg; }
            set
            {
                SetField(ref _VacHg, value);
                sVacHg = value.ToString();
            }
        }

        private String _sVacHg;
        public String sVacHg
        {
            get { return _sVacHg; }
            set
            {
                SetField(ref _sVacHg, value);
            }
        }


        private String _O2State;
        public String O2State
        {
            get { return _O2State; }
            set
            {
                SetField(ref _O2State, value);
            }
        }


        private String _ECUMode;
        public String ECUMode
        {
            get { return _ECUMode; }
            set { SetField(ref _ECUMode, value); }
        }

        private String _ThrottlePos;
        public String ThrottlePos
        {
            get { return _ThrottlePos; }
            set { SetField(ref _ThrottlePos, value); }
        }


        private String _ACClutch;
        public String ACClutch
        {
            get { return _ACClutch; }
            set { SetField(ref _ACClutch, value); }
        }

        private String _ACReq;
        public String ACReq
        {
            get { return _ACReq; }
            set { SetField(ref _ACReq, value); }
        }

        private String _ACState;
        public String ACState
        {
            get { return _ACState; }
            set { SetField(ref _ACState, value); }
        }

        private String _EGR;
        public String EGR
        {
            get { return _EGR; }
            set { SetField(ref _EGR, value); }
        }

        
        private UInt16 _BadFrames;
        public UInt16 BadFrames
        {
            get { return _BadFrames; }
            set
            {
                SetField(ref _BadFrames, value);
                sBadFrames = value.ToString();
            }
        }
        private String _sBadFrames;
        public String sBadFrames
        {
            get { return _sBadFrames; }
            private set { SetField(ref _sBadFrames, value); }
        }



        //****************************************   Property Changed Event Implementation  ***********

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //Note.  Uses c# 5.0 to automatically fill in property name
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            //if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        //Returns a List with each entry corresponding to the value an item in the Data Record
        //See GetDataValueNamesList to get the corresponding names for each entry
        public List<String> GetDataValueStringList()
        {
            List<String> StringList = new List<string>();

            StringList.Add(sLogTime);
            StringList.Add(sProgramVersion);
            StringList.Add(sPromVersion);
            StringList.Add(sACRequest);
            StringList.Add(sMAP);
            StringList.Add(sCTS);
            StringList.Add(sIAT);
            StringList.Add(sVolts);
            StringList.Add(sLambda);
            StringList.Add(sRPM);
            StringList.Add(sTPS);
            StringList.Add(sSparkAdvance);

           
            StringList.Add(sInitialMAP);
            StringList.Add(sLoopStatusExhaust);
            StringList.Add(sInjPulseMs);
           
            StringList.Add(sfuelsync);
           
           
            StringList.Add(sSTFuelTrim);
           
            StringList.Add(sLTFuelTrim);
            StringList.Add(sKnock);
           
           
            StringList.Add(sVacHg);
            StringList.Add(O2State);
            StringList.Add(ECUMode);
            StringList.Add(ThrottlePos);

            StringList.Add(ACClutch);     //on/off
            StringList.Add(ACReq);        //On/off
            StringList.Add(ACState);      //On/Iff
            StringList.Add(EGR);          //On/off

            StringList.Add(sBadFrames); 


            return StringList;
        }


        //Given an ECU Data data structure, calculates the proper values for 
        //Throttle  Position Sensor,ECU Mode, Lean/Rich Indicator, and Vaccum
        //from the pit positions in the ECU data 
        public static void CalcECUItems(ref ECUData ECUInfo)
        {
            //Calc Absolute Manifold Pressure
            double VacHg = (ECUInfo.InitialMAP - ECUInfo.MAP) / 9.13;
            ECUInfo.sVacHg = VacHg.ToString();

            //Calc if we're lean or rich
            Byte lr = ECUInfo.LoopStatusExhaust;
            lr = (Byte)(lr >> 7);
            if (lr == 1)
                ECUInfo.O2State = "Rich";
            else
                ECUInfo.O2State = "Lean";

            //Figure out which mode the ECU is in
            lr = ECUInfo.LoopStatusExhaust;
            lr = (Byte)(lr >> 1);
            lr = (Byte)(lr & 0x01);
            if (lr == 1)
                ECUInfo.ECUMode = "Decel";
            else
            {
                lr = ECUInfo.LoopStatusExhaust;
                lr = (Byte)(lr >> 6);
                lr = (Byte)(lr & 0x01);
                if (lr == 1)
                    ECUInfo.ECUMode = "Closed";
                else
                    ECUInfo.ECUMode = "Open";
            }

            //figure out throttle position
            //Get Bit Positions 1 and 3
           
            Byte tpsB1 = (Byte)(ECUInfo.fuelsync >> 1);
            Byte tpsB3 = (Byte)(ECUInfo.fuelsync >> 3);
            tpsB1 &= 0x01;
            tpsB3 &= 0x01;
            if ((tpsB1 ^ tpsB3) == 1)
            {
                //One or the other is set (But not Both)
                if (tpsB1 == 1)
                    ECUInfo.ThrottlePos = "Closed";
                else
                    ECUInfo.ThrottlePos = "Wide Open";
            }
            else
                ECUInfo.ThrottlePos = "Partial";
        }




        ///gets the corresponding names for each data entry
        ///returned from GetDataValueStringList 
        static public List<String> GetDataValueNameList()
        {
            List<String> StringList = new List<string>();

            StringList.Add("Time");
            StringList.Add("ProgramVersion" );
            StringList.Add("PromVersion");
            StringList.Add("ACRequest" );
            StringList.Add("MAP" );
            StringList.Add("CTS" );
            StringList.Add("IAT" );
            StringList.Add("Volts" );
            StringList.Add("Lambda" );
            StringList.Add("RPM");

            StringList.Add("TPS" );
            StringList.Add("SparkAdvance" );
           
            StringList.Add("InitialMAP" );

            StringList.Add("LoopStatusExhaust" );
            StringList.Add("InjPulseMs" );
           
            StringList.Add("fuelsync" );
            
           
            StringList.Add("STFuelTrim" );
            
            StringList.Add("LTFuelTrim" );
            StringList.Add("Knock" );
            
            

            StringList.Add("Abs Manifold Hg");
            StringList.Add("Exhaust Mix");
            StringList.Add("ECU Mode");
            StringList.Add("Throttle");

            StringList.Add("ACClutch");     //on/off
            StringList.Add("ACReq");        //On/off
            StringList.Add("ACState");      //On/Iff
            StringList.Add("EGR");          //On/off

            StringList.Add("BadFrames");  
            return StringList;
        }

    }

    class JeepECUData
    {
        const uint frameSize = 28;

        Byte[] _frameBuffer = new Byte[40];
        UInt16 _bufferPosition = 0;
        bool _frameCompleteFlag = false;
        bool _0xFFReceived = false;
        bool _bufferFilling = false;
        Byte _lastByte = 0;
        Byte _bufferError = 0;

        public bool FrameCompleteFlag
        {
            get { return _frameCompleteFlag; }
        }

        public Byte bufferError
        {
            get { return _bufferError; }
        }

        public UInt16 bufferCount
        {
            get { return _bufferPosition; }
        }

        /// <summary>
        /// Read the frame buffer.  Resets flags so reads can continue
        /// </summary>
        public Byte[] frameBuffer
        {
            get {
                _frameCompleteFlag = false;
                return _frameBuffer;
            }
        }

        public ECUData ParseFrame(Byte[] frame)
        {
            ECUData eData = new ECUData();

            eData.ProgramVersion = frame[0];
            eData.PromVersion = frame[1];
            eData.ACRequest = frame[2];

            eData.MAP = (frame[3] / 9.13)+3.1;
            eData.CTS = (frame[4] / 0.888) - 40.0;
            eData.IAT = (frame[5] / 0.888) - 40.0;
            eData.Volts = frame[6] / 16.24;
            eData.Lambda = frame[7] / 51.2;
       
            UInt16 t = frame[9];
            t <<= 8;
            t += frame[8];
            if (t == 0)
            {
                eData.RPM = 0;
            }
            else
            {
                Int32 r = 19850000 / t;
                eData.RPM = (UInt16)r;
            }


           

            eData.TPS = frame[12] / 2.55;
            eData.SparkAdvance = frame[13];
            
            eData.InitialMAP = (frame[16] / 9.3) + 3.1;

            eData.LoopStatusExhaust = frame[18];
            eData.InjPulseMs = frame[19] / 7.79;
           
            eData.fuelsync = frame[21];
          
           
            eData.STFuelTrim = frame[24];
           
            eData.LTFuelTrim = frame[26];
            eData.Knock = frame[27];
           
           
            ECUData.CalcECUItems(ref eData);    //Handle Calculated Properties

            return eData;
        }

        /// <summary>
        /// Parses a stream of Byte data into a reception frame.  Looks for Start of frame
        /// Sequence 0xFF, 0x00.  Also handles a 0xFF followed by 0xFF sequence where the first 
        /// 0xFF indicates data and the second 0xFF indicates the first one was ok.
        /// Int data is used instead of Byte data so that bad bytes can be identified and
        /// the entire packet discarded.  Bad bytes were identified during the CSV read
        /// and flagged as -1.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ReceiveDataFrame(Int16 data)
        {

            bool storeByteFlag = false; //Indicates we should write the byte into the buffer
            Byte byteData;

            if (FrameCompleteFlag)      //Unread frame waiting - ignore data
                return false;

            //Bad data so abort current frame
            if(data == -1)
            {
                _bufferFilling = false;
                _bufferPosition = 0;
                _lastByte = 0;
                _bufferError = 1;
                return true;
            }

            //Now that bad data has been checked, deal with Byte data 
            //
            byteData = (Byte)data;


            if(!_bufferFilling)
            {   //Waiting on a 0xFF 0x00 to get started
                if((byteData == 0x00) && (_lastByte == 0xFF))
                {
                    _bufferFilling = true;
                    _bufferPosition = 0;
                    _bufferError = 0;   //reset error
                    _lastByte = 0;          //reset for next frame start
                }
                else
                    _lastByte = byteData;
            }
            else
            {   //Start of Frame received so Receiving Data
                if(_0xFFReceived)
                {   //Last Byte into buffer was a 0xFF
                    switch(byteData)
                    {
                        case 0xFF:
                            //We have a 0xFF followed by a 0xFF.  This indicates that the prior value
                            //was valid (and not start of new frame transmission).  Simply discard this byte
                            //by not setting the store storeByteFlag.
                            break;
                        case 0:
                            //We have a 0xFF followed by a 0x00. Treat as start of new Frame transmission
                            _bufferError = 2;       //Indicate Short Count On Buffer
                            --_bufferPosition;      //Back up to last good data
                            _bufferFilling = false; //Stop Filling
                            _frameCompleteFlag = true;
                            break;
                        default:
                            //Should not happen.  Assume Data is bad and reset buffer
                            _bufferFilling = false;
                            break;
                    }
                    _0xFFReceived = false;  //Reset the flag
                }
                else
                {
                    storeByteFlag = true;
                    if (byteData == 0xFF)
                        _0xFFReceived = true;
                }

            }
            if (storeByteFlag)
            {
                _frameBuffer[_bufferPosition++] = byteData; //Store the data
                if(_bufferPosition >= frameSize)
                {
                    _bufferFilling = false; //Stop Filling
                    _frameCompleteFlag = true;
                }
            }

            return true;
        }

        static public void SaveECUData(String fName, List<ECUData> ECUDataRecords)
        {
            CsvFile cf = new CsvFile();
            CsvWriter cw = new CsvWriter();
            foreach (ECUData rec in ECUDataRecords)
            {
                CsvRecord cr = new CsvRecord();               //Get a new CSV Record
                List<String> dataStringList = rec.GetDataValueStringList();
                foreach (String item in dataStringList)
                {
                    cr.Fields.Add(item);
                }
                cf.Records.Add(cr);

            }

            cf.Headers.Clear();
            List<String> dataNameList = ECUData.GetDataValueNameList();
            foreach (String s in dataNameList)
            {
                cf.Headers.Add(s);
            }

            cw.WriteCsv(cf, fName, Encoding.ASCII); //Write The CSV File
        }


        public static bool ReadECUData(ref ECUData ECUVars,String url)
        {
            ECUData tempecu;
            bool retval = false;

            url = "http://" + url + "/ecu";
            

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result == null)
                        return false;
                    if (result == "")
                        return false;
                    tempecu = JsonConvert.DeserializeObject<ECUData>(result);

                    //Now we have name value pairs of ECU variables.  Need to calculate a few remaining ones
                   // ECUData.CalcECUItems(ref tempecu);  Obsolete

                    ObjectCopier.CopyShallow<ECUData>(tempecu, ECUVars);
                    //Now ensure we've copied the Relay Status
                    retval = true;

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retval;

        }
}
}
