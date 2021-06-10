using System;

namespace Dominio.Excecoes
{
    public class UsuarioOuSenhaException : Exception
    {
        public UsuarioOuSenhaException(string message) : base(message)
        {
        }

        public static void LancarQuando(Func<bool> expressao,String mensagem)
        {
            if(expressao.Invoke()==true)
            {
                throw new UsuarioOuSenhaException(mensagem);
            }
        }
    }
}
