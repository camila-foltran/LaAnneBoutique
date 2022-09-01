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
    public partial class frmVendasVendedor : Form
    {
        public frmVendasVendedor()
        {
            InitializeComponent();
        }

        public void CarregarDados()
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no sistema. Tente novamente, caso o erro persita, contate o administrador. ");
                Utilitarios.SalvarLog(ex.Message, "VENDAS POR VENDEDOR - CarregarDados()");
            }
        }
    }
}
