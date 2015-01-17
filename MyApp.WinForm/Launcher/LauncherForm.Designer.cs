namespace MyApp.WinForm.Launcher
{
    partial class LauncherForm
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
            this.numGenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numGenButton
            // 
            this.numGenButton.Location = new System.Drawing.Point(44, 22);
            this.numGenButton.Name = "numGenButton";
            this.numGenButton.Size = new System.Drawing.Size(75, 23);
            this.numGenButton.TabIndex = 0;
            this.numGenButton.Text = "Num Gen";
            this.numGenButton.UseVisualStyleBackColor = true;
            this.numGenButton.Click += new System.EventHandler(this.numGenButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numGenButton);
            this.Name = "LauncherForm";
            this.Text = "LauncherForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button numGenButton;
    }
}