
namespace Vision
{
    partial class FormMain
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
            this.ImageBoxLoad = new Vision.ImageBox();
            this.buttonImageLoad = new System.Windows.Forms.Button();
            this.buttonImageSave = new System.Windows.Forms.Button();
            this.ImageBoxConvert = new Vision.ImageBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxRotateFlip = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonURL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxConvert)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageBoxLoad
            // 
            this.ImageBoxLoad.AutoFill = false;
            this.ImageBoxLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBoxLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBoxLoad.Image = null;
            this.ImageBoxLoad.Location = new System.Drawing.Point(3, 3);
            this.ImageBoxLoad.Name = "ImageBoxLoad";
            this.ImageBoxLoad.Size = new System.Drawing.Size(705, 752);
            this.ImageBoxLoad.TabIndex = 0;
            this.ImageBoxLoad.TabStop = false;
            // 
            // buttonImageLoad
            // 
            this.buttonImageLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImageLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImageLoad.Location = new System.Drawing.Point(3, 3);
            this.buttonImageLoad.Name = "buttonImageLoad";
            this.buttonImageLoad.Size = new System.Drawing.Size(230, 39);
            this.buttonImageLoad.TabIndex = 1;
            this.buttonImageLoad.Text = "이미지";
            this.buttonImageLoad.UseVisualStyleBackColor = true;
            // 
            // buttonImageSave
            // 
            this.buttonImageSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImageSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImageSave.Location = new System.Drawing.Point(358, 3);
            this.buttonImageSave.Name = "buttonImageSave";
            this.buttonImageSave.Size = new System.Drawing.Size(350, 39);
            this.buttonImageSave.TabIndex = 2;
            this.buttonImageSave.Text = "저장";
            this.buttonImageSave.UseVisualStyleBackColor = true;
            // 
            // ImageBoxConvert
            // 
            this.ImageBoxConvert.AutoFill = false;
            this.ImageBoxConvert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBoxConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBoxConvert.Image = null;
            this.ImageBoxConvert.Location = new System.Drawing.Point(714, 3);
            this.ImageBoxConvert.Name = "ImageBoxConvert";
            this.ImageBoxConvert.Size = new System.Drawing.Size(705, 752);
            this.ImageBoxConvert.TabIndex = 6;
            this.ImageBoxConvert.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ImageBoxConvert, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ImageBoxLoad, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1422, 803);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.buttonURL, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonImageLoad, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxRotateFlip, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 758);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(711, 45);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // comboBoxRotateFlip
            // 
            this.comboBoxRotateFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRotateFlip.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxRotateFlip.FormattingEnabled = true;
            this.comboBoxRotateFlip.Location = new System.Drawing.Point(475, 3);
            this.comboBoxRotateFlip.Name = "comboBoxRotateFlip";
            this.comboBoxRotateFlip.Size = new System.Drawing.Size(233, 39);
            this.comboBoxRotateFlip.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.comboBoxType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonImageSave, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(711, 758);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(711, 45);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(3, 3);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(349, 39);
            this.comboBoxType.TabIndex = 8;
            // 
            // buttonURL
            // 
            this.buttonURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonURL.Location = new System.Drawing.Point(239, 3);
            this.buttonURL.Name = "buttonURL";
            this.buttonURL.Size = new System.Drawing.Size(230, 39);
            this.buttonURL.TabIndex = 3;
            this.buttonURL.Text = "URL";
            this.buttonURL.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1422, 803);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxConvert)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Vision.ImageBox ImageBoxLoad;
        private System.Windows.Forms.Button buttonImageLoad;
        private System.Windows.Forms.Button buttonImageSave;
        private Vision.ImageBox ImageBoxConvert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBoxRotateFlip;
        private System.Windows.Forms.Button buttonURL;
    }
}

