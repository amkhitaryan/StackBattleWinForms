using System;

namespace StackBattle
{

    public interface IUnit
    {
        /// <summary>
        /// Здоровье
        /// </summary>
        double Hitpoints { get;}
        /// <summary>
        /// Урон
        /// </summary>
        int Damage { get;}
        /// <summary>
        /// Броня
        /// </summary>
        //int Armor { get; }
        /// <summary>
        /// Стоимость
        /// </summary>
        int Cost { get;}
        
        void GetHit(double dmg);

        string GetUnitInfo();
    }
}
