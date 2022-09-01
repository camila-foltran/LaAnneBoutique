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
    public class Comprovante
    {
        #region Atributos

        private int _com_n_codigo;
        private int _com_ven_n_codigo;
        private int _com_tro_n_codigo;
        private string _com_c_status;
        private string _com_c_comprovante;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _com_n_codigo; }
            set { _com_n_codigo = value; }
        }

        public int CodigoVenda
        {
            get { return _com_ven_n_codigo; }
            set { _com_ven_n_codigo = value; }
        }

        public int CodigoTroca
        {
            get { return _com_tro_n_codigo; }
            set { _com_tro_n_codigo = value; }
        }
        public string TextoComprovante
        {
            get { return _com_c_comprovante; }
            set { _com_c_comprovante = value; }
        }

        public string Status
        {
            get { return _com_c_status; }
            set { _com_c_status = value; }
        }

        #endregion

        public int Inserir(Comprovante objComprovante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_COM_I_INSERIR_Comprovante");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                if(objComprovante.CodigoVenda > 0)
                sqlCommand.Parameters.Add("@COM_VEN_N_CODIGO", SqlDbType.Int).Value = objComprovante.CodigoVenda;

                if (objComprovante.CodigoTroca > 0)
                    sqlCommand.Parameters.Add("@COM_TRO_N_CODIGO", SqlDbType.Int).Value = objComprovante.CodigoTroca;

                sqlCommand.Parameters.Add("@COM_C_COMPROVANTE", SqlDbType.VarChar).Value = objComprovante.TextoComprovante;
                sqlCommand.Parameters.Add("@COM_C_STATUS", SqlDbType.VarChar).Value = objComprovante.Status;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Comprovante objComprovante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_COM_U_ALTERAR_Comprovante");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@COM_N_CODIGO", SqlDbType.Int).Value = objComprovante.Codigo;
                sqlCommand.Parameters.Add("@COM_C_STATUS", SqlDbType.VarChar).Value = objComprovante.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(Comprovante objComprovante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_COM_L_LISTAR_Comprovante");

                if (objComprovante.CodigoVenda > 0)
                    sqlCommand.Parameters.Add("@COM_VEN_N_CODIGO", SqlDbType.Int).Value = objComprovante.CodigoVenda;

                if (objComprovante.CodigoTroca > 0)
                    sqlCommand.Parameters.Add("@COM_TRO_N_CODIGO", SqlDbType.Int).Value = objComprovante.CodigoTroca;

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
