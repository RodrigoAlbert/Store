using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Persistence
{
    public class ProdutoDAL : Conexao
    {
        public void Adicionar(Produto p)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("insert into Produtos (Nome, Area, Quantidade, Modelo) values (@nome, @area, @quantidade, @modelo)", Con);
                    Cmd.Parameters.AddWithValue("@nome", p.Nome);
                    Cmd.Parameters.AddWithValue("@area", p.Area);
                    Cmd.Parameters.AddWithValue("@quantidade", p.Quantidade);
                    Cmd.Parameters.AddWithValue("@modelo", p.Modelo);

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

        public void Deletar(int Id)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("delete from Produtos where Id=@id",Con);
                    Cmd.Parameters.AddWithValue("@id",Id);

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

        public void Atualizar(Produto p)
        {
            try
            {
                if (AbreConexao())
                {
                    Cmd = new SqlCommand("update Produtos set (Nome=@nome, Area=@area, Quantidade=@quantidade, Modelo=@modelo) where Id=@id",Con);
                    Cmd.Parameters.AddWithValue("@id", p.Id);
                    Cmd.Parameters.AddWithValue("@nome", p.Nome);
                    Cmd.Parameters.AddWithValue("@quantidade", p.Quantidade);
                    Cmd.Parameters.AddWithValue("@modelo", p.Modelo);
                    Cmd.Parameters.AddWithValue("@area", p.Area);

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
    }
}
