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
            TreeNode treeNode1 = new TreeNode("PROMPTS");
            TreeNode treeNode2 = new TreeNode("AIBAM", new TreeNode[] { treeNode1 });
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracoes));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            treeView1 = new TreeView();
            toolStrip1 = new ToolStrip();
            abrirToolStripButton = new ToolStripButton();
            salvarToolStripButton = new ToolStripButton();
            txtDiretorioRaiz = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            imageList1 = new ImageList(components);
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(448, 450);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.AccessibleRole = AccessibleRole.ToolTip;
            tabPage1.Controls.Add(treeView1);
            tabPage1.Controls.Add(toolStrip1);
            tabPage1.Controls.Add(txtDiretorioRaiz);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(440, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "DIRETORIOS";
            tabPage1.ToolTipText = "CONF DIRETORIO";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            treeView1.HotTracking = true;
            treeView1.Location = new Point(3, 50);
            treeView1.Name = "treeView1";
            treeNode1.Name = "PROMPTS";
            treeNode1.Text = "PROMPTS";
            treeNode2.Name = "AIBAM";
            treeNode2.Text = "AIBAM";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeView1.Size = new Size(409, 97);
            treeView1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { abrirToolStripButton, salvarToolStripButton });
            toolStrip1.Location = new Point(363, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(49, 25);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // abrirToolStripButton
            // 
            abrirToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton.Image = (Image)resources.GetObject("abrirToolStripButton.Image");
            abrirToolStripButton.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton.Name = "abrirToolStripButton";
            abrirToolStripButton.Size = new Size(23, 22);
            abrirToolStripButton.Text = "&Definir Diretorio Raiz";
            abrirToolStripButton.Click += abrirToolStripButton_Click;
            // 
            // salvarToolStripButton
            // 
            salvarToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton.Image = (Image)resources.GetObject("salvarToolStripButton.Image");
            salvarToolStripButton.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton.Name = "salvarToolStripButton";
            salvarToolStripButton.Size = new Size(23, 22);
            salvarToolStripButton.Text = "&Salvar Diretorio";
            salvarToolStripButton.Click += salvarToolStripButton_Click;
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
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(440, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "MODELOS IA";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "diretorio-raiz (1).png");
            // 
            // FrmConfiguracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 450);
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
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private ImageList imageList1;
        private TextBox txtDiretorioRaiz;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolStrip toolStrip1;
        private ToolStripButton abrirToolStripButton;
        private ToolStripButton salvarToolStripButton;
        private TreeView treeView1;
        private TabPage tabPage2;
    }
}