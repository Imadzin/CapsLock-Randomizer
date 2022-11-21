using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLock_Randomizer___winform
{
    public partial class Form1 : Form
    {


        public static int TMPinterval;
        public static int pocitadlo;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            config.ConfigTest();

            config.ConfigLoad();


            if (config.VariableIntervalEnabled)
            {
                Random rnd = new Random();
                TMPinterval = rnd.Next(config.MinInterval, config.MinInterval);
            }
            


            timer1.Enabled = true;

            label1.Text = "Aktivní";
            label1.ForeColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            label1.Text = "Neaktivní";
            label1.ForeColor = Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
          


            if (!config.VariableIntervalEnabled)
            {
                if (pocitadlo <= config.interval)
                {
                    pocitadlo++;
                    SendKeys.Send("{CAPSLOCK}");
                    radioButton1.Checked = true;
                }
                else if (pocitadlo >= 2 * config.interval)
                {
                    pocitadlo = 0;
                }
                else
                {
                    pocitadlo++;
                    radioButton1.Checked = false;
                }
            }else
            {
                if (pocitadlo <= TMPinterval)
                {
                    pocitadlo++;
                    SendKeys.Send("{CAPSLOCK}");
                    radioButton1.Checked = true;
                }
                else if (pocitadlo >= 2 * TMPinterval)
                {
                    TMPinterval = rnd.Next(config.MinInterval, config.MaxInterval);
                    pocitadlo = 0;
                }
                else
                {
                    pocitadlo++;
                    radioButton1.Checked = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            config.ConfigTest();

            config.ConfigLoad();

            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
