using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tocaLivrosDataBase
{
    /// <summary>
    /// Objeto Cliente responsavel por fazer o pedido, Cliente pode ser tanto pessoa física ou jurídica
    /// </summary>
    /// <param name="conn">Conexão com banco dados,local do banco</param>
    /// <param name="reader">Consulta dos dados, retorno mais rapido </param>
    /// <param name="connectionString">sting com configuração do banco </param>
    public class ConectionDb
    {
        private SqlConnection conn;

        private string connectionString;
        private SqlDataReader reader;


        public DataSet returDataSet(string _sql)
        {
           
            try
            {
                using (conn = new SqlConnection(conectionString()))
                {
                    //Obrigatorio Open mesmo usando using
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(_sql,conn);
                    DataSet dts = new DataSet();
                    adp.Fill(dts);
                    return dts;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable executeReader(string _sql)
        {
            try
            {
                DataTable dt = new DataTable();
                using(conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(_sql, conn))
                    {
                        reader = comm.ExecuteReader();
                        dt.Load(reader);
                        return dt;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int executeNoQuery(string _sql)
        {
            try
            {
                using(conn=new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand(_sql, conn))
                    {
                      int resposta=  cmd.ExecuteNonQuery();
                        return resposta;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string conectionString()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            int index = baseDir.IndexOf("\\tocaLivros");
            string dataDir = baseDir.Substring(0, index);
            dataDir= dataDir+"\\tocaLivros\\tocaLivrosDataBase\\tocaLivros.mdf";
            //dataDir= @"C:\Users\Tree\Documents\Visual Studio 2015\Projects\tocaLivros\tocaLivrosDataBase\tocaLivros.mdf";
             connectionString  = @"Data Source=MSSQL1;Server=.\SQLExpress;AttachDbFilename="+dataDir+ ";Database=tocaLivros;Trusted_Connection=Yes;User Instance = True";
            return connectionString;
        }

    }
}
