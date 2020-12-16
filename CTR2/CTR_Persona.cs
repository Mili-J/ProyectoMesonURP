using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
namespace CTR
{
    public class CTR_Persona
    {
        DAO_Persona dao_persona;
        public CTR_Persona()
        {
            dao_persona = new DAO_Persona();
        }
        public DTO_Persona CTR_ConsultarPersona(int id)
        {
            return dao_persona.DAO_ConsultarPersona(id);
        }
    }
}
