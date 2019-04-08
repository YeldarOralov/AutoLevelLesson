using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoLevelLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("books");
            dataSet.ExtendedProperties.Add("Owner", "ITStep"); //metadannie o nabore

            #region books columns
            DataTable booksTable = new DataTable("books");
            booksTable.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            booksTable.Columns.Add("Name", typeof(string));
            booksTable.Columns.Add("Price", typeof(int));
            booksTable.Columns.Add("authorId", typeof(int));
            #endregion

            #region books rows
            booksTable.Rows.Add("Сказки", 1000, 1);
            DataRow row = booksTable.NewRow();
            row.BeginEdit();
            row.ItemArray = new object[] { "Сказки ч.2", 1200, 1 };
            row.SetAdded();
            row.EndEdit();
            booksTable.Rows.Add(row);


            #endregion

            dataSet.Tables.Add(booksTable);

            #region authors columns
            DataTable authorTable = new DataTable("authors");
            authorTable.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementStep = 1,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            authorTable.Columns.Add("Name", typeof(string));
            #endregion

            #region authors rows
            authorTable.Rows.Add("Пушкин А.С.");
            #endregion

            dataSet.Tables.Add(authorTable);

            DataRelation dataRelation = new DataRelation("authors_books_fk", 
                "authors", "books", new string[] { "id" }, new string[] { "authorId" }, false);
            dataSet.Relations.Add(dataRelation);

        }
    }
}
