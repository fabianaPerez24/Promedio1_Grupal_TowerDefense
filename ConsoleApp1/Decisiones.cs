using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Decisiones
    {
        public int elergirAccion()
        { 

            int opcion = 0;

            try
            {
                Console.WriteLine(" -------------------");
                Console.WriteLine("1.Comprar Torres");
                Console.WriteLine("2.Mejorar Torres");
                Console.WriteLine("3.Pasar turno");
                Console.WriteLine(" Elige");
                opcion = int.Parse(Console.ReadLine());

                if (opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Debes escoger un numero");
                    opcion = 3;
                }
            }
            catch
            {
                Console.WriteLine("Opción invalida");
                opcion = 3;
            }
            return opcion;
        }
    } 
}
