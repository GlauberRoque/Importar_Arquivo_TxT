using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Desafio_1.Classes;

namespace Desafio_1
{
    public partial class Form1 : Form
    {
        public int CountP;
        public int CountA;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        { 

            banco Banco = new banco();

            string sql = "select * from Pessoa";

            DataTable dt = new DataTable();

            dt = Banco.executarConsulta(sql);

            dataGridView1.DataSource = dt;

        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {

            banco Banco = new banco();

            string sql = "select * from Aluno";

            DataTable dt = new DataTable();

            dt = Banco.executarConsulta(sql);

            dataGridView1.DataSource = dt;

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

            string linha;
            string[] d;
            StreamReader sr = new StreamReader(@"C:\Users\Glauber Roque\Downloads\desafio1.txt");
            linha = sr.ReadLine();
            Pessoa pessoa = new Pessoa();
            Aluno aluno = new Aluno();

            while (linha != null)
            {
                d = linha.Split('-');
                string Nome_Pessoa;

                if (d[0].Equals("X"))
                {
                    linha = sr.ReadLine();
                    continue;
                }

                else if (d[0] == "Z")
                {
                    pessoa.Nome = d[1];
                    pessoa.Telefone = d[2];
                    pessoa.Cidade = d[3];
                    pessoa.Rg = d[4];
                    pessoa.Cpf = d[5];
                    Nome_Pessoa = pessoa.Nome;

                    bool retornoPessoa = pessoa.gravarPessoa();

                    linha = sr.ReadLine();
                    CountP++;
                }
                else if (d[0] == "Y")
                {
                    aluno.Matricula = d[1];
                    aluno.CodCurso = d[2];
                    aluno.NomeCurso = d[3];
                    aluno.NomePessoa = pessoa.Nome;

                    bool retornoAluno = aluno.gravarAluno();

                    linha = sr.ReadLine();
                    CountA++;
                }



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            banco Banco = new banco();

            string sql = "select count(*) from Pessoa";

            DataTable dt = new DataTable();

            dt = Banco.executarConsulta(sql);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            banco Banco = new banco();

            string sql = "select count(*) from Aluno";

            DataTable dt = new DataTable();

            dt = Banco.executarConsulta(sql);

            dataGridView1.DataSource = dt;
        }
    }
}
