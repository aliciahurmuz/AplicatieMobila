using SQLite;


namespace AplicatieMobila.Models
{

    public class Clinica
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string Detalii => $"{Nume} {Adresa}";

        [Ignore]
        public List<ListaInterventii> ListeI { get; set; }
        public int InterventieId { get; set; }
    }
}
