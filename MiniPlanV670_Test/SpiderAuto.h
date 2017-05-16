/*
 *    Module: SpiderAuto.h
 *    Author: Jinn-Kwei Guo
 *    Date: 2016/6/10
 *      
 *    Auto Action for Spider
 *        
 */

#include <Arduino.h>

#ifndef SpiderAuto_h
#define SpiderAutol_h

#include "RTOS.h"

class SpiderAuto {
    public:    
        Task* pMoveTask;        
        byte actionType = 'Z'; //stop

        // methods
        SpiderAuto(); //constructor
        void beginAction(byte actionType);
        void nextMove();

    private:            
        int moveStep  = 0;
};

extern SpiderAuto spiderAuto;

#endif //SpiderAuto

//
// END OF FILE
//

