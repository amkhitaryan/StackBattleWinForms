using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StackBattle
{
    /// <summary>
    /// Пехотинец
    /// </summary>
    [Serializable]
    class InfantryUnit : IUnit, ICanBeHealed, ICloneable, ISpecialAbility
    {
        public InfantryUnit(double hp = 10, int dmg = 4, int armor = 2)
        {
            _hitpoints = hp;
            Damage = dmg;
            Armor = armor;
        }

        private double _hitpoints;
        private Random _rnd;
        private Engine _engine = Engine.CreateInstance();

        public double Hitpoints
        {
            get { return _hitpoints; }
            private set { _hitpoints = value > MaxHealth ? MaxHealth : value; }
        }

        public int MaxHealth => _MaxHealth;
        public int Damage { get; }
        private int Armor { get; }
        public int Cost => _cost;
        private static readonly int _cost = 10;
        private const int _MaxHealth = 10;

        /// <summary>
        /// Уменьшает здоровье юнита
        /// </summary>
        /// <param name="dmg">Полученный урон здоровью</param>
        public void GetHit(double dmg)
        {
            _hitpoints -= dmg - (dmg * (5 * Armor) / 100);
            
        }

        public string GetUnitInfo()
        {
            return $"[Infantry:hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";
        }

        public void GetHeal(int hp)
        {
            Hitpoints += hp;
        }

        public object Clone()
        {
            return new InfantryUnit(this.Hitpoints, this.Damage, this.Armor);
        }

        private HeavyUnitDecorator GetRandomDecorator(HeavyUnit hu)
        {
            _rnd = new Random((int) DateTime.Now.Ticks);
            if (!hu.Shield)
            {
                Debug.Write(" Щитом");
                return new ShieldDecorator(hu);
            }
            if(!hu.Pike)
            {
                Debug.Write(" Копьем");
                return new PikeDecorator(hu);
            }
            if (!hu.Helmet) 
            {
                Debug.Write(" Шлемом");
                return new HelmetDecorator(hu);
            }
            if (!hu.Horse)
            {
                Debug.Write(" Лошадью");
                return new HorseDecorator(hu);
            }
            return null;

            //var rnd = _rnd.Next(0, 4);
            //switch (rnd)
            //{
            //    case 0:
            //        if(hu.Shield)
            //        Debug.Write(" Щитом");
            //        return new ShieldDecorator(hu);
            //    case 1:
            //        Debug.Write(" Копьем");
            //        return new PikeDecorator(hu);
            //    case 2:
            //        Debug.Write(" Шлемом");
            //        return new HelmetDecorator(hu);
            //    case 3:
            //        Debug.Write(" Лошадью");
            //        return new HorseDecorator(hu);
            //    default:
            //        throw new ArgumentException("Wrong Decorator argument" + rnd + ".");
            //}
        }

        public void DoSpecialAbility(Army a, Army b, int position, int combatMode)
        {
            _rnd = new Random((int) DateTime.Now.Ticks);
            if (_rnd.Next(0, 10) != 7) return; //10% шанс

            if (combatMode == 0 || combatMode == 2)
            {
                var tmp = a.Units.ElementAt(position - 1) as HeavyUnit;
                //if (tmp != null && a.Units.ElementAt(position - 1).Hitpoints > 0 
                //Проверяем, что юнит лечится, что он не труп и, что у него не макс хп
                if (tmp != null && ((IUnit) tmp).Hitpoints > 0)
                {
                    Debug.Write("Экипирован юнит из армии(" + a.Mark + ") на позиции " + (position - 1) + " с позиции " +
                                position + " " + ((IUnit) tmp).GetUnitInfo());
                    GetRandomDecorator(tmp);
                    Debug.WriteLine(" => " + ((IUnit)tmp).GetUnitInfo());
                    return;
                }
                //Этот метод не будет вызван, если пехотинец стоит на первой позиции(0), поэтому проверяем только верхнюю границу
                if (position == a.Units.Count - 1) return;
                tmp = a.Units.ElementAt(position + 1) as HeavyUnit;
                if (tmp != null && ((IUnit)tmp).Hitpoints > 0)
                {
                    Debug.Write("Экипирован юнит из армии(" + a.Mark + ") на позиции " + (position + 1) + " с позиции " +
                                position + " " + ((IUnit) tmp).GetUnitInfo());
                    GetRandomDecorator(tmp);
                    Debug.WriteLine(" => " + ((IUnit)tmp).GetUnitInfo());
                }
            }
            else if (combatMode == 1)
            {
                int[] indexes = _engine.SpecialAbilityHelper(position);
                foreach (int t in indexes)
                {
                    if (t < 0 || t >= a.Units.Count) continue;
                    var tmp = a.Units.ElementAt(t) as HeavyUnit;
                    if (tmp != null && ((IUnit)tmp).Hitpoints > 0 )
                    {
                        Debug.Write("Экипирован юнит из армии(" + a.Mark + ") на позиции " + t + " с позиции " +
                                    position + " " + ((IUnit) tmp).GetUnitInfo());
                        GetRandomDecorator(tmp);
                        Debug.WriteLine(" => " + ((IUnit)tmp).GetUnitInfo());
                        return;
                    }
                }
            }
        }
    }
}
