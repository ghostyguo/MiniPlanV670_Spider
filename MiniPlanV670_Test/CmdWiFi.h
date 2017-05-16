/*
 *    Module: CmdWiFi.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2017/5/10
 *      
 *    Command from WiFi
 *        
 */

#include <Arduino.h>
#include <ESP8266WiFi.h>
#include "Spider.h"
#include "RTOS.h"
#include "CmdShell.h"

#ifndef CmdWiFi_h
#define CmdWiFi_h

class CmdWiFi : CmdShell {
    public:             
        Task* pGetCommandTask;   
        
        // methods
        CmdWiFi(); //constructor
        void begin(); 
        void getCommand(); //Task for get command
};

extern CmdWiFi cmdWiFi;

#endif //CmdWiFi_h
//
// END OF FILE
//
