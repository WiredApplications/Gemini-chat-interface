namespace telikiergasia2
{
    partial class about
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
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(906, 287);
            label1.TabIndex = 0;
            label1.Text = "Το Project αυτό δημιουργήθηκε στα πλαισια του μαθήματος  \r\n\"ΑΝΤΙΚΕΙΜΕΝΟΣΤΡΕΦΗΣ ΑΝΑΠΤΥΞΗ ΕΦΑΡΜΟΓΩΝ\" \r\nαπο τους μαθητές:\r\n\r\n-Εμμανουήλ Κλιρόπουλος\r\n-Αθανάσιος Ντελέκος\r\n-Μαρίνος Στέφανος\r\n";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(638, 393);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(216, 66);
            button1.TabIndex = 4;
            button1.Text = "Επιστροφή";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.image_2026_01_15_021241771_removebg_preview;
            pictureBox1.Location = new Point(12, 299);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(482, 160);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // about
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(894, 474);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "about";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "about";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
    }
}