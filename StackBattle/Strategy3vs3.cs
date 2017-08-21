using System;
using System.Linq;

namespace StackBattle
{
    /// <summary>
    /// Стратегия боя в колонну по 3
    /// </summary>
    class Strategy3vs3 : IStrategy
    {
        public void Combat(Army a, Army b)
        {
            //Бой начинается с обмена ударами впереди стоящих 3-х юнитов
            for (int i = 0; i < 3 && i < Math.Min(a.Units.Count,b.Units.Count); i++)
            {
                b.Units.ElementAt(i).GetHit(a.Units.ElementAt(i).Damage);
                if(b.Units.ElementAt(i).Hitpoints > 0) a.Units.ElementAt(i).GetHit(b.Units.ElementAt(i).Damage);
            }
            //Далее, начиная со второй шеренги , юниты совершают специальные действия
            int j = 3, k = 3;
            while (j < a.Units.Count || k < b.Units.Count)
            {
                if (j < a.Units.Count && a.Units.ElementAt(j).Hitpoints > 0)
                {
                    var tmp = a.Units.ElementAt(j) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility)a.Units.ElementAt(j)).DoSpecialAbility(a, b, j, 1);
                    }
                }
                if (k < b.Units.Count && b.Units.ElementAt(k).Hitpoints > 0)
                {
                    var tmp = b.Units.ElementAt(k) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility)b.Units.ElementAt(k)).DoSpecialAbility(b, a, k, 1);
                    }
                }
                ++j;
                ++k;
            }
        }
    }
}
