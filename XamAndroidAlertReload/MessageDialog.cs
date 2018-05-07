using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamAndroidAlertReload
{
    public class MessageDialog
    {
        private Context Context { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public MessageDialog(Context context)
        {
            Context = context;
            Message = "Message";
            Title = "Title";
        }

        public MessageDialog(Context context, string title, string message)
        {
            Context = context;
            Title = title;
            Message = message;
        }

        public MessageDialog(Context context, int title, int message)
        {
            Context = context;
            Title = Context.GetString(title); 
            Message = Context.GetString(message);
        }
       

        public void ShowConfirmDialog( int btnaccept, int btncancel)
        {
           // string stitle = Context.GetString(title);
            //string smessage = Context.GetString(message);
            string sbtnaccept = Context.GetString(btnaccept);
            string sbtncancel = Context.GetString(btncancel);
            ShowConfirmDialog(sbtnaccept, sbtncancel);
        }

        private string _btnaccept { get; set; }
        private string _btncancel { get; set; }

        public void ShowConfirmDialog( string btnaccept , string btncancel)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Context);
            builder.SetMessage(Message);
            builder.SetTitle(Title);
            builder.SetPositiveButton(btnaccept, PositiveButton);
            builder.SetNegativeButton(btncancel, NegativeButton);

            AlertDialog dialog = builder.Create();
            dialog.Show();
        }
        public event EventHandler<CommandResult> MessageDialogResult;
        private void OnMessageDialogResult(Command command ,string btncontext)
        {
            MessageDialogResult?.Invoke(this, new CommandResult(command, btncontext));
        }
        private void NegativeButton(object sender, DialogClickEventArgs e)
        {
            OnMessageDialogResult(Command.Cancel,_btncancel);
        }

        private void PositiveButton(object sender, DialogClickEventArgs e)
        {
            OnMessageDialogResult(Command.Accept,_btnaccept);
        }

       
    }

         public class CommandResult
         {
        private string _btncontent;
        public string Btncontent
        {
            get
            {
                return _btncontent;
            }
        }
                private Command _result;
                public Command result { get
                        {
                            return _result;
                        }   
                }
                public CommandResult(Command result, string btncontent)
                {
                    _result = result;
                    _btncontent = btncontent;
                }
         }

        public enum Command
        {
           Accept , Cancel
        }
}