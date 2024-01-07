using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieMobila.Models
{
    public class Interventie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Denumire { get; set; }

       
        [OneToMany]
        public List<ListaInterventie> Listainterventii { get; set; }

        
    }
}
