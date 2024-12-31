namespace AIBAM.Controles
{
    partial class ProdutoControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutoControl));
            cboGrupoProd = new ComboBox();
            label7 = new Label();
            cboCategoriaProd = new ComboBox();
            label6 = new Label();
            txtDescricao = new TextBox();
            label5 = new Label();
            txtLinkProd = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtNomeProd = new TextBox();
            label1 = new Label();
            toolStrip4 = new ToolStrip();
            btnLimpar = new ToolStripButton();
            btnSalvar = new ToolStripButton();
            btnAplicarMarkup = new ToolStripButton();
            txtCusto = new TextBox();
            txtVenda = new TextBox();
            adicionarListaControl1 = new AdicionarListaControl();
            checkBox1 = new CheckBox();
            txtVrPromo = new TextBox();
            label8 = new Label();
            txtDesc = new TextBox();
            label9 = new Label();
            txtLuc = new TextBox();
            label10 = new Label();
            lblId = new Label();
            txtDescontoPix = new TextBox();
            label11 = new Label();
            txtLucroComPix = new TextBox();
            label12 = new Label();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // cboGrupoProd
            // 
            cboGrupoProd.BackColor = Color.LavenderBlush;
            cboGrupoProd.FormattingEnabled = true;
            cboGrupoProd.Location = new Point(11, 160);
            cboGrupoProd.Name = "cboGrupoProd";
            cboGrupoProd.Size = new Size(332, 23);
            cboGrupoProd.TabIndex = 7;
            cboGrupoProd.KeyDown += cboGrupoProd_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 144);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 53;
            label7.Text = "GRUPO";
            // 
            // cboCategoriaProd
            // 
            cboCategoriaProd.BackColor = Color.LavenderBlush;
            cboCategoriaProd.FlatStyle = FlatStyle.System;
            cboCategoriaProd.FormattingEnabled = true;
            cboCategoriaProd.ItemHeight = 15;
            cboCategoriaProd.Items.AddRange(new object[] { "CAMISETA", "CAMISETA ALGODÃO PERUANO", "CAMISETA INFANTIL", "CAMISETA OVERSIZED", "BODY INFANTIL", "CROPPED", "CROPPED MOLETOM", "HOODIE MOLETOM", "REGATA", "SUÉTER MOLETOM", "" });
            cboCategoriaProd.Location = new Point(11, 118);
            cboCategoriaProd.Name = "cboCategoriaProd";
            cboCategoriaProd.Size = new Size(332, 23);
            cboCategoriaProd.TabIndex = 6;
            cboCategoriaProd.SelectedIndexChanged += cboCategoriaProd_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 102);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 52;
            label6.Text = "CATEGORIA";
            // 
            // txtDescricao
            // 
            txtDescricao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescricao.Location = new Point(349, 76);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.ScrollBars = ScrollBars.Vertical;
            txtDescricao.Size = new Size(388, 123);
            txtDescricao.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(348, 58);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 51;
            label5.Text = "DESCRIÇÃO";
            // 
            // txtLinkProd
            // 
            txtLinkProd.Location = new Point(11, 76);
            txtLinkProd.Name = "txtLinkProd";
            txtLinkProd.Size = new Size(335, 23);
            txtLinkProd.TabIndex = 5;
            txtLinkProd.MouseDoubleClick += txtLinkProd_MouseDoubleClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 58);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 50;
            label4.Text = "LINK SITE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(437, 15);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(62, 15);
            label3.TabIndex = 49;
            label3.Text = "VR VENDA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(348, 15);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(44, 15);
            label2.TabIndex = 48;
            label2.Text = "CUSTO";
            // 
            // txtNomeProd
            // 
            txtNomeProd.CharacterCasing = CharacterCasing.Upper;
            txtNomeProd.Location = new Point(10, 33);
            txtNomeProd.Name = "txtNomeProd";
            txtNomeProd.Size = new Size(336, 23);
            txtNomeProd.TabIndex = 1;
            txtNomeProd.Leave += txtNomeProd_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 40;
            label1.Text = "NOME PRODUTO";
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { btnLimpar, btnSalvar, btnAplicarMarkup });
            toolStrip4.Location = new Point(1001, 28);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(72, 25);
            toolStrip4.TabIndex = 54;
            toolStrip4.Text = "toolStrip4";
            // 
            // btnLimpar
            // 
            btnLimpar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLimpar.Image = Properties.Resources.botao_de_deletar;
            btnLimpar.ImageTransparentColor = Color.Magenta;
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(23, 22);
            btnLimpar.Text = "&Limpar Campos";
            btnLimpar.ToolTipText = "Limpar Campos";
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.ImageTransparentColor = Color.Magenta;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(23, 22);
            btnSalvar.Text = "&Salvar";
            btnSalvar.ToolTipText = "Salvar Produto";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAplicarMarkup
            // 
            btnAplicarMarkup.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAplicarMarkup.Image = Properties.Resources.tag;
            btnAplicarMarkup.ImageTransparentColor = Color.Magenta;
            btnAplicarMarkup.Name = "btnAplicarMarkup";
            btnAplicarMarkup.Size = new Size(23, 22);
            btnAplicarMarkup.Text = "&APLICAR MARKUP";
            btnAplicarMarkup.Click += btnAplicarMarkup_Click;
            // 
            // txtCusto
            // 
            txtCusto.Location = new Point(349, 33);
            txtCusto.Name = "txtCusto";
            txtCusto.Size = new Size(80, 23);
            txtCusto.TabIndex = 2;
            txtCusto.TextAlign = HorizontalAlignment.Right;
            txtCusto.TextChanged += txtCusto_TextChanged;
            txtCusto.KeyPress += txtCusto_KeyPress;
            txtCusto.Leave += txtCusto_Leave;
            // 
            // txtVenda
            // 
            txtVenda.Location = new Point(435, 33);
            txtVenda.Name = "txtVenda";
            txtVenda.Size = new Size(80, 23);
            txtVenda.TabIndex = 3;
            txtVenda.TextAlign = HorizontalAlignment.Right;
            txtVenda.KeyPress += txtVenda_KeyPress;
            txtVenda.Leave += txtVenda_Leave;
            // 
            // adicionarListaControl1
            // 
            adicionarListaControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            adicionarListaControl1.Descricao = "TAGS";
            adicionarListaControl1.Location = new Point(743, 58);
            adicionarListaControl1.Name = "adicionarListaControl1";
            adicionarListaControl1.NomeLista = "TAGS_PRODUTO";
            adicionarListaControl1.Size = new Size(326, 154);
            adicionarListaControl1.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(239, 8);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(107, 19);
            checkBox1.TabIndex = 58;
            checkBox1.TabStop = false;
            checkBox1.Text = "DESCONTO PIX";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtVrPromo
            // 
            txtVrPromo.Location = new Point(521, 33);
            txtVrPromo.Name = "txtVrPromo";
            txtVrPromo.Size = new Size(80, 23);
            txtVrPromo.TabIndex = 4;
            txtVrPromo.TextAlign = HorizontalAlignment.Right;
            txtVrPromo.KeyPress += txtVrPromo_KeyPress;
            txtVrPromo.Leave += txtVrPromo_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(520, 15);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.Yes;
            label8.Size = new Size(67, 15);
            label8.TabIndex = 59;
            label8.Text = "VR PROMO";
            // 
            // txtDesc
            // 
            txtDesc.Enabled = false;
            txtDesc.Location = new Point(683, 33);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(100, 23);
            txtDesc.TabIndex = 62;
            txtDesc.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(682, 15);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(45, 15);
            label9.TabIndex = 61;
            label9.Text = "%DESC";
            // 
            // txtLuc
            // 
            txtLuc.Enabled = false;
            txtLuc.Location = new Point(789, 33);
            txtLuc.Name = "txtLuc";
            txtLuc.Size = new Size(100, 23);
            txtLuc.TabIndex = 64;
            txtLuc.TextAlign = HorizontalAlignment.Right;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(788, 15);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(65, 15);
            label10.TabIndex = 63;
            label10.Text = "LUCRO UN";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(14, 2);
            lblId.Name = "lblId";
            lblId.Size = new Size(0, 15);
            lblId.TabIndex = 65;
            lblId.Visible = false;
            // 
            // txtDescontoPix
            // 
            txtDescontoPix.Location = new Point(607, 33);
            txtDescontoPix.Name = "txtDescontoPix";
            txtDescontoPix.Size = new Size(70, 23);
            txtDescontoPix.TabIndex = 5;
            txtDescontoPix.Text = "3,00";
            txtDescontoPix.TextAlign = HorizontalAlignment.Right;
            txtDescontoPix.KeyPress += txtDescontoPix_KeyPress;
            txtDescontoPix.Leave += txtDescontoPix_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(606, 15);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.Yes;
            label11.Size = new Size(68, 15);
            label11.TabIndex = 67;
            label11.Text = "% DESC PIX";
            // 
            // txtLucroComPix
            // 
            txtLucroComPix.Enabled = false;
            txtLucroComPix.Location = new Point(895, 33);
            txtLucroComPix.Name = "txtLucroComPix";
            txtLucroComPix.Size = new Size(100, 23);
            txtLucroComPix.TabIndex = 69;
            txtLucroComPix.TextAlign = HorizontalAlignment.Right;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(894, 15);
            label12.Name = "label12";
            label12.RightToLeft = RightToLeft.Yes;
            label12.Size = new Size(96, 15);
            label12.TabIndex = 68;
            label12.Text = "LUCRO UN C PIX";
            // 
            // ProdutoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtLucroComPix);
            Controls.Add(label12);
            Controls.Add(txtDescontoPix);
            Controls.Add(label11);
            Controls.Add(lblId);
            Controls.Add(txtLuc);
            Controls.Add(label10);
            Controls.Add(txtDesc);
            Controls.Add(label9);
            Controls.Add(txtVrPromo);
            Controls.Add(label8);
            Controls.Add(checkBox1);
            Controls.Add(adicionarListaControl1);
            Controls.Add(txtVenda);
            Controls.Add(txtCusto);
            Controls.Add(toolStrip4);
            Controls.Add(cboGrupoProd);
            Controls.Add(label7);
            Controls.Add(cboCategoriaProd);
            Controls.Add(label6);
            Controls.Add(txtDescricao);
            Controls.Add(label5);
            Controls.Add(txtLinkProd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtNomeProd);
            Controls.Add(label1);
            Name = "ProdutoControl";
            Size = new Size(1073, 218);
            Load += ProdutoControl_Load;
            KeyDown += ProdutoControl_KeyDown;
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboGrupoProd;
        private Label label7;
        private ComboBox cboCategoriaProd;
        private Label label6;
        private TextBox txtDescricao;
        private Label label5;
        private TextBox txtLinkProd;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtNomeProd;
        private Label label1;
        private ToolStrip toolStrip4;
        private ToolStripButton btnLimpar;
        private ToolStripButton btnSalvar;
        private TextBox txtCusto;
        private TextBox txtVenda;
        private AdicionarListaControl adicionarListaControl1;
        private CheckBox checkBox1;
        private TextBox txtVrPromo;
        private Label label8;
        private TextBox txtDesc;
        private Label label9;
        private TextBox txtLuc;
        private Label label10;
        private Label lblId;
        private TextBox txtDescontoPix;
        private Label label11;
        private TextBox txtLucroComPix;
        private Label label12;
        private ToolStripButton btnAplicarMarkup;
    }
}
