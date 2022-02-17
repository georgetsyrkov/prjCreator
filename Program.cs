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
            myWin.DeleteEvent += DelEv;

            Label myLabel = new Label();
            myLabel.Text = "Hello World!!!!";

            Button btn = new Button();
            btn.Label = "Test BTN";
            btn.MarginLeft = 20;
            btn.MarginRight = 20;


            Button btn_ok = new Button();
            btn_ok.Label = "OK";
            btn_ok.Margin = 20;
            btn_ok.HeightRequest = 30;
            
            //btn_ok.MarginLeft = 20;
            //btn_ok.MarginRight = 20;

            Label myLabel2 = new Label();
            myLabel2.Text = "Hello World!!!!";

            Label myLabel3 = new Label();
            myLabel3.Text = "...\n...\n...\n...\n...\n...\n";

            HBox hbox = new HBox();
            hbox.Halign = Align.End;
            hbox.Valign = Align.End;
            
            hbox.Add(myLabel3);
            hbox.Add(btn_ok);
            


            VBox vbox = new VBox();

            vbox.Add(myLabel);
            vbox.Add(btn);
            vbox.Add(myLabel2);
            vbox.Add(hbox);


            myWin.Add(vbox);
            myWin.ShowAll();

            Application.Run();
        }

        private static void DelEv(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }
    }
}