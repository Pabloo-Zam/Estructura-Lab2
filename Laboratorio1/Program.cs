using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.IO;

namespace Laboratorio1
{
    internal class Program
    {
        public class House
        {
            public string zoneDangerous { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }
        public class Apartment
        {
            public bool isPetFriendly { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }
        public class Premise
        {
            public string[] commercialActivities { get; set; }
            public string address { get; set; }
            public double price { get; set; }
            public string contactPhone { get; set; }
            public string id { get; set; }
        }
        public class Builds
        {
            public Premise[] Premises { get; set; }
            public Apartment[] Apartments { get; set; }
            public House[] Houses { get; set; }
        }
        public class Input1
        {
            public Dictionary<string, bool> services { get; set; }
            public Builds builds { get; set; }

        }
        public class Input2
        {
            public double budget { get; set; }
            public string typeBuilder { get; set; }
            public string[] requiredServices { get; set; }
            public string commercialActivity { get; set; }
            public bool? wannaPetFriendly { get; set; }
            public string minDanger { get; set; }
        }
        public class InputLab
        {
            public Input1[] input1 { get; set; }
            public Input2 input2 { get; set; }
        }
        /////
        static void Main(string[] args)
        {
            
            //LEER JSON
            string Zone;
            bool pets=true;
            string comercialActivity;
            string pA = "jjj";
            // = true;

            /*foreach (string line in System.IO.File.ReadLines(@"D:\Desktop\1er ciclo 2023\Estructura Lab\Estructura-Lab2\input_lab_2_example.jsonl"))
            {
                string[] jsonObjects = line.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                System.Console.WriteLine(line);
                var options = new JsonSerializerOptions


                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                };
            }*/
            string jsonText = File.ReadAllText(@"D:\Desktop\1er ciclo 2023\Estructura Lab\LAB2\input_lab_2_example.jsonl");
            string[] jsonObjects = jsonText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            InputLab input = JsonSerializer.Deserialize<InputLab>(jsonObjects[0]);
            //Console.WriteLine("Si lo leyo");
            //InputLab input = JsonSerializer.Deserialize<InputLab>(line, options);

            bool[] TypeBuilders = new bool[3];
                //InputLab input = JsonSerializer.Deserialize<InputLab>(jsonObjects[0]);
                //System.Console.ReadLine();
                if (input.input1[0].builds.Apartments != null)
                {
                    TypeBuilders[0] = true;
                }
                if (input.input1[0].builds.Houses != null)
                {
                    TypeBuilders[1] = true;
                }
                if (input.input1[0].builds.Premises != null)
                {
                    TypeBuilders[0] = true;
                }

                if (input.input2.typeBuilder == "Houses")
                {
                    Zone = input.input2.minDanger;

                }
                if (input.input2.typeBuilder == "Apartmets")
                {
                    pets = input.input2.wannaPetFriendly.Value;


                }
                if (input.input2.typeBuilder == "Premises")
                {
                    comercialActivity = input.input2.commercialActivity;

                }
                //APARTAMENTOS
                for (int i = 0; i < input.input1.Length; i++)
                {
                    //input.input1[i].builds.Apartments[].id;
                    if (input.input1[i].builds.Apartments[i].isPetFriendly == pets)
                    {
                        pA = input.input1[i].builds.Apartments[i].id;
                        Console.WriteLine(pA);
                    }

                }
                Console.WriteLine("HOLAAA");
            Console.ReadKey();
            
        }
        
	

	}
    }

