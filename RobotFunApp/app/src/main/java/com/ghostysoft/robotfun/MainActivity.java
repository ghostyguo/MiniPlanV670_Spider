package com.ghostysoft.robotfun;

import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.InputFilter;
import android.text.Spanned;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private final static String TAG = MainActivity.class.getSimpleName();
    public static RobotService mRobotService;
    private EditText edServerIP, edServerPort;
    private TextView tvMessage;
    private Button btnConnect, btnAction1, btnAction2,btnAction3,btnAction4,btnAction5,btnAction6,btnAction7,btnAction8;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        Intent robotServiceIntent = new Intent(this, RobotService.class);
        bindService(robotServiceIntent, mServiceConnection, BIND_AUTO_CREATE);

        edServerIP = (EditText) findViewById(R.id.edServerIP);
        edServerPort = (EditText) findViewById(R.id.edServerPort);
        tvMessage = (TextView) findViewById(R.id.tvMessage);
        InputFilter[] filters = new InputFilter[1];
        filters[0] = new InputFilter() {
            public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend) {
                if (end > start) {
                    String destTxt = dest.toString();
                    String resultingTxt = destTxt.substring(0, dstart) + source.subSequence(start, end) + destTxt.substring(dend);
                    if (!resultingTxt.matches ("^\\d{1,3}(\\.(\\d{1,3}(\\.(\\d{1,3}(\\.(\\d{1,3})?)?)?)?)?)?")) {
                        return "";
                    } else {
                        String[] splits = resultingTxt.split("\\.");
                        for (int i=0; i<splits.length; i++) {
                            if (Integer.valueOf(splits[i]) > 255) {
                                return "";
                            }
                        }
                    }
                }
                return null;
            }
        };
        edServerIP.setFilters(filters);

        btnConnect = (Button)findViewById(R.id.btnConnect);
        btnConnect .setOnClickListener(new Button.OnClickListener(){
            @Override
            public void onClick(View v) {
                //Toast.makeText(MainActivity.this, "Try Connect", Toast.LENGTH_SHORT).show();
                if (mRobotService!=null) {
                    String IP = edServerIP.getText().toString();
                    String Port = edServerPort.getText().toString();
                    if (mRobotService.ConnectServer(IP,Port)) {
                        Log.d(TAG,"Server Connect OK");
                        tvMessage.setText("Connect to Server OK");
                        //RelayEnabled(true);
                        //btnConnect.setClickable(false);
                        btnConnect.setEnabled(false);
                        edServerIP.setEnabled(false);
                        edServerPort.setEnabled(false);
                        //Sampling();
                    } else {
                        Log.d(TAG,"Server Connect Fail");
                        tvMessage.setText("Connect to Server Failed");
                    }
                } else {
                    Log.d(TAG,"mRobotService is null");
                    tvMessage.setText("Robot Service is null");
                }
            }
        });

        btnAction1= (Button) findViewById(R.id.btnAction1);
        btnAction1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Toast.makeText(MainActivity.this, "Action1", Toast.LENGTH_SHORT).show();
                if (mRobotService!=null) {
                    mRobotService.Send("$S060#");
                }
                tvMessage.setText(mRobotService.netStatus);
            }
        });

        btnAction2= (Button) findViewById(R.id.btnAction2);
        btnAction2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //Toast.makeText(MainActivity.this, "Action2", Toast.LENGTH_SHORT).show();
                if (mRobotService!=null) {
                    mRobotService.Send("$S090#");
                }
                tvMessage.setText(mRobotService.netStatus);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
    
    @Override
    protected void onResume() {
        super.onResume();
        //registerReceiver(mRobotResponseReceiver, makeRobotIntentFilter());
        if (mRobotService != null) {
            //final boolean result = mRobotService.connect(mDeviceAddress);
            //Log.d(TAG, "Connect request result=" + result);
        }
        //displayDeviceInfo();
    }

    @Override
    protected void onPause() {
        super.onPause();
        //unregisterReceiver(mRobotResponseReceiver);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        unbindService(mServiceConnection);
        mRobotService = null;
    }

    // Code to manage Service lifecycle.
    private final ServiceConnection mServiceConnection = new ServiceConnection() {

        @Override
        public void onServiceConnected(ComponentName componentName, IBinder service) {
            Log.d(TAG, "onServiceConnected()");
            mRobotService = ((RobotService.LocalBinder) service).getService();
            if (!mRobotService.initialize()) {
                Log.d(TAG, "Unable to initialize Robot Service");
                Toast.makeText(MainActivity.this, "Robot Service Failed", Toast.LENGTH_SHORT).show();
                finish();
            }
        }

        @Override
        public void onServiceDisconnected(ComponentName componentName) {
            Log.d(TAG, "onServiceDisconnected()");
            mRobotService = null;
        }
    };
}
