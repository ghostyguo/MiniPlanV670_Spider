using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using RobotSystem;

namespace MySpiderRobot
{
    public partial class MySpiderForm : Form
    {
        const int PortNumber = 1234;    //TCPIP port

        HScrollBar[] angleSlider;
        TextBox[] angleValue;
        DataTable commandTable;
        RobotPort Port;

        public MySpiderForm()
        {
            InitializeComponent();
        }
            
        private void MySpiderForm_Load(object sender, EventArgs e)
        {
            RefreshPortList();
            UI_Init();
        }

        void UI_Init()
        {
            angleSlider = new HScrollBar[18];
            angleSlider[0] = hScrollBar0;
            angleSlider[1] = hScrollBar1;
            angleSlider[2] = hScrollBar2;
            angleSlider[3] = hScrollBar3;
            angleSlider[4] = hScrollBar4;
            angleSlider[5] = hScrollBar5;
            angleSlider[6] = hScrollBar6;
            angleSlider[7] = hScrollBar7;
            angleSlider[8] = hScrollBar8;
            angleSlider[9] = hScrollBar9;
            angleSlider[10] = hScrollBar10;
            angleSlider[11] = hScrollBar11;
            angleSlider[12] = hScrollBar12;
            angleSlider[13] = hScrollBar13;
            angleSlider[14] = hScrollBar14;
            angleSlider[15] = hScrollBar15;
            angleSlider[16] = hScrollBar16;
            angleSlider[17] = hScrollBar17;

            angleValue = new TextBox[18];
            angleValue[0] = textBox0;
            angleValue[1] = textBox1;
            angleValue[2] = textBox2;
            angleValue[3] = textBox3;
            angleValue[4] = textBox4;
            angleValue[5] = textBox5;
            angleValue[6] = textBox6;
            angleValue[7] = textBox7;
            angleValue[8] = textBox8;
            angleValue[9] = textBox9;
            angleValue[10] = textBox10;
            angleValue[11] = textBox11;
            angleValue[12] = textBox12;
            angleValue[13] = textBox13;
            angleValue[14] = textBox14;
            angleValue[15] = textBox15;
            angleValue[16] = textBox16;
            angleValue[17] = textBox17;

            commandTable = new DataTable("Data");
            DataView DataView = new DataView(commandTable);

            gridViewCommand.DataSource = DataView;
            //gridViewCommand.RowHeadersVisible = false;
            //gridViewCommand.ColumnHeadersVisible = false;
            commandTable.Columns.Add(new DataColumn("Time", typeof(int)));
            gridViewCommand.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCommand.Columns[0].Width = 60; 
            for (int i = 1; i <= 18; i++)
            {
                commandTable.Columns.Add(new DataColumn(String.Format("M{0:00}",i), typeof(int)));
                gridViewCommand.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridViewCommand.Columns[i].Width = 45;
            }

            setBtnState(false);
        }

        void RefreshPortList()
        {
            string[] ports = SerialPort.GetPortNames();

            toolstripCbSerial.Items.Clear();
            toolstripCbSerial.Items.Add("Refresh");
            toolstripCbSerial.Text = "Refresh"; //toolstripCbSerial.Items[0]
            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    toolstripCbSerial.Items.Add(port);
                }
                toolstripCbSerial.Text = toolstripCbSerial.Items[0].ToString(); //預設值
            }
            else
            {
                toolStripMessage.Text = "COM Port not found";
            }
        }

        void OpenPort()
        {
            if (Port == null)
            {
                toolStripMessage.Text = "Port not exists";
                return;
            }

            if (!Port.IsOpen()) //還沒開啟
            {
                try
                {
                    Port.Open();
                }
                catch
                {
                }
                toolStripMessage.Text = Port.PortStatus;
                if (Port.IsOpen()) // 開啟成功
                {
                    Port.DiscardInBuffer();
                    Port.DiscardOutBuffer();

                    toolstripTbTCPIP.Enabled = false;
                    toolstripCbSerial.Enabled = false;
                    toolstripCbPort.Enabled = false;
                    toolstripBtnStart.Enabled = false;
                    toolstripBtnStop.Enabled = true;
                    toolstripCbSerial.Enabled = false;

                    setBtnState(true);

                    hScrollBarTime.Enabled = true;

                    for (int id = 0; id < 12; id++)
                    {
                        sendCommand(motorCommand(id));
                    }

                    toolStripMessage.Text = "Port is Opened";
                }
                else
                {
                    toolStripMessage.Text = "Port is not Opened";
                    return;
                }
            }
        }

        void ClosePort()
        {
            if (Port == null)
            {
                toolStripMessage.Text = "Port not exists";
                return;
            }

            if (Port.IsOpen()) //已開啟
            {
                try
                {
                    Port.Close();
                }
                catch
                {
                }
                toolStripMessage.Text = Port.PortStatus;
                if (!Port.IsOpen()) // 關閉成功
                {
                    toolstripTbTCPIP.Enabled = true;
                    toolstripCbSerial.Enabled = true;
                    toolstripCbPort.Enabled = true;
                    toolstripBtnStart.Enabled = true;
                    toolstripBtnStop.Enabled = false;
                    toolstripCbSerial.Enabled = true;

                    setBtnState(false);

                    hScrollBarTime.Enabled = false;
                    timerPlay.Enabled = false;
                }
            }
        }

        private int angleToWidth(int angle)
        {
            if (angle>=0 && angle<180) {
                return (angle * 10 + 600);
            } else {
                return 1500; //middle
            }
        }

        private void Update_UI_Angle(int id=-1)
        {
            if (id < 0) //all
            {                
                for (int i = 0; i < angleSlider.Count(); i++)
                {
                    angleValue[i].Text = angleSlider[i].Value.ToString();
                }
            }
            else if ((id >= 0) && id < angleValue.Count())
            {
                angleValue[id].Text = angleSlider[id].Value.ToString();
            }
            else
            {
                angleValue[id].Text = 90.ToString();
            }
        }

        private void Update_UI_Time()
        {
            textBoxTime.Text = (hScrollBarTime.Value * 20).ToString();
        }

        private String motorCommand(int id)
        {
            if ((id >= 0) && id < angleValue.Count())
            {
                return (String.Format("$M{0:00}A{1:000}#", id, angleSlider[id].Value));
            } else {
                return (String.Format("$M{0:00}A{1:000}#", 90));
            }
        }

        private void sendCommand(String command)
        {
             try
            {
                Port.Write(command);
                Port.Flush();
                toolStripMessage.Text = "Command : " + command; //successful
            }
            catch
            {
            }
        }

        private void toolstripCbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolstripCbPort.Text == "Serial")
            {
                toolstripCbSerial.Visible = true;
                toolstripTbTCPIP.Visible = false;
            }
            else if (toolstripCbPort.Text == "TCPIP")
            {
                toolstripCbSerial.Visible = false;
                toolstripTbTCPIP.Visible = true;
            }
            else
            {
                toolStripMessage.Text = "Invalid Port Type";
            }
        }
        private void toolstripCbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //inhinit the user to change the text
        }

        private void toolstripCbSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void toolstripBtnStart_Click(object sender, EventArgs e)
        {
            if (toolstripCbPort.Text == "Serial")
            {
                if (toolstripCbSerial.Text == "Refresh")
                {
                    RefreshPortList();
                    toolStripMessage.Text = "Port List is Refreshed";
                    return;
                }
                else
                {
                    Port = new RobotSerial(toolstripCbSerial.Text, 9600); // To  meterbus
                }
            }
            else if (toolstripCbPort.Text == "TCPIP")
            {
                if (!(RobotSystem.NetTool.IPCheck(toolstripTbTCPIP.Text)))
                {
                    toolStripMessage.Text = "Invalid IP expression";
                    return;
                }
                toolStripMessage.Text = "Connect ...";
                if (RobotSystem.NetTool.PingServer(toolstripTbTCPIP.Text))
                {
                    Port = new RobotWiFi(toolstripTbTCPIP.Text, PortNumber); // To  meterbus    
                }
                else
                {
                    toolStripMessage.Text = "Robot is unrearchable";
                    return;
                }
            }
            else
            {
                toolStripMessage.Text = "Invalid Port Type";
                return;
            }
            OpenPort();
        }

        private void toolstripBtnStop_Click(object sender, EventArgs e)
        {
            ClosePort();
            Port = null;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        #region ScrollBar

        private void hScrollBar0_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(0);
            sendCommand(motorCommand(0));
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(1);
            sendCommand(motorCommand(1));
        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(2);
            sendCommand(motorCommand(2));
        }
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(3);
            sendCommand(motorCommand(3));
        }
        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(4);
            sendCommand(motorCommand(4));
        }
        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(5);
            sendCommand(motorCommand(5));
        }
        private void hScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(6);
            sendCommand(motorCommand(6));
        }
        private void hScrollBar7_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(7);
            sendCommand(motorCommand(7));
        }
        private void hScrollBar8_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(8);
            sendCommand(motorCommand(8));
        }
        private void hScrollBar9_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(9);
            sendCommand(motorCommand(9));
        }
        private void hScrollBar10_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(10);
            sendCommand(motorCommand(10));
        }
        private void hScrollBar11_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(11);
            sendCommand(motorCommand(11));
        }
        private void hScrollBar12_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(12);
            sendCommand(motorCommand(12));
        }
        private void hScrollBar13_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(13);
            sendCommand(motorCommand(13));
        }
        private void hScrollBar14_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(14);
            sendCommand(motorCommand(14));
        }
        private void hScrollBar15_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(15);
            sendCommand(motorCommand(15));
        }
        private void hScrollBar16_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(16);
            sendCommand(motorCommand(16));
        }
        private void hScrollBar17_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Angle(17);
            sendCommand(motorCommand(17));
        }
        private void hScrollBarTime_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Time();
        }

        #endregion
                        
        int SelectedRowIndex = 0;

        private void gridViewCommand_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
            toolStripMessage.Text = "選擇第" + SelectedRowIndex.ToString() + "列";
        }

        private void setBtnState(Boolean state)
        {

            btnAddNew.Enabled = state;
            btnDelete.Enabled = state;
            btnMoveDown.Enabled = state;
            btnMoveUp.Enabled = state;
            btnClear.Enabled = state;
            btnLoad.Enabled = state;
            btnSave.Enabled = state;
            btnSaveArduino.Enabled = state;
            hScrollBarTime.Enabled = state;

            for (int i = 0; i < 18; i++)
            {
                angleSlider[i].Enabled = state;
            }
        }

        #region Button

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            commandTable.Rows.Add();
            DataRow row = commandTable.Rows[commandTable.Rows.Count - 1];
            row[0] = Convert.ToInt16(textBoxTime.Text);
            for (int i = 0; i <18; i++)
            {
                row[i+1] = angleSlider[i].Value;
            }
        }        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            commandTable.Rows[SelectedRowIndex].Delete();
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (SelectedRowIndex == 0)
                return;

            DataRow SourceRow = commandTable.Rows[SelectedRowIndex];
            DataRow TargetRow = commandTable.Rows[SelectedRowIndex - 1];

            for (int i = 0; i < 18; i++)
            {
                try
                {
                    int temp = (int)TargetRow[i];
                    TargetRow[i] = SourceRow[i];
                    SourceRow[i] = temp;
                }
                catch
                {
                    //不理會資料錯誤, 有可能是空白資料引起
                }
            }

            gridViewCommand.Rows[SelectedRowIndex].Selected = false;
            gridViewCommand.Rows[SelectedRowIndex - 1].Selected = true;
            gridViewCommand.CurrentCell = gridViewCommand.Rows[SelectedRowIndex - 1].Cells[0];
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (SelectedRowIndex == commandTable.Rows.Count - 1)
                return;

            DataRow SourceRow = commandTable.Rows[SelectedRowIndex];
            DataRow TargetRow = commandTable.Rows[SelectedRowIndex+1];

            for (int i = 0; i < 18; i++)
            {
                try
                {
                    int temp = (int)TargetRow[i];
                    TargetRow[i] = SourceRow[i];
                    SourceRow[i] = temp;
                }
                catch
                {
                    //不理會資料錯誤, 有可能是空白資料引起
                }
            }
            gridViewCommand.Rows[SelectedRowIndex].Selected = false;
            gridViewCommand.Rows[SelectedRowIndex + 1].Selected = true;
            gridViewCommand.CurrentCell = gridViewCommand.Rows[SelectedRowIndex + 1].Cells[0];
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure?", "Clear All Data",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                commandTable.Clear(); 
            }            
        }

        int playStep = 0;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "Play")
            {
                btnPlay.Text = "Stop";
                playStep = -1;               

                setBtnState(false);
                timerPlay.Enabled = true;
            }
            else
            {
                btnPlay.Text = "Play";
                timerPlay.Enabled = false; 
                
                setBtnState(true);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "save files (*.Spider)|*.Spider|All files (*.*)|*.*"; //設定Filter，過濾檔案
            //dialog.InitialDirectory = "C:";   //設定起始目錄為C:\
            //dialog.InitialDirectory = Application.StartupPath;  //設定起始目錄為程式目錄
            dialog.Title = "Select a save file";    //設定dialog的Title

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter outfile = new StreamWriter(dialog.FileName, false, System.Text.Encoding.Default);

                string title = "";
                for (int column=0; column<18; column++)
                {
                    title += commandTable.Columns[column].ColumnName + ",";
                }
                title += commandTable.Columns[18].ColumnName;
                outfile.WriteLine(title);

                
                foreach (DataRow row in commandTable.Rows)
                {
                    string data = "";
                    for (int column = 0; column < 18; column++)
                    {
                        data += row[column].ToString().Trim() + ",";
                    }
                    data += row[18].ToString().Trim();
                    outfile.WriteLine(data);
                }
                outfile.Dispose();
                outfile.Close();
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "open files (*.Spider)|*.Spider|All files (*.*)|*.*"; //設定Filter，過濾檔案
            //dialog.InitialDirectory = "C:";   //設定起始目錄為C:\
            //dialog.InitialDirectory = Application.StartupPath;  //設定起始目錄為程式目錄
            dialog.Title = "Select a file";    //設定dialog的Title

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader infile = new StreamReader(dialog.FileName);
                string[] stringSeparators = new string[] { "," };

                commandTable.Clear(); 
                String Line;
                infile.ReadLine(); // skip header
                while ((Line = infile.ReadLine()) != null)
                {
                    commandTable.Rows.Add();
                    DataRow row = commandTable.Rows[commandTable.Rows.Count - 1];
                    String[] Item = Line.Split(stringSeparators, StringSplitOptions.None);
                    row[0] = Convert.ToInt16(Item[0]);
                    for (int i = 0; i < 18; i++)
                    {
                        row[i + 1] = Convert.ToInt16(Item[i]);
                    }
                }
                infile.Dispose();
                infile.Close();
            }
        }
        private void btnSaveArduino_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "save files (*.C)|*.C|All files (*.*)|*.*"; //設定Filter，過濾檔案
            //dialog.InitialDirectory = "C:";   //設定起始目錄為C:\
            //dialog.InitialDirectory = Application.StartupPath;  //設定起始目錄為程式目錄
            dialog.Title = "Select a save file";    //設定dialog的Title

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter outfile = new StreamWriter(dialog.FileName, false, System.Text.Encoding.Default);

                outfile.WriteLine("#define Steps " + commandTable.Rows.Count);
                outfile.WriteLine("int spiderMove[]  = {");
                string data;
                for (int row = 0; row < commandTable.Rows.Count; row++ )
                {
                    data = "        ";
                    for (int column = 0; column < 19; column++)
                    {
                        data += String.Format("{0,4},", commandTable.Rows[row][column]);
                    }
                    outfile.WriteLine(data);
                }
                outfile.WriteLine("};");

                outfile.Dispose();
                outfile.Close();
            }
        }

        private void btn0Degree_Click(object sender, EventArgs e)
        {
            for (int id = 0; id < 18; id++)
            {
                angleSlider[id].Value = 0;
                Update_UI_Angle(id);
                //sendCommand(motorCommand(id));
            }
            sendCommand("$S000#");
        }
        private void btn180Degree_Click(object sender, EventArgs e)
        {
            for (int id = 0; id < 18; id++)
            {
                angleSlider[id].Value = 180;
                Update_UI_Angle(id);
                //sendCommand(motorCommand(id));
            }
            sendCommand("$S180#");
        }
        private void btn90Degree_Click(object sender, EventArgs e)
        {
            for (int id = 0; id < 18; id++)
            {
                angleSlider[id].Value = 90;
                Update_UI_Angle(id);
                //sendCommand(motorCommand(id));
            }
            sendCommand("$S090#");
        }

        #endregion

        private void timerPlay_Tick(object sender, EventArgs e)
        {            
            timerPlay.Enabled = false;  //stop timer to send command

            if (Port.IsOpen())
            {
                int dataLen= Port.BytesToRead();
                if (dataLen > 0)
                {
                    byte[] temp = new byte[dataLen];
                    Port.Read(temp, 0, dataLen);
                    string str = System.Text.Encoding.Default.GetString(temp);
                    tbDebug.Text += str;
                }
            }

            if (commandTable.Rows.Count == 0)
            {
                toolStripMessage.Text = "No Steps"; //successful
                btnPlay.Text = "Play";
                setBtnState(true);
                return;
            }

            int lastStep = (playStep - 1 + commandTable.Rows.Count) % commandTable.Rows.Count;
            for (int id = 0; id < 18; id++)
            {
                if (playStep<0) {
                    sendCommand(String.Format("$M{0:00}A{1:000}#", id, commandTable.Rows[0][id+1]));
                }
                else if (commandTable.Rows[playStep][id + 1] != commandTable.Rows[lastStep][id + 1])
                {
                    sendCommand(String.Format("$M{0:00}A{1:000}#", id, commandTable.Rows[playStep][id + 1]));
                }
            }
            if (playStep<0) playStep=0;
            for (int i = 0; i < commandTable.Rows.Count; i++)
            {
                gridViewCommand.Rows[i].Selected = false;
            }
            gridViewCommand.Rows[playStep].Selected = true;
            timerPlay.Interval = Convert.ToInt16(commandTable.Rows[playStep][0]);
            timerPlay.Enabled = true; //restart timer

            if (++playStep >= commandTable.Rows.Count)
            {
                playStep = 0;
            }

            timerPlay.Enabled = true;  //restart timer to send command
        }

    }
}
