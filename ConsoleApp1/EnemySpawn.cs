using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EnemySpawn
    {
        public int amount;

        int a = 0;
        int b = 1;
        int c;

        public void IncreaseEnemies()
        {
            amount = a;

            c = a + b;
            a = b;
            b = c;
        }
    }
}
