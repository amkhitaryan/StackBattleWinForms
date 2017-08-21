using System;
using System.Drawing;
using System.Windows.Forms;

namespace StackBattle
{
    [Serializable]
    class BlinkObserver : IObserver
    {
        public void Update()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            if (Form.ActiveForm != null)
                Form.ActiveForm.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255),
                    rnd.Next(0, 255));
        }
    }
}
