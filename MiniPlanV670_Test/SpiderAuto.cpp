/*
 *    Module: SpiderAuto.cpp
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Auto Action for Spider
 *        
 */
 
#include "SpiderAuto.h"
#include "ServoPWM.h"

SpiderAuto spiderAuto;


/* Spider leg action:
   array data : time(ms), angle1, angle2, angle3 ...... angle12
  direction of angle>90 : motor 0, 2, 4 : forward
                          motor 1, 3, 5 : in
                          motor 6, 8, 10 : backward
                          motot 7, 9, 11 : out
  angle limit: motor 0, 4, 6, 10 : 0~180/0
               motor 2, 8 : 45~135
               motor 1, 3, 5 : 0~135
               motor 7, 9 ,11: 45~180
*/
const PROGMEM uint16_t spiderAutoAction1[]  = { 
         200, 150,  90,    60,  90,    90,  90,   150,  90,    60,  90,    90,  90,  150,  90,    60,  90,    90,  90, //put leg set 2 
         200, 150,  90,    60,  45,    90,  90,   150, 135,    60,  90,    90, 135,  150,  60,    60,  60,    90,  90,//lift leg set 1
         200,  90,  90,    60,  45,    30,  90,   150, 130,   120,  90,    90, 135,  30,   90,    90,  90,   120,  90, //backward leg set 2
         200,  90,  90,   120,  45,    30,  90,    90, 130,   120,  90,    30, 135,  150,  90,    60,  90,    90,  90,//forward leg set 1
         200,  90,  90,   120,  90,    30,  90,    90,  90,   120,  90,    30,  90,  30,   60,    90,  60,   120,  90, //21 put leg set 1
         200,  90,  45,   120,  90,    30,  45,    90,  90,   120, 135,    30,  90,  150,  60,    60,  90,    90,  90,//lift leg set 2
         200,  90,  45,    60,  90,    30,  45,   150,  90,   120, 135,    90,  90,  150,  90,    60,  90,    90,  90,//backward leg set 1
         200, 150,  45,    60,  90,    90,  45,   150,  90,    60, 135,    90,  90,  150,  90,    60,  90,    90,  90//forward leg set 2  
        //repeat put leg set 2         
    };
const PROGMEM uint16_t spiderAutoAction2[] = { 
         250,  30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30,  30, 30, 30, 30, 30, 30, 
         250,  90, 90, 90, 90, 90, 90, 30, 30, 30, 30, 30, 30, 150,150,150, 90, 90, 90,
         250,  90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 150,150,150, 90, 90, 90,
         250, 150,150,150,150,150,150, 90, 90, 90, 90, 90, 90,  30, 30, 30, 30, 30, 30, 
         250, 150,150,150,150,150,150,150,150,150,150,150,150,  30, 30, 30, 30, 30, 30, 
         250, 150,150,150,150,150,150, 90, 90, 90, 90, 90, 90, 150,150,150, 90, 90, 90,
         250,  90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 150,150,150, 90, 90, 90,
         250,  90, 90, 90, 90, 90, 90, 30, 30, 30, 30, 30, 30,  30, 30, 30, 30, 30, 30
    };
const PROGMEM uint16_t spiderAutoAction3[]= { 
         2000,   0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 
         2000,  90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90,
         2000, 180,180,180,180,180,180,180,180,180,180,180,180,180,180,180,180,180,180
    };


SpiderAuto::SpiderAuto() //constructor
{
    moveStep  = 0;
    actionType = 0; // no action
}

void SpiderAuto::beginAction(byte actionType)
{ 
    this->actionType = actionType;
    moveStep  = 0;  
}


void SpiderAuto::nextMove()
{  
    int totalSteps=0;
    int stepSize = NumberOfServo+1;
    
    if (actionType=='1') {
        totalSteps = sizeof(spiderAutoAction1)/sizeof(int)/stepSize;
        pMoveTask->tickInterval = (unsigned long)pgm_read_word_near(spiderAutoAction1+moveStep*stepSize)*1000L;
        for (int i=0; i<NumberOfServo; i++) {
            motor.setAngle(i,pgm_read_word_near(spiderAutoAction1+moveStep*stepSize+(i+1)));
        }
        if (++moveStep>=totalSteps) moveStep=0;
    }
    if (actionType=='2') {
        totalSteps = sizeof(spiderAutoAction2)/sizeof(int)/stepSize;
        pMoveTask->tickInterval = (unsigned long)pgm_read_word_near(spiderAutoAction2+moveStep*stepSize)*1000L;
        for (int i=0; i<NumberOfServo; i++) {
            motor.setAngle(i,pgm_read_word_near(spiderAutoAction2+moveStep*stepSize+(i+1)));
        }
        if (++moveStep>=totalSteps) moveStep=0;
    } 
    if (actionType=='3') {
       totalSteps = sizeof(spiderAutoAction3)/sizeof(int)/stepSize;
        pMoveTask->tickInterval = (unsigned long)pgm_read_word_near(spiderAutoAction3+moveStep*stepSize)*1000L;
        for (int i=0; i<NumberOfServo; i++) {
            motor.setAngle(i,pgm_read_word_near(spiderAutoAction3+moveStep*stepSize+(i+1)));
        }
        if (++moveStep>=totalSteps) moveStep=0;
    }
    if (actionType=='R') { //random
        totalSteps = 1;
        pMoveTask->tickInterval = 500*1000L; //500ms
        for (int i=0; i<NumberOfServo; i++) {
            motor.setAngle(i,random(0,180));
        }
        // if (++moveStep>=totalSteps) moveStep=0; //no need
    }
}

