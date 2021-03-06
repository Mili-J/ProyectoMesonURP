﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public  class CTR_Menu
    {
        DAO_Menu dao_menu;
        public CTR_Menu()
        {
            dao_menu = new DAO_Menu();
        }
        public void CTR_RegistrarMenu(DTO_Menu dto_menu)
        {
            dao_menu.DAO_RegistrarMenu(dto_menu);
        }
        public int CTR_IdMenuMayor()
        {
            return dao_menu.DAO_IdMenuMayor();
        }
        public DTO_Menu CTR_ConsultarMenu(DateTime fecha)
        {
            return dao_menu.DAO_ConsultarMenu(fecha);
        }
        public bool CTR_HayMenu(DateTime fecha)
        {
            return dao_menu.DAO_HayMenu(fecha);
        }
        public void CTR_ActualizarMenu(DTO_Menu obj)
        {
            dao_menu.DAO_ActualizarMenu(obj);
        }
        public void CTR_ActualizaEstadoMenu(DTO_Menu obj)
        {

            dao_menu.DAO_ActualizaEstadoMenu(obj);
        }
        public DataTable CTR_ConsultarMenusXEstadoYFecha(int estado, DateTime fecha)
        {
            return dao_menu.DAO_ConsultarMenusXEstadoYFecha(estado,fecha);
        }
        public DTO_Menu CTR_ConsultarMenuXID(int id)
        {
            return dao_menu.DAO_ConsultarMenuXID(id);
        }
        public DataTable DAO_ConsultarMenusXYFecha(DateTime fecha)
        {
            return dao_menu.DAO_ConsultarMenusXYFecha(fecha);
        }
        public DataTable CTR_SelectMenuXFecha(string fecha)
        {
            return dao_menu.DAO_SelectMenuXFecha(fecha);
        }
    }
}
