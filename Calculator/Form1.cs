using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _107860
{
    public partial class Form1 : Form
    {  
        string Operation;
        double ErsteNummer, ZweiteNummer, Ergebnis;
        bool GleichzeichenRichtig, OperatorGedrückt; 
        public Form1()
        {       
            InitializeComponent();
        }

        public void zahl_click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
            {
                textBox.Text = (sender as Button).Text;
            }
            else if (textBox.Text == "Teilen durch 0 ist nicht möglich")
            {
               löschen.PerformClick();
               textBox.Text = (sender as Button).Text;
            }
            else
            {
                textBox.Text += (sender as Button).Text;
            }       
        }
        public void Benable(bool b_enable)
        {
            mal.Enabled = b_enable;
            plus.Enabled = b_enable;
            minus.Enabled = b_enable;
            geteilt.Enabled = b_enable;
            gleichheitszeichen.Enabled = b_enable;
        }      
        private void operator_Click(object sender, EventArgs e)
        {
            Operation = (sender as Button).Text;

            if (OperatorGedrückt == false)
            {
                ErsteNummer = Convert.ToDouble(textBox.Text);
                textBox.Text = "0";
                OperatorGedrückt = true;
            }
                      
        }      
        private void gleichheitszeichen_Click(object sender, EventArgs e)
        {           
            if (GleichzeichenRichtig 
                && OperatorGedrückt == false)
            {              
                switch (Operation)
                {
                    case "+":
                        Ergebnis += ZweiteNummer;
                        break;
                    case "-":
                        Ergebnis -= ZweiteNummer;
                        break;                 
                    case "*":
                        Ergebnis *= ZweiteNummer;
                        break;
                    case "/":
                        Ergebnis /= ZweiteNummer;                                            
                        break;
                }
                textBox.Text = Convert.ToString(Ergebnis);
            }
            else 
            {
                ZweiteNummer = Convert.ToDouble(textBox.Text);
                GleichzeichenRichtig = true;
                switch (Operation)
                {
                    case "+":
                        Ergebnis = ErsteNummer + ZweiteNummer;
                        textBox.Text = Convert.ToString(Ergebnis);
                        break;
                    case "*":
                        Ergebnis = ErsteNummer * ZweiteNummer;
                        textBox.Text = Convert.ToString(Ergebnis);
                        break;
                    case "/":
                        if (ZweiteNummer == 0)
                        {
                            textBox.Text = "Teilen durch 0 ist nicht möglich";
                            Benable(false);
                        }
                        else
                        {
                            Ergebnis = ErsteNummer / ZweiteNummer;
                            textBox.Text = Convert.ToString(Ergebnis);
                        }
                        break;
                    case "-":
                        Ergebnis = ErsteNummer - ZweiteNummer;
                        textBox.Text = Convert.ToString(Ergebnis);
                        break;
                }
            } 
            OperatorGedrückt = false;
        }   
               
        private void komma_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.Contains("."))
            {
                textBox.Text += ".";
            }
        }

        private void eineZahlZurück_Click(object sender, EventArgs e)
        {
           textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);           
        }
        private void löschen_Click(object sender, EventArgs e)
        {
            OperatorGedrückt = false;
            GleichzeichenRichtig = false;
            textBox.Text = "0";
            Ergebnis = 0;
            ErsteNummer = 0;
            ZweiteNummer = 0;
            Benable(true);
        }
       
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text.Length == 0) 
            {
                textBox.Text = "0";
            }
        }

        private void NegativZahlen_Click(object sender, EventArgs e)
        {
            double Negativ = Convert.ToDouble(textBox.Text) * -1;
            textBox.Text = Convert.ToString(Negativ);         
        }
    }
}
