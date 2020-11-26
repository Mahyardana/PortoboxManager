namespace PortoboxManager
{
    partial class Manager
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
            this.button1 = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serversComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ulLabel = new System.Windows.Forms.Label();
            this.dlLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentserverLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.foreignLabel = new System.Windows.Forms.Label();
            this.localLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check Servers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 339);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(158, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Welcome To Portobox Manager";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Servers: ";
            // 
            // serversComboBox
            // 
            this.serversComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serversComboBox.FormattingEnabled = true;
            this.serversComboBox.Location = new System.Drawing.Point(67, 17);
            this.serversComboBox.Name = "serversComboBox";
            this.serversComboBox.Size = new System.Drawing.Size(339, 21);
            this.serversComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "UL";
            // 
            // ulLabel
            // 
            this.ulLabel.Location = new System.Drawing.Point(498, 303);
            this.ulLabel.Name = "ulLabel";
            this.ulLabel.Size = new System.Drawing.Size(74, 13);
            this.ulLabel.TabIndex = 7;
            this.ulLabel.Text = "0 KB/s";
            this.ulLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dlLabel
            // 
            this.dlLabel.Location = new System.Drawing.Point(498, 316);
            this.dlLabel.Name = "dlLabel";
            this.dlLabel.Size = new System.Drawing.Size(74, 13);
            this.dlLabel.TabIndex = 6;
            this.dlLabel.Text = "0 KB/s";
            this.dlLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current Server: ";
            // 
            // currentserverLabel
            // 
            this.currentserverLabel.AutoSize = true;
            this.currentserverLabel.Location = new System.Drawing.Point(99, 53);
            this.currentserverLabel.Name = "currentserverLabel";
            this.currentserverLabel.Size = new System.Drawing.Size(29, 13);
            this.currentserverLabel.TabIndex = 9;
            this.currentserverLabel.Text = "NaN";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(474, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 28);
            this.button2.TabIndex = 10;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(274, 28);
            this.button3.TabIndex = 11;
            this.button3.Text = "Check Foreign Connection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(274, 28);
            this.button4.TabIndex = 12;
            this.button4.Text = "Check Local Connection";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // foreignLabel
            // 
            this.foreignLabel.AutoSize = true;
            this.foreignLabel.Location = new System.Drawing.Point(292, 282);
            this.foreignLabel.Name = "foreignLabel";
            this.foreignLabel.Size = new System.Drawing.Size(0, 13);
            this.foreignLabel.TabIndex = 13;
            // 
            // localLabel
            // 
            this.localLabel.AutoSize = true;
            this.localLabel.Location = new System.Drawing.Point(292, 316);
            this.localLabel.Name = "localLabel";
            this.localLabel.Size = new System.Drawing.Size(0, 13);
            this.localLabel.TabIndex = 14;
            // 
            // Manager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.localLabel);
            this.Controls.Add(this.foreignLabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.currentserverLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ulLabel);
            this.Controls.Add(this.dlLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serversComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Manager";
            this.Text = "Portobox Manager - ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manager_FormClosed);
            this.Load += new System.EventHandler(this.Manager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox serversComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ulLabel;
        private System.Windows.Forms.Label dlLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentserverLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label foreignLabel;
        private System.Windows.Forms.Label localLabel;
    }
}

