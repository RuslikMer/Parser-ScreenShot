using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Romanov
{
    class ReadXls
    {
        public void Read()
        {
            var fileName = @"C:\Users\r.merikanov\Desktop\Urls.xlsx";
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fileName);

            var adapter = new OleDbDataAdapter("SELECT * FROM [workSheetNameHere$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "XLSData");
            DataTable data = ds.Tables["XLSData"];

            // ... Loop over all rows.
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in data.Rows)
            {
                sb.AppendLine(string.Join(",", row.ItemArray));
            }
        }
    }
}
