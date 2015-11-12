using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Xml;
using LastFM_Now_Playing.Properties;

namespace LastFM_Now_Playing
{
    public partial class Form1 : Form
    {
        LFMXml XML = new LFMXml();
        NowPlaying lfm = new NowPlaying();
        Form2 settings = new Form2();
        Form3 about = new Form3();

        public Form1()
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
            CheckName(lfmUsername.Text);
            userName = lfmUsername.Text;
            notifyIcon1.Visible = false; //Tray icon
            if(Settings.Default.path!="")
                folderPath.Text = Settings.Default.path;
            lfmUsername.Text = Settings.Default.username;
        }

        //Global variables
        public static System.Timers.Timer aTimer;
        public string savePlace = "";
        public string userName = "";
        bool check = false;

        

        

        //Work with NowPlaying file
        public string saveNP(string np, string path)
        {
            string g = np;
            StreamWriter sw = new StreamWriter(path + "\\np.txt");      
            sw.Write(g);
            sw.Close();
            return "";
        }

        //Now playing update cycle
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (check)
            {
                string nowPlayingText = lfm.Generate(lfmUsername.Text, Settings.Default.divider, Settings.Default.reverse,
                    Settings.Default.np, Settings.Default.nowplayingtext, Settings.Default.lastplayedtext,
                    Settings.Default.fill);
                if (nowPlayingText.Length >= 63)
                    notifyIcon1.Text = nowPlayingText.Substring(0, 63);
                else
                    notifyIcon1.Text = nowPlayingText;               
                saveNP(nowPlayingText, savePlace);
            }
        }

        //Get an API code of userInfo
        //Maybe I should check code of error node istead of just check lfm status, but it crushes when user is found
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
                label1.ForeColor = System.Drawing.Color.Green;
                label1.Text = "Valid";
            }

            if (attr == "failed")
            {
                startParse.Enabled = false;
                label1.ForeColor = System.Drawing.Color.DarkRed;
                label1.Text = "Invalid";
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

        //Notify icon. Working a bit strange. I'll try to fix it later
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
        
        //Cheching user async when user typing username
        private async void lfmUsername_TextChanged(object sender, EventArgs e)
        {
                 await CheckName(lfmUsername.Text);      
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.path = folderPath.Text;
            Settings.Default.username = lfmUsername.Text;
            Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }
    }
}
