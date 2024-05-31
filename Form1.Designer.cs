namespace ConvertTStoMp4
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            label1 = new Label();
            tbFiles = new TextBox();
            btnFiles = new Button();
            btnOutput = new Button();
            tbOutput = new TextBox();
            label2 = new Label();
            lbFiles = new ListBox();
            label3 = new Label();
            btnConvert = new Button();
            pbStatus = new ProgressBar();
            labelStatus = new Label();
            labelPercent = new Label();
            cbSpeed = new ComboBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(178, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione local dos arquivos TS";
            // 
            // tbFiles
            // 
            tbFiles.Location = new Point(12, 123);
            tbFiles.Name = "tbFiles";
            tbFiles.Size = new Size(479, 23);
            tbFiles.TabIndex = 1;
            // 
            // btnFiles
            // 
            btnFiles.Location = new Point(497, 123);
            btnFiles.Name = "btnFiles";
            btnFiles.Size = new Size(75, 23);
            btnFiles.TabIndex = 2;
            btnFiles.Text = "Selecionar";
            btnFiles.UseVisualStyleBackColor = true;
            btnFiles.Click += btnFiles_Click;
            // 
            // btnOutput
            // 
            btnOutput.Location = new Point(342, 183);
            btnOutput.Name = "btnOutput";
            btnOutput.Size = new Size(75, 23);
            btnOutput.TabIndex = 5;
            btnOutput.Text = "Selecionar";
            btnOutput.UseVisualStyleBackColor = true;
            btnOutput.Click += btnOutput_Click;
            // 
            // tbOutput
            // 
            tbOutput.Location = new Point(12, 184);
            tbOutput.Name = "tbOutput";
            tbOutput.Size = new Size(324, 23);
            tbOutput.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 166);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 3;
            label2.Text = "Selecione local de saida";
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 15;
            lbFiles.Location = new Point(12, 256);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new Size(560, 259);
            lbFiles.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 238);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 7;
            label3.Text = "Lista de arquivos";
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(12, 521);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(136, 23);
            btnConvert.TabIndex = 8;
            btnConvert.Text = "Converter Arquivos";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // pbStatus
            // 
            pbStatus.Location = new Point(12, 576);
            pbStatus.Name = "pbStatus";
            pbStatus.Size = new Size(560, 23);
            pbStatus.Style = ProgressBarStyle.Continuous;
            pbStatus.TabIndex = 9;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(12, 558);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(86, 15);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Aguardando....";
            // 
            // labelPercent
            // 
            labelPercent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelPercent.AutoSize = true;
            labelPercent.BackColor = Color.Transparent;
            labelPercent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPercent.ImageAlign = ContentAlignment.MiddleRight;
            labelPercent.Location = new Point(545, 558);
            labelPercent.Name = "labelPercent";
            labelPercent.RightToLeft = RightToLeft.No;
            labelPercent.Size = new Size(27, 15);
            labelPercent.TabIndex = 11;
            labelPercent.Text = "0 %";
            labelPercent.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbSpeed
            // 
            cbSpeed.FormattingEnabled = true;
            cbSpeed.Location = new Point(428, 183);
            cbSpeed.Name = "cbSpeed";
            cbSpeed.Size = new Size(144, 23);
            cbSpeed.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(428, 165);
            label4.Name = "label4";
            label4.Size = new Size(144, 15);
            label4.TabIndex = 13;
            label4.Text = "Velocidade de conversão";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.convert_ts_to_mp4_fotor_bg_remover_20240531145455;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(584, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 611);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(cbSpeed);
            Controls.Add(labelPercent);
            Controls.Add(labelStatus);
            Controls.Add(pbStatus);
            Controls.Add(btnConvert);
            Controls.Add(label3);
            Controls.Add(lbFiles);
            Controls.Add(btnOutput);
            Controls.Add(tbOutput);
            Controls.Add(label2);
            Controls.Add(btnFiles);
            Controls.Add(tbFiles);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mainForm";
            Text = "Conversor TS para MP4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbFiles;
        private Button btnFiles;
        private Button btnOutput;
        private TextBox tbOutput;
        private Label label2;
        private ListBox lbFiles;
        private Label label3;
        private Button btnConvert;
        private ProgressBar pbStatus;
        private Label labelStatus;
        private Label labelPercent;
        private ComboBox cbSpeed;
        private Label label4;
        private PictureBox pictureBox1;
    }
}
