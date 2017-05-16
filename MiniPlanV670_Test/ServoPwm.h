/*
 *    Module: ServoPwm.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Software PWM Control Library for 50Hz Servo Motor  
 *        
 */

#ifndef ServoPwm_h
#define ServoPwm_h

#include <Arduino.h>
#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>
#include <Servo.h>
#include "Spider.h"
#include "RTOS.h"

#define NumberOfServo         18
#define PWM_MaxPulseWidth   2400
#define PWM_MinPulseWidth    600 
#define PWM_Frequency         52   //calibrated by oscilloscope
#define Servo16pin            13
#define Servo17pin            16

class ServoPwm {
    public:      
        // variables      
        int targetAngle[NumberOfServo]; //ideal angle=0~180, limited by motor design parameter 
        Task* pPwmTask;   

        // methods
        ServoPwm(); //constructor
        void begin();        
        void PwmControl();
        void setPwmWidth(int servoNo, int pwmWidth);
        void setAngle(int servoNo, int angle);
        void report();
        
    private:
        // The followint parameters are motor-dependent, they should be adjusted for each motor
        int minPulseWidth[NumberOfServo] = {  600,  600,  600,  600,  600,  600,  600,  600,  600,  600,  600,  600, 600,  600,  600,  600,  600,  600};  // limit of each servo
        int midPulseWidth[NumberOfServo] = { 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500, 1500};  // center of each servo
        int maxPulseWidth[NumberOfServo] = { 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400, 2400};  // limit of each servo
        float angleToPwmRatio[NumberOfServo] = { 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0 }; //convert angle to pulse width ratio

        // methods
        float angleToPulseWidth(int servoNo, int angle);  //convert angle to pulse width
};

extern ServoPwm motor;

#endif //ServoPwm_h
//
// END OF FILE
//



