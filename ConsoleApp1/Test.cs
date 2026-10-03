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

        // Sistema del jugador
        private Decisiones decision = new Decisiones();
        private List<Towers> towers;

        // Sistema de enemigos
        private EnemySpawn enemySpawn = new EnemySpawn();
        private List<Enemy> enemies = new List<Enemy>();

        private int currentEnemies;

        // Turno actual
        private int turn = 0;

        public void startTest()
        {
            inLoop = true;

            // Utilizamos la misma lista que maneja Decisiones
            towers = decision.GetTorres();

            Console.WriteLine("=================================");
            Console.WriteLine("        TOWER DEFENSE");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("Defiende tus torres todo lo que puedas.");
            Console.WriteLine();
            Console.WriteLine("Presiona ENTER para comenzar...");

            Console.ReadLine();

            GameLoop();
        }

        private void GameLoop()
        {
            while (inLoop)
            {
                turn++;

                PlayerTurn();

                if (!inLoop)
                    break;

                TowerAttackTurn();

                if (!inLoop)
                    break;

                EnemyTurn();

                CheckGameOver();

                if (!inLoop)
                    break;

                GiveMoney();

                Console.WriteLine();
                Console.WriteLine("Presiona ENTER para comenzar el siguiente turno...");
                Console.ReadLine();
            }

            GameOver();
        }

        private void PlayerTurn()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine($"           TURNO {turn}");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine($"Enemigos actuales: {enemies.Count}");
            Console.WriteLine($"Torres actuales: {towers.Count}");
            Console.WriteLine($"Dinero: {decision.GetDinero()}");
            Console.WriteLine();

            decision.elergirAccion();
        }

        private void TowerAttackTurn()
        {
            if (towers.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No tienes torres.");
                return;
            }

            if (enemies.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No hay enemigos para atacar.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("        ATAQUE DE TORRES");
            Console.WriteLine("=================================");

            // Cada torre ataca a un enemigo
            foreach (Towers tower in towers.ToList())
            {
                if (enemies.Count == 0)
                    break;

                Enemy target = enemies[0];

                int damage = tower.Attack(target);

                Console.WriteLine(
                    $"{tower.name} ataca a {target.name} y hace {damage} de daño."
                );

                if (target.Dead())
                {
                    Console.WriteLine(
                        $"{target.name} fue derrotado."
                    );

                    enemies.Remove(target);
                    currentEnemies--;
                }
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("         TURNO ENEMIGO");
            Console.WriteLine("=================================");

            // Fibonacci controla la cantidad de enemigos
            enemySpawn.IncreaseEnemies();

            currentEnemies += enemySpawn.amount;

            for (int i = 0; i < enemySpawn.amount; i++)
            {
                Enemy newEnemy = new Enemy(
                    "Enemigo",
                    10,
                    1
                );

                enemies.Add(newEnemy);
            }

            Console.WriteLine(
                $"Se generaron {enemySpawn.amount} enemigos."
            );

            Console.WriteLine(
                $"Enemigos totales: {enemies.Count}"
            );

            if (towers.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No quedan torres.");
                return;
            }

            // Los enemigos atacan las torres
            foreach (Enemy enemy in enemies.ToList())
            {
                if (towers.Count == 0)
                    break;

                Towers currentTarget = towers[0];

                int damage = enemy.Attack(currentTarget);

                Console.WriteLine(
                    $"{enemy.name} ataca a {currentTarget.name} y hace {damage} de daño."
                );

                if (currentTarget.Dead())
                {
                    Console.WriteLine(
                        $"{currentTarget.name} fue destruida."
                    );

                    towers.Remove(currentTarget);
                }
            }
        }

        private void GiveMoney()
        {
            int moneyGenerated = 0;

            foreach (Towers tower in towers)
            {
                if (tower is MoneyTower moneyTower)
                {
                    moneyGenerated += moneyTower.Money;
                }
            }

            if (moneyGenerated > 0)
            {
                decision.AgregarDinero(moneyGenerated);

                Console.WriteLine();
                Console.WriteLine(
                    $"Tus torres de dinero generaron ${moneyGenerated}."
                );
            }

            // Recompensa básica por sobrevivir al turno
            decision.AgregarDinero(10);

            Console.WriteLine(
                "Recibiste 10 de dinero por sobrevivir al turno."
            );
        }

        private void CheckGameOver()
        {
            if (towers.Count <= 0)
            {
                inLoop = false;
            }
        }

        private void GameOver()
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("          GAME OVER");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("Te quedaste sin torres.");
            Console.WriteLine();
            Console.WriteLine($"Turnos sobrevividos: {turn}");
            Console.WriteLine($"Enemigos derrotados: {currentEnemies}");
            Console.WriteLine();
            Console.WriteLine("Presiona ENTER para salir...");

            Console.ReadLine();
        }

        public void AddTower(Towers tower)
        {
            if (tower == null)
                return;

            towers.Add(tower);
        }
    }
}
