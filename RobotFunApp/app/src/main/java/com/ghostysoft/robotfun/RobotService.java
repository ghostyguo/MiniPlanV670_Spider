package com.ghostysoft.robotfun;

import android.app.Service;
import android.content.Intent;
import android.os.Binder;
import android.os.IBinder;
import android.util.Log;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.charset.Charset;

import static java.lang.Class.forName;

public class RobotService extends Service {

    private final static String TAG = RobotService.class.getSimpleName();

    // TODO: Rename actions, choose action names that describe tasks that this
    // IntentService can perform, e.g. ACTION_FETCH_NEW_ITEMS
    public static final String ACTION_RobotConnected = "com.ghostysoft.robotfun.action.RobotsConnected";
    public static final String ACTION_RobotResponse = "com.ghostysoft.robotfun.action.RobotResponse";

    // TODO: Rename parameters
    public static final String EXTRA_PARAM1 = "com.ghostysoft.robotfun.extra.PARAM1";
    public static final String EXTRA_PARAM2 = "com.ghostysoft.robotfun.extra.PARAM2";

    private final int networkTimeout = 3000;

    // Server Parameters
    public Socket clientSocket;
    private OutputStream outputStream;
    private InputStream inputStream;
    InetAddress serverIP;
    int serverPort;
    String netStatus;

    //  Communicaiton Packet
    static byte[] message;
    static byte[] response;

    public RobotService() {
        Log.d(TAG,"RobotService()");
    }

    public class LocalBinder extends Binder {
        RobotService getService() {
            Log.d(TAG,"Binder:getService()");
            return RobotService.this;
        }
    }

    private final IBinder mBinder = new LocalBinder();

    @Override
    public IBinder onBind(Intent intent) {
        // TODO: Return the communication channel to the service.
        //throw new UnsupportedOperationException("Not yet implemented");
        Log.d(TAG,"onBind()");
        return mBinder;
    }

    @Override
    public void onRebind(Intent intent) {
        super.onRebind(intent);
    }

    @Override
    public boolean onUnbind(Intent intent) {
        return super.onUnbind(intent);
    }

    public boolean initialize() {
        Log.d(TAG,"initialize()");
        return true;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        Log.d(TAG, "onCreate()");
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        Log.d(TAG, "onDestroy()");

        try {
            if (outputStream!=null)  outputStream.close();
            if (inputStream!=null) inputStream.close();
            if (clientSocket!=null)  clientSocket.close();
        } catch (Exception e) {
            //當斷線時會跳到catch,可以在這裡寫上斷開連線後的處理
            e.printStackTrace();
            Log.d(TAG, "Socket連線=" + e.toString());
        }
    }

    // Robot Service ------------------------------------------------------------------------------------------------------------------------
    public StringBuilder byteArrayToHex(byte data[]) {
        final StringBuilder strResult = new StringBuilder();
        for (int i=0; i<data.length; i++)
            strResult.append(String.format("%02X ", data[i]));
        return strResult;
    }

    private void broadcastRobotStatus(final String action) {
        Log.d(TAG," broadcastResponse()");
        final Intent intent = new Intent(action);
        sendBroadcast(intent);
    }

    private void broadcastRobotResponse(final String action, final String param1, final String param2) {
        Log.d(TAG," broadcastResponse():str1='"+param1+"', str2='"+param2+"'");
        final Intent intent = new Intent(action);
        intent.putExtra(RobotService.EXTRA_PARAM1, param1);
        intent.putExtra(RobotService.EXTRA_PARAM2, param2);
        sendBroadcast(intent);
    }

    public boolean ConnectServer(String IP, String Port) {
        Log.d(TAG,"handleActionConnect():IP='"+serverIP+", Port="+serverPort);

        try {
            serverIP = InetAddress.getByName(IP);
            serverPort = Integer.parseInt(Port);
        } catch (Exception e) {
            e.printStackTrace();
            Log.d(TAG, "onHandleIntent() Error :  " + e.toString());
            netStatus = "Cannot connect to servver";
            return false;
        }
        startThread(new Thread(connectServerThread));
        return (clientSocket.isConnected());
    }

    void startThread(Thread thread)
    {
        thread.start();
        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public boolean IsServerConnedted() { //throws IOException {
        Log.d(TAG, "ServerIsConnedted()");
        if (clientSocket==null) {
            Log.d(TAG, "ServerIsConnedted(): null clientSocket");
            return false;
        }
        message = new byte[]{0,0,0,0,0,0,0,0};
        try {
            if (clientSocket.isConnected()) {
                outputStream.write(message);
                outputStream.flush();
                netStatus = "Server is connedted";
                return true;
            } else {
                netStatus = "Server is not connected";
            }
        } catch (Exception e) {
            //當斷線時會跳到catch,可以在這裡寫上斷開連線後的處理
            e.printStackTrace();
            Log.d(TAG, "Connection Error :  " + e.toString());
            netStatus = "Server is not reachable";
        }
        try {
            outputStream.close();
            outputStream = null;
            inputStream.close();
            inputStream = null;
            clientSocket.close();
            clientSocket = null;
        } catch (Exception e) {
            e.printStackTrace();
            Log.d(TAG, "Connection Error :  " + e.toString());
            netStatus = "Socket close failed";
        }
        return false;
    }

    public void GetResponse()
    {
        startThread(new Thread(getResponseThread));
    }

    //連結socket伺服器做傳送與接收
    private Runnable connectServerThread = new Runnable() {
        @Override
        public void run() {
            netStatus = "status not defined";
            try {
                Log.d(TAG, "Tyr Connect "+ serverIP + ":" + serverPort);

                clientSocket = new Socket();
                clientSocket.connect(new InetSocketAddress(serverIP, serverPort), networkTimeout);

                if (clientSocket.isConnected()) {
                    //clientSocket.setKeepAlive(true);
                    outputStream = clientSocket.getOutputStream();
                    inputStream = clientSocket.getInputStream();
                    broadcastRobotStatus(RobotService.ACTION_RobotConnected);
                    netStatus = "Socket is connected";
                } else {
                    netStatus = "Cannot connect to server";
                    //throw new SocketException("Cannot connect to servver");
                }
            } catch (Exception e) {
                e.printStackTrace();
                Log.d(TAG, "ConnecServer Thread():  " + e.toString());
                netStatus = "Cannot connect to server";
            }
            Log.d(TAG,netStatus);
        }
    };

    //連結socket伺服器做傳送與接收
    private Runnable getResponseThread=new Runnable(){
        @Override
        public void run() {
            if (clientSocket==null) {
                Log.d(TAG, " getResponseThread(): null clientSocket");
            } else {
                try {
                    clientSocket.setSoTimeout(networkTimeout);
                    if (clientSocket.isConnected()) {
                        // 取得網路訊息
                        response = new byte[inputStream.available()];
                        inputStream.read(response);
                        Log.d(TAG, "getResponseThread():" + byteArrayToHex(response));
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                    Log.d(TAG, " getResponseThread(): Error=" + e.toString());
                }
            }
            //Log.d(TAG,"getResponseThread() exit");
        }
    };

    //連結socket伺服器做傳送與接收
    private Runnable clearResponseThread=new Runnable(){
        @Override
        public void run() {
            if (clientSocket==null) {
                Log.d(TAG, " clearResponseThread(): null clientSocket");
            } else {
                try {
                    clientSocket.setSoTimeout(50);
                    if (clientSocket.isConnected()) {
                        // 取得網路訊息
                        inputStream.read(response);
                        Log.d(TAG, "clearResponseThread():" + byteArrayToHex(response));
                    }
                } catch (Exception e) {
                    //Time out is OK
                    //e.printStackTrace();
                    //Log.d(TAG, " clearResponseThread(): Error=" + e.toString());
                }
            }
            //Log.d(TAG,"clearResponseThread() exit");
        }
    };

    public boolean Send(String command)
    {
        Log.d(TAG, "Send comand:" + command);
        if (clientSocket==null) {
            Log.d(TAG, "Send(): null clientSocket");
            return false;
        }

        boolean ResponseOK = true;
        netStatus = null;

        startThread(new Thread(clearResponseThread)); //clear before send
        try {
            if (clientSocket.isConnected()) {
                outputStream.write(command.getBytes(Charset.forName("UTF-8")));
                outputStream.flush();
                netStatus = "";
            } else {
                netStatus = "Server is not connected";
            }
        } catch (Exception e) {
            e.printStackTrace();
            Log.d(TAG, "Connection Error :  " + e.toString());
            netStatus = "Server is not reachable";
        }

        Log.d(TAG,"call GetResponse()");
        GetResponse();  //not used
        if (response==null) {
            Log.d(TAG,"response null");
            ResponseOK = false;
        } else {
            String strResponse = new String(response, Charset.forName("UTF-8"));
            netStatus = "Send " + command; // + " " + strResponse;
            Log.d(TAG, netStatus);
        }

        return ResponseOK;
    }
}
