namespace Autoscreenshot_testing_tooll
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
            this.start_button = new System.Windows.Forms.Button();
            this.end_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Check_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.start_button.Location = new System.Drawing.Point(16, 287);
            this.start_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(80, 42);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // end_button
            // 
            this.end_button.BackColor = System.Drawing.Color.Red;
            this.end_button.Location = new System.Drawing.Point(414, 289);
            this.end_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.end_button.Name = "end_button";
            this.end_button.Size = new System.Drawing.Size(99, 42);
            this.end_button.TabIndex = 1;
            this.end_button.Text = "End";
            this.end_button.UseVisualStyleBackColor = false;
            this.end_button.Click += new System.EventHandler(this.end_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(464, 160);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(15, 25);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(498, 132);
            this.listBox1.TabIndex = 6;
            // 
            // Check_button
            // 
            this.Check_button.BackColor = System.Drawing.Color.Yellow;
            this.Check_button.Location = new System.Drawing.Point(160, 289);
            this.Check_button.Margin = new System.Windows.Forms.Padding(4);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(192, 42);
            this.Check_button.TabIndex = 7;
            this.Check_button.Text = "Check";
            this.Check_button.UseVisualStyleBackColor = false;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.SpringGreen;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 163);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(497, 118);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(526, 512);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.end_button);
            this.Controls.Add(this.start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AutoScreen Tool Sharad_Pawar_Version:1.0";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button end_button;
        public System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Check_button;
        private System.Windows.Forms.ListView listView1;
    }
}

