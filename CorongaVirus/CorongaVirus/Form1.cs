using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorongaVirus
{
    public partial class Form1 : Form
    {
        public String nome, sexo, idade, origem, temperatura;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnResumo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 tela = new Form2();
            tela.Show();
        }

        private void txNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            nome = txNome.Text;
            sexo = txSexo.Text;
            idade = txIdade.Text;
            origem = txOrigem.Text;
            temperatura = txTemperatura.Text;

            AdicionaRegistro();

            txNome.Text = "";
            txSexo.Text = "";
            txIdade.Text = "";
            txOrigem.Text = "";
            txTemperatura.Text = "";

        }

        private void AdicionaRegistro()
        {
            conexao comb = new conexao();

            comb.sql = "INSERT INTO tb01_entrevistados (tb01_nome, tb01_sexo, tb01_idade, tb01_origem, tb01_temperatura)";
            comb.sql += "VALUES ('" + nome + "', '" + sexo + "', '" + idade + "', '" + origem + "', '" + temperatura + "')";

            comb.open();

            int lin = comb.Runsql();

            if (lin > 0)
            {
                MessageBox.Show("Dados registrados!", "Ação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro! Desculpe, algo deu errado", "Ação",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
