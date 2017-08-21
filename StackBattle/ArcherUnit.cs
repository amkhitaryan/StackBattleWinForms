using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Лучник
    /// </summary>
    [Serializable]
    class ArcherUnit : ISpecialAbility, IUnit , ICanBeHealed, ICloneable
    {
        private double _hitpoints;

        public double Hitpoints
        {
            get { return _hitpoints; }
            set { _hitpoints = value > MaxHealth ? MaxHealth : value; }
        }
        public int MaxHealth => _MaxHealth;

        public int Damage { get; }
        public int Armor { get; }
        public int Cost => _cost;

        /// <summary>
        /// Дальность стрельбы лучника(3-6)
        /// </summary>
        private readonly Tuple<int, int> _range = new Tuple<int, int>(4,6);

        private const int _cost = 15;
        private const int _MaxHealth = 8;

        private Random _rnd = new Random(DateTime.Now.Millisecond);


        public ArcherUnit(double hp = 8, int dmg = 2, int armor = 1)
        {
            _hitpoints = hp;
            Damage = dmg;
            Armor = armor;
        }
        public void GetHit(double dmg)
        {
            _hitpoints -= dmg - (dmg * (5 * Armor) / 100);
        }

        public string GetUnitInfo()
        {
            return $"[Archer:hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";
        }

        public void DoSpecialAbility(Army a, Army b, int position, int combatMode)
        {
            _rnd = new Random((int)DateTime.Now.Ticks);
            if (combatMode == 0)
            {
                var min = (_range.Item2 - position - _range.Item1) < 0 ? 0 : _range.Item2 - position - _range.Item1;
                var max = _range.Item2 - position;
                if (max <= 0 || max > b.Units.Count) return;
                var rnd = _rnd.Next(min, max);
                //if (b.Units.ElementAt(rnd) != null) 
                Debug.Write("Лучник из армии(" + a.Mark + ") атаковал юнита на позиции " + rnd + " с позиции " + position + " " + b.Units.ElementAt(rnd).GetUnitInfo());
                b.Units.ElementAt(rnd).GetHit(Damage);
                Debug.WriteLine(" => " + b.Units.ElementAt(rnd).GetUnitInfo());

            }
            else if (combatMode == 1)
            {
                var min = (_range.Item2 - (position / 3) * 3) < 0 ? 0 : _range.Item2 - (position / 3) * 3;
                //var max = -(position / 6 * 3) + (_range.Item2 - 1) * 3;
                var max = _range.Item2 * 3 - position / 3 * 3 > b.Units.Count
                    ? b.Units.Count
                    : _range.Item2 * 3 - position / 3 * 3;
                //max = max > b.Units.Count ? b.Units.Count : max;
                if (max < 0 || min >= b.Units.Count) return;
                var rnd = _rnd.Next(min, max);
                //if (b.Units.ElementAt(rnd) != null)
                Debug.Write("Лучник из армии(" + a.Mark + ") атаковал юнита на позиции " + rnd + " с позиции " + position + " " + b.Units.ElementAt(rnd).GetUnitInfo());
                b.Units.ElementAt(rnd).GetHit(Damage);
                Debug.WriteLine(" => " + b.Units.ElementAt(rnd).GetUnitInfo());
            }
            else if (combatMode == 2)
            {
                var min = (position - _range.Item2 + 1) < 0 ? 0 : position - _range.Item2 + 1;
                var max = (position - 1) > b.Units.Count ? b.Units.Count - 1 : position - 1;
                if (max < 0 || min >=b.Units.Count) return;
                var rnd = _rnd.Next(min, max);
                //if (b.Units.ElementAt(rnd) != null) 
                Debug.Write("Лучник из армии(" + a.Mark + ") атаковал юнита на позиции " + rnd + " с позиции " + position + " " + b.Units.ElementAt(rnd).GetUnitInfo());
                b.Units.ElementAt(rnd).GetHit(Damage);
                Debug.WriteLine(" => " + b.Units.ElementAt(rnd).GetUnitInfo());
            }

        }

        public void GetHeal(int hp)
        {
            Hitpoints += hp;
        }

        public object Clone()
        {
            return new ArcherUnit(this.Hitpoints, this.Damage, this.Armor);
        }

        
    }
}
