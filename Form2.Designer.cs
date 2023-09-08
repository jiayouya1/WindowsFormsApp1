namespace WindowsFormsApp1
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelSex = new System.Windows.Forms.Panel();
            this.radioButton0 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panelState = new System.Windows.Forms.Panel();
            this.radioButtonDJ = new System.Windows.Forms.RadioButton();
            this.radioButtonZC = new System.Windows.Forms.RadioButton();
            this.panelRole = new System.Windows.Forms.Panel();
            this.radioButtonGZRY = new System.Windows.Forms.RadioButton();
            this.radioButtonStu = new System.Windows.Forms.RadioButton();
            this.radioButtonLS = new System.Windows.Forms.RadioButton();
            this.radioButtonGLY = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelZC = new System.Windows.Forms.Label();
            this.panelSex.SuspendLayout();
            this.panelState.SuspendLayout();
            this.panelRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(201, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(89, 63);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 21);
            this.textBoxUser.TabIndex = 2;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(89, 103);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(100, 21);
            this.textBoxPwd.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 149);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 4;
            // 
            // panelSex
            // 
            this.panelSex.Controls.Add(this.radioButton0);
            this.panelSex.Controls.Add(this.radioButton1);
            this.panelSex.Location = new System.Drawing.Point(89, 190);
            this.panelSex.Name = "panelSex";
            this.panelSex.Size = new System.Drawing.Size(100, 31);
            this.panelSex.TabIndex = 5;
            // 
            // radioButton0
            // 
            this.radioButton0.AutoSize = true;
            this.radioButton0.Location = new System.Drawing.Point(62, 9);
            this.radioButton0.Name = "radioButton0";
            this.radioButton0.Size = new System.Drawing.Size(35, 16);
            this.radioButton0.TabIndex = 1;
            this.radioButton0.TabStop = true;
            this.radioButton0.Text = "女";
            this.radioButton0.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panelState
            // 
            this.panelState.Controls.Add(this.radioButtonDJ);
            this.panelState.Controls.Add(this.radioButtonZC);
            this.panelState.Location = new System.Drawing.Point(89, 238);
            this.panelState.Name = "panelState";
            this.panelState.Size = new System.Drawing.Size(118, 31);
            this.panelState.TabIndex = 6;
            // 
            // radioButtonDJ
            // 
            this.radioButtonDJ.AutoSize = true;
            this.radioButtonDJ.Location = new System.Drawing.Point(62, 9);
            this.radioButtonDJ.Name = "radioButtonDJ";
            this.radioButtonDJ.Size = new System.Drawing.Size(47, 16);
            this.radioButtonDJ.TabIndex = 1;
            this.radioButtonDJ.TabStop = true;
            this.radioButtonDJ.Text = "冻结";
            this.radioButtonDJ.UseVisualStyleBackColor = true;
            // 
            // radioButtonZC
            // 
            this.radioButtonZC.AutoSize = true;
            this.radioButtonZC.Location = new System.Drawing.Point(5, 9);
            this.radioButtonZC.Name = "radioButtonZC";
            this.radioButtonZC.Size = new System.Drawing.Size(47, 16);
            this.radioButtonZC.TabIndex = 0;
            this.radioButtonZC.TabStop = true;
            this.radioButtonZC.Text = "正常";
            this.radioButtonZC.UseVisualStyleBackColor = true;
            // 
            // panelRole
            // 
            this.panelRole.Controls.Add(this.radioButtonGZRY);
            this.panelRole.Controls.Add(this.radioButtonStu);
            this.panelRole.Controls.Add(this.radioButtonLS);
            this.panelRole.Controls.Add(this.radioButtonGLY);
            this.panelRole.Location = new System.Drawing.Point(89, 286);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(240, 31);
            this.panelRole.TabIndex = 7;
            // 
            // radioButtonGZRY
            // 
            this.radioButtonGZRY.AutoSize = true;
            this.radioButtonGZRY.Location = new System.Drawing.Point(165, 9);
            this.radioButtonGZRY.Name = "radioButtonGZRY";
            this.radioButtonGZRY.Size = new System.Drawing.Size(71, 16);
            this.radioButtonGZRY.TabIndex = 3;
            this.radioButtonGZRY.TabStop = true;
            this.radioButtonGZRY.Text = "工作人员";
            this.radioButtonGZRY.UseVisualStyleBackColor = true;
            // 
            // radioButtonStu
            // 
            this.radioButtonStu.AutoSize = true;
            this.radioButtonStu.Location = new System.Drawing.Point(112, 9);
            this.radioButtonStu.Name = "radioButtonStu";
            this.radioButtonStu.Size = new System.Drawing.Size(47, 16);
            this.radioButtonStu.TabIndex = 2;
            this.radioButtonStu.TabStop = true;
            this.radioButtonStu.Text = "学生";
            this.radioButtonStu.UseVisualStyleBackColor = true;
            // 
            // radioButtonLS
            // 
            this.radioButtonLS.AutoSize = true;
            this.radioButtonLS.Location = new System.Drawing.Point(62, 9);
            this.radioButtonLS.Name = "radioButtonLS";
            this.radioButtonLS.Size = new System.Drawing.Size(47, 16);
            this.radioButtonLS.TabIndex = 1;
            this.radioButtonLS.TabStop = true;
            this.radioButtonLS.Text = "教师";
            this.radioButtonLS.UseVisualStyleBackColor = true;
            // 
            // radioButtonGLY
            // 
            this.radioButtonGLY.AutoSize = true;
            this.radioButtonGLY.Location = new System.Drawing.Point(5, 9);
            this.radioButtonGLY.Name = "radioButtonGLY";
            this.radioButtonGLY.Size = new System.Drawing.Size(59, 16);
            this.radioButtonGLY.TabIndex = 0;
            this.radioButtonGLY.TabStop = true;
            this.radioButtonGLY.Text = "管理员";
            this.radioButtonGLY.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "角色：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(30, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "注册新用户：";
            // 
            // labelZC
            // 
            this.labelZC.AutoSize = true;
            this.labelZC.Location = new System.Drawing.Point(88, 391);
            this.labelZC.Name = "labelZC";
            this.labelZC.Size = new System.Drawing.Size(0, 12);
            this.labelZC.TabIndex = 15;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 424);
            this.Controls.Add(this.labelZC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelRole);
            this.Controls.Add(this.panelState);
            this.Controls.Add(this.panelSex);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.Text = "用户注册页";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panelSex.ResumeLayout(false);
            this.panelSex.PerformLayout();
            this.panelState.ResumeLayout(false);
            this.panelState.PerformLayout();
            this.panelRole.ResumeLayout(false);
            this.panelRole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelSex;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton0;
        private System.Windows.Forms.Panel panelState;
        private System.Windows.Forms.RadioButton radioButtonDJ;
        private System.Windows.Forms.RadioButton radioButtonZC;
        private System.Windows.Forms.Panel panelRole;
        private System.Windows.Forms.RadioButton radioButtonGZRY;
        private System.Windows.Forms.RadioButton radioButtonStu;
        private System.Windows.Forms.RadioButton radioButtonLS;
        private System.Windows.Forms.RadioButton radioButtonGLY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelZC;
    }
}