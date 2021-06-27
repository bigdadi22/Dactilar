using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Dactilar.Models
{
    public class Productos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string NomPrd { get; set; }
        
        public int CantPrd { get; set; }
        
        public  int CostPrd { get; set; }
    }
}
