using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieMobila.Models
{
    public class ListaInterventii
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Denumire { get; set; }
        public int Pret {  get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Interventie))]

        public int ListaInterventiiId { get; set; }

        public int InterventieId { get; set; }

        [ManyToOne(nameof(InterventieId))]
        public Interventie Interventie { get; set; }
        public int ClinicaID { get; set; }

    }
}
