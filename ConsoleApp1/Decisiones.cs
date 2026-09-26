using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Decisiones
    {

        public List<string> torres = new List<string>();

        public void elergirAccion()
        {
            int opcion = 0;

            try
            {
                Console.WriteLine("\n------------------");
                Console.WriteLine("1. Comprar torre");
                Console.WriteLine("2. Revisar torres");
                Console.WriteLine("3. Pasar turno");

    
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    ComprarTorre();
                }
                else if (opcion == 2)
                {
                    RevisarTorres();
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("Pasaste el turno.");
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta.");
                }
            }
            catch
            {
                Console.WriteLine("Debes escribir un numero.");
            }
        }

        public void ComprarTorre()
        {
            Console.WriteLine("\n--- COMPRAR TORRE ---");
            Console.WriteLine("1. Torre de defensa");
            Console.WriteLine("2. Torre de ataque");
            Console.WriteLine("3. Torre de dinero");

            try
            {
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    torres.Add("Torre Defensa");
                    Console.WriteLine("Compraste una Torre de defensa");
                }
                else if (opcion == 2)
                {
                    torres.Add("Torre Ataque");
                    Console.WriteLine("Compraste una Torre de ataque");
                }
                else if (opcion == 3)
                {
                    torres.Add("Torre Dinero");
                    Console.WriteLine("Compraste una Torre de dinero");
                }
                else
                {
                    Console.WriteLine("Esa torre no existe.");
                }
            }
            catch
            {
                Console.WriteLine("Debes escribir un numero.");
            }
        }

        public void RevisarTorres()
        {
            Console.WriteLine("\n--- MIS TORRES ---");

            if (torres.Count == 0)
            {
                Console.WriteLine("No tienes torres.");
            }
            else
            {
                foreach (string torre in torres)
                {
                    Console.WriteLine("- " + torre);
                }

                Console.WriteLine("Total de torres: " + torres.Count);
            }
        }
    }
}
