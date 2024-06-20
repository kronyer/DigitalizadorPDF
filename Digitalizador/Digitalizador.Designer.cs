namespace Digitalizador
{
    partial class Digitalizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Digitalizador));
            button1 = new Button();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            comboBoxScanners = new ComboBox();
            label1 = new Label();
            labelWhere = new Label();
            button2 = new Button();
            labelWherePath = new Label();
            progressBarScan = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(479, 381);
            button1.Name = "button1";
            button1.Size = new Size(298, 58);
            button1.TabIndex = 0;
            button1.Text = "Digitalizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(30, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(337, 446);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBoxScanners
            // 
            comboBoxScanners.FormattingEnabled = true;
            comboBoxScanners.Location = new Point(452, 57);
            comboBoxScanners.Name = "comboBoxScanners";
            comboBoxScanners.Size = new Size(365, 29);
            comboBoxScanners.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 32);
            label1.Name = "label1";
            label1.Size = new Size(157, 21);
            label1.TabIndex = 3;
            label1.Text = "Scanner Selecionado:";
            // 
            // labelWhere
            // 
            labelWhere.AutoSize = true;
            labelWhere.Location = new Point(452, 132);
            labelWhere.Name = "labelWhere";
            labelWhere.Size = new Size(81, 21);
            labelWhere.TabIndex = 4;
            labelWhere.Text = "Salvo em: ";
            // 
            // button2
            // 
            button2.Location = new Point(452, 157);
            button2.Name = "button2";
            button2.Size = new Size(82, 31);
            button2.TabIndex = 5;
            button2.Text = "Abrir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // labelWherePath
            // 
            labelWherePath.AutoSize = true;
            labelWherePath.Location = new Point(546, 132);
            labelWherePath.Name = "labelWherePath";
            labelWherePath.Size = new Size(0, 21);
            labelWherePath.TabIndex = 6;
            // 
            // progressBarScan
            // 
            progressBarScan.Location = new Point(389, 459);
            progressBarScan.Name = "progressBarScan";
            progressBarScan.Size = new Size(479, 18);
            progressBarScan.TabIndex = 7;
            // 
            // Digitalizador
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(900, 514);
            Controls.Add(progressBarScan);
            Controls.Add(labelWherePath);
            Controls.Add(button2);
            Controls.Add(labelWhere);
            Controls.Add(label1);
            Controls.Add(comboBoxScanners);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9.5F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Digitalizador";
            Text = "Digitalizador";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ComboBox comboBoxScanners;
        private Label label1;
        private Label labelWhere;
        private Button button2;
        private Label labelWherePath;
        private ProgressBar progressBarScan;
    }
}
