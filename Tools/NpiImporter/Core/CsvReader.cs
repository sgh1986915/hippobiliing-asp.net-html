using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElencySolutions.CsvHelper;

namespace NpiImporter.Core
{
    internal class CsvReader
    {
        private static string _connectString;
        private static Action<string> _callBack;
        private static Action _completed;
        private static StringBuilder _sb = new StringBuilder();
        private static int _counter = 0;
        private static int _maxBuffer = 1000;

        public static void ReadCsv(string filePath, string connectString, Action<string> callBack = null,
            Action completed = null)
        {
            _connectString = connectString;
            _callBack = callBack;
            _completed = completed;
            _sb.Clear();

            var headers = new List<string>();

            using (var reader = new ElencySolutions.CsvHelper.CsvReader(filePath, Encoding.Default))
            {
                if (reader.ReadNextRecord())
                {
                    headers = reader.Fields;
                }

                DataTable table = new DataTable("NPIRecords");
                headers.ForEach(x => table.Columns.Add(new DataColumn(Column(x))));

                //CreateTable(table);


                int buffer = 0;
                while (reader.ReadNextRecord())
                {
                    var row = table.NewRow();
                    row.ItemArray = reader.Fields.ToArray();
                    table.Rows.Add(row);
                    buffer++;
                    if (buffer >= _maxBuffer)
                    {
                        BulkCopy(table);
                        buffer = 0;
                        table.Rows.Clear();
                    }
                }

                if (table.Rows.Count > 0)
                {
                    BulkCopy(table);
                }
            }

            if (_completed != null) _completed();
        }

        private static void CreateTable(DataTable table)
        {
            string ctStr = "CREATE TABLE [dbo].[" + table.TableName + "](\r\n";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                ctStr += "  [" + table.Columns[i].ColumnName + "] [nvarchar](max) NULL";
                if (i < table.Columns.Count - 1)
                {
                    ctStr += ",";
                }
                ctStr += "\r\n";
            }
            ctStr += ")";

            try
            {
                SqlConnection conn = new SqlConnection(_connectString);
                SqlCommand command = conn.CreateCommand();
                command.CommandText = ctStr;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                command.Dispose();
                conn.Dispose();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e + "\r\n Faild to create table");
            }
        }

        private static void BulkCopy(DataTable table)
        {
            using (SqlBulkCopy bc = new SqlBulkCopy(_connectString))
            {
                bc.BulkCopyTimeout = 0;
                // Destination table with owner - this example doesn't
                // check the owner and table names!
                bc.DestinationTableName = table.TableName;

                bc.SqlRowsCopied += bc_SqlRowsCopied;
                // User notification with the SqlRowsCopied event
                bc.NotifyAfter = _maxBuffer;

                // Starts the bulk copy.

                bc.WriteToServer(table);

                // Closes the SqlBulkCopy instance
                bc.Close();
            }
        }

        private static void bc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            if (_callBack != null)
            {
                _counter++;
                _sb.AppendLine(e.RowsCopied + " rows copyed, already copyed " + _counter*_maxBuffer);
                _callBack(_sb.ToString());
            }
        }

        private static string Column(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return str.Replace(" ", "_").Replace("(", "_").Replace(")", "_").Replace(".", "_");
        }
    }
}