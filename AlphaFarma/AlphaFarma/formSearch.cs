using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AlphaFarma
{
    public partial class formSearch : Form
    {
        public formSearch()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            StreamWriter arquivo = new StreamWriter(@"C:\Ficheiros\ficheiro.txt", true, Encoding.Default);
            arquivo.WriteLine("Frase de teste 2");
            arquivo.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader ficheiro = new StreamReader(@"C:\Ficheiros\ficheiro.txt");
            ficheiro.ReadToEnd();
            ficheiro.Dispose();
        }
    }
}
