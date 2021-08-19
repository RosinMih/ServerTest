
namespace ServerTest
{
    partial class MainFormServer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_IPAdr = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_Description = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_PORT = new System.Windows.Forms.Label();
            this.textBox_In_message = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_IPAdr
            // 
            this.textBox_IPAdr.Location = new System.Drawing.Point(88, 43);
            this.textBox_IPAdr.Name = "textBox_IPAdr";
            this.textBox_IPAdr.Size = new System.Drawing.Size(152, 20);
            this.textBox_IPAdr.TabIndex = 0;
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(16, 79);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(373, 30);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "Старт (начать прослушивание с сокета IP Adress:Port)";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Location = new System.Drawing.Point(13, 9);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(403, 13);
            this.label_Description.TabIndex = 3;
            this.label_Description.Text = "Серверная часть программы тестирования прохождения TCP севых пакетов ";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(316, 43);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(69, 20);
            this.textBox_Port.TabIndex = 4;
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(13, 50);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(67, 13);
            this.label_IP.TabIndex = 7;
            this.label_IP.Text = "IP v4 Adress";
            // 
            // label_PORT
            // 
            this.label_PORT.AutoSize = true;
            this.label_PORT.Location = new System.Drawing.Point(270, 50);
            this.label_PORT.Name = "label_PORT";
            this.label_PORT.Size = new System.Drawing.Size(26, 13);
            this.label_PORT.TabIndex = 8;
            this.label_PORT.Text = "Port";
            // 
            // textBox_In_message
            // 
            this.textBox_In_message.Location = new System.Drawing.Point(16, 155);
            this.textBox_In_message.Multiline = true;
            this.textBox_In_message.Name = "textBox_In_message";
            this.textBox_In_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_In_message.Size = new System.Drawing.Size(369, 151);
            this.textBox_In_message.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(281, 126);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(104, 23);
            this.button_Clear.TabIndex = 10;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // MainFormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 335);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.textBox_In_message);
            this.Controls.Add(this.label_PORT);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_IPAdr);
            this.Name = "MainFormServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IPAdr;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_PORT;
        private System.Windows.Forms.TextBox textBox_In_message;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_Clear;
    }
}

