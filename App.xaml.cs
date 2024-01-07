using System;
using AplicatieMobila;
using System.IO;
using AplicatieMobila.Data;

namespace AplicatieMobila
{
    public partial class App : Application
    {
        static InterventieDatabase database;
        public static InterventieDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new InterventieDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ListaInterventii.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
