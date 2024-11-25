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
            btnSalvarAlteracoes = new Button();
            groupBox1.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.ForeColor = SystemColors.ControlLightLight;
            btnExcluir.Location = new Point(732, 309);
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
            btnProximo.Location = new Point(894, 309);
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
            btnAnterior.Location = new Point(813, 309);
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
            textBox1.Location = new Point(12, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(483, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(189, 15);
            label1.TabIndex = 7;
            label1.Text = "PROCURAR PRODUTO POR NOME";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(produtoControl1);
            groupBox1.Location = new Point(-1, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(979, 237);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFORMAÇÃO GERAL PRODUTO";
            // 
            // produtoControl1
            // 
            produtoControl1.Location = new Point(3, 17);
            produtoControl1.Name = "produtoControl1";
            produtoControl1.Size = new Size(972, 203);
            produtoControl1.TabIndex = 1;
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1 });
            toolStrip4.Location = new Point(894, 30);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(80, 25);
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
            novaToolStripButton1.ToolTipText = "Novo Publico Produto";
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
            // btnSalvarAlteracoes
            // 
            btnSalvarAlteracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarAlteracoes.BackColor = Color.DarkOliveGreen;
            btnSalvarAlteracoes.ForeColor = SystemColors.ControlLight;
            btnSalvarAlteracoes.Location = new Point(813, 309);
            btnSalvarAlteracoes.Name = "btnSalvarAlteracoes";
            btnSalvarAlteracoes.Size = new Size(156, 23);
            btnSalvarAlteracoes.TabIndex = 11;
            btnSalvarAlteracoes.Text = "SALVAR ALTERAÇÕES";
            btnSalvarAlteracoes.UseVisualStyleBackColor = false;
            btnSalvarAlteracoes.Visible = false;
            btnSalvarAlteracoes.Click += btnSalvarAlteracoes_Click;
            // 
            // FrmProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 344);
            Controls.Add(toolStrip4);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(btnExcluir);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(btnSalvarAlteracoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Produtos";
            Load += FrmProduto_Load;
            KeyDown += FrmProduto_KeyDown;
            groupBox1.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
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
    }
}