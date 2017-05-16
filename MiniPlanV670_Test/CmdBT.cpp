/*
 *    Module: CmdBT.cpp
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Command from PC
 *        
 */ 

#include "CmdBT.h"

CmdBT cmdBT;  //External

CmdBT::CmdBT()  //constructor
{
}

void CmdBT::begin(SoftwareSerial* serialPort)
{
    port = serialPort;
}

void CmdBT::getCommand() 
{
    while (port->available()) {
        byte inByte = port->read();
        if (inByte=='$') { // Start Of Command
            cmdLength=0;
        }
        cmdBuffer[cmdLength++] = inByte;
        if (inByte=='#') {  // End Of Command
            if (parseCommand()>0) { // success
                port->println(Code_OK);
            } else if (parseCommand()<0) {  //fail
                port->println(Code_ERR);
            } else {  //no command
                
            }
        } 
    }
}



