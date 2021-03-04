using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kompas6API5;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace KompasToExcel
{
    class Utils
    {
        public static string[] getEntities(ListBox.ObjectCollection collection)
        {
            string[] output = new string[collection.Count];
            for(int i = 0; i < collection.Count; i++)
                output[i] = collection[i].ToString();
            return output;
        }

        public static string getFileNameWithoutCount(string file)
        {
            try
            {
                string[] arr = file.Split(' ');
                arr[arr.Length - 1] = "";
                string output = string.Join(" ", arr).Trim();
                return output.Substring(0, output.Length - 1);
            } catch (Exception e)
            {
                return "";
            }
        }
        public static bool createDirectory(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
                return false;
            }
            else
            {
                var files = Directory.GetFiles(dirName);
                if (files.Length != 0)
                {
                    if (MessageBox.Show("Непустая директория с таким названием уже существует.\nПерезаписать ее?", "Удалить директорию?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < files.Length; i++)
                            File.Delete(files[i]);
                        return false;
                    }
                    else return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string changeFileCount(string file, int newCount)
        {
            try
            {
                string[] arr = file.Split(' ');
                arr[arr.Length - 1] = Convert.ToString(newCount);
                return string.Join(" ", arr).Trim();
            } catch (Exception e)
            {
                return "";
            }
        }

       
    }
}