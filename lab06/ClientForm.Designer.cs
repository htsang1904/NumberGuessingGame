namespace lab06
{
    partial class ClientForm
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
            this.timerCountDown = new System.Windows.Forms.Label();
            this.conversation = new System.Windows.Forms.RichTextBox();
            this.btnReady = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnAutoplayAllRound = new System.Windows.Forms.Button();
            this.tbClientCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerCountDown
            // 
            this.timerCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerCountDown.Location = new System.Drawing.Point(810, 17);
            this.timerCountDown.Name = "timerCountDown";
            this.timerCountDown.Size = new System.Drawing.Size(164, 134);
            this.timerCountDown.TabIndex = 17;
            this.timerCountDown.Text = "...";
            this.timerCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conversation
            // 
            this.conversation.BackColor = System.Drawing.Color.White;
            this.conversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversation.ForeColor = System.Drawing.Color.Black;
            this.conversation.Location = new System.Drawing.Point(13, 158);
            this.conversation.Margin = new System.Windows.Forms.Padding(4);
            this.conversation.Name = "conversation";
            this.conversation.ReadOnly = true;
            this.conversation.Size = new System.Drawing.Size(961, 390);
            this.conversation.TabIndex = 18;
            this.conversation.TabStop = false;
            this.conversation.Text = "";
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnReady.ForeColor = System.Drawing.Color.White;
            this.btnReady.Location = new System.Drawing.Point(13, 44);
            this.btnReady.Margin = new System.Windows.Forms.Padding(4);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(165, 96);
            this.btnReady.TabIndex = 19;
            this.btnReady.TabStop = false;
            this.btnReady.Text = "Sẵn sàng";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 608);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nhập đáp án:";
            // 
            // answer
            // 
            this.answer.BackColor = System.Drawing.Color.White;
            this.answer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer.ForeColor = System.Drawing.Color.Black;
            this.answer.Location = new System.Drawing.Point(190, 598);
            this.answer.Margin = new System.Windows.Forms.Padding(4);
            this.answer.MaxLength = 3;
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(80, 45);
            this.answer.TabIndex = 20;
            this.answer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(292, 588);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(180, 69);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Gửi";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnAutoplayAllRound
            // 
            this.btnAutoplayAllRound.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAutoplayAllRound.FlatAppearance.BorderSize = 0;
            this.btnAutoplayAllRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAutoplayAllRound.ForeColor = System.Drawing.Color.White;
            this.btnAutoplayAllRound.Location = new System.Drawing.Point(741, 588);
            this.btnAutoplayAllRound.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoplayAllRound.Name = "btnAutoplayAllRound";
            this.btnAutoplayAllRound.Size = new System.Drawing.Size(233, 69);
            this.btnAutoplayAllRound.TabIndex = 27;
            this.btnAutoplayAllRound.TabStop = false;
            this.btnAutoplayAllRound.Text = "Dự đoán tất cả";
            this.btnAutoplayAllRound.UseVisualStyleBackColor = false;
            this.btnAutoplayAllRound.Click += new System.EventHandler(this.btnAutoplayAllRound_Click);
            // 
            // tbClientCount
            // 
            this.tbClientCount.AutoSize = true;
            this.tbClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClientCount.Location = new System.Drawing.Point(394, 9);
            this.tbClientCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbClientCount.Name = "tbClientCount";
            this.tbClientCount.Size = new System.Drawing.Size(251, 29);
            this.tbClientCount.TabIndex = 28;
            this.tbClientCount.Text = "Phòng có 0 người chơi";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 702);
            this.Controls.Add(this.tbClientCount);
            this.Controls.Add(this.btnAutoplayAllRound);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.conversation);
            this.Controls.Add(this.timerCountDown);
            this.Name = "ClientForm";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerCountDown;
        public System.Windows.Forms.RichTextBox conversation;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnAutoplayAllRound;
        private System.Windows.Forms.Label tbClientCount;
    }
}