using System;
using System.Collections.Generic;
using Kompas6API5;
using KompasAPI7;

namespace KompasToExcel
{
    class KompasUtils
    {
        //Получить список строк из файла
        public static List<Row> getDataFromKompas(KompasObject kompas, string fileName, bool isCdw)
        {
            List<Row> rows = new List<Row>();
            IApplication app = kompas.ksGetApplication7();
            IKompasDocument doc;

            if(isCdw)
                if (fileName.EndsWith(".cdw")) doc = (IKompasDocument2D)app.Documents.Open(fileName, true, false);
                else throw new Exception();
            else
                if (fileName.EndsWith(".spw")) doc = app.Documents.Open(fileName, true, false);
                else throw new Exception();

            SpecificationDescription desc = doc.SpecificationDescriptions[0];

            if(desc != null)
                for (int i = 0; i < desc.BaseObjects.Count; i++)
                    rows.Add(new Row(desc.BaseObjects[i], fileName));

            if (fileName.EndsWith(".spw"))
                doc.Close(0); 

            return rows;
        }

        public static Dictionary<string, string> getFilenamesFromSpc(KompasObject kompas, string fileName)
        {
            List<Row> spcRows = getDataFromKompas(kompas, fileName, false);
            Dictionary<string, string> output = new Dictionary<string, string>();
            foreach(Row row in spcRows)         
                output.Add(row.Mark, row.Count);       
            return output;
        }
    }
}
