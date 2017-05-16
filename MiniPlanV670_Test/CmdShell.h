/*
 *    Module: CmdShell.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Command Shell for Spider
 *        
 */

#include <Arduino.h>
#include "Spider.h"

#ifndef CmdShell_h
#define CmdShell_h

#define   CmdBufferLength        12
#define   Code_OK    "OK"
#define   Code_ERR   "ERR"

class CmdShell {
    public:             
        // methods
        CmdShell(); //constructor          
        int parseCommand(); //interpret the command then execute    
                
    protected:
        char cmdBuffer[CmdBufferLength];
        int  cmdLength=0;
};

#endif //CmdShell_h
//
// END OF FILE
//



