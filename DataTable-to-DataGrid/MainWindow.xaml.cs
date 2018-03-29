using AsciiImport;
using DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace DataTable_to_DataGrid
{

    public partial class MainWindow : Window
    {
        AsciiSettings asciiSettings = new AsciiSettings()
        {
            ColDelimiter = ';',
            DateTimeFormat = "dd.MM.yyyy HH:mm:ss",
            NumberDelimiter = ",",
            SkipFirstRowsNum = 0,
            UseFirstRowAsHeader = true,
            FileName = "shortValidSamples.csv"
        };

        IEnumerable<Row> rows = new List<Row>()
            {
                    new Row() { Timestamp = new DateTime(2018, 02, 08, 13, 34, 25), Samples = new double[] { 0.1011991198, 0.4766171544, 0.8710178677 }.AsEnumerable()},
                    new Row() { Timestamp = new DateTime(2018, 02, 08, 13, 34, 27), Samples = new double[] { 0.0994543063, 0.8352792030, 0.5027661952 }.AsEnumerable()},
                    new Row() { Timestamp = new DateTime(2018, 02, 08, 13, 34, 29), Samples = new double[] { 0.5390439995, 0.6669164386, 0.2144592430 }.AsEnumerable()},
                    new Row() { Timestamp = new DateTime(2018, 02, 08, 13, 34, 31), Samples = new double[] { 0.4302489003, 0.0161936665, 0.3082652711 }.AsEnumerable()}
            }.AsEnumerable();

        IEnumerable<object> headers = new List<object>()
            {
                "Date", "Var 1", "Var 2", "Var 3"
            }.AsEnumerable();
        public MainWindow()
        {
            InitializeComponent();
        }            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            IDataImport asciiImport = new AsciiDataImport(asciiSettings);
            
                try
                {
                    //headers = asciiImport.GetHeaders();
                    //rows = asciiImport.Load(1, 10);
 
                    dataGrid.DataContext = new RowsViewModel(headers, rows);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            
        }
    }
}
