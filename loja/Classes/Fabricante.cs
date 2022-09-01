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
using loja;

namespace Loja
{
    public class Fabricante
    {
        #region Atributos

        private int _fab_n_codigo;
        private string _fab_c_descricao;
        private bool? _fab_b_status;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _fab_n_codigo; }
            set { _fab_n_codigo = value; }
        }

        public string Descricao
        {
            get { return _fab_c_descricao; }
            set { _fab_c_descricao = value; }
        }

        public bool? Status
        {
            get { return _fab_b_status; }
            set { _fab_b_status = value; }
        }

        #endregion

        public int Inserir(Fabricante objFabricante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FAB_I_INSERIR_FABRICANTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objFabricante.Descricao;
                sqlCommand.Parameters.Add("@fab_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Fabricante objFabricante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FAB_U_ALTERAR_FABRICANTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FAB_N_CODIGO", SqlDbType.Int).Value = objFabricante.Codigo;

                if (!string.IsNullOrEmpty(objFabricante.Descricao))
                    sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objFabricante.Descricao;

                sqlCommand.Parameters.Add("@FAB_B_STATUS", SqlDbType.Bit).Value = objFabricante.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Fabricante objFabricante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_FAB_D_EXCLUIR_FABRICANTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FAB_N_CODIGO", SqlDbType.Int).Value = objFabricante.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Fabricante objFabricante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataTable dtMarca = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SP_FAB_L_LISTAR_FABRICANTE");

                if (!string.IsNullOrEmpty(objFabricante.Descricao))
                    sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objFabricante.Descricao;

                if (objFabricante.Status != null)
                    sqlCommand.Parameters.Add("@FAB_B_STATUS", SqlDbType.Bit).Value = objFabricante.Status;

                sqlCommand.Parameters.Add("@fab_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtMarca =  db.ExecuteDataSet(sqlCommand).Tables[0];

                return dtMarca;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
