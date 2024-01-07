using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;


namespace AplicatieMobila.Models
{
    public class ListaInterventie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(ListaInterventii))]
        public int ListaInterventiiId { get; set; }
        public int InterventieId { get; set; }
    }
}
