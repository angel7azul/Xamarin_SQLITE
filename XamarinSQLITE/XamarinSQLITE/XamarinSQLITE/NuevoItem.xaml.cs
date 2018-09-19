using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSQLITE.Clases;

namespace XamarinSQLITE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NuevoItem : ContentPage
	{
		public NuevoItem ()
		{
			InitializeComponent ();
		}

        private void GuardarClick(object sender, EventArgs e)
        {
            //Crear el Objeto Tarea
            Tarea tarea = new Tarea
            {
                Nombre = nombreEntry.Text,
                Fecha = fechaLimiteDatePicker.Date,
                Hora = horaLimiteTimePicker.Time,
                Completada = false
            };

            //Insertar Datos a la Tabla usando SQLITE
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                connection.CreateTable<Tarea>();
                var result = connection.Insert(tarea);
                if (result != 0)
                {
                    DisplayAlert("Tarea", "La tarea fue registrada!", "Aceptar");
                   
                }
                else
                {
                    DisplayAlert("Error", "Intenta de Nuevo!", "Aceptar");
                }
            }
        }
    }
}