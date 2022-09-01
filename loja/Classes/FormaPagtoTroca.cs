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
    public class FormaPagtoTroca
    {
        #region Atributos

        private int _FPT_n_codigo;
        private int _FPT_tro_n_codigo;
        private int _FPT_fpg_n_codigo;
        private decimal _FPT_n_valor;
        private string _FPT_c_status;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _FPT_n_codigo; }
            set { _FPT_n_codigo = value; }
        }

        public int CodigoTroca
        {
            get { return _FPT_tro_n_codigo; }
            set { _FPT_tro_n_codigo = value; }
        }

        public int CodigoFormaPagto
        {
            get { return _FPT_fpg_n_codigo; }
            set { _FPT_fpg_n_codigo = value; }
        }

        public decimal Valor
        {
            get { return _FPT_n_valor; }
            set { _FPT_n_valor = value; }
        }

        public string Status
        {
            get { return _FPT_c_status; }
            set { _FPT_c_status = value; }
        }

        #endregion

        public int Inserir(FormaPagtoTroca objFormaPagtoTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPT_I_INSERIR_FORMA_PAGTO_TROCA");

                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.Add("@FPT_TRO_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoTroca.CodigoTroca;
                sqlCommand.Parameters.Add("@FPT_FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoTroca.CodigoFormaPagto;
                sqlCommand.Parameters.Add("@FPT_N_VALOR", SqlDbType.Decimal).Value = objFormaPagtoTroca.Valor;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(FormaPagtoTroca objFormaPagtoTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPT_D_EXCLUIR_FORMA_PAGTO_TROCA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FPT_TRO_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoTroca.CodigoTroca;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(FormaPagtoTroca objFormaPagtoTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPT_L_LISTAR_FORMA_PAGTO_VENDA");

                sqlCommand.Parameters.Add("@FPT_VEN_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoTroca.CodigoTroca;

                if (objFormaPagtoTroca.CodigoFormaPagto > 0)
                    sqlCommand.Parameters.Add("@FPT_FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagtoTroca.CodigoFormaPagto;

                if (!string.IsNullOrEmpty(objFormaPagtoTroca.Status))
                    sqlCommand.Parameters.Add("@FPT_C_STATUS", SqlDbType.VarChar).Value = objFormaPagtoTroca.Status;

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
