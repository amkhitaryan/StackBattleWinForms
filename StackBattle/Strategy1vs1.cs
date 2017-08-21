using System.Linq;

namespace StackBattle
{
    /// <summary>
    /// Стратегия боя в колонну по 1
    /// </summary>
    class Strategy1vs1 : IStrategy
    {
        public void Combat(Army a, Army b)
        {
            //Бой начинается с обмена ударами впереди стоящих юнитов
            b.Units.First().GetHit(a.Units.First().Damage);
            if (b.Units.First().Hitpoints > 0) //Если атакованный юнит выжил - он бьет в ответ
            {
                a.Units.First().GetHit(b.Units.First().Damage);
            }
            //Далее, начиная со второй позиции, юниты совершают специальные действия
            int j = 1, k = 1;
            while (j < a.Units.Count || k < b.Units.Count)
            {
                if (j < a.Units.Count && a.Units.ElementAt(j).Hitpoints > 0)
                {
                    var tmp = a.Units.ElementAt(j) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility)a.Units.ElementAt(j)).DoSpecialAbility(a, b, j, 0);
                    }
                }
                if (k < b.Units.Count && b.Units.ElementAt(k).Hitpoints > 0)
                {
                    var tmp = b.Units.ElementAt(k) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility)b.Units.ElementAt(k)).DoSpecialAbility(b, a, k, 0);
                    }
                }
                ++j;
                ++k;
            }
        }
    }
}
