internal class Towers : Character
{
    public Towers(string name, int life, int damage) : base(name, life, damage)
    {
    }
    public virtual int Attack(Character target)
    {
        return PerformAttack(target);
    }
}
