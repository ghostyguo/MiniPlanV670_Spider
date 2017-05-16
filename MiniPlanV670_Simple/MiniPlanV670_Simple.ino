#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>
#include <Servo.h>

// ------------ replace the following moves ------------
#define Steps 4
int spiderMove[]  = {
         500,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,
         500, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180, 180,
         500,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,  90,
         500,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
};

// -------------------------------------------------------

#define NumberOfServo         18
#define PWM_MaxPulseWidth   2400
#define PWM_MinPulseWidth    600 
#define PWM_Frequency         52   //calibrated by oscilloscope
#define Servo16pin            13
#define Servo17pin            16

// The followint parameters are motor-dependent, they should be adjusted for each motor
int minPulseWidth[NumberOfServo] = {  600,  600,  600,  600,  600,  600,  600,  600,  600,  600,  600,  600, 600,  600,  600,  600,  600,  600};  // limit of each servo
int midPulseWidth[NumberOfServo] = { 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500};  // center of each servo
int maxPulseWidth[NumberOfServo] = { 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400};  // limit of each servo
float angleToPwmRatio[NumberOfServo] = { 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0 }; //convert angle to pulse width ratio

//private
Adafruit_PWMServoDriver PCA9685 = Adafruit_PWMServoDriver();
Servo softServo[2];      

void setup() {
    Serial.begin(57600);
    servoInit();
}

void loop() {
    for (int cmd=0; cmd<Steps; cmd++) {
        Serial.print("Command");
        Serial.print(cmd);
        Serial.print(":");
        for (int servoNo=0; servoNo<NumberOfServo; servoNo++) {
            int angle = spiderMove[cmd*(NumberOfServo+1)+servoNo+1];
            setAngle(servoNo, angle);
            Serial.print(angle);
            Serial.print(" ");
        }
        delay(spiderMove[cmd*(NumberOfServo+1)]);    
        Serial.println(spiderMove[cmd*(NumberOfServo+1)]);                
    }
}

void servoInit()
{
  // Initialize I2C
  Wire.begin(4, 5);
  
  // Hardware PWM *16
  PCA9685.begin();  
  PCA9685.setPWMFreq(PWM_Frequency);  // Analog servos run at ~50 Hz updates  
  
  // Software PWM *2 @ pin 12, 13
  pinMode(12,OUTPUT);
  pinMode(13,OUTPUT);
  softServo[0].attach(Servo16pin);
  softServo[1].attach(Servo17pin);
}

float angleToPulseWidth(int servoNo, int angle) {
    int pulseWidth = (angle-90)*angleToPwmRatio[servoNo] + midPulseWidth[servoNo];
    if (pulseWidth>=minPulseWidth[servoNo] && pulseWidth<=maxPulseWidth[servoNo]) {
        return pulseWidth;
    } else {
        return midPulseWidth[servoNo]; //reject invalid angle to protect servo
    }
}

void setAngle(int servoNo, int angle) 
{
    const float pulseUnit = 1068000.0f/PWM_Frequency/4096;   //calibrated by oscilloscope
   if (angle>=0 && angle<=180) {    
        if (servoNo<16) {
            int pulseCount = angleToPulseWidth(servoNo, angle)/pulseUnit;
            PCA9685.setPWM(servoNo, 0, pulseCount);
            //Serial.println("Setting PCA9685"); //debug
        } else if (servoNo<NumberOfServo) {
            softServo[servoNo-16].write(angle);  
            //Serial.println("Setting softServo"); //debug
        }
    }            
}
