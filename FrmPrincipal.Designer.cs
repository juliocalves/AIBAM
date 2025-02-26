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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1 = new MenuStrip();
            arquivoToolStripMenuItem = new ToolStripMenuItem();
            novaToolStripMenuItem = new ToolStripMenuItem();
            exibirModelosItemAItemToolStripMenuItem = new ToolStripMenuItem();
            listaDeModelosToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            livreToolStripMenuItem = new ToolStripMenuItem();
            ferramentasToolStripMenuItem = new ToolStripMenuItem();
            personalizarToolStripMenuItem = new ToolStripMenuItem();
            opçõesToolStripMenuItem = new ToolStripMenuItem();
            produtosToolStripMenuItem = new ToolStripMenuItem();
            novoProdutoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            catalogoToolStripMenuItem = new ToolStripMenuItem();
            colecaoToolStripMenuItem = new ToolStripMenuItem();
            listaProdutosToolStripMenuItem = new ToolStripMenuItem();
            produtoToolStripMenuItem = new ToolStripMenuItem();
            publicoAlvoToolStripMenuItem = new ToolStripMenuItem();
            chatParametrizadoToolStripMenuItem = new ToolStripMenuItem();
            copyWriterToolStripMenuItem = new ToolStripMenuItem();
            ajudaToolStripMenuItem = new ToolStripMenuItem();
            sumárioToolStripMenuItem = new ToolStripMenuItem();
            índiceToolStripMenuItem = new ToolStripMenuItem();
            pesquisarToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            webToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            openFileDialog1 = new OpenFileDialog();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 639);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1062, 22);
            statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { arquivoToolStripMenuItem, ferramentasToolStripMenuItem, produtosToolStripMenuItem, chatParametrizadoToolStripMenuItem, ajudaToolStripMenuItem, webToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1062, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novaToolStripMenuItem, exibirModelosItemAItemToolStripMenuItem, listaDeModelosToolStripMenuItem, toolStripSeparator4, livreToolStripMenuItem });
            arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            arquivoToolStripMenuItem.Size = new Size(65, 20);
            arquivoToolStripMenuItem.Text = "&Modelos";
            // 
            // novaToolStripMenuItem
            // 
            novaToolStripMenuItem.Image = (Image)resources.GetObject("novaToolStripMenuItem.Image");
            novaToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            novaToolStripMenuItem.Name = "novaToolStripMenuItem";
            novaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            novaToolStripMenuItem.Size = new Size(214, 22);
            novaToolStripMenuItem.Text = "&Novo Modelo";
            novaToolStripMenuItem.Click += novaToolStripMenuItem_Click;
            // 
            // exibirModelosItemAItemToolStripMenuItem
            // 
            exibirModelosItemAItemToolStripMenuItem.Name = "exibirModelosItemAItemToolStripMenuItem";
            exibirModelosItemAItemToolStripMenuItem.Size = new Size(214, 22);
            exibirModelosItemAItemToolStripMenuItem.Text = "&Exibir Modelos Item a Item";
            exibirModelosItemAItemToolStripMenuItem.Click += exibirModelosItemAItemToolStripMenuItem_Click;
            // 
            // listaDeModelosToolStripMenuItem
            // 
            listaDeModelosToolStripMenuItem.Name = "listaDeModelosToolStripMenuItem";
            listaDeModelosToolStripMenuItem.Size = new Size(214, 22);
            listaDeModelosToolStripMenuItem.Text = "&Lista de Modelos";
            listaDeModelosToolStripMenuItem.Click += listaDeModelosToolStripMenuItem_Click_1;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(211, 6);
            // 
            // livreToolStripMenuItem
            // 
            livreToolStripMenuItem.Name = "livreToolStripMenuItem";
            livreToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            livreToolStripMenuItem.Size = new Size(214, 22);
            livreToolStripMenuItem.Text = "&Livre";
            livreToolStripMenuItem.Click += livreToolStripMenuItem_Click;
            // 
            // ferramentasToolStripMenuItem
            // 
            ferramentasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { personalizarToolStripMenuItem, opçõesToolStripMenuItem });
            ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            ferramentasToolStripMenuItem.Size = new Size(84, 20);
            ferramentasToolStripMenuItem.Text = "&Ferramentas";
            // 
            // personalizarToolStripMenuItem
            // 
            personalizarToolStripMenuItem.Name = "personalizarToolStripMenuItem";
            personalizarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.P;
            personalizarToolStripMenuItem.Size = new Size(231, 22);
            personalizarToolStripMenuItem.Text = "&Personalizar";
            // 
            // opçõesToolStripMenuItem
            // 
            opçõesToolStripMenuItem.Image = Properties.Resources.engrenagens;
            opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            opçõesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.C;
            opçõesToolStripMenuItem.Size = new Size(231, 22);
            opçõesToolStripMenuItem.Text = "&Configurações  ...";
            opçõesToolStripMenuItem.Click += opçõesToolStripMenuItem_Click;
            // 
            // produtosToolStripMenuItem
            // 
            produtosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoProdutoToolStripMenuItem, toolStripSeparator1, catalogoToolStripMenuItem, colecaoToolStripMenuItem, listaProdutosToolStripMenuItem, produtoToolStripMenuItem, publicoAlvoToolStripMenuItem });
            produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            produtosToolStripMenuItem.Size = new Size(67, 20);
            produtosToolStripMenuItem.Text = "&Produtos";
            // 
            // novoProdutoToolStripMenuItem
            // 
            novoProdutoToolStripMenuItem.Image = Properties.Resources.novo_arquivo;
            novoProdutoToolStripMenuItem.Name = "novoProdutoToolStripMenuItem";
            novoProdutoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            novoProdutoToolStripMenuItem.Size = new Size(222, 22);
            novoProdutoToolStripMenuItem.Text = "&Novo Produto";
            novoProdutoToolStripMenuItem.Click += novoProdutoToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(219, 6);
            // 
            // catalogoToolStripMenuItem
            // 
            catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
            catalogoToolStripMenuItem.Size = new Size(222, 22);
            catalogoToolStripMenuItem.Text = "&Catalogo";
            catalogoToolStripMenuItem.Click += catalogoToolStripMenuItem_Click;
            // 
            // colecaoToolStripMenuItem
            // 
            colecaoToolStripMenuItem.Name = "colecaoToolStripMenuItem";
            colecaoToolStripMenuItem.Size = new Size(222, 22);
            colecaoToolStripMenuItem.Text = "&Colecao";
            colecaoToolStripMenuItem.Click += colecaoToolStripMenuItem_Click;
            // 
            // listaProdutosToolStripMenuItem
            // 
            listaProdutosToolStripMenuItem.Name = "listaProdutosToolStripMenuItem";
            listaProdutosToolStripMenuItem.Size = new Size(222, 22);
            listaProdutosToolStripMenuItem.Text = "Lista Produtos";
            listaProdutosToolStripMenuItem.Click += listaProdutosToolStripMenuItem_Click;
            // 
            // produtoToolStripMenuItem
            // 
            produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            produtoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            produtoToolStripMenuItem.Size = new Size(222, 22);
            produtoToolStripMenuItem.Text = "&Produto";
            produtoToolStripMenuItem.Click += produtoToolStripMenuItem_Click;
            // 
            // publicoAlvoToolStripMenuItem
            // 
            publicoAlvoToolStripMenuItem.Name = "publicoAlvoToolStripMenuItem";
            publicoAlvoToolStripMenuItem.Size = new Size(222, 22);
            publicoAlvoToolStripMenuItem.Text = "&Publico Alvo";
            publicoAlvoToolStripMenuItem.Click += publicoAlvoToolStripMenuItem_Click;
            // 
            // chatParametrizadoToolStripMenuItem
            // 
            chatParametrizadoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyWriterToolStripMenuItem });
            chatParametrizadoToolStripMenuItem.Name = "chatParametrizadoToolStripMenuItem";
            chatParametrizadoToolStripMenuItem.Size = new Size(64, 20);
            chatParametrizadoToolStripMenuItem.Text = "&Prompts";
            // 
            // copyWriterToolStripMenuItem
            // 
            copyWriterToolStripMenuItem.Name = "copyWriterToolStripMenuItem";
            copyWriterToolStripMenuItem.Size = new Size(134, 22);
            copyWriterToolStripMenuItem.Text = "&CopyWriter";
            copyWriterToolStripMenuItem.Click += copyWriterToolStripMenuItem_Click;
            // 
            // ajudaToolStripMenuItem
            // 
            ajudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sumárioToolStripMenuItem, índiceToolStripMenuItem, pesquisarToolStripMenuItem, toolStripSeparator7, sobreToolStripMenuItem });
            ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            ajudaToolStripMenuItem.Size = new Size(50, 20);
            ajudaToolStripMenuItem.Text = "&Ajuda";
            // 
            // sumárioToolStripMenuItem
            // 
            sumárioToolStripMenuItem.Name = "sumárioToolStripMenuItem";
            sumárioToolStripMenuItem.Size = new Size(124, 22);
            sumárioToolStripMenuItem.Text = "&Sumário";
            // 
            // índiceToolStripMenuItem
            // 
            índiceToolStripMenuItem.Name = "índiceToolStripMenuItem";
            índiceToolStripMenuItem.Size = new Size(124, 22);
            índiceToolStripMenuItem.Text = "&Índice";
            // 
            // pesquisarToolStripMenuItem
            // 
            pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            pesquisarToolStripMenuItem.Size = new Size(124, 22);
            pesquisarToolStripMenuItem.Text = "&Pesquisar";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(121, 6);
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(124, 22);
            sobreToolStripMenuItem.Text = "&Sobre...";
            // 
            // webToolStripMenuItem
            // 
            webToolStripMenuItem.Name = "webToolStripMenuItem";
            webToolStripMenuItem.Size = new Size(43, 20);
            webToolStripMenuItem.Text = "&Web";
            webToolStripMenuItem.Click += webToolStripMenuItem_Click;
            // 
            // toolTip1
            // 
            toolTip1.BackColor = Color.Ivory;
            toolTip1.IsBalloon = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1062, 661);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.On;
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private SaveFileDialog saveFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem novaToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ferramentasToolStripMenuItem;
        private ToolStripMenuItem personalizarToolStripMenuItem;
        private ToolStripMenuItem opçõesToolStripMenuItem;
        private ToolStripMenuItem ajudaToolStripMenuItem;
        private ToolStripMenuItem sumárioToolStripMenuItem;
        private ToolStripMenuItem índiceToolStripMenuItem;
        private ToolStripMenuItem pesquisarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ChatControl chatControl;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WebControl webControl;
        private ToolStripMenuItem produtosToolStripMenuItem;
        private ToolStripMenuItem catalogoToolStripMenuItem;
        private ToolStripMenuItem publicoAlvoToolStripMenuItem;
        private ToolStripMenuItem produtoToolStripMenuItem;
        private ToolStripMenuItem chatParametrizadoToolStripMenuItem;
        private ToolStripMenuItem copyWriterToolStripMenuItem;
        private ToolStripMenuItem colecaoToolStripMenuItem;
        private ToolStripMenuItem webToolStripMenuItem;
        private ToolStripMenuItem listaProdutosToolStripMenuItem;
        private ToolStripMenuItem livreToolStripMenuItem;
        private ToolStripMenuItem listaDeModelosToolStripMenuItem;
        private ToolStripMenuItem exibirModelosItemAItemToolStripMenuItem;
        private ToolStripMenuItem novoProdutoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}