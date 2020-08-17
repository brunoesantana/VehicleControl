using NUnit.Framework;
using VehicleControl.CrossCutting.Helper;

namespace Helpers.Test
{
    public class EncryptHelperTest
    {
        private const string SENHA_12345_ENCRIPTADA = "WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=";
        private const string SENHA = "12345";

        [Test]
        public void Deve_encriptar_senha_corretamente()
        {
            var passwordEncrypt = EncryptHelper.EncryptPassword(SENHA);
            Assert.AreEqual(passwordEncrypt, SENHA_12345_ENCRIPTADA);
        }
    }
}
