using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StackBattle
{
    /// <summary>
    /// Движок игры, к нему применен паттерн Одиночка
    /// </summary>
    [Serializable]
    sealed class Engine
    {
        private static readonly List<IStrategy> CombatMode = new List<IStrategy>()
        {
            new Strategy1vs1(),
            new Strategy3vs3(),
            new StrategyAllvsAll()
        };

        private static readonly Engine _engine = new Engine();
        
        private Engine() { }

        private static void Attack(Army a, Army b, int combatMode)
        {
            CombatMode.ElementAt(combatMode).Combat(a,b); //Применение стратегии

            //Очищаем поле боя от трупов после очередного хода
            for (var i = 0; i < Math.Max(a.Units.Count,b.Units.Count); i++)
            {
                if (i < a.Units.Count && a.Units.ElementAt(i).Hitpoints <= 0)
                {
                    Debug.WriteLine("Умер юнит из армии(" + a.Mark + ") на позиции " + i + " " + a.Units.ElementAt(i).GetUnitInfo());
                    var cleric = a.Units.ElementAt(i) as ClericUnit;
                    cleric?.NotifyObservers();
                    a.Units.RemoveAt(i);
                }
                if (i < b.Units.Count && b.Units.ElementAt(i).Hitpoints <= 0)
                {
                    Debug.WriteLine("Умер юнит из армии(" + b.Mark + ") на позиции " + i + " " + b.Units.ElementAt(i).GetUnitInfo());
                    var cleric = b.Units.ElementAt(i) as ClericUnit;
                    cleric?.NotifyObservers();
                    b.Units.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Метод для расчета индексов для применения специального действия для некоторых юнитов
        /// </summary>
        /// <param name="position">Индекс действующего юнита</param>
        /// <returns>Массив индексов</returns>
        public int[] SpecialAbilityHelper(int position)
        {
            int[] indexes = new int[4];
            indexes[0] = position - 3;
            indexes[1] = position / 3 == (position - 1) / 3 ? position - 1 : -1;
            indexes[2] = position / 3 == (position + 1) / 3 ? position + 1 : -1;
            indexes[3] = position + 3;
            return indexes;
        }

        /// <summary>
        /// Осуществляет ход
        /// </summary>
        /// <param name="a">Первая армия</param>
        /// <param name="b">Вторая армия</param>
        /// <param name="combatMode">Стратегия боя</param>
        public void NextTurn(Army a, Army b, int combatMode)
        {
            Attack(a,b, combatMode);
        }

        public static Engine CreateInstance()
        {
            return _engine;
        }

    }
}
