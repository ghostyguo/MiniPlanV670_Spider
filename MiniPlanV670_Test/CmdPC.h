/*
 *    Module: CmdPC.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Command from PC
 *        
 */

#include <Arduino.h>
#include <HardwareSerial.h>
#include "Spider.h"
#include "RTOS.h"
#include "CmdShell.h"

#ifndef CmdPC_h
#define CmdPC_h

class CmdPC : CmdShell {
    public:             
        Task* pGetCommandTask;   

        // methods
        CmdPC(); //constructor
        void begin(HardwareSerial* serialPort); 
        void getCommand(); //Task for get command
    private:    
        HardwareSerial* port;    
};

extern CmdPC cmdPC;

#endif //CmdPC_h
//
// END OF FILE
//
