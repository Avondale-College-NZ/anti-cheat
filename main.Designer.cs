namespace anti_cheat
{
    partial class main
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
            this.textbox = new System.Windows.Forms.TextBox();
            this.buttonlist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(12, 11);
            this.textbox.Multiline = true;
            this.textbox.Name = "textbox";
            this.textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox.Size = new System.Drawing.Size(570, 458);
            this.textbox.TabIndex = 0;
            // 
            // buttonlist
            // 
            this.buttonlist.Location = new System.Drawing.Point(12, 476);
            this.buttonlist.Name = "buttonlist";
            this.buttonlist.Size = new System.Drawing.Size(75, 23);
            this.buttonlist.TabIndex = 1;
            this.buttonlist.Text = "list";
            this.buttonlist.UseVisualStyleBackColor = true;
            this.buttonlist.Click += new System.EventHandler(this.buttonlist_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 511);
            this.Controls.Add(this.buttonlist);
            this.Controls.Add(this.textbox);
            this.Name = "main";
            this.Text = "Anti-Cheat";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Button buttonlist;
    }
}

