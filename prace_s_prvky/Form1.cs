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
        List<int> radatemp;

        public void zobrazit(String pole, String min, String max, String min2, String max2, String soucet, String prumer)
        {
            textBox.Text = String.Empty;
            textBox.Text = $"Pole: {pole} {Environment.NewLine}Max: {max} {Environment.NewLine}Min: {min}{Environment.NewLine}Max2: {max2} {Environment.NewLine}Min2: {min2} {Environment.NewLine}Součet: {soucet} {Environment.NewLine}Průměr: {prumer}";
                            
        }

        public void hledat(String indexhledanehocisla)
        {
            var lines = textBox.Text
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                .ToList();

            if (lines.Count >= 8)
                lines.RemoveAt(7);

            lines.Add($"Index hledaného čísla {indexhledanehocisla}");

            textBox.Text = string.Join(Environment.NewLine, lines);
        }

        private void buttonDoit_Click(object sender, EventArgs e)
        {
            if (numericPocet.Value == 0) { return; }

            ciselnarada.Clear();
            String toout = string.Empty; 
            Random rn = new Random();
            for (int i = 0; i < numericPocet.Value; i++)
            {
                ciselnarada.Add(rn.Next(-1000, 1000));
            }

            string outtoutmin2 = "list je moc kratky";
            string outtoutmax2 = "list je moc kratky";

            int soucet = 0;

            radatemp = ciselnarada;
            radatemp.Sort();
            int tooutmin = radatemp[0];
            int tooutmax = radatemp[radatemp.Count() - 1];
            if (!(radatemp.Count() <= 2))
            {
                int tooutmin2 = radatemp[2];
                int tooutmax2 = radatemp[radatemp.Count() - 2];
                outtoutmin2 = Convert.ToString(tooutmin2);
                outtoutmax2 = Convert.ToString(tooutmax2);
            }
            string outtoutmin = Convert.ToString(tooutmin);
            string outtoutmax = Convert.ToString(tooutmax);

            for (int i = 0; i < ciselnarada.Count; i++)
            {
                toout += $"{ciselnarada[i]}, "; 

            }
            toout = toout.Substring(0, toout.Length - 2);

            for (int i = 0; i < ciselnarada.Count; i++)
            {
                soucet += ciselnarada[i];
            }
            string soucetout = Convert.ToString(soucet);

            
            string prumerout = Convert.ToString(Math.Round(Convert.ToDecimal(soucet)/Convert.ToDecimal(ciselnarada.Count), 3));

            zobrazit(toout, outtoutmin, outtoutmax, outtoutmin2, outtoutmax2, soucetout, prumerout);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericPocet_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String hledanyindexout = "";
            int hledanyindex = ciselnarada.IndexOf(Convert.ToInt32(numericHledaneCislo.Value));
            if (hledanyindex == -1) hledanyindexout = "mimo index";
            else hledanyindexout = Convert.ToString(hledanyindex);
            hledat(hledanyindexout);
            
        }
    }
}
