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
    public class FormaPagto
    {
        #region Atributos

        private int _fpg_n_codigo;
        private string _fpg_c_descricao;
        private bool? _fpg_b_status;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _fpg_n_codigo; }
            set { _fpg_n_codigo = value; }
        }

        public string Descricao
        {
            get { return _fpg_c_descricao; }
            set { _fpg_c_descricao = value; }
        }

        public bool? Status
        {
            get { return _fpg_b_status; }
            set { _fpg_b_status = value; }
        }

        #endregion

        public int Inserir(FormaPagto objFormaPagto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPG_I_INSERIR_FORMA_PAGTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FPG_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;
                sqlCommand.Parameters.Add("@FPG_C_DESCRICAO", SqlDbType.VarChar).Value = objFormaPagto.Descricao;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(FormaPagto objFormaPagto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPG_U_ALTERAR_FORMA_PAGTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagto.Codigo;

                if (!string.IsNullOrEmpty(objFormaPagto.Descricao))
                    sqlCommand.Parameters.Add("@FPG_C_DESCRICAO", SqlDbType.VarChar).Value = objFormaPagto.Descricao;

                sqlCommand.Parameters.Add("@FPG_B_STATUS", SqlDbType.Bit).Value = objFormaPagto.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(FormaPagto objFormaPagto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPG_D_EXCLUIR_FORMA_PAGTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FPG_N_CODIGO", SqlDbType.Int).Value = objFormaPagto.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(FormaPagto objFormaPagto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FPG_L_LISTAR_FORMA_PAGTO");

                if (!string.IsNullOrEmpty(objFormaPagto.Descricao))
                    sqlCommand.Parameters.Add("@FPG_C_DESCRICAO", SqlDbType.VarChar).Value = objFormaPagto.Descricao;

                if (objFormaPagto.Status != null)
                    sqlCommand.Parameters.Add("@FPG_B_STATUS", SqlDbType.Bit).Value = objFormaPagto.Status;

                sqlCommand.Parameters.Add("@fpg_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

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
