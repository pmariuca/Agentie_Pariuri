namespace Agentie_Pariuri
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCastiguri = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.graficCastiguriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(299, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bilete jucate";
            // 
            // lbCastiguri
            // 
            this.lbCastiguri.BackColor = System.Drawing.Color.MistyRose;
            this.lbCastiguri.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCastiguri.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lbCastiguri.FormattingEnabled = true;
            this.lbCastiguri.HorizontalScrollbar = true;
            this.lbCastiguri.ItemHeight = 17;
            this.lbCastiguri.Location = new System.Drawing.Point(42, 70);
            this.lbCastiguri.Name = "lbCastiguri";
            this.lbCastiguri.Size = new System.Drawing.Size(713, 361);
            this.lbCastiguri.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackgroundImage = global::Agentie_Pariuri.Properties.Resources._7fe944ae68a19a24dae92d57e591b055;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graficCastiguriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 56);
            // 
            // graficCastiguriToolStripMenuItem
            // 
            this.graficCastiguriToolStripMenuItem.Name = "graficCastiguriToolStripMenuItem";
            this.graficCastiguriToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.graficCastiguriToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.graficCastiguriToolStripMenuItem.Text = "Grafic castiguri";
            this.graficCastiguriToolStripMenuItem.Click += new System.EventHandler(this.graficCastiguriToolStripMenuItem_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Agentie_Pariuri.Properties.Resources.ff6cee218b0fbbb046082285824941eb;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbCastiguri);
            this.Controls.Add(this.label1);
            this.Name = "Form7";
            this.Text = "Form7";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbCastiguri;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graficCastiguriToolStripMenuItem;
    }
}