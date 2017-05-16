/*
 *    Module: ServoPwm.cpp
 *    Author: Jinn-Kwei Guo
 *    Date: 2017/5/10
 *      
 *    PWM Control Library for 50Hz Servo Motor  
 *    Support MiniPlan V670 board, with PCA9685 (16 servos) + Software servo*2
 */

#include "ServoPwm.h"

#define DEBUG_LEVEL 0


//Extern
ServoPwm motor;

//private
Adafruit_PWMServoDriver PCA9685 = Adafruit_PWMServoDriver();
Servo softServo[2];  

/*
 * ServoPwm Class
 */
ServoPwm::ServoPwm()
{
}

void ServoPwm::begin()
{
  // check data
  for (int servoNo=0; servoNo<NumberOfServo; servoNo++) {
      if  ((minPulseWidth[servoNo]<PWM_MinPulseWidth) || (minPulseWidth[servoNo]>PWM_MaxPulseWidth)) {
          Serial.print("minPulseWidth#");
          Serial.print(servoNo);
          Serial.println(" Error");
          RTOS.shutdown();
      }
      if  ((maxPulseWidth[servoNo]<PWM_MinPulseWidth) || (maxPulseWidth[servoNo]>PWM_MaxPulseWidth)) {
          Serial.print("maxPulseWidth#");
          Serial.print(servoNo);
          Serial.println(" Error");
          RTOS.shutdown();
      }
      if  ((midPulseWidth[servoNo]<PWM_MinPulseWidth) || (midPulseWidth[servoNo]>PWM_MaxPulseWidth)) {
          Serial.print("midPulseWidth#");
          Serial.print(servoNo);
          Serial.println(" Error");
          RTOS.shutdown();
      }
  }
  
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

 //init angle to 90 degree
  for (int servoNo=0; servoNo<NumberOfServo; servoNo++) {
    setAngle(servoNo, 90);
  }
}

float ServoPwm::angleToPulseWidth(int servoNo, int angle) {
    int pulseWidth = (angle-90)*angleToPwmRatio[servoNo] + midPulseWidth[servoNo];
    if (pulseWidth>=minPulseWidth[servoNo] && pulseWidth<=maxPulseWidth[servoNo]) {
        return pulseWidth;
    } else {
        return midPulseWidth[servoNo]; //reject invalid angle to protect servo
    }
}

void ServoPwm::PwmControl()
{ 
    const float pulseUnit = 1068000.0f/PWM_Frequency/4096;   //calibrated by oscilloscope
    
    for (int servoNo=0; servoNo<NumberOfServo; servoNo++) {      
        #if (DEBUG_LEVEL>1)
        Serial.print("setAngle(");
        Serial.print(servoNo);
        Serial.print(",");
        Serial.print(angle);
        Serial.println(")");
        #endif
        if (servoNo<16) {
            int pulseCount = angleToPulseWidth(servoNo, targetAngle[servoNo])/pulseUnit;
            PCA9685.setPWM(servoNo, 0, pulseCount);
            //Serial.println("Setting PCA9685"); //debug
        } else if (servoNo<NumberOfServo) {
            softServo[servoNo-16].write(targetAngle[servoNo]);  
            //Serial.println("Setting softServo"); //debug
        }
    }            
}

void ServoPwm::setAngle(int servoNo, int angle) 
{
    if (angle>=0 && angle<=180) {
        targetAngle[servoNo] =  angle;
    }
}

void ServoPwm::report()
{
    Serial.print("*** PWM : ");
    for (int i=0; i<NumberOfServo; i++) {
        Serial.print(targetAngle[i]);
        Serial.print(" ");    
    }
    Serial.println();
}

