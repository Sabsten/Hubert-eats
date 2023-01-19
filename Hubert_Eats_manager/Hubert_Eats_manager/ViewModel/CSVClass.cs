using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ViewModel
{
   class CSVClass
   {
        public static void ExportToCSV(List<ExtractDatabase> Data, string filename)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(ExtractDatabase)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = Data.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            DateTime thisDate = DateTime.Today;
            CultureInfo format = new CultureInfo("pt-BR");
            System.IO.File.WriteAllLines(filename, lines.ToArray());

        }
   }
}
