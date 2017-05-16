/*
 *    Module: CmdShell.cpp
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Command Shellf for Spider
 *        
 */ 
#include <ESP8266WiFi.h>
#include "CmdShell.h"
#include "ServoPwm.h"
#include "SpiderAuto.h"

#define DEBUG_LEVEL 2

//Extern
CmdShell CommandShell;

CmdShell::CmdShell()
{
    cmdLength=0;
}

int CmdShell::parseCommand()
{
    int retCode=0;
    
    #if (DEBUG_LEVEL>0)
      Serial.print("*** CMD:");
      Serial.write(cmdBuffer,cmdLength);
      Serial.println();
    #endif
    
    if ((cmdBuffer[1]=='M') && (cmdBuffer[4]=='A') && (cmdBuffer[8]=='#'))
    { 
        // Command : Motor Angle 
        int motorID = (cmdBuffer[2]-'0')*10 + (cmdBuffer[3]-'0');
        int angle = (cmdBuffer[5]-'0')*100 + (cmdBuffer[6]-'0')*10 + (cmdBuffer[7]-'0');
        if (angle>=0 && angle<=180) {
            motor.setAngle(motorID, angle);        
            retCode=1;
        } else {
            retCode=-1;
        }
        
        #if (DEBUG_LEVEL>1)
            Serial.print(F("MotorID="));
            Serial.print(motorID);
            Serial.print(F(", angle="));
            Serial.println(angle);
        #endif        
    } 
    else if ((cmdBuffer[1]=='S') && (cmdBuffer[5]=='#'))
    { 
        // Command : Set
        int angle = (cmdBuffer[2]-'0')*100 + (cmdBuffer[3]-'0')*10 + (cmdBuffer[4]-'0');
        if (angle>=0 && angle<=180) {
            for (int i=0; i<NumberOfServo; i++) {
                motor.setAngle(i, angle);
            }     
            retCode=1;
        } else {
            retCode=-1;
        }   
    } 
    else if ((cmdBuffer[1]=='Q') && (cmdBuffer[2]=='#')) 
    {
        // Command : Query
        Serial.print("*** PWM: ");
        for (int i=0; i<NumberOfServo; i++) {
            Serial.print(motor.targetAngle[i]);
            Serial.print(" ");
        }    
        Serial.println();     
        Serial.print("server IP=");
        Serial.println(WiFi.softAPIP());
        retCode=1;
    } else if ((cmdBuffer[1]=='A') && (cmdBuffer[3]=='#')) 
    {
        // Command : AutoAction
        int actionID = (cmdBuffer[2]);        
        spiderAuto.beginAction(actionID);
        retCode=1;
    }    
    else if ((cmdBuffer[1]=='T') && (cmdBuffer[2]=='#')) 
    {
        RTOS.taskManager.taskListReport(); //RTOS 
        retCode=1; 
    } else {
        //spiderAuto.beginAction('Z'); //reset and stop
        #if (DEBUG_LEVEL>0)
            Serial.print("Bad Command: '");
            Serial.write(cmdBuffer, cmdLength); 
            Serial.println("'");
        #endif
        retCode = -1;
    }
    cmdLength=0; //reset 
    return retCode;
}
