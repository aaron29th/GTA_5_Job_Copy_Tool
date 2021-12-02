namespace GTA_5_Job_Copy_Tool
{
	partial class mainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.connectBtn = new System.Windows.Forms.Button();
			this.attachBtn = new System.Windows.Forms.Button();
			this.contentIdsTextbox = new System.Windows.Forms.RichTextBox();
			this.copyBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.outputTextbox = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tmapiRadio = new System.Windows.Forms.RadioButton();
			this.ccapiRadio = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// connectBtn
			// 
			this.connectBtn.Location = new System.Drawing.Point(104, 12);
			this.connectBtn.Name = "connectBtn";
			this.connectBtn.Size = new System.Drawing.Size(142, 36);
			this.connectBtn.TabIndex = 0;
			this.connectBtn.Text = "Connect";
			this.connectBtn.UseVisualStyleBackColor = true;
			this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
			// 
			// attachBtn
			// 
			this.attachBtn.Location = new System.Drawing.Point(104, 54);
			this.attachBtn.Name = "attachBtn";
			this.attachBtn.Size = new System.Drawing.Size(142, 36);
			this.attachBtn.TabIndex = 1;
			this.attachBtn.Text = "Attach / Enable RPC";
			this.attachBtn.UseVisualStyleBackColor = true;
			this.attachBtn.Click += new System.EventHandler(this.attachBtn_Click);
			// 
			// contentIdsTextbox
			// 
			this.contentIdsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.contentIdsTextbox.Location = new System.Drawing.Point(12, 118);
			this.contentIdsTextbox.Name = "contentIdsTextbox";
			this.contentIdsTextbox.Size = new System.Drawing.Size(234, 205);
			this.contentIdsTextbox.TabIndex = 2;
			this.contentIdsTextbox.Text = "";
			// 
			// copyBtn
			// 
			this.copyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.copyBtn.Location = new System.Drawing.Point(12, 329);
			this.copyBtn.Name = "copyBtn";
			this.copyBtn.Size = new System.Drawing.Size(234, 23);
			this.copyBtn.TabIndex = 3;
			this.copyBtn.Text = "Copy";
			this.copyBtn.UseVisualStyleBackColor = true;
			this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Content IDs (one per line)";
			// 
			// outputTextbox
			// 
			this.outputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.outputTextbox.Location = new System.Drawing.Point(252, 12);
			this.outputTextbox.Name = "outputTextbox";
			this.outputTextbox.ReadOnly = true;
			this.outputTextbox.Size = new System.Drawing.Size(287, 340);
			this.outputTextbox.TabIndex = 5;
			this.outputTextbox.Text = "";
			this.outputTextbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.outputTextbox_LinkClicked);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ccapiRadio);
			this.groupBox1.Controls.Add(this.tmapiRadio);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(86, 78);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection";
			// 
			// tmapiRadio
			// 
			this.tmapiRadio.AutoSize = true;
			this.tmapiRadio.Checked = true;
			this.tmapiRadio.Location = new System.Drawing.Point(6, 19);
			this.tmapiRadio.Name = "tmapiRadio";
			this.tmapiRadio.Size = new System.Drawing.Size(58, 17);
			this.tmapiRadio.TabIndex = 0;
			this.tmapiRadio.TabStop = true;
			this.tmapiRadio.Text = "TMAPI";
			this.tmapiRadio.UseVisualStyleBackColor = true;
			// 
			// ccapiRadio
			// 
			this.ccapiRadio.AutoSize = true;
			this.ccapiRadio.Location = new System.Drawing.Point(6, 52);
			this.ccapiRadio.Name = "ccapiRadio";
			this.ccapiRadio.Size = new System.Drawing.Size(56, 17);
			this.ccapiRadio.TabIndex = 1;
			this.ccapiRadio.Text = "CCAPI";
			this.ccapiRadio.UseVisualStyleBackColor = true;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(550, 362);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.outputTextbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.copyBtn);
			this.Controls.Add(this.contentIdsTextbox);
			this.Controls.Add(this.attachBtn);
			this.Controls.Add(this.connectBtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "mainForm";
			this.Text = "GTA 5 Job Copy Tool";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button connectBtn;
		private System.Windows.Forms.Button attachBtn;
		private System.Windows.Forms.RichTextBox contentIdsTextbox;
		private System.Windows.Forms.Button copyBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox outputTextbox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton ccapiRadio;
		private System.Windows.Forms.RadioButton tmapiRadio;
	}
}

