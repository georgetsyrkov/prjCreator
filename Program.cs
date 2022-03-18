using System;
using Gtk;

namespace PrjCreator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();

            MWindow myWin = new MWindow();
            myWin.ShowAll();

            Application.Run();
        }
    }
}