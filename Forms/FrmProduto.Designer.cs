namespace AIBAM.Forms
{
    partial class FrmProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduto));
            btnExcluir = new Button();
            btnProximo = new Button();
            btnAnterior = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            produtoControl1 = new AIBAM.Controles.ProdutoControl();
            toolStrip4 = new ToolStrip();
            novaToolStripButton1 = new ToolStripButton();
            abrirToolStripButton1 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnSalvarAlteracoes = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnCancelar = new Button();
            splitContainer1 = new SplitContainer();
            toolStrip2 = new ToolStrip();
            btnSugestaoDescricao = new ToolStripButton();
            btnSugestaoTags = new ToolStripButton();
            btnPesquisarProdutosSimilares = new ToolStripButton();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            btnAdiconarImagem = new ToolStripButton();
            btnImgAnterior = new ToolStripButton();
            btnImgProximo = new ToolStripButton();
            btnExcluirImg = new ToolStripButton();
            groupBox1.SuspendLayout();
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.ForeColor = SystemColors.ControlLightLight;
            btnExcluir.Location = new Point(1014, -1);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 6;
            btnExcluir.TabStop = false;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnProximo
            // 
            btnProximo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProximo.Location = new Point(1177, 0);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 4;
            btnProximo.Text = "PRÓXIMO";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Enabled = false;
            btnAnterior.Location = new Point(1087, 0);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 5;
            btnAnterior.Text = "ANTERIOR";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LavenderBlush;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Location = new Point(3, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(483, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(189, 15);
            label1.TabIndex = 7;
            label1.Text = "PROCURAR PRODUTO POR NOME";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(produtoControl1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1081, 236);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFORMAÇÃO GERAL PRODUTO";
            // 
            // produtoControl1
            // 
            produtoControl1.Location = new Point(3, 17);
            produtoControl1.Name = "produtoControl1";
            produtoControl1.Size = new Size(1067, 203);
            produtoControl1.TabIndex = 1;
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, toolStripButton1, btnEditar });
            toolStrip4.Location = new Point(1156, 14);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(95, 25);
            toolStrip4.TabIndex = 10;
            toolStrip4.Text = "toolStrip4";
            // 
            // novaToolStripButton1
            // 
            novaToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            novaToolStripButton1.Image = (Image)resources.GetObject("novaToolStripButton1.Image");
            novaToolStripButton1.ImageTransparentColor = Color.Magenta;
            novaToolStripButton1.Name = "novaToolStripButton1";
            novaToolStripButton1.Size = new Size(23, 22);
            novaToolStripButton1.Text = "&Novo Produto";
            novaToolStripButton1.ToolTipText = "Novo Produto";
            novaToolStripButton1.Click += novaToolStripButton1_Click;
            // 
            // abrirToolStripButton1
            // 
            abrirToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton1.Image = (Image)resources.GetObject("abrirToolStripButton1.Image");
            abrirToolStripButton1.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton1.Name = "abrirToolStripButton1";
            abrirToolStripButton1.Size = new Size(23, 22);
            abrirToolStripButton1.Text = "$Abrir Produto";
            abrirToolStripButton1.ToolTipText = "Abrir Produto";
            abrirToolStripButton1.Click += abrirToolStripButton1_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.copia_de;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "&DUPLICAR PRODUTO";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Image = Properties.Resources.editar;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(23, 22);
            btnEditar.Text = "toolStripButton2";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnSalvarAlteracoes
            // 
            btnSalvarAlteracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarAlteracoes.BackColor = Color.DarkOliveGreen;
            btnSalvarAlteracoes.ForeColor = SystemColors.ControlLight;
            btnSalvarAlteracoes.Location = new Point(1097, 0);
            btnSalvarAlteracoes.Name = "btnSalvarAlteracoes";
            btnSalvarAlteracoes.Size = new Size(156, 23);
            btnSalvarAlteracoes.TabIndex = 11;
            btnSalvarAlteracoes.Text = "SALVAR ALTERAÇÕES";
            btnSalvarAlteracoes.UseVisualStyleBackColor = false;
            btnSalvarAlteracoes.Visible = false;
            btnSalvarAlteracoes.Click += btnSalvarAlteracoes_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(939, 4);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 14;
            label2.Text = "de";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox2.Enabled = false;
            textBox2.Location = new Point(892, 0);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.RightToLeft = RightToLeft.Yes;
            textBox2.Size = new Size(41, 23);
            textBox2.TabIndex = 15;
            textBox2.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox3.Enabled = false;
            textBox3.Location = new Point(965, 0);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.RightToLeft = RightToLeft.Yes;
            textBox3.Size = new Size(41, 23);
            textBox3.TabIndex = 16;
            textBox3.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(1011, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
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
            splitContainer1.Panel1.Controls.Add(toolStrip2);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1256, 313);
            splitContainer1.SplitterDistance = 44;
            splitContainer1.TabIndex = 18;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new ToolStripItem[] { btnSugestaoDescricao, btnSugestaoTags, btnPesquisarProdutosSimilares });
            toolStrip2.Location = new Point(489, 19);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.RenderMode = ToolStripRenderMode.System;
            toolStrip2.Size = new Size(103, 25);
            toolStrip2.TabIndex = 9;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnSugestaoDescricao
            // 
            btnSugestaoDescricao.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSugestaoDescricao.Enabled = false;
            btnSugestaoDescricao.Image = Properties.Resources.palavra_chave__1_;
            btnSugestaoDescricao.ImageTransparentColor = Color.Magenta;
            btnSugestaoDescricao.Name = "btnSugestaoDescricao";
            btnSugestaoDescricao.Size = new Size(23, 22);
            btnSugestaoDescricao.Text = "&Sugestão Descrição";
            btnSugestaoDescricao.Click += btnSugestaoDescricao_Click;
            // 
            // btnSugestaoTags
            // 
            btnSugestaoTags.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSugestaoTags.Enabled = false;
            btnSugestaoTags.Image = Properties.Resources.palavra_chave;
            btnSugestaoTags.ImageTransparentColor = Color.Magenta;
            btnSugestaoTags.Name = "btnSugestaoTags";
            btnSugestaoTags.Size = new Size(23, 22);
            btnSugestaoTags.Text = "&Sugestão Tags";
            btnSugestaoTags.Click += btnSugestaoTags_Click;
            // 
            // btnPesquisarProdutosSimilares
            // 
            btnPesquisarProdutosSimilares.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPesquisarProdutosSimilares.Enabled = false;
            btnPesquisarProdutosSimilares.Image = Properties.Resources.procurar1;
            btnPesquisarProdutosSimilares.ImageTransparentColor = Color.Magenta;
            btnPesquisarProdutosSimilares.Name = "btnPesquisarProdutosSimilares";
            btnPesquisarProdutosSimilares.Size = new Size(23, 22);
            btnPesquisarProdutosSimilares.Text = "&Pesquisa Produtos Similares";
            btnPesquisarProdutosSimilares.Click += btnPesquisarProdutosSimilares_Click;
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
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = SystemColors.Control;
            splitContainer2.Panel2.Controls.Add(btnCancelar);
            splitContainer2.Panel2.Controls.Add(btnAnterior);
            splitContainer2.Panel2.Controls.Add(textBox3);
            splitContainer2.Panel2.Controls.Add(btnProximo);
            splitContainer2.Panel2.Controls.Add(btnSalvarAlteracoes);
            splitContainer2.Panel2.Controls.Add(btnExcluir);
            splitContainer2.Panel2.Controls.Add(textBox2);
            splitContainer2.Panel2.Controls.Add(label2);
            splitContainer2.Size = new Size(1256, 265);
            splitContainer2.SplitterDistance = 236;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(groupBox1);
            splitContainer3.Size = new Size(1256, 236);
            splitContainer3.SplitterDistance = 171;
            splitContainer3.TabIndex = 10;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(toolStrip1);
            splitContainer4.Size = new Size(171, 236);
            splitContainer4.SplitterDistance = 207;
            splitContainer4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 207);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdiconarImagem, btnImgAnterior, btnImgProximo, btnExcluirImg });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(171, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdiconarImagem
            // 
            btnAdiconarImagem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdiconarImagem.Image = Properties.Resources.adicionar_imagem;
            btnAdiconarImagem.ImageTransparentColor = Color.Magenta;
            btnAdiconarImagem.Name = "btnAdiconarImagem";
            btnAdiconarImagem.Size = new Size(23, 22);
            btnAdiconarImagem.Text = "&Adicionar Imagen(s)";
            btnAdiconarImagem.Click += btnAdiconarImagem_Click;
            // 
            // btnImgAnterior
            // 
            btnImgAnterior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImgAnterior.Image = Properties.Resources.anterior;
            btnImgAnterior.ImageTransparentColor = Color.Magenta;
            btnImgAnterior.Name = "btnImgAnterior";
            btnImgAnterior.Size = new Size(23, 22);
            btnImgAnterior.Text = "&Anterior";
            btnImgAnterior.Click += btnImgAnterior_Click;
            // 
            // btnImgProximo
            // 
            btnImgProximo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImgProximo.Image = Properties.Resources.proximo_botao;
            btnImgProximo.ImageTransparentColor = Color.Magenta;
            btnImgProximo.Name = "btnImgProximo";
            btnImgProximo.Size = new Size(23, 22);
            btnImgProximo.Text = "&Próximo";
            btnImgProximo.Click += btnImgProximo_Click;
            // 
            // btnExcluirImg
            // 
            btnExcluirImg.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluirImg.Image = Properties.Resources.excluir_imagem;
            btnExcluirImg.ImageTransparentColor = Color.Magenta;
            btnExcluirImg.Name = "btnExcluirImg";
            btnExcluirImg.Size = new Size(23, 22);
            btnExcluirImg.Text = "&Excluir Imagem";
            btnExcluirImg.Click += btnExcluirImg_Click;
            // 
            // FrmProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 313);
            Controls.Add(toolStrip4);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FrmProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Produtos";
            Load += FrmProduto_Load;
            SizeChanged += FrmProduto_SizeChanged;
            KeyDown += FrmProduto_KeyDown;
            groupBox1.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnExcluir;
        private Button btnProximo;
        private Button btnAnterior;
        private TextBox textBox1;
        private Label label1;
        private GroupBox groupBox1;
        private AIBAM.Controles.ProdutoControl produtoControl1;
        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private Button btnSalvarAlteracoes;
        private ToolStripButton toolStripButton1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private ToolStripButton btnEditar;
        private Button btnCancelar;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnAdiconarImagem;
        private ToolStripButton btnImgAnterior;
        private ToolStripButton btnImgProximo;
        private ToolStripButton btnExcluirImg;
        private ToolStrip toolStrip2;
        private ToolStripButton btnSugestaoDescricao;
        private ToolStripButton btnSugestaoTags;
        private ToolStripButton btnPesquisarProdutosSimilares;
    }
}