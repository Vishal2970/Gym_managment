namespace Gym_Application {
    partial class PayFees {
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
            Cash_Payement = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 340);
            dataGridView1.TabIndex = 2;
            // 
            // Cash_Payement
            // 
            Cash_Payement.Location = new Point(274, 373);
            Cash_Payement.Name = "Cash_Payement";
            Cash_Payement.Size = new Size(185, 65);
            Cash_Payement.TabIndex = 1;
            Cash_Payement.Text = "Cash Payement";
            Cash_Payement.UseVisualStyleBackColor = true;
            Cash_Payement.Click += Cash_Payement_Click;
            // 
            // PayFees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Cash_Payement);
            Controls.Add(dataGridView1);
            Name = "PayFees";
            Text = "PayFees";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Cash_Payement;
    }
}