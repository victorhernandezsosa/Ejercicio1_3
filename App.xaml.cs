using Ejercicio1_3.Controllers;
using Ejercicio1_3.Vistas;

namespace Ejercicio1_3
{
    public partial class App : Application
    {
        static Datos basedatos;

        public static Datos BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new Datos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PersonasDB.db3"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Personlist());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}