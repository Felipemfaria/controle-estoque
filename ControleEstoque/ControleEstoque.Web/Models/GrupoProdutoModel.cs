using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models
{
    public class GrupoProdutoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public static List<GrupoProdutoModel> findAll()
        {
            var ret = new List<GrupoProdutoModel>();

            using (var conexao = new SqlConnection())
            {
                try
                {
                    conexao.ConnectionString = conexao.ConnectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = "SELECT * FROM Grupo_Produto ORDER BY Nome";

                        var reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            ret.Add(new GrupoProdutoModel
                            {
                                id = (int)reader["id"],
                                Nome = (String)reader["Nome"],
                                Ativo = (bool)reader["Ativo"]
                            });
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw sqlEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ret;
        }

        public static GrupoProdutoModel findById(int id)
        {
            GrupoProdutoModel ret = null;

            using (var conexao = new SqlConnection())
            {
                try
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = String.Format("SELECT * FROM Grupo_Produto WHERE (id = {0})", id);

                        var reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            ret = new GrupoProdutoModel
                            {
                                id = (int)reader["id"],
                                Nome = (String)reader["Nome"],
                                Ativo = (bool)reader["Ativo"]
                            };
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw sqlEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ret;
        }

        public static bool remove(int id)
        {
            var ret = false;

            using (var conexao = new SqlConnection())
            {
                try
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = String.Format("DELETE FROM Grupo_Produto WHERE (id = {0})", id);

                        ret = (comando.ExecuteNonQuery() > 0);
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw sqlEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ret;
        }

        public int save()
        {
            var ret = 0;
            var model = findById(this.id);

            using (var conexao = new SqlConnection())
            {
                try
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;                     
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;

                        if (model == null)
                        {
                            comando.CommandText = String.Format("INSERT INTO Grupo_Produto (nome, ativo) VALUES ('{0}', {1}); SELECT CONVERT(int, SCOPE_IDENTITY())",
                                this.Nome, this.Ativo ? 1 : 0);

                            ret = (int)comando.ExecuteScalar();
                        }
                        else
                        {
                            comando.CommandText = String.Format("UPDATE Grupo_Produto SET nome = '{1}', ativo = {2} WHERE id = {0}",
                               this.id, this.Nome, this.Ativo ? 1 : 0);

                            if (comando.ExecuteNonQuery() > 0)
                            {
                                ret = this.id;                                    
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw sqlEx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ret;
        }
    }
}