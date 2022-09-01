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
   public class Estoque
   {
       #region Atributos

       private int _est_n_codigo;
       private DateTime _est_d_data;
       private int _est_pro_n_codigo;
       private int _est_n_qtde;
       private string _est_c_movimento;
       private decimal _est_n_valor_custo;
       private decimal _est_n_valor_venda;
       private string _pro_c_codigo;
       private string _pro_c_nome;
       private string _pro_c_referencia;
       private string _cat_c_descricao;
       private string _fab_c_descricao;

       #endregion

       #region Propriedades

       public int Codigo
       {
           get { return _est_n_codigo; }
           set { _est_n_codigo = value; }
       }

       public DateTime Data
       {
           get { return _est_d_data; }
           set { _est_d_data = value; }
       }

       public int CodigoProduto
       {
           get { return _est_pro_n_codigo; }
           set { _est_pro_n_codigo = value; }
       }

       public int Qtde
       {
           get { return _est_n_qtde; }
           set { _est_n_qtde = value; }
       }

       public string Movimento
       {
           get { return _est_c_movimento; }
           set { _est_c_movimento = value; }
       }

       public decimal ValorCusto
       {
           get { return _est_n_valor_custo; }
           set { _est_n_valor_custo = value; }
       }

       public decimal ValorVenda
       {
           get { return _est_n_valor_venda; }
           set { _est_n_valor_venda = value; }
       }

       public string CodigoBarrasProduto
       {
           get { return _pro_c_codigo; }
           set { _pro_c_codigo = value; }
       }

       public string NomeProduto
       {
           get { return _pro_c_nome; }
           set { _pro_c_nome = value; }
       }

       public string Referencia
       {
           get { return _pro_c_referencia; }
           set { _pro_c_referencia = value; }
       }

       public string Categoria
       {
           get { return _cat_c_descricao; }
           set { _cat_c_descricao = value; }
       }

       public string Fabricante
       {
           get { return _fab_c_descricao; }
           set { _fab_c_descricao = value; }
       }

       #endregion

       public int Inserir(Estoque objEstoque)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_EST_I_INSERIR_ESTOQUE");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@EST_PRO_C_CODIGO", SqlDbType.VarChar).Value = objEstoque.CodigoBarrasProduto;
               sqlCommand.Parameters.Add("@EST_PRO_N_CODIGO", SqlDbType.Int).Value = objEstoque.CodigoProduto;
               sqlCommand.Parameters.Add("@EST_N_QTDE", SqlDbType.Int).Value = objEstoque.Qtde;
               sqlCommand.Parameters.Add("@EST_C_MOVIMENTO", SqlDbType.VarChar).Value = objEstoque.Movimento;
               sqlCommand.Parameters.Add("@EST_N_VALOR_CUSTO", SqlDbType.Decimal).Value = objEstoque.ValorCusto;
               sqlCommand.Parameters.Add("@EST_N_VALOR_VENDA", SqlDbType.Decimal).Value = objEstoque.ValorVenda;

               return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
           }
           catch(Exception ex)
           {
               throw ex;
           }
       }

       public DataTable Listar(Estoque objEstoque)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand sqlCommand = new SqlCommand("SP_EST_L_LISTAR_ESTOQUE");
               sqlCommand.CommandType = CommandType.StoredProcedure;

               if(objEstoque.CodigoProduto > 0)
                   sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.Int).Value = objEstoque.CodigoProduto;

               if(objEstoque.Data > DateTime.MinValue)
                   sqlCommand.Parameters.Add("@EST_D_DATA", SqlDbType.DateTime).Value = objEstoque.Data;

               if(!string.IsNullOrEmpty(objEstoque.CodigoBarrasProduto))
                   sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objEstoque.CodigoBarrasProduto;

               if (!string.IsNullOrEmpty(objEstoque.NomeProduto))
                   sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objEstoque.NomeProduto;

               sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

               sqlCommand.CommandType = CommandType.StoredProcedure;
               sqlCommand.CommandTimeout = 9000;

               return db.ExecuteDataSet(sqlCommand).Tables[0];
           }
           catch(Exception ex)
           {
               throw ex;
           }
       }

        public DataTable ListarTotalEntradaPeriodo(DateTime dtInicio, DateTime dtFim)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                SqlCommand sqlCommand = new SqlCommand("SP_EST_L_LISTAR_ENTRADA_ESTOQUE_MES");
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@EST_D_DATA_INICIO", SqlDbType.DateTime).Value = dtInicio;
                sqlCommand.Parameters.Add("@EST_D_DATA_FIM", SqlDbType.DateTime).Value = dtFim;
                sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarTotalEntradaPeriodoPorProduto(DateTime dtInicio, DateTime dtFim)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                SqlCommand sqlCommand = new SqlCommand("SP_EST_L_LISTAR_ENTRADA_ESTOQUE_MES_PRODUTO");
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@EST_D_DATA_INICIO", SqlDbType.DateTime).Value = dtInicio;
                sqlCommand.Parameters.Add("@EST_D_DATA_FIM", SqlDbType.DateTime).Value = dtFim;
                sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarResumo(Estoque objEstoque)
       {
           try
           {
               DataTable dtRetorno = new DataTable();
               Database db = DatabaseFactory.CreateDatabase();
               SqlCommand sqlCommand = new SqlCommand("SP_EST_L_LISTAR_RESUMO_ESTOQUE");
               sqlCommand.CommandType = CommandType.StoredProcedure;

               if (objEstoque.CodigoProduto > 0)
                   sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.Int).Value = objEstoque.CodigoProduto;

               sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

               if (objEstoque.Data > DateTime.MinValue)
                   sqlCommand.Parameters.Add("@EST_D_DATA", SqlDbType.DateTime).Value = objEstoque.Data;

               if (!string.IsNullOrEmpty(objEstoque.CodigoBarrasProduto))
                   sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objEstoque.CodigoBarrasProduto;

               if (!string.IsNullOrEmpty(objEstoque.NomeProduto))
                   sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objEstoque.NomeProduto;

               if (!string.IsNullOrEmpty(objEstoque.Referencia))
                   sqlCommand.Parameters.Add("@PRO_C_REFERENCIA", SqlDbType.VarChar).Value = objEstoque.Referencia;

               if (!string.IsNullOrEmpty(objEstoque.Categoria))
                   sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objEstoque.Categoria;

               if (!string.IsNullOrEmpty(objEstoque.Fabricante))
                   sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objEstoque.Fabricante;

               sqlCommand.CommandType = CommandType.StoredProcedure;
               sqlCommand.CommandTimeout = 9000;

               dtRetorno =  db.ExecuteDataSet(sqlCommand).Tables[0];

               dtRetorno = db.ExecuteDataSet(sqlCommand).Tables[0];
               dtRetorno.Columns.Add("QtdeEstoqueTotal");
               dtRetorno.Columns.Add("ValorCustoEstoqueTotal");

               int intTotalQtde = 0;
               decimal decValorCusto = 0;

               foreach (DataRow dr in dtRetorno.Rows)
               {
                   intTotalQtde += Convert.ToInt32(dr["Qtde total em estoque"]);
                   decValorCusto += (Convert.ToDecimal(dr["Preço Custo"]) * Convert.ToDecimal(dr["Qtde total em estoque"]));
               }

               if (dtRetorno.Rows.Count > 0)
               {
                   dtRetorno.Rows[0]["QtdeEstoqueTotal"] = intTotalQtde;
                   dtRetorno.Rows[0]["ValorCustoEstoqueTotal"] = decValorCusto;
               }

               return dtRetorno;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Excluir(Estoque objEstoque)
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_EST_D_EXCLUIR_MOVIMENTO");

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.Parameters.Add("@EST_N_CODIGO", SqlDbType.Int).Value = objEstoque.Codigo;

               db.ExecuteScalar(sqlCommand);
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

        public DataTable ListarTotaisEntradaAnosEstoque()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                StringBuilder stb = new StringBuilder();

                stb.Append("select distinct year(est_d_data) AS ANO, ");
                stb.Append("sum(est_n_qtde * est_n_valor_custo) as Total ");
                stb.Append("from tb_est_estoque INNER JOIN TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO where est_c_movimento  = 'ENTRADA' ");
                stb.Append("and pro_loj_n_codigo = " + Utilitarios.intCodigoLoja);
                stb.Append("group by year(est_d_data) order by year(est_d_data)");

                SqlCommand sqlCommand = new SqlCommand(stb.ToString());
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarTotaisVendaAnosEstoque()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                StringBuilder stb = new StringBuilder();

                stb.Append("select distinct year(ven_d_data) AS ANO, ");
                stb.Append("SUM (ISNULL(VEN_N_TOTAL,0)) - SUM(ISNULL(VEN_N_DESCONTO,0)) + SUM(ISNULL(VEN_N_ACRESCIMO,0)) as Total ");
                stb.Append("from tb_ven_venda  where ven_c_status  = 'A' ");
                stb.Append("and ven_loj_n_codigo = " + Utilitarios.intCodigoLoja);
                stb.Append("group by year(ven_d_data) order by year(ven_d_data)");

                SqlCommand sqlCommand = new SqlCommand(stb.ToString());
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarTotaisEntradaMesesEstoque(int pintAno)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataTable dtRetorno = new DataTable();
                StringBuilder stb = new StringBuilder();
                stb.Append("select ");
                stb.Append("MONTH(EST_D_DATA) AS MES, ");
                stb.Append("'' as MÊS, ");
                stb.Append("sum(est_n_qtde * est_n_valor_custo) as TOTAL ");
                stb.Append("from tb_est_estoque INNER JOIN TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO where est_c_movimento  = 'ENTRADA' ");
                stb.Append("and pro_loj_n_codigo = " + Utilitarios.intCodigoLoja);
                stb.Append("and year(est_d_data) = " + pintAno);
                stb.Append("group by year(est_d_data), month(est_d_data) order by month(est_d_data) ");

                SqlCommand sqlCommand = new SqlCommand(stb.ToString());
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 9000;

                dtRetorno = db.ExecuteDataSet(sqlCommand).Tables[0];

                foreach (DataRow dr in dtRetorno.Rows)
                {
                    if (dr["MES"].ToString() == "1")
                        dr["MÊS"] = "JANEIRO";
                    else if (dr["MES"].ToString() == "2")
                        dr["MÊS"] = "FEVEREIRO";
                    else if (dr["MES"].ToString() == "3")
                        dr["MÊS"] = "MARÇO";
                    else if (dr["MES"].ToString() == "4")
                        dr["MÊS"] = "ABRIL";
                    else if (dr["MES"].ToString() == "5")
                        dr["MÊS"] = "MAIO";
                    else if (dr["MES"].ToString() == "6")
                        dr["MÊS"] = "JUNHO";
                    else if (dr["MES"].ToString() == "7")
                        dr["MÊS"] = "JULHO";
                    else if (dr["MES"].ToString() == "8")
                        dr["MÊS"] = "AGOSTO";
                    else if (dr["MES"].ToString() == "9")
                        dr["MÊS"] = "SETEMBRO";
                    else if (dr["MES"].ToString() == "10")
                        dr["MÊS"] = "OUTUBRO";
                    else if (dr["MES"].ToString() == "11")
                        dr["MÊS"] = "NOVEMBRO";
                    else if (dr["MES"].ToString() == "12")
                        dr["MÊS"] = "DEZEMBRO";
                }

                return dtRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarTotalEntradaDiaEstoque(int pintAno, int pintMes)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataTable dtRetorno = new DataTable();
                StringBuilder stb = new StringBuilder();
                stb.Append("select day(est_d_data) as DIA, ");
                stb.Append("sum(est_n_qtde * est_n_valor_custo) as TOTAL ");
                stb.Append("from tb_est_estoque INNER JOIN TB_PRO_PRODUTO ON PRO_N_CODIGO = EST_PRO_N_CODIGO where est_c_movimento  = 'ENTRADA' ");
                stb.Append("and pro_loj_n_codigo = " + Utilitarios.intCodigoLoja);
                stb.Append("and year(est_d_data) = " + pintAno);
                stb.Append("and month(est_d_data) = " + pintMes);
                stb.Append(" group by day(est_d_data) order by day(est_d_data)");

                SqlCommand sqlCommand = new SqlCommand(stb.ToString());
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandTimeout = 9000;

                dtRetorno = db.ExecuteDataSet(sqlCommand).Tables[0];

                return dtRetorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
