using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace AplicatieMobila.Models
{
    public class ClinicaListaInterventii
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int ClinicaId { get; set; }

        [Indexed]
        public int InterventieId { get; set; }
    }
}
