using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace loja
{
    public class Cliente
    {
        #region Atributos

        private int _cli_n_codigo;
        private string _cli_c_nome;
        private string _cli_c_cpf;
        private string _cli_c_telefone;
        private string _cli_c_endereco;
        private string _cli_c_bairro;
        private string _cli_c_cidade;
        private string _cli_c_email;
        private DateTime _cli_d_data_cadastro;

        #endregion

        #region Propriedades

        public int Codigo
        {
            get { return _cli_n_codigo; }
            set { _cli_n_codigo = value; }
        }

        public string Nome
        {
            get { return _cli_c_nome; }
            set { _cli_c_nome = value; }
        }

        public string CPF
        {
            get { return _cli_c_cpf; }
            set { _cli_c_cpf = value; }
        }

        public string Telefone
        {
            get { return _cli_c_telefone; }
            set { _cli_c_telefone = value; }
        }

        public string Endereco
        {
            get { return _cli_c_endereco; }
            set { _cli_c_endereco = value; }
        }

        public string Bairro
        {
            get { return _cli_c_bairro; }
            set { _cli_c_bairro = value; }
        }

        public string Cidade
        {
            get { return _cli_c_cidade; }
            set { _cli_c_cidade = value; }
        }

        public string Email
        {
            get { return _cli_c_email; }
            set { _cli_c_email = value; }
        }

        public DateTime  DataCadastro
        {
            get { return _cli_d_data_cadastro; }
            set { _cli_d_data_cadastro = value; }
        }

        #endregion

        public int Inserir(Cliente objCliente)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CLI_I_INSERIR_CLIENTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                if(!string.IsNullOrEmpty(objCliente.Nome))
                    sqlCommand.Parameters.Add("@cli_c_nome", SqlDbType.VarChar).Value = objCliente.Nome;

                if (!string.IsNullOrEmpty(objCliente.CPF))
                    sqlCommand.Parameters.Add("@cli_c_CPF", SqlDbType.VarChar).Value = objCliente.CPF;

                if (!string.IsNullOrEmpty(objCliente.Telefone))
                    sqlCommand.Parameters.Add("@cli_c_telefone", SqlDbType.VarChar).Value = objCliente.Telefone;

                if (!string.IsNullOrEmpty(objCliente.Endereco))
                    sqlCommand.Parameters.Add("@cli_c_endereco", SqlDbType.VarChar).Value = objCliente.Endereco;

                if (!string.IsNullOrEmpty(objCliente.Bairro))
                    sqlCommand.Parameters.Add("@cli_c_bairro", SqlDbType.VarChar).Value = objCliente.Bairro;

                if (!string.IsNullOrEmpty(objCliente.Cidade))
                    sqlCommand.Parameters.Add("@cli_c_cidade", SqlDbType.VarChar).Value = objCliente.Cidade;

                if (!string.IsNullOrEmpty(objCliente.Email))
                    sqlCommand.Parameters.Add("@cli_c_email", SqlDbType.VarChar).Value = objCliente.Email;

                sqlCommand.Parameters.Add("@cli_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

                return Convert.ToInt32(db.ExecuteScalar(sqlCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Cliente objCliente)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CLI_U_ALTERAR_CLIENTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CLI_N_CODIGO", SqlDbType.Int).Value = objCliente.Codigo;

                if (!string.IsNullOrEmpty(objCliente.Nome))
                    sqlCommand.Parameters.Add("@cli_c_nome", SqlDbType.VarChar).Value = objCliente.Nome;

                if (!string.IsNullOrEmpty(objCliente.CPF))
                    sqlCommand.Parameters.Add("@cli_c_CPF", SqlDbType.VarChar).Value = objCliente.CPF;

                if (!string.IsNullOrEmpty(objCliente.Telefone))
                    sqlCommand.Parameters.Add("@cli_c_telefone", SqlDbType.VarChar).Value = objCliente.Telefone;

                if (!string.IsNullOrEmpty(objCliente.Endereco))
                    sqlCommand.Parameters.Add("@cli_c_endereco", SqlDbType.VarChar).Value = objCliente.Endereco;

                if (!string.IsNullOrEmpty(objCliente.Bairro))
                    sqlCommand.Parameters.Add("@cli_c_bairro", SqlDbType.VarChar).Value = objCliente.Bairro;

                if (!string.IsNullOrEmpty(objCliente.Cidade))
                    sqlCommand.Parameters.Add("@cli_c_cidade", SqlDbType.VarChar).Value = objCliente.Cidade;

                if (!string.IsNullOrEmpty(objCliente.Email))
                    sqlCommand.Parameters.Add("@cli_c_email", SqlDbType.VarChar).Value = objCliente.Email;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Cliente objCliente)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CLI_D_EXCLUIR_CLIENTE");

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@CLI_N_CODIGO", SqlDbType.Int).Value = objCliente.Codigo;

                db.ExecuteScalar(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Listar(Cliente objCliente)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                SqlCommand sqlCommand = new SqlCommand("SP_CLI_L_LISTAR_CLIENTE");

                if(objCliente.Codigo > 0)
                    sqlCommand.Parameters.Add("@CLI_N_CODIGO", SqlDbType.Int).Value = objCliente.Codigo;

                if (!string.IsNullOrEmpty(objCliente.Nome))
                    sqlCommand.Parameters.Add("@cli_c_nome", SqlDbType.VarChar).Value = objCliente.Nome;

                if (!string.IsNullOrEmpty(objCliente.CPF))
                    sqlCommand.Parameters.Add("@cli_c_CPF", SqlDbType.VarChar).Value = objCliente.CPF;

                if (!string.IsNullOrEmpty(objCliente.Telefone))
                    sqlCommand.Parameters.Add("@cli_c_telefone", SqlDbType.VarChar).Value = objCliente.Telefone;

                if (!string.IsNullOrEmpty(objCliente.Endereco))
                    sqlCommand.Parameters.Add("@cli_c_endereco", SqlDbType.VarChar).Value = objCliente.Endereco;

                if (!string.IsNullOrEmpty(objCliente.Bairro))
                    sqlCommand.Parameters.Add("@cli_c_bairro", SqlDbType.VarChar).Value = objCliente.Bairro;

                if (!string.IsNullOrEmpty(objCliente.Cidade))
                    sqlCommand.Parameters.Add("@cli_c_cidade", SqlDbType.VarChar).Value = objCliente.Cidade;

                if (!string.IsNullOrEmpty(objCliente.Email))
                    sqlCommand.Parameters.Add("@cli_c_email", SqlDbType.VarChar).Value = objCliente.Email;

                sqlCommand.Parameters.Add("@cli_loj_n_codigo", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

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
