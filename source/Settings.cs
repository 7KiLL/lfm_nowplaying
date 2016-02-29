using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LastFM_Now_Playing.Properties;

namespace LastFM_Now_Playing
{
    public partial class Settings : Form
    {
        NowPlaying np = new NowPlaying();
        public Settings()
        {
            InitializeComponent();
            dividerText.Text = Properties.Settings.Default.divider;
            ReverseStatus.Checked = Properties.Settings.Default.reverse;
            nowplayingUsage.Checked = Properties.Settings.Default.np;
            nowplayingPrefix.Text = Properties.Settings.Default.nowplayingtext;
            lastplayedPrefix.Text = Properties.Settings.Default.lastplayedtext;
            fillEntire.Checked = Properties.Settings.Default.fill;
        }

        

        public void Update(string pre, bool matter)
        {
            var song = "Song";
            var artist = "Artist";


            if (nowplayingUsage.Checked)
            {
                if (!ReverseStatus.Checked)
                {
                    if (!fillEntire.Checked && !matter)
                        label2.Text = pre + artist + dividerText.Text + song;
                    if (!fillEntire.Checked && matter)
                        label2.Text = pre + artist + dividerText.Text + song;
                    if (fillEntire.Checked && matter)
                        label2.Text = pre;
                    if (fillEntire.Checked && !matter)
                        label2.Text = pre + artist + dividerText.Text + song;
                }
                if (ReverseStatus.Checked)
                {
                    if (!fillEntire.Checked && !matter)
                        label2.Text = pre + song + dividerText.Text + artist;
                    if (!fillEntire.Checked && matter)
                        label2.Text = pre + song + dividerText.Text + artist;
                    if (fillEntire.Checked && matter)
                        label2.Text = pre;
                    if (fillEntire.Checked && !matter)
                        label2.Text = pre + song + dividerText.Text + artist;
                }
            }
            if (!nowplayingUsage.Checked)
            {
                if (ReverseStatus.Checked)
                {
                    label2.Text = song + dividerText.Text + artist;
                }

                if (!ReverseStatus.Checked)
                {
                    label2.Text = artist + dividerText.Text + song;
                }
            }

        }


        public  void textBox1_TextChanged(object sender, EventArgs e)
        {
            Update(nowplayingPrefix.Text, false);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Update(nowplayingPrefix.Text, false);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Update(nowplayingPrefix.Text, false);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Update(lastplayedPrefix.Text, true);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Update(lastplayedPrefix.Text, true);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            Update(lastplayedPrefix.Text, true);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            Update(nowplayingPrefix.Text, false);
        }

        private void nowplayingUsage_CheckedChanged(object sender, EventArgs e)
        {
            if (!nowplayingUsage.Checked)
            {
                nowplayingPrefix.Enabled = false;
                lastplayedPrefix.Enabled = false;
                fillEntire.Enabled = false;
            }

            if (nowplayingUsage.Checked)
            {
                nowplayingPrefix.Enabled = true;
                lastplayedPrefix.Enabled = true;
                fillEntire.Enabled = true;
            }
            Update("", false);
            if (nowplayingUsage.Checked)
                Update(nowplayingPrefix.Text, false);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
             
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.divider = dividerText.Text;
            Properties.Settings.Default.reverse = ReverseStatus.Checked;
            Properties.Settings.Default.np = nowplayingUsage.Checked;
            Properties.Settings.Default.nowplayingtext = nowplayingPrefix.Text;
            Properties.Settings.Default.lastplayedtext = lastplayedPrefix.Text;
            Properties.Settings.Default.fill = fillEntire.Checked;
            Properties.Settings.Default.Save();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dividerText.Text = Properties.Settings.Default.divider;
            ReverseStatus.Checked = Properties.Settings.Default.reverse;
            nowplayingUsage.Checked = Properties.Settings.Default.np;
            nowplayingPrefix.Text = Properties.Settings.Default.nowplayingtext;
            lastplayedPrefix.Text = Properties.Settings.Default.lastplayedtext;
            fillEntire.Checked = Properties.Settings.Default.fill;
            Close();
        }

       
    }
}
