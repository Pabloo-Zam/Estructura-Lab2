using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Laboratorio1
{
    internal class Program
    {
        public class InputLab
        {
            public Dictionary<string, bool>[] input1 { get; set; }
            public string[] input2 { get; set; }
        }
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(@"D:\Desktop\1er ciclo 2023\Estructura Lab\Estructura-Lab2\input_lab_2_example.jsonl"))
            {
                System.Console.WriteLine(line);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                };
               
                System.Console.ReadLine();
            }
        }
    }
}
