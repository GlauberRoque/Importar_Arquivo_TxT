using Desafio_1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_1.Classes
{
    class Pessoa
    {
        public string Nome;
        public string Telefone;
        public string Cidade;
        public string Rg;
        public string Cpf;
        public int CountP;

        public bool gravarPessoa()
        {

            banco Banco = new banco();

            SqlConnection cn = Banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into Pessoa" + " values (@Nome, @Telefone, @Cidade, @Rg, @Cpf);";
            command.Parameters.Add("@Nome", SqlDbType.VarChar);
            command.Parameters.Add("@Telefone", SqlDbType.VarChar);
            command.Parameters.Add("@Cidade", SqlDbType.VarChar);
            command.Parameters.Add("@Rg", SqlDbType.VarChar);
            command.Parameters.Add("@Cpf", SqlDbType.VarChar);
            command.Parameters[0].Value = Nome;
            command.Parameters[1].Value = Telefone;
            command.Parameters[2].Value = Cidade;
            command.Parameters[3].Value = Rg;
            command.Parameters[4].Value = Cpf;
           


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


    

