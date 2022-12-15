using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPinfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async private void btnFindInfo_Click(object sender, EventArgs e)
        {
            string ip;
            ip = textBox1.Text;
            using (WebClient wc = new WebClient())
            {
                string text = wc.DownloadString($"https://ipinfo.io/{ip}?token=dacf571233cb41");
                var json = JsonConvert.DeserializeObject(text);
                IPInfo iPInfo = JsonConvert.DeserializeObject<IPInfo>(json.ToString());
                labelIp.Text = $"IP-адрес: {iPInfo.ip}";
                labelCity.Text = $"Город: {iPInfo.city}";
                labelRegion.Text = $"Регион: {iPInfo.region}";
                labelCountry.Text = $"Страна: {iPInfo.country}";
                labelPostal.Text = $"Почтовый индекс: {iPInfo.postal}";
                labelTimeZone.Text = $"Временая зона: {iPInfo.timezone}";
                textBox1.Text = iPInfo.loc;
            }
        }
    }
}
