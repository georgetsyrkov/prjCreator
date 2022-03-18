using System;
using Gtk;

namespace PrjCreator
{
    public class MWindow
    {
        private Window myWin;

        public MWindow()
        {
            myWin = new Window("My first GTK# Application! ");
            myWin.Resize(200,200);
            myWin.DeleteEvent += DelEv;


            MenuBar menuBar = new MenuBar();
            
            Menu fMenu = new Menu();
            MenuItem fMenuRootItem = new MenuItem();
            fMenuRootItem.Label = "Файл";
            fMenuRootItem.Submenu = fMenu;

            MenuItem fMenuOpenItem = new MenuItem();
            fMenuOpenItem.Label = "Открыть";
            fMenu.Append(fMenuOpenItem);

            menuBar.Append(fMenuRootItem);




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
            btn_ok.Clicked += OnClick;

            Label myLabel2 = new Label();
            myLabel2.Text = "Hello World!!!!";

            Label myLabel3 = new Label();
            myLabel3.Text = "...\n...\n...\n...\n...\n...\n";

            HBox hbox = new HBox();
            hbox.Halign = Align.End;
            hbox.Valign = Align.End;
            
            hbox.Add(myLabel3);
            hbox.Add(btn_ok);

            ScrolledWindow sw = new ScrolledWindow();

            Label myLabel4 = new Label();
            myLabel4.Text = "...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n...\n";
            
            sw.Add(myLabel4);
            hbox.Add(sw);


            VBox vbox = new VBox(false, 2);

            vbox.PackStart(menuBar, false, false, 0);

            //vbox.Add(menuBar);
            vbox.Add(myLabel);
            vbox.Add(btn);
            vbox.Add(myLabel2);
            vbox.Add(hbox);


            myWin.Add(vbox);
        }

        public void ShowAll()
        {
            myWin.ShowAll();
        }

        private void DelEv(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            FileChooserDialog dlg = new FileChooserDialog("title", myWin, FileChooserAction.Open, "qwe");
            dlg.Show(); 
        }
    }
}