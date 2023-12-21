namespace WinFormsApp1
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
        private void InitializeComponent()
        {
            label2 = new Label();
            button1 = new Button();
            entername = new TextBox();
            listBox = new ListBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 100);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Введите имя";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(305, 161);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(108, 28);
            button1.TabIndex = 2;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // entername
            // 
            entername.Location = new Point(305, 129);
            entername.Margin = new Padding(3, 2, 3, 2);
            entername.Name = "entername";
            entername.Size = new Size(110, 23);
            entername.TabIndex = 3;
            entername.TextChanged += textBox1_TextChanged;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(10, 9);
            listBox.Margin = new Padding(3, 2, 3, 2);
            listBox.Name = "listBox";
            listBox.SelectionMode = SelectionMode.None;
            listBox.Size = new Size(132, 349);
            listBox.TabIndex = 4;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 363);
            Controls.Add(listBox);
            Controls.Add(entername);
            Controls.Add(button1);
            Controls.Add(label2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private TextBox entername;
        private ListBox listBox;
    }
}
