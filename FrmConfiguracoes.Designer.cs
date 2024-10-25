namespace AIBAM
{
    partial class FrmConfiguracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracoes));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnCriarEstrutura = new Button();
            btnDefinirDiretorio = new Button();
            txtDiretorioRaiz = new TextBox();
            label1 = new Label();
            imageList1 = new ImageList(components);
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 450);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.AccessibleRole = AccessibleRole.ToolTip;
            tabPage1.Controls.Add(btnCriarEstrutura);
            tabPage1.Controls.Add(btnDefinirDiretorio);
            tabPage1.Controls.Add(txtDiretorioRaiz);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(27, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(772, 442);
            tabPage1.TabIndex = 0;
            tabPage1.ToolTipText = "CONF DIRETORIO";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCriarEstrutura
            // 
            btnCriarEstrutura.Image = Properties.Resources.pasta;
            btnCriarEstrutura.Location = new Point(399, 16);
            btnCriarEstrutura.Name = "btnCriarEstrutura";
            btnCriarEstrutura.Size = new Size(38, 30);
            btnCriarEstrutura.TabIndex = 5;
            btnCriarEstrutura.UseVisualStyleBackColor = true;
            btnCriarEstrutura.Click += btnCriarEstrutura_Click;
            // 
            // btnDefinirDiretorio
            // 
            btnDefinirDiretorio.Image = Properties.Resources.pasta__1_;
            btnDefinirDiretorio.Location = new Point(361, 16);
            btnDefinirDiretorio.Name = "btnDefinirDiretorio";
            btnDefinirDiretorio.Size = new Size(38, 30);
            btnDefinirDiretorio.TabIndex = 4;
            btnDefinirDiretorio.UseVisualStyleBackColor = true;
            btnDefinirDiretorio.Click += btnDefinirDiretorio_Click;
            // 
            // txtDiretorioRaiz
            // 
            txtDiretorioRaiz.Enabled = false;
            txtDiretorioRaiz.Location = new Point(2, 21);
            txtDiretorioRaiz.Name = "txtDiretorioRaiz";
            txtDiretorioRaiz.Size = new Size(358, 23);
            txtDiretorioRaiz.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "Diretorio raiz";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "diretorio-raiz.png");
            // 
            // FrmConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmConfiguracoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CONFIGURAÇÕES";
            Load += FrmConfiguracoes_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private ImageList imageList1;
        private TextBox txtDiretorioRaiz;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnDefinirDiretorio;
        private Button btnCriarEstrutura;
    }
}