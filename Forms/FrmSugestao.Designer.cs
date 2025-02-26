namespace AIBAM.Forms
{
    partial class FrmSugestao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSugestao));
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            label1 = new Label();
            btnCancelar = new Button();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnCancelar);
            splitContainer1.Panel2.Controls.Add(progressBar1);
            splitContainer1.Size = new Size(838, 450);
            splitContainer1.SplitterDistance = 417;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(webView);
            splitContainer2.Size = new Size(838, 417);
            splitContainer2.SplitterDistance = 25;
            splitContainer2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(838, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.configuracoes1;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "&Configurações Sugestão";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.ai;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "&Gerar Mais";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Fill;
            webView.Location = new Point(0, 0);
            webView.Name = "webView";
            webView.Size = new Size(838, 388);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(686, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 29);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Left;
            progressBar1.ForeColor = SystemColors.GradientInactiveCaption;
            progressBar1.Location = new Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(490, 29);
            progressBar1.TabIndex = 4;
            // 
            // FrmSugestao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 450);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSugestao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSugestao";
            Load += FrmSugestao_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnCancelar;
        private SplitContainer splitContainer2;
        private Label label1;
        private ProgressBar progressBar1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
    }
}