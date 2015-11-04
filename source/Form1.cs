using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;
using System.Security.AccessControl;
using System.Timers;

namespace LastFM_Now_Playing
{
    public partial class Form1 : Form
    {
        LFMXml XML = new LFMXml();
        public bool rdyOrNot = false;
        public static System.Timers.Timer aTimer;

        public Form1()
        {
            InitializeComponent();
            //Timer cycle for parsing
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 5000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            changeLabel();
            
            //Path things
            folderPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            savePlace = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            lfmUsername.Text = "mr7kill";
            userName = lfmUsername.Text;
            notifyIcon1.Visible = false; //Tray icon
        }

        public string savePlace = "";
        public string userName = "";
        bool check = false;
        public bool correctName = true;

        public string saveNP(string np, string path)
        {
            string g = np;
            StreamWriter sw = new StreamWriter(path + "\\np.txt");
            
            sw.Write(g);
            sw.Close();
            return "";
        }

        public async Task changeLabel()
        {
            
            await Task.Delay(1000);
            rdyOrNot = false;
            string cod = await CheckName(lfmUsername.Text);
            if (!cod.Equals("6"))
            {
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "Valid";
                startParse.Enabled = true;

            }
            else
            {
                label1.ForeColor = System.Drawing.Color.DarkRed;
                label1.Text = "Invalid";
                startParse.Enabled = false;
            }

        }


        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (check)
            {
                notifyIcon1.Text = XML.RecentTracks(userName);
                saveNP(XML.RecentTracks(userName), savePlace);

            }
        }

        

        public async Task<string> CheckName(string name)
        {
            
            string url = "http://7kill.bl.ee/user-check.php?name=" + name;
            string HtmlText = string.Empty;
            HttpWebRequest myHttwebrequest =  (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();
            return HtmlText;
        }

        void Parsing(string path, string name)
        {
            
            string url = "http://7kill.bl.ee/lfm.php?name=" + userName;
            string HtmlText = string.Empty;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();

            string g = "";
            g = HtmlText;
            StreamWriter sw = new StreamWriter(path + "\\np.txt");
            sw.Write("Now Playing: {0}", g);
            sw.Close();
            notifyIcon1.Text = "Now playing: " + g;
                

        }

        private void getPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.folderPath.Text = folderBrowserDialog1.SelectedPath;
                savePlace = @folderBrowserDialog1.SelectedPath;

            }
        }

        private void startParse_Click(object sender, EventArgs e)
        {
            
            if (parseStatus.Text == "Not parsing")
            {
                check = true;
                parseStatus.ForeColor = System.Drawing.Color.Green;
                userName = lfmUsername.Text;
                parseStatus.Text = "Parsing";
                startParse.Text = "Stop";
                folderPath.Enabled = false;
                lfmUsername.Enabled = false;

            }

            else
            {
                parseStatus.ForeColor = System.Drawing.Color.DarkRed;
                parseStatus.Text = "Not parsing";
                startParse.Text = "Start";
                check = false;
                folderPath.Enabled = true;
                lfmUsername.Enabled = true;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private async void lfmUsername_TextChanged(object sender, EventArgs e)
        {
            if (!rdyOrNot)
            {
                rdyOrNot = true;
                await changeLabel();
            }
        }

        
    }
}
