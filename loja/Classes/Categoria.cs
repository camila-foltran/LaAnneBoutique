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
    public class Categoria
    {
        #region Atributos

        private int _cat_n_codigo;
        private string _cat_c_descricao;
        private bool? _cat_b_status;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _cat_n_codigo; }
            set { _cat_n_codigo = value; }
        }

        public string Descricao
        {
            get { return _cat_c_descricao; }
            set { _cat_c_descricao = value; }
        }

        public bool? Status
        {
            get { return _cat_b_status; }
            set { _cat_b_status = value; }
        }

        #endregion

        public int Inserir(Categoria objCategoria)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAT_I_INSERIR_CATEGORIA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objCategoria.Descricao;
                sqlCommand.Parameters.Add("@cat_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Categoria objCategoria)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAT_U_ALTERAR_CATEGORIA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CAT_N_CODIGO", SqlDbType.Int).Value = objCategoria.Codigo;

                if (!string.IsNullOrEmpty(objCategoria.Descricao))
                    sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objCategoria.Descricao;

                sqlCommand.Parameters.Add("@CAT_B_STATUS", SqlDbType.Bit).Value = objCategoria.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Categoria objCategoria)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAT_D_EXCLUIR_CATEGORIA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CAT_N_CODIGO", SqlDbType.Int).Value = objCategoria.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Categoria objCategoria)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAT_L_LISTAR_CATEGORIA");

                if(objCategoria.Codigo > 0)
                    sqlCommand.Parameters.Add("@CAT_N_CODIGO", SqlDbType.Int).Value = objCategoria.Codigo;

                if (!string.IsNullOrEmpty(objCategoria.Descricao))
                    sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objCategoria.Descricao;

                if (objCategoria.Status != null)
                    sqlCommand.Parameters.Add("@CAT_B_STATUS", SqlDbType.Bit).Value = objCategoria.Status;

                sqlCommand.Parameters.Add("@cat_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

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
