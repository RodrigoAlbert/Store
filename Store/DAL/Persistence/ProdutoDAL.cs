using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Persistence
{
    public class ProdutoDAL
    {
        public void Adicionar(Produto p)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
