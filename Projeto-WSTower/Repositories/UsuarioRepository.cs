using Projeto_WSTower.Contexts;
using Projeto_WSTower.Domains;
using Projeto_WSTower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.Repositories
{
    public class UsuarioRepository
    {
        CampeonatoContext ctx = new CampeonatoContext();

        public void Atualizar(int id,Usuario userAtlz)
        {
            var userDB = ctx.Usuario.Find(id);

            if ((userAtlz.Nome != null) || (userDB.Nome != userAtlz.Nome))
                userDB.Nome = userAtlz.Nome;
            if ((userAtlz.Email != null) || (userDB.Apelido != userAtlz.Apelido))
                userDB.Email = userAtlz.Email;
            if (userAtlz.Apelido != null)
                userDB.Apelido = userAtlz.Apelido;
            if (userAtlz.Foto != null)
                userDB.Foto = userAtlz.Foto;

            ctx.Usuario.Update(userDB);
            ctx.SaveChanges();
        }

        public void AtulizarSenha(SenhaViewModel Atlzsenha)
        {
            var userDB = ctx.Usuario.Find(Atlzsenha.Id);
                
            userDB.Senha = Atlzsenha.Senha;

            ctx.Usuario.Update(userDB);
            ctx.SaveChanges();
        }
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.Find(id);
        }
        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuario.FirstOrDefault(e => e.Email == email);
        }
        public Usuario BuscarPorApelido(string apelido)
        {
            return ctx.Usuario.FirstOrDefault(e => e.Apelido == apelido);
        }

        public void Cadastrar(Usuario user)
        {
            ctx.Usuario.Add(user);

            ctx.SaveChanges();
        }

        public Usuario Login(LoginViewModel user)
        {
            if(ctx.Usuario.FirstOrDefault(u => u.Email == user.Usuario) != null)
            {
                return ctx.Usuario.FirstOrDefault(e => e.Email == user.Usuario && e.Senha == user.Senha);

            }
            if(ctx.Usuario.FirstOrDefault(u => u.Apelido == user.Usuario) != null)
            {
                return ctx.Usuario.FirstOrDefault(e => e.Apelido == user.Usuario && e.Senha == user.Senha);
            }

            return null;
        }
    }
}
