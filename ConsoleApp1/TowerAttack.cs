using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TowerAttack : Towers
    {
        public TowerAttack(string name, int life, int damage) : base(name, life, damage)
        {
        }

        public override int Attack(Character target)
        {
            Random random = new Random();
            if(random.Next(1,6)==1)
            {
                return PerformAttack(target) + 5;
            }

            return PerformAttack(target);
        }

    }
}
