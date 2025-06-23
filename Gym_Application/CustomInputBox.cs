using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Application {
    internal class CustomInputBox : Form {
        private Label labelPrompt;
        private TextBox textBoxInput;
        private Button buttonOK;
        private Button buttonCancel;

        public string InputText => textBoxInput.Text;

        public CustomInputBox(string title, string prompt, string defaultValue = "") {
            // Form settings
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(400, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = buttonOK;
            this.CancelButton = buttonCancel;

            // Label
            labelPrompt = new Label()
            {
                AutoSize = false,
                Text = prompt,
                Location = new Point(10, 10),
                Size = new Size(380, 40)
            };
            this.Controls.Add(labelPrompt);

            // TextBox
            textBoxInput = new TextBox()
            {
                Location = new Point(10, 60),
                Size = new Size(380, 25),
                Text = defaultValue
            };
            this.Controls.Add(textBoxInput);

            // OK Button
            buttonOK = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(220, 100),
                Size = new Size(75, 30)
            };
            buttonOK.Click += (s, e) => { this.Close(); };
            this.Controls.Add(buttonOK);

            // Cancel Button
            buttonCancel = new Button()
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(310, 100),
                Size = new Size(75, 30)
            };
            buttonCancel.Click += (s, e) => { this.Close(); };
            this.Controls.Add(buttonCancel);
        }
    }
}
