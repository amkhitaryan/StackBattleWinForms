using System;
using System.Collections.Generic;

namespace StackBattle
{
    [Serializable]
    public class Army
    {
        public List<IUnit> Units = new List<IUnit>();
        /// <summary>
        /// Список конкретных фабрик для реализации паттерна Фабричный метод
        /// </summary>
        private readonly List<IFactory> _concreteFactories = new List<IFactory>()
        {
            new InfantryUnitFactory(),
            new ArmoredUnitFactory(),
            new ClericUnitFactory(),
            new ArcherUnitFactory(),
            new MageUnitFactory(),
            new GulyayGorodFactory()
        };

        public int TotalCost;
        public char Mark;
        /// <summary>
        /// Создает армию
        /// </summary>
        /// <param name="cost">Стоимость армии</param>
        public void CreateArmy(int cost)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            Units.Clear();
            TotalCost = 0; // общая стоимость армии
            
            while (TotalCost < cost - 5)
            {
                IUnit a = _concreteFactories[rnd.Next(0, _concreteFactories.Count)].CreateUnit(); // Использование фабричного метода
                TotalCost += a.Cost;
                Units.Add(a);
            }
        }

        public Army ChangeState(Army stateToChange)
        {
            return StackBattle.DeepClone.DoDeepClone(stateToChange);
        }

        public override string ToString()
        {
            return "Стоимость армии: " + TotalCost + "\nКоличество юнитов: " + Units.Count;
        }
    }
}
