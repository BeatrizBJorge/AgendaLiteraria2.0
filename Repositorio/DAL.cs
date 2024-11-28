using Microsoft.Data.SqlClient;
using System.Data;

namespace Agenda_Lieraria2._0.Repositorio
{
    public class DAL
    {
        static readonly DAL _instance = new DAL();
        public static DAL getInstance
        {
            get
            {
                return _instance;
            }
        }

        private string _stringConexao = "";

        public string stringConexao
        {
            get
            {
                if (_stringConexao == "")
                {
                    //_stringConexao = Resources.conexao;
                }
                return _stringConexao;
            }
            set { _stringConexao = value; }
        }

        public SqlConnection buscaSqlConnection()
        {
            SqlConnection mySqlconn = new SqlConnection();
            mySqlconn.ConnectionString = stringConexao;
            mySqlconn.Open();

            return mySqlconn;
        }
        public DataTable buscaDataTable(string fSql)
        {
            DataTable dtable = null;
            DataSet dset = new DataSet();
            SqlConnection sqlConn = null;
            try
            {
                sqlConn = buscaSqlConnection();
                using (SqlCommand cmd = new SqlCommand(fSql, sqlConn))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dset);
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                fechaSqlConnection(sqlConn);
                throw ex;
            }
            finally
            {
                fechaSqlConnection(sqlConn);
            }
            if (dset.Tables.Count > 0)
            {
                dtable = dset.Tables[0];
            }
            return dtable;
        }

        public bool ExecuteSql(string fSql)
        {
            bool ok = false;

            SqlConnection sqlConn = null;

            try
            {
                sqlConn = buscaSqlConnection();

                using (SqlCommand sqlCommand = new SqlCommand(fSql, sqlConn))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                }
                ok = true;
            }
            catch (Exception)
            {
                ok = false;

                if (sqlConn != null)
                {
                    fechaSqlConnection(sqlConn);
                }
                throw;
            }
            finally
            {
                if (sqlConn != null)
                {
                    fechaSqlConnection(sqlConn);
                }

            }

            return ok;
        }


        private void fechaSqlConnection(SqlConnection conn)
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                conn = null;
            }
        }
    }
}
