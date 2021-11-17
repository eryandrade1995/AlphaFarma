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
    public partial class CadastroManip : Form
    {
        List<string> listaManip; // Cria uma lista DE medicamentos
        string arquivoManip;
        public CadastroManip()
        {
            InitializeComponent();
            arquivoManip = @"C:\Ficheiros\MedicamentoManip.txt";
            listaManip = new List<string>();

            StreamReader lerFichPsico = new StreamReader(arquivoManip, true);
            while (lerFichPsico.EndOfStream == false)
            {
                listaManip.Add(lerFichPsico.ReadLine());
            }
            lerFichPsico.Dispose();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            string tipo = "Injetável";
            string tipo2 = "Oral ";
            Random randNum = new Random();

            randNum.Next();
            int id = Convert.ToInt32(randNum.Next(01, 999).ToString());


            if (txtNomenclatura.Text == "")
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }
            if (txtUnd.Text == "")
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }
            if (txtPeso.Text == "")
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }


            try
            {
                if (radioButton1.Checked)
                {

                    string nome = txtNomenclatura.Text;
                    int peso = Convert.ToInt32(txtPeso.Text);
                    int und = Convert.ToInt32(txtUnd.Text);

                    string Psico = tipo + " Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                    listaManip.Add(Psico);
                    carregarproTxt();
                    MessageBox.Show("Cadastrado com sucesso.");

                    txtNomenclatura.Text = "";
                    txtPeso.Text = "";
                    txtUnd.Text = "";
                }
                if (radioButton2.Checked)
                {

                    string nome = txtNomenclatura.Text;
                    int peso = Convert.ToInt32(txtPeso.Text);
                    int und = Convert.ToInt32(txtUnd.Text);

                    string Manip = tipo2 + "      Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                    listaManip.Add(Manip);
                    carregarproTxt();
                    MessageBox.Show("Cadastrado com sucesso.");

                    txtNomenclatura.Text = "";
                    txtPeso.Text = "";
                    txtUnd.Text = "";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public void carregarproTxt()
        {
            StreamWriter escreverArq = new StreamWriter(arquivoManip, false);
            for (int i = 0; i < listaManip.Count; i++)
            {
                escreverArq.WriteLine(listaManip[i]);
            }
            escreverArq.Dispose();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomenclatura.Text = "";
            txtPeso.Text = "";
            txtUnd.Text = "";
        }
    }
}
