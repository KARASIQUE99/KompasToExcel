using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Kompas6API5;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace KompasToExcel
{
    public partial class Form1 : Form
    {
        private KompasObject kompas;
        private Excel.Application excelApp;
        private delegate void SafeCallDelegate(string text);

        private string dirPath = "";
        private string filePath = "";
        private string spwPath = "";

        public Form1()
        {
            InitializeComponent();
            InitializeApplications();
        }

        public void InitializeApplications()
        {
            try
            {
                #if __LIGHT_VERSION__
				    Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
                #else
                    Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                #endif

                excelApp = new Excel.Application();
                kompas = (KompasObject)Activator.CreateInstance(t);
                info_label.Text = "";
            } catch (Exception ex)
            {
                info_label.Text = "Ошибка инициализации!";
            }
            
        }

        private void btn_select_dir_in_Click(object sender, EventArgs e)
        {

            try
            {
                listBox1.Items.Clear();
                
                CommonOpenFileDialog FBD = new CommonOpenFileDialog();
                FBD.IsFolderPicker = true;
                FBD.Title = "Выберите папку с исходниками";
                

                if (FBD.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    dirPath = FBD.FileName;
                    dir_in.Text = dirPath;

                    if (filePath == "")
                    {
                        filePath = dirPath+@"\вывод";
                        dir_out.Text = filePath;
                    }
                }

                foreach (string fileName in Directory.GetFiles(dirPath))
                    if (fileName.EndsWith(".cdw"))
                        listBox1.Items.Add(fileName + ", " + 1);

                info_label.Text = "";
        } catch (Exception ex)
            {
                info_label.Text = "Ошибка загрузки пути директории!";
            }

}

        private void btn_select_dir_out_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog FBD = new CommonOpenFileDialog();
                FBD.IsFolderPicker = true;
                FBD.Title = "Выберите папку для вывода";

                if (FBD.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    filePath = FBD.FileName +@"\вывод";
                    dir_out.Text = filePath;
                   
                }
                info_label.Text = "";
            }
            catch (Exception ex)
            {
                info_label.Text = "Ошибка загрузки пути директории!";
            }

        }

        private void btn_select_spw_Click(object sender, EventArgs e)
        {
            try
            {
                if(dirPath != "" && filePath != ""){
                    OpenFileDialog OPD = new OpenFileDialog();
                    OPD.Title = "Выберите файл спецификации с количествами изделий";
                    OPD.Filter = "Файлы спецификаций (*.spw)|*.spw;";
                    if (OPD.ShowDialog() == DialogResult.OK)
                        spwPath = OPD.FileName;
                
                    spw_path.Text = spwPath;
                    string missingFiles = "";

                    Dictionary<string, string> marks= KompasUtils.getFilenamesFromSpc(kompas, spwPath);

                    List<string> copy = new List<string>();
                    for(int i = 0; i<listBox1.Items.Count; i++)
                        copy.Add(listBox1.Items[i].ToString());
                    
                    listBox1.Items.Clear();

                    foreach(string mark in marks.Keys)
                    {
                        bool b = true;
                        string outItem = null;
                        for(int i = 0; i<copy.Count; i++)
                        {
                            string item = copy[i];
                            if (item.Contains(mark)){
                                b = false;
                                copy[i] = Utils.changeFileCount(item, Convert.ToInt32(marks[mark]));
                                outItem = copy[i];
                            }
                        }

                        if (b) missingFiles += mark + "\n";
                        else listBox1.Items.Add(outItem);
  
                    }
                    if (missingFiles != "") MessageBox.Show("Не найдены файлы: \n\n"+missingFiles);

                    info_label.Text = "";
                } else
                {
                    info_label.Text = "Выберите директорию с файлами!";
                }
                
            }
            catch (Exception ex)
            {
                info_label.Text = "Ошибка загрузки файла спецификации!";
            }
        }

        private void cb_use_spw_CheckedChanged(object sender, EventArgs e)
        {
            spw_path.Text = ""; spwPath = "";
   
            if (cb_use_spw.Checked) 
                btn_select_spw.Enabled = true;
            else
                btn_select_spw.Enabled = false; 
        }

        private void WriteTextSafe(string text)
        {
            if (info_label.InvokeRequired)
                info_label.Invoke(new SafeCallDelegate(WriteTextSafe), new object[] { text });
            else
                info_label.Text = text;
        }

        private Dictionary<string, List<Row>> getInputDataFromKompas(KompasObject kompas, string[] fileEntries, bool connect)
        {
            Dictionary<string, List<Row>> outputs = new Dictionary<string, List<Row>>();

            if (connect)
            {
                List<Row> singleInput = new List<Row>();
                foreach (string fileName in fileEntries)
                {
                    int count = Convert.ToInt32(fileName.Split(' ').Last());
                    if (count < 1) continue;
                    for (int i = 0; i < count; i++)
                    {
                        string fName = Utils.getFileNameWithoutCount(fileName);
                        singleInput.AddRange(KompasUtils.getDataFromKompas(kompas, fName, true));
                        WriteTextSafe(fName);
                    }


                }
                outputs.Add("result", singleInput);
            }
            else
            {
                foreach (string fileName in fileEntries)
                {
                    
                    int count = Convert.ToInt32(fileName.Split(' ').Last());
                    if (count < 1) continue;
                    string fileNameWithoutCount = Utils.getFileNameWithoutCount(fileName);
                    WriteTextSafe(fileNameWithoutCount);
                    Console.WriteLine(fileNameWithoutCount);
                    List<Row> rws = KompasUtils.getDataFromKompas(kompas, fileNameWithoutCount, true);
                    List<Row> rows = new List<Row>();
                    for (int i = 0; i < count; i++)
                    {
                        rows.AddRange(rws);
                    }

                    outputs[fileNameWithoutCount] = rows;
                }
            }

            return outputs;
        }

        private void runKompasToExcel(bool connect)
        {
         
            Dictionary<string, List<Row>> inputs = getInputDataFromKompas(kompas, Utils.getEntities(listBox1.Items), connect);
            foreach (KeyValuePair<string, List<Row>> entry in inputs)
            {
                excelApp.Workbooks.Add();
                Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
                string fileName = entry.Key;
                if (entry.Key.EndsWith(".cdw")) fileName = fileName.Substring(0, fileName.Length - 4); 
                ExcelUtils.DisplayInExcel(entry.Value, workSheet, filePath+"\\"+fileName.Split('\\').Last(), connect);
            }
            
        }

        private async void btn_ok_Click(object sender, EventArgs e)
        {  
            try
            {
                groupBox1.Enabled = false;

                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                bool val = Utils.createDirectory(filePath);
                if (val)
                {
                    groupBox1.Enabled = true;
                    return;
                }

                if (dirPath == "" | filePath == "")
                {
                    info_label.Text = "Не указаны необходимые директории!";
                    return;
                }

                if(cb_use_spw.Checked == true && spwPath == "")
                {
                    info_label.Text = "Не выбран файл спецификации!";
                    return;
                }

                bool connect = cb_connect_all.Checked;
               
                for(int i = 0; i<listBox1.Items.Count; i++)
                {
                    var item = listBox1.Items[i].ToString();
                    int count = Convert.ToInt32(item.Split(' ').Last());
                    string newItem = Utils.changeFileCount(item, count * (int)multiplier.Value);
                    listBox1.Items[i] = newItem;
                }
                await Task.Run(() => runKompasToExcel(connect));

                info_label.Text = "Готово!";
                groupBox1.Enabled = true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                info_label.Text = "Ошибка выполнения! Перезагрузите ПО!";
            }

           
            kompas.Quit();
            excelApp.Quit(); 
            Program.exit(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                kompas.Quit();
                excelApp.Quit();
            }
            catch (Exception ex) { }
        }

    }
}
