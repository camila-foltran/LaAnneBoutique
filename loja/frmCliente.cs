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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
            this.PopularListagem();
        }

        public void PopularListagem()
        {
            try
            {
                Cliente objCliente = new Cliente();
                DataTable dtCliente = new DataTable();

                dtCliente = objCliente.Listar(objCliente);
                rgvCliente.DataSource = dtCliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE CLIENTES - PopularListagem()");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtCPFFiltro.Text = string.Empty;
            txtNomeFiltro.Text = string.Empty;
            pnlListagem.Visible = false;
            pnlCadastro.Visible = true;
            lblDataCadastro.Text = DateTime.Now.ToShortDateString();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente objCliente = new Cliente();
                DataTable dtCliente = new DataTable();

                if (!string.IsNullOrEmpty(txtCPFFiltro.Text))
                    objCliente.CPF = txtCPFFiltro.Text;

                if(!string.IsNullOrEmpty(txtNomeFiltro.Text))
                    objCliente.Nome = txtNomeFiltro.Text;

                dtCliente = objCliente.Listar(objCliente);
                rgvCliente.DataSource = dtCliente;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE CLIENTES - btnPesquisar");
            }
        }

        private void rgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    Cliente objCliente = new Cliente();
                    DataTable dtCliente = new DataTable();

                    if (e.ColumnIndex == 0)//editar; popular dados com o código 
                    {
                        objCliente.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        dtCliente = objCliente.Listar(objCliente);
                        //popular campos de edição

                        lblTitulo.Text = "Alterar cliente";
                        lblCodigo.Text = dtCliente.Rows[0]["Código"].ToString();
                        txtCPF.Text = dtCliente.Rows[0]["CPF"].ToString();
                        txtCPF.Enabled = false;
                        lblDataCadastro.Text = dtCliente.Rows[0]["Data Cadastro"].ToString();
                        txtNome.Text = dtCliente.Rows[0]["Nome"].ToString();
                        txtTelefone.Text = dtCliente.Rows[0]["Telefone"].ToString();
                        txtEndereco.Text = dtCliente.Rows[0]["Endereço"].ToString();
                        txtBairro.Text = dtCliente.Rows[0]["Bairro"].ToString();
                        txtCidade.Text = dtCliente.Rows[0]["Cidade/UF"].ToString();
                        txtEmail.Text = dtCliente.Rows[0]["e-mail"].ToString();
                       
                        pnlListagem.Visible = false;
                        pnlCadastro.Visible = true;
                    }
                    else if (e.ColumnIndex == 1)//excluir
                    {
                         objCliente = new Cliente();
                        objCliente.Codigo = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                        objCliente.Excluir(objCliente);

                    }

                    objCliente = new Cliente();
                    dtCliente = new DataTable();
                    dtCliente = objCliente.Listar(objCliente);
                    rgvCliente.DataSource = dtCliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "CADASTRO DE CLIENTES - rgvCliente_CellContentClick");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCPF.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEmail.Text = string.Empty;
            pnlCadastro.Visible = false;
            pnlListagem.Visible = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCPF.Text))
                {

                    Cliente objCliente = new Cliente();
                    objCliente.CPF = txtCPF.Text.Replace(".","").Replace("-","");

                    if (!string.IsNullOrEmpty(txtNome.Text))
                        objCliente.Nome = txtNome.Text.ToUpper();

                    if (!string.IsNullOrEmpty(txtTelefone.Text))
                        objCliente.Telefone = txtTelefone.Text.ToUpper();

                    if (!string.IsNullOrEmpty(txtEndereco.Text))
                        objCliente.Endereco = txtEndereco.Text.ToUpper();

                    if (!string.IsNullOrEmpty(txtBairro.Text))
                        objCliente.Bairro = txtBairro.Text.ToUpper();

                    if (!string.IsNullOrEmpty(txtCidade.Text))
                        objCliente.Cidade = txtCidade.Text.ToUpper();

                    if (!string.IsNullOrEmpty(txtEmail.Text))
                        objCliente.Email = txtEmail.Text.ToUpper();

                    if (!string.IsNullOrEmpty(lblCodigo.Text))
                    {
                        objCliente.Codigo = Convert.ToInt32(lblCodigo.Text);
                        objCliente.Alterar(objCliente);
                        MessageBox.Show("Cliente alterado com sucesso!");
                    }
                    else
                    {
                        int intId = objCliente.Inserir(objCliente);
                        MessageBox.Show("Cliente cadastrado com sucesso!");
                    }

                    txtCPF.Text = string.Empty;
                    txtNome.Text = string.Empty;
                    txtTelefone.Text = string.Empty;
                    txtEndereco.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    txtCidade.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    pnlCadastro.Visible = false;
                    pnlListagem.Visible = true;

                    DataTable dtCliente = new DataTable();

                    dtCliente = objCliente.Listar(objCliente);
                    rgvCliente.DataSource = dtCliente;

                }
                else
                    MessageBox.Show("Informe o CPF");

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_"))
                    MessageBox.Show("Esse CPF já está cadastrado!");
                else
                {
                    MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                    Utilitarios.SalvarLog(ex.Message, "CADASTRO DE CLIENTES - btnSalvar_Click");
                }
            }
           
        }
    }
}
