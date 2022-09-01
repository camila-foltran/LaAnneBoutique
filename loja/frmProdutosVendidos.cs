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
    public partial class frmProdutosVendidos : Form
    {
        public frmProdutosVendidos()
        {
            InitializeComponent();

            try
            {
                Categoria objCategoria = new Categoria();
                DataTable dtCategoria = new DataTable();
                objCategoria.Status = true;
                dtCategoria = objCategoria.Listar(objCategoria);
                dtCategoria.Rows.Add(0, "Selecione...");

                ddlCategoria.DataSource = dtCategoria;
                ddlCategoria.DisplayMember = "Descrição";
                ddlCategoria.ValueMember = "Código";
                ddlCategoria.SelectedValue = "0";

                Fabricante objFabricante = new Fabricante();
                DataTable dtFabricante = new DataTable();
                objFabricante.Status = true;
                dtFabricante = objFabricante.Listar(objFabricante);
                dtFabricante.Rows.Add(0, "Selecione...");

                ddlMarca.DataSource = dtFabricante;
                ddlMarca.DisplayMember = "Descrição";
                ddlMarca.ValueMember = "Código";
                ddlMarca.SelectedValue = "0";

                txtCodigoFiltro.Focus();

                AutoCompleteStringCollection strNome = new AutoCompleteStringCollection();

                Produto objProduto = new Produto();
                DataSet dtsFiltros = new DataSet();
                dtsFiltros = objProduto.ListarFiltros();

                foreach (DataRow dr in dtsFiltros.Tables[0].Rows)
                {
                    strNome.Add(dr["PRO_C_NOME"].ToString());
                }

                txtNomeFiltro.AutoCompleteCustomSource = strNome;

                this.PopularListagem();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "PRODUTOS VENDIDOS - frmProdutosVendidos()");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopularListagem();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "PRODUTOS VENDIDOS - btnPesquisar_Click");
            }
        }

        public void PopularListagem()
        {
            try
            {
                Produto objProduto = new Produto();
                DataTable dtProduto = new DataTable();

                if (!string.IsNullOrEmpty(txtCodigoFiltro.Text))
                    objProduto.CodigoProduto = txtCodigoFiltro.Text.ToUpper();

                if (!string.IsNullOrEmpty(txtNomeFiltro.Text))
                    objProduto.Nome = txtNomeFiltro.Text.ToUpper();

                if (!string.IsNullOrEmpty(txtReferenciaFiltro.Text))
                    objProduto.Referencia = txtReferenciaFiltro.Text;

                if (ddlCategoria.SelectedValue != null)
                    objProduto.CodigoCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);

                if (ddlMarca.SelectedValue != null)
                    objProduto.CodigoFabricante = Convert.ToInt32(ddlMarca.SelectedValue);

                DateTime? dtInicio = null, dtFim = null;
                try
                {
                    if (!string.IsNullOrEmpty(txtDataInicio.Text))
                        dtInicio = Convert.ToDateTime(txtDataInicio.Text);

                    if (!string.IsNullOrEmpty(txtDataFim.Text))
                        dtFim = Convert.ToDateTime(txtDataFim.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao processar a data de início e fim. Verifique se as datas estão no formado dd/mm/yyyy (Ex: 02/05/2016) e tente novamente.");
                    return;
                }

                dtProduto = objProduto.ListarProdutosVendidos(dtInicio,dtFim,objProduto);

                rgvProduto.DataSource = dtProduto;

                int intQtde = 0;
                decimal decTotal = 0;

                if (dtProduto.Rows.Count > 0)
                {
                    rgvProduto.Columns["Código"].Width = 120;//CÓDIGO
                    rgvProduto.Columns["Produto"].Width = 250;
                    rgvProduto.Columns["Marca"].Width = 150;
                    rgvProduto.Columns["Qtde Vendida"].Width = 130;
                    rgvProduto.Columns["Qtde Estoque"].Width = 130;
                    rgvProduto.Columns["Preço Venda"].Width = 130;
                    rgvProduto.Columns["Qtde Vendida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProduto.Columns["Qtde Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProduto.Columns["Preço Custo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                    rgvProduto.Columns["Preço Venda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                    rgvProduto.Columns["Preço Custo"].DefaultCellStyle.Format = "C2";
                    rgvProduto.Columns["Preço Venda"].DefaultCellStyle.Format = "C2";

                    foreach (DataRow dr in dtProduto.Rows)
                    {
                        intQtde += Convert.ToInt32(dr["Qtde Vendida"]);
                        decTotal += (Convert.ToDecimal(dr["Preço Venda"]) * Convert.ToInt32(dr["Qtde Vendida"]));
                    }

                }

                lblQtdeTotal.Text = intQtde.ToString("0000");
                lblValorTotal.Text = decTotal.ToString("C");

                //formatar grid
                DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
                estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                estiloCelulaHeader.ForeColor = Color.DarkBlue;
                this.rgvProduto.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
                this.rgvProduto.DefaultCellStyle = estiloCelulaHeader;

                DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
                estiloCelula.Font = new System.Drawing.Font("Arial", 10);
                estiloCelula.ForeColor = Color.Black;
                estiloCelula.BackColor = Color.White;
                this.rgvProduto.RowsDefaultCellStyle = estiloCelula;

                DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
                estiloCelulaAlternada.BackColor = Color.Gainsboro;
                this.rgvProduto.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
