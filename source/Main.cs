using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Threading;
using System.Xml.XPath;
using LastFM_Now_Playing.Properties;

namespace LastFM_Now_Playing
{

    public partial class Main : Form
    {

        LFMXml XML = new LFMXml();
        NowPlaying lfm = new NowPlaying();
        Settings settings = new Settings();
        About about = new About();
       


        public bool Check
        {
            get {return check;}
            set {check = value; }
        }
        public string Lname {
            get { return lfmUsername.Text; }
            set { lfmUsername.Text = value; }
        }

        public Main()
        {
            InitializeComponent();
            //Timer cycle for parsing
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 5000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            
            //Path things
            folderPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            savePlace = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            startParse.Enabled = false;
            userName = lfmUsername.Text;
            notifyIcon1.Visible = false; //Tray icon
            if(Properties.Settings.Default.path!="")
                folderPath.Text = Properties.Settings.Default.path;
            lfmUsername.Text = Properties.Settings.Default.username;
        }

        //Global variables
        public static System.Timers.Timer aTimer;
        public string savePlace = "";
        public string userName = "";
        bool check = false;   

        //Work with NowPlaying file
        public string saveNP(string np, string path)
        {
            var g = np;
            var sw = new StreamWriter(path + "\\np.txt");      
            sw.Write(g);
            sw.Close();
            return "";
        }


        //Now playing update cycle
        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {        
            if (check)
            {
                
                    var nowPlayingText = lfm.Generate(
                        lfmUsername.Text.Trim());

                    if (nowPlayingText.Length >= 63)
                        notifyIcon1.Text = nowPlayingText.Substring(0, 63);
                    else
                        notifyIcon1.Text = nowPlayingText;
                    saveNP(nowPlayingText, savePlace);

            }
        }

        
        //Get an API code of userInfo
        //Maybe I should check code of error node instead of just check lfm status, but it crushes when user is found
        //Possible problems it's different errors because of an API problem, too many API requests from IP etc.
        public async Task CheckName(string name)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromSeconds(100);
            string getResponsestring = "";
            Uri url = new Uri("http://ws.audioscrobbler.com/2.0/?method=user.getInfo&user=" + name + "&api_key=5b801a66d1a34e73b6e563afc27ef06b");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            getResponsestring = await response.Content.ReadAsStringAsync();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(getResponsestring);
            XmlNode root = xmlDoc.DocumentElement;
            string attr = root.SelectSingleNode("/lfm/@status").Value;

            if (attr == "ok")
            {
                startParse.Enabled = true;
                validity.ForeColor = System.Drawing.Color.Green;
                validity.Text = "Valid";
            }

            if (attr == "failed")
            {
                startParse.Enabled = false;
                validity.ForeColor = System.Drawing.Color.DarkRed;
                validity.Text = "Invalid";
            }

        }

        //Getting path to save Now Playing file
        private void getPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.folderPath.Text = folderBrowserDialog1.SelectedPath;
                savePlace = folderBrowserDialog1.SelectedPath;
            }
        }

        //Enable cycle to parse recenttracks, blocks textareas
        private void startParse_Click(object sender, EventArgs e)
        { 
            if (parseStatus.Text == "Not parsing")
            {
                check = true;
                parseStatus.ForeColor = System.Drawing.Color.Green;
                userName = lfmUsername.Text;
                validity.Visible = false;
                parseStatus.Text = "Parsing";
                startParse.Text = "Stop";         
                folderPath.Enabled = false;
                lfmUsername.Enabled = false;
            }

            else
            {
                parseStatus.ForeColor = System.Drawing.Color.DarkRed;
                parseStatus.Text = "Not parsing";
                validity.Visible = true;
                startParse.Text = "Start";
                check = false;
                folderPath.Enabled = true;
                lfmUsername.Enabled = true;
            }
        }

        //Notify icon. Working a bit strange. I'll try to fix it later
        //1.1.0.2 Fixed. Visible attribute have to be deactivated 
        //or you can open window with ALT+Tab combo
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Visible = true;
                notifyIcon1.Visible = false;
            }
        }
        
        //Cheching user async when user typing username
        private async void lfmUsername_TextChanged(object sender, EventArgs e)
        {
                 await CheckName(lfmUsername.Text.Trim());      
        }

        //Saving variables
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.path = folderPath.Text;
            Properties.Settings.Default.username = lfmUsername.Text.Trim();
            Properties.Settings.Default.Save();
        }

        //Open Settings widnow
        private void button1_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }

        //Open About window
        private void btnAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }
    }
}
