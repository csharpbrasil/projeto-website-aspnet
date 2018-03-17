using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Linq;

namespace WebSite.Business
{
    public class Usuarios
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public bool Erro { get; set; }
        public string MensagemErro { get; set; }

        public Usuarios()
        {
            this.Erro = false;
            this.MensagemErro = string.Empty;
        }

        public Entities.Usuarios AutenticaUsuario(string Login, string Senha)
        {
            Entities.Usuarios[] usuarios = ListaUsuarios(new Entities.Usuarios(Login, Senha));
            Entities.Usuarios usuario = usuarios.FirstOrDefault();

            if (usuario == null)
            {
                this.Erro = true;
                this.MensagemErro = "Usuário ou senha inválido";
            }

            return usuario;
        }

        public bool LoginCadastrado(string Login)
        {
            Entities.Usuarios[] usuarios = ListaUsuarios(new Entities.Usuarios(Login));
            Entities.Usuarios usuario = usuarios.FirstOrDefault();
            
            bool existe = usuario != null && usuario.Id > 0;

            return existe;
        }

        public Entities.Usuarios[] ListaUsuarios()
        {
            return ListaUsuarios(null);
        }

        public Entities.Usuarios[] ListaUsuarios(Entities.Usuarios usuario)
        {
            List<Entities.Usuarios> lstUsuarios = new List<Entities.Usuarios>();

            Data.Connection connection = new Data.Connection(this.ConnectionString);
            connection.AbrirConexao();

            StringBuilder sqlString = new StringBuilder();
            sqlString.AppendLine("select * from usuarios");

            if (usuario != null)
            {
                sqlString.AppendLine("where 1 = 1");

                if (usuario.Id > 0)
                {
                    sqlString.AppendLine("and id_usuario = " + usuario.Id + "");
                }

                if (!string.IsNullOrEmpty(usuario.Login) && usuario.Login.Length > 0)
                {
                    sqlString.AppendLine("and login_usuario like '" + usuario.Login.Replace("'", "''") + "'");
                }

                if (!string.IsNullOrEmpty(usuario.Senha) && usuario.Senha.Length > 0)
                {
                    sqlString.AppendLine("and senha_usuario = '" + usuario.Senha + "'");
                }
            }

            IDataReader reader = connection.RetornaDados(sqlString.ToString());

            int idxId = reader.GetOrdinal("ID_USUARIO");
            int idxNome = reader.GetOrdinal("NOME_USUARIO");
            int idxEmail = reader.GetOrdinal("EMAIL_USUARIO");
            int idxLogin = reader.GetOrdinal("LOGIN_USUARIO");
            int idxSenha = reader.GetOrdinal("SENHA_USUARIO");
            int idxAtivo = reader.GetOrdinal("ATIVO_USUARIO");

            while (reader.Read())
            {
                Entities.Usuarios _Usuario = new Entities.Usuarios();
                _Usuario.Id = reader.GetInt32(idxId);
                _Usuario.Nome = reader.GetString(idxNome);
                _Usuario.Email = reader.GetString(idxEmail);
                _Usuario.Login = reader.GetString(idxLogin);
                _Usuario.Senha = reader.GetString(idxSenha);
                _Usuario.Ativo = reader.GetInt32(idxAtivo) == 1;

                lstUsuarios.Add(_Usuario);
            }

            connection.FechaConexao();

            return lstUsuarios.ToArray();
        }

        public bool SalvaUsuario(Entities.Usuarios usuario)
        {
            bool salvou = false;

            if (usuario != null)
            {
                Data.Connection connection = new Data.Connection(this.ConnectionString);
                connection.AbrirConexao();

                StringBuilder sqlString = new StringBuilder();

                if (usuario.Id > 0)
                {
                    sqlString.AppendLine("update usuarios set");
                    sqlString.AppendLine("nome_usuario = '" + usuario.Nome.Replace("'", "''") + "',");
                    sqlString.AppendLine("email_usuario = '" + usuario.Email.Replace("'", "''") + "',");
                    sqlString.AppendLine("login_usuario = '" + usuario.Login.Replace("'", "''") + "',");
                    sqlString.AppendLine("ativo_usuario = " + (usuario.Ativo ? 1 : 0) + " ");
                    sqlString.AppendLine("where id_usuario = " + usuario.Id + "");
                }
                else
                {
                    if (!LoginCadastrado(usuario.Login))
                    {
                        sqlString.AppendLine("insert into usuarios(nome_usuario, email_usuario, login_usuario, senha_usuario, ativo_usuario)");
                        sqlString.AppendLine("values('" + usuario.Nome.Replace("'", "''") + "', '" + usuario.Email.Replace("'", "''") + "', '" + usuario.Login.Replace("'", "''") + "', '" + usuario.Senha.Replace("'", "''") + "', " + (usuario.Ativo ? 1 : 0) + ")");
                    }
                    else
                    {
                        this.Erro = true;
                        this.MensagemErro = "Login já está sendo utilizado.";
                    }
                }

                int i = connection.ExecutaComando(sqlString.ToString());
                salvou = i > 0;

                connection.FechaConexao();
            }

            return salvou;
        }

        public bool SalvaUsuario(int Id, string Nome, string Email, string Login, string Senha, bool Ativo)
        {
            return SalvaUsuario(new Entities.Usuarios(Id, Nome, Email, Login, Senha, Ativo));
        }
        
        public bool ExcluiUsuario(Entities.Usuarios usuario)
        {
            bool salvou = false;

            if (usuario != null && usuario.Id > 0)
            {
                Data.Connection connection = new Data.Connection(this.ConnectionString);
                connection.AbrirConexao();

                StringBuilder sqlString = new StringBuilder();
                sqlString.AppendLine("delete from usuarios");
                sqlString.AppendLine("where id_usuario = " + usuario.Id + "");

                int i = connection.ExecutaComando(sqlString.ToString());

                connection.FechaConexao();
            }

            return salvou;
        }

        public bool ExcluiUsuario(int Id)
        {
            return ExcluiUsuario(new Entities.Usuarios(Id));
        }
    }
}
