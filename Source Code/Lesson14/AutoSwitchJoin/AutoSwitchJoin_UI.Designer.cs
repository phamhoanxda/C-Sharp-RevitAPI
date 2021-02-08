
namespace Pch
{
    partial class AutoSwitchJoin_UI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Component1 = new System.Windows.Forms.Label();
            this.Component2 = new System.Windows.Forms.Label();
            this.comboBoxA = new System.Windows.Forms.ComboBox();
            this.comboBoxB = new System.Windows.Forms.ComboBox();
            this.AutoJoin = new System.Windows.Forms.RadioButton();
            this.AutoUnJoin = new System.Windows.Forms.RadioButton();
            this.SwitchJoin = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Component1
            // 
            this.Component1.AutoSize = true;
            this.Component1.Location = new System.Drawing.Point(9, 27);
            this.Component1.Name = "Component1";
            this.Component1.Size = new System.Drawing.Size(67, 13);
            this.Component1.TabIndex = 2;
            this.Component1.Text = "Component1";
            this.Component1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Component2
            // 
            this.Component2.AutoSize = true;
            this.Component2.Location = new System.Drawing.Point(155, 27);
            this.Component2.Name = "Component2";
            this.Component2.Size = new System.Drawing.Size(67, 13);
            this.Component2.TabIndex = 3;
            this.Component2.Text = "Component2";
            this.Component2.Click += new System.EventHandler(this.Component2_Click);
            // 
            // comboBoxA
            // 
            this.comboBoxA.FormattingEnabled = true;
            this.comboBoxA.Location = new System.Drawing.Point(12, 52);
            this.comboBoxA.Name = "comboBoxA";
            this.comboBoxA.Size = new System.Drawing.Size(93, 21);
            this.comboBoxA.TabIndex = 4;
            // 
            // comboBoxB
            // 
            this.comboBoxB.FormattingEnabled = true;
            this.comboBoxB.Location = new System.Drawing.Point(158, 52);
            this.comboBoxB.Name = "comboBoxB";
            this.comboBoxB.Size = new System.Drawing.Size(93, 21);
            this.comboBoxB.TabIndex = 5;
            // 
            // AutoJoin
            // 
            this.AutoJoin.AutoSize = true;
            this.AutoJoin.Location = new System.Drawing.Point(12, 110);
            this.AutoJoin.Name = "AutoJoin";
            this.AutoJoin.Size = new System.Drawing.Size(66, 17);
            this.AutoJoin.TabIndex = 6;
            this.AutoJoin.TabStop = true;
            this.AutoJoin.Text = "AutoJoin";
            this.AutoJoin.UseVisualStyleBackColor = true;
            // 
            // AutoUnJoin
            // 
            this.AutoUnJoin.AutoSize = true;
            this.AutoUnJoin.Location = new System.Drawing.Point(12, 134);
            this.AutoUnJoin.Name = "AutoUnJoin";
            this.AutoUnJoin.Size = new System.Drawing.Size(80, 17);
            this.AutoUnJoin.TabIndex = 7;
            this.AutoUnJoin.TabStop = true;
            this.AutoUnJoin.Text = "AutoUnJoin";
            this.AutoUnJoin.UseVisualStyleBackColor = true;
            // 
            // SwitchJoin
            // 
            this.SwitchJoin.AutoSize = true;
            this.SwitchJoin.Location = new System.Drawing.Point(158, 110);
            this.SwitchJoin.Name = "SwitchJoin";
            this.SwitchJoin.Size = new System.Drawing.Size(76, 17);
            this.SwitchJoin.TabIndex = 8;
            this.SwitchJoin.TabStop = true;
            this.SwitchJoin.Text = "SwitchJoin";
            this.SwitchJoin.UseVisualStyleBackColor = true;
            // 
            // AutoSwitchJoin_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(315, 189);
            this.Controls.Add(this.SwitchJoin);
            this.Controls.Add(this.AutoUnJoin);
            this.Controls.Add(this.AutoJoin);
            this.Controls.Add(this.comboBoxB);
            this.Controls.Add(this.comboBoxA);
            this.Controls.Add(this.Component2);
            this.Controls.Add(this.Component1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "AutoSwitchJoin_UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoSwitchJoin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Component1;
        private System.Windows.Forms.Label Component2;
        private System.Windows.Forms.ComboBox comboBoxA;
        private System.Windows.Forms.ComboBox comboBoxB;
        private System.Windows.Forms.RadioButton AutoJoin;
        private System.Windows.Forms.RadioButton AutoUnJoin;
        private System.Windows.Forms.RadioButton SwitchJoin;
    }
}