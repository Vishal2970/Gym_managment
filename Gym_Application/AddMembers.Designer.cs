namespace Gym_Application {
    partial class AddMembers {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            member_name = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripSeparator1 = new ToolStripSeparator();
            mobileNumber = new TextBox();
            memberName = new Label();
            mobile_number = new Label();
            aadhar = new Label();
            id = new TextBox();
            Member_ID = new Label();
            aadharNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(343, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 380);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(37, 336);
            button1.Name = "button1";
            button1.Size = new Size(204, 54);
            button1.TabIndex = 1;

            button1.Text = "Add Member";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // member_name
            // 
            member_name.AccessibleRole = AccessibleRole.Text;
            member_name.Cursor = Cursors.SizeAll;
            member_name.Location = new Point(37, 74);
            member_name.Name = "member_name";
            member_name.Size = new Size(204, 23);
            member_name.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 10);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(57, 6);
            // 
            // mobileNumber
            // 
            mobileNumber.Location = new Point(37, 140);
            mobileNumber.Name = "mobileNumber";
            mobileNumber.Size = new Size(204, 23);
            mobileNumber.TabIndex = 3;
            // 
            // memberName
            // 
            memberName.AutoSize = true;
            memberName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            memberName.Location = new Point(54, 43);
            memberName.Name = "memberName";
            memberName.Size = new Size(153, 28);
            memberName.TabIndex = 4;
            memberName.Text = "Member Name";
            // 
            // mobile_number
            // 
            mobile_number.AutoSize = true;
            mobile_number.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            mobile_number.Location = new Point(54, 109);
            mobile_number.Name = "mobile_number";
            mobile_number.Size = new Size(161, 28);
            mobile_number.TabIndex = 5;
            mobile_number.Text = "Mobile Number";
            // 
            // aadhar
            // 
            aadhar.AutoSize = true;
            aadhar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            aadhar.Location = new Point(54, 180);
            aadhar.Name = "aadhar";
            aadhar.Size = new Size(163, 28);
            aadhar.TabIndex = 7;
            aadhar.Text = "Aadhar Number";
            // 
            // id
            // 
            id.Location = new Point(37, 298);
            id.Name = "id";
            id.Size = new Size(204, 23);
            id.TabIndex = 8;
            // 
            // Member_ID
            // 
            Member_ID.AutoSize = true;
            Member_ID.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Member_ID.Location = new Point(54, 255);
            Member_ID.Name = "Member_ID";
            Member_ID.Size = new Size(118, 28);
            Member_ID.TabIndex = 9;
            Member_ID.Text = "Member ID";
            // 
            // aadharNumber
            // 
            aadharNumber.Location = new Point(37, 211);
            aadharNumber.Name = "aadharNumber";
            aadharNumber.Size = new Size(204, 23);
            aadharNumber.TabIndex = 10;
            // 
            // AddMembers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(aadharNumber);
            Controls.Add(Member_ID);
            Controls.Add(id);
            Controls.Add(aadhar);
            Controls.Add(mobile_number);
            Controls.Add(memberName);
            Controls.Add(mobileNumber);
            Controls.Add(member_name);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "AddMembers";
            Text = "AddMembers";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox member_name;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private TextBox mobileNumber;
        private Label memberName;
        private Label mobile_number;
        private Label aadhar;
        private TextBox id;
        private Label Member_ID;
        private TextBox aadharNumber;
    }
}