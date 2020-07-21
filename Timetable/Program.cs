using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "txt files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            var file = "";
            openFileDialog1.ShowDialog();
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                using (var document = SpreadsheetDocument.Open(file, true))
                {
                    //create the object for workbook part  
                    WorkbookPart wbPart = document.WorkbookPart;

                    //statement to get the count of the worksheet  
                    int worksheetcount = document.WorkbookPart.Workbook.Sheets.Count();

                    //statement to get the sheet object  
                    Sheet mysheet = (Sheet)document.WorkbookPart.Workbook.Sheets.ChildElements.GetItem(0);

                    //statement to get the worksheet object by using the sheet id  
                    Worksheet Worksheet = ((WorksheetPart)wbPart.GetPartById(mysheet.Id)).Worksheet;


                    //statement to get the sheetdata which contains the rows and cell in table  
                    IEnumerable<Row> Rows = Worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    //Loop through the Worksheet rows
                    foreach (var row in Rows)
                    {
                        if (row.RowIndex.Value != 0)
                        {
                            //var qq = Program.GetSharedStringItemById(wbPart ,0);
                            var lesson = new Lesson();
                            int idx = 1;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {

                                var val = Program.GetValue(document, cell);
                                int idy = 0;
                                if (idx < 7)
                                {
                                    if (idx == 1)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numberOfWeek = x;
                                    }
                                    if (idx == 2)
                                    {
                                        lesson.dayOfWeek = val;
                                    }

                                    if (idx == 3)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numbewrOfDayInWeek = x;
                                    }
                                    if (idx == 4)
                                    {
                                        lesson.date = val;
                                    }
                                    if (idx == 5)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numberOfLesson = x;
                                    }
                                    if (idx == 7)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        if (x != 4)
                                            break;
                                    }
                                }
                                else
                                {

                                    idy++;
                                    if (idx == 1)
                                    {
                                        lesson.numberOfGroup = val;
                                    }
                                    if (idx == 2)
                                    {
                                        lesson.dayOfWeek = val;
                                    }

                                    if (idx == 3)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numbewrOfDayInWeek = x;
                                    }
                                    if (idx == 4)
                                    {
                                        lesson.date = val;
                                    }
                                    if (idx == 5)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numberOfLesson = x;
                                    }

                                }




                                Console.WriteLine("{0} \n", val);
                                idx++;
                            }
                        }

                    }
                    //getting the row as per the specified index of getitem method  


                    //getting the cell as per the specified index of getitem method  
                    // Cell currentcell = (Cell)currentrow.ChildElements.GetItem(0);
                    //string currentcellvalue = string.Empty;
                    //if (currentcell.DataType != null)
                    //{
                    //    if (currentcell.DataType == CellValues.SharedString)
                    //    {
                    //        int id = -1;

                    //        if (Int32.TryParse(currentcell.InnerText, out id))
                    //        {
                    //            SharedStringItem item = GetSharedStringItemById(wbPart, id);

                    //            if (item.Text != null)
                    //            {
                    //                //code to take the string value  
                    //                currentcellvalue = item.Text.Text;
                    //            }
                    //            else if (item.InnerText != null)
                    //            {
                    //                currentcellvalue = item.InnerText;
                    //            }
                    //            else if (item.InnerXml != null)
                    //            {
                    //                currentcellvalue = item.InnerXml;
                    //            }
                    //        }
                    //    }
                    //}

                }
            }
        }
        public static string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }
        public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }
    }

    public class Lesson
    {
        public int numberOfWeek { get; set; }
        public string dayOfWeek { get; set; }
        public int numbewrOfDayInWeek { get; set; }
        public int numberOfLesson { get; set; }
        public string numberOfGroup { get; set; }

        public string nameOfDiscipline { get; set; }
        public int typeOfLesson { get; set; }
        public string Lectural { get; set; }
        public string date { get; set; }

        public string auditore { get; set; }
    }
}
