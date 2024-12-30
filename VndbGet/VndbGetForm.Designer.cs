namespace VndbGet
{
    partial class VndbGetForm
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
            urlTextBox = new TextBox();
            sendButton = new Button();
            fieldsTextBox = new TextBox();
            urlLabel = new Label();
            fieldsLabel = new Label();
            vndbStatusStrip = new StatusStrip();
            vndbToolStripStatusLabel = new ToolStripStatusLabel();
            iDTextBox = new TextBox();
            iDsLabel = new Label();
            vndbStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // urlTextBox
            // 
            urlTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextBox.Location = new Point(12, 32);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Size = new Size(550, 27);
            urlTextBox.TabIndex = 0;
            urlTextBox.Text = "https://api.vndb.org/kana/vn";
            // 
            // sendButton
            // 
            sendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sendButton.Location = new Point(420, 407);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(142, 29);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send and Save";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += SendButton_Click;
            // 
            // fieldsTextBox
            // 
            fieldsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fieldsTextBox.Location = new Point(12, 85);
            fieldsTextBox.Name = "fieldsTextBox";
            fieldsTextBox.Size = new Size(550, 27);
            fieldsTextBox.TabIndex = 2;
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(12, 9);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(30, 20);
            urlLabel.TabIndex = 3;
            urlLabel.Text = "Url";
            // 
            // fieldsLabel
            // 
            fieldsLabel.AutoSize = true;
            fieldsLabel.Location = new Point(12, 62);
            fieldsLabel.Name = "fieldsLabel";
            fieldsLabel.Size = new Size(51, 20);
            fieldsLabel.TabIndex = 4;
            fieldsLabel.Text = "Fields";
            // 
            // vndbStatusStrip
            // 
            vndbStatusStrip.ImageScalingSize = new Size(20, 20);
            vndbStatusStrip.Items.AddRange(new ToolStripItem[] { vndbToolStripStatusLabel });
            vndbStatusStrip.Location = new Point(0, 439);
            vndbStatusStrip.Name = "vndbStatusStrip";
            vndbStatusStrip.Size = new Size(574, 26);
            vndbStatusStrip.TabIndex = 5;
            vndbStatusStrip.Text = "statusStrip1";
            // 
            // vndbToolStripStatusLabel
            // 
            vndbToolStripStatusLabel.Name = "vndbToolStripStatusLabel";
            vndbToolStripStatusLabel.Size = new Size(223, 20);
            vndbToolStripStatusLabel.Text = "Hey you, You're finally awake.";
            // 
            // iDTextBox
            // 
            iDTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iDTextBox.Location = new Point(12, 138);
            iDTextBox.Multiline = true;
            iDTextBox.Name = "iDTextBox";
            iDTextBox.Size = new Size(550, 263);
            iDTextBox.TabIndex = 6;
            // 
            // iDsLabel
            // 
            iDsLabel.AutoSize = true;
            iDsLabel.Location = new Point(12, 115);
            iDsLabel.Name = "iDsLabel";
            iDsLabel.Size = new Size(31, 20);
            iDsLabel.TabIndex = 7;
            iDsLabel.Text = "IDs";
            // 
            // VndbGetForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 465);
            Controls.Add(iDsLabel);
            Controls.Add(iDTextBox);
            Controls.Add(vndbStatusStrip);
            Controls.Add(fieldsLabel);
            Controls.Add(urlLabel);
            Controls.Add(fieldsTextBox);
            Controls.Add(sendButton);
            Controls.Add(urlTextBox);
            Name = "VndbGetForm";
            Text = "VndbGet";
            Load += VndbGetForm_Load;
            vndbStatusStrip.ResumeLayout(false);
            vndbStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox urlTextBox;
        private Button sendButton;
        private TextBox fieldsTextBox;
        private StatusStrip vndbStatusStrip;
        private ToolStripStatusLabel vndbToolStripStatusLabel;
        private TextBox iDTextBox;
        private Label urlLabel;
        private Label fieldsLabel;
        private Label iDsLabel;
    }
}
