namespace AIBAM
{
    partial class FrmPrincipal
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
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            txtPrompt = new TextBox();
            btnSalvar = new Button();
            saveFileDialog1 = new SaveFileDialog();
            chatControl = new ChatControl();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(727, 484);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(119, 22);
            statusStrip1.TabIndex = 0;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // txtPrompt
            // 
            txtPrompt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPrompt.Location = new Point(12, 458);
            txtPrompt.Name = "txtPrompt";
            txtPrompt.PlaceholderText = "Comando ";
            txtPrompt.Size = new Size(831, 23);
            txtPrompt.TabIndex = 1;
            txtPrompt.KeyDown += txtPrompt_KeyDown;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvar.Location = new Point(768, 5);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // chatControl
            // 
            chatControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatControl.BackColor = Color.White;
            chatControl.Location = new Point(12, 34);
            chatControl.Name = "chatControl";
            chatControl.Size = new Size(831, 415);
            chatControl.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 512);
            Controls.Add(chatControl);
            Controls.Add(btnSalvar);
            Controls.Add(statusStrip1);
            Controls.Add(txtPrompt);
            Name = "FrmPrincipal";
            Text = "AIBAM";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private TextBox txtPrompt;
        private ToolStripProgressBar toolStripProgressBar1;
        private Button btnSalvar;
        private SaveFileDialog saveFileDialog1;
        private FlowLayoutPanel lstPrompts;
        private ChatControl chatControl;
    }
}