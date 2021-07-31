using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoToZaPlik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();
            if (result==DialogResult.OK)
            {
                lFileName.Text = ofd.FileName;

                lFileName.Visible = true;
                lbInfo.Items.Clear();

                FileInfo fileInfo = new FileInfo(ofd.FileName);
                lbInfo.Items.Add($"nazwa:{fileInfo.Name}");
                lbInfo.Items.Add($"rozmiar:{fileInfo.Length}");
                lbInfo.Items.Add($"folder:{fileInfo.DirectoryName}");
                lbInfo.Items.Add($"roszerzenie:{fileInfo.Extension}");
                lbInfo.Items.Add($"atrybuty:{fileInfo.Attributes}");
                lbInfo.Items.Add($"czas kreacji:{fileInfo.CreationTime}");
                lbInfo.Items.Add($"czas ostatniego dostepu:{fileInfo.LastAccessTime}");
                lbInfo.Items.Add($"czas ostatniej modyf.:{fileInfo.LastWriteTime}");                    
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lFileName.Visible = false;
        }
    }
}
