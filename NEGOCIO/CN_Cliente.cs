﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIO
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        public Cliente obtenerCliente(Llamada llamada)
        {
            if (llamada.cliente != null)
            {
                return objcd_cliente.obtenerClienteLlamada(llamada.cliente.dni);
            }          
            else
            {
              
                return null;
            }
        }
    }
}
