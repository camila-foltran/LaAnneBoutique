using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace loja
{
   public class Loja
    {
       private int _loj_n_codigo;
       private int _loj_emp_n_codigo;

       public int Codigo
       {
           get { return _loj_n_codigo; }
           set { _loj_n_codigo = value; }
       }

       public DataTable Listar()
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_LOJ_L_LISTAR_LOJA");

               sqlCommand.Parameters.Add("@LOJ_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoLoja;

               sqlCommand.CommandType = CommandType.StoredProcedure;

               sqlCommand.CommandTimeout = 9000;

               return db.ExecuteDataSet(sqlCommand).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataTable ListarPorEmpresa()
       {
           try
           {
               Database db = DatabaseFactory.CreateDatabase();

               SqlCommand sqlCommand = new SqlCommand("SP_LOJ_L_LISTAR_LOJA");

               sqlCommand.Parameters.Add("@LOJ_EMP_N_CODIGO", SqlDbType.Int).Value = Utilitarios.intCodigoEmpresa;

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
