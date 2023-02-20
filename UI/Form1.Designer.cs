namespace UI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.webcamBtn = new System.Windows.Forms.Button();
            this.fileBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 401);
            this.panel1.TabIndex = 0;
            // 
            // webcamBtn
            // 
            this.webcamBtn.Location = new System.Drawing.Point(12, 424);
            this.webcamBtn.Name = "webcamBtn";
            this.webcamBtn.Size = new System.Drawing.Size(75, 23);
            this.webcamBtn.TabIndex = 1;
            this.webcamBtn.Text = "Webcam";
            this.webcamBtn.UseVisualStyleBackColor = true;
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(93, 424);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(75, 23);
            this.fileBtn.TabIndex = 1;
            this.fileBtn.Text = "File";
            this.fileBtn.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(174, 424);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 459);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.webcamBtn);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Brand Brigade Task";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button webcamBtn;
        private Button fileBtn;
        private Button stopBtn;
    }
}