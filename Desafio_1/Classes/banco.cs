using System;
using System.Data;
using System.Data.SqlClient;


namespace Desafio_1.Classes
{
    class banco
    {

        //fazendo a conexão com o banco de dados
        private string stringConexao = "Data Source=localhost; Initial Catalog=CRUD_Desafio; User ID=usuarioCrud; password=senha; language=portuguese";

        private SqlConnection cn;

        private void conexao() // vai vincular a string com a cn, e inicia o CN
        {
            cn = new SqlConnection(stringConexao);
        }

        public SqlConnection abrirConexao()
        {
            try
            {
                //vai tentar fazer algo
                conexao();
                cn.Open();

                return cn;
            }
            catch (Exception ex)
            {
                // faz algo se der erro no try


                return null;
            }
        }

        public void fecharConexao()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {

                return;
            }
        }

        public DataTable executarConsulta(string sql)
        {
            try
            {

                abrirConexao();

                SqlCommand command = new SqlCommand(sql, cn);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                fecharConexao();
            }
        }

    }


}