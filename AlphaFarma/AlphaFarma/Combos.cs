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
    public partial class Combos : Form
    {
            List<string> listaOrigi;
            string arquivoOrigi;
            List<string> listaManip;
            string arquivoManip;
            List<string> listaCombo;
            string arquivoCombo;
        public Combos()
        {
            InitializeComponent();

            arquivoCombo = @"C:\Ficheiros\Combos.txt";
            listaCombo = new List<string>();
            arquivoOrigi = @"C:\Ficheiros\MedicamentoOrigi.txt";
            listaOrigi = new List<string>();
            arquivoManip = @"C:\Ficheiros\MedicamentoManip.txt";
            listaManip = new List<string>();

            StreamReader lerFichOrigi = new StreamReader(arquivoOrigi, true);
            while (lerFichOrigi.EndOfStream == false)
            {
                listaOrigi.Add(lerFichOrigi.ReadLine());
            }
            lerFichOrigi.Dispose();


            StreamReader lerFichManip = new StreamReader(arquivoManip, true);
            while (lerFichManip.EndOfStream == false)
            {
                listaManip.Add(lerFichManip.ReadLine());
            }
            lerFichManip.Dispose();

            StreamReader lerFichCombo = new StreamReader(arquivoCombo, true);
            while (lerFichCombo.EndOfStream == false)
            {
                listaCombo.Add(lerFichCombo.ReadLine());
            }
            lerFichCombo.Dispose();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < listaOrigi.Count; i++)
                {
                    listBox1.Items.Add(listaOrigi[i]);
                }
            }
            if (radioButton2.Checked)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < listaManip.Count; i++)
                {
                    listBox1.Items.Add(listaManip[i]);
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            listBoxCombo.Items.Clear();
            for (int i = 0; i < listaCombo.Count; i++)
            {
                listBoxCombo.Items.Add(listaCombo[i]);
            }
        }
        public void carregarProComboTxt()
        {
            StreamWriter escreverArq = new StreamWriter(arquivoCombo, false);
            for (int i = 0; i < listaCombo.Count; i++)
            {
                escreverArq.WriteLine(listaCombo[i]);
            }
            escreverArq.Dispose();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool encontrado = true;

            if (txtCodigo1.Text == "")
            {
                MessageBox.Show("Digite o código do primeiro medicamento.");
                return;
            }
            if (txtCodigo2.Text == "")
            {
                MessageBox.Show("Digite o código do segundo medicamento.");
                return;
            }

            if (encontrado == true)
            { 
                        try
                        {


                            int cod1 = Convert.ToInt32(txtCodigo1.Text);
                            int cod2 = Convert.ToInt32(txtCodigo2.Text);

                            string Combo = "Código: " + cod1 + "  +  " + "  Código: " + cod2;
                            listaCombo.Add(Combo);
                            carregarProComboTxt();
                            MessageBox.Show("Cadastrado com sucesso.");

                            txtCodigo1.Text = "";
                            txtCodigo2.Text = "";
                        }
                        catch
                        {
                         if (encontrado)
                            {

                                MessageBox.Show("Digite um código válido.");
                            }
                        }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int linhaSelecionadaPosicao = listBoxCombo.SelectedIndex;

            if (linhaSelecionadaPosicao == -1)
            {
                MessageBox.Show("Selecione o combo.");
                return;
            }
            try
            {
                if (MessageBox.Show("Deseja mesmo deletar " + "?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                listaCombo.RemoveAt(linhaSelecionadaPosicao);
                carregarProComboTxt();
                MessageBox.Show("Removido com sucesso.");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
