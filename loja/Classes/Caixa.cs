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
using System.IO;

namespace loja
{
    public class Caixa
    {
        #region Atributos

        private int _cai_n_codigo;
        private DateTime _cai_d_data;
        private int _cai_usu_n_codigo;
        private string _cai_c_tipo;
        private decimal _cai_n_troco;
        private decimal _cai_n_valor_final;
        private string _cai_c_obs;
        private int _cai_loj_n_codigo;
        private decimal _cai_n_valor_diferenca;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _cai_n_codigo; }
            set { _cai_n_codigo = value; }
        }

        public int CodigoUsuario
        {
            get { return _cai_usu_n_codigo; }
            set { _cai_usu_n_codigo = value; }
        }

        public int CodigoLoja
        {
            get { return _cai_loj_n_codigo; }
            set { _cai_loj_n_codigo = value; }
        }

        public decimal Troco
        {
            get { return _cai_n_troco; }
            set { _cai_n_troco = value; }
        }

        public DateTime Data
        {
            get { return _cai_d_data; }
            set { _cai_d_data = value; }
        }

        public decimal ValorFinal
        {
            get { return _cai_n_valor_final; }
            set { _cai_n_valor_final = value; }
        }

        public string Obs
        {
            get { return _cai_c_obs; }
            set { _cai_c_obs = value; }
        }

        public string Tipo
        {
            get { return _cai_c_tipo; }
            set { _cai_c_tipo = value; }
        }

        public decimal Diferenca
        {
            get { return _cai_n_valor_diferenca; }
            set { _cai_n_valor_diferenca = value; }
        }

        #endregion

        public int Inserir(Caixa objCaixa)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAI_I_INSERIR_CAIXA");

                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.Add("@CAI_USU_N_CODIGO", SqlDbType.Int).Value = objCaixa.CodigoUsuario;
                sqlCommand.Parameters.Add("@CAI_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;
                sqlCommand.Parameters.Add("@CAI_N_TROCO", SqlDbType.Decimal).Value = objCaixa.Troco;
                sqlCommand.Parameters.Add("@CAI_N_VALOR_FINAL", SqlDbType.Decimal).Value = objCaixa.ValorFinal;
                sqlCommand.Parameters.Add("@CAI_C_TIPO", SqlDbType.VarChar).Value = objCaixa.Tipo;

                if(!string.IsNullOrEmpty(objCaixa.Obs))
                    sqlCommand.Parameters.Add("@CAI_C_OBS", SqlDbType.VarChar).Value = objCaixa.Obs;

                sqlCommand.Parameters.Add("@CAI_N_VALOR_DIFERENCA", SqlDbType.Decimal).Value = objCaixa.Diferenca;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Caixa objCaixa)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAI_D_EXCLUIR_CAIXA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CAI_N_CODIGO", SqlDbType.Int).Value = objCaixa.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Caixa objCaixa)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAI_L_LISTAR_CAIXA");

                if (objCaixa.CodigoUsuario > 0)
                    sqlCommand.Parameters.Add("@CAI_USU_N_CODIGO", SqlDbType.Int).Value = objCaixa.CodigoUsuario;

                    sqlCommand.Parameters.Add("@CAI_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                if (objCaixa.Data > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@CAI_D_DATA", SqlDbType.DateTime).Value = objCaixa.Data.ToShortDateString();

                if(!string.IsNullOrEmpty(objCaixa.Tipo))
                    sqlCommand.Parameters.Add("@CAI_C_TIPO", SqlDbType.VarChar).Value = objCaixa.Tipo;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable ListarFechamento(Caixa objCaixa)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CAI_L_LISTAR_FECHAMENTO_CAIXA");

                sqlCommand.Parameters.Add("@CAI_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                if (objCaixa.Data > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@CAI_D_DATA", SqlDbType.DateTime).Value = objCaixa.Data.ToShortDateString();

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
