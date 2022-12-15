using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

/*Leia o README
 * Projeto desenvolvido como estudo próprio durante o primeiro período da faculdade IBRATEC
 * Desenvolvimento de um CRUD com arquivos .txt para base de estudos, projeto viável para melhorias.
*/
namespace AlphaFarma
{
    public partial class txtCadastroPE : Form
    {



        public txtCadastroPE()
        {
 
            //if (!File.Exists(@"C:\MedicamentoOrigi.txt"))
            //{
            //    File.Create(@"C:\MedicamentoOrigi.txt");
            //}

            //if (!File.Exists(@"C:\Ficheiros\MedicamentoManip.txt"))
            //{
            //    File.Create(@"C:\MedicamentoManip.txt");
            //}
            //if (!File.Exists(@"C:\Combos.txt"))
            //{
            //    File.Create(@"C:\Combos.txt");
            //}

            InitializeComponent();
            
        }


        private void pesquisaEditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pesquisar add = new Pesquisar();
            add.ShowDialog();
        }


        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroMed add = new CadastroMed();
            add.ShowDialog();

        }

        private void manipuladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroManip add = new CadastroManip();
            add.ShowDialog();
        }

        private void combosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Combos add = new Combos();
            add.ShowDialog();
        }

        private void formTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formSearch add = new formSearch();
            add.ShowDialog();
        }
    }
}
