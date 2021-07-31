using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StooqParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtStop.Value = DateTime.Now;
            dtStart.Value = DateTime.Now.AddMonths(-1);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

            dgvData.Columns.Clear();
            dgvData.Columns.Add("DATE", "Data notowania");
            dgvData.Columns.Add("CLOSE", "Kurs zamknięcia");
            dgvData.Columns.Add("VOLUME", "Wolumen");

            dgvData.Columns[0].Width = 250;
            dgvData.Columns[1].Width = 180;
            dgvData.Columns[2].Width = 170;

            String ticker = tbTicker.Text.Trim().ToLower();
            String d1 = dtStart.Value.ToString("yyyyMMdd");
            String d2 = dtStop.Value.ToString("yyyyMMdd");
            String url = $"https://stooq.pl/q/d/l/?s={ticker}&d1={d1}&d2={d2}&i=d";
            try
            {
                WebClient webClient = new WebClient();                
                String s = webClient.DownloadString(url);
                string[] lines = s.Split('\n');
                for (int i = 1; i < lines.Length; i++)
                {
                    String[] items = lines[i].Split(',');
                    if (items.Length==6)
                    {
                        // zaraz ladujemy do gridview
                        dgvData.Rows.Add(new string[] { 
                            items[0], items[4], items[5]
                        });
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
