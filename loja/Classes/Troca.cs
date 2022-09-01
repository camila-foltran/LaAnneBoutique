using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace loja
{
   public class Troca
   {
       #region Atributos

       private int _tro_n_codigo;
       private int _tro_ven_n_codigo;
       private decimal _tro_n_valor_troca;
       private decimal _tro_n_valor_venda;
       private decimal _tro_n_desconto;
       private DateTime _tro_d_data;
       private int _tro_usu_n_codigo;
       private string _tro_c_obs;

       #endregion

       #region Properties

       public int Codigo
       {
           get { return _tro_n_codigo; }
           set { _tro_n_codigo = value; }
       }

       public int CodigoVenda
       {
           get { return _tro_ven_n_codigo; }
           set { _tro_ven_n_codigo = value; }
       }

       public int CodigoUsuario
       {
           get { return _tro_usu_n_codigo; }
           set { _tro_usu_n_codigo = value; }
       }

       public DateTime Data
       {
           get { return _tro_d_data; }
           set { _tro_d_data = value; }
       }

       public decimal ValorVenda
       {
           get { return _tro_n_valor_venda; }
           set { _tro_n_valor_venda = value; }
       }

       public decimal ValorTroca
       {
           get { return _tro_n_valor_troca; }
           set { _tro_n_valor_troca = value; }
       }

       public decimal Desconto
       {
           get { return _tro_n_desconto; }
           set { _tro_n_desconto = value; }
       }

       public string Observacao
       {
           get { return _tro_c_obs; }
           set { _tro_c_obs = value; }
       }
       #endregion

       public int Inserir(Troca objTroca)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_TRO_I_INSERIR_TROCA");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               if(objTroca.CodigoUsuario > 0)
                sqlCommand.Parameters.Add("@TRO_USU_N_CODIGO", SqlDbType.Int).Value = objTroca.CodigoUsuario;

               sqlCommand.Parameters.Add("@TRO_VEN_N_CODIGO", SqlDbType.Int).Value = objTroca.CodigoVenda;
               sqlCommand.Parameters.Add("@TRO_N_VALOR_VENDA", SqlDbType.Decimal).Value = objTroca.ValorVenda;
               sqlCommand.Parameters.Add("@TRO_N_VALOR_TROCA", SqlDbType.Decimal).Value = objTroca.ValorTroca;

               if(!string.IsNullOrEmpty(objTroca.Observacao))
                   sqlCommand.Parameters.Add("@TRO_C_OBS", SqlDbType.VarChar).Value = objTroca.Observacao;

               return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Alterar(Troca objTroca)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_TRO_U_ALTERAR_TROCA");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@TRO_N_CODIGO", SqlDbType.Int).Value = objTroca.Codigo;
               sqlCommand.Parameters.Add("@TRO_USU_N_CODIGO", SqlDbType.Int).Value = objTroca.CodigoUsuario;
               sqlCommand.Parameters.Add("@TRO_N_VALOR_VENDA", SqlDbType.Decimal).Value = objTroca.ValorVenda;
               sqlCommand.Parameters.Add("@TRO_N_VALOR_TROCA", SqlDbType.Decimal).Value = objTroca.ValorTroca;
               sqlCommand.Parameters.Add("@TRO_N_DESCONTO", SqlDbType.Decimal).Value = objTroca.Desconto;
               if (!string.IsNullOrEmpty(objTroca.Observacao))
                   sqlCommand.Parameters.Add("@TRO_C_OBS", SqlDbType.VarChar).Value = objTroca.Observacao;

               sqlCommand.Parameters.Add("@TRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

               db.ExecuteScalar(sqlCommand);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Excluir(Troca objTroca)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_TRO_D_EXCLUIR_TROCA");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@TRO_N_CODIGO", SqlDbType.Int).Value = objTroca.Codigo;

               db.ExecuteScalar(sqlCommand);
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataTable Listar(Troca objTroca)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_TRO_L_LISTAR_TROCA");

               if (objTroca.Codigo > 0)
                   sqlCommand.Parameters.Add("@TRO_N_CODIGO", SqlDbType.Int).Value = objTroca.Codigo;

               if (objTroca.Data > DateTime.MinValue)
                   sqlCommand.Parameters.Add("@TRO_D_DATA", SqlDbType.DateTime).Value = objTroca.Data.ToShortDateString();

               if (objTroca.CodigoUsuario > 0)
                   sqlCommand.Parameters.Add("@TRO_USU_N_CODIGO", SqlDbType.Int).Value = objTroca.CodigoUsuario;


               sqlCommand.Parameters.Add("@TRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.CommandTimeout = 9000;

               return db.ExecuteDataSet(sqlCommand).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataSet ListarItensTroca(Troca objTroca)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_ITT_L_LISTAR_ITEM_TROCA");

               if (objTroca.Codigo > 0)
                   sqlCommand.Parameters.Add("@ITT_TRO_N_CODIGO", SqlDbType.Int).Value = objTroca.Codigo;

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
