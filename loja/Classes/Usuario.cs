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
using System.Configuration;

namespace loja
{
    public class Usuario
    {
        #region Atributos

        private int _usu_n_codigo;
        private string _usu_c_nome;
        private string _usu_c_login;
        private string _usu_c_senha;
        private string _usu_c_email;
        private bool? _usu_b_status;
        private string _usu_c_perfil;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _usu_n_codigo; }
            set { _usu_n_codigo = value; }
        }

        public string Nome
        {
            get { return _usu_c_nome; }
            set { _usu_c_nome = value; }
        }

        public string Login
        {
            get { return _usu_c_login; }
            set { _usu_c_login = value; }
        }

        public string Senha
        {
            get { return _usu_c_senha; }
            set { _usu_c_senha = value; }
        }

        public string Email
        {
            get { return _usu_c_email; }
            set { _usu_c_email = value; }
        }

        public bool? Status
        {
            get { return _usu_b_status; }
            set { _usu_b_status = value; }
        }

        public string Perfil
        {
            get { return _usu_c_perfil; }
            set { _usu_c_perfil = value; }
        }

        #endregion

        public int Inserir(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_I_INSERIR_USUARIO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(objUsuario.Nome))
                    sqlCommand.Parameters.Add("@USU_C_NOME", SqlDbType.VarChar).Value = objUsuario.Nome;

                if (!string.IsNullOrEmpty(objUsuario.Login))
                    sqlCommand.Parameters.Add("@USU_C_LOGIN", SqlDbType.VarChar).Value = objUsuario.Login;

                if (!string.IsNullOrEmpty(objUsuario.Senha))
                    sqlCommand.Parameters.Add("@USU_C_SENHA", SqlDbType.VarChar).Value = objUsuario.Senha;

                if (!string.IsNullOrEmpty(objUsuario.Perfil))
                    sqlCommand.Parameters.Add("@USU_C_PERFIL", SqlDbType.VarChar).Value = objUsuario.Perfil;

                if (!string.IsNullOrEmpty(objUsuario.Email))
                    sqlCommand.Parameters.Add("@USU_C_EMAIL", SqlDbType.VarChar).Value = objUsuario.Email;

                sqlCommand.Parameters.Add("@USU_B_STATUS", SqlDbType.Bit).Value = objUsuario.Status;
                sqlCommand.Parameters.Add("@usu_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_U_ALTERAR_USUARIO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@USU_N_CODIGO", SqlDbType.Int).Value = objUsuario.Codigo;

                if (!string.IsNullOrEmpty(objUsuario.Nome))
                    sqlCommand.Parameters.Add("@USU_C_NOME", SqlDbType.VarChar).Value = objUsuario.Nome;

                //if (!string.IsNullOrEmpty(objUsuario.Perfil))
                //    sqlCommand.Parameters.Add("@USU_C_PERFIL", SqlDbType.VarChar).Value = objUsuario.Perfil;

                if (!string.IsNullOrEmpty(objUsuario.Email))
                    sqlCommand.Parameters.Add("@USU_C_EMAIL", SqlDbType.VarChar).Value = objUsuario.Email;

                sqlCommand.Parameters.Add("@USU_B_STATUS", SqlDbType.Bit).Value = objUsuario.Status;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarSenha(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_U_ALTERAR_SENHA_USUARIO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@USU_N_CODIGO", SqlDbType.Int).Value = objUsuario.Codigo;
                sqlCommand.Parameters.Add("@USU_C_SENHA", SqlDbType.VarChar).Value = objUsuario.Senha;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_L_LISTAR_USUARIO");

                if (objUsuario.Codigo > 0)
                    sqlCommand.Parameters.Add("@USU_N_CODIGO", SqlDbType.Int).Value = objUsuario.Codigo;

                if (!string.IsNullOrEmpty(objUsuario.Login))
                    sqlCommand.Parameters.Add("@USU_C_LOGIN", SqlDbType.VarChar).Value = objUsuario.Login;

                if (!string.IsNullOrEmpty(objUsuario.Nome))
                    sqlCommand.Parameters.Add("@USU_C_NOME", SqlDbType.VarChar).Value = objUsuario.Nome;

                if (objUsuario.Status != null)
                    sqlCommand.Parameters.Add("@USU_B_STATUS", SqlDbType.Bit).Value = objUsuario.Status;

                if(!string.IsNullOrEmpty(objUsuario.Perfil))
                    sqlCommand.Parameters.Add("@USU_C_PERFIL", SqlDbType.VarChar).Value = objUsuario.Perfil;

                sqlCommand.Parameters.Add("@usu_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ObterLogin(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_L_OBTER_USUARIO");


                if (!string.IsNullOrEmpty(objUsuario.Login))
                    sqlCommand.Parameters.Add("@USU_C_LOGIN", SqlDbType.VarChar).Value = objUsuario.Login;

                if (!string.IsNullOrEmpty(objUsuario.Senha))
                    sqlCommand.Parameters.Add("@USU_C_SENHA", SqlDbType.VarChar).Value = objUsuario.Senha;

                sqlCommand.Parameters.Add("@usu_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.CommandTimeout = 9000;

                return db.ExecuteDataSet(sqlCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Excluir(Usuario objUsuario)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_USU_D_EXCLUIR_USUARIO");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@USU_N_CODIGO", SqlDbType.Int).Value = objUsuario.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public static class Utilitarios
    {
        public static string strVendedor;
        public static int intCodigoVendedor;
        public static bool blnAberturaCaixa;
        public static string strPerfil;
        public static int intCodigoLoja = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoLoja"]);
        public static int intCodigoEmpresa = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoEmpresa"]);
        public static int CodigoMunicipio = Convert.ToInt32(ConfigurationManager.AppSettings["CodigoMunicipio"]);
        public static int ModeloImpressora = Convert.ToInt32(ConfigurationManager.AppSettings["ModeloImpressora"]);
        public static string PortaImpressora = ConfigurationManager.AppSettings["PortaImpressora"].ToString();
        public static string CodigoSelecione = ConfigurationManager.AppSettings["CodigoSelecione"].ToString();
        public static string strNomeImpressora = ConfigurationManager.AppSettings["NomeImpressora"].ToString();

        public static string dadosProduto;

        public static int SalvarLog(string strMensagem, string strTela)
        {
            try
            {
                using (StreamWriter lendo = new StreamWriter(ConfigurationManager.AppSettings["CaminhoLog"].ToString(), true))
                {
                    lendo.WriteLine("DATA: " + DateTime.Now + " TELA: " + strTela + " -  ERRO: " + strMensagem + " - LOJA: " + ConfigurationManager.AppSettings["CodigoLoja"].ToString());
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
