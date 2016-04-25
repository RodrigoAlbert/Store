using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Persistence
{
    public class Conexao
    {

        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        public bool AbreConexao()
        {
            try
            {
                Con = new SqlConnection("Data Source=ALBERT;Initial Catalog=master;Integrated Security=True");
                Con.Open();

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void FechaConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
