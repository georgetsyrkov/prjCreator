using System;
using System.IO;
using Gtk;

namespace PrjCreator
{
    public class MWindow
    {
        private Window myWin;
        Statusbar statusBar = new Statusbar();
        
        public MWindow()
        {
            //имя, как указали в css файле, только без #
            const string neonWidget = "neon-widget";
            
            myWin = new Window("My first GTK# Application! ");
            myWin.Resize(200,200);
            myWin.DeleteEvent += DelEv;

            //вызываем функцию, которая подгрузит css файлик по заданному пути (реализация в конце текущего файла)
            LoadCss("CSS\\style.css");

            MenuBar menuBar = new MenuBar();
            //указываем Name с помощью переменной с именем из файла css
            menuBar.Name = neonWidget;
            
            Menu fMenu = new Menu();
            MenuItem fMenuRootItem = new MenuItem();
            fMenuRootItem.Label = "Файл";
            fMenuRootItem.Submenu = fMenu;

            MenuItem fMenuOpenItem = new MenuItem();
            fMenuOpenItem.Label = "Открыть";
            fMenuOpenItem.Activated += OnClick;
            //указываем Name с помощью переменной с именем из файла css
            fMenuOpenItem.Name = neonWidget;
            fMenu.Append(fMenuOpenItem);

            menuBar.Append(fMenuRootItem);

            

            Label lb2 = new Label("lb2");

            TreeView tv = new TreeView();
            
            TreeViewColumn nameCol = new TreeViewColumn();
            nameCol.Title = "Наименование";
            nameCol.Resizable = true;

            TreeViewColumn codeCol = new TreeViewColumn();
            codeCol.Title = "Обозначение";
            codeCol.Resizable = true;

            CellRendererText nameCell = new CellRendererText();
            nameCol.PackStart(nameCell, true);
            nameCol.AddAttribute(nameCell, "text", 0);

            CellRendererText codeCell = new CellRendererText();
            codeCol.PackStart(codeCell, true);
            codeCol.AddAttribute(codeCell, "text", 1);

            TreeStore treestore = new TreeStore(typeof(string), typeof(string));

            TreeIter root = treestore.AppendValues("Изделие", "ABC.000000.000");

            TreeIter item1 = treestore.AppendValues(root, "Сборка 1", "ABC.000000.001");
            TreeIter item2 = treestore.AppendValues(root, "Сборка 2", "ABC.000000.002");
            TreeIter item3 = treestore.AppendValues(root, "Сборка 3", "ABC.000000.003");
            TreeIter item4 = treestore.AppendValues(root, "Сборка 4", "ABC.000000.004");
    
            treestore.AppendValues(item1, "Деталь 1-1", "ABC.000100.001");
            treestore.AppendValues(item1, "Деталь 1-2", "ABC.000100.002");
            treestore.AppendValues(item1, "Деталь 1-3", "ABC.000100.003");
            treestore.AppendValues(item1, "Деталь 1-4", "ABC.000100.004");

            treestore.AppendValues(item2, "Деталь 2-1", "ABC.000200.001");
            treestore.AppendValues(item2, "Деталь 2-2", "ABC.000200.002");
            treestore.AppendValues(item2, "Деталь 2-3", "ABC.000200.003");

            treestore.AppendValues(item3, "Деталь 3-1", "ABC.000300.001");

            treestore.AppendValues(item4, "Деталь 4-1", "ABC.000400.001");
            treestore.AppendValues(item4, "Деталь 4-2", "ABC.000400.002");

            tv.AppendColumn(nameCol);
            tv.AppendColumn(codeCol);

            tv.Model = treestore;

            ScrolledWindow sw1 = new ScrolledWindow();
            sw1.ShadowType = ShadowType.EtchedIn;
            sw1.WidthRequest = 300;
            sw1.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);
            sw1.Add(tv);


            ListStore data = TableDataManager.CreateModel();

            TreeView tv2 = new TreeView(data);
            tv2.RulesHint = true;
            AddTableColumns(tv2);

            ScrolledWindow sw2 = new ScrolledWindow();
            sw2.ShadowType = ShadowType.EtchedIn;
            sw2.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);
            sw2.Add(tv2);

            Paned pn = new Paned(Orientation.Horizontal);
            pn.Add1(sw1);
            pn.Add2(sw2);

            VBox vbox = new VBox(false, 2);
            vbox.PackStart(menuBar, false, false, 0);
            vbox.Add(pn);
            vbox.PackStart(statusBar, false, false, 0);


            myWin.WidthRequest = 640;

            myWin.Add(vbox);

            statusBar.Push(0, "Конструктор проинициализирован");
        }

        void AddTableColumns(TreeView treeView)
        {
            CellRendererText rendererText = new CellRendererText();
            TreeViewColumn column = new TreeViewColumn("Имя", rendererText, "text", 0);
            column.Resizable = true;
            column.SortColumnId = 0;
            treeView.AppendColumn(column);

            rendererText = new CellRendererText();
            column = new TreeViewColumn("Код", rendererText, "text", 1);
            column.Resizable = true;
            column.SortColumnId = 1;
            treeView.AppendColumn(column);

            rendererText = new CellRendererText();
            column = new TreeViewColumn("Количество", rendererText, "text", 2);
            column.Resizable = true;
            column.SortColumnId = 2;
            treeView.AppendColumn(column);
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
            //создаем диалог выбора файла
            //указываем его название
            //указваем родительское окно (вроде как)
            //говорим, что это окно будет использоваться для открытия файлов
            //указываем названия (хотя, наверное, скорее просто лейблы) и значения, которые вернутся при их нажатии
            FileChooserDialog dlg = new FileChooserDialog("title", myWin, FileChooserAction.Open,
                "Open", ResponseType.Accept, "Отмена", ResponseType.Cancel);
            //показываем все элементы диалогового окна dlg
            dlg.ShowAll(); 
            
            //проверка (ощущение, что прямиком из чистого си) значения, которое вернулось от кнопочек окна
            //а точнее, проверка, вернулось ли значение Accept (т.е. была ли нажата кнопка с лейблом Open)
            if (dlg.Run() == (int)ResponseType.Accept)
            {
                //помещаем в статусбар сообщение о том, какой файл был открыт
                statusBar.Push(0, $"Открыт файл: {dlg.Filename}");
            }
            
            //убираем после этого окно dlg
            dlg.Destroy();
        }

        //функция для подгрузки css из файлика по пути path
        private void LoadCss(string path)
        {
            //создаем новый CssProvider, в который будут отправляться данные из css файла
            CssProvider css = new CssProvider();

            //добавляем созданный CssProvider дефолтному экрану с максимальным (вроде бы) приоритетом User
            Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css, Gtk.StyleProviderPriority.User);

            //строка, в которцю будем считывать css
            string cssStyles = "";

            //читаем файл css по пути path в строку cssStyles
            cssStyles = File.ReadAllText(path);
            
            //ну и отправляем данные из строки с содержимым css файла в CssProvider
            css.LoadFromData(cssStyles);
        }
    }
}