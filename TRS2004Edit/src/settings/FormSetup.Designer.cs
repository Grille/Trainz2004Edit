namespace TRS2004Edit
{
    partial class FormSetup
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxFullscreen = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRes = new System.Windows.Forms.ComboBox();
            this.numericGround = new System.Windows.Forms.NumericUpDown();
            this.numericScenery = new System.Windows.Forms.NumericUpDown();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.numericUpDownFogGood = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFogBad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericParticles = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScenery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFogGood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFogBad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParticles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(197, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Draw Distance Scenery (km)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Draw Distance Ground (km)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Resulution";
            // 
            // checkBoxFullscreen
            // 
            this.checkBoxFullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFullscreen.Location = new System.Drawing.Point(157, 39);
            this.checkBoxFullscreen.Name = "checkBoxFullscreen";
            this.checkBoxFullscreen.Size = new System.Drawing.Size(115, 20);
            this.checkBoxFullscreen.TabIndex = 10;
            this.checkBoxFullscreen.UseVisualStyleBackColor = true;
            this.checkBoxFullscreen.CheckedChanged += new System.EventHandler(this.checkBoxFullscreen_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fullscreen";
            // 
            // comboBoxRes
            // 
            this.comboBoxRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRes.FormattingEnabled = true;
            this.comboBoxRes.Location = new System.Drawing.Point(157, 12);
            this.comboBoxRes.Name = "comboBoxRes";
            this.comboBoxRes.Size = new System.Drawing.Size(115, 21);
            this.comboBoxRes.TabIndex = 11;
            // 
            // numericGround
            // 
            this.numericGround.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericGround.DecimalPlaces = 3;
            this.numericGround.Location = new System.Drawing.Point(157, 65);
            this.numericGround.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericGround.Name = "numericGround";
            this.numericGround.Size = new System.Drawing.Size(115, 20);
            this.numericGround.TabIndex = 13;
            // 
            // numericScenery
            // 
            this.numericScenery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericScenery.DecimalPlaces = 3;
            this.numericScenery.Location = new System.Drawing.Point(157, 91);
            this.numericScenery.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericScenery.Name = "numericScenery";
            this.numericScenery.Size = new System.Drawing.Size(115, 20);
            this.numericScenery.TabIndex = 12;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(116, 196);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 14;
            this.buttonLoad.Text = "Reset";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // numericUpDownFogGood
            // 
            this.numericUpDownFogGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFogGood.DecimalPlaces = 3;
            this.numericUpDownFogGood.Location = new System.Drawing.Point(157, 117);
            this.numericUpDownFogGood.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFogGood.Name = "numericUpDownFogGood";
            this.numericUpDownFogGood.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownFogGood.TabIndex = 15;
            // 
            // numericUpDownFogBad
            // 
            this.numericUpDownFogBad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFogBad.DecimalPlaces = 3;
            this.numericUpDownFogBad.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFogBad.Location = new System.Drawing.Point(157, 143);
            this.numericUpDownFogBad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFogBad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFogBad.Name = "numericUpDownFogBad";
            this.numericUpDownFogBad.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownFogBad.TabIndex = 16;
            this.numericUpDownFogBad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Fog Distance (km)";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Weather Fog Multiplicator";
            // 
            // numericParticles
            // 
            this.numericParticles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericParticles.DecimalPlaces = 3;
            this.numericParticles.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericParticles.Location = new System.Drawing.Point(157, 169);
            this.numericParticles.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericParticles.Name = "numericParticles";
            this.numericParticles.Size = new System.Drawing.Size(115, 20);
            this.numericParticles.TabIndex = 19;
            this.numericParticles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Particles";
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 231);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericParticles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownFogBad);
            this.Controls.Add(this.numericUpDownFogGood);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.numericGround);
            this.Controls.Add(this.numericScenery);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxFullscreen);
            this.Controls.Add(this.comboBoxRes);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 270);
            this.Name = "FormSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRS0406 Tuner";
            this.Load += new System.EventHandler(this.FormSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericScenery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFogGood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFogBad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxFullscreen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRes;
        private System.Windows.Forms.NumericUpDown numericGround;
        private System.Windows.Forms.NumericUpDown numericScenery;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.NumericUpDown numericUpDownFogGood;
        private System.Windows.Forms.NumericUpDown numericUpDownFogBad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericParticles;
        private System.Windows.Forms.Label label7;
    }
}

