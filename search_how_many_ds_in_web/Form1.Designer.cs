namespace search_how_many_ds_in_web
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.feedback = new System.Windows.Forms.TextBox();
            this.lable_notice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(513, 375);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "开始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // txtpath
            // 
            this.txtpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpath.Location = new System.Drawing.Point(12, 45);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(576, 21);
            this.txtpath.TabIndex = 1;
            this.txtpath.Text = "url.ini";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "包含URL的文件地址：";
            // 
            // feedback
            // 
            this.feedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feedback.Location = new System.Drawing.Point(12, 90);
            this.feedback.Multiline = true;
            this.feedback.Name = "feedback";
            this.feedback.ReadOnly = true;
            this.feedback.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.feedback.Size = new System.Drawing.Size(576, 279);
            this.feedback.TabIndex = 3;
            // 
            // lable_notice
            // 
            this.lable_notice.AutoSize = true;
            this.lable_notice.Location = new System.Drawing.Point(10, 386);
            this.lable_notice.Name = "lable_notice";
            this.lable_notice.Size = new System.Drawing.Size(359, 12);
            this.lable_notice.TabIndex = 2;
            this.lable_notice.Text = "说明：URL为应用的完整URL，执行完毕后将内容复制到excel中即可";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 410);
            this.Controls.Add(this.feedback);
            this.Controls.Add(this.lable_notice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.start);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "应用所含数据流统计";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox feedback;
        private System.Windows.Forms.Label lable_notice;
    }
}

