using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    class Program
    {

        static HttpClient client = new HttpClient();
       
        static async Task Main(string[] args)
        {
            ClassFile classFile = new ClassFile();


            string file = classFile.path;
            if (file != null)
            { 
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
                            int idx = 1; int idy = 0;
                            foreach (Cell cell in row.Descendants<Cell>())
                            {

                                var val = Program.GetValue(document, cell);
                                if (val == "Неделя")
                                    break;
                                if (idx < 8)
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
                                        int day, month, year;
                                        string[] z = val.Split(' ');
                                        Int32.TryParse(z[0], out day);
                                        if (z[2].Length == 4)
                                            Int32.TryParse(z[2], out year);
                                        else
                                        {                                            
                                            Int32.TryParse(z[2].Substring(0, 3), out year);
                                        }
                                        switch (z[1]) {
                                            case "СЕНТЯБРЯ":
                                                month = 09;break;

                                            case "ОКТЯБРЯ":
                                                month = 10; break;

                                            case "НОЯБРЯ":
                                                month = 11; break;

                                            case "ДЕКАБРЯ":
                                                month = 12; break;

                                            case "ЯНВАРЯ":
                                                month = 1; break;

                                            case "ФЕВРАЛЯ":
                                                month = 2; break;

                                            case "МАРТ":
                                                month = 3; break;

                                            case "АПРЕЛЬ":
                                                month = 4; break;

                                            case "МАЙ":
                                                month = 5; break;

                                            case "ИЮНЬ":
                                                month = 6; break;

                                            case "ИЮЛЬ":
                                                month = 7; break;

                                            case "АВГУСТА":
                                                month = 8; break;
                                            default:
                                                month = 0; break;

                                        }
                                        DateTime dateTime = new DateTime(year, month, day);
                                        lesson.date = dateTime;
                                    }
                                    if (idx == 5)
                                    {
                                        int x;
                                        Int32.TryParse(val, out x);
                                        lesson.numberOfLessonInDay = x;
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
                                    if (idy == 1)
                                    {
                                        lesson.numberOfGroup = val;
                                    }
                                    if (idy == 2)
                                    {
                                        lesson.nameOfDiscipline = val;
                                    }

                                    if (idy == 3)
                                    {
                                        int x = 0;
                                        if(val != "" && val != "ОХРАНА" && val != "ПРАЗДНИК")
                                        {
                                            string[] z = val.Split(' ');
                                            lesson.typeOfLesson = z[0];                                            
                                            Int32.TryParse(z[z.Length-1], out x);
                                            lesson.numberOfLesson = x;
                                        }
                                    }
                                    if (idy == 4)
                                    {
                                        lesson.Lectural = val;
                                    }
                                    if (idy == 5)
                                    {
                                        if(val != null)
                                            lesson.auditore = val;
                                        else
                                            lesson.auditore = "";
                                    }
                                    if (idy == 7)
                                    {
                                        idy = 0;
                                        //await sendLessonToAPIAsync(lesson);
                                        if (lesson.numberOfGroup != "431А" && lesson.numberOfGroup != "431Б" &&
                                            lesson.numberOfGroup != "441А" && lesson.numberOfGroup != "441Б" &&
                                            lesson.numberOfGroup != "451А" && lesson.numberOfGroup != "451Б")
                                        {
                                            Console.WriteLine(lesson.ToString());
                                            if (lesson.Lectural != "" && lesson.nameOfDiscipline != "")
                                                try
                                                {
                                                    await sendLessonToAPIAsync(lesson); 
                                                }
                                                catch(Exception e) 
                                                {
                                                    Console.WriteLine(e.Message);
                                                }
                                                
                                        }
                                    }
                                }
                                idx++;
                            }
                        }

                    }

                }
            }
        }



        private static async Task sendLessonToAPIAsync(Lesson lesson)
        {
            var url = "https://localhost:44351/api/TimetableDBs";
            string jsonLesson = JsonConvert.SerializeObject(lesson);
            var data = new StringContent(jsonLesson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(" Response result = {0}. lesson send to API success", result);
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
        public int numberOfLessonInDay { get; set; }
        public string nameOfDiscipline { get; set; }
        public string typeOfLesson { get; set; }
        public string Lectural { get; set; }
        public DateTime date { get; set; }

        public string auditore { get; set; }

        public override string ToString()
        {
            return String.Format("number of week: {0}\t day Of Week:{1}\t number day in Week : {2}\n" +
                "number of lesson:{3}\t group number : {4}\n" +
                "name Of Discipline : {5}\t type Of Lesson : {6}\t auditore : {7}\n" +
                "Lectural : {8}\t date : {9}\n",
                numberOfWeek , dayOfWeek, numbewrOfDayInWeek, numberOfLesson,  numberOfGroup, nameOfDiscipline,typeOfLesson, auditore, Lectural, date);
        }
    }

    public class ClassFile
    {
        public string path { get; set; }
        public ClassFile()
        {
            Thread thread = new Thread(()=> { GetPathToFile(); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
        public void GetPathToFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
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

            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
          
        }

    }
}
