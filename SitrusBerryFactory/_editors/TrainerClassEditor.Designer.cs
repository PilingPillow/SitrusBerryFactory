
namespace SitrusBerryFactory._editors
{
    partial class TrainerClassEditor
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
            this.lblClassNameIndex = new System.Windows.Forms.Label();
            this.nudClassNameIndex = new System.Windows.Forms.NumericUpDown();
            this.cmbClassNameIndex = new System.Windows.Forms.ComboBox();
            this.grpClassData = new System.Windows.Forms.GroupBox();
            this.lblClassNameStr = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassNameIndex)).BeginInit();
            this.grpClassData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblClassNameIndex
            // 
            this.lblClassNameIndex.AutoSize = true;
            this.lblClassNameIndex.Location = new System.Drawing.Point(20, 24);
            this.lblClassNameIndex.Margin = new System.Windows.Forms.Padding(0);
            this.lblClassNameIndex.Name = "lblClassNameIndex";
            this.lblClassNameIndex.Size = new System.Drawing.Size(26, 15);
            this.lblClassNameIndex.TabIndex = 0;
            this.lblClassNameIndex.Text = "No.";
            // 
            // nudClassNameIndex
            // 
            this.nudClassNameIndex.Location = new System.Drawing.Point(56, 20);
            this.nudClassNameIndex.Margin = new System.Windows.Forms.Padding(0);
            this.nudClassNameIndex.Name = "nudClassNameIndex";
            this.nudClassNameIndex.Size = new System.Drawing.Size(56, 23);
            this.nudClassNameIndex.TabIndex = 1;
            // 
            // cmbClassNameIndex
            // 
            this.cmbClassNameIndex.FormattingEnabled = true;
            this.cmbClassNameIndex.Location = new System.Drawing.Point(124, 20);
            this.cmbClassNameIndex.Margin = new System.Windows.Forms.Padding(0);
            this.cmbClassNameIndex.Name = "cmbClassNameIndex";
            this.cmbClassNameIndex.Size = new System.Drawing.Size(160, 23);
            this.cmbClassNameIndex.TabIndex = 2;
            // 
            // grpClassData
            // 
            this.grpClassData.Controls.Add(this.textBox1);
            this.grpClassData.Controls.Add(this.lblClassNameStr);
            this.grpClassData.Location = new System.Drawing.Point(20, 54);
            this.grpClassData.Margin = new System.Windows.Forms.Padding(0);
            this.grpClassData.Name = "grpClassData";
            this.grpClassData.Size = new System.Drawing.Size(289, 149);
            this.grpClassData.TabIndex = 3;
            this.grpClassData.TabStop = false;
            this.grpClassData.Text = "Class Data";
            // 
            // lblClassNameStr
            // 
            this.lblClassNameStr.AutoSize = true;
            this.lblClassNameStr.Location = new System.Drawing.Point(20, 32);
            this.lblClassNameStr.Margin = new System.Windows.Forms.Padding(0);
            this.lblClassNameStr.Name = "lblClassNameStr";
            this.lblClassNameStr.Size = new System.Drawing.Size(73, 15);
            this.lblClassNameStr.TabIndex = 0;
            this.lblClassNameStr.Text = "Class Name :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 23);
            this.textBox1.TabIndex = 1;
            // 
            // TrainerClassEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.grpClassData);
            this.Controls.Add(this.cmbClassNameIndex);
            this.Controls.Add(this.nudClassNameIndex);
            this.Controls.Add(this.lblClassNameIndex);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrainerClassEditor";
            this.Text = "TrainerClass";
            ((System.ComponentModel.ISupportInitialize)(this.nudClassNameIndex)).EndInit();
            this.grpClassData.ResumeLayout(false);
            this.grpClassData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClassNameIndex;
        private System.Windows.Forms.NumericUpDown nudClassNameIndex;
        private System.Windows.Forms.ComboBox cmbClassNameIndex;
        private System.Windows.Forms.GroupBox grpClassData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblClassNameStr;
    }
}