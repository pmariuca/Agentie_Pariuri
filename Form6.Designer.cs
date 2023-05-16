namespace Agentie_Pariuri
{
    partial class Form6
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
            this.lbPariuri = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(314, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pariuri";
            // 
            // lbPariuri
            // 
            this.lbPariuri.BackColor = System.Drawing.Color.MistyRose;
            this.lbPariuri.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPariuri.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lbPariuri.FormattingEnabled = true;
            this.lbPariuri.HorizontalScrollbar = true;
            this.lbPariuri.ItemHeight = 22;
            this.lbPariuri.Location = new System.Drawing.Point(45, 72);
            this.lbPariuri.Name = "lbPariuri";
            this.lbPariuri.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPariuri.Size = new System.Drawing.Size(702, 356);
            this.lbPariuri.TabIndex = 1;
            this.lbPariuri.SelectedIndexChanged += new System.EventHandler(this.lbPariuri_SelectedIndexChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Agentie_Pariuri.Properties.Resources.ff6cee218b0fbbb046082285824941eb;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbPariuri);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPariuri;
    }
}