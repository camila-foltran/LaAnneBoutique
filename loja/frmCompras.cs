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
    public partial class frmCompras : Form
    {
        public int intAno = 0;
        public int intMes = 0;
        public int intDia = 0;

        public frmCompras()
        {
            InitializeComponent();
            PopularAnos();
        }

        public void PopularAnos()
        {
            try
            {
                Estoque objEstoque = new Estoque();
                DataTable dtAnos = new DataTable();

                dtAnos = objEstoque.ListarTotaisEntradaAnosEstoque();

                rgvAno.DataSource = dtAnos;
                rgvAno.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                rgvAno.Columns["TOTAL"].DefaultCellStyle.Format = "C2";

                FormatarGrid(rgvAno);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "COMPRAS - PopularAnos()");
            }
        }

        private void rgvAno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na lupa mostrar os meses do ano correspondente
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//visualizar totais por meses
                    {
                        DataTable dtMeses = new DataTable();
                        Estoque objEstoque = new Estoque();
                        intAno = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["ANO"].Value);
                        dtMeses = objEstoque.ListarTotaisEntradaMesesEstoque(intAno);

                        rgvMes.DataSource = dtMeses;
                        rgvMes.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvMes.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                        rgvMes.Columns["MES"].Visible = false;

                        pnlAno.Visible = false;
                        pnlMes.Visible = true;
                        lblMes.Text = "Compras realizadas em " + intAno;

                        FormatarGrid(rgvMes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "COMPRAS - rgvAno_CellContentClick");
            }
        }

        private void rgvMes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na lupa mostrar os meses do ano correspondente
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)//visualizar totais por mês
                    {
                        DataTable dtDias = new DataTable();
                        Estoque objEstoque = new Estoque();
                        intMes = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["MES"].Value);
                        dtDias = objEstoque.ListarTotalEntradaDiaEstoque(intAno, intMes);

                        rgvCompras.DataSource = dtDias;
                        rgvCompras.Columns["TOTAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        rgvCompras.Columns["TOTAL"].DefaultCellStyle.Format = "C2";

                        pnlMes.Visible = false;
                        pnlDia.Visible = true;
                        lblDias.Text = "Compras relizadas em " + intMes.ToString("00") + "/" + intAno;

                        FormatarGrid(rgvCompras);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "COMPRAS - rgvMes_CellContentClick");
            }
        }

        private void btnVoltarDia_Click(object sender, EventArgs e)
        {
            pnlDia.Visible = false;
            pnlMes.Visible = true;

        }

        private void btnVoltarMes_Click(object sender, EventArgs e)
        {
            pnlMes.Visible = false;
            pnlAno.Visible = true;
        }

        public void FormatarGrid(DataGridView sender)
        {
            //formatar grid
            DataGridViewCellStyle estiloCelulaHeader = new DataGridViewCellStyle();
            estiloCelulaHeader.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            estiloCelulaHeader.ForeColor = Color.DarkBlue;
            sender.ColumnHeadersDefaultCellStyle = estiloCelulaHeader;
            sender.DefaultCellStyle = estiloCelulaHeader;

            DataGridViewCellStyle estiloCelula = new DataGridViewCellStyle();
            estiloCelula.Font = new System.Drawing.Font("Arial", 10);
            estiloCelula.ForeColor = Color.Black;
            estiloCelula.BackColor = Color.White;
            sender.RowsDefaultCellStyle = estiloCelula;

            DataGridViewCellStyle estiloCelulaAlternada = new DataGridViewCellStyle();
            estiloCelulaAlternada.BackColor = Color.Gainsboro;
            sender.AlternatingRowsDefaultCellStyle = estiloCelulaAlternada;
        }
    }
}
