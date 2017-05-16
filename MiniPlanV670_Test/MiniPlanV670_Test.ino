/*
 *    Spider_Test: Test PWM Control for 18 Servo Motors, 1~16 is controlled PCA9685, 17&18 is controlled by Servo Library
 *    
 *    Note : Each RTOS task must be executed within 1ms (RTOS tick) to generate the correct PWM pulse width.
 */
#include <esp.h> 
#include "RTOS.h"
#include "Spider.h"
#include "ServoPwm.h"
#include "CmdPC.h"
#include "CmdBT.h"
#include "CmdWiFi.h"
#include "SpiderAuto.h"

#define DEBUG_LEVEL 1
//#define USE_WDT
//#define USE_BT

#if defined(USE_BT)
#define   BT_RX  14
#define   BT_TX  12
SoftwareSerial BTSerial(BT_RX, BT_TX);
#endif

Task* pDebugTask; 

void setup() {   
    #if defined(USE_WDT)
    wdt_disable();
    #endif
    
    Serial.begin(57600);        // PC port on Serial        
    delay(100);
    Serial.println("Serial Begin");
    cmdPC.begin(&Serial);
    
    Serial1.begin(57600);
    Serial.println("Serial-1 Begin");

    #if defined(USE_BT)
    BTSerial.begin(9600);  // HC-05 default speed in AT command more    
    Serial.println("BTSerial Begin");
    cmdBT.begin(&BTSerial);
    #endif

    cmdWiFi.begin();
    Serial.println("WiFi Begin");
    
    motor.begin();
    Serial.println("Motor Begin");
        
    // Add tasks to RTOS
    motor.pPwmTask = RTOS.taskManager.addTask(MotorPwmTask, "MotorPwmTask", 20000); //50Hz Pulse, 20ms 
    cmdPC.pGetCommandTask = RTOS.taskManager.addTask(CmdPcTask, "CmdPcTask", 5000); //check input stream every 5ms     
    #if defined(USE_BT)
    cmdBT.pGetCommandTask = RTOS.taskManager.addTask(CmdBtTask, "CmdBtTask", 5000); //check input stream every 5ms 
    #endif
    cmdWiFi.pGetCommandTask = RTOS.taskManager.addTask(CmdWiFiTask, "CmdWiFiTask", 5000); //check input stream every 5ms 
    spiderAuto.pMoveTask = RTOS.taskManager.addTask(SpiderMoveTask, "SpiderMoveTask", 1000000); //move legs every 1s
    pDebugTask = RTOS.taskManager.addTask(DebugTask, "DebugTask", 1000000); //debug
    
    // init()
    RTOS.init();
    #if (DEBUG_LEVEL>0)
    Serial.println(F("RTOS begin")); 
    #endif

    #if defined(USE_WDT)
    wdt_enable(WDTO_1S); //RTOS Task cannot run exceed 1s
    #endif
}

void loop() {
    #if defined(USE_WDT)
    wdt_reset();
    #endif
    RTOS.run(); //Always run th OS
}

void DebugTask()
{
    //Serial1.print(".");
}

void MotorPwmTask()
{
    motor.PwmControl();
    //motor.report();           //cannot report in running mode
    //motor.pPwmTask->report();  //cannot report in running mode
}

void CmdPcTask()
{
    cmdPC.getCommand();  //get command from input stream
    //cmdPC.pGetCommandTask->report();  //cannot report in running mode
}

#if defined(USE_BT)
void CmdBtTask()
{
    cmdBT.getCommand();  //get command from input stream
    //cmdBT.pGetCommandTask->report();  //cannot report in running mode
}
#endif

void CmdWiFiTask()
{
    cmdWiFi.getCommand();  //get command from input stream
    //cmdWiFi.pGetCommandTask->report();  //cannot report in running mode
}

void SpiderMoveTask()
{
    if (spiderAuto.actionType>0) {
        spiderAuto.nextMove();
    }
    //spiderAuto.pMoveTask->report(); //cannot report in running mode
}

