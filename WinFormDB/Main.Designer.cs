﻿namespace WinFormDB
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.DBConn = new System.Windows.Forms.Label();
            this.BTmemb = new System.Windows.Forms.Label();
            this.BTinsert = new System.Windows.Forms.Label();
            this.BTmusic = new System.Windows.Forms.Label();
            this.BTplaylist = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DBConn
            // 
            this.DBConn.AutoSize = true;
            this.DBConn.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DBConn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.DBConn.Location = new System.Drawing.Point(181, 52);
            this.DBConn.Name = "DBConn";
            this.DBConn.Size = new System.Drawing.Size(466, 38);
            this.DBConn.TabIndex = 0;
            this.DBConn.Text = "Management Program";
            // 
            // BTmemb
            // 
            this.BTmemb.AutoSize = true;
            this.BTmemb.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTmemb.Location = new System.Drawing.Point(460, 171);
            this.BTmemb.Name = "BTmemb";
            this.BTmemb.Size = new System.Drawing.Size(81, 33);
            this.BTmemb.TabIndex = 1;
            this.BTmemb.Text = "회원";
            this.BTmemb.Click += new System.EventHandler(this.BTmemb_Click);
            // 
            // BTinsert
            // 
            this.BTinsert.AutoSize = true;
            this.BTinsert.Font = new System.Drawing.Font("굴림", 20F);
            this.BTinsert.Location = new System.Drawing.Point(300, 252);
            this.BTinsert.Name = "BTinsert";
            this.BTinsert.Size = new System.Drawing.Size(0, 34);
            this.BTinsert.TabIndex = 2;
            // 
            // BTmusic
            // 
            this.BTmusic.AutoSize = true;
            this.BTmusic.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTmusic.Location = new System.Drawing.Point(460, 241);
            this.BTmusic.Name = "BTmusic";
            this.BTmusic.Size = new System.Drawing.Size(81, 33);
            this.BTmusic.TabIndex = 3;
            this.BTmusic.Text = "음원";
            this.BTmusic.Click += new System.EventHandler(this.BTmusic_Click);
            // 
            // BTplaylist
            // 
            this.BTplaylist.AutoSize = true;
            this.BTplaylist.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTplaylist.Location = new System.Drawing.Point(460, 311);
            this.BTplaylist.Name = "BTplaylist";
            this.BTplaylist.Size = new System.Drawing.Size(213, 33);
            this.BTplaylist.TabIndex = 4;
            this.BTplaylist.Text = "플레이리스트";
            this.BTplaylist.Click += new System.EventHandler(this.BTplaylist_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exit.Location = new System.Drawing.Point(707, 398);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(81, 33);
            this.exit.TabIndex = 5;
            this.exit.Text = "종료";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(177, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 217);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.BTplaylist);
            this.Controls.Add(this.BTmusic);
            this.Controls.Add(this.BTinsert);
            this.Controls.Add(this.BTmemb);
            this.Controls.Add(this.DBConn);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DBConn;
        private System.Windows.Forms.Label BTmemb;
        private System.Windows.Forms.Label BTinsert;
        private System.Windows.Forms.Label BTmusic;
        private System.Windows.Forms.Label BTplaylist;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

