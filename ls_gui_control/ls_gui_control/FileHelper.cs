using System;
using System.Collections.Generic;
using System.IO;

namespace ls_gui_control
{
    internal static class FileHelper
    {

        public static IEnumerable<string> LoadFile(string filePath)
        {
            var fileText = new List<string>();

            if (File.Exists(filePath))
            {
                try
                {
                    var file = new StreamReader(filePath);

                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        fileText.Add(line);
                    }

                    file.Close();
                }
                catch (Exception)
                {
                    // throw new Exception(ex.ToString());
                }
            }
            else
            {
                //throw new Exception(filePath + " файл отсутствует");
            }

            return fileText.ToArray();
        }

        public static void SaveText(string filePath, string line, bool reWrite)
        {
            var files = new FileInfo(filePath);

            if (reWrite)
            {
                //var file = new StreamWriter(filePath);

                //if (files.Exists == false)
                //    files.Create();

                //file.WriteLine(line);
                //file.Close();
            }
            else
            {
                using (var file = new StreamWriter(filePath, true))
                {
                    file.WriteLine(line);
                    // file.Dispose();
                    file.Flush();
                }
            }
        }
    }
}
