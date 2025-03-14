﻿namespace TestingPlace;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsername, txtNewUsername, txtPassword, txtConfirmPassword, txtEmail;
    private Button btnRegister, btnUpdate, btnDelete, btnFetch;
    private Label lblUsername, lblNewUsername, lblPassword, lblConfirmPassword, lblEmail, lblMessage;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(600, 400);
        this.Text = "User Management";
        this.StartPosition = FormStartPosition.CenterScreen;

        // Labels
        lblUsername = new Label { Text = "Current Username:", Location = new System.Drawing.Point(20, 20) };
        lblNewUsername = new Label { Text = "New Username:", Location = new System.Drawing.Point(20, 60) };
        lblPassword = new Label { Text = "Password:", Location = new System.Drawing.Point(20, 100) };
        lblConfirmPassword = new Label { Text = "Confirm Password:", Location = new System.Drawing.Point(20, 140) };
        lblEmail = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 180) };
        lblMessage = new Label { Location = new System.Drawing.Point(20, 350), ForeColor = System.Drawing.Color.Red };

        // Textboxes
        txtUsername = new TextBox { Location = new System.Drawing.Point(150, 20), Width = 200 };
        txtNewUsername = new TextBox { Location = new System.Drawing.Point(150, 60), Width = 200 };
        txtPassword = new TextBox { Location = new System.Drawing.Point(150, 100), Width = 200, PasswordChar = '*' };
        txtConfirmPassword = new TextBox { Location = new System.Drawing.Point(150, 140), Width = 200, PasswordChar = '*' };
        txtEmail = new TextBox { Location = new System.Drawing.Point(150, 180), Width = 200 };

        // Buttons
        btnRegister = new Button { Text = "Register", Location = new System.Drawing.Point(150, 220),Size = new System.Drawing.Size(120, 40)};
        btnUpdate = new Button { Text = "Update", Location = new System.Drawing.Point(270, 220), Size = new System.Drawing.Size(120, 40) };
        btnDelete = new Button { Text = "Delete", Location = new System.Drawing.Point(390, 220),Size = new System.Drawing.Size(120, 40) };
        btnFetch = new Button { Text = "Fetch", Location = new System.Drawing.Point(360, 20), Size = new System.Drawing.Size(120, 40) };

        // Event Handlers
        btnRegister.Click += new EventHandler(this.btnRegister_Click);
        btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
        btnDelete.Click += new EventHandler(this.btnDelete_Click);
        // btnFetch.Click += new EventHandler(this.btnFetch_Click);

        // Adding Controls to Form
        this.Controls.Add(lblUsername);
        this.Controls.Add(lblNewUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(lblConfirmPassword);
        this.Controls.Add(lblEmail);
        this.Controls.Add(lblMessage);

        this.Controls.Add(txtUsername);
        this.Controls.Add(txtNewUsername);
        this.Controls.Add(txtPassword);
        this.Controls.Add(txtConfirmPassword);
        this.Controls.Add(txtEmail);

        this.Controls.Add(btnRegister);
        this.Controls.Add(btnUpdate);
        this.Controls.Add(btnDelete);
        this.Controls.Add(btnFetch);
    }
}