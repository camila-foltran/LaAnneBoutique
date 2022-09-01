using Loja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace loja
{
    public partial class FrmCodigo : Form
    {
        frmVenda instanciaDoFormVenda; //crio um objeto do tipo frmVenda, que será usado dentro da classe


        public FrmCodigo(frmVenda formVenda)
        {
            InitializeComponent();
            this.CarregarDados();
            instanciaDoFormVenda = formVenda;//atribuo a instancia recebida pelo construtor a minha variavel interna
        }

        public void CarregarDados()
        {
            try
            {
                //procurar pelo produto no bd: se achar apenas 1, adiciona o produto no grid
                Produto objProduto = new Produto();
                DataTable dtProduto = new DataTable();
                string[] str = Utilitarios.dadosProduto.Split(';');
                objProduto.CodigoProduto = str[3];
                objProduto.Nome = str[0];
                objProduto.Tamanho = str[1];
                objProduto.Cor = str[2];

                dtProduto = objProduto.ListarVenda(objProduto);

                if (dtProduto.Rows.Count > 0)
                {
                    //lblProduto.Text = dtProduto.Rows[0]["Referência"].ToString() + " " + dtProduto.Rows[0]["Nome"].ToString() + " " + dtProduto.Rows[0]["Tamanho"].ToString() + " " + dtProduto.Rows[0]["Cor"].ToString();
                    lblProduto.Text = dtProduto.Rows[0]["Referência"].ToString();

                    DataTable dtCodigos = new DataTable();
                    dtCodigos.Columns.Add("Codigo");
                    dtCodigos.Columns.Add("Produto");

                    foreach (DataRow dr in dtProduto.Rows)
                    {
                        dtCodigos.Rows.Add(dr["Código"], dr["Código"].ToString().PadRight(20,' ') + " " + dr["Nome"].ToString().PadRight(20, ' ') + " " + dr["Tamanho"].ToString().PadRight(4,' ') + " " + dr["Cor"].ToString().PadRight(15,' ') + " " + dr["ValorVenda"].ToString().PadLeft(11, ' '));
                    }

                    lstCodigos.ValueMember = "Codigo";
                    lstCodigos.DisplayMember = "Produto";
                    lstCodigos.DataSource = dtCodigos;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!");
                    this.Close();
                }
                  
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "BUSCA POR CÓDIGO - CarregarDados()");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(lstCodigos.SelectedValue != null)//selecionou um código
                {
                    instanciaDoFormVenda.txtCodigo.Text = lstCodigos.SelectedValue.ToString();
                    instanciaDoFormVenda.txtCodigo.Focus();
                    //instanciaDoFormVenda.AdicionarProduto();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "BUSCA POR CÓDIGO - btnOK_Click");
            }
        }
    }
}
