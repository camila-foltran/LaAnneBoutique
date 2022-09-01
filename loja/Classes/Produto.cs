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
    public class Produto
    {
        #region Atributos

        private int _pro_n_codigo;
        private string _pro_c_nome;
        private string _pro_c_descricao;
        private int _pro_cat_n_codigo;
        private int _pro_fab_n_codigo;
        private bool? _pro_b_status;
        private string _pro_c_tamanho;
        private string _pro_c_cor;
        private string _pro_c_codigo;
        private string _pro_c_referencia;
        private string _cat_c_descricao;
        private string _fab_c_descricao;
        private int _pro_loj_n_codigo;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _pro_n_codigo; }
            set { _pro_n_codigo = value; }
        }

        public int CodigoCategoria
        {
            get { return _pro_cat_n_codigo; }
            set { _pro_cat_n_codigo = value; }
        }

        public int CodigoFabricante 
        {
            get { return _pro_fab_n_codigo; }
            set { _pro_fab_n_codigo = value; }
        }

        public string Descricao
        {
            get { return _pro_c_descricao; }
            set { _pro_c_descricao = value; }
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

        public bool? Status
        {
            get { return _pro_b_status; }
            set { _pro_b_status = value; }
        }

        public string Tamanho
        {
            get { return _pro_c_tamanho; }
            set { _pro_c_tamanho = value; }
        }

        public string Cor
        {
            get { return _pro_c_cor; }
            set { _pro_c_cor = value; }
        }

        public string CodigoProduto
        {
            get { return _pro_c_codigo; }
            set { _pro_c_codigo = value; }
        }

        public string Referencia
        {
            get { return _pro_c_referencia; }
            set { _pro_c_referencia = value; }
        }

        public string Nome
        {
            get { return _pro_c_nome; }
            set { _pro_c_nome = value; }
        }

        public int CodigoLoja
        {
            get { return _pro_loj_n_codigo; }
            set { _pro_loj_n_codigo = value; }
        }


        #endregion

        public int Inserir(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_I_INSERIR_PRODUTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@PRO_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Descricao;
                sqlCommand.Parameters.Add("@PRO_C_TAMANHO", SqlDbType.VarChar).Value = objProduto.Tamanho;
                sqlCommand.Parameters.Add("@PRO_C_COR", SqlDbType.VarChar).Value = objProduto.Cor;
                sqlCommand.Parameters.Add("@PRO_CAT_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoCategoria;
                sqlCommand.Parameters.Add("@PRO_FAB_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoFabricante;
                sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;
                sqlCommand.Parameters.Add("@PRO_C_REFERENCIA", SqlDbType.VarChar).Value = objProduto.Referencia;
                sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;
                sqlCommand.Parameters.Add("@PRO_B_STATUS", SqlDbType.Bit).Value = objProduto.Status;
                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_U_ALTERAR_PRODUTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.Int).Value = objProduto.Codigo;

                sqlCommand.Parameters.Add("@PRO_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Descricao;
                sqlCommand.Parameters.Add("@PRO_C_TAMANHO", SqlDbType.VarChar).Value = objProduto.Tamanho;
                sqlCommand.Parameters.Add("@PRO_C_COR", SqlDbType.VarChar).Value = objProduto.Cor;
                sqlCommand.Parameters.Add("@PRO_CAT_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoCategoria;
                sqlCommand.Parameters.Add("@PRO_FAB_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoFabricante;
                sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;
                sqlCommand.Parameters.Add("@PRO_C_REFERENCIA", SqlDbType.VarChar).Value = objProduto.Referencia;
                sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;
                sqlCommand.Parameters.Add("@PRO_B_STATUS", SqlDbType.Bit).Value = objProduto.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_D_EXCLUIR_PRODUTO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.VarChar).Value = objProduto.Codigo;
                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Produto objProduto)
        {
            try
            {
                DataTable dtRetorno = new DataTable();
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTO");

                if (!string.IsNullOrEmpty(objProduto.Nome))
                    sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;

                if (!string.IsNullOrEmpty(objProduto.Tamanho))
                    sqlCommand.Parameters.Add("@PRO_C_TAMANHO", SqlDbType.VarChar).Value = objProduto.Tamanho;
                
                if (!string.IsNullOrEmpty(objProduto.Cor))
                    sqlCommand.Parameters.Add("@PRO_C_COR", SqlDbType.VarChar).Value = objProduto.Cor;

                if (objProduto.Status != null)
                    sqlCommand.Parameters.Add("@PRO_B_STATUS", SqlDbType.Bit).Value = objProduto.Status;

                if (objProduto.Codigo > 0)
                    sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.Int).Value = objProduto.Codigo;

                if(objProduto.CodigoFabricante > 0)
                    sqlCommand.Parameters.Add("@PRO_FAB_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoFabricante;

                if (objProduto.CodigoCategoria > 0)
                    sqlCommand.Parameters.Add("@PRO_CAT_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoCategoria;

                if (!string.IsNullOrEmpty(objProduto.CodigoProduto))
                    sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;

                if (!string.IsNullOrEmpty(objProduto.Referencia))
                    sqlCommand.Parameters.Add("@PRO_C_REFERENCIA", SqlDbType.VarChar).Value = objProduto.Referencia;

                if (!string.IsNullOrEmpty(objProduto.Categoria))
                    sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Categoria;

                if (!string.IsNullOrEmpty(objProduto.Fabricante))
                    sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Fabricante;

                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtRetorno =  db.ExecuteDataSet(sqlCommand).Tables[0];
                dtRetorno.Columns.Add("QtdeEstoqueTotal");
                dtRetorno.Columns.Add("ValorCustoEstoqueTotal");

                int intTotalQtde = 0;
                decimal decValorCusto = 0;

                foreach (DataRow dr in dtRetorno.Rows)
                {
                    intTotalQtde += Convert.ToInt32(dr["Qtde Estoque"]);
                    decValorCusto += (Convert.ToDecimal(dr["Valor Custo"]) * Convert.ToDecimal(dr["Qtde Estoque"]));
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

        public DataTable ListarVenda(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTO_VENDA");

                if (!string.IsNullOrEmpty(objProduto.Nome))
                    sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;

                if (!string.IsNullOrEmpty(objProduto.CodigoProduto))
                    sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;

                if (!string.IsNullOrEmpty(objProduto.Tamanho))
                    sqlCommand.Parameters.Add("@PRO_C_TAMANHO", SqlDbType.VarChar).Value = objProduto.Tamanho;

                if (!string.IsNullOrEmpty(objProduto.Cor))
                    sqlCommand.Parameters.Add("@PRO_C_COR", SqlDbType.VarChar).Value = objProduto.Cor;

                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ListarProdutoCombo(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTO_VENDA_COMBO");

                if (!string.IsNullOrEmpty(objProduto.Nome))
                    sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;

                if (!string.IsNullOrEmpty(objProduto.CodigoProduto))
                    sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;


                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ListarProdutoTrocaCombo(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTO_TROCA_COMBO");

                if (!string.IsNullOrEmpty(objProduto.Nome))
                    sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;

                if (!string.IsNullOrEmpty(objProduto.CodigoProduto))
                    sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;


                sqlCommand.Parameters.Add("@pro_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// listagem de produtos vendidos em um determinado período, em ordem decrescente de quantidade, listando assim os mais vendidos para os menos vendidos
        /// também é possível filtrar por marca
        /// O código da loja é obrigatório
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <param name="pintCodigoFabricante"></param>
        /// <returns></returns>
        public DataTable ListarProdutosVendidos(DateTime? dataInicio, DateTime? dataFim, Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTOS_VENDIDOS");

                if (dataInicio != null)
                    sqlCommand.Parameters.Add("@DATA_INICIO", SqlDbType.DateTime).Value = dataInicio;

                if (dataFim != null)
                    sqlCommand.Parameters.Add("@DATA_FIM", SqlDbType.DateTime).Value = dataFim;

                if (objProduto.CodigoFabricante > 0)
                    sqlCommand.Parameters.Add("@FAB_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoFabricante;

                if (objProduto.CodigoCategoria > 0)
                    sqlCommand.Parameters.Add("@CAT_N_CODIGO", SqlDbType.Int).Value = objProduto.CodigoCategoria;

                if(!string.IsNullOrEmpty(objProduto.CodigoProduto))
                    sqlCommand.Parameters.Add("@PRO_C_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;

                if (!string.IsNullOrEmpty(objProduto.Referencia))
                    sqlCommand.Parameters.Add("@PRO_C_REFERENCIA", SqlDbType.VarChar).Value = objProduto.Referencia;

                if (!string.IsNullOrEmpty(objProduto.Nome))
                    sqlCommand.Parameters.Add("@PRO_C_NOME", SqlDbType.VarChar).Value = objProduto.Nome;

                if (!string.IsNullOrEmpty(objProduto.Fabricante))
                    sqlCommand.Parameters.Add("@FAB_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Fabricante;

                if (!string.IsNullOrEmpty(objProduto.Categoria))
                    sqlCommand.Parameters.Add("@CAT_C_DESCRICAO", SqlDbType.VarChar).Value = objProduto.Categoria;

                sqlCommand.Parameters.Add("@VEN_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista as marcas mais vendidas e a qtde em estoque em um determinado período
        /// o código da loja é obrigatório
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public DataTable ListarMarcasVendidas(DateTime? dataInicio, DateTime? dataFim, int? CodigoFabricante)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_MARCAS_VENDIDOS");

                if (dataInicio != null)
                    sqlCommand.Parameters.Add("@DATA_INICIO", SqlDbType.DateTime).Value = dataInicio;

                if (dataFim != null)
                    sqlCommand.Parameters.Add("@DATA_FIM", SqlDbType.DateTime).Value = dataFim;

                if(CodigoFabricante != null)
                {
                    if(CodigoFabricante > 0)
                        sqlCommand.Parameters.Add("@FAB_N_CODIGO", SqlDbType.Int).Value = CodigoFabricante;
                }
                    

                sqlCommand.Parameters.Add("@VEN_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListarProdutoVendidoOuTrocado(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTO_VENDIDO_TROCADO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@PRO_LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;
                sqlCommand.Parameters.Add("@PRO_N_CODIGO", SqlDbType.VarChar).Value = objProduto.CodigoProduto;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet  ListarFiltros()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_PRO_L_LISTAR_PRODUTOS_FILTROS");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ListarFormaPagto(Produto objProduto)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("select * from tb_fpg_forma_pagto where fpg_b_status = 1 and fpg_loj_n_codigo = " + Utilitarios.intCodigoLoja + " order by fpg_c_descricao");

                sqlCommand.CommandType = CommandType.Text;

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
