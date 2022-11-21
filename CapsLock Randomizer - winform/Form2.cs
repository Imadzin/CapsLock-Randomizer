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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            config.ConfigLoad();
            textBox1.Text = config.interval.ToString();
            textBox2.Text = config.MinInterval.ToString();
            textBox3.Text = config.MaxInterval.ToString();

            if (!config.VariableIntervalEnabled)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }else
            {
                radioButton1.Checked = !true;
                radioButton2.Checked = !false;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                config.VariableIntervalEnabled = false;
            }else
            {
                config.VariableIntervalEnabled = true;
            }



            if (int.TryParse(textBox1.Text, out int tmp))
            {
                config.interval = tmp;
            }

            if (int.TryParse(textBox2.Text, out int tmp1))
            {
                config.MinInterval = tmp1;
            }

            if (int.TryParse(textBox3.Text, out int tmp2))
            {
                config.MaxInterval = tmp2;
            }


            config.ConfigRefresh();
            config.ConfigLoad();




            textBox1.Text = config.interval.ToString();
            textBox2.Text = config.MinInterval.ToString();
            textBox3.Text = config.MaxInterval.ToString();

            label3.ForeColor = Color.Green;
            label3.Text = "ULOŽENO";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            config.DefaultConfig();
            textBox1.Text = config.interval.ToString();
            textBox2.Text = config.MinInterval.ToString();
            textBox3.Text = config.MaxInterval.ToString();

            label3.ForeColor = Color.DarkRed;
            label3.Text = "OBNOVENO";
        }

        


      

    }
}
