using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace KompasToExcel
{
    class ExcelUtils
    {

        private static int lastRowIndex = 1;

        public static void sort(Excel._Worksheet workSheet)
        {
            dynamic allDataRange = workSheet.UsedRange;
            for (int i = 1; i <= 18; i++) allDataRange.Columns[i].AutoFit();
            allDataRange.Sort(allDataRange.Columns[7], Excel.XlSortOrder.xlDescending);
        }

        public static List<Row> group(List<Row> rows)
        {
            return rows.GroupBy(l => l.Name)
               .Select(cl => new Row
               {
                   Unknown = cl.First().Unknown,
                   Format = cl.First().Format,
                   Zone = cl.First().Zone,
                   Position = cl.Select(i => i.Position).Distinct().Aggregate((i, j) => i + ", " + j),
                   Mark = cl.First().Mark,
                   Name = cl.First().Name,
                   Count = cl.Sum(c => Convert.ToInt32(c.Count)).ToString(),
                   Note = cl.First().Note,
                   Mass = cl.First().Mass,
                   Material = cl.First().Material,
                   User = cl.Select(i => i.User).Distinct().Aggregate((i, j) => i + "; " + j),
                   Code = cl.First().Code,
                   Factory = cl.First().Factory,
                   DocumentNumber = cl.First().DocumentNumber,
                   DocumentName = cl.First().DocumentName,
                   DocumentCode = cl.First().DocumentCode,
                   CodeOKP = cl.First().CodeOKP,
                   FileName = cl.Select(i => i.FileName).Distinct().Aggregate((i, j) => i + ";\n" + j)
               }).ToList();
        }

        public static void trimEmptyColumns(Excel._Worksheet workSheet)
        {
            for (int col = 1; col <= workSheet.UsedRange.Columns.Count; col++)
            {
                int notEmptyCellsCount = 0;
                for (int row = 2; row <= workSheet.UsedRange.Rows.Count; row++)
                {
                    Excel.Range dataRange = workSheet.Cells[row, col];
                    string value = Convert.ToString(dataRange.Value);
                    if (value != null)
                        notEmptyCellsCount++;

                }
                if (notEmptyCellsCount != 0) continue;
                else workSheet.Columns[col--].Delete(null);
            }
            for (int col = 1; col <= workSheet.UsedRange.Columns.Count; col++)
            {
                for (int row = 1; row <= workSheet.UsedRange.Rows.Count; row++)
                {
                    Excel.Range range = workSheet.UsedRange;
                    Excel.Range cell = range.Cells[row, col];
                    Excel.Borders border = cell.Borders;

                    border.LineStyle = Excel.XlLineStyle.xlContinuous;
                    border.Weight = 2d;
                }
            }
        }
        public static Dictionary<int, int> getSubstringBorders(string[] arr)
        {
            Dictionary<int, int> output = new Dictionary<int, int>();
            string s = ""; int k = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                output.Add(k, k + arr[i].Length);
                k = k + arr[i].Length + 1;
            }
            return output;
        }
        public static void colorColumns(Excel._Worksheet workSheet)
        {
            try
            {
                int[] colors = new int[]
                {
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Pink),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Brown),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Azure),
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Indigo)
                };

                for (int col = 1; col <= workSheet.UsedRange.Columns.Count; col++)
                {
                    for (int row = 1; row <= workSheet.UsedRange.Rows.Count; row++)
                    {
                        Excel.Range range = workSheet.UsedRange;
                        Excel.Range cell = range.Cells[row, col];
                        if (Convert.ToString(cell.Text).Contains(";"))
                        {
                            int t = 0;
                            foreach(KeyValuePair<int, int> pair in getSubstringBorders(Convert.ToString(cell.Text).Split(';')))
                            {
                                cell.Characters[pair.Key, pair.Value].Font.Color = colors[t++];
                                if (t == 10) t = 0;
                            }
               
                        }
                    

                    }
                }
            } catch (Exception e) { }
            
        }

        public static void DisplayInExcel(List<Row> rows, Excel._Worksheet workSheet, string filePath, bool connect)
        {
            List<string> alphabet = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U" };
            List<string> columnTitle = new List<string> { "Неизвестный тип", "Формат", "Зона", "Позиция", "Обозначение",
                                                          "Наименование", "Количество", "Примечание", "Масса", "Материал", "Пользовательская",
                                                          "Код", "Завод изготовитель", "Номер документа", "Наименование документа",
                                                          "Код документа", "Код ОКП", "Имя файла" };

            rows = group(rows);

            for (int i = 1; i <= rows.Count + 1; i++, lastRowIndex++)
                if (i == 1)
                    for (int j = 1; j <= 18; j++)
                        if (connect)
                            workSheet.Cells[lastRowIndex, alphabet[j - 1]] = columnTitle[j - 1];
                        else
                        {
                            if (j == 18) continue;
                            workSheet.Cells[i, alphabet[j - 1]] = columnTitle[j - 1];
                        }
                            

                else
                    for (int j = 1; j <= 18; j++)
                        if (connect)
                            workSheet.Cells[lastRowIndex, alphabet[j - 1]] = rows[i - 2].getRowAsList()[j - 1];
                        else
                        {
                            if (j == 18) continue;
                            workSheet.Cells[i, alphabet[j - 1]] = rows[i - 2].getRowAsList()[j - 1];
                        }
                            

            sort(workSheet);
            trimEmptyColumns(workSheet);
            if(connect)colorColumns(workSheet);

            lastRowIndex += 1;
            Console.WriteLine(filePath);
            workSheet.SaveAs(filePath + ".xlsx");
        }

    }
}

