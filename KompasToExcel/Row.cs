using System;
using System.Collections.Generic;
using Kompas6Constants;
using KompasAPI7;

namespace KompasToExcel
{
    class Row
    {
        public string Unknown { get; set; } = "";
        public string Format { get; set; } = "";
        public string Zone { get; set; } = "";
        public string Position { get; set; } = "";
        public string Mark { get; set; } = "";
        public string Name { get; set; } = "";
        public string Count { get; set; } = "";
        public string Note { get; set; } = "";
        public string Mass { get; set; } = "";
        public string Material { get; set; } = "";
        public string User { get; set; } = "";
        public string Code { get; set; } = "";
        public string Factory { get; set; } = "";
        public string DocumentNumber { get; set; } = "";
        public string DocumentName { get; set; } = "";
        public string DocumentCode { get; set; } = "";
        public string CodeOKP { get; set; } = "";
        public string FileName { get; set; } = "";
        public Row(){}
        public Row(ISpecificationBaseObject spc, string fileName)
        {
            ISpecificationColumns columns = spc.Columns;

            for (int j = 0; j < columns.Count; j++)
            {
                ISpecificationColumnItems items = columns[j].ColumnItems;
                ISpecificationColumnItem item = items[0];

                switch (columns[j].ColumnType)
                {
                    case ksSpecificationColumnTypeEnum.ksSColumnUnknown:
                        Unknown = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnFormat:
                        Format = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnZone:
                        Zone = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnPosition:
                        Position = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnMark:
                        Mark = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnName:
                        Name = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnCount:
                        Count = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnNote:
                        Note = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnMass:
                        Mass = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnMaterial:
                        Material = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnUser:
                        User = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnCode:
                        Code = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnFactory:
                        Factory = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnDocumentNumber:
                        DocumentNumber = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnDocumentName:
                        DocumentName = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnDocumentCode:
                        DocumentCode = Convert.ToString(item.Value);
                        break;
                    case ksSpecificationColumnTypeEnum.ksSColumnCodeOKP:
                        CodeOKP = Convert.ToString(item.Value);
                        break;
                }
            }
            this.FileName = fileName;
        }

        public List<string> getRowAsList()
        {
            List<string> values = new List<string>();

            values.Add(Unknown);
            values.Add(Format);
            values.Add(Zone);
            values.Add(Position);
            values.Add(Mark);
            values.Add(Name);
            values.Add(Count);
            values.Add(Note);
            values.Add(Mass);
            values.Add(Material);
            values.Add(User);
            values.Add(Code);
            values.Add(Factory);
            values.Add(DocumentNumber);
            values.Add(DocumentName);
            values.Add(DocumentCode);
            values.Add(CodeOKP);
            values.Add(FileName);

            return values;
        }
    }
}
