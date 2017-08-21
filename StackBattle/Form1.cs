using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace StackBattle
{
    public partial class Form1 : Form
    {
        private static Random _rnd = new Random(DateTime.Now.Millisecond);

        private static bool _armyNumber = false;

        private int _combatMode;

        private readonly Engine _engine = Engine.CreateInstance();

        private Army _a = new Army();

        private Army _b = new Army();

        private readonly List<IObserver> _obervers = new List<IObserver>()
        {
            new BeepObserver(),
            new BlinkObserver(),
            new DeathLogObserver()
        };

        private Invoker _invoker;

        public Form1()
        {
            InitializeComponent();
            _a.Mark = 'A';
            _b.Mark = 'B';
            _invoker = new Invoker();
        }

        private void Subscribe(List<IUnit> units)
        {
            foreach (var unit in units)
            {
                var clericUnit = unit as ClericUnit;
                if (clericUnit == null) continue;
                foreach (var observer in _obervers)
                {
                    clericUnit.AddObserver(observer);
                }
            }
        }

        /// <summary>
        /// Показывает нанесенный урон одним юнитом другому
        /// </summary>
        /// <param name="a">Из какой армии атакующий юнит(А или В)</param>
        private string ShowAttack(char a)
        {
            return a == 'A'
                ? "Юнит из армии А нанес урон юниту из армии B"
                : "Юнит из армии B нанес урон юниту из армии A";
        }

        private bool CheckForWin()
        {
            if (_a.Units.Count == 0 && _b.Units.Count == 0) return true;
            if (_a.Units.Count == 0)
                lbShowAttack.Text = "Армия B победила";
            if (_b.Units.Count == 0)
                lbShowAttack.Text = "Армия A победила";
            return _a.Units.Count <= 0 || _b.Units.Count <= 0;

        }

        private void ShowStats()
        {
            lbFirstArmy.Text = _a.ToString();
            lbSecondArmy.Text = _b.ToString();
            btnRedo.Enabled = _invoker._commandsRedo.Count > 0;
            btnUndo.Enabled = _invoker._commandsUndo.Count > 0;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Вы действительно хотите зыкрыть приложение?",
                "Закрыть.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
                this.Close();
        }

        private void btnCreateArmy_Click(object sender, EventArgs e)
        {
            lbShowAttack.Text = "";
            if (!_armyNumber)
            {
                _armyNumber = !_armyNumber;
                _a.CreateArmy(150);
                lbFirstArmy.Text = "Первая армия создана";
                Subscribe(_a.Units);
                _invoker = new Invoker();

            }
            else
            {
                _armyNumber = !_armyNumber;
                _b.CreateArmy(150);
                lbSecondArmy.Text = "Вторая армия создана";
                Subscribe(_b.Units);
                _invoker = new Invoker();
            }
        }

        private void btnShowArmy_Click(object sender, EventArgs e)
        {
            ShowStats();
        }

        private void btnNextTurn_Click(object sender, EventArgs e)
        {
            _invoker.AddCommand(new NextTurnCommand(StackBattle.DeepClone.DoDeepClone(_a),
                StackBattle.DeepClone.DoDeepClone(_b)));
            _invoker.ClearRedo();
            btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            Debug.WriteLine("_ _ _");
            if (CheckForWin()) return; // Если есть победитель - ничего не делаем
            int aCounter = _a.Units.Count;
            int bCounter = _b.Units.Count;
            _rnd = new Random(DateTime.Now.Millisecond);
            lbShowAttack.Text = "";
            if (_rnd.Next(1, 3) == 1)
            {
                lbShowAttack.Text += ShowAttack('A') + "\n";
                _engine.NextTurn(_a, _b, _combatMode);
                if (_b.Units.Count < bCounter) lbShowAttack.Text += "Юнит из армии B погиб";
                else
                {
                    lbShowAttack.Text += "В ответ " + ShowAttack('B') + "\n";
                    if (_a.Units.Count < aCounter) lbShowAttack.Text += "Юнит из армии A погиб";
                }
            }
            else
            {
                lbShowAttack.Text += ShowAttack('B') + "\n";
                _engine.NextTurn(_b, _a, _combatMode);
                if (_a.Units.Count < aCounter) lbShowAttack.Text += "Юнит из армии A погиб";
                else
                {
                    lbShowAttack.Text += "В ответ " + ShowAttack('A') + "\n";
                    if (_b.Units.Count < bCounter) lbShowAttack.Text += "Юнит из армии B погиб";
                }
            }
            ShowStats();
            CheckForWin();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lbShowAttack.Text = lbFirstArmy.Text = lbSecondArmy.Text = "";
            _a.Units.Clear();
            _b.Units.Clear();
            btnUndo.Enabled = btnRedo.Enabled = false;

        }

        private void rb_Click(object sender, EventArgs e)
        {
            _combatMode = rb1.Checked ? 0 : rb2.Checked ? 1 : 2;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            lbShowAttack.Text = "";
            var a =_invoker.Undo( _a, _b);
            if (a == null)
            {
                btnUndo.Enabled = false;
                return;
            }
            _a = a.Item1;
            _b = a.Item2;
            ShowStats();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            lbShowAttack.Text = "";
            var a = _invoker.Redo(_a, _b);
            _a = a.Item1;
            _b = a.Item2;
            ShowStats();
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T) formatter.Deserialize(ms);
            }
        }
    }
}
