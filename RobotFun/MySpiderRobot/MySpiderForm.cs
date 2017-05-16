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

namespace MySpiderRobot
{
    public partial class MySpiderForm : Form
    {
        HScrollBar[] angleSlider;
        TextBox[] angleValue;
        DataTable commandTable;

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
            angleSlider = new HScrollBar[12];
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

            angleValue = new TextBox[12];
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

            commandTable = new DataTable("Data");
            DataView DataView = new DataView(commandTable);

            gridViewCommand.DataSource = DataView;
            //gridViewCommand.RowHeadersVisible = false;
            //gridViewCommand.ColumnHeadersVisible = false;
            commandTable.Columns.Add(new DataColumn("Time", typeof(int)));
            gridViewCommand.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridViewCommand.Columns[0].Width = 60; 
            for (int i = 1; i <= 12; i++)
            {
                commandTable.Columns.Add(new DataColumn(String.Format("M{0:00}",i), typeof(int)));
                gridViewCommand.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridViewCommand.Columns[i].Width = 60;
            }
        }

        void RefreshPortList()
        {
            string[] ports = SerialPort.GetPortNames();
            cbPortList.Items.Clear();
            cbPortList.Items.Add("Refresh");
            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    cbPortList.Items.Add(port);
                }
                cbPortList.Text = cbPortList.Items[0].ToString(); //預設值
            }
            else
            {
                toolStripMessage.Text = "COM Port not found";
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
                    angleValue[i].Text = ((radioAngle.Checked) ? angleSlider[i].Value : angleToWidth(angleSlider[i].Value)).ToString();
                }
            }
            else if ((id >= 0) && id < angleValue.Count())
            {
                angleValue[id].Text = ((radioAngle.Checked) ? angleSlider[id].Value : angleToWidth(angleSlider[id].Value)).ToString();
            }
            else
            {
                angleValue[id].Text = ((radioAngle.Checked) ? 90 : angleToWidth(90)).ToString();
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
                return ((radioAngle.Checked) ? String.Format("$M{0:00}A{1:000}#", id, angleSlider[id].Value) 
                                             : String.Format("$M{0:00}W{1:0000}#", id,angleToWidth(angleSlider[id].Value)));
            } else {
                return ((radioAngle.Checked) ? String.Format("$M{0:00}A{1:000}#", 90)
                                             : String.Format("$M{0:00}W{1:0000}#", angleToWidth(90)));
            }
        }

        private void sendCommand(String command)
        {
             try
            {
                serialPort.Write(command);
                toolStripMessage.Text = "Command : " + command; //successful
            }
            catch
            {
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 連接埠
            if (btnStart.Text == "Start")
            {
                if (cbPortList.Text == "Refresh")
                {
                    RefreshPortList();
                    toolStripMessage.Text = "Port List is Refreshed";
                    return;
                }
                serialPort = new SerialPort(cbPortList.Text, 9600);
                try
                {
                    serialPort.Open();
                }
                catch 
                {
                    toolStripMessage.Text = "Cannot Open Port";
                    return;
                }
                if (serialPort.IsOpen)
                {
                    hScrollBar0.Enabled = true;
                    hScrollBar1.Enabled = true;
                    hScrollBar2.Enabled = true;
                    hScrollBar3.Enabled = true;
                    hScrollBar4.Enabled = true;
                    hScrollBar5.Enabled = true;
                    hScrollBar6.Enabled = true;
                    hScrollBar7.Enabled = true;
                    hScrollBar8.Enabled = true;
                    hScrollBar9.Enabled = true;
                    hScrollBar10.Enabled = true;
                    hScrollBar11.Enabled = true;
                    hScrollBarTime.Enabled = true;

                    for (int id = 0; id < 12; id++)
                    {
                        sendCommand(motorCommand(id));
                    }

                    btnStart.Text = "Stop";
                    toolStripMessage.Text = "Port is Opened";
                }
                else
                {
                    toolStripMessage.Text = "Port is not Opened";
                    return;
                }
            }
            else if (btnStart.Text == "Stop")
            {
                serialPort.Close();
                serialPort = null;

                hScrollBar0.Enabled = false;
                hScrollBar1.Enabled = false;
                hScrollBar2.Enabled = false;
                hScrollBar3.Enabled = false;
                hScrollBar4.Enabled = false;
                hScrollBar5.Enabled = false;
                hScrollBar6.Enabled = false;
                hScrollBar7.Enabled = false;
                hScrollBar8.Enabled = false;
                hScrollBar9.Enabled = false;
                hScrollBar10.Enabled = false;
                hScrollBar11.Enabled = false;
                hScrollBarTime.Enabled = false;
                timerPlay.Enabled = false;

                btnStart.Text = "Start";
            }
            else
            {
                toolStripMessage.Text = "Start Button Error";
                return;
            } 
        }

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

        private void hScrollBarTime_Scroll(object sender, ScrollEventArgs e)
        {
            Update_UI_Time();
        }

        private void radioAngle_CheckedChanged(object sender, EventArgs e)
        {
            Update_UI_Angle();
        }

        private void radioPulseWidth_CheckedChanged(object sender, EventArgs e)
        {
            Update_UI_Angle();
        }
                
        int SelectedRowIndex = 0;

        private void gridViewCommand_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
            toolStripMessage.Text = "選擇第" + SelectedRowIndex.ToString() + "列";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            commandTable.Rows.Add();
            DataRow row = commandTable.Rows[commandTable.Rows.Count - 1];
            row[0] = Convert.ToInt16(textBoxTime.Text);
            for (int i = 0; i <12; i++)
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

            for (int i = 0; i < 12; i++)
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

            for (int i = 0; i < 12; i++)
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

                btnAddNew.Enabled = false;
                btnDelete.Enabled = false;
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
                btnClear.Enabled = false;
                btnLoad.Enabled = false;
                btnSave.Enabled = false;
                btnSaveArduino.Enabled = false;
                hScrollBar0.Enabled = false;
                hScrollBar1.Enabled = false;
                hScrollBar2.Enabled = false;
                hScrollBar3.Enabled = false;
                hScrollBar4.Enabled = false;
                hScrollBar5.Enabled = false;
                hScrollBar6.Enabled = false;
                hScrollBar7.Enabled = false;
                hScrollBar8.Enabled = false;
                hScrollBar9.Enabled = false;
                hScrollBar10.Enabled = false;
                hScrollBar11.Enabled = false;
                hScrollBarTime.Enabled = false;

                timerPlay.Enabled = true;
            }
            else
            {
                btnPlay.Text = "Play";
                timerPlay.Enabled = false;

                btnAddNew.Enabled = true;
                btnDelete.Enabled = true;
                btnMoveDown.Enabled = true;
                btnMoveUp.Enabled = true;
                btnClear.Enabled = true;
                btnLoad.Enabled = true;
                btnSave.Enabled = true;
                btnSaveArduino.Enabled = true;
                hScrollBar0.Enabled = true;
                hScrollBar1.Enabled = true;
                hScrollBar2.Enabled = true;
                hScrollBar3.Enabled = true;
                hScrollBar4.Enabled = true;
                hScrollBar5.Enabled = true;
                hScrollBar6.Enabled = true;
                hScrollBar7.Enabled = true;
                hScrollBar8.Enabled = true;
                hScrollBar9.Enabled = true;
                hScrollBar10.Enabled = true;
                hScrollBar11.Enabled = true;
                hScrollBarTime.Enabled = true;
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
                for (int column=0; column<12; column++)
                {
                    title += commandTable.Columns[column].ColumnName + ",";
                }
                title += commandTable.Columns[12].ColumnName;
                outfile.WriteLine(title);

                
                foreach (DataRow row in commandTable.Rows)
                {
                    string data = "";
                    for (int column = 0; column < 12; column++)
                    {
                        data += row[column].ToString().Trim() + ",";
                    }
                    data += row[12].ToString().Trim();
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
                    for (int i = 0; i < 12; i++)
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

                outfile.WriteLine("#define Steps" + commandTable.Rows.Count);
                outfile.WriteLine("int spiderMove[]  = {");
                string data;
                for (int row = 0; row < commandTable.Rows.Count; row++ )
                {
                    data = "        ";
                    for (int column = 0; column < 13; column++)
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

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            timerPlay.Enabled = false;  //stop timer to send command

            int lastStep = (playStep - 1 + commandTable.Rows.Count) % commandTable.Rows.Count;
            for (int id = 0; id < 12; id++)
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
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            hScrollBar0.Value = 90;
            hScrollBar1.Value = 90;
            hScrollBar2.Value = 90;
            hScrollBar3.Value = 90;
            hScrollBar4.Value = 90;
            hScrollBar5.Value = 90;
            hScrollBar6.Value = 90;
            hScrollBar7.Value = 90;
            hScrollBar8.Value = 90;
            hScrollBar9.Value = 90;
            hScrollBar10.Value = 90;
            hScrollBar11.Value = 90;
            hScrollBarTime.Value = 25;
            for (int id=0; id<12; id++) {
                Update_UI_Angle(id);
                sendCommand(motorCommand(id));
            }
            Update_UI_Time();
        }
    }
}
