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
    public class ItemTroca
    {


        #region Atributos

        private int _itt_n_codigo;
        private int _itt_tro_n_codigo;
        private string _itt_itv_pro_c_codigo;
        private string _itt_pro_c_codigo;
        private int _itt_n_qtde;
        private decimal _itt_n_valor_diferenca;

        #endregion

        #region Properties

        public int Codigo
        {
            get { return _itt_n_codigo; }
            set { _itt_n_codigo = value; }
        }

        public int CodigoTroca
        {
            get { return _itt_tro_n_codigo; }
            set { _itt_tro_n_codigo = value; }
        }

        public string CodigoProdutoVendido
        {
            get { return _itt_itv_pro_c_codigo; }
            set { _itt_itv_pro_c_codigo = value; }
        }

        public int Qtde
        {
            get { return _itt_n_qtde; }
            set { _itt_n_qtde = value; }
        }
        public string CodigoProdutoTrocado
        {
            get { return _itt_pro_c_codigo; }
            set { _itt_pro_c_codigo = value; }
        }

        public decimal ValorDiferenca
        {
            get { return _itt_n_valor_diferenca; }
            set { _itt_n_valor_diferenca = value; }
        }

        #endregion

        public int Inserir(ItemTroca objItemTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_ITT_I_INSERIR_ITEM_TROCA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@ITT_TRO_N_CODIGO", SqlDbType.Int).Value = objItemTroca.CodigoTroca;
                sqlCommand.Parameters.Add("@ITT_ITV_PRO_C_CODIGO", SqlDbType.VarChar).Value = objItemTroca.CodigoProdutoVendido;
                sqlCommand.Parameters.Add("@ITT_PRO_C_CODIGO", SqlDbType.VarChar).Value = objItemTroca.CodigoProdutoTrocado;
                sqlCommand.Parameters.Add("@ITT_N_QTDE", SqlDbType.Int).Value = objItemTroca.Qtde;
                sqlCommand.Parameters.Add("@ITT_N_VALOR_DIFERENCA", SqlDbType.Decimal).Value = objItemTroca.ValorDiferenca;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(ItemTroca objItemTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_ITT_D_EXCLUIR_ITEM_TROCA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (objItemTroca.Codigo > 0)
                    sqlCommand.Parameters.Add("@ITT_N_CODIGO", SqlDbType.Int).Value = objItemTroca.Codigo;

                if (objItemTroca.CodigoTroca > 0)
                    sqlCommand.Parameters.Add("@ITT_TRO_N_CODIGO", SqlDbType.Int).Value = objItemTroca.CodigoTroca;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Listar(ItemTroca objItemTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_ITT_L_LISTAR_ITEM_TROCA");

                sqlCommand.Parameters.Add("@ITT_TRO_N_CODIGO", SqlDbType.Int).Value = objItemTroca.CodigoTroca;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListarItensComValor(ItemTroca objItemTroca)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_ITT_L_LISTAR_ITEM_TROCA_COM_VALOR");

                sqlCommand.Parameters.Add("@ITT_TRO_N_CODIGO", SqlDbType.Int).Value = objItemTroca.CodigoTroca;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
