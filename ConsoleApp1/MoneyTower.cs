using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MoneyTower : TowerDefense
    {
        public int Money {  get; set; }
        public MoneyTower(string name, int life, int damage, int money) : base(name, life, damage)
        {
            Money = money;
        }
    }
}

