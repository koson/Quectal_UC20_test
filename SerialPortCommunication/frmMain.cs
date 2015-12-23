using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;
namespace PCComm
{
    public partial class frmMain : Form
    {
        CommunicationManager comm = new CommunicationManager();        
        string transType = string.Empty;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           LoadValues();
           SetDefaults();
           SetControlState();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            comm.PortName = cboPort.Text;
            comm.Parity = cboParity.Text;
            comm.StopBits = cboStop.Text;
            comm.DataBits = cboData.Text;
            comm.BaudRate = cboBaud.Text;
            comm.DisplayWindow = rtbDisplay;
            comm.OpenPort();

            if (true == comm.isPortOpen)
            {
                cmdOpen.Enabled = false;
                cmdClose.Enabled = true;
                cmdSend.Enabled = true;
                txtSend.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;

            }

            if (false == comm.isPortOpen)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }

        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "115200";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            rdoText.Checked = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            sendData();
        }

        private void sendData()
        {
            comm.WriteData(txtSend.Text.ToUpper());
            txtSend.SelectAll();
        }

        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHex.Checked == true)
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Hex;
            }
            else
            {
                comm.CurrentTransmissionType = PCComm.CommunicationManager.TransmissionType.Text;
            }
        }

        private void chkBoxEOL_CheckedChanged(object sender, EventArgs e)
        {
            comm.AutoEOL = chkBoxEOL.Checked;
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                sendData();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();
            if (false == comm.isPortOpen)
            {
                cmdOpen.Enabled = true;
                cmdClose.Enabled = false;
                cmdSend.Enabled = false;
                txtSend.Enabled = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }

            if (true == comm.isPortOpen)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmAbout = new AboutBox();
            frmAbout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+CSQ" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "ATI" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+GMI" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+GMM" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+GMR" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+GSN" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+COPS?" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+CMGF=1" + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text =  "AT+CMGL=\"ALL\""  + Environment.NewLine;
            cmdSend_Click(null, null);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!(comm.isPortOpen == true))
                return;
            txtSend.Text = "AT+CMGD="+ txtSMSNo.Text + Environment.NewLine;
            cmdSend_Click(null, null);
        }
    }
}