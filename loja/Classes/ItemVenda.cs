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
   public  class ItemVenda
   {

       #region Atributos

       private int _itv_n_codigo;
       private int _itv_ven_n_codigo;
       private string _itv_pro_c_codigo;
       private string _pro_c_nome;
       private int _itv_n_qtde;
       private decimal _itv_n_valor_unitario;
       private decimal _itv_n_valor_total_sd;
       private decimal _itv_n_desconto;
       private decimal _itv_n_valor_total;
       private string _pro_c_tamanho;
       private string _pro_c_cor;
        private int _itv_pro_n_codigo;
       #endregion

       #region Properties

       public int Codigo
       {
           get { return _itv_n_codigo; }
           set { _itv_n_codigo = value; }
       }

       public int CodigoVenda
       {
           get { return _itv_ven_n_codigo; }
           set { _itv_ven_n_codigo = value; }
       }

        public int CodigoProduto
        {
            get { return _itv_pro_n_codigo; }
            set { _itv_pro_n_codigo = value; }
        }

        public int Qtde
       {
           get { return _itv_n_qtde; }
           set { _itv_n_qtde = value; }
       }
       public string CodigoProdutoString
       {
           get { return _itv_pro_c_codigo; }
           set { _itv_pro_c_codigo = value; }
       }

       public string NomeProduto
       {
           get { return _pro_c_nome; }
           set { _pro_c_nome = value; }
       }

       public string Cor
       {
           get { return _pro_c_cor; }
           set { _pro_c_cor = value; }
       }

       public string Tamanho
       {
           get { return _pro_c_tamanho; }
           set { _pro_c_tamanho = value; }
       }

       public decimal ValorUnitario
       {
           get { return _itv_n_valor_unitario; }
           set { _itv_n_valor_unitario = value; }
       }

       public decimal ValorTotalSD
       {
           get { return _itv_n_valor_total_sd; }
           set { _itv_n_valor_total_sd = value; }
       }

       public decimal ValorDesconto
       {
           get { return _itv_n_desconto; }
           set { _itv_n_desconto = value; }
       }

       public decimal ValorTotal
       {
           get { return _itv_n_valor_total; }
           set { _itv_n_valor_total = value; }
       }

       #endregion

       public int Inserir(ItemVenda objItemVenda)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_ITV_I_INSERIR_ITEM_Venda");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@ITV_VEN_N_CODIGO", SqlDbType.Int).Value = objItemVenda.CodigoVenda;
                sqlCommand.Parameters.Add("@ITV_PRO_C_CODIGO", SqlDbType.VarChar).Value = objItemVenda.CodigoProdutoString;
                sqlCommand.Parameters.Add("@ITV_PRO_N_CODIGO", SqlDbType.Int).Value = objItemVenda.CodigoProduto;
               sqlCommand.Parameters.Add("@ITV_N_QTDE", SqlDbType.Int).Value = objItemVenda.Qtde;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_UNITARIO", SqlDbType.Decimal).Value = objItemVenda.ValorUnitario;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_TOTAL_SD", SqlDbType.Decimal).Value = objItemVenda.ValorTotalSD;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_TOTAL", SqlDbType.Decimal).Value = objItemVenda.ValorTotal;
               sqlCommand.Parameters.Add("@ITV_N_DESCONTO", SqlDbType.Decimal).Value = objItemVenda.ValorDesconto;

               return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Alterar(ItemVenda objItemVenda)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_ITV_U_ALTERAR_ITEM_Venda");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@ITV_N_CODIGO", SqlDbType.Int).Value = objItemVenda.Codigo;

               sqlCommand.Parameters.Add("@ITV_VEN_N_CODIGO", SqlDbType.Int).Value = objItemVenda.CodigoVenda;
               sqlCommand.Parameters.Add("@ITV_PRO_C_CODIGO", SqlDbType.VarChar).Value = objItemVenda.CodigoProduto;
               sqlCommand.Parameters.Add("@ITV_N_QTDE", SqlDbType.Int).Value = objItemVenda.Qtde;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_UNITARIO", SqlDbType.Decimal).Value = objItemVenda.ValorUnitario;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_TOTAL_SD", SqlDbType.Decimal).Value = objItemVenda.ValorTotalSD;
               sqlCommand.Parameters.Add("@ITV_N_VALOR_TOTAL", SqlDbType.Decimal).Value = objItemVenda.ValorTotal;
               sqlCommand.Parameters.Add("@ITV_N_DESCONTO", SqlDbType.Decimal).Value = objItemVenda.ValorDesconto;

               db.ExecuteScalar(sqlCommand);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Excluir(ItemVenda objItemVenda)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_ITV_D_EXCLUIR_ITEM_Venda");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@ITV_N_CODIGO", SqlDbType.Int).Value = objItemVenda.Codigo;

               db.ExecuteScalar(sqlCommand);
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataSet Listar(ItemVenda objItemVenda)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_ITV_L_LISTAR_ITEM_Venda");

               sqlCommand.Parameters.Add("@ITV_VEN_N_CODIGO", SqlDbType.Int).Value = objItemVenda.CodigoVenda;

               if(!string.IsNullOrEmpty(objItemVenda.CodigoProdutoString))
                   sqlCommand.Parameters.Add("@ITV_PRO_C_CODIGO", SqlDbType.VarChar).Value = objItemVenda.CodigoProdutoString;

               if (!string.IsNullOrEmpty(objItemVenda.NomeProduto))
                   sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objItemVenda.NomeProduto;

               if (!string.IsNullOrEmpty(objItemVenda.Cor))
                   sqlCommand.Parameters.Add("@PRO_C_COR", SqlDbType.VarChar).Value = objItemVenda.Cor;

               if (!string.IsNullOrEmpty(objItemVenda.Tamanho))
                   sqlCommand.Parameters.Add("@PRO_C_TAMANHO", SqlDbType.VarChar).Value = objItemVenda.Tamanho;

               if(objItemVenda.CodigoProduto > 0)
                    sqlCommand.Parameters.Add("@ITV_PRO_N_CODIGO", SqlDbType.Int).Value = objItemVenda.CodigoProduto;

                sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

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
