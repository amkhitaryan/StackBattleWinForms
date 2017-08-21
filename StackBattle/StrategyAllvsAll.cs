using System;
using System.Linq;

namespace StackBattle
{
    /// <summary>
    /// Стратегия боя стенка на стенку
    /// </summary>
    class StrategyAllvsAll : IStrategy
    {
        public void Combat(Army a, Army b)
        {
            //Обмен ударами между всеми юнитами, перед лицом которых есть противник
            int pairs = Math.Min(a.Units.Count, b.Units.Count);
            for (int i = 0; i < pairs; i++)
            {
                b.Units.ElementAt(i).GetHit(a.Units.ElementAt(i).Damage);
                if (b.Units.ElementAt(i).Hitpoints > 0) a.Units.ElementAt(i).GetHit(b.Units.ElementAt(i).Damage);
            }
            //Остальные выполняют специальные действия, это всегда будет только одна из армий
            if (pairs != a.Units.Count)
            {
                for (int i = pairs; i < a.Units.Count && a.Units.ElementAt(i).Hitpoints > 0; i++)
                {
                    var tmp = a.Units.ElementAt(i) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility) a.Units.ElementAt(i)).DoSpecialAbility(a, b, i, 2);
                    }
                }
            }
            else
            {
                for (int i = pairs; i < b.Units.Count && b.Units.ElementAt(i).Hitpoints > 0; i++)
                {
                    var tmp = b.Units.ElementAt(i) as ISpecialAbility;
                    if (tmp != null)
                    {
                        ((ISpecialAbility)b.Units.ElementAt(i)).DoSpecialAbility(b, a, i, 2);
                    }
                }
            }
       }
    }
}
