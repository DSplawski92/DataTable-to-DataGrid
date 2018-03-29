using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Row
    {
        public DateTime Timestamp { get; set; }
        public IEnumerable<double> Samples { get; set; }
    }
}
