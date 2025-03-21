using System.Net.Http.Headers;

namespace BloodBankManagementSystem
{

    partial class Form1
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox Name;
        private TextBox FatherName;
        private TextBox MotherName;
        private TextBox Email;
        private Button BRegister;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Name = new TextBox();
            FatherName = new TextBox();
            MotherName = new TextBox();
            Email = new TextBox();
            BRegister = new Button();
            BStock = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(345, 32);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Add New Donor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 117);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(515, 117);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 204);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 3;
            label4.Text = "Father Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 276);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 4;
            label5.Text = "Mother Name";
            // 
            // Name
            // 
            Name.Location = new Point(170, 117);
            Name.Name = "Name";
            Name.Size = new Size(189, 27);
            Name.TabIndex = 5;
            // 
            // FatherName
            // 
            FatherName.Location = new Point(170, 204);
            FatherName.Name = "FatherName";
            FatherName.Size = new Size(189, 27);
            FatherName.TabIndex = 6;
            // 
            // MotherName
            // 
            MotherName.Location = new Point(170, 276);
            MotherName.Name = "MotherName";
            MotherName.Size = new Size(189, 27);
            MotherName.TabIndex = 7;
            // 
            // Email
            // 
            Email.Location = new Point(567, 117);
            Email.Name = "Email";
            Email.Size = new Size(189, 27);
            Email.TabIndex = 8;
            // 
            // BRegister
            // 
            BRegister.Location = new Point(617, 195);
            BRegister.Name = "BRegister";
            BRegister.Size = new Size(94, 29);
            BRegister.TabIndex = 9;
            BRegister.Text = "Register ";
            BRegister.UseVisualStyleBackColor = true;
            BRegister.Click += BRegister_Click;
            // 
            // BStock
            // 
            BStock.Location = new Point(617, 307);
            BStock.Name = "BStock";
            BStock.Size = new Size(94, 29);
            BStock.TabIndex = 10;
            BStock.Text = "Stocks";
            BStock.UseVisualStyleBackColor = true;
            BStock.Click += BStock_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(321, 32);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 0;
            label6.Text = "Stocks";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BStock);
            Controls.Add(BRegister);
            Controls.Add(Email);
            Controls.Add(MotherName);
            Controls.Add(FatherName);
            Controls.Add(Name);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);

            //Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Button BStock;
        private Label label6;
    }
}
