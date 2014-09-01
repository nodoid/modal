using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Threading.Tasks;

namespace modal
{
    [Activity(Label = "modal", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Dialog myDialog;
        private TextView txtColour, txtName, txtSmell;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.myButton);
            txtColour = FindViewById<TextView>(Resource.Id.txtColor);
            txtName = FindViewById<TextView>(Resource.Id.txtName);
            txtSmell = FindViewById<TextView>(Resource.Id.txtSmell);

            button.Click += delegate
            {
                DisplayModal();
            };
        }

        private void DisplayModal(string message = "")
        {
            myDialog = new Dialog(this, Resource.Style.lightbox_dialog);
            myDialog.SetContentView(Resource.Layout.ModalView);
            ((TextView)myDialog.FindViewById(Resource.Id.txtMessage)).Text = message;
            var editName = myDialog.FindViewById<EditText>(Resource.Id.editName);
            var editSmell = myDialog.FindViewById<EditText>(Resource.Id.editSmell);
            var editColor = myDialog.FindViewById<EditText>(Resource.Id.editColour);
            var btnDone = myDialog.FindViewById<Button>(Resource.Id.btnDone);

            btnDone.Click += delegate
            {
                txtName.Text = editName.Text;
                txtColour.Text = editColor.Text;
                txtSmell.Text = editSmell.Text;
                myDialog.Dismiss();
            };

            RunOnUiThread(myDialog.Show);
        }
    }
}


