namespace lab06
{
    partial class Control
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.btnServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(18, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Username:";
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.SystemColors.Control;
            this.btnClient.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.Color.Black;
            this.btnClient.Location = new System.Drawing.Point(13, 183);
            this.btnClient.Margin = new System.Windows.Forms.Padding(4);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(355, 68);
            this.btnClient.TabIndex = 14;
            this.btnClient.Text = "Join a game ";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Control;
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbUsername.ForeColor = System.Drawing.Color.Black;
            this.tbUsername.Location = new System.Drawing.Point(169, 107);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(208, 28);
            this.tbUsername.TabIndex = 11;
            this.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnServer
            // 
            this.btnServer.BackColor = System.Drawing.SystemColors.Control;
            this.btnServer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServer.ForeColor = System.Drawing.Color.Black;
            this.btnServer.Location = new System.Drawing.Point(427, 183);
            this.btnServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(355, 68);
            this.btnServer.TabIndex = 16;
            this.btnServer.Text = "Create Room";
            this.btnServer.UseVisualStyleBackColor = false;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(253, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number Guessing Game";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 309);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.btnServer);
            this.Name = "Control";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Label label2;
    }
}

