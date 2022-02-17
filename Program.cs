using System;
using Gtk;

namespace PrjCreator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();

            Window myWin = new Window("My first GTK# Application! ");
            myWin.Resize(200,200);

            Label myLabel = new Label();
            myLabel.Text = "Hello World!!!!";

            myWin.Add(myLabel);
            myWin.ShowAll();

            myWin.DeleteEvent += DelEv;

            Application.Run();
        }

        private static void DelEv(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }
    }
}