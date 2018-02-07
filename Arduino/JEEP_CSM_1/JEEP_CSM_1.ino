
/* JEEP_CSM Version 1.0
 *  John Eberle 2018
 *  This program will read Jeep Renix ECU codes.  It has been tested only on 
 *  1990 Jeep YJ 2.5L engine with manual transmission.  This code, and hardware, is heavly based on the 
 *  open source work by:
 *  Nick Risley
 *  and his Renduinix Plus project.  See:
 *  https://www.facebook.com/nickintimefilms/
 *  https://nickintimedesign.wordpress.com/
 *  Thanks to him for his work on this and help he personally provided!
 *  
 *  Also based on prior work by  Phil Andrews 2011, 2012
 *  
 *  ECU variable can be accessed through an HTTP request (i.e. http://192.168.4.1/ecu in Web Broser).
 *  It will respond with a JSON structure of name value pairs. 
 *  
 *  The Hardware sets up it's own access point so that no existing wireless infrastructure is needed.
 *  To access the data, you must connect to the SSID with a password.   Currently SSID = RenixECU and
 *  password is 12345678.
 *  
 *  The processor is an ESP8266 Arduino compatable processor which provides WiFi.   It uses it Serial
 *  UART RX pin to receive data from the JEEP ECU and it's serial TX pin to send debug info if the 
 *  variable _debug = true (see code).  It communicates at the same serial setting as the Jeep ECU:
 *  62500, N,8,1
 *  Questions can be sent to jeberle5713@gmail.com or see TractorEnvy.com
 *  
 *  Version History
 *  V 1.0 - The first 
 *  
 *  
  */

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <WiFiManager.h>
#include <ArduinoJson.h>
#include <ESP8266mDNS.h>        // Include the mDNS library

/*************************************************************************   Global Variable Declaeations *********************************************/
ESP8266WebServer server(80);      //Our Web Server on Port 80
                                  //The name of the SSID we will use to connect

                                  //ToDo: put SSID and password here vs hardcode


//const char* ssid = "hug2g373793";

const char* ssid = "Chip001";
const char* password = "givemeinternet2";



//************************************************************************ Globals used fo rECU frame reception  **************************************
uint8_t FRAME_SIZE = 28;          //ECU Frame size constant
String webString="";              // String to display
uint8_t _frameBuffer[40];         //Holds the data frame
uint16_t _bufferPosition = 0;     //Current reception byte position
bool _frameCompleteFlag = false;  //Set when a frame is ready
bool _0xFFReceived = false;       // Set when a 0xFF received
bool _bufferFilling = false;      //Indicates a frame reception is in progress
uint8_t _lastByte = 0;            //Tracks last byte received
uint8_t _bufferError = 0;         //Indicates a buffer error
bool _CLFlag = false;              //indicates if we're currently in closed loop
uint16_t _badFrames = 0;          //Indicates number of bad Comm Frames from ECU
//**************************************************************  ECU Data Variables  ************************************************************
  uint8_t ProgramVersion = 0;   //framebuffer[0] - ECU Program Version (Constant).  If = 32, then it's 2.5L, if 177 then 89-90, if 176 then 87-88
  uint8_t PromVersion = 0 ;     //framebuffer[1]  - ECU PROM version (Constant).  If 16 or 20 then Auto, if 144 or 148 then Manual, if 98 then new, 97 = mid, 225 = old.
//  uint8_t CalibrationCode= 0  ; //framebuffer[2] - Calibration Code fro engine
  uint8_t ACRequest = 0;        //JE framebuffer[3] -   Various AC Bits and Throtttle position (Note Throttle is fuelsync on 4L)
                                //Bit 2 AC Switch
                                //Bit 3 & 4 = Throttle Position
                                //Bit 5 = AC Request or EGR ?????????????????
                                //Bit 6 = AC Clutch
                                //
                                //Throttle Position:
                                //Bits 1-3 indicate throttle psoition: Wide Open, partial, Closed
                                //Bit 1. Set = Decel Mode (not in Closed Loop)
                                //Bit 3  Bit 4  ThrottleState
                                //  0     0     Partial
                                //  0     1     Closed
                                //  1     0     Wide Open
                                //  1     1     Partial
                                //If  (Bit 1 XOR Bit 3) Check Bit(4) to determine Closed or Wide Open Otherwise it's Partial
                                
                                                    
  double MAP = 0.0  ;           //(framebuffer[3] - Raw Manafold Absolute Pressure.  Convert To inHg Map = MapRaw/9.13) + 3.1.  Convert to volts Map = MapRaw/51 (Volts)
                                //Idle: 10-25 "Hg, 1-4 Volts.
                                //Location: Center of firewall
                                //Pinout: A:GND, B:Output, C:5V
                                
  double CTS= 0.0  ;           //(framebuffer[4]/0.888) - 40 - Coolant Temp Sensor in F
                                //Left Side of Intake Manafold
                                //Typ: 180F - 220F
                                //Pinout: A:GND,B:Output.  0-100k Ohms
                                
  double IAT= 0.0  ;           //(framebuffer[5]/0.888)-40  - Inductive Aitr Temp F
                                //Location: Intake Manafold behind throttle body.
                                //Pinout A:GND, B:Output.  0-100k Ohms
                                
  double Volts= 0.0  ;            //(framebuffer[6]/31.875)+8 - (2.5L) Charging Voltage Vdc
                                //Typ: 13-15 at Idle
                                
  double Lambda= 0.0  ;           //framebuffer[7]*4.34  - (2.5L) O2 Sensor reading in volts
                                //0-1V Sing (2.5L)
                                //Location: Exhaust Manafold Collector
                                //Pinout: A:12V, B:GND, C:Output
  
  uint16_t RPM= 0  ;            //19868686/((frameBuffer[9] << 8) | (frameBuffer[8])) * 1.5 - (2.5L) Engine RPM
                                //Location: Top Left Transmission Bellhousing
                                //Pinout: A&B AC Signal or 125-275 Ohms

  //uint8_t Prom1= 0  ;           // JE frameBuffer[10]    Injection Pulsewidth Low
  //uint8_t Prom2= 0  ;           // JE frameBuffer[11]    Injection Pulse Width High
  
  double InjPulseMs = 0.0;        //((frameBuffer[11] << 8) | (frameBuffer[10]))/1000 -  (2.5L) Injection Pulse Width ms 
  
  double TPS= 0.0  ;              //frameBuffer[12] / 2.55 - Throttle Position Sensor (% Open)
                                //Location: Front of throttle body
                                //Pinout: A:5v, B:GND, C:Output 0-5V
                                
  uint8_t SparkAdvance= 0  ;    //frameBuffer[13] - Spark advance in degrees
  // Unknown1= 0  ;        //frameBuffer[14]
  // Unknown2 = 0 ;        //frameBuffer[15]
  double InitialMAP = 0 ;       //(frameBuffer[16]  - Initial Manafold Absolute Pressure inches Hg
  // Unknown3= 0  ;        //frameBuffer[17]
  uint8_t LoopStatusExhaust = 0 ; //frameBuffer[18]         - Bits indicate fuel control mode (open/closed) and if we're in rich or lean condition
                                  //Bit 7. Set = Rich, else Lean
                                  //
                                  //ECU Control Mode:
                                  //Bit 1. Set = Decel Mode (not in closed loop) Otherwise
                                  //Bit 6. Set = Closed Loop, otherwise Open Loop
                                  
  //double InjPulseMs = 0 ;       //JE frameBuffer[19] / 7.79    NO!   - Unknown
 // uint8_t Unknown4= 0  ;        //frameBuffer[20]
  uint8_t fuelsync= 0  ;        //JE ?? Unknown frameBuffer[21]   NOT USED
 // uint8_t Unknown5= 0  ;        //frameBuffer[22]
  //uint8_t Warmup = 0 ;          //frameBuffer[23]  //JE Unknown
  uint8_t STFuelTrim= 0  ;      //frameBuffer[24]   - Short term fuel trim.  This is the amount of fuel being +/- to the base fuel curve.  < 128 then subtracting from base
                                                      //128 = using base, > 128 adding to base
 // uint8_t Unknown6= 0  ;        //frameBuffer[25]  -
  uint8_t LTFuelTrim= 0  ;      //frameBuffer[26]   - long term fuel trim -  Long term average of STFuelTrim
  uint8_t Knock= 0  ;           //frameBuffer[27]   - engine knock sensor - low value is normal and increases with RPM
                                //Location: Left Side of Engine Block
                                //Reading: 2500 RPM 10-100 Typ
                                //Pinout A: GND, B:Output
 // uint8_t unknown7= 0  ;        //frameBuffer[28]
 // uint8_t ACSwitch= 0  ;        //frameBuffer[29]   - JE Stop Byte 0xFF

  double Vaccum = 0.0; //Engine Vacuum
                      //InitialMap-MAPRaw -> Scaled. (Convert InitialMap and Suptract MAP from that)

  //Display Representations to Send (String indicators of states)
  //
  String ThrottlePos; //"WOT, Partial,Close"
  String ACClutch;     //on/off
  String ACReq;        //On/off
  String ACState;      //On/Iff
  String ECUMode;      //"Open, Decel, Close"
  String O2State;       //Rich or Lean
  String EGR;          //On/off
        
 //***************************************************   End ECU Variables ******************************************************************************

//****************************************************   Other Globals **********************************************************************************
bool _debug = true;
bool _useExistingWifi = false;
//****************************************************   End Other Globals **********************************************************************************

//Method to take raw frame of bytes and parse into our global variables.  See describptions of variables
//and frame positions abovee.
void ParseBuffer()
{
    uint8_t bit_3;
    uint8_t bit_4;
    
    uint16_t t;
    uint32_t r;
    ProgramVersion = _frameBuffer[0];
    PromVersion = _frameBuffer[1];
    //CalibrationCode = _frameBuffer[2];

    //Decode ACRequest Byte
    ACRequest = _frameBuffer[2];
      //Figure out Throttle Position:  
      bit_3 = (ACRequest & B00001000) >> 3;  //Setup bit indicators for boolean op (XOR)
      bit_4 = (ACRequest & B00010000) >> 4; 
      if(bit_3 ^ bit_4){              //XOR isolates bit3 or bit4 on
        if(bit_4)
          ThrottlePos = "Close";
        else
          ThrottlePos = "WOT";
      }
      else
          ThrottlePos = "Partial";    //both bits off or on

     //Figure out AC variables
     if(ACRequest & B00000100)      //bit/2 indicates AC Request
        ACState = "On";
     else
        ACState = "Off";

    if(ACRequest & B01000000)     //bit/6 indicates clutch state
        ACClutch = "On";
     else
        ACClutch = "Off";
    
    if(ACRequest & B00100000)     //Not sure on this one.....
        EGR = "On";
     else
        EGR = "Off";
 

    MAP = (_frameBuffer[3] / 9.13)+3.1;        //Scale Manafold Pressure to inHg
    CTS = (_frameBuffer[4] / 0.888) - 40.0;    //Scale Coolant temp to F
    IAT = (_frameBuffer[5] / 0.888) - 40.0;    //Scale Inlet Air Temperature to F
    Volts = (_frameBuffer[6] / 31.875) + 8; //converts to Volts (8 - 16)  //OK
    Lambda = (_frameBuffer[7] * 4.34);      //converts to mV (0 - 1,106.7)  //OK

    //Combine L/H Bytes to get RPM.  Could use Word() macro instead
    t = _frameBuffer[9];  //High byte into Word and left shift 8 bits
    t <<= 8;
    t += _frameBuffer[8]; //Add Low to High.
    if (t == 0)           //Avoid Divide by Zero
        RPM = 0;
    else
    {
        r = 19868686 / t;
        r = r * 1.5;        //Adjust for 2.5L
        RPM = (int16_t)r;
    }

   
    InjPulseMs = (word(_frameBuffer[11], _frameBuffer[10]) / 1000.0);  //Pulse Width in mS (0 - 65.5)
 
    TPS = _frameBuffer[12] / 2.55;    //Throttle Position %
    SparkAdvance = _frameBuffer[13];    //Spark Advance Degree

    InitialMAP = (_frameBuffer[16] / 9.3) + 3.1;    //OK
    Vaccum = InitialMAP - MAP;                  //Calculate current vaccum

    LoopStatusExhaust = _frameBuffer[18];

    //Figure out fuel mix: Rich/Lean
    if(LoopStatusExhaust & B10000000) {
      O2State = "Rich";
    }
    else
      O2State = "Lean";

     //Figure out ECU Control Mode
     _CLFlag = false;
     if(LoopStatusExhaust & B00000010)
        ECUMode = "Decel";
     else if(LoopStatusExhaust & B01000000)
     {
        ECUMode = "Cls Loop";
        _CLFlag = true;
     }
     else
        ECUMode = "Opn Loop";
  
    fuelsync = _frameBuffer[21];
   // Warmup = _frameBuffer[23];
    STFuelTrim = _frameBuffer[24];
    LTFuelTrim = _frameBuffer[26];
    Knock = _frameBuffer[27];
}






 //HTTP Callback method when root HTML request is made ie: 164.192.1/
 //Simply give hint on other requests to be made...in this case use /ECU to see ecu settings
void handle_root() {
  server.send(200, "text/plain", "Jeep Rennix ECU Reader, Use /ECU to get readings.....");
  delay(100);
}

//Handles Sending Debug info oot the debug port.
void SendDebug(char * msg){
  if(_debug)                //If debug flag set then send message, otherwise return.
     Serial.print(msg);
}



//HTTP Callback method to send real time ECU info.  ie. 164.192.1/ECU
void handleECU() {
  SendDebug("\n\r Got /ECU request");
  String js =   makeJSON();                      //Build JSON Object of current status
  server.send(200, "application/json", js);     //Update client
  delay(100);
}

void handleCheckConnection(){

//  DynamicJsonBuffer jsonBuffer;
//  JsonObject& json = jsonBuffer.createObject();

//  String action = "";
//  String key = "";
//  String statusUpdate = "";

  SendDebug("\n\r Got /CheckConnection request");
  server.send(200, "text/plain", "Jeep ECU Reader Connected!");
  
 // key = "Name";
 // action = "Rennix ECU Reader";
 // json[key] = action;
 // json.printTo(statusUpdate);
 // server.send(200, "application/json", statusUpdate);     //Update client
  delay(100);
}

bool ConnectToWifi()
{
  char msg[80];
  static uint8_t tries = 0;
  WiFi.begin(ssid, password);

  // while wifi not connected yet, print '.'
  // then after it connected, get out of the loop
  while (WiFi.status() != WL_CONNECTED) {
     delay(500);
     ++tries;
     SendDebug("?");
     if(tries > 20)
     {
        tries = 0;
        break;
     }
  }

 if(WiFi.status() != WL_CONNECTED)
 {
    WiFi.disconnect();
    return false;
 }
  
  //print a new line, then print WiFi connected and the IP address
  
 SendDebug("\r\nWiFi connected to local ");
 return true;
  // Print the IP address
 // sprintf(msg,"Connected. Local IP is: %s",WiFi.localIP().toString());
 // SendDebug(msg);
}

void ConnectToAP()  
{
  IPAddress ipa;
  String ips;
  char ipmsg[80];
  
    //Setup Wifi with SSID and password
    SendDebug("Setting soft-AP ... ");
     WiFi.mode(WIFI_AP);
    boolean result = WiFi.softAP("RenixECU", "12345678");
    if(result == true)
    {
      SendDebug("\n\rReady");
      SendDebug("Soft-AP IP connected ");
      ipa = WiFi.softAPIP();
      ips = ipa.toString();
      ips.toCharArray(ipmsg,80);
      SendDebug(ipmsg);
    }
    else
    {
     SendDebug("SoftAP WiFi Setup Failed!");
    }


    if (!MDNS.begin("esp8266")) {             // Start the mDNS responder for esp8266.local
    SendDebug("Error setting up MDNS responder!");
  }
  SendDebug("mDNS responder started");
    
}

 // Called automatically, first thing on every reeboot
void setup(void)
{
  pinMode(2, OUTPUT);       //Set GPIO.2 as output
  digitalWrite(2, LOW);   // turn the LED on (inverted output) to show we're powered up and configuring
  delay(5000);            //Delay 5 seconds.  This allow a few seconds to get serial debug terminal ready for troubleshooting if needed
  digitalWrite(2, HIGH);   // Invert LED to indicate we're running

  Serial.begin(62500);  // Serial connection.  Rx from Jeep, Tx to debug.  Note we must use Jeep Baud rate 
  SendDebug("\n\r \n\rWorking to connect");

  if(_useExistingWifi)
    while (!ConnectToWifi())
    {
      SendDebug("Trying again to connect to existing WiFi");
    }
  else
    ConnectToAP();  

  
  //Set callbacks when the server receives HTTP requests
  server.on("/", handle_root);
  server.on("/ecu",handleECU);
  server.on("/checkconnection",handleCheckConnection);

  //Start our server listening
  server.begin();
  SendDebug("HTTP server started");
}


//loop is called continually during execution 
void loop(void)
{
  server.handleClient();  //Required by librry to update states
  ManageSerialReceive();  //Handle ECU frame reception
  
  if(_CLFlag )
      digitalWrite(2, LOW);   // turn the LED on (inverted output) to show we're in closed loop mode
} 


//Method to toggle GPIO.2
void toggleLed()
{
  static uint8_t state = 0;
  if(state == 0)
  {
    digitalWrite(2, HIGH);   // turn the LED on (HIGH is the voltage level)
    state = 1;
  }
  else
  {
    digitalWrite(2, LOW);   // turn the LED on (HIGH is the voltage level)
    state = 0;
  }
}

//Method used receive and parse bytes from Jeep ECU
void ManageSerialReceive()
{
  uint8_t byte_read;

  //Loop while there's anything in the serial buffer
  while( Serial.available() > 0)
    {
       byte_read= Serial.read();  //Read any data received (at a minimum empty the buffer))
       ReceiveDataFrame(byte_read); //Send byte read to be put in dataframe
       if(_frameCompleteFlag)       //If we have a complete dataframe
       {
          //toggleLed();
          if(_bufferError == 0)     //If there was not an error receiving frame
          {
             SendDebug("+");        //Indicate good frame to debug
             ParseBuffer();         //Parse the raw buffer data into our global ECU variables
          }
          else
          {
            ++_badFrames;
            SendDebug("-");    //Indicate bad frame to debug
          }
          _frameCompleteFlag = false;   //Reset Flag to start new receive
       }
    }
}






//Method to handle bytewise frame data from JEEP ECU.  Looks for 0xFF 0x00 sequence which indicates a start of frame condition to start.
//Note: It's posible to have 0xFF as a data value and for it to be followed by the next data value as 0x00.   To ensure this doesn't
//cause a start of frame condition, the ECU will always send 0xFF and follow it with a second 0xFF to indicate that it's data.
//
//To Use:
//Pass in serial data.
//Look for _frameCompleteFlag complete flag, read the _framebuffer
//Check _bufferError to see if there was a problem reading frame
//_reset the _frameCompleteFlag and continue.
bool ReceiveDataFrame(uint8_t data)
{

    bool storeByteFlag = false; //Indicates we should write the byte into the buffer
    uint8_t byteData;

    if (_frameCompleteFlag)      //Unread frame waiting - ignore data
        return false;
        
    byteData = data;
    
    if(!_bufferFilling)           //Waiting on 0xFF, 0x00 sequence to start
    {   
        if((byteData == 0x00) && (_lastByte == 0xFF))   //if currentt byte is 0x00 and last was 0xFF then start frame
        {
            _bufferFilling = true;   //Indicate filling in progress
            _bufferPosition = 0;     //Reset frame fill position
            _bufferError = 0;       //reset error
            _lastByte = 0;          //reset for next frame start
            _0xFFReceived = false;  //Reset double 0xFF data indicator
        }
        else
            _lastByte = byteData;   //Not start of frame, so keep byte for next check
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
            storeByteFlag = true;   //Prior byte was not 0xFF.  Store it and set flag if current byte is 0xFF
            if (byteData == 0xFF)
                _0xFFReceived = true;
        }

    }

    //If there is valid data to store
    if (storeByteFlag)
    {
        _frameBuffer[_bufferPosition++] = byteData; //Store the data
        if(_bufferPosition >= FRAME_SIZE)   //Full frame so indicate
        {
            _bufferFilling = false; //Stop Filling
            _frameCompleteFlag = true;
        }
    }

    return true;
}




//Method handles taking our ECU data variable and making them into JSON string
String makeJSON()
{
  DynamicJsonBuffer jsonBuffer;
  //StaticJsonBuffer<500> jsonBuffer;   //Changed to 400 Bytes Due to exception at 200
  JsonObject& json = jsonBuffer.createObject();

  String action = "";
  String key = "";
  String statusUpdate = "";


//~250 characters tect
// 32 entries x 6 char per = 192.  250 + 192 = 442  Make JSON Buffer 500

   key = "ProgramVersion";
   action = String(ProgramVersion);
   json[key] = action;
   
   key = "PromVersion";
   action = String(PromVersion);
   json[key] = action;
   
   key = "ACRequest";
   action = String(ACRequest);
   json[key] = action;
   
  key = "MAP";
  action = String(MAP);
   json[key] = action;
   
  key = "CTS";
  action = String(CTS);
   json[key] = action;
   
  key = "IAT";
  action = String(IAT);
   json[key] = action;
   
  key ="Volts";
  action = String(Volts);
   json[key] = action;
   
  key ="Lambda";
  action = String(Lambda);
   json[key] = action;
   
  key ="RPM";
  action = String(RPM);
   json[key] = action;

  
  key = "InjPulseMs";
  action = String(InjPulseMs);
  json[key] = action;
   
  key ="TPS";
  action = String(TPS);
   json[key] = action;
   
  key ="SparkAdvance";
  action = String(SparkAdvance);
   json[key] = action;
      
  key ="InitialMAP";
  action = String(InitialMAP);
   json[key] = action;
   
    
  key ="LoopStatusExhaust";
  action = String(LoopStatusExhaust);
   json[key] = action;
    
  key = "fuelsync";
  action = String(fuelsync);
   json[key] = action;
  
    
 // key = "Warmup";
 // action = String(Warmup);
 //  json[key] = action;
  
  key = "STFuelTrim";
  action = String(STFuelTrim);
   json[key] = action;
  
    
  key = "LTFuelTrim";
  action = String(LTFuelTrim);
   json[key] = action;
  
  key = "Knock";
  action = String(Knock);
   json[key] = action;
    
  key = "VacHg";
  action = String(Vaccum);
  json[key] = action;

  key = "O2State";
  action = O2State;
  json[key] = action;

  key = "ECUMode";
  action = ECUMode;
  json[key] = action;


  key = "ThrottlePos";
  action = ThrottlePos;
  json[key] = action;

  key = "ACReq";
  action = ACReq;
  json[key] = action;

  key = "ACState";
  action = ACState;
  json[key] = action;

  key = "ACClutch";
  action = ACClutch;
  json[key] = action;

  key = "EGR";
  action = EGR;
  json[key] = action;

  key = "BadFrames";
  action = String(_badFrames);
  json[key] = action;

 //Print JSON to debug if enabled.
  if(_debug)
    json.printTo(Serial); //Print to our return variable.

  json.printTo(statusUpdate); 
  return statusUpdate;
}





    

