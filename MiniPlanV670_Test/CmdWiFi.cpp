/*
 *    Module: CmdWiFi.cpp
 *    Author: Jinn-Kwei Guo
 *    Date: 2017/5/10
 *      
 *    Command from WiFi
 *        
 */ 

#include "CmdWiFi.h"

#define   PortNumber   1234

const char *ssid = "SpiderRobot";
const char *password = "12345678";
CmdWiFi cmdWiFi;  //External

WiFiServer server(PortNumber);
WiFiClient serverClient;

CmdWiFi::CmdWiFi()  //constructor
{
}

void CmdWiFi::begin()
{    
    delay(1000);  //wait
    WiFi.mode(WIFI_AP);
    WiFi.softAP(ssid, password);
    Serial.print("server IP=");
    Serial.println(WiFi.softAPIP());
    
    server.begin();
    server.setNoDelay(true);
}

void CmdWiFi::getCommand() 
{
    if (server.hasClient()) { // new client
        if (!serverClient || !serverClient.connected()) {
            if(serverClient) serverClient.stop();
            serverClient = server.available();
            Serial.println("New TCP client"); 
        }
        //no free/disconnected spot so reject
        //server.available().stop();
    }
    
    //check clients for data
    if (serverClient && serverClient.connected()) {
        while(serverClient.available()) { //has data
            byte inByte = serverClient.read();
            if (inByte=='$') { // Start Of Command
                cmdLength=0;
            }
            cmdBuffer[cmdLength++] = inByte;
            if (inByte=='#') {  // End Of Command
                if (parseCommand()>0) { // success
                    //serverClient.println(Code_OK); //correct
                    Serial.println(Code_OK); //debug
                } else if (parseCommand()<0) {  //fail
                   //serverClient.println(Code_ERR); //correct
                   Serial.println(Code_ERR); //debug
                } else {  //no command                
                }
            } //if (inByte=='#')  
        } //while(serverClient.available())
    } //if (serverClient && serverClient.connected())
}


