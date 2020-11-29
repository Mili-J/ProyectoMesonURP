using DAO2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR2
{
    public class CTR_EstadoReceta
    {
        DAO_EstadoReceta objDao;
        public CTR_EstadoReceta()
        {
            objDao = new DAO_EstadoReceta();
        }
        public DataSet CargarEstadoReceta()
        {
            return objDao.SelectEstadoReceta();
        }
        public string CargarEstadoxIdReceta(int R_idReceta)
        {
            return objDao.SelectEstadoxIdReceta(R_idReceta);
        }
        public int CargarIdEstadoxIdReceta(int R_idReceta)
        {
            return objDao.SelectIdEstadoxIdReceta(R_idReceta);
        }
    }
}
