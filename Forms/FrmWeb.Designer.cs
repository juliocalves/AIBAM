namespace AIBAM.Forms
{
    partial class FrmWeb
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeb));
            splitContainer2 = new SplitContainer();
            panel1 = new Panel();
            txtUrl = new TextBox();
            btnRefresh = new Button();
            btnProximo = new Button();
            btnAnterior = new Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            btnFecharGuia = new Button();
            btnNovo = new Button();
            button1 = new Button();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnFechar = new Button();
            toolTip = new ToolTip(components);
            splitContainer3 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.ControlLightLight;
            splitContainer2.Panel1.Controls.Add(panel1);
            splitContainer2.Panel1.Controls.Add(btnRefresh);
            splitContainer2.Panel1.Controls.Add(btnProximo);
            splitContainer2.Panel1.Controls.Add(btnAnterior);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
            splitContainer2.Panel2.Controls.Add(webView);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(txtUrl);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // txtUrl
            // 
            txtUrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUrl.BackColor = Color.White;
            txtUrl.BorderStyle = BorderStyle.None;
            resources.ApplyResources(txtUrl, "txtUrl");
            txtUrl.Name = "txtUrl";
            txtUrl.KeyDown += txtUrl_KeyDown;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            resources.ApplyResources(btnRefresh, "btnRefresh");
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Image = Properties.Resources.recarregando;
            btnRefresh.Name = "btnRefresh";
            toolTip.SetToolTip(btnRefresh, resources.GetString("btnRefresh.ToolTip"));
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnProximo
            // 
            btnProximo.BackColor = Color.Transparent;
            resources.ApplyResources(btnProximo, "btnProximo");
            btnProximo.FlatAppearance.BorderSize = 0;
            btnProximo.Image = Properties.Resources.proximo_botao;
            btnProximo.Name = "btnProximo";
            toolTip.SetToolTip(btnProximo, resources.GetString("btnProximo.ToolTip"));
            btnProximo.UseVisualStyleBackColor = false;
            btnProximo.Click += btnProximo_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = Color.Transparent;
            resources.ApplyResources(btnAnterior, "btnAnterior");
            btnAnterior.FlatAppearance.BorderSize = 0;
            btnAnterior.Image = Properties.Resources.anterior;
            btnAnterior.Name = "btnAnterior";
            toolTip.SetToolTip(btnAnterior, resources.GetString("btnAnterior.ToolTip"));
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.BackColor = SystemColors.ControlLightLight;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            resources.ApplyResources(webView, "webView");
            webView.Name = "webView";
            webView.ZoomFactor = 1D;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ControlLightLight;
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AllowDrop = true;
            splitContainer1.Panel1.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel1.Controls.Add(btnFecharGuia);
            splitContainer1.Panel1.Controls.Add(btnNovo);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(btnMinimizar);
            splitContainer1.Panel1.Controls.Add(btnMaximizar);
            splitContainer1.Panel1.Controls.Add(btnFechar);
            splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            // 
            // btnFecharGuia
            // 
            btnFecharGuia.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnFecharGuia.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnFecharGuia, "btnFecharGuia");
            btnFecharGuia.Name = "btnFecharGuia";
            toolTip.SetToolTip(btnFecharGuia, resources.GetString("btnFecharGuia.ToolTip"));
            btnFecharGuia.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.Transparent;
            resources.ApplyResources(btnNovo, "btnNovo");
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.Image = Properties.Resources.adicionar1;
            btnNovo.Name = "btnNovo";
            toolTip.SetToolTip(btnNovo, resources.GetString("btnNovo.ToolTip"));
            btnNovo.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            resources.ApplyResources(button1, "button1");
            button1.FlatAppearance.BorderSize = 0;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            resources.ApplyResources(btnMinimizar, "btnMinimizar");
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.UseVisualStyleBackColor = false;
            // 
            // btnMaximizar
            // 
            btnMaximizar.BackColor = Color.Transparent;
            resources.ApplyResources(btnMaximizar, "btnMaximizar");
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Transparent;
            resources.ApplyResources(btnFechar, "btnFechar");
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Name = "btnFechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // splitContainer3
            // 
            resources.ApplyResources(splitContainer3, "splitContainer3");
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(statusStrip1);
            // 
            // FrmWeb
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer3);
            KeyPreview = true;
            Name = "FrmWeb";
            TransparencyKey = Color.FromArgb(128, 128, 255);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private TextBox txtUrl;
        private Button btnRefresh;
        private Button btnProximo;
        private Button btnAnterior;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private SplitContainer splitContainer1;
        private Button btnMinimizar;
        private Button btnMaximizar;
        private Button btnFechar;
        private Button btnFecharGuia;
        private Button btnNovo;
        private Button button1;
        private ToolTip toolTip;
        private SplitContainer splitContainer3;
    }
}