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
            string pA = "";
            int opcion = 0;
            string ZDR_S = "";
            int ZDR_I = 0;
            int Resultados = 0;
            string[] RID = new string[200];
            double[] PR = new double[200];
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

                bool[] requerimientoE = { false, false, false };

                //InputLab input = JsonSerializer.Deserialize<InputLab>(jsonObjects[0]);
                //System.Console.ReadLine();
                if (input.input1[0].builds.Apartments != null)
                {
                    requerimientoE[0] = true;
                }
                if (input.input1[0].builds.Houses != null)
                {
                    requerimientoE[1] = true;
                }
                if (input.input1[0].builds.Premises != null)
                {
                    requerimientoE[2] = true;
                }
                /////
                if (input.input2.typeBuilder == "Houses")
                {
                    Zone = input.input2.minDanger;
                    opcion = 1;
                    if (ZDR_S == "Green") { ZDR_I = 3; }
                    if (ZDR_S == "Yellow") { ZDR_I = 2; }
                    if (ZDR_S == "Orange") { ZDR_I = 1; }
                    if (ZDR_S == "Red") { ZDR_I = 0; }
                }
                if (input.input2.typeBuilder == "Apartmets")
                {
                    pets = input.input2.wannaPetFriendly.Value;
                    opcion = 0;

                }
                if (input.input2.typeBuilder == "Premises")
                {
                    comercialActivity = input.input2.commercialActivity;
                    opcion = 2;
                }
                //APARTAMENTOS

                /*for (int i = 0; i < input.input1.Length; i++)
                {
                //input.input1[i].builds.Apartments[].id;
                
                for (int j = 0; j < input.input1[i].builds.Apartments.Length; j++)
                {
                    if ((input.input1[i].builds.Apartments[i].isPetFriendly = pets) && (input.input1[i].builds.Apartments[i].price <= input.input2.budget))
                    {
                        pA = input.input1[i].builds.Apartments[i].id;
                        Console.WriteLine(pA);
                    }
                }
                }*/
            switch (opcion) {
                case 0:{
                        for (int i = 0; i < input.input1.Length; i++)
                        {
                            if (input.input1[i].builds.Apartments != null)
                            {
                                requerimientoE[0] = true;
                            }
                            if (requerimientoE[0] = true)
                            {
                                string[] Id = new string[input.input1[i].builds.Apartments.Length];
                                bool[] PetFriendly = new bool[input.input1[i].builds.Apartments.Length];
                                double[] Budgets = new double[input.input1[i].builds.Apartments.Length];
                                //EVALUACION 
                                for (int a = 0; a < input.input1[i].builds.Apartments.Length; a++)
                                {
                                    Id[a] = input.input1[i].builds.Apartments[a].id;
                                    PetFriendly[a] = input.input1[i].builds.Apartments[a].isPetFriendly;
                                    Budgets[a] = input.input1[i].builds.Apartments[a].price;
                                }

                                for (int j = 0; j < input.input1[i].builds.Apartments.Length; j++)
                                {
                                    if ((input.input1[i].builds.Apartments[i].isPetFriendly = pets) && (input.input1[i].builds.Apartments[i].price <= input.input2.budget))
                                    {
                                        RID[Resultados] = Id[j];
                                        PR[Resultados] = Budgets[j];
                                        Resultados++;
                                    }
                                }
                                requerimientoE[0] = false;
                            }
                        }
                        break;
                    }
                case 1: {
                        for (int i = 0; i < input.input1.Length; i++)
                        {
                            if (input.input1[i].builds.Houses != null) 
                            {
                                requerimientoE[1] = true;
                            }
                            if (requerimientoE[1] = true) {
                                string[] Id = new string[input.input1[i].builds.Houses.Length];
                                int[] zoneDangerous = new int[input.input1[i].builds.Houses.Length];
                                double[] Budgets = new double[input.input1[i].builds.Houses.Length];
                                string Color = "";
                                int zonsD = 0;
                                //EVALUACION 
                                for (int a = 0; a < input.input1[i].builds.Apartments.Length; a++)
                                {
                                    Id[a] = input.input1[i].builds.Houses[a].id;
                                    Budgets[a] = input.input1[i].builds.Houses[a].price;
                                    Color = input.input1[i].builds.Houses[a].zoneDangerous;
                                    // Se asigna el número dependiendo del color de zona de riesgo//
                                    if (Color == "Green") { zonsD = 3; }
                                    if (Color == "Yellow") { zonsD = 2; }
                                    if (Color == "Orange") { zonsD = 1; }
                                    if (Color == "Red") { zonsD = 0; }
                                    zoneDangerous[a] = zonsD;
                                }
                                for (int j = 0; j < input.input1[i].builds.Apartments.Length; j++)
                                {
                                    if (zoneDangerous[j] <= zonsD && Budgets[j] <= input.input2.budget)
                                    {
                                        RID[Resultados] = Id[j];
                                        PR[Resultados] = Budgets[j];
                                        Resultados++;
                                    }
                                }  
                            }
                            requerimientoE[1] = false;
                        }
                            break;
                    }
                case 2:
                    {
                        for (int i = 0; i < input.input1.Length; i++)
                        {
                            if (input.input1[i].builds.Premises != null) {
                                requerimientoE[2] = true; 
                            }
                            if (requerimientoE[2] == true)
                            {
                                string[] Id = new string[input.input1[i].builds.Premises.Length];
                                bool[] Ca = new bool[input.input1[i].builds.Premises.Length];
                                double[] Budgets = new double[input.input1[i].builds.Premises.Length];
                                for (int a = 0; a < input.input1[i].builds.Premises.Length; a++)
                                {
                                    Id[a] = input.input1[i].builds.Premises[a].id;
                                    Budgets[a] = input.input1[i].builds.Premises[a].price;
                                    for (int b = 0; b < input.input1[i].builds.Premises[a].commercialActivities.Length; b++)
                                    {
                                        if (input.input1[i].builds.Premises[a].commercialActivities[b] == input.input2.commercialActivity)
                                        {
                                            Ca[a] = true;
                                        }

                                    }
                                }

                                //Se evaluan las condiciones de Budget y Commercial Activities//
                                for (int j = 0; j < input.input1[i].builds.Premises.Length; j++)
                                {
                                    if (Ca[j] == true && Budgets[j] <= input.input2.budget)
                                    {
                                        RID[Resultados] = Id[j];
                                        PR[Resultados] = Budgets[j];
                                        Resultados++;
                                    }
                                }
                            }
                            requerimientoE[2] = false;
                        }
                        break;
                    }
            }
            // Ordenamiento//
            double temporalD = 0;
            string temporalS = "";
            for (int i = 0; i < Resultados; i++) // i = current//
            {
                int pivote = i;
                for (int j = 0; j < Resultados; j++)
                {
                    if (PR[pivote] <= PR[j])
                    {
                        pivote = j;
                    }
                    temporalD = PR[i];
                    temporalS = RID[i];
                    RID[i] = RID[pivote];
                    PR[i] = PR[pivote];
                    RID[pivote] = temporalS;
                    PR[pivote] = temporalD;
                }
            }
            string RespuestaFinal = "[";

            for (int i = 0; i < Resultados; i++)
            {
                if (i < Resultados - 1)
                {
                    RespuestaFinal = RespuestaFinal + "\"" + RID[i] + "\"" + ",";
                }
                else
                {
                    RespuestaFinal = RespuestaFinal + "\"" + RID[i] + "\"";
                }
            }
            RespuestaFinal = RespuestaFinal + "]";

            Console.WriteLine(RespuestaFinal);
            Console.ReadKey();
            
        }
        
	

	}
    }

