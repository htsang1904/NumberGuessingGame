namespace lab06
{
    partial class ServerForm
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
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumberRange = new System.Windows.Forms.Label();
            this.tbClientCount = new System.Windows.Forms.Label();
            this.tbAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // conversation
            // 
            this.conversation.BackColor = System.Drawing.Color.White;
            this.conversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversation.ForeColor = System.Drawing.Color.Black;
            this.conversation.Location = new System.Drawing.Point(33, 275);
            this.conversation.Margin = new System.Windows.Forms.Padding(4);
            this.conversation.Name = "conversation";
            this.conversation.ReadOnly = true;
            this.conversation.Size = new System.Drawing.Size(961, 390);
            this.conversation.TabIndex = 19;
            this.conversation.TabStop = false;
            this.conversation.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 233);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "Lịch sử";
            // 
            // tbNumberRange
            // 
            this.tbNumberRange.AutoSize = true;
            this.tbNumberRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumberRange.Location = new System.Drawing.Point(28, 72);
            this.tbNumberRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbNumberRange.Name = "tbNumberRange";
            this.tbNumberRange.Size = new System.Drawing.Size(104, 29);
            this.tbNumberRange.TabIndex = 24;
            this.tbNumberRange.Text = "Phạm vi:";
            // 
            // tbClientCount
            // 
            this.tbClientCount.AutoSize = true;
            this.tbClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClientCount.Location = new System.Drawing.Point(28, 22);
            this.tbClientCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbClientCount.Name = "tbClientCount";
            this.tbClientCount.Size = new System.Drawing.Size(231, 29);
            this.tbClientCount.TabIndex = 25;
            this.tbClientCount.Text = "Tổng số người chơi: ";
            // 
            // tbAnswer
            // 
            this.tbAnswer.AutoSize = true;
            this.tbAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAnswer.Location = new System.Drawing.Point(28, 140);
            this.tbAnswer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(101, 29);
            this.tbAnswer.TabIndex = 26;
            this.tbAnswer.Text = "Kết quả:";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 702);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.tbClientCount);
            this.Controls.Add(this.tbNumberRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conversation);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbNumberRange;
        private System.Windows.Forms.Label tbClientCount;
        private System.Windows.Forms.Label tbAnswer;
    }
}