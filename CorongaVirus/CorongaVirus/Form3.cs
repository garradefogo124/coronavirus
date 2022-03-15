using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DadosTabela();
        }

        private void DadosTabela()
        {
            conexao comb = new conexao();
            comb.sql = "SELECT * FROM tb01_entrevistados ORDER BY tb01_nome";

            comb.open();

            MySqlDataReader dados = comb.Execsql();

            dgLista.Rows.Clear();

            if(dados.HasRows)
            {
                while (dados.Read())
                {
                    dgLista.Rows.Add(
                        dados["tb01_nome"].ToString(),
                        dados["tb01_idade"].ToString(),
                        dados["tb01_sexo"].ToString(),
                        dados["tb01_temperatura"].ToString(),
                        dados["tb01_origem"].ToString());
                }
            }
                comb.close();
        }

        private void btnResumo_Click(object sender, EventArgs e)
        {
            Form2 tela = new Form2();
            tela.Visible = true;
            this.Close();
        }
    }
}
