using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace prace_s_prvky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> ciselnarada = new List<int>();

        public void zobrazit(String text)
        {
            textBox.Text = $"Pole: {text} {Environment.NewLine}";
                            
        }

        private void buttonDoit_Click(object sender, EventArgs e)
        {
            if (numericPocet.Value == 0) { return; }


            String toot = string.Empty; 
            Random rn = new Random();
            for (int i = 0; i < numericPocet.Value; i++)
            {
                ciselnarada.Add(rn.Next(-100, 100));
            }
            
            for (int i = 0; i < ciselnarada.Count; i++)
            {
                toot += $"{ciselnarada[i]}, "; 

            }
            toot = toot.Substring(0, toot.Length - 2);
            zobrazit(toot);
        }
    }
}
