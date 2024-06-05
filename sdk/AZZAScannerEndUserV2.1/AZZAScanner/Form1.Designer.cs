namespace AZZAScanner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDocCCCD = new System.Windows.Forms.Button();
            this.pb_imgB = new System.Windows.Forms.PictureBox();
            this.pb_imgA = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.tb_cardType = new System.Windows.Forms.TextBox();
            this.lb_cardType = new System.Windows.Forms.Label();
            this.tb_cardName = new System.Windows.Forms.TextBox();
            this.lb_subImage2 = new System.Windows.Forms.Label();
            this.lb_OCRtext = new System.Windows.Forms.Label();
            this.lb_subImage1 = new System.Windows.Forms.Label();
            this.tb_OCRtext = new System.Windows.Forms.TextBox();
            this.pb_subImage1 = new System.Windows.Forms.PictureBox();
            this.pb_subImage2 = new System.Windows.Forms.PictureBox();
            this.lb_pass_mrzCode = new System.Windows.Forms.Label();
            this.tb_pass_MRZcode = new System.Windows.Forms.TextBox();
            this.bt_pass_readTextByOCR = new System.Windows.Forms.Button();
            this.bt_pass_readDG = new System.Windows.Forms.Button();
            this.lb_pass_dg = new System.Windows.Forms.Label();
            this.cb_pass_dg = new System.Windows.Forms.ComboBox();
            this.pb_pass_digitalImage = new System.Windows.Forms.PictureBox();
            this.tb_pass_digitalText = new System.Windows.Forms.TextBox();
            this.tb_pass_MRZkey = new System.Windows.Forms.TextBox();
            this.bt_pass_generateKey = new System.Windows.Forms.Button();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imgB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imgA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_subImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_subImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pass_digitalImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDocCCCD
            // 
            this.btnDocCCCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocCCCD.Location = new System.Drawing.Point(14, 6);
            this.btnDocCCCD.Name = "btnDocCCCD";
            this.btnDocCCCD.Size = new System.Drawing.Size(122, 36);
            this.btnDocCCCD.TabIndex = 0;
            this.btnDocCCCD.Text = "Đọc thông tin";
            this.btnDocCCCD.UseVisualStyleBackColor = true;
            this.btnDocCCCD.Click += new System.EventHandler(this.btnDocCCCD_Click);
            // 
            // pb_imgB
            // 
            this.pb_imgB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_imgB.Location = new System.Drawing.Point(12, 268);
            this.pb_imgB.Name = "pb_imgB";
            this.pb_imgB.Size = new System.Drawing.Size(322, 204);
            this.pb_imgB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_imgB.TabIndex = 11;
            this.pb_imgB.TabStop = false;
            // 
            // pb_imgA
            // 
            this.pb_imgA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_imgA.Location = new System.Drawing.Point(13, 38);
            this.pb_imgA.Name = "pb_imgA";
            this.pb_imgA.Size = new System.Drawing.Size(322, 204);
            this.pb_imgA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_imgA.TabIndex = 12;
            this.pb_imgA.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(131, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ảnh mặt trước";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ảnh mặt sau";
            // 
            // tb_log
            // 
            this.tb_log.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_log.Location = new System.Drawing.Point(1012, 60);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(244, 529);
            this.tb_log.TabIndex = 16;
            this.tb_log.TextChanged += new System.EventHandler(this.tb_log_TextChanged);
            // 
            // tb_cardType
            // 
            this.tb_cardType.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cardType.Location = new System.Drawing.Point(438, 687);
            this.tb_cardType.Margin = new System.Windows.Forms.Padding(4);
            this.tb_cardType.Name = "tb_cardType";
            this.tb_cardType.Size = new System.Drawing.Size(48, 32);
            this.tb_cardType.TabIndex = 52;
            // 
            // lb_cardType
            // 
            this.lb_cardType.AutoSize = true;
            this.lb_cardType.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_cardType.Location = new System.Drawing.Point(367, 695);
            this.lb_cardType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_cardType.Name = "lb_cardType";
            this.lb_cardType.Size = new System.Drawing.Size(63, 16);
            this.lb_cardType.TabIndex = 50;
            this.lb_cardType.Text = "Card type";
            // 
            // tb_cardName
            // 
            this.tb_cardName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_cardName.Location = new System.Drawing.Point(503, 688);
            this.tb_cardName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_cardName.Name = "tb_cardName";
            this.tb_cardName.Size = new System.Drawing.Size(114, 32);
            this.tb_cardName.TabIndex = 51;
            // 
            // lb_subImage2
            // 
            this.lb_subImage2.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_subImage2.Location = new System.Drawing.Point(337, 240);
            this.lb_subImage2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_subImage2.Name = "lb_subImage2";
            this.lb_subImage2.Size = new System.Drawing.Size(156, 20);
            this.lb_subImage2.TabIndex = 65;
            this.lb_subImage2.Text = "QR Code ";
            this.lb_subImage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_OCRtext
            // 
            this.lb_OCRtext.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_OCRtext.Location = new System.Drawing.Point(12, 704);
            this.lb_OCRtext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OCRtext.Name = "lb_OCRtext";
            this.lb_OCRtext.Size = new System.Drawing.Size(327, 21);
            this.lb_OCRtext.TabIndex = 68;
            this.lb_OCRtext.Text = "OCR text";
            this.lb_OCRtext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_subImage1
            // 
            this.lb_subImage1.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_subImage1.Location = new System.Drawing.Point(343, 19);
            this.lb_subImage1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_subImage1.Name = "lb_subImage1";
            this.lb_subImage1.Size = new System.Drawing.Size(156, 20);
            this.lb_subImage1.TabIndex = 64;
            this.lb_subImage1.Text = "Ảnh scan";
            this.lb_subImage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_OCRtext
            // 
            this.tb_OCRtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_OCRtext.Location = new System.Drawing.Point(16, 729);
            this.tb_OCRtext.Margin = new System.Windows.Forms.Padding(4);
            this.tb_OCRtext.Multiline = true;
            this.tb_OCRtext.Name = "tb_OCRtext";
            this.tb_OCRtext.Size = new System.Drawing.Size(286, 51);
            this.tb_OCRtext.TabIndex = 57;
            // 
            // pb_subImage1
            // 
            this.pb_subImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_subImage1.Location = new System.Drawing.Point(346, 39);
            this.pb_subImage1.Name = "pb_subImage1";
            this.pb_subImage1.Size = new System.Drawing.Size(153, 163);
            this.pb_subImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_subImage1.TabIndex = 53;
            this.pb_subImage1.TabStop = false;
            // 
            // pb_subImage2
            // 
            this.pb_subImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_subImage2.Location = new System.Drawing.Point(346, 266);
            this.pb_subImage2.Name = "pb_subImage2";
            this.pb_subImage2.Size = new System.Drawing.Size(153, 139);
            this.pb_subImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_subImage2.TabIndex = 54;
            this.pb_subImage2.TabStop = false;
            // 
            // lb_pass_mrzCode
            // 
            this.lb_pass_mrzCode.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_pass_mrzCode.Location = new System.Drawing.Point(351, 446);
            this.lb_pass_mrzCode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_pass_mrzCode.Name = "lb_pass_mrzCode";
            this.lb_pass_mrzCode.Size = new System.Drawing.Size(125, 27);
            this.lb_pass_mrzCode.TabIndex = 71;
            this.lb_pass_mrzCode.Text = "MRZ code";
            this.lb_pass_mrzCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_pass_MRZcode
            // 
            this.tb_pass_MRZcode.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.tb_pass_MRZcode.Location = new System.Drawing.Point(13, 477);
            this.tb_pass_MRZcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_pass_MRZcode.Multiline = true;
            this.tb_pass_MRZcode.Name = "tb_pass_MRZcode";
            this.tb_pass_MRZcode.Size = new System.Drawing.Size(479, 68);
            this.tb_pass_MRZcode.TabIndex = 70;
            // 
            // bt_pass_readTextByOCR
            // 
            this.bt_pass_readTextByOCR.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.bt_pass_readTextByOCR.Location = new System.Drawing.Point(881, 705);
            this.bt_pass_readTextByOCR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bt_pass_readTextByOCR.Name = "bt_pass_readTextByOCR";
            this.bt_pass_readTextByOCR.Size = new System.Drawing.Size(155, 40);
            this.bt_pass_readTextByOCR.TabIndex = 83;
            this.bt_pass_readTextByOCR.Text = "Read text by OCR";
            this.bt_pass_readTextByOCR.UseVisualStyleBackColor = true;
            // 
            // bt_pass_readDG
            // 
            this.bt_pass_readDG.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.bt_pass_readDG.Location = new System.Drawing.Point(1037, 781);
            this.bt_pass_readDG.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.bt_pass_readDG.Name = "bt_pass_readDG";
            this.bt_pass_readDG.Size = new System.Drawing.Size(125, 40);
            this.bt_pass_readDG.TabIndex = 82;
            this.bt_pass_readDG.Text = "Read DG";
            this.bt_pass_readDG.UseVisualStyleBackColor = true;
            this.bt_pass_readDG.Click += new System.EventHandler(this.bt_pass_readDG_Click);
            // 
            // lb_pass_dg
            // 
            this.lb_pass_dg.AutoSize = true;
            this.lb_pass_dg.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lb_pass_dg.Location = new System.Drawing.Point(1047, 749);
            this.lb_pass_dg.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_pass_dg.Name = "lb_pass_dg";
            this.lb_pass_dg.Size = new System.Drawing.Size(28, 16);
            this.lb_pass_dg.TabIndex = 81;
            this.lb_pass_dg.Text = "DG";
            // 
            // cb_pass_dg
            // 
            this.cb_pass_dg.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.cb_pass_dg.FormattingEnabled = true;
            this.cb_pass_dg.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cb_pass_dg.Location = new System.Drawing.Point(1097, 746);
            this.cb_pass_dg.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cb_pass_dg.Name = "cb_pass_dg";
            this.cb_pass_dg.Size = new System.Drawing.Size(55, 24);
            this.cb_pass_dg.TabIndex = 80;
            this.cb_pass_dg.Text = "1";
            // 
            // pb_pass_digitalImage
            // 
            this.pb_pass_digitalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_pass_digitalImage.Location = new System.Drawing.Point(8, 38);
            this.pb_pass_digitalImage.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pb_pass_digitalImage.Name = "pb_pass_digitalImage";
            this.pb_pass_digitalImage.Size = new System.Drawing.Size(132, 164);
            this.pb_pass_digitalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_pass_digitalImage.TabIndex = 79;
            this.pb_pass_digitalImage.TabStop = false;
            // 
            // tb_pass_digitalText
            // 
            this.tb_pass_digitalText.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.tb_pass_digitalText.Location = new System.Drawing.Point(392, 729);
            this.tb_pass_digitalText.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_pass_digitalText.Multiline = true;
            this.tb_pass_digitalText.Name = "tb_pass_digitalText";
            this.tb_pass_digitalText.Size = new System.Drawing.Size(249, 43);
            this.tb_pass_digitalText.TabIndex = 78;
            // 
            // tb_pass_MRZkey
            // 
            this.tb_pass_MRZkey.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.tb_pass_MRZkey.Location = new System.Drawing.Point(153, 797);
            this.tb_pass_MRZkey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_pass_MRZkey.Name = "tb_pass_MRZkey";
            this.tb_pass_MRZkey.Size = new System.Drawing.Size(149, 24);
            this.tb_pass_MRZkey.TabIndex = 74;
            // 
            // bt_pass_generateKey
            // 
            this.bt_pass_generateKey.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.bt_pass_generateKey.Location = new System.Drawing.Point(15, 788);
            this.bt_pass_generateKey.Margin = new System.Windows.Forms.Padding(4);
            this.bt_pass_generateKey.Name = "bt_pass_generateKey";
            this.bt_pass_generateKey.Size = new System.Drawing.Size(125, 40);
            this.bt_pass_generateKey.TabIndex = 73;
            this.bt_pass_generateKey.Text = "Generate key";
            this.bt_pass_generateKey.UseVisualStyleBackColor = true;
            this.bt_pass_generateKey.Click += new System.EventHandler(this.bt_pass_generateKey_Click);
            // 
            // textBox_1
            // 
            this.textBox_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_1.Location = new System.Drawing.Point(148, 38);
            this.textBox_1.Multiline = true;
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_1.Size = new System.Drawing.Size(318, 504);
            this.textBox_1.TabIndex = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_imgA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pb_imgB);
            this.groupBox1.Controls.Add(this.tb_pass_MRZcode);
            this.groupBox1.Controls.Add(this.lb_pass_mrzCode);
            this.groupBox1.Controls.Add(this.pb_subImage2);
            this.groupBox1.Controls.Add(this.pb_subImage1);
            this.groupBox1.Controls.Add(this.lb_subImage1);
            this.groupBox1.Controls.Add(this.lb_subImage2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 551);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu scan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pb_pass_digitalImage);
            this.groupBox2.Controls.Add(this.textBox_1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(527, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 549);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dữ liệu CHIP";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(146, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 36);
            this.button1.TabIndex = 88;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(313, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 89;
            this.checkBox1.Text = "Hiển thị LOG";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 607);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_pass_readTextByOCR);
            this.Controls.Add(this.bt_pass_readDG);
            this.Controls.Add(this.lb_pass_dg);
            this.Controls.Add(this.cb_pass_dg);
            this.Controls.Add(this.tb_pass_digitalText);
            this.Controls.Add(this.tb_pass_MRZkey);
            this.Controls.Add(this.bt_pass_generateKey);
            this.Controls.Add(this.lb_OCRtext);
            this.Controls.Add(this.tb_OCRtext);
            this.Controls.Add(this.tb_cardType);
            this.Controls.Add(this.lb_cardType);
            this.Controls.Add(this.tb_cardName);
            this.Controls.Add(this.btnDocCCCD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NaviScanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_imgB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imgA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_subImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_subImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pass_digitalImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDocCCCD;
        private System.Windows.Forms.PictureBox pb_imgB;
        private System.Windows.Forms.PictureBox pb_imgA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TextBox tb_cardType;
        private System.Windows.Forms.Label lb_cardType;
        private System.Windows.Forms.TextBox tb_cardName;
        private System.Windows.Forms.Label lb_subImage2;
        private System.Windows.Forms.Label lb_OCRtext;
        private System.Windows.Forms.Label lb_subImage1;
        private System.Windows.Forms.TextBox tb_OCRtext;
        private System.Windows.Forms.PictureBox pb_subImage1;
        private System.Windows.Forms.PictureBox pb_subImage2;
        private System.Windows.Forms.Label lb_pass_mrzCode;
        private System.Windows.Forms.TextBox tb_pass_MRZcode;
        private System.Windows.Forms.Button bt_pass_readTextByOCR;
        private System.Windows.Forms.Button bt_pass_readDG;
        private System.Windows.Forms.Label lb_pass_dg;
        private System.Windows.Forms.ComboBox cb_pass_dg;
        private System.Windows.Forms.PictureBox pb_pass_digitalImage;
        private System.Windows.Forms.TextBox tb_pass_digitalText;
        private System.Windows.Forms.TextBox tb_pass_MRZkey;
        private System.Windows.Forms.Button bt_pass_generateKey;
        private System.Windows.Forms.TextBox textBox_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

