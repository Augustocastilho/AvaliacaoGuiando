using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

/*métodos responsáveis por abrir e fechar a conexão com o banco de dados,
 * inserir e listar os registros da tabela*/

namespace AvaliacaoGuiando.Models
{
    public class FornecedorModel : System.IDisposable
    {
        private SqlConnection connection;

        public FornecedorModel()
        {
            string strConn = "Data Source=.\\SQLEXPRESS;Initial Catalog=AVALICAO_GUIANDO;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void AddFornecedor(Fornecedor fornecedor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Fornecedor VALUES (@nome, @vertical, @link, @logo, @historico)";

            cmd.Parameters.AddWithValue("@nome", fornecedor.nome);
            cmd.Parameters.AddWithValue("@vertical", fornecedor.vertical);
            cmd.Parameters.AddWithValue("@linkl", fornecedor.link);
            cmd.Parameters.AddWithValue("@logo", fornecedor.logo);
            cmd.Parameters.AddWithValue("@historico", fornecedor.historico);

            cmd.ExecuteNonQuery();
        }

        public List<Fornecedor> Read()
        {
            List<Fornecedor> lista = new List<Fornecedor>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Fornecedor";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Fornecedor fornecedor = new Fornecedor();
                fornecedor.idFornecedor = (int)reader["ID_Fornecedor"];
                fornecedor.nome = (string)reader["Nome"];
                fornecedor.vertical = (string)reader["Vertical"];
                fornecedor.link = (string)reader["Link"];
                fornecedor.logo = (Bitmap)reader["Logo"];
                fornecedor.historico = (bool)reader["Historico"];

                lista.Add(fornecedor);
            }

            return lista;
        }
    }
}
