using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Test
    {
        private bool inLoop;

        //Relacionado con el jugador
        Decisiones decision = new Decisiones();
        private List<Towers> towers = new List<Towers>();

        //Relacionado con enemigos
        EnemySpawn enemySpawn = new EnemySpawn();
        private int currentEnemies;
        private List<Enemy> enemies = new List<Enemy>();

        public void startTest()
        {
            inLoop = true;
            asd();
        }

        private void asd()
        {
            while (inLoop)
            {
                playerTurn();

                EnemyTurn();
            }
        }

        private void playerTurn()
        {
            Console.Clear();

            decision.elergirAccion();

            Console.ReadLine();
        }

        public void AddTower(Towers tower)
        {
            towers.Add(tower);
        }

        private void EnemyTurn()
        {
            //Limpia la consola
            Console.Clear();
            Console.WriteLine($"[Turno del enemigo]");
            Console.WriteLine();

            //Incrementa un número en base a fibonacci
            enemySpawn.IncreaseEnemies();

            //Génera cantidad de enemigos
            currentEnemies += enemySpawn.amount;

            //Agrega enemigos a la lista de enemigos existentes
            for (int i = 0; i < enemySpawn.amount; i++ )
            {
                Enemy newEnemy = new Enemy("Enemigo", 10, 1);
                enemies.Add(newEnemy);
            }

            Console.WriteLine($"Se generaron {enemySpawn.amount} de enemigos en este turno");

            //Indica cantidad de enemigos
            Console.WriteLine($"Actualmente hay {currentEnemies} enemigos en total");
            
            //Acción de los enemigos
            foreach (Enemy enemy in enemies)
            {
                if (towers.Count <= 0)
                {
                    Console.WriteLine("No te quedan torretas :D");
                    Console.WriteLine("Perdiste");
                    inLoop = false;
                }
                Towers currentTarget = towers[0];

                enemy.Attack(currentTarget);

                if (currentTarget.Dead()) 
                {
                    Console.WriteLine($"{currentTarget.name} fue destruido");
                    towers.RemoveAt(0);
                }
            }

            //Espera un input para continuar al siguiente turno
            Console.ReadLine();
        }
    }

}
