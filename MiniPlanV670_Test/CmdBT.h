/*
 *    Module: CmdPC.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Command from BT
 *        
 */

#include <Arduino.h>
#include <SoftwareSerial.h>
#include "Spider.h"
#include "RTOS.h"
#include "CmdShell.h"

#ifndef CmdBT_h
#define CmdBT_h

class CmdBT : CmdShell {
    public:             
        Task* pGetCommandTask;   

        // methods
        CmdBT(); //constructor
        void begin(SoftwareSerial* serialPort); 
        void getCommand(); //Task for get command
    private:    
        SoftwareSerial* port;    
};

extern CmdBT cmdBT;

#endif //CmdBT_h
//
// END OF FILE
//
