namespace PlatiniumLC
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
            this.UpdateConsole_textBox = new System.Windows.Forms.TextBox();
            this.News_title_textBox = new System.Windows.Forms.TextBox();
            this.UpdateConsole_title_textBox = new System.Windows.Forms.TextBox();
            this.ClientFolder_button = new System.Windows.Forms.Button();
            this.Website__button = new System.Windows.Forms.Button();
            this.Register_button = new System.Windows.Forms.Button();
            this.LC_Top_pictureBox = new System.Windows.Forms.PictureBox();
            this.Start_button = new System.Windows.Forms.Button();
            this.News_richTextBox = new System.Windows.Forms.RichTextBox();
            this.ClientFolder_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Top_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateConsole_textBox
            // 
            this.UpdateConsole_textBox.BackColor = System.Drawing.Color.DimGray;
            this.UpdateConsole_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.UpdateConsole_textBox.ForeColor = System.Drawing.Color.Lime;
            this.UpdateConsole_textBox.Location = new System.Drawing.Point(12, 429);
            this.UpdateConsole_textBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.UpdateConsole_textBox.Multiline = true;
            this.UpdateConsole_textBox.Name = "UpdateConsole_textBox";
            this.UpdateConsole_textBox.ReadOnly = true;
            this.UpdateConsole_textBox.Size = new System.Drawing.Size(420, 403);
            this.UpdateConsole_textBox.TabIndex = 3;
            // 
            // News_title_textBox
            // 
            this.News_title_textBox.BackColor = System.Drawing.Color.DimGray;
            this.News_title_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.News_title_textBox.ForeColor = System.Drawing.Color.Yellow;
            this.News_title_textBox.Location = new System.Drawing.Point(446, 376);
            this.News_title_textBox.Name = "News_title_textBox";
            this.News_title_textBox.ReadOnly = true;
            this.News_title_textBox.Size = new System.Drawing.Size(420, 35);
            this.News_title_textBox.TabIndex = 5;
            this.News_title_textBox.Text = "Platinium Last Chaos Update News";
            // 
            // UpdateConsole_title_textBox
            // 
            this.UpdateConsole_title_textBox.BackColor = System.Drawing.Color.DimGray;
            this.UpdateConsole_title_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UpdateConsole_title_textBox.ForeColor = System.Drawing.Color.Lime;
            this.UpdateConsole_title_textBox.Location = new System.Drawing.Point(12, 376);
            this.UpdateConsole_title_textBox.Name = "UpdateConsole_title_textBox";
            this.UpdateConsole_title_textBox.ReadOnly = true;
            this.UpdateConsole_title_textBox.Size = new System.Drawing.Size(420, 35);
            this.UpdateConsole_title_textBox.TabIndex = 6;
            this.UpdateConsole_title_textBox.Text = "Platinium Last Chaos Update Console";
            // 
            // ClientFolder_button
            // 
            this.ClientFolder_button.BackgroundImage = global::PlatiniumLC.Properties.Resources.LC_Button;
            this.ClientFolder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientFolder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientFolder_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ClientFolder_button.ForeColor = System.Drawing.Color.White;
            this.ClientFolder_button.Location = new System.Drawing.Point(736, 679);
            this.ClientFolder_button.Name = "ClientFolder_button";
            this.ClientFolder_button.Size = new System.Drawing.Size(130, 40);
            this.ClientFolder_button.TabIndex = 9;
            this.ClientFolder_button.Text = "Client Folder";
            this.ClientFolder_button.UseVisualStyleBackColor = true;
            this.ClientFolder_button.Click += new System.EventHandler(this.ClientFolder_button_Click);
            // 
            // Website__button
            // 
            this.Website__button.BackgroundImage = global::PlatiniumLC.Properties.Resources.LC_Button;
            this.Website__button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Website__button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Website__button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Website__button.ForeColor = System.Drawing.Color.White;
            this.Website__button.Location = new System.Drawing.Point(446, 679);
            this.Website__button.Name = "Website__button";
            this.Website__button.Size = new System.Drawing.Size(130, 40);
            this.Website__button.TabIndex = 8;
            this.Website__button.Text = "Website";
            this.Website__button.UseVisualStyleBackColor = false;
            this.Website__button.Click += new System.EventHandler(this.Website_button_Click);
            // 
            // Register_button
            // 
            this.Register_button.BackgroundImage = global::PlatiniumLC.Properties.Resources.LC_Button;
            this.Register_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Register_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Register_button.ForeColor = System.Drawing.Color.White;
            this.Register_button.Location = new System.Drawing.Point(591, 679);
            this.Register_button.Name = "Register_button";
            this.Register_button.Size = new System.Drawing.Size(130, 40);
            this.Register_button.TabIndex = 7;
            this.Register_button.Text = "Register";
            this.Register_button.UseVisualStyleBackColor = true;
            this.Register_button.Click += new System.EventHandler(this.Register_button_Click);
            // 
            // LC_Top_pictureBox
            // 
            this.LC_Top_pictureBox.Image = global::PlatiniumLC.Properties.Resources.LC_Top;
            this.LC_Top_pictureBox.InitialImage = null;
            this.LC_Top_pictureBox.Location = new System.Drawing.Point(0, 0);
            this.LC_Top_pictureBox.Name = "LC_Top_pictureBox";
            this.LC_Top_pictureBox.Size = new System.Drawing.Size(877, 433);
            this.LC_Top_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LC_Top_pictureBox.TabIndex = 1;
            this.LC_Top_pictureBox.TabStop = false;
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.Color.Black;
            this.Start_button.BackgroundImage = global::PlatiniumLC.Properties.Resources.LC_Button;
            this.Start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Start_button.ForeColor = System.Drawing.Color.White;
            this.Start_button.Location = new System.Drawing.Point(446, 734);
            this.Start_button.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(420, 98);
            this.Start_button.TabIndex = 0;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // News_richTextBox
            // 
            this.News_richTextBox.BackColor = System.Drawing.Color.DimGray;
            this.News_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.News_richTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.News_richTextBox.Location = new System.Drawing.Point(446, 429);
            this.News_richTextBox.Name = "News_richTextBox";
            this.News_richTextBox.ReadOnly = true;
            this.News_richTextBox.Size = new System.Drawing.Size(420, 228);
            this.News_richTextBox.TabIndex = 10;
            this.News_richTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(878, 830);
            this.Controls.Add(this.News_richTextBox);
            this.Controls.Add(this.ClientFolder_button);
            this.Controls.Add(this.Website__button);
            this.Controls.Add(this.Register_button);
            this.Controls.Add(this.UpdateConsole_title_textBox);
            this.Controls.Add(this.News_title_textBox);
            this.Controls.Add(this.UpdateConsole_textBox);
            this.Controls.Add(this.LC_Top_pictureBox);
            this.Controls.Add(this.Start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Platinium Last Chaos Launcher v2.0.3 by Nico Bosshard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LC_Top_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.PictureBox LC_Top_pictureBox;
        private System.Windows.Forms.TextBox UpdateConsole_textBox;
        private System.Windows.Forms.TextBox News_title_textBox;
        private System.Windows.Forms.TextBox UpdateConsole_title_textBox;
        private System.Windows.Forms.Button Register_button;
        private System.Windows.Forms.Button Website__button;
        private System.Windows.Forms.Button ClientFolder_button;
        private System.Windows.Forms.RichTextBox News_richTextBox;
        private System.Windows.Forms.FolderBrowserDialog ClientFolder_folderBrowserDialog;
    }
}

