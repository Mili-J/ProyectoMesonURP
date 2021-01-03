using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_MedidaXFormatoCompra
    {
        DAO_MedidaXFormatoCompra dao_medidaXFormatoCompra;
        public CTR_MedidaXFormatoCompra()
        {
            dao_medidaXFormatoCompra = new DAO_MedidaXFormatoCompra();
        }
        public DTO_MedidaXFormatoCompra CTR_ConsultarMedidaXFormatoCompra(int id)
        {
            return dao_medidaXFormatoCompra.DAO_ConsultarMedidaXFormatoCompra(id);
        }
    }
}
