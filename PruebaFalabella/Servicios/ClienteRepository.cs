﻿using PruebaFalabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaFalabella.Servicios
{
    public class ClienteRepository
    {
        private FalabellaContext db = new FalabellaContext();

        internal Cliente ObtenerPorId(int id)
        {
            return db.Cliente.Where(x => x.Documento == id).SingleOrDefault();
        }
    }
}