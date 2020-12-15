namespace iworking
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
            this.components = new System.ComponentModel.Container();
            this.dtLastInput = new System.Windows.Forms.DateTimePicker();
            this.labelLastInput = new System.Windows.Forms.Label();
            this.timerNoInput = new System.Windows.Forms.Timer(this.components);
            this.labelStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dtLastInput
            // 
            this.dtLastInput.Enabled = false;
            this.dtLastInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtLastInput.Location = new System.Drawing.Point(116, -6);
            this.dtLastInput.Name = "dtLastInput";
            this.dtLastInput.ShowUpDown = true;
            this.dtLastInput.Size = new System.Drawing.Size(134, 21);
            this.dtLastInput.TabIndex = 0;
            this.dtLastInput.Visible = false;
            // 
            // labelLastInput
            // 
            this.labelLastInput.AutoSize = true;
            this.labelLastInput.Location = new System.Drawing.Point(12, 0);
            this.labelLastInput.Name = "labelLastInput";
            this.labelLastInput.Size = new System.Drawing.Size(67, 13);
            this.labelLastInput.TabIndex = 1;
            this.labelLastInput.Text = "Last Time";
            this.labelLastInput.Visible = false;
            // 
            // timerNoInput
            // 
            this.timerNoInput.Interval = 1000;
            this.timerNoInput.Tick += new System.EventHandler(this.TimerNoInput_Tick);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(12, 27);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(69, 13);
            this.labelStart.TabIndex = 3;
            this.labelStart.Text = "Start Time";
            // 
            // dtStart
            // 
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStart.Location = new System.Drawing.Point(116, 21);
            this.dtStart.Name = "dtStart";
            this.dtStart.ShowUpDown = true;
            this.dtStart.Size = new System.Drawing.Size(134, 21);
            this.dtStart.TabIndex = 2;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(12, 54);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(65, 13);
            this.labelEnd.TabIndex = 5;
            this.labelEnd.Text = "End Time";
            // 
            // dtEnd
            // 
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEnd.Location = new System.Drawing.Point(116, 48);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ShowUpDown = true;
            this.dtEnd.Size = new System.Drawing.Size(134, 21);
            this.dtEnd.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(273, 89);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.labelLastInput);
            this.Controls.Add(this.dtLastInput);
            this.Name = "FormMain";
            this.Text = "i working";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtLastInput;
        private System.Windows.Forms.Label labelLastInput;
        private System.Windows.Forms.Timer timerNoInput;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dtEnd;
    }
}

