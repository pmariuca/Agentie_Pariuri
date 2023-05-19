namespace Agentie_Pariuri
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.userControl11 = new Agentie_Pariuri.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.AllowDrop = true;
            this.userControl11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl11.BackgroundImage")));
            this.userControl11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControl11.Location = new System.Drawing.Point(40, 21);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(877, 531);
            this.userControl11.TabIndex = 0;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Agentie_Pariuri.Properties.Resources.ff6cee218b0fbbb046082285824941eb;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(959, 575);
            this.Controls.Add(this.userControl11);
            this.Name = "Form12";
            this.Text = "Form12";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
    }
}