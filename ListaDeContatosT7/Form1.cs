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

namespace ListaDeContatosT7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Um vetor de contatos.
        private Contato[] contatos = new Contato[1];

        private void Escrever(Contato contato)
        {
            StreamWriter escreverEmArquivo = new StreamWriter("Contatos.txt");
            escreverEmArquivo.WriteLine(contatos.Length + 1);
            escreverEmArquivo.WriteLine(contato.Nome);
            escreverEmArquivo.WriteLine(contato.Sobrenome);
            escreverEmArquivo.WriteLine(contato.Telefone);

            for (int i = 0; i < contatos.Length; i++)
            {
                escreverEmArquivo.WriteLine(contatos[i].Nome);
                escreverEmArquivo.WriteLine(contatos[i].Sobrenome);
                escreverEmArquivo.WriteLine(contatos[i].Telefone);
            }

            escreverEmArquivo.Close();
        }

        private void Ler()
        {
            StreamReader lerArquivo = new StreamReader("Contatos.txt");
            contatos = new Contato[Convert.ToInt32(lerArquivo.ReadLine())];

            for (int i = 0; i < contatos.Length; i++)
            {
                contatos[i] = new Contato();
                contatos[i].Nome = lerArquivo.ReadLine();
                contatos[i].Sobrenome = lerArquivo.ReadLine();
                contatos[i].Telefone = lerArquivo.ReadLine();
            }

            lerArquivo.Close();
        }

        // Atualiza a tela do programa com os contatos.
        private void Exibir()
        {
            // Limpa a lista de contatos.
            listBoxContatos.Items.Clear();

            for (int i = 0; i < contatos.Length; i++)
            {
                listBoxContatos.Items.Add(contatos[i].ToString());
            }

        }

        private void LimparFormulario()
        {
            textBoxNome.Text = String.Empty;
            textBoxSobrenome.Text = String.Empty;
            textBoxTelefone.Text = String.Empty;
        }

        private void buttonCriarContato_Click(object sender, EventArgs e)
        {
            // Se os campos não estiverem vazios, criar o objeto de classe Contato
            Contato contato = new Contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;

            // listBoxContatos.Items.Add(contato.ToString());

            Escrever(contato);
            Ler();
            Exibir();
            LimparFormulario();

            // Limpar as caixas de texto para criar um novo contato
            textBoxNome.Clear();
            textBoxSobrenome.Clear();
            textBoxTelefone.Clear();
        }

        private void buttonLimparLista_Click(object sender, EventArgs e)
        {
            // Verificar se há um item selecionado na lista
            if (listBoxContatos.SelectedItem != null)
            {
                // Remover o item selecionado da lista
                listBoxContatos.Items.Remove(listBoxContatos.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um contato para remover.", "Nenhum Contato Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            Exibir();
        }
    }
}
