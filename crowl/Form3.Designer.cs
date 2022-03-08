namespace crowl
{
    partial class Form3
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.제품명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.버전번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.버전 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.지원닷넷프레임워크버젼 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.출시일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(563, 327);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(195, 55);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "탐색";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.제품명,
            this.버전번호,
            this.버전,
            this.지원닷넷프레임워크버젼,
            this.출시일,
            this.코드명});
            this.dataGridView1.Location = new System.Drawing.Point(73, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(604, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // 제품명
            // 
            this.제품명.HeaderText = "Column1";
            this.제품명.Name = "제품명";
            // 
            // 버전번호
            // 
            this.버전번호.HeaderText = "버전 번호";
            this.버전번호.Name = "버전번호";
            // 
            // 버전
            // 
            this.버전.HeaderText = "Column1";
            this.버전.Name = "버전";
            // 
            // 지원닷넷프레임워크버젼
            // 
            this.지원닷넷프레임워크버젼.HeaderText = "지원닷넷프레임워크버젼";
            this.지원닷넷프레임워크버젼.Name = "지원닷넷프레임워크버젼";
            // 
            // 출시일
            // 
            this.출시일.HeaderText = "출시일";
            this.출시일.Name = "출시일";
            // 
            // 코드명
            // 
            this.코드명.HeaderText = "코드명";
            this.코드명.Name = "코드명";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearch);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제품명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 버전번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 버전;
        private System.Windows.Forms.DataGridViewTextBoxColumn 지원닷넷프레임워크버젼;
        private System.Windows.Forms.DataGridViewTextBoxColumn 출시일;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드명;
    }
}