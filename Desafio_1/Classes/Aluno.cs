using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Desafio_1.Classes
{
    class Aluno : Pessoa
    {
        public string Matricula;
        public string NomeCurso;
        public string CodCurso;
        public string NomePessoa;

        public bool gravarAluno()
        {

            banco Banco = new banco();

            SqlConnection cn = Banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into Aluno" + " values (@Matricula, @NomeCurso, @CodCurso, @NomePessoa);";
            command.Parameters.Add("@Matricula", SqlDbType.VarChar);
            command.Parameters.Add("@NomeCurso", SqlDbType.VarChar);
            command.Parameters.Add("@CodCurso", SqlDbType.VarChar);
            command.Parameters.Add("@NomePessoa", SqlDbType.VarChar);


            command.Parameters[0].Value = Matricula;
            command.Parameters[1].Value = CodCurso;
            command.Parameters[2].Value = NomeCurso;
            command.Parameters[3].Value = NomePessoa;






            try
            {
                command.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {

                tran.Rollback();
                return false;

            }
            finally
            {
                Banco.fecharConexao();
            }

        }

    }
}
