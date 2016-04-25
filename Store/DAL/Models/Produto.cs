using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public int Quantidade { get; set; }
        public string Modelo { get; set; }
    }
}
