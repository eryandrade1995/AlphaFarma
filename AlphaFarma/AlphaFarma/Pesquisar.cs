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
    public partial class Pesquisar : Form
    {
        List<string> listaOrigi;
        string arquivoOrigi;
        List<string> listaManip;
        string arquivoManip;
        List<string> listaCombo;
        string arquivoCombo;
        public Pesquisar()
        {
            InitializeComponent();
            arquivoOrigi = @"C:\Ficheiros\MedicamentoOrigi.txt";
            listaOrigi = new List<string>();
            arquivoManip = @"C:\Ficheiros\MedicamentoManip.txt";
            listaManip = new List<string>();
            arquivoCombo = @"C:\Ficheiros\Combos.txt";
            listaCombo = new List<string>();

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                listBoxOrigi.Items.Clear();
                for (int i = 0; i < listaOrigi.Count; i++)
                {
                    listBoxOrigi.Items.Add(listaOrigi[i]);
                }
            }
            if (radioButton4.Checked)
            {
                listBoxOrigi.Items.Clear();
                for (int i = 0; i < listaManip.Count; i++)
                {
                    listBoxOrigi.Items.Add(listaManip[i]);
                }
            }
        }
        public void carregarOrigiProTxt()
        {
            StreamWriter escreverArq = new StreamWriter(arquivoOrigi, false);
            for (int i = 0; i < listaOrigi.Count; i++)
            {
                escreverArq.WriteLine(listaOrigi[i]);
            }
            escreverArq.Dispose();
        }

        public void carregarProTxt()
        {
            StreamWriter escreverArq = new StreamWriter(arquivoManip, false);
            for (int i = 0; i < listaManip.Count; i++)
            {
                escreverArq.WriteLine(listaManip[i]);
            }
            escreverArq.Dispose();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //bool verdadeiro = true;
            //while (verdadeiro == true)
            //{
                int linhaSelecionadaPosicao = listBoxOrigi.SelectedIndex;
                if (linhaSelecionadaPosicao == -1)
                {
                    MessageBox.Show("Selecione o medicamento.");
                    return;
                }
                try
                {
                    bool listaExiste = false;
                for (int i = 0; i < listaCombo.Count; i++)
                {
                    if (listaCombo[i].Contains(arquivoOrigi))
                    {
                        MessageBox.Show("Não é possivel deletar, pois ja está cadastrado em um combo.");
                        listaExiste = true;
                        return;
                    }
                }
                        if (listaExiste == false)
                        {


                            try
                            {
                                if (MessageBox.Show("Deseja mesmo deletar " + "?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                                listaOrigi.RemoveAt(linhaSelecionadaPosicao);
                                carregarOrigiProTxt();
                                MessageBox.Show("Removido com sucesso.");
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                


                //int linhaSelecionadaPosicao2 = listBoxOrigi.SelectedIndex;
                //if (linhaSelecionadaPosicao2 == -1)
                //{
                //    MessageBox.Show("Selecione o medicamento.");
                //    return;
                //}
                //try
                //{
                //    bool listaExiste2 = false;
                //    for (int i = 0; i < listaCombo.Count; i++)
                //    {
                //        if (listaCombo[i].Contains(arquivoManip))
                //        {

                //            listaExiste2 = false;
                //            MessageBox.Show("Não é possivel deletar, pois ja está cadastrado em um combo.");
                //            return;

                //        }
                //    }
                //    if (listaExiste2 == true)
                //    {

                //        try
                //        {
                //            if (MessageBox.Show("Deseja mesmo deletar " + "?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                //            {
                //                return;
                //            }
                //            listaManip.RemoveAt(linhaSelecionadaPosicao2);
                //            carregarProTxt();
                //            MessageBox.Show("Removido com sucesso.");
                //        }
                //        catch (Exception err)
                //        {
                //            MessageBox.Show(err.Message);
                //        }
                //    }
                //}
                //catch (Exception err)
                //{
                //    MessageBox.Show(err.Message);
                //}
                //verdadeiro = false;
           // }
        }
    
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int linhaSelecionadaPosicao = listBoxOrigi.SelectedIndex;
            var tipo = "Injetável";
            var tipo2 = "Oral";

            if (radioButton4.Checked)
            {

            
                if(txtCodigo.Text == "")
                {
                    MessageBox.Show("Digite o ID que deseja editar");
                }

                for (int i = 0; i < listaManip.Count; i++)
                {
                    bool codigoExiste = false;
                    if (listaManip[i].Contains(txtCodigo.Text))
                    {
                        codigoExiste = false;

                        if (checkBox1.Checked)
                        {

                            try
                            {

                                int id = Convert.ToInt32(txtCodigo.Text);
                                string nome = txtNomenclatura.Text;
                                int und = Convert.ToInt32(txtUnd.Text);
                                int peso = Convert.ToInt32(txtPeso.Text);

                                string novoMed = tipo + " Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                                listaManip[linhaSelecionadaPosicao] = novoMed;
                                carregarProTxt();
                                MessageBox.Show("Editado com sucesso.");
                            }

                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            if (codigoExiste == true)
                            {
                                MessageBox.Show("O código não existe no cadastro.");
                                return;
                            }
                        }


                        if (checkBox2.Checked)
                        {
                            try
                            {

                                int id = Convert.ToInt32(txtCodigo.Text);
                                string nome = txtNomenclatura.Text;
                                int und = Convert.ToInt32(txtUnd.Text);
                                int peso = Convert.ToInt32(txtPeso.Text);

                                string novoMed = tipo2 + "      Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                                listaManip[linhaSelecionadaPosicao] = novoMed;
                                carregarProTxt();
                                MessageBox.Show("Editado com sucesso.");
                            }

                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            if (codigoExiste == true)
                            {
                                MessageBox.Show("O código não existe no cadastro.");
                                return;
                            }

                        }
                    }
                }
            }
            if (radioButton3.Checked)
            {
                    if (linhaSelecionadaPosicao == -1)
                    {
                        MessageBox.Show("Selecione o medicamento.");
                        return;

                    }
                for (int i = 0; i < listaOrigi.Count; i++)
                {
                    bool codigoExiste = false;

                    if (listaOrigi[i].Contains(txtCodigo.Text))
                    {
                        codigoExiste = false;

                        if (checkBox1.Checked)
                        {

                            try
                            {

                                int id = Convert.ToInt32(txtCodigo.Text);
                                string nome = txtNomenclatura.Text;
                                int und = Convert.ToInt32(txtUnd.Text);
                                int peso = Convert.ToInt32(txtPeso.Text);

                                string novoMed = tipo + " Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                                listaOrigi[linhaSelecionadaPosicao] = novoMed;
                                carregarOrigiProTxt();
                                MessageBox.Show("Editado com sucesso.");
                            }

                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            if (codigoExiste == true)
                            {
                                MessageBox.Show("O código não existe no cadastro.");
                                return;
                            }
                        }


                        if (checkBox2.Checked)
                        {
                            try
                            {

                                int id = Convert.ToInt32(txtCodigo.Text);
                                string nome = txtNomenclatura.Text;
                                int und = Convert.ToInt32(txtUnd.Text);
                                int peso = Convert.ToInt32(txtPeso.Text);

                                string novoMed = tipo2 + "      Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

                                listaOrigi[linhaSelecionadaPosicao] = novoMed;
                                carregarOrigiProTxt();
                                MessageBox.Show("Editado com sucesso.");
                            }

                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            if (codigoExiste == true)
                            {
                                MessageBox.Show("O código não existe no cadastro.");
                                return;
                            }
                        }
                    }
                }

            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            int linhaSelecionadaPosicao = listBoxOrigi.SelectedIndex;
            if (linhaSelecionadaPosicao == -1)
            {
                MessageBox.Show("Selecione o medicamento.");
                return;
            }
            try
            {
                bool listaExiste2 = false;
                for (int i = 0; i < listaCombo.Count; i++)
                {
                    if (listaCombo[i].Contains(arquivoManip))
                    {

                        listaExiste2 = true;
                        MessageBox.Show("Não é possivel deletar, pois ja está cadastrado em um combo.");
                        return;

                    }
                }
                if (listaExiste2 == false)
                {

                    try
                    {
                        if (MessageBox.Show("Deseja mesmo deletar " + "?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                        listaManip.RemoveAt(linhaSelecionadaPosicao);
                        carregarProTxt();
                        MessageBox.Show("Removido com sucesso.");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;

            }
        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int linhaSelecionadaPosicao = listBoxOrigi.SelectedIndex;
        //    var tipo = "Injetável";
        //    var tipo2 = "Oral";

        //    bool codigoExiste = false;

        //    if (txtCodigo.Text == "")
        //    {
        //        MessageBox.Show("Digite o ID que deseja editar");
        //        txtCodigo.Focus();
        //    }

        //    for (int i = 0; i < listaManip.Count; i++)
        //    {
        //        if (listaManip[i].Contains(txtCodigo.Text))
        //        {
        //            codigoExiste = true;
        //        }
        //    }
        //    if (codigoExiste == false)
        //    {
        //        MessageBox.Show("Esse código é diferente do selecionado");
        //        return;
        //    }

        //    for (int i = 0; i < listaManip.Count; i++)
        //    {
        //        if (listaManip[i].Contains(txtCodigo.Text))
        //        {
        //            if (linhaSelecionadaPosicao == -1)
        //            {
        //                MessageBox.Show("Selecione o medicamento.");
        //                return;
        //            }

        //            if (radioButton1.Checked)
        //            {
        //                try
        //                {

        //                    int id = Convert.ToInt32(txtCodigo.Text);
        //                    string nome = txtNomenclatura.Text;
        //                    int und = Convert.ToInt32(txtUnd.Text);
        //                    int peso = Convert.ToInt32(txtPeso.Text);

        //                    string novoMed = tipo + " Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

        //                    listaManip[linhaSelecionadaPosicao] = novoMed;
        //                    carregarProTxt();
        //                    MessageBox.Show("Editado com sucesso.");
        //                }

        //                catch (Exception err)
        //                {
        //                    MessageBox.Show(err.Message);
        //                }
        //            }
        //            if (radioButton2.Checked)
        //            {
        //                try
        //                {

        //                    int id = Convert.ToInt32(txtCodigo.Text);
        //                    string nome = txtNomenclatura.Text;
        //                    int und = Convert.ToInt32(txtUnd.Text);
        //                    int peso = Convert.ToInt32(txtPeso.Text);

        //                    string novoMed = tipo2 + "      Código: " + id + "  Nomenclatura: " + nome + " Und: " + und + "  Peso: " + peso;

        //                    listaManip[linhaSelecionadaPosicao] = novoMed;
        //                    carregarProTxt();
        //                    MessageBox.Show("Editado com sucesso.");
        //                }

        //                catch (Exception err)
        //                {
        //                    MessageBox.Show(err.Message);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}








