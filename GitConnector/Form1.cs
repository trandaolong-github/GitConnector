using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GitConnector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            //if (path )
            string cmd = "/C cd " + path + "&" + path.Substring(0, 2);
            string gitadd = "& git add .";
            string gitcommit = "& git commit -m " + '"' + textBox2.Text + '"';
            string gitpush = "& git push origin HEAD";
            cmd += (gitadd + gitcommit + gitpush);
            label2.Text = "";
            if (textBox2.Text == "")
            {
                label2.Text = "Commit message is required to push data";
                if (label2.ForeColor != System.Drawing.Color.Red)
                {
                    label2.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //System.Diagnostics.Process.Start("CMD.exe", cmd);
                using (Process gitProcess = Process.Start("CMD.exe", cmd))
                {
                    gitProcess.WaitForExit();
                    if (gitProcess.ExitCode != 0)
                    {
                        label2.Text = "Error while pushing data";
                        if (label2.ForeColor != System.Drawing.Color.Red)
                        {
                            label2.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        label2.Text = "SUCCESS";
                        if (label2.ForeColor != System.Drawing.Color.Green)
                        {
                            label2.ForeColor = System.Drawing.Color.Green;
                        }
                    }    
                }
            }    
        }
    }
}
