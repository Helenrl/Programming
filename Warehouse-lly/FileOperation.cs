using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Warehouse_lly
{
    public class FileOperation
    {
        public List <string> ReadFile(string fileName)
        {

            List<string> lineList = new List<string>();
            string line;
            try
            {
                using (StreamReader fileReader = new StreamReader(fileName, System.Text.Encoding.UTF8))
                    while ((line=fileReader.ReadLine())!=null)
                      lineList.Add(line);
             }
            catch (IOException)
            {
                lineList = null;
                Console.WriteLine("File({0}) not found in the specified path", fileName);
            }
            return lineList ; 
        }
    }
}
