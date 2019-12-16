﻿namespace WinFormDB
{
    partial class PlaylistAs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPresent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrevious = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMusicid = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.txtCustid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtListid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTextBoxClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNext = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNext);
            this.panel1.Controls.Add(this.txtPresent);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPrevious);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMusicid);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.txtCustid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtListid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(14, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 210);
            this.panel1.TabIndex = 0;
            // 
            // txtPresent
            // 
            this.txtPresent.Location = new System.Drawing.Point(126, 113);
            this.txtPresent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPresent.Name = "txtPresent";
            this.txtPresent.Size = new System.Drawing.Size(213, 25);
            this.txtPresent.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(8, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Publisher";
            // 
            // txtPrevious
            // 
            this.txtPrevious.Location = new System.Drawing.Point(126, 145);
            this.txtPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrevious.Name = "txtPrevious";
            this.txtPrevious.Size = new System.Drawing.Size(213, 25);
            this.txtPrevious.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(8, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // txtMusicid
            // 
            this.txtMusicid.Location = new System.Drawing.Point(126, 81);
            this.txtMusicid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusicid.Name = "txtMusicid";
            this.txtMusicid.Size = new System.Drawing.Size(213, 25);
            this.txtMusicid.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label.Location = new System.Drawing.Point(8, 87);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 19);
            this.label.TabIndex = 4;
            this.label.Text = "Author";
            // 
            // txtCustid
            // 
            this.txtCustid.Location = new System.Drawing.Point(126, 50);
            this.txtCustid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustid.Name = "txtCustid";
            this.txtCustid.Size = new System.Drawing.Size(213, 25);
            this.txtCustid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtListid
            // 
            this.txtListid.Location = new System.Drawing.Point(126, 19);
            this.txtListid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtListid.Name = "txtListid";
            this.txtListid.Size = new System.Drawing.Size(213, 25);
            this.txtListid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "BookID";
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInsert.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnInsert.Location = new System.Drawing.Point(14, 248);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(170, 32);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "추가";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnUpdate.Location = new System.Drawing.Point(197, 248);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(170, 32);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "변경";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Location = new System.Drawing.Point(14, 288);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 32);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTextBoxClear
            // 
            this.btnTextBoxClear.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTextBoxClear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTextBoxClear.Location = new System.Drawing.Point(197, 288);
            this.btnTextBoxClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTextBoxClear.Name = "btnTextBoxClear";
            this.btnTextBoxClear.Size = new System.Drawing.Size(170, 32);
            this.btnTextBoxClear.TabIndex = 10;
            this.btnTextBoxClear.Text = "Clear";
            this.btnTextBoxClear.UseVisualStyleBackColor = true;
            this.btnTextBoxClear.Click += new System.EventHandler(this.btnTextBoxClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(64, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "도서 테이블을 선택하셨습니다";
            // 
            // txtNext
            // 
            this.txtNext.Location = new System.Drawing.Point(137, 174);
            this.txtNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNext.Name = "txtNext";
            this.txtNext.Size = new System.Drawing.Size(213, 25);
            this.txtNext.TabIndex = 9;
            // 
            // PlaylistAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTextBoxClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlaylistAs";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.PlaylistAs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrevious;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMusicid;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtCustid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtListid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTextBoxClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPresent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNext;
    }
}