using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace XamAndroidAlertReload
{
    [Activity(Label = "XamAndroidAlertReload", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }

        public override void OnBackPressed()
        {
            /*
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage("Desea Salir de la Aplicacion?");
            builder.SetTitle("Salir");
            builder.SetPositiveButton("Si", PositiveButton);
            builder.SetNegativeButton("No", NegativeButton);
            //base.OnBackPressed();
            AlertDialog dialog = builder.Create();
            dialog.Show();
            */

            MessageDialog dialog = new MessageDialog(this,"MessageDialog","My message dialog");
            dialog.MessageDialogResult += Dialog_MessageDialogResult;
            dialog.ShowConfirmDialog("Aceptar","Cancelar");
        }

        private void Dialog_MessageDialogResult(object sender, CommandResult e)
        {
            // throw new NotImplementedException();
            if (e.result == Command.Accept)
            {
                Finish();
            }
        }
        /*
        private void NegativeButton(object sender, DialogClickEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void PositiveButton(object sender, DialogClickEventArgs e)
        {
            // throw new NotImplementedException();
            Finish();
        }*/
    }
}

