using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Poem_Generator.Entities
{
    public class FilesHandler
    {
        public static string[] getLinesFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] linesRead = System.IO.File.ReadAllLines(path);
                    return linesRead.ToArray();
                }
                else
                {
                    throw new Exception($"File not found, verify that file exists. Path: {path}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void createFileFromLines(string path, string[] lines)
        {
            if (File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}
