using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciador
{
    public class Comanda
    {
        public int id;
        public string nome;
        public string pedido;
        private bool _status = false;

        public bool Status { get; set; }
        public static int Total { get; private set; }

        public Comanda(int id, string nome, string pedido)
        {
            this.id = id;
            this.nome = nome;
            this.pedido = pedido;
            Comanda.Total++;
        }

    }
}
