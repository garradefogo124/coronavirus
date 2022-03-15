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
    public partial class Form2 : Form
    {
        double calcTotal = 0, calcConta = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            TotalEntrevistados();
            lbTotal.Text = System.Convert.ToString(calcTotal);

            calcConta = 0;
            GrupoRisco();
            lbGrupoRisco.Text = ( calcConta / calcTotal * 100).ToString("N2");

            calcConta = 0;
            PessoasFebris();
            lbFebris.Text = (calcConta / calcTotal * 100).ToString("N2");

            calcConta = 0;
            PessoasFebrisRisco();
            lbFebrisRisco.Text = (calcConta / calcTotal * 100).ToString("N2");

            calcConta = 0;
            Entrevistados();
            lbM.Text = (calcConta / calcTotal * 100).ToString("N2");

            calcConta = 0;
            Entrevistadas();
            lbF.Text = (calcConta / calcTotal * 100).ToString("N2");
        }


        private void btnResumo_Click(object sender, EventArgs e)
        {
            Form1 tela = new Form1();
            tela.Visible = true;
            this.Close();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            Form3 tela = new Form3();
            tela.Visible = true;
            this.Close();
        }

        private void TotalEntrevistados()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if(conta > 0)
            {
                calcTotal = conta;
            }

            comb.close();
        }

        private void GrupoRisco()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_idade >= 60";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }

            comb.close();
        }

        private void PessoasFebris()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_temperatura > 37.5";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }

            comb.close();
        }

        private void PessoasFebrisRisco()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_temperatura > 37.5 AND tb01_idade > 60";


            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }


            comb.close();
        }

        private void Entrevistados()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_sexo = 'Masculino' ";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }

            comb.close();
        }

        private void Entrevistadas()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_sexo = 'Feminino' ";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }

            comb.close();
        }

        private void Estado()
        {
            conexao comb = new conexao();

            comb.open();

            comb.sql = "Select count(*) from tb01_entrevistados ";
            comb.sql += " where tb01_origem = '" + lbUF.Text + "'";

            int conta = Convert.ToInt32(comb.ExecEscalar());

            if (conta > 0)
            {
                calcConta = conta;
            }

            comb.close();
        }

        private void lbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcConta = 0;
            Estado();
            lbEstado.Text = (calcConta / calcTotal * 100).ToString("N2");
        }


        private void lbTotal_Click(object sender, EventArgs e)
        {
            
        }

        private void lbGrupoRisco_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
