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
    public class Venda
    {
        #region Atributos

        private int _ven_n_codigo;
        private int _ven_usu_n_codigo;
        private DateTime _ven_d_data;
        private DateTime _ven_d_data_inicio;
        private DateTime _ven_d_data_fim;
        private string _ven_c_forma_pagto;
        private string _ven_c_status;
        private decimal _ven_n_desconto;
        private decimal _ven_n_acrescimo;
        private decimal _ven_n_total;
        private string _pro_c_tamanho;
        private string _cat_c_descricao;
        private string _fab_c_descricao;
        private string _VEN_CLI_C_CNPJ;
        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _ven_n_codigo; }
            set { _ven_n_codigo = value; }
        }

        public int CodigoUsuario
        {
            get { return _ven_usu_n_codigo; }
            set { _ven_usu_n_codigo = value; }
        }

        public DateTime Data
        {
            get { return _ven_d_data; }
            set { _ven_d_data = value; }
        }

        public DateTime DataInicio
        {
            get { return _ven_d_data_inicio; }
            set { _ven_d_data_inicio = value; }
        }

        public DateTime DataFim
        {
            get { return _ven_d_data_fim; }
            set { _ven_d_data_fim = value; }
        }

        public string FormaPagto
        {
            get { return _ven_c_forma_pagto; }
            set { _ven_c_forma_pagto = value; }
        }

        public string Status
        {
            get { return _ven_c_status; }
            set { _ven_c_status = value; }
        }

        public decimal Desconto
        {
            get { return _ven_n_desconto; }
            set { _ven_n_desconto = value; }
        }

        public decimal Acrescimo
        {
            get { return _ven_n_acrescimo; }
            set { _ven_n_acrescimo = value; }
        }

        public decimal ValorTotal
        {
            get { return _ven_n_total; }
            set { _ven_n_total = value; }
        }

        public string Tamanho
        {
            get { return _pro_c_tamanho; }
            set { _pro_c_tamanho = value; }
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

        public string CNPJCliente
        {
            get { return _VEN_CLI_C_CNPJ; }
            set { _VEN_CLI_C_CNPJ = value; }
        }

        #endregion

        public int Inserir(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_I_INSERIR_VENDA");

                sqlCommand.CommandType = CommandType.StoredProcedure;


                sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;
                sqlCommand.Parameters.Add("@VEN_C_FORMA_PAGTO", SqlDbType.VarChar).Value = objVenda.FormaPagto;
                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_U_ALTERAR_VENDA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                if(objVenda.CodigoUsuario >0)
                    sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;

                if (!string.IsNullOrEmpty(objVenda.FormaPagto))
                    sqlCommand.Parameters.Add("@VEN_C_FORMA_PAGTO", SqlDbType.VarChar).Value = objVenda.FormaPagto;

                if (!string.IsNullOrEmpty(objVenda.Status))
                    sqlCommand.Parameters.Add("@VEN_C_STATUS", SqlDbType.VarChar).Value = objVenda.Status;

                sqlCommand.Parameters.Add("@VEN_N_DESCONTO", SqlDbType.Decimal).Value = objVenda.Desconto;
                sqlCommand.Parameters.Add("@VEN_N_ACRESCIMO", SqlDbType.Decimal).Value = objVenda.Acrescimo;
                sqlCommand.Parameters.Add("@VEN_N_TOTAL", SqlDbType.Decimal).Value = objVenda.ValorTotal;

                if(!string.IsNullOrEmpty(objVenda.CNPJCliente))
                    sqlCommand.Parameters.Add("@VEN_CLI_C_CNPJ", SqlDbType.VarChar).Value = objVenda.CNPJCliente;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_D_EXCLUIR_VENDA");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA");

                if (objVenda.Codigo > 0)
                    sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                if (objVenda.Data > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA", SqlDbType.DateTime).Value = objVenda.Data.ToShortDateString();

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                if (objVenda.CodigoUsuario >0)
                    sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;

                if(!string.IsNullOrEmpty(objVenda.FormaPagto))
                    sqlCommand.Parameters.Add("@VEN_C_FORMA_PAGTO", SqlDbType.VarChar).Value = objVenda.FormaPagto;

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListarPeriodo(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA_PERIODO");

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// LISTA O TOTAL VENDIDO NO MES/ANO
        /// </summary>
        /// <param name="objVenda"></param>
        /// <returns></returns>
        public DataTable ListarVendasMes(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataTable dtVendasMes = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA_ANO_MES_DIVINA");
               

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                if (objVenda.CodigoUsuario > 0)
                    sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtVendasMes =  db.ExecuteDataSet(sqlCommand).Tables[0];

                foreach(DataRow dr in dtVendasMes.Rows)
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

                if (objVenda.CodigoUsuario == 0)//significa que um administrador vai ver as vendas de todos os seus vendedores
                {
                    foreach (DataRow drVenda in dtVendasMes.Rows)
                    {
                        DataTable dtVendasPorVendedor = new DataTable();
                        objVenda = new Venda();
                        objVenda.DataInicio = Convert.ToDateTime("01/" + drVenda["MES"].ToString() + "/" + drVenda["ANO"].ToString());
                        objVenda.DataFim = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(drVenda["ANO"]), Convert.ToInt32(drVenda["MES"])) + "/" + drVenda["MES"].ToString() + "/" + drVenda["ANO"].ToString());
                    }

                }

                //if (objVenda.CodigoUsuario == 0)//significa que um administrador vai ver as vendas de todos os seus vendedores
                //{
                //    DataTable dtVendedores = new DataTable();
                //    Usuario objUsuario = new Usuario();
                //    objUsuario.Status = true;
                //    objUsuario.Perfil = "VENDEDOR";
                //    dtVendedores = objUsuario.Listar(objUsuario);

                //    foreach (DataRow drUser in dtVendedores.Rows)//para cada vendedor obtém o total vendido no período
                //    {
                //        dtVendasMes.Columns.Add(drUser["Nome"].ToString().ToUpper());

                //        foreach (DataRow drVenda in dtVendasMes.Rows)
                //        {
                //            objVenda = new Venda();
                //            DataTable dtVendaVendedor = new DataTable();
                //            objVenda.CodigoUsuario = Convert.ToInt32(drUser["Código"]);
                //            objVenda.DataInicio = Convert.ToDateTime("01/" + drVenda["MES"].ToString() + "/" + drVenda["ANO"].ToString());
                //            objVenda.DataFim = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(drVenda["ANO"]), Convert.ToInt32(drVenda["MES"])) + "/" + drVenda["MES"].ToString() + "/" + drVenda["ANO"].ToString());
                //            dtVendaVendedor = objVenda.ListarVendasMes(objVenda);

                //            if (dtVendaVendedor.Rows.Count > 0)
                //                drVenda[drUser["Nome"].ToString()] = Convert.ToDecimal(dtVendaVendedor.Rows[0]["TOTAL"]);
                //            else
                //                drVenda[drUser["Nome"].ToString()] = 0;
                //        }
                //    }
                //}

                return dtVendasMes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// LISTA TOTAL VENDIDO POR DIA EM UM PERÍODO INFORMADO
        /// </summary>
        /// <param name="objVenda"></param>
        /// <returns></returns>
        public DataTable ListarVendasdoMes(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataTable dtVendasMes = new DataTable();
                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA_PERIODO_MES_DIVINA");

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                if (objVenda.CodigoUsuario > 0)
                    sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtVendasMes = db.ExecuteDataSet(sqlCommand).Tables[0];

                decimal decTotal = 0, decTotalLucro = 0, decTotalCusto = 0, decTotalDinheiro = 0, decTotalCartao = 0, decTotalCompra = 0;

                foreach (DataRow dr in dtVendasMes.Rows)
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

                    decTotal += Convert.ToDecimal(dr["TOTAL"]);
                    decTotalCusto +=Convert.ToDecimal(dr["TOTAL_CUSTO"]);
                    decTotalLucro += Convert.ToDecimal(dr["LUCRO"]);
                    decTotalDinheiro += Convert.ToDecimal(dr["DINHEIRO"]);
                    decTotalCartao += Convert.ToDecimal(dr["CARTÃO"]);
                    decTotalCompra += Convert.ToDecimal(dr["COMPRA"]);
                }

                if (objVenda.CodigoUsuario == 0)//significa que um administrador vai ver as vendas de todos os seus vendedores
                {
                    foreach(DataRow dr in dtVendasMes.Rows)
                    {
                        DataTable dtVendasPorVendedor = new DataTable();
                        objVenda = new Venda();

                    }
                    
                }

                //if (objVenda.CodigoUsuario == 0)//significa que um administrador vai ver as vendas de todos os seus vendedores
                //{
                //    DataTable dtVendedores = new DataTable();
                //    Usuario objUsuario = new Usuario();
                //    objUsuario.Status = true;
                //    objUsuario.Perfil = "VENDEDOR";
                //    dtVendedores = objUsuario.Listar(objUsuario);

                //    foreach (DataRow drUser in dtVendedores.Rows)//para cada vendedor obtém o total vendido no período
                //    {
                //        dtVendasMes.Columns.Add(drUser["Nome"].ToString().ToUpper());

                //        foreach (DataRow drVenda in dtVendasMes.Rows)
                //        {
                //            objVenda = new Venda();
                //            DataTable dtVendaVendedor = new DataTable();
                //            objVenda.CodigoUsuario = Convert.ToInt32(drUser["Código"]);
                //            objVenda.DataInicio = Convert.ToDateTime(drVenda["DIA"].ToString() + "/" + drVenda["MES"].ToString() + "/" + drVenda["ANO"].ToString());
                //            objVenda.DataFim = objVenda.DataInicio;

                //            dtVendaVendedor = objVenda.ListarVendasMes(objVenda);

                //            if (dtVendaVendedor.Rows.Count > 0)
                //                drVenda[drUser["Nome"].ToString()] = Convert.ToDecimal(dtVendaVendedor.Rows[0]["TOTAL"]);
                //            else
                //                drVenda[drUser["Nome"].ToString()] = 0;
                //        }
                //    }
                //}

                dtVendasMes.Rows.Add(dtVendasMes.Rows[0]["ANO"].ToString(), 0, "", "TOTAL", decTotal, decTotalDinheiro, decTotalCartao, decTotalCusto, decTotalLucro, decTotalCompra);
                return dtVendasMes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista as vendas por vendedor de acordo com o período/loja informado
        /// </summary>
        /// <param name="objVenda"></param>
        /// <returns></returns>
        public DataTable ListarVendaPorMesVendedor(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA_POR_VENDEDOR");

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ListarVendaPorDiaVendedor(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_VENDA_PERIODO_MES_POR_VENDEDOR");

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ListarVendaDiaria(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataSet dtsVenda = new DataSet();
                DataSet dtsRetorno = new DataSet();
                SqlCommand sqlCommand = new SqlCommand("SP_ITV_L_LISTAR_ITENS_VENDA_DIARIA");

                if (objVenda.Codigo > 0)
                    sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                if (objVenda.Data > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@VEN_D_DATA", SqlDbType.DateTime).Value = objVenda.Data.ToShortDateString();

                if (objVenda.DataInicio > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@DATA_INICIO", SqlDbType.DateTime).Value = objVenda.DataInicio.ToShortDateString();

                if (objVenda.DataFim > DateTime.MinValue)
                    sqlCommand.Parameters.Add("@DATA_FIM", SqlDbType.DateTime).Value = objVenda.DataFim.ToShortDateString();

                if (objVenda.CodigoUsuario > 0)
                    sqlCommand.Parameters.Add("@VEN_USU_N_CODIGO", SqlDbType.Int).Value = objVenda.CodigoUsuario;

                if (!string.IsNullOrEmpty(objVenda.FormaPagto))
                    sqlCommand.Parameters.Add("@VEN_C_FORMA_PAGTO", SqlDbType.VarChar).Value = objVenda.FormaPagto;

                sqlCommand.Parameters.Add("@ven_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtsVenda = db.ExecuteDataSet(sqlCommand);

                DataTable dtItensVenda = dtsVenda.Tables[0];

                DataView view = new DataView(dtItensVenda);
                DataTable distinctValues = view.ToTable(true, "Código Venda");

                //para cada código de venda acrescenta linha com os totais
                foreach (DataRow dr in distinctValues.Rows)
                {
                    DataRow[] drItens = dtItensVenda.Select("[Código Venda] = " + dr["Código Venda"].ToString());

                    //if (drItens.Length > 1)
                    //{
                        dtItensVenda.Rows.Add(dr["Código Venda"].ToString(), 0, "", "", "TOTAL", Convert.ToInt32(drItens[0]["Qtde Total"]),
                                                                                             Convert.ToDecimal(drItens[0]["Total Venda"]),
                                                                                             Convert.ToDecimal(drItens[0]["Desconto"]),
                                                                                             Convert.ToDecimal(drItens[0]["Acrescimo"]),
                                                                                             Convert.ToDecimal(drItens[0]["TOTAL"])
                                         );

                        //para cada linha do item da venda zera o desconto, acrescimo e total da venda para só exibir no total da venda
                        foreach (DataRow drLinha in drItens)
                        {
                            drLinha["Desconto"] = "0,00";
                            drLinha["Acrescimo"] = "0,00";
                            drLinha["Total Venda"] = "0,00";
                        }
                    //}
                    
                   
                }

                 view = new DataView(dtItensVenda);
                 view.Sort = "Código Venda";

                 dtsVenda.Tables.Add(view.ToTable("ItensVenda"));

                 return dtsVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable VerificaValorVenda (Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataSet dtsVenda = new DataSet();
                DataTable dtVenda = new DataTable();
                DataSet dtsRetorno = new DataSet();
                SqlCommand sqlCommand = new SqlCommand("SP_VEN_VERIFICA_VALOR_VENDA");

                sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                dtsVenda = db.ExecuteDataSet(sqlCommand);

                dtVenda.Columns.Add("TOTAL_VENDA");
                dtVenda.Columns.Add("TOTAL_REGISTRADO");

                if (dtsVenda.Tables[0].Rows.Count > 0 && dtsVenda.Tables[1].Rows.Count > 0)
                {
                    dtVenda.Rows.Add(dtsVenda.Tables[0].Rows[0]["TOTAL_VENDA"].ToString(), dtsVenda.Tables[1].Rows[0]["TOTAL_REGISTRADO"].ToString());
                }
                else
                    dtVenda.Rows.Add(0);

                return dtVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet ListarDadosNFE(Venda objVenda)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataSet dtsVenda = new DataSet();
                DataSet dtsRetorno = new DataSet();
                SqlCommand sqlCommand = new SqlCommand("SP_VEN_L_LISTAR_DADOS_NFE");

                if (objVenda.Codigo > 0)
                    sqlCommand.Parameters.Add("@VEN_N_CODIGO", SqlDbType.Int).Value = objVenda.Codigo;

                sqlCommand.Parameters.Add("@CODIGO_EMPRESA", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 9000;
                dtsVenda = db.ExecuteDataSet(sqlCommand);

                return dtsVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
