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
                    Cmd = new SqlCommand("insert into Usuarios (Nome, Email, Senha) values (@nome, @email, @senha)", Con);
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
                Cmd = new SqlCommand("delete from Usuarios where Codigo=@codigo", Con);
                Cmd.Parameters.AddWithValue("@codigo", Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally { FechaConexao(); }
        }

        public void Atualizar(Usuario u)
        {
            try
            {
                Cmd = new SqlCommand("update Usuarios set(Nome=@nome, Email=@email, Senha=@senha) where Codigo=@codigo ", Con);
                Cmd.Parameters.AddWithValue("@nome", u.Nome);
                Cmd.Parameters.AddWithValue("@email", u.Email);
                Cmd.Parameters.AddWithValue("@senha", u.Senha);
                Cmd.Parameters.AddWithValue("@codigo", u.Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally { FechaConexao(); }
        }

        public List<Usuario> Listar()
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("select * from Usuarios", Con);
                    Dr = Cmd.ExecuteReader();

                    List<Usuario> lista = new List<Usuario>();
                    Usuario u = new Usuario();

                    while (Dr.Read())
                    {
                        u.Codigo = Convert.ToInt32(Dr["Codigo"]);
                        u.Nome = Convert.ToString(Dr["Nome"]);
                        u.Email = Convert.ToString(Dr["Email"]);
                        u.Senha = Convert.ToString(Dr["Senha"]);

                        lista.Add(u);
                    }

                    return lista;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { FechaConexao(); }
        }
    }
}
