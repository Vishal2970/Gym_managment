namespace Gym_Application
{
    partial class Form1
    {
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
        private void InitializeComponent() {
            add_Member = new Button();
            expired_Memberships = new Button();
            list_Of_Members = new Button();
            pay_Fees = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // add_Member
            // 
            add_Member.Location = new Point(12, 352);
            add_Member.Name = "add_Member";
            add_Member.Size = new Size(149, 57);
            add_Member.TabIndex = 0;
            add_Member.Text = "Add Member";
            add_Member.UseVisualStyleBackColor = true;
            add_Member.Click += add_Member_Click;
            // 
            // expired_Memberships
            // 
            expired_Memberships.Location = new Point(219, 352);
            expired_Memberships.Name = "expired_Memberships";
            expired_Memberships.Size = new Size(149, 57);
            expired_Memberships.TabIndex = 1;
            expired_Memberships.Text = "Expired Memberships";
            expired_Memberships.UseVisualStyleBackColor = true;
            expired_Memberships.Click += expired_Memberships_Click;
            // 
            // list_Of_Members
            // 
            list_Of_Members.Location = new Point(415, 352);
            list_Of_Members.Name = "list_Of_Members";
            list_Of_Members.Size = new Size(149, 57);
            list_Of_Members.TabIndex = 2;
            list_Of_Members.Text = "All Members";
            list_Of_Members.UseVisualStyleBackColor = true;
            list_Of_Members.Click += list_Of_Members_Click;
            // 
            // pay_Fees
            // 
            pay_Fees.Location = new Point(626, 352);
            pay_Fees.Name = "pay_Fees";
            pay_Fees.Size = new Size(149, 57);
            pay_Fees.TabIndex = 3;
            pay_Fees.Text = "Pay fees";
            pay_Fees.UseVisualStyleBackColor = true;
            pay_Fees.Click += pay_Fees_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Serif Lao", 18F, FontStyle.Bold);
            label1.Location = new Point(121, 95);
            label1.Name = "label1";
            label1.Size = new Size(546, 40);
            label1.TabIndex = 4;
            label1.Text = "Welcome to Gym Management System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(pay_Fees);
            Controls.Add(list_Of_Members);
            Controls.Add(expired_Memberships);
            Controls.Add(add_Member);
            Name = "Form1";
            Text = "Gym Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button add_Member;
        private Button expired_Memberships;
        private Button list_Of_Members;
        private Button pay_Fees;
        private Label label1;
    }
}
