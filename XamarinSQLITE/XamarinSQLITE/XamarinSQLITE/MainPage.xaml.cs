using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinSQLITE
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSesion_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usuarioEntry.Text)||String.IsNullOrEmpty(passwordEntry.Text))
            {
                lblResult.Text = $"Usuario o Password Incorrecto";
            }
            else
            {
                lblResult.Text = $"Login Exitoso!";
                await Navigation.PushAsync(new ListaTareas(), true);
            }
        }
    }
}
