using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Models
{
    public class UsuarioPedidosModel
    {
        public List<PedidoModel> Pedidos { get; set; }
    }
}
