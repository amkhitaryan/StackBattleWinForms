namespace StackBattle
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateArmy = new System.Windows.Forms.Button();
            this.btnShowArmy = new System.Windows.Forms.Button();
            this.btnNextTurn = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbFirstArmy = new System.Windows.Forms.Label();
            this.lbSecondArmy = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbShowAttack = new System.Windows.Forms.Label();
            this.lbA = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateArmy
            // 
            this.btnCreateArmy.Location = new System.Drawing.Point(18, 546);
            this.btnCreateArmy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateArmy.Name = "btnCreateArmy";
            this.btnCreateArmy.Size = new System.Drawing.Size(152, 54);
            this.btnCreateArmy.TabIndex = 0;
            this.btnCreateArmy.Text = "Создать армию";
            this.btnCreateArmy.UseVisualStyleBackColor = true;
            this.btnCreateArmy.Click += new System.EventHandler(this.btnCreateArmy_Click);
            // 
            // btnShowArmy
            // 
            this.btnShowArmy.Location = new System.Drawing.Point(178, 546);
            this.btnShowArmy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowArmy.Name = "btnShowArmy";
            this.btnShowArmy.Size = new System.Drawing.Size(152, 54);
            this.btnShowArmy.TabIndex = 1;
            this.btnShowArmy.Text = "Показать армию";
            this.btnShowArmy.UseVisualStyleBackColor = true;
            this.btnShowArmy.Click += new System.EventHandler(this.btnShowArmy_Click);
            // 
            // btnNextTurn
            // 
            this.btnNextTurn.Location = new System.Drawing.Point(339, 546);
            this.btnNextTurn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNextTurn.Name = "btnNextTurn";
            this.btnNextTurn.Size = new System.Drawing.Size(152, 54);
            this.btnNextTurn.TabIndex = 2;
            this.btnNextTurn.Text = "Следующий ход";
            this.btnNextTurn.UseVisualStyleBackColor = true;
            this.btnNextTurn.Click += new System.EventHandler(this.btnNextTurn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(678, 546);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 54);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbFirstArmy
            // 
            this.lbFirstArmy.AutoSize = true;
            this.lbFirstArmy.Location = new System.Drawing.Point(18, 89);
            this.lbFirstArmy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFirstArmy.Name = "lbFirstArmy";
            this.lbFirstArmy.Size = new System.Drawing.Size(0, 20);
            this.lbFirstArmy.TabIndex = 2;
            // 
            // lbSecondArmy
            // 
            this.lbSecondArmy.AutoSize = true;
            this.lbSecondArmy.Location = new System.Drawing.Point(566, 89);
            this.lbSecondArmy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSecondArmy.Name = "lbSecondArmy";
            this.lbSecondArmy.Size = new System.Drawing.Size(0, 20);
            this.lbSecondArmy.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(500, 546);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 54);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Сбросить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbShowAttack
            // 
            this.lbShowAttack.AutoSize = true;
            this.lbShowAttack.Location = new System.Drawing.Point(208, 388);
            this.lbShowAttack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbShowAttack.Name = "lbShowAttack";
            this.lbShowAttack.Size = new System.Drawing.Size(0, 20);
            this.lbShowAttack.TabIndex = 4;
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(18, 37);
            this.lbA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(73, 20);
            this.lbA.TabIndex = 5;
            this.lbA.Text = "Армия А";
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Location = new System.Drawing.Point(566, 37);
            this.lbB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(73, 20);
            this.lbB.TabIndex = 5;
            this.lbB.Text = "Армия B";
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(789, 34);
            this.rb1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(106, 24);
            this.rb1.TabIndex = 7;
            this.rb1.Text = "1 versus 1";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.Click += new System.EventHandler(this.rb_Click);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(789, 71);
            this.rb2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(106, 24);
            this.rb2.TabIndex = 8;
            this.rb2.Text = "3 versus 3";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.Click += new System.EventHandler(this.rb_Click);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(789, 108);
            this.rb3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(118, 24);
            this.rb3.TabIndex = 9;
            this.rb3.Text = "all versus all";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.Click += new System.EventHandler(this.rb_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(771, 180);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 53);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Location = new System.Drawing.Point(852, 180);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 53);
            this.btnRedo.TabIndex = 5;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 618);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.lbB);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.lbShowAttack);
            this.Controls.Add(this.lbSecondArmy);
            this.Controls.Add(this.lbFirstArmy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnNextTurn);
            this.Controls.Add(this.btnShowArmy);
            this.Controls.Add(this.btnCreateArmy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стековые войны";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateArmy;
        private System.Windows.Forms.Button btnShowArmy;
        private System.Windows.Forms.Button btnNextTurn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbFirstArmy;
        private System.Windows.Forms.Label lbSecondArmy;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbShowAttack;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
    }
}

