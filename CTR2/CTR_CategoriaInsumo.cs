﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;

namespace CTR
{
    public class CTR_CategoriaInsumo
    {
        DAO_CategoriaInsumo dao_catIns;
        public CTR_CategoriaInsumo()
        {
            dao_catIns = new DAO_CategoriaInsumo();
        }
        public DataTable DAO_ConsultarCategoriasInsumo()
        {
            return dao_catIns.DAO_ConsultarCategoriasInsumo();
        }
    }
}
