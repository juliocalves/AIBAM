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
            lstPrompts = new FlowLayoutPanel();
            btnSalvar = new Button();
            saveFileDialog1 = new SaveFileDialog();
            rTxtResponse = new RichTextBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(696, 484);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(150, 22);
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
            // lstPrompts
            // 
            lstPrompts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstPrompts.Location = new Point(12, 34);
            lstPrompts.Name = "lstPrompts";
            lstPrompts.Size = new Size(831, 418);
            lstPrompts.TabIndex = 2;
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
            // rTxtResponse
            // 
            rTxtResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTxtResponse.Location = new Point(23, 53);
            rTxtResponse.Name = "rTxtResponse";
            rTxtResponse.ReadOnly = true;
            rTxtResponse.Size = new Size(808, 372);
            rTxtResponse.TabIndex = 0;
            rTxtResponse.TabStop = false;
            rTxtResponse.Text = "";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 512);
            Controls.Add(btnSalvar);
            Controls.Add(rTxtResponse);
            Controls.Add(statusStrip1);
            Controls.Add(txtPrompt);
            Controls.Add(lstPrompts);
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
        private FlowLayoutPanel lstPrompts;
        private Button btnSalvar;
        private SaveFileDialog saveFileDialog1;
        private RichTextBox rTxtResponse;
    }
}