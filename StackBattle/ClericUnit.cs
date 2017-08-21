using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StackBattle
{
    [Serializable]
    class ClericUnit : ISpecialAbility, IUnit, ICanBeHealed, ICloneable, IObservable
    {
        private Engine _engine = Engine.CreateInstance();
        private Random _rnd;
        private double _hitpoints;

        public double Hitpoints
        {
            get { return _hitpoints; }
            private set { _hitpoints = value > MaxHealth ? MaxHealth : value; }


        }
        public int MaxHealth => _MaxHealth;
        public int Damage { get; }
        public int Armor { get; }

        private List<IObserver> _observers = new List<IObserver>();
        public int Cost => _cost;

        private static readonly int _cost = 12;
        private const int _MaxHealth = 6;

        public ClericUnit(double hp = 6, int dmg = 2, int armor = 1)
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
            return $"[Cleric:hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";
        }

        public void DoSpecialAbility(Army a, Army b, int position, int combatMode)
        {
            _rnd = new Random((int)DateTime.Now.Ticks);
            if (_rnd.Next(0,5) != 3) return; //20% шанс

            if (combatMode == 0 || combatMode == 2)
            {
                var tmp = a.Units.ElementAt(position - 1) as ICanBeHealed;
                //Проверяем, что юнит лечится, что он не труп и, что у него не макс хп
                if (tmp != null && ((IUnit)tmp).Hitpoints > 0 && ((IUnit)tmp).Hitpoints < tmp.MaxHealth)
                {
                    Debug.Write("Вылечен юнит из армии(" + a.Mark + ") на позиции " + (position - 1) + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                    tmp.GetHeal(Damage + 1);
                    Debug.WriteLine(" => " + ((IUnit) tmp).GetUnitInfo());
                    return;
                }
                //Этот метод не будет вызван, если лекарь стоит на первой позиции(0), поэтому проверяем только верхнюю границу
                if (position == a.Units.Count - 1) return; 
                tmp = a.Units.ElementAt(position + 1) as ICanBeHealed;
                if (tmp != null && ((IUnit) tmp).Hitpoints > 0 && ((IUnit) tmp).Hitpoints < tmp.MaxHealth)
                {
                    Debug.Write("Вылечен юнит из армии(" + a.Mark + ") на позиции " + (position + 1) + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                    tmp.GetHeal(Damage + 1);
                    Debug.WriteLine(" => " + ((IUnit)tmp).GetUnitInfo());
                }
            }
            else if (combatMode == 1)
            {
                int[] indexes = _engine.SpecialAbilityHelper(position);
                foreach (int t in indexes)
                {
                    if(t < 0 || t >= a.Units.Count) continue;
                    var tmp = a.Units.ElementAt(t) as ICanBeHealed;
                    if (tmp != null && ((IUnit)tmp).Hitpoints > 0 && ((IUnit)tmp).Hitpoints < tmp.MaxHealth)
                    {
                        Debug.Write("Вылечен юнит из армии(" + a.Mark + ") на позиции " + t + " с позиции " + position + " " + ((IUnit)tmp).GetUnitInfo());
                        tmp.GetHeal(Damage + 1);
                        Debug.WriteLine(" => " + ((IUnit)tmp).GetUnitInfo());
                        return;
                    }
                }
            }
        }

        public void GetHeal(int hp)
        {
            Hitpoints += hp;
        }

        public object Clone()
        {
            return new ClericUnit(this.Hitpoints, this.Damage, this.Armor);
        }

        public void AddObserver(IObserver obs)
        {
            _observers.Add(obs);
        }

        public void RemoveObserver(IObserver obs)
        {
            _observers.RemoveAt(_observers.IndexOf(obs));
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
