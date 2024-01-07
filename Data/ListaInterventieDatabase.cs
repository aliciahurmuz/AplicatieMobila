using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AplicatieMobila.Models;


namespace AplicatieMobila.Data
{
    public class InterventieDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public InterventieDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ListaInterventii>().Wait();
            _database.CreateTableAsync<Interventie>().Wait();
            _database.CreateTableAsync<ListaInterventie>().Wait();
            _database.CreateTableAsync<Clinica>().Wait();

        }
        public Task<List<Clinica>> GetCliniciAsync()
        {
            return _database.Table<Clinica>().ToListAsync();
        }
        public Task<List<ListaInterventii>> GetListeInterventiiForClinicaAsync(int clinicaId)
        {
            return _database.QueryAsync<ListaInterventii>(
                "SELECT L.* FROM ListaInterventii L " +
                "INNER JOIN ClinicaListaInterventii CL ON L.Id = CL.ListaInterventiiId " +
                "WHERE CL.ClinicaId = ?",
                clinicaId);
        }
        public Task<int> SaveClinicaAsync(Clinica clinica)
        {
            if (clinica.Id != 0)
            {
                return _database.UpdateAsync(clinica);
            }
            else
            {
                return _database.InsertAsync(clinica);
            }
        }


        public Task<int> SaveInterventieAsync(Interventie interventie)
        {
            if (interventie.Id != 0)
            {
                return _database.UpdateAsync(interventie);
            }
            else
            {
                return _database.InsertAsync(interventie);
            }
        }
        public Task<int> DeleteInterventieAsync(Interventie interventie)
        {
            return _database.DeleteAsync(interventie);
        }
        public Task<List<ListaInterventii>> GetShopListsAsync()
        {
            return _database.Table<ListaInterventii>().ToListAsync();
        }

        public Task<List<Interventie>> GetInterventiiAsync()
        {
            return _database.Table<Interventie>().ToListAsync();
        }

        public Task<List<ListaInterventii>> GetListeInterventiiAsync()
        {
            return _database.Table<ListaInterventii>().ToListAsync();
        }


        public Task<int> SaveListaInterventiiAsync(ListaInterventii ilist)
        {
            if (ilist.Id != 0)
            {
                return _database.UpdateAsync(ilist);
            }
            else
            {
                return _database.InsertAsync(ilist);
            }
        }

        public Task<int> DeleteListaInterventiiAsync(ListaInterventii ilist)
        {
            return _database.DeleteAsync(ilist);
        }

        public Task<int> SaveListaInterventieAsync(ListaInterventie listp)
        {
            if (listp.Id != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Interventie>> GetListaInterventiiAsync(int listainterventieid)
        {
            return _database.QueryAsync<Interventie>(
                "SELECT P.ID, P.Denumire FROM Interventie P"
                + " INNER JOIN ListaInterventie LP"
                + " ON P.ID = LP.InterventieId WHERE LP.ListaInterventieID = ?",
                listainterventieid);
        }
        public Task<int> DeleteClinicaAsync(Clinica clinica)
        {
            return _database.DeleteAsync(clinica);
        }

    }
}
