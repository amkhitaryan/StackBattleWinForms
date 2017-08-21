using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    /// <summary>
    /// Прокси для логирования
    /// </summary>
    [Serializable]
    class Proxy : Subject
    {
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProxyLog.txt";

        private MageUnit _realSubject;
        private Random _rnd;

        public Proxy(MageUnit realSubject)
        {
            if(realSubject != null)
                _realSubject = realSubject;
        }

        private static async Task WriteTxt(string path, string text, bool newLine)
        {
            using (StreamWriter sw = new StreamWriter(path, true,Encoding.UTF8))
            {
                Task writeTask = newLine
                    ? sw.WriteLineAsync(text.ToCharArray(), 0, text.Length)
                    : sw.WriteAsync(text.ToCharArray(), 0, text.Length);
                await writeTask;
            }
        }

        public override async void GetHit(double dmg)
        {
                CheckNull();
            await WriteTxt(_path, _realSubject.GetUnitInfo() + " получил урон(" + dmg + ")", false);
                _realSubject.GetHit(dmg);
            await WriteTxt(_path, " => " + _realSubject.GetUnitInfo(), true);
        }

        public override string GetUnitInfo()
        {
            CheckNull();
            return _realSubject.GetUnitInfo();
        }

        private void CheckNull()
        {
            if (_realSubject == null)
                _realSubject = new MageUnit();
        }

        public override double Hitpoints
        {
            get { return _realSubject.Hitpoints; }
            protected set { _realSubject._hitpoints = value; }
        }
        public override int MaxHealth => _realSubject.MaxHealth;

        public override int Damage
        {
            get { return _realSubject.Damage; }
            protected set { _realSubject._damage = value; }
        }

        public override int Cost => _realSubject.Cost;

        public override async void GetHeal(int hp)
        {
            await WriteTxt(_path, _realSubject.GetUnitInfo() + " был вылечен на " + hp + "hp", false);
            _realSubject.GetHeal(hp);
            await WriteTxt(_path, " => " + _realSubject.GetUnitInfo(), true);
        }

        public override async void DoSpecialAbility(Army a, Army b, int position, int combatMode)
        {
            _rnd = new Random((int)DateTime.Now.Ticks);
            if (_rnd.Next(0, 10) != 3) return; //10% шанс
            await WriteTxt(_path,
                _realSubject.GetUnitInfo() + " клонирует юнита из армии " + a.Mark + " с позиции " + position, true);
            _realSubject.DoSpecialAbility(a, b, position, combatMode);
        }

        
    }
}
