using System.ComponentModel.DataAnnotations;

namespace VehicleControl.CrossCutting.DTO.User
{
    public class UserInsertDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Senha e confirmação de senha devem ser iguais.")]
        public string PasswordCheck { get; set; }
    }
}
