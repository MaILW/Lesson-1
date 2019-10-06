using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;



namespace Logs
{
    class Program
    {
     
        static  int colStrok(string nameFile)
        {
            int colStr = 0;
            FileStream log = new FileStream(nameFile, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(log);
            do
            {
                reader.ReadLine();
                colStr++;
            } while (reader.EndOfStream == false);
            reader.Close();
            log.Close();
            return colStr;
        }
      
        static void pars(string fileName, string target)
        {
            
            StreamReader reader = new StreamReader(fileName);
            List<string> logStr = new List<string>();
            
            string[][] log = new string[0][];
            
            int k = 0;
            string v;
            
           
            while (reader.EndOfStream == false)
            {
                if ((v = reader.ReadLine()) != "")
                {
                    if (v.Contains("garbage")) continue;
                    logStr.Add(v);
                    Array.Resize(ref log, log.Length + 1);
                    log[k] = logStr[k].Split(new char[] { ':' });
                    k++;
                }
            }
            int colStr = log.Length;
            
            bool error = true;
            
                for(int i =0;i < colStr;i++ )
                {
                    if (target == log[i][1]) error = false;
                }
            if (error == true)
            {
                
                Console.WriteLine(Path.GetFileNameWithoutExtension(fileName) + "\t\tТакого устройства нет");
                return;
            }

            for (
                int i = 0; i < colStr; i++)
            {
                
                if (String.Compare(target, log[i][1]) == 0)
                {

                    Console.WriteLine(Path.GetFileNameWithoutExtension(fileName) + "-" + log[i][0] + ") \tзначение: " + log[i][2]);
                    // Console.WriteLine(fileName.Substring(56, 21) +"-"+log[i][0]+ ") значение: " + log[i][2]);

                }
                               
            }
            reader.Dispose();
            reader.Close();
           
         

        }
        static void Main(string[] args)
        {
            
            string target = null;
            string[] vivod = new string[0];
           
            string nameFile = ("D:\\MaILW\\Documents\\Visual Studio 2019\\Projects\\Logs\\log");

            List<string> names = new List<string>();
            names.AddRange(Directory.GetFiles(nameFile));

            do {
                Console.Write("Введите имя устройства: ");
                target = Console.ReadLine();


                foreach (string a in names)
                {
                    pars(a, target);
                }
                Console.Write("\nВведите q для выхода: ");
            } while (Console.ReadLine()!="q");
           
        }
        
        
    }
}
