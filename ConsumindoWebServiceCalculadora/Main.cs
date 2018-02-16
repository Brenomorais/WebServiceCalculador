using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsumindoWebServiceCalculadora
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            decimal valorA, valorB;
            localhost.OperacoesBasicas operacao = localhost.OperacoesBasicas.Adicao;
            decimal resultado;

            decimal.TryParse(tbValorA.Text, out valorA);
            decimal.TryParse(tbValorB.Text, out valorB);

            switch (cbOperacao.SelectedIndex)
            {
                case 0:
                    operacao = localhost.OperacoesBasicas.Adicao;
                    break;

                case 1:
                    if (valorB == 0)
                    {
                        clearField();
                        MessageBox.Show("Não é possivel dividir por zero!", "Atenção",
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information, 
                            MessageBoxDefaultButton.Button1);
                       
                    }
                    else
                        operacao = localhost.OperacoesBasicas.Divisao;
                    break;

                case 2:
                    operacao = localhost.OperacoesBasicas.Multiplicacao;
                    break;

                case 3:
                    operacao = localhost.OperacoesBasicas.Subtracao;
                    break;
            }

            //Recebe resultado da operação do webservice
            localhost.Service1 WebServiceCaluladora = new localhost.Service1();
            resultado = WebServiceCaluladora.Caluladora(valorA, valorB, operacao);

            tbResultado.Text = resultado.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearField();

        }

        private void clearField()
        {
            tbResultado.Text = "";
            tbValorA.Text = "";
            tbValorB.Text = "";
            cbOperacao.Text = "";
        }
    }
}
