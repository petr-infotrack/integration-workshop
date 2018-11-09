namespace WF_Auth0_Lab
{
    partial class frmMainTest
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
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.btnRefreshAuth = new System.Windows.Forms.Button();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(628, 26);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(96, 31);
            this.btnAuthorize.TabIndex = 0;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAuth
            // 
            this.btnRefreshAuth.Location = new System.Drawing.Point(628, 105);
            this.btnRefreshAuth.Name = "btnRefreshAuth";
            this.btnRefreshAuth.Size = new System.Drawing.Size(96, 31);
            this.btnRefreshAuth.TabIndex = 1;
            this.btnRefreshAuth.Text = "Refresh";
            this.btnRefreshAuth.UseVisualStyleBackColor = true;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(636, 72);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAutoRefresh.Size = new System.Drawing.Size(88, 17);
            this.chkAutoRefresh.TabIndex = 2;
            this.chkAutoRefresh.Text = "Auto Refresh";
            this.chkAutoRefresh.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(45, 192);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(490, 108);
            this.txtResponse.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Response";
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(45, 42);
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(490, 94);
            this.txtRequest.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Request";
            // 
            // frmMainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.btnRefreshAuth);
            this.Controls.Add(this.btnAuthorize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMainTest";
            this.Text = "Auth0 - TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Button btnRefreshAuth;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.Label label2;
    }
}

