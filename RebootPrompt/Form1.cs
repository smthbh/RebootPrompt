using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace RebootPrompt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            runTimer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                System.Diagnostics.Process.Start("ShutDown", "/g");
            }
            catch
            {
            }

            Close();
        }

        private void runTimer()
        {
            // SET TIMER UP
            bool bTimer_Expired = false;
            System.Timers.Timer m_theTimer = new System.Timers.Timer();
            m_theTimer.Elapsed += new ElapsedEventHandler(OurTimerCallback);
            const int hrsToMs = 60 * 60 * 1000;
            m_theTimer.Interval = 4 * hrsToMs;
            //---enable 30sec timer below to test
            //m_theTimer.Interval = 30000;
            m_theTimer.Enabled = true;

            //Wait for call back to set flag that the elapsed time has expired
            while (!bTimer_Expired) Thread.Sleep(1000);

            //---->want to wait for 4 hours<------
            // RESUME HERE
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;


            void OurTimerCallback(object source, ElapsedEventArgs e)
            {
                bTimer_Expired = true;
                //Console.WriteLine("Received a callback, the time is {0}", e.SignalTime);
            }
        }
    }
}
