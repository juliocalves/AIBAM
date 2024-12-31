namespace AIBAM.Forms
{
    partial class FrmWebView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWebView));
            splitContainer1 = new SplitContainer();
            btnNovo = new Button();
            button1 = new Button();
            btnMinimizar = new Button();
            btnMaximizar = new Button();
            btnFechar = new Button();
            splitContainer2 = new SplitContainer();
            panel1 = new Panel();
            txtUrl = new TextBox();
            btnRefresh = new Button();
            btnProximo = new Button();
            btnAnterior = new Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnFecharGuia = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnFecharGuia);
            splitContainer1.Panel1.Controls.Add(btnNovo);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(btnMinimizar);
            splitContainer1.Panel1.Controls.Add(btnMaximizar);
            splitContainer1.Panel1.Controls.Add(btnFechar);
            resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
            splitContainer1.Panel1.MouseDown += splitContainer1_Panel1_MouseDown;
            splitContainer1.Panel1.MouseMove += splitContainer1_Panel1_MouseMove;
            splitContainer1.Panel1.MouseUp += splitContainer1_Panel1_MouseUp;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.Transparent;
            resources.ApplyResources(btnNovo, "btnNovo");
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.Image = Properties.Resources.adicionar1;
            btnNovo.Name = "btnNovo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            resources.ApplyResources(button1, "button1");
            button1.FlatAppearance.BorderSize = 0;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            resources.ApplyResources(btnMinimizar, "btnMinimizar");
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.BackColor = Color.Transparent;
            resources.ApplyResources(btnMaximizar, "btnMaximizar");
            btnMaximizar.FlatAppearance.BorderSize = 0;
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.UseVisualStyleBackColor = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Transparent;
            resources.ApplyResources(btnFechar, "btnFechar");
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Name = "btnFechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel1);
            splitContainer2.Panel1.Controls.Add(btnRefresh);
            splitContainer2.Panel1.Controls.Add(btnProximo);
            splitContainer2.Panel1.Controls.Add(btnAnterior);
            // 
            // splitContainer2.Panel2
            // 
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
            resources.ApplyResources(txtUrl, "txtUrl");
            txtUrl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUrl.BackColor = Color.White;
            txtUrl.Name = "txtUrl";
            txtUrl.KeyDown += txtUrl_KeyDown;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            resources.ApplyResources(btnRefresh, "btnRefresh");
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Image = Properties.Resources.seta_esquerda;
            btnRefresh.Name = "btnRefresh";
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
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            resources.ApplyResources(webView, "webView");
            webView.Name = "webView";
            webView.ZoomFactor = 1D;
            webView.Resize += FrmWebView_Resize;
            // 
            // btnFecharGuia
            // 
            btnFecharGuia.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnFecharGuia.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnFecharGuia, "btnFecharGuia");
            btnFecharGuia.Name = "btnFecharGuia";
            btnFecharGuia.UseVisualStyleBackColor = true;
            // 
            // FrmWebView
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "FrmWebView";
            MouseDown += FrmWebView_MouseDown;
            MouseMove += FrmWebView_MouseMove;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private Button btnFechar;
        private Button btnMinimizar;
        private Button btnMaximizar;
        private SplitContainer splitContainer2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Button btnRefresh;
        private Button btnProximo;
        private Button btnAnterior;
        private Panel panel1;
        private TextBox txtUrl;
        private Button button1;
        private Button btnNovo;
        private Button btnFecharGuia;
    }
}