using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Persistence
{
    class UsuarioDAL : Conexao
    {
        public void Adicionar(Usuario u)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("insert into Usuarios (Nome, Email, Senha) values (@nome, @email, @senha)");
                    Cmd.Parameters.AddWithValue("@nome", u.Nome);
                    Cmd.Parameters.AddWithValue("@email", u.Email);
                    Cmd.Parameters.AddWithValue("@senha", u.Senha);

                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FechaConexao();
            }
        }

        public void Deletar(int Codigo)
        {
            try
            {
                Cmd = new SqlCommand("delete from Usuarios where Codigo=@codigo");
                Cmd.Parameters.AddWithValue("@codigo", Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally { FechaConexao(); }
        }
    }
}
