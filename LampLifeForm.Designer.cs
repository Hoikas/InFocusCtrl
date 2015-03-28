namespace InFocusCtrl
{
    partial class LampLifeForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LampLifeForm));
            this.m_progress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lifeHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_progress
            // 
            this.m_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_progress.Location = new System.Drawing.Point(14, 13);
            this.m_progress.Margin = new System.Windows.Forms.Padding(4);
            this.m_progress.MarqueeAnimationSpeed = 0;
            this.m_progress.Maximum = 32766;
            this.m_progress.Name = "m_progress";
            this.m_progress.Size = new System.Drawing.Size(329, 27);
            this.m_progress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Projector Lamp Life:";
            // 
            // m_lifeHint
            // 
            this.m_lifeHint.AutoSize = true;
            this.m_lifeHint.Location = new System.Drawing.Point(134, 49);
            this.m_lifeHint.Name = "m_lifeHint";
            this.m_lifeHint.Size = new System.Drawing.Size(16, 15);
            this.m_lifeHint.TabIndex = 2;
            this.m_lifeHint.Text = "...";
            // 
            // LampLifeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 77);
            this.Controls.Add(this.m_lifeHint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_progress);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LampLifeForm";
            this.Text = "Projector Lamp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar m_progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lifeHint;
    }
}