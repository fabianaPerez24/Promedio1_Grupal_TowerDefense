using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Decisiones
    {
        private List<Towers> torres = new List<Towers>();

        private int dinero = 100;

        public List<Towers> GetTorres()
        {
            return torres;
        }

        public int GetDinero()
        {
            return dinero;
        }

        public void AgregarDinero(int cantidad)
        {
            dinero += cantidad;
        }

        public void elergirAccion()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                try
                {
                    Console.WriteLine("\n==============================");
                    Console.WriteLine("       TOWER DEFENSE");
                    Console.WriteLine("==============================");
                    Console.WriteLine($"Dinero: {dinero}");
                    Console.WriteLine($"Torres: {torres.Count}");
                    Console.WriteLine();
                    Console.WriteLine("1. Comprar torre");
                    Console.WriteLine("2. Revisar torres");
                    Console.WriteLine("3. Pasar turno");
                    Console.WriteLine("==============================");

                    Console.Write("Seleccione una opcion: ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int opcion))
                    {
                        Console.WriteLine("Debes escribir un numero.");
                        continue;
                    }

                    switch (opcion)
                    {
                        case 1:
                            ComprarTorre();
                            opcionValida = true;
                            break;

                        case 2:
                            RevisarTorres();
                            Console.WriteLine("\nPresiona ENTER para continuar...");
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("\nPasaste el turno.");
                            opcionValida = true;
                            break;

                        default:
                            Console.WriteLine("Opcion incorrecta.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error: " + ex.Message);
                }
            }
        }

        public void ComprarTorre()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("==============================");
                    Console.WriteLine("       COMPRAR TORRE");
                    Console.WriteLine("==============================");
                    Console.WriteLine($"Dinero disponible: {dinero}");
                    Console.WriteLine();
                    Console.WriteLine("1. Torre de defensa - 20");
                    Console.WriteLine("2. Torre de ataque  - 40");
                    Console.WriteLine("3. Torre de dinero  - 30");
                    Console.WriteLine("4. Cancelar");
                    Console.WriteLine("==============================");

                    Console.Write("Seleccione una torre: ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int opcion))
                    {
                        Console.WriteLine("Debes escribir un numero.");
                        Console.ReadLine();
                        continue;
                    }

                    switch (opcion)
                    {
                        case 1:

                            if (dinero < 20)
                            {
                                Console.WriteLine("No tienes suficiente dinero.");
                                Console.ReadLine();
                                continue;
                            }

                            Towers defensa = new TowerDefense("Torre de defensa", 30, 2);

                            torres.Add(defensa);
                            dinero -= 20;

                            Console.WriteLine("Compraste una Torre de defensa.");

                            opcionValida = true;
                            break;

                        case 2:

                            if (dinero < 40)
                            {
                                Console.WriteLine("No tienes suficiente dinero.");
                                Console.ReadLine();
                                continue;
                            }

                            Towers ataque = new TowerAttack("Torre de ataque", 20, 5);

                            torres.Add(ataque);
                            dinero -= 40;

                            Console.WriteLine("Compraste una Torre de ataque.");

                            opcionValida = true;
                            break;

                        case 3:

                            if (dinero < 30)
                            {
                                Console.WriteLine("No tienes suficiente dinero.");
                                Console.ReadLine();
                                continue;
                            }

                            Towers dineroTower = new MoneyTower("Torre de dinero", 20, 1, 10);

                            torres.Add(dineroTower);
                            dinero -= 30;

                            Console.WriteLine("Compraste una Torre de dinero.");

                            opcionValida = true;
                            break;

                        case 4:

                            Console.WriteLine("Compra cancelada.");
                            opcionValida = true;
                            break;

                        default:

                            Console.WriteLine("Esa torre no existe.");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error: " + ex.Message);
                    Console.ReadLine();
                }
            }
        }

        public void RevisarTorres()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("         MIS TORRES");
            Console.WriteLine("==============================");

            if (torres.Count == 0)
            {
                Console.WriteLine("No tienes torres.");
                return;
            }

            for (int i = 0; i < torres.Count; i++)
            {
                Towers torre = torres[i];

                Console.WriteLine(
                    $"{i + 1}. {torre.name} | Vida: {torre.life} | Daño: {torre.damage}"
                );
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total de torres: {torres.Count}");
        }
    }
}
