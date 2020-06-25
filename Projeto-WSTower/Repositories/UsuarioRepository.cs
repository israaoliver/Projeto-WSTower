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
