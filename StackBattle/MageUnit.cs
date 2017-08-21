using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    [Serializable]
    class MageUnit : Subject
    {
        private readonly Engine _engine = Engine.CreateInstance();
        private Random _rnd = new Random(DateTime.Now.Millisecond);
        internal double _hitpoints;
        private const int _MaxHealth = 6;
        private static readonly int _cost = 13;
        internal double _damage = 2;

        public override double Hitpoints
        {
            get { return _hitpoints; }
            protected set { _hitpoints = value > MaxHealth ? MaxHealth : value; }

        }
        public override int MaxHealth => _MaxHealth;
        public override int Damage {
            get { return (int)_damage; }
            protected set { _damage = value; }
        }
        public int Armor { get; }
        public override int Cost => _cost;

        public MageUnit(int hp = 6, int dmg = 2, int armor = 1)
        {
            _hitpoints = hp;
            Damage = dmg;
            Armor = armor;
        }

        public override void GetHit(double dmg)
        {
            _hitpoints -= dmg - (dmg * (5 * Armor) / 100);
        }

        public override void GetHeal(int hp)
        {
            Hitpoints += hp;
        }

        public override string GetUnitInfo()
        {
            return $"[Mage:hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";

        }

        public override void DoSpecialAbility(Army a, Army b, int position, int combatMode)
        {
            //_rnd = new Random((int)DateTime.Now.Ticks);
            //if (_rnd.Next(0, 10) != 3) return; //10% шанс

            if (combatMode == 0 || combatMode == 2)
            {
                var tmp = a.Units.ElementAt(position - 1) as ICloneable;
                if (tmp != null && a.Units.ElementAt(position - 1).Hitpoints > 0)
                {
                    a.Units.Add((IUnit)tmp.Clone());
                    Debug.WriteLine("Клонирован юнит из армии(" + a.Mark + ") на позиции " + (position - 1) + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                    return;
                }
                //Этот метод не будет вызван, если маг стоит на первой позиции(0), поэтому проверяем только верхнюю границу
                if (position == a.Units.Count - 1) return;
                tmp = a.Units.ElementAt(position + 1) as ICloneable;
                if (tmp != null && a.Units.ElementAt(position + 1).Hitpoints > 0)
                {
                    a.Units.Add((IUnit)tmp.Clone());
                    Debug.WriteLine("Клонирован юнит из армии(" + a.Mark + ") на позиции " + (position - 1) + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                }
            }
            else if (combatMode == 1)
            {
                int[] indexes = _engine.SpecialAbilityHelper(position);
                foreach (int t in indexes)
                {
                    if (t < 0 || t >= a.Units.Count) continue;
                    var tmp = a.Units.ElementAt(t) as ICloneable;
                    if (tmp != null && a.Units.ElementAt(t).Hitpoints > 0)
                    {
                        a.Units.Add((IUnit)tmp.Clone());
                        Debug.WriteLine("Клонирован юнит из армии(" + a.Mark + ") на позиции " + t + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                        return;
                    }
                }
            }

        }
    }
}
