namespace Gym_Application {
    partial class AllMembers {
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
            dataGridView1 = new DataGridView();
            delete_btn = new Button();
            Update_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(283, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(495, 408);
            dataGridView1.TabIndex = 3;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(39, 302);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(188, 63);
            delete_btn.TabIndex = 1;
            delete_btn.Text = "Delete Member";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // Update_btn
            // 
            Update_btn.Location = new Point(39, 54);
            Update_btn.Name = "Update_btn";
            Update_btn.Size = new Size(188, 63);
            Update_btn.TabIndex = 4;
            Update_btn.Text = "Update Member";
            Update_btn.UseVisualStyleBackColor = true;
            Update_btn.Click += Update_btn_Click;
            // 
            // AllMembers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Update_btn);
            Controls.Add(delete_btn);
            Controls.Add(dataGridView1);
            Name = "AllMembers";
            Text = "AllMembers";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button delete_btn;
        private Button Update_btn;
    }
}