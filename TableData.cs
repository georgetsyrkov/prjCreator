using System;

namespace PrjCreator
{
    public class TableRecord
    {
        public string Name;
        public string Code;
        public float Quantity;

        public TableRecord(string name, string code, float quantity)
        {
            Name = name;
            Code = code;
            Quantity = quantity;
        }
    }

    public static class TableDataManager
    {
        public static Gtk.ListStore CreateModel()
        {
            Gtk.ListStore store = new Gtk.ListStore( typeof(string), typeof(string), typeof(float) );

            List<TableRecord> tabRecs = new List<TableRecord>();

            tabRecs.Add(new TableRecord("Данные 1", "КОД.123.001", 0.01f));
            tabRecs.Add(new TableRecord("Данные 2", "КОД.123.002", 0.02f));
            tabRecs.Add(new TableRecord("Данные 3", "КОД.123.003", 0.03f));
            tabRecs.Add(new TableRecord("Данные 4", "КОД.123.004", 0.04f));
            tabRecs.Add(new TableRecord("Данные 5", "КОД.123.005", 0.05f));
            tabRecs.Add(new TableRecord("Данные 6", "КОД.123.006", 0.06f));
            tabRecs.Add(new TableRecord("Данные 7", "КОД.123.007", 0.07f));
            tabRecs.Add(new TableRecord("Данные 8", "КОД.123.008", 0.08f));
            tabRecs.Add(new TableRecord("Данные 9", "КОД.123.009", 0.09f));
            tabRecs.Add(new TableRecord("Данные 10","КОД.123.010", 0.00f));
            tabRecs.Add(new TableRecord("Данные 11","КОД.123.011", 1.01f));
            tabRecs.Add(new TableRecord("Данные 12","КОД.123.012", 2.01f));
            tabRecs.Add(new TableRecord("Данные 13","КОД.123.013", 3.01f));
            tabRecs.Add(new TableRecord("Данные 14","КОД.123.014", 4.01f));
            tabRecs.Add(new TableRecord("Данные 15","КОД.123.015", 5.01f));
            tabRecs.Add(new TableRecord("Данные 16","КОД.123.016", 6.01f));
            tabRecs.Add(new TableRecord("Данные 17","КОД.123.017", 7.01f));

            foreach (TableRecord act in tabRecs) {
                store.AppendValues(act.Name, act.Code, act.Quantity);
            }

            return store;
        }
    }
}