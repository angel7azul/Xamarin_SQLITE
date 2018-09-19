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
	public partial class ListaTareas : ContentPage
	{
		public ListaTareas ()
		{
			InitializeComponent ();

            //Crear el Item de + para agregar nueva Tarea
            var boton_nuevo = new ToolbarItem
            {
                Text = "+",
            };

            boton_nuevo.Clicked += Boton_nuevo_Clicked;

            
            //Agregar el + en la parte de arriba
            ToolbarItems.Add(boton_nuevo);                    
		}

        private async void Boton_nuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoItem());
        }


        //Metodo el cual permite actualizar la lista una vez que regrese
        protected override void OnAppearing()
        {
            base.OnAppearing();


            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {               
                try
                {
                    List<Tarea> listaTareas;
                    listaTareas = connection.Table<Tarea>().Where(t => t.Completada == false).ToList();

                    listaTareasListView.ItemsSource = listaTareas;
                }
                catch (Exception)
                {
                    DisplayAlert("Sin Lista", "Agrega Nuevas Tareas", "Aceptar");
                }
                   
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                var tareaSelected = (sender as MenuItem).CommandParameter as Tarea;
                tareaSelected.Completada = true;
                connection.Update(tareaSelected);

                List<Tarea> listaTareasFilter;
                listaTareasFilter = connection.Table<Tarea>().Where(t => t.Completada == false).ToList();
                listaTareasListView.ItemsSource = listaTareasFilter;
            }
        }
    }
}