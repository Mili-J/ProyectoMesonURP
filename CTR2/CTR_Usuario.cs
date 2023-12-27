using DAO;
using DTO;

namespace CTR
{
    public class CTR_Usuario
    {
        public DTO_Usuario validarUsuario(DTO_Usuario dto_usu)
        {
            return new DAO_Usuario().Login(dto_usu);
        }

        public DTO_Usuario CTR_ConsultarUsuario(int id)
        {
            return new DAO_Usuario().DAO_ConsultarUsuario(id);
        }
    }
}
