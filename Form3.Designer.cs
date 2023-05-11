namespace Agentie_Pariuri
{
    partial class Form3
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
            this.listBoxMeciuri = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(321, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meciuri disponibile";
            // 
            // listBoxMeciuri
            // 
            this.listBoxMeciuri.BackColor = System.Drawing.Color.MistyRose;
            this.listBoxMeciuri.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMeciuri.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.listBoxMeciuri.FormattingEnabled = true;
            this.listBoxMeciuri.ItemHeight = 20;
            this.listBoxMeciuri.Location = new System.Drawing.Point(40, 94);
            this.listBoxMeciuri.Name = "listBoxMeciuri";
            this.listBoxMeciuri.Size = new System.Drawing.Size(859, 364);
            this.listBoxMeciuri.TabIndex = 2;
            this.listBoxMeciuri.SelectedIndexChanged += new System.EventHandler(this.listBoxMeciuri_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Agentie_Pariuri.Properties.Resources.dd81a2c2c6c2e718557c23fc757ad428;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.listBoxMeciuri);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMeciuri;
    }
}