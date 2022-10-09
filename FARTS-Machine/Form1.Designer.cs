namespace FARTS_Machine
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Attach = new System.Windows.Forms.Button();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Randomizer = new System.Windows.Forms.Button();
            this.buttonStopRandomizer = new System.Windows.Forms.Button();
            this.timerWarmup = new System.Windows.Forms.Timer(this.components);
            this.timerRandomizer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCurrentEffect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.checkBoxSuperJump = new System.Windows.Forms.CheckBox();
            this.checkBoxNoDamage = new System.Windows.Forms.CheckBox();
            this.checkBoxInfiniteAmmo = new System.Windows.Forms.CheckBox();
            this.labelHelpers = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Attach
            // 
            this.button_Attach.Location = new System.Drawing.Point(12, 12);
            this.button_Attach.Name = "button_Attach";
            this.button_Attach.Size = new System.Drawing.Size(143, 34);
            this.button_Attach.TabIndex = 0;
            this.button_Attach.Text = "Attach to Game";
            this.button_Attach.UseVisualStyleBackColor = true;
            this.button_Attach.Click += new System.EventHandler(this.button_Attach_Click);
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(289, 12);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(387, 20);
            this.textBox_Status.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Created by HuhnerSpeed";
            // 
            // button_Randomizer
            // 
            this.button_Randomizer.Enabled = false;
            this.button_Randomizer.Location = new System.Drawing.Point(12, 126);
            this.button_Randomizer.Name = "button_Randomizer";
            this.button_Randomizer.Size = new System.Drawing.Size(143, 34);
            this.button_Randomizer.TabIndex = 4;
            this.button_Randomizer.Text = "Start Randomizer";
            this.button_Randomizer.UseVisualStyleBackColor = true;
            this.button_Randomizer.Click += new System.EventHandler(this.button_Randomizer_Click);
            // 
            // buttonStopRandomizer
            // 
            this.buttonStopRandomizer.Enabled = false;
            this.buttonStopRandomizer.Location = new System.Drawing.Point(12, 166);
            this.buttonStopRandomizer.Name = "buttonStopRandomizer";
            this.buttonStopRandomizer.Size = new System.Drawing.Size(143, 34);
            this.buttonStopRandomizer.TabIndex = 5;
            this.buttonStopRandomizer.Text = "Stop Randomizer";
            this.buttonStopRandomizer.UseVisualStyleBackColor = true;
            this.buttonStopRandomizer.Click += new System.EventHandler(this.buttonStopRandomizer_Click);
            // 
            // timerWarmup
            // 
            this.timerWarmup.Interval = 1000;
            this.timerWarmup.Tick += new System.EventHandler(this.timerWarmup_Tick);
            // 
            // timerRandomizer
            // 
            this.timerRandomizer.Interval = 1000;
            this.timerRandomizer.Tick += new System.EventHandler(this.timerRandomizer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(286, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Effect:";
            // 
            // textBoxCurrentEffect
            // 
            this.textBoxCurrentEffect.Location = new System.Drawing.Point(289, 454);
            this.textBoxCurrentEffect.Name = "textBoxCurrentEffect";
            this.textBoxCurrentEffect.Size = new System.Drawing.Size(387, 20);
            this.textBoxCurrentEffect.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(700, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Duration:";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(703, 454);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(47, 20);
            this.textBoxDuration.TabIndex = 9;
            // 
            // checkBoxSuperJump
            // 
            this.checkBoxSuperJump.AutoSize = true;
            this.checkBoxSuperJump.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxSuperJump.Location = new System.Drawing.Point(12, 316);
            this.checkBoxSuperJump.Name = "checkBoxSuperJump";
            this.checkBoxSuperJump.Size = new System.Drawing.Size(82, 17);
            this.checkBoxSuperJump.TabIndex = 10;
            this.checkBoxSuperJump.Text = "Super Jump";
            this.checkBoxSuperJump.UseVisualStyleBackColor = true;
            this.checkBoxSuperJump.Visible = false;
            this.checkBoxSuperJump.CheckedChanged += new System.EventHandler(this.checkBoxSuperJump_CheckedChanged);
            // 
            // checkBoxNoDamage
            // 
            this.checkBoxNoDamage.AutoSize = true;
            this.checkBoxNoDamage.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxNoDamage.Location = new System.Drawing.Point(12, 339);
            this.checkBoxNoDamage.Name = "checkBoxNoDamage";
            this.checkBoxNoDamage.Size = new System.Drawing.Size(77, 17);
            this.checkBoxNoDamage.TabIndex = 11;
            this.checkBoxNoDamage.Text = "Invincibility";
            this.checkBoxNoDamage.UseVisualStyleBackColor = true;
            this.checkBoxNoDamage.Visible = false;
            this.checkBoxNoDamage.CheckedChanged += new System.EventHandler(this.checkBoxNoDamage_CheckedChanged);
            // 
            // checkBoxInfiniteAmmo
            // 
            this.checkBoxInfiniteAmmo.AutoSize = true;
            this.checkBoxInfiniteAmmo.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBoxInfiniteAmmo.Location = new System.Drawing.Point(12, 362);
            this.checkBoxInfiniteAmmo.Name = "checkBoxInfiniteAmmo";
            this.checkBoxInfiniteAmmo.Size = new System.Drawing.Size(89, 17);
            this.checkBoxInfiniteAmmo.TabIndex = 12;
            this.checkBoxInfiniteAmmo.Text = "Infinite Ammo";
            this.checkBoxInfiniteAmmo.UseVisualStyleBackColor = true;
            this.checkBoxInfiniteAmmo.Visible = false;
            this.checkBoxInfiniteAmmo.CheckedChanged += new System.EventHandler(this.checkBoxInfiniteAmmo_CheckedChanged);
            // 
            // labelHelpers
            // 
            this.labelHelpers.AutoSize = true;
            this.labelHelpers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpers.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHelpers.Location = new System.Drawing.Point(8, 280);
            this.labelHelpers.Name = "labelHelpers";
            this.labelHelpers.Size = new System.Drawing.Size(178, 24);
            this.labelHelpers.TabIndex = 13;
            this.labelHelpers.Text = "Strat-Finder Helpers";
            this.labelHelpers.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(832, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(143, 34);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(987, 499);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelHelpers);
            this.Controls.Add(this.checkBoxInfiniteAmmo);
            this.Controls.Add(this.checkBoxNoDamage);
            this.Controls.Add(this.checkBoxSuperJump);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCurrentEffect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStopRandomizer);
            this.Controls.Add(this.button_Randomizer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.button_Attach);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "F.A.R.T.S. Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Attach;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Randomizer;
        private System.Windows.Forms.Button buttonStopRandomizer;
        private System.Windows.Forms.Timer timerWarmup;
        private System.Windows.Forms.Timer timerRandomizer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCurrentEffect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.CheckBox checkBoxSuperJump;
        private System.Windows.Forms.CheckBox checkBoxNoDamage;
        private System.Windows.Forms.CheckBox checkBoxInfiniteAmmo;
        private System.Windows.Forms.Label labelHelpers;
        private System.Windows.Forms.Button buttonClose;
    }
}

