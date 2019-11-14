namespace TRS2004Edit
{
    partial class FormContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContent));
            this.trainzButton1 = new TRS2004Edit.TrainzButton();
            this.trainzButton2 = new TRS2004Edit.TrainzButton();
            this.SuspendLayout();
            // 
            // trainzButton1
            // 
            this.trainzButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainzButton1.BackColor = System.Drawing.Color.Transparent;
            this.trainzButton1.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 18F);
            this.trainzButton1.Location = new System.Drawing.Point(476, 539);
            this.trainzButton1.Margin = new System.Windows.Forms.Padding(4);
            this.trainzButton1.MaximumSize = new System.Drawing.Size(512, 32);
            this.trainzButton1.MinimumSize = new System.Drawing.Size(32, 32);
            this.trainzButton1.Name = "trainzButton1";
            this.trainzButton1.Size = new System.Drawing.Size(172, 32);
            this.trainzButton1.TabIndex = 2;
            this.trainzButton1.Text = "Beenden";
            this.trainzButton1.Click += new System.EventHandler(this.trainzButtonClose_Click);
            // 
            // trainzButton2
            // 
            this.trainzButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainzButton2.BackColor = System.Drawing.Color.Transparent;
            this.trainzButton2.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 18F);
            this.trainzButton2.Location = new System.Drawing.Point(476, 499);
            this.trainzButton2.Margin = new System.Windows.Forms.Padding(4);
            this.trainzButton2.MaximumSize = new System.Drawing.Size(512, 32);
            this.trainzButton2.MinimumSize = new System.Drawing.Size(32, 32);
            this.trainzButton2.Name = "trainzButton2";
            this.trainzButton2.Size = new System.Drawing.Size(172, 32);
            this.trainzButton2.TabIndex = 3;
            this.trainzButton2.Text = "Kopiren";
            // 
            // FormContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TRS2004Edit.Properties.Resources.readmeback;
            this.ClientSize = new System.Drawing.Size(661, 584);
            this.Controls.Add(this.trainzButton2);
            this.Controls.Add(this.trainzButton1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormContent";
            this.Text = "TRS2004 Content Manager";
            this.ResumeLayout(false);

        }

        #endregion
        private TrainzButton trainzButton1;
        private TrainzButton trainzButton2;
    }
}