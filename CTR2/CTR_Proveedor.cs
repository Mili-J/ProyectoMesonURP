using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;
namespace CTR
{
    public class CTR_Proveedor
    {
        DAO_Proveedor dao_pro;
        public CTR_Proveedor()
        {
            dao_pro = new DAO_Proveedor();
        }
        public DataTable CTR_ConsultarProveedores()
        {
            return dao_pro.DAO_ConsultarProveedores();
        }
        public DataTable ListarCategoriaProveedor(int PR_idProveedor)
        {
            return dao_pro.ListarCategoriaProveedor(PR_idProveedor);
        }
        public DTO_Proveedor CTR_ConsultarProveedor(int id)
        {
            return dao_pro.DAO_ConsultarProveedor(id);
        }
        public DataTable ListarProveedores(string razonSocial)
        {
            return dao_pro.ListarProveedores(razonSocial);
        }
        public void CambiarEstadoProveedor(int id, int estado)
        {
            dao_pro.CambiarEstadoProveedor(id, estado);
        }
        public int RegistrarProveedor(DTO_Proveedor obj)
        {

            return dao_pro.RegistrarProveedor(obj);
        }
        public void RegistrarProveedorxCategoria(int PR_idProveedor, int CI_idCategoriaInsumo)
        {
            dao_pro.RegistrarProveedorxCategoria(PR_idProveedor, CI_idCategoriaInsumo);
        }
        public List<int> TraerCategorias(int PR_idProveedor)
        {
            return dao_pro.TraerCategorias(PR_idProveedor);
        }

        public DTO_Proveedor traerProveedor(int PR_idProveedor)
        {
            return dao_pro.traerProveedor(PR_idProveedor);
        }

        public DTO_Proveedor actualizarProveedor(DTO_Proveedor obj)
        {
            return dao_pro.actualizarProveedor(obj);
        }
        public void EliminarProveedorxCategoria(int PR_idProveedor, int CI_idCategoriaInsumo)
        {
            dao_pro.EliminarProveedorxCategoria(PR_idProveedor, CI_idCategoriaInsumo);
        }
    }
}
