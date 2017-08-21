using System;
using SpecialUnits;

namespace StackBattle
{
    /// <summary>
    /// Класс для реализации структурного паттерна Адаптер
    /// </summary>
    [Serializable]
    class Adapter : IUnit
    {
        /// <summary>
        /// Адаптируемый объект
        /// </summary>
        private GulyayGorod _gG;

        public Adapter(GulyayGorod gG)
        {
            _gG = gG;
        } 

        public double Hitpoints => _gG.GetCurrentHealth();
        public int Damage => _gG.GetStrength();
        public int Armor => _gG.GetDefence();
        public int Cost => _gG.GetCost();

        public void GetHit(double dmg)
        {
            _gG.TakeDamage((int)dmg);
        }

        public string GetUnitInfo()
        {
            return $"[Wall:hp({Hitpoints}), dmg({Damage}), armor({Armor}), cost({Cost})]";
        }
    }
}
