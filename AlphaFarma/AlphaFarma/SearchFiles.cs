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

public partial class SearchDirectionHint
{
    List<string> listaPsico;
    string arquivoPsico;
    List<string> listaManip;
    string arquivoManip;

    public Search()
    {
        InitializeComponent();
        arquivoPsico = @"C:\Ficheiros\Medicamento.txt";
        listaPsico = new List<string>();
        arquivoManip = @"C:\Ficheiros\MedicamentoManip.txt";
        listaManip = new List<string>();

        StreamReader lerFichPsico = new StreamReader(arquivoPsico, true);
        while (lerFichPsico.EndOfStream == false)
        {
            listaPsico.Add(lerFichPsico.ReadLine());
        }
        lerFichPsico.Dispose();


        StreamReader lerFichManip = new StreamReader(arquivoManip, true);
        while (lerFichManip.EndOfStream == false)
        {
            listaManip.Add(lerFichManip.ReadLine());
        }
        lerFichManip.Dispose();

    }
}