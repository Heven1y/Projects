using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Pogodka
{
    public partial class Form1 : Form
    {
        string answer = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
                WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Omsk&units=metric&appid=8118ed6ee68db2debfaaa5a44c832918");
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";
                WebResponse respons = await request.GetResponseAsync();
                using (Stream s = respons.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }
                respons.Close();
                OpenWether.OpenWether OW = JsonConvert.DeserializeObject<OpenWether.OpenWether>(answer);
                panel1.BackgroundImage = OW.weather[0].Icon;
                label1.Text = OW.weather[0].main;
                label2.Text = OW.weather[0].description;
                label3.Text = "Температура: " + OW.main.Temp.ToString("0.##") + " *C";
                label6.Text = "Скорость: " + OW.wind.speed.ToString() + "m/sek";
                label7.Text = "Направление: " + OW.wind.deg.ToString() + "Grad";
                label4.Text = "Влажность: " + OW.main.humidity.ToString() + "%";
                label5.Text = "Давление: " + ((int)OW.main.Pressure).ToString() + "мм ртут. столб.";
                label9.Text = "Omsk";
                button1.Click += new EventHandler(BTN1_Click);
                checkBox1.CheckedChanged += new EventHandler(checkBox);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void checkBox(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            OpenWether.OpenWether OW = JsonConvert.DeserializeObject<OpenWether.OpenWether>(answer);
            double temp = OW.main.Temp;
            if (checkBox.Checked == true)
            {
                temp = 1.8 * temp + 32;
                label3.Text = "Температура: " + temp.ToString("0.##") + " Fr";
            }
            else
            {
                temp = OW.main.Temp;
                label3.Text = "Температура: " + temp.ToString("0.##") + " *C";
            }
        }
        private async void BTN1_Click(object sender, EventArgs e)
        {
            string Mesto = textBox1.Text;
            if (Mesto == String.Empty)
            {
                Mesto = "Omsk";
            }
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" + Mesto + "&units=metric&appid=8118ed6ee68db2debfaaa5a44c832918");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            try
            {
                WebResponse respons = await request.GetResponseAsync();
                using (Stream s = respons.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }
                respons.Close();
                OpenWether.OpenWether OW = JsonConvert.DeserializeObject<OpenWether.OpenWether>(answer);
                panel1.BackgroundImage = OW.weather[0].Icon;
                label1.Text = OW.weather[0].main;
                label2.Text = OW.weather[0].description;
                label3.Text = "Температура: " + OW.main.Temp.ToString("0.##") + "*C";
                label6.Text = "Скорость: " + OW.wind.speed.ToString() + "m/sek";
                label7.Text = "Направление: " + OW.wind.deg.ToString() + "Grad";
                label4.Text = "Влажность: " + OW.main.humidity.ToString() + "%";
                label5.Text = "Давление: " + ((int)OW.main.Pressure).ToString() + "мм ртут. столб.";
                label9.Text = Mesto;
            }
            catch (Exception exp)
            {
                label1.Text = "Неизвестно";
                label2.Text = "Неизвестно";
                label3.Text = "Температура: " + "Неизвестно";
                label6.Text = "Скорость: " + "Неизвестно";
                label7.Text = "Направление: " + "Неизвестно";
                label4.Text = "Влажность: " + "Неизвестно";
                label5.Text = "Давление: " + "Неизвестно";
                label9.Text = "Выбрано неизвестное местоположение";
            }
        }
    }
}
