namespace Cofragem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textMaterial = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material a aplicar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textMaterial
            // 
            this.textMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textMaterial.Location = new System.Drawing.Point(115, 12);
            this.textMaterial.Name = "textMaterial";
            this.textMaterial.Size = new System.Drawing.Size(182, 13);
            this.textMaterial.TabIndex = 2;
            this.textMaterial.TextChanged += new System.EventHandler(this.textMaterial_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(94, 58);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(118, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 93);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textMaterial);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Paint Tool ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMaterial;
        private System.Windows.Forms.Button okButton;
    }
}