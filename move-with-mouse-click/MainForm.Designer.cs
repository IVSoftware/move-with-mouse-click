namespace move_with_mouse_click
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxEnableCTM = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxEnableCTM
            // 
            this.checkBoxEnableCTM.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxEnableCTM.AutoSize = true;
            this.checkBoxEnableCTM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxEnableCTM.Location = new System.Drawing.Point(30, 63);
            this.checkBoxEnableCTM.Name = "checkBoxEnableCTM";
            this.checkBoxEnableCTM.Size = new System.Drawing.Size(187, 35);
            this.checkBoxEnableCTM.TabIndex = 0;
            this.checkBoxEnableCTM.Text = "Enable Click to Move";
            this.checkBoxEnableCTM.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxEnableCTM);
            this.Name = "MainForm";
            this.Text = "Click to Move";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBoxEnableCTM;
    }
}