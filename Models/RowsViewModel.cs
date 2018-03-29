using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Models
{
    public class RowsViewModel
    {
        private IEnumerable<Row> rows;
        private IEnumerable<object> headers;
        public IEnumerable<object> Headers
        {
            get
            {
                return headers;
            }
            set
            {
                if (headers != value)
                {
                    headers = value;
                }
            }
        }
        DataView _rowsView;
        public DataView RowsView
        {
            get
            {
                DataTable rowsView = new DataTable();
                
                rowsView.Columns.Add(new DataColumn(headers.First().ToString(), typeof(DateTime)));

                foreach (var item in headers.Skip(1))
                {
                    rowsView.Columns.Add(new DataColumn(item.ToString(), typeof(double)));
                }
                
                var rowList = rows.ToList();

                foreach (var item in rowList)
                {
                    DataRow dataRow = rowsView.NewRow();
                    dataRow[0] = item.Timestamp;

                    int i = 1;
                    foreach (var sample in item.Samples.ToList())
                    {
                        dataRow[i++] = sample;
                    }

                    rowsView.Rows.Add(dataRow);
                }
                _rowsView = rowsView.DefaultView;
                return _rowsView;
            }
            set
            {
                _rowsView = value;
            }
        }
        public RowsViewModel(IEnumerable<object> headers, IEnumerable<Row> rows)
        {
            this.headers = headers;
            this.rows = rows;
        }
    }
}
