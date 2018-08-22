namespace AML
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Changes = new System.Windows.Forms.ListBox();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelLastChecked = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Changes
            // 
            this.Changes.FormattingEnabled = true;
            this.Changes.Location = new System.Drawing.Point(215, 22);
            this.Changes.Name = "Changes";
            this.Changes.Size = new System.Drawing.Size(482, 316);
            this.Changes.TabIndex = 1;
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(12, 111);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(61, 13);
            this.labelStartTime.TabIndex = 2;
            this.labelStartTime.Text = "Start Time: ";
            // 
            // labelLastChecked
            // 
            this.labelLastChecked.AutoSize = true;
            this.labelLastChecked.Location = new System.Drawing.Point(12, 149);
            this.labelLastChecked.Name = "labelLastChecked";
            this.labelLastChecked.Size = new System.Drawing.Size(79, 13);
            this.labelLastChecked.TabIndex = 3;
            this.labelLastChecked.Text = "Last Checked: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLastChecked);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.Changes);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox Changes;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelLastChecked;
    }
}

