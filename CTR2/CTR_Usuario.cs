using DAO;
using DTO;

namespace CTR
{
    public class CTR_Usuario
    {
        DAO_Usuario dao_usu = new DAO_Usuario();
        public DTO_Usuario validarUsuario(DTO_Usuario dto_usu)
        {
            return new DAO_Usuario().Login(dto_usu);
        }
        public void getPerfil(DTO_Usuario dto_usu, DTO_TipoUsuario dto_tus)
        {
            dao_usu.getPerfil(dto_usu, dto_tus);
        }
        public DTO_Usuario CTR_ConsultarUsuario(int id)
        {
            return dao_usu.DAO_ConsultarUsuario(id);
        }
    }
}
