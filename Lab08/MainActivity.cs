using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Obtener la vista mediante el método SetContentView.
            SetContentView(Resource.Layout.Main);

            ValidateAsync();
            
            //// Permite obtener referencia del diseño de interfaz de usuario Main.
            //var ViewGroup = (Android.Views.ViewGroup)
            //Window.DecorView.FindViewById(Android.Resource.Id.Content); // Vista raíz de la actividad actual.

            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;


            //// Crear elemento de tipo ImageView para representar imágenes en una aplicación Android.
            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);

            //MainLayout.AddView(HeaderImage); // Incorporar ImageView a la colección de elementos que componen el diseño de la interfaz.


            //// Establecer el valor del recurso cadena en propiedad text.
            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);

            //MainLayout.AddView(UserNameTextView);
        }

        private async void ValidateAsync()
        {
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var ServiceClient = new SALLab08.ServiceClient();
            var Result = await ServiceClient.ValidateAsync("email@email.com", "password", myDevice);

            var UserName = FindViewById<TextView>(Resource.Id.UserNameValue);
            var Status = FindViewById<TextView>(Resource.Id.StatusValue);
            var Token = FindViewById<TextView>(Resource.Id.TokenValue);

            UserName.Text = $"{Result.Fullname}";
            Status.Text = $"{Result.Status}";
            Token.Text = $"{Result.Token}";
        }
    }
}

