using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trainee.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Trainee.Business
{
    public class CadastroBusiness
    {
        private MySqlConnection connectionString;
        
        public cadastro NovoCadastro(cadastro dados)
        {
            if (string.IsNullOrEmpty(dados.RA.ToString()) && dados.RA.ToString().Length >= 7)
            {
                throw new Exception("Favor preencher o RA!");
            }

            if (string.IsNullOrEmpty(dados.Nome))
            {
                throw new Exception("Favor informar o Nome!");
            }

            if (string.IsNullOrEmpty(dados.Email))
            {
                throw new Exception("Favor informar o Email!");
            }

            if (string.IsNullOrEmpty(dados.Telefone))
            {
                throw new Exception("Favor informar o Telefone!");
            }

            if (string.IsNullOrEmpty(dados.CEP))
            {
                throw new Exception("Favor informar o CEP!");
            }

            if (string.IsNullOrEmpty(dados.Endereco))
            {
                throw new Exception("Favor informar o Endereço!");
            }

            if (string.IsNullOrEmpty(dados.Cidade))
            {
                throw new Exception("Favor informar o Cidade!");
            }

            if (string.IsNullOrEmpty(dados.Estado))
            {
                throw new Exception("Favor informar o Estado!");
            }

            if (string.IsNullOrEmpty(dados.Curso) && dados.Curso != "0")
            {
                throw new Exception("Favor informar o Curso!");
            }

            if (string.IsNullOrEmpty(dados.Semestre) && dados.Semestre != "0")
            {
                throw new Exception("Favor informar o Semestre!");
            }

            if (!dados.Sexo.Equals("F") && !dados.Sexo.Equals("M"))
            {
                throw new Exception("Favor informar o Sexo!");
            }

            try
            {
                Save(dados);

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private cadastro Save(cadastro dados)
        {
            try
            {
                connectionString = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                connectionString.Open();
                
                MySqlCommand command = new MySqlCommand("INSERT INTO cadastro(RA,Nome,Email,DataNasc,Telefone,Curso,Semestre,CEP,Endereco,Cidade,Estado,Sexo,Interno) " +
                    "VALUES('" + dados.RA + "','" 
                               + dados.Nome + "','"
                               + dados.Email + "','"
                               + dados.DataNasc.ToString("yyyy-MM-dd HH:mm:ss") + "','" 
                               + dados.Telefone + "','"
                               + dados.Curso + "','"
                               + dados.Semestre + "','"
                               + dados.CEP + "','"
                               + dados.Endereco + "','"
                               + dados.Cidade + "','"
                               + dados.Estado + "','"
                               + dados.Sexo + "','"
                               + dados.Interno + "');", connectionString);

                command.ExecuteNonQuery();

                connectionString.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dados;
        }

    }
}