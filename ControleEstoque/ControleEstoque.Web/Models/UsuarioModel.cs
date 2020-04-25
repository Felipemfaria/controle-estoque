using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ControleEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var usuario = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source = DESKTOP-P80P593\SQLEXPRESS; Initial Catalog = controle_estoque; User Id=admin; Password=123";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = String.Format(
                        "SELECT COUNT(*) FROM USUARIO WHERE LOGIN='{0}' AND SENHA='{1}'", login, senha);

                    usuario = ((int)comando.ExecuteScalar() > 0);

                }
            }

            return usuario;
        }

    }
}