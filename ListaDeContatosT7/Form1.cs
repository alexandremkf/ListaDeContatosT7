using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeContatosT7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCriarContato_Click(object sender, EventArgs e)
        {
            // Criar un objeto de classe contato
            Contato contato = new Contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;

            listBoxContatos.Items.Add(contato.ToString());

            // Limpar as caixas de texto, para criar um novo contato
            textBoxNome.Clear();
            textBoxSobrenome.Clear();
            textBoxTelefone.Clear();
        }
    }
}
