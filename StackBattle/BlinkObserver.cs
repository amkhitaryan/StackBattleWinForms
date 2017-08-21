﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
