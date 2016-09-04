using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApi.Services
{
   
        public interface ICsvReader
        {
            IEnumerable<string> ReadDataFromCsv(string filePath);
        }

        public class CsvReader : ICsvReader
        {
            public IEnumerable<string> ReadDataFromCsv(string filePath)
            {
                if (!filePath.EndsWith(".csv"))
                {
                    throw new Exception("Not a csv file");
                }
                if (!File.Exists(filePath))
                {
                    throw new Exception("File not found");
                }               
                
                return File.ReadAllLines(filePath).Skip(1);               
            
            }
        }    
}
