using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace loja
{
    public class FormaPagtoVenda
    {
        #region Atributos

        private int _fpv_n_codigo;
        private int _fpv_ven_n_codigo;
        private int _fpv_fpg_n_codigo;
        private decimal _fpv_n_valor;
        private string _fpv_c_status;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _fpv_n_codigo; }
            set { _fpv_n_codigo = value; }
        }

        public int CodigoVenda
        {
            get { return _fpv_ven_n_codigo; }
            set { _fpv_ven_n_codigo = value; }
        }

        public int CodigoFormaPagto
        {
            get { return _fpv_fpg_n_codigo; }
            set { _fpv_fpg_n_codigo = value; }
        }

        public decimal Valor
        {
            get { return _fpv_n_valor; }
            set { _fpv_n_valor = value; }
        }

        public string Status
        {
            get { return _fpv_c_status; }
            set { _fpv_c_status = value; }
        }

        #endregion

        public int Inserir(FormaPagtoVenda objFormaPagtoVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPV_I_INSERIR_FORMA_PAGTO_VENDA");

                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.Add("@FPV_VEN_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoVenda.CodigoVenda;
                sqlCommand.Parameters.Add("@FPV_FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoVenda.CodigoFormaPagto;
                sqlCommand.Parameters.Add("@FPV_N_VALOR", SqlDbType.Decimal).Value = objFormaPagtoVenda.Valor;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(FormaPagtoVenda objFormaPagtoVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPV_D_EXCLUIR_FORMA_PAGTO_VENDA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FPV_VEN_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoVenda.CodigoVenda;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(FormaPagtoVenda objFormaPagtoVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPV_L_LISTAR_FORMA_PAGTO_VENDA");

                sqlCommand.Parameters.Add("@FPV_VEN_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoVenda.CodigoVenda;

                if (objFormaPagtoVenda.CodigoFormaPagto > 0)
                    sqlCommand.Parameters.Add("@FPV_FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoVenda.CodigoFormaPagto;
                
                if(!string.IsNullOrEmpty(objFormaPagtoVenda.Status))
                    sqlCommand.Parameters.Add("@FPV_C_STATUS", SqlDbType.VarChar).Value = objFormaPagtoVenda.Status;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
