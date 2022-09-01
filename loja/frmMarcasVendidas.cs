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
    public partial class frmMarcasVendidas : Form
    {
        public frmMarcasVendidas()
        {
            InitializeComponent();

            try
            {
                Fabricante objFabricante = new Fabricante();
                DataTable dtFabricante = new DataTable();
                //objFabricante.Status = true;
                dtFabricante = objFabricante.Listar(objFabricante);
                dtFabricante.Rows.Add(0, "Selecione...");
                ddlMarca.DataSource = dtFabricante;
                ddlMarca.DisplayMember = "Descrição";
                ddlMarca.ValueMember = "Código";
                ddlMarca.SelectedValue = "0";

                this.PopularListagem();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "MARCAS VENDIDAS - frmMarcasVendidas()");
            }

        }

        public void PopularListagem()
        {
            try
            {

                Produto objProduto = new Produto();

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

                DataTable dtMarcas = new DataTable();

                int? intCodigoFabricante = null;

                if (ddlMarca.SelectedValue != null)
                    intCodigoFabricante = Convert.ToInt32(ddlMarca.SelectedValue);
 
                dtMarcas = objProduto.ListarMarcasVendidas(dtInicio, dtFim, intCodigoFabricante);
                rgvMarca.DataSource = dtMarcas;

                rgvMarca.Columns["FAB_N_CODIGO"].Visible = false;
                rgvMarca.Columns["Qtde Vendida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvMarca.Columns["Qtde Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvMarca.Columns["Total Vendido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvMarca.Columns["Lucro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

                rgvMarca.Columns["Total Vendido"].DefaultCellStyle.Format = "C2";
                rgvMarca.Columns["Lucro"].DefaultCellStyle.Format = "C2";

                int intQtde = 0;

                foreach (DataRow dr in dtMarcas.Rows)
                {
                    intQtde += Convert.ToInt32(dr["Qtde Vendida"]);
                }

                lblQtdeTotal.Text = intQtde.ToString("0000");
            }
            catch(Exception ex)
            {
                Utilitarios.SalvarLog(ex.Message, "MARCAS VENDIDAS - PopularListagem()");
                throw ex;
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
                Utilitarios.SalvarLog(ex.Message, "MARCAS VENDIDAS - btnPesquisar_Click");
            }
        }
    }
}
