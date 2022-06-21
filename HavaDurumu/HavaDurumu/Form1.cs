using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HavaDurumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string api = "ff5384f572da1653f3f6e115696950fa";
        private void button1_Click(object sender, EventArgs e)
        {
           string key = comboBox1.Text;
           string connection= "http://api.openweathermap.org/data/2.5/weather?q="+key.ToLower()+"&mode=xml&lang=tr&units=metric&appid="+api;
           XDocument weathear = XDocument.Load(connection);
           var temp = weathear.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            double temp2 = Math.Round(Convert.ToDouble(temp.Replace(".", ",")),1);
            var weath = weathear.Descendants("clouds").ElementAt(0).Attribute("name").Value;

            MessageBox.Show(key + " İçin Beklenen sıcaklık " + temp2 + "°C ve " + weath.ToString()+".");
            
        }
    }
}
