using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace xUnitPoc.Dominio.Teste._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string msg)
        {
            if (exception.Message == msg)
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{msg}'");

        }
    }
}
