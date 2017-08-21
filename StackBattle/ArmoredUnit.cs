using System;
using System.Diagnostics;

namespace StackBattle
{
    /// <summary>
    /// Бронированный пехотинец
    /// </summary>
    [Serializable]
    class ArmoredUnit: HeavyUnit,  IUnit, ICanBeHealed, ICloneable
    {
        private Random _rnd;

        public ArmoredUnit(double hp = 15, int dmg = 6, int armor = 3, bool shield = false, bool pike = false,
            bool helmet = false, bool horse = false)
        {
            _hitpoints = hp;
            _damage = dmg;
            _armor = armor;
            Shield = shield;
            Pike = pike;
            Helmet = helmet;
            Horse = horse;
        }

        private double _hitpoints;
        private readonly int _damage;
        private readonly int _armor;

        public double Hitpoints
        {
            get { return _hitpoints; }
            set { _hitpoints = value > MaxHealth ? MaxHealth : value; }
        }
        public int MaxHealth => _MaxHealth;

        public int Damage
        {
            get
            {
                if (Pike && Horse)
                    return _damage + 2;
                if (Pike || Horse)
                    return _damage + 1;
                return _damage;
            }
        }
        public int Armor
        {
            get
            {
                if (Shield && Helmet && Horse)
                    return _armor + 3;
                if (Shield && Helmet || Shield && Horse || Horse && Helmet)
                    return _armor + 2;
                if (Shield || Helmet || Horse)
                    return _armor + 1;
                return _armor;
            }
        }
        public int Cost { get { return _cost; } set { } }

        private static readonly int _cost = 15;
        private const int _MaxHealth = 15;

        /// <summary>
        /// Уменьшает здоровье юнита
        /// </summary>
        /// <param name="dmg">Полученный урон здоровью</param>
        public void GetHit(double dmg)
        {
            _hitpoints -= dmg - (dmg * (5 * Armor) / 100);
            _rnd = new Random((int)DateTime.Now.Ticks);
            if (_rnd.Next(0, 4) == 1) //25% шанс
            {
                if (Pike)
                {
                    Pike = false;
                    Debug.WriteLine("*Копейщик выронил копье после удара*");
                    return;
                }
                if (Shield)
                {
                    Shield = false;
                    Debug.WriteLine("*Щитоносец лишился щита после удара*");
                    return;
                }
                if (Helmet)
                {
                    Helmet = false;
                    Debug.WriteLine("*Легионер лишился шлема после удара*");
                    return;
                }
                if (!Horse) return;
                Horse = false;
                Debug.WriteLine("*Рыцарь лишился лошади после удара*");
            }
        }

        public string GetUnitInfo()
        {
            string s = Horse ? "Рыцарь" : Helmet ? "Легионер" : Pike ? "Копейщик" : Shield ? "Щитоносец" : "Armored";
            return  "[" + s + $":hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";
        }

        public void GetHeal(int hp)
        {
            Hitpoints += hp;
        }

        public object Clone()
        {
            return new ArmoredUnit(this.Hitpoints, this.Damage, this.Armor, Shield, Pike, Helmet, Horse);
        }

        
    }
}
