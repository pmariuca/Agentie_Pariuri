namespace Agentie_Pariuri
{
    partial class Form9
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPersoane = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Persoane";
            // 
            // lbPersoane
            // 
            this.lbPersoane.BackColor = System.Drawing.Color.MistyRose;
            this.lbPersoane.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersoane.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lbPersoane.FormattingEnabled = true;
            this.lbPersoane.ItemHeight = 22;
            this.lbPersoane.Location = new System.Drawing.Point(47, 72);
            this.lbPersoane.Name = "lbPersoane";
            this.lbPersoane.Size = new System.Drawing.Size(710, 356);
            this.lbPersoane.TabIndex = 1;
            this.lbPersoane.SelectedIndexChanged += new System.EventHandler(this.lbPersoane_SelectedIndexChanged);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Agentie_Pariuri.Properties.Resources.dd81a2c2c6c2e718557c23fc757ad428;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbPersoane);
            this.Controls.Add(this.label1);
            this.Name = "Form9";
            this.Text = "Form9";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPersoane;
    }
}