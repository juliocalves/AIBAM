namespace AIBAM
{
    partial class FrmCatalogoProdServ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCatalogoProdServ));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStrip4 = new ToolStrip();
            novaToolStripButton1 = new ToolStripButton();
            abrirToolStripButton1 = new ToolStripButton();
            salvarToolStripButton1 = new ToolStripButton();
            btnLimpar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            txtQtdProdutos = new TextBox();
            label7 = new Label();
            label6 = new Label();
            dtCriacao = new DateTimePicker();
            chkAtivoInativo = new CheckBox();
            txtLucroMedio = new TextBox();
            label4 = new Label();
            txtCustoMedio = new TextBox();
            label3 = new Label();
            label21 = new Label();
            txtDescricao = new TextBox();
            toolStrip1 = new ToolStrip();
            toolStripButton4 = new ToolStripButton();
            btnVerPublicoAlvo = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            txtNomePublicoAlvo = new TextBox();
            label2 = new Label();
            txtNomeCatalogo = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            toolStrip2 = new ToolStrip();
            toolStripButton7 = new ToolStripButton();
            toolStripButton8 = new ToolStripButton();
            btnListarProdutos = new ToolStripButton();
            btnExcluir = new Button();
            btnProximo = new Button();
            btnAnterior = new Button();
            dgvProdutos = new DataGridView();
            select = new DataGridViewCheckBoxColumn();
            id = new DataGridViewTextBoxColumn();
            prodNome = new DataGridViewTextBoxColumn();
            custoProd = new DataGridViewTextBoxColumn();
            vrVendaProd = new DataGridViewTextBoxColumn();
            vrPromo = new DataGridViewTextBoxColumn();
            pDesconto = new DataGridViewTextBoxColumn();
            pix = new DataGridViewCheckBoxColumn();
            vrLucro = new DataGridViewTextBoxColumn();
            linkProd = new DataGridViewTextBoxColumn();
            catProd = new DataGridViewTextBoxColumn();
            grupoProd = new DataGridViewTextBoxColumn();
            descricao = new DataGridViewTextBoxColumn();
            tags = new DataGridViewTextBoxColumn();
            btnSalvarAlteracoes = new Button();
            label5 = new Label();
            txtPesquisaCatalogo = new TextBox();
            toolStrip3 = new ToolStrip();
            imprimirToolStripButton = new ToolStripButton();
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, salvarToolStripButton1, btnLimpar });
            toolStrip4.Location = new Point(889, 9);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(95, 25);
            toolStrip4.TabIndex = 4;
            toolStrip4.Text = "toolStrip4";
            // 
            // novaToolStripButton1
            // 
            novaToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            novaToolStripButton1.Image = (Image)resources.GetObject("novaToolStripButton1.Image");
            novaToolStripButton1.ImageTransparentColor = Color.Magenta;
            novaToolStripButton1.Name = "novaToolStripButton1";
            novaToolStripButton1.Size = new Size(23, 22);
            novaToolStripButton1.Text = "&Novo";
            novaToolStripButton1.ToolTipText = "Novo Catalogo";
            novaToolStripButton1.Click += novaToolStripButton1_Click;
            // 
            // abrirToolStripButton1
            // 
            abrirToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton1.Image = (Image)resources.GetObject("abrirToolStripButton1.Image");
            abrirToolStripButton1.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton1.Name = "abrirToolStripButton1";
            abrirToolStripButton1.Size = new Size(23, 22);
            abrirToolStripButton1.Text = "&Abrir";
            abrirToolStripButton1.ToolTipText = "Abrir Catalogo";
            abrirToolStripButton1.Click += abrirToolStripButton1_Click;
            // 
            // salvarToolStripButton1
            // 
            salvarToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton1.Image = (Image)resources.GetObject("salvarToolStripButton1.Image");
            salvarToolStripButton1.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton1.Name = "salvarToolStripButton1";
            salvarToolStripButton1.Size = new Size(23, 22);
            salvarToolStripButton1.Text = "&Salvar";
            salvarToolStripButton1.ToolTipText = "Salvar Catalogo";
            salvarToolStripButton1.Click += salvarToolStripButton1_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLimpar.Image = Properties.Resources.botao_de_deletar;
            btnLimpar.ImageTransparentColor = Color.Magenta;
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(23, 22);
            btnLimpar.Text = "&Limpar Catalogo";
            btnLimpar.Click += btnLimpar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 55);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Control;
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(987, 426);
            splitContainer1.SplitterDistance = 110;
            splitContainer1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtQtdProdutos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtCriacao);
            groupBox1.Controls.Add(chkAtivoInativo);
            groupBox1.Controls.Add(txtLucroMedio);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtCustoMedio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(toolStrip4);
            groupBox1.Controls.Add(txtDescricao);
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Controls.Add(txtNomePublicoAlvo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNomeCatalogo);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(987, 110);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ESPECIFICAÇÕES DE CATALOGO";
            // 
            // txtQtdProdutos
            // 
            txtQtdProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtQtdProdutos.BackColor = Color.LavenderBlush;
            txtQtdProdutos.Enabled = false;
            txtQtdProdutos.Location = new Point(750, 83);
            txtQtdProdutos.Name = "txtQtdProdutos";
            txtQtdProdutos.RightToLeft = RightToLeft.Yes;
            txtQtdProdutos.Size = new Size(133, 23);
            txtQtdProdutos.TabIndex = 17;
            txtQtdProdutos.TabStop = false;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(752, 65);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 16;
            label7.Text = "QTD PRODUTOS";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(889, 65);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 15;
            label6.Text = "DATA CRIAÇÃO";
            // 
            // dtCriacao
            // 
            dtCriacao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtCriacao.Enabled = false;
            dtCriacao.Format = DateTimePickerFormat.Short;
            dtCriacao.Location = new Point(889, 83);
            dtCriacao.Name = "dtCriacao";
            dtCriacao.Size = new Size(92, 23);
            dtCriacao.TabIndex = 14;
            dtCriacao.TabStop = false;
            // 
            // chkAtivoInativo
            // 
            chkAtivoInativo.AutoSize = true;
            chkAtivoInativo.Checked = true;
            chkAtivoInativo.CheckState = CheckState.Checked;
            chkAtivoInativo.Location = new Point(792, 41);
            chkAtivoInativo.Name = "chkAtivoInativo";
            chkAtivoInativo.Size = new Size(59, 19);
            chkAtivoInativo.TabIndex = 3;
            chkAtivoInativo.Text = "ATIVO";
            chkAtivoInativo.UseVisualStyleBackColor = true;
            // 
            // txtLucroMedio
            // 
            txtLucroMedio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLucroMedio.BackColor = Color.LavenderBlush;
            txtLucroMedio.Enabled = false;
            txtLucroMedio.Location = new Point(584, 83);
            txtLucroMedio.Name = "txtLucroMedio";
            txtLucroMedio.RightToLeft = RightToLeft.Yes;
            txtLucroMedio.Size = new Size(160, 23);
            txtLucroMedio.TabIndex = 13;
            txtLucroMedio.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(586, 65);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 12;
            label4.Text = "LUCRO MÉDIO";
            // 
            // txtCustoMedio
            // 
            txtCustoMedio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustoMedio.BackColor = Color.LavenderBlush;
            txtCustoMedio.Enabled = false;
            txtCustoMedio.Location = new Point(418, 83);
            txtCustoMedio.Name = "txtCustoMedio";
            txtCustoMedio.RightToLeft = RightToLeft.Yes;
            txtCustoMedio.Size = new Size(160, 23);
            txtCustoMedio.TabIndex = 11;
            txtCustoMedio.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(420, 65);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 10;
            label3.Text = "CUSTO MÉDIO";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(311, 16);
            label21.Name = "label21";
            label21.Size = new Size(70, 15);
            label21.TabIndex = 9;
            label21.Text = "DESCRIÇÃO";
            // 
            // txtDescricao
            // 
            txtDescricao.BackColor = Color.LavenderBlush;
            txtDescricao.CharacterCasing = CharacterCasing.Upper;
            txtDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescricao.Location = new Point(311, 37);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(475, 23);
            txtDescricao.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton4, btnVerPublicoAlvo, toolStripButton6, toolStripButton5 });
            toolStrip1.Location = new Point(308, 81);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(95, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(23, 22);
            toolStripButton4.Text = "&Definir Publico Alvo";
            toolStripButton4.ToolTipText = "Definir Publico Alvo";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // btnVerPublicoAlvo
            // 
            btnVerPublicoAlvo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnVerPublicoAlvo.Enabled = false;
            btnVerPublicoAlvo.Image = Properties.Resources.visualizar;
            btnVerPublicoAlvo.ImageTransparentColor = Color.Magenta;
            btnVerPublicoAlvo.Name = "btnVerPublicoAlvo";
            btnVerPublicoAlvo.Size = new Size(23, 22);
            btnVerPublicoAlvo.Text = "&Ver Publico Alvo";
            btnVerPublicoAlvo.Click += btnBuscarPublicoAlvo_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(23, 22);
            toolStripButton6.Text = "&Novo Publico Alvo";
            toolStripButton6.ToolTipText = "Novo Publico Alvo";
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Enabled = false;
            toolStripButton5.Image = Properties.Resources.botao_de_deletar;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(23, 22);
            toolStripButton5.Text = "&Remover Publico Alvo";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // txtNomePublicoAlvo
            // 
            txtNomePublicoAlvo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomePublicoAlvo.BackColor = Color.LavenderBlush;
            txtNomePublicoAlvo.Enabled = false;
            txtNomePublicoAlvo.Location = new Point(3, 83);
            txtNomePublicoAlvo.Name = "txtNomePublicoAlvo";
            txtNomePublicoAlvo.Size = new Size(302, 23);
            txtNomePublicoAlvo.TabIndex = 3;
            txtNomePublicoAlvo.TabStop = false;
            txtNomePublicoAlvo.TextChanged += txtNomePublicoAlvo_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 65);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 2;
            label2.Text = "PÚBLICO ALVO";
            // 
            // txtNomeCatalogo
            // 
            txtNomeCatalogo.BackColor = Color.LavenderBlush;
            txtNomeCatalogo.Location = new Point(3, 37);
            txtNomeCatalogo.Name = "txtNomeCatalogo";
            txtNomeCatalogo.Size = new Size(302, 23);
            txtNomeCatalogo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "NOME";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(toolStrip2);
            groupBox2.Controls.Add(btnExcluir);
            groupBox2.Controls.Add(btnProximo);
            groupBox2.Controls.Add(btnAnterior);
            groupBox2.Controls.Add(dgvProdutos);
            groupBox2.Controls.Add(btnSalvarAlteracoes);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(987, 312);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "LISTA PRODUTOS";
            // 
            // toolStrip2
            // 
            toolStrip2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton7, toolStripButton8, btnListarProdutos });
            toolStrip2.Location = new Point(908, 9);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.RenderMode = ToolStripRenderMode.Professional;
            toolStrip2.Size = new Size(72, 25);
            toolStrip2.TabIndex = 13;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = Properties.Resources.visualizar;
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(23, 22);
            toolStripButton7.Text = "&Ver Produto";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(23, 22);
            toolStripButton8.Text = "&Novo Produto";
            toolStripButton8.ToolTipText = "Novo Produto";
            toolStripButton8.Click += toolStripButton8_Click;
            // 
            // btnListarProdutos
            // 
            btnListarProdutos.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnListarProdutos.Image = Properties.Resources.lista;
            btnListarProdutos.ImageTransparentColor = Color.Magenta;
            btnListarProdutos.Name = "btnListarProdutos";
            btnListarProdutos.Size = new Size(23, 22);
            btnListarProdutos.Text = "&LISTAR TODOS PRODUTOS";
            btnListarProdutos.Click += btnListarProdutos_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.ForeColor = SystemColors.ControlLightLight;
            btnExcluir.Location = new Point(741, 274);
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
            btnProximo.Location = new Point(903, 274);
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
            btnAnterior.Location = new Point(822, 274);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 5;
            btnAnterior.Text = "ANTERIOR";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToOrderColumns = true;
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.BackgroundColor = SystemColors.ButtonHighlight;
            dgvProdutos.BorderStyle = BorderStyle.None;
            dgvProdutos.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Columns.AddRange(new DataGridViewColumn[] { select, id, prodNome, custoProd, vrVendaProd, vrPromo, pDesconto, pix, vrLucro, linkProd, catProd, grupoProd, descricao, tags });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProdutos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProdutos.Location = new Point(9, 37);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(971, 231);
            dgvProdutos.TabIndex = 0;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            dgvProdutos.CellValueChanged += dgvProdutos_CellValueChanged;
            dgvProdutos.KeyDown += dgvProdutos_KeyDown;
            dgvProdutos.MouseDoubleClick += dgvProdutos_MouseDoubleClick;
            // 
            // select
            // 
            select.HeaderText = "";
            select.Name = "select";
            select.Width = 30;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // prodNome
            // 
            prodNome.HeaderText = "NOME";
            prodNome.Name = "prodNome";
            prodNome.ReadOnly = true;
            // 
            // custoProd
            // 
            custoProd.HeaderText = "CUSTO";
            custoProd.Name = "custoProd";
            custoProd.ReadOnly = true;
            // 
            // vrVendaProd
            // 
            vrVendaProd.HeaderText = "VALOR VENDA";
            vrVendaProd.Name = "vrVendaProd";
            vrVendaProd.ReadOnly = true;
            // 
            // vrPromo
            // 
            vrPromo.HeaderText = "$PROMOCIONAL";
            vrPromo.Name = "vrPromo";
            vrPromo.ReadOnly = true;
            // 
            // pDesconto
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            pDesconto.DefaultCellStyle = dataGridViewCellStyle1;
            pDesconto.HeaderText = "%DESCONTO";
            pDesconto.Name = "pDesconto";
            pDesconto.ReadOnly = true;
            // 
            // pix
            // 
            pix.HeaderText = "DESC PIX";
            pix.Name = "pix";
            pix.ReadOnly = true;
            // 
            // vrLucro
            // 
            vrLucro.HeaderText = "LUCRO UN";
            vrLucro.Name = "vrLucro";
            vrLucro.ReadOnly = true;
            // 
            // linkProd
            // 
            linkProd.HeaderText = "LINK";
            linkProd.Name = "linkProd";
            linkProd.ReadOnly = true;
            // 
            // catProd
            // 
            catProd.HeaderText = "CATEGORIA";
            catProd.Name = "catProd";
            catProd.ReadOnly = true;
            // 
            // grupoProd
            // 
            grupoProd.HeaderText = "GRUPO";
            grupoProd.Name = "grupoProd";
            grupoProd.ReadOnly = true;
            // 
            // descricao
            // 
            descricao.HeaderText = "DESCRICAO";
            descricao.Name = "descricao";
            descricao.ReadOnly = true;
            // 
            // tags
            // 
            tags.HeaderText = "TAGS";
            tags.Name = "tags";
            tags.ReadOnly = true;
            // 
            // btnSalvarAlteracoes
            // 
            btnSalvarAlteracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarAlteracoes.BackColor = Color.DarkOliveGreen;
            btnSalvarAlteracoes.ForeColor = SystemColors.ControlLight;
            btnSalvarAlteracoes.Location = new Point(822, 274);
            btnSalvarAlteracoes.Name = "btnSalvarAlteracoes";
            btnSalvarAlteracoes.Size = new Size(156, 23);
            btnSalvarAlteracoes.TabIndex = 12;
            btnSalvarAlteracoes.Text = "SALVAR ALTERAÇÕES";
            btnSalvarAlteracoes.UseVisualStyleBackColor = false;
            btnSalvarAlteracoes.Visible = false;
            btnSalvarAlteracoes.Click += btnSalvarAlteracoes_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 5);
            label5.Name = "label5";
            label5.Size = new Size(132, 15);
            label5.TabIndex = 11;
            label5.Text = "PROCURAR CATALOGO";
            // 
            // txtPesquisaCatalogo
            // 
            txtPesquisaCatalogo.BackColor = Color.LavenderBlush;
            txtPesquisaCatalogo.CharacterCasing = CharacterCasing.Upper;
            txtPesquisaCatalogo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtPesquisaCatalogo.Location = new Point(3, 26);
            txtPesquisaCatalogo.Name = "txtPesquisaCatalogo";
            txtPesquisaCatalogo.Size = new Size(475, 23);
            txtPesquisaCatalogo.TabIndex = 0;
            txtPesquisaCatalogo.KeyDown += txtPesquisaCatalogo_KeyDown;
            txtPesquisaCatalogo.Leave += txtPesquisaCatalogo_Leave;
            // 
            // toolStrip3
            // 
            toolStrip3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip3.Dock = DockStyle.None;
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.Items.AddRange(new ToolStripItem[] { imprimirToolStripButton });
            toolStrip3.Location = new Point(961, 24);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.RenderMode = ToolStripRenderMode.Professional;
            toolStrip3.Size = new Size(26, 25);
            toolStrip3.TabIndex = 14;
            toolStrip3.Text = "toolStrip3";
            toolStrip3.Visible = false;
            // 
            // imprimirToolStripButton
            // 
            imprimirToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            imprimirToolStripButton.Image = (Image)resources.GetObject("imprimirToolStripButton.Image");
            imprimirToolStripButton.ImageTransparentColor = Color.Magenta;
            imprimirToolStripButton.Name = "imprimirToolStripButton";
            imprimirToolStripButton.Size = new Size(23, 22);
            imprimirToolStripButton.Text = "&Imprimir Catalogo";
            // 
            // FrmCatalogoProdServ
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 478);
            Controls.Add(toolStrip3);
            Controls.Add(label5);
            Controls.Add(txtPesquisaCatalogo);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FrmCatalogoProdServ";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Catalogo ";
            Load += FrmCatalogoProdServ_Load;
            KeyDown += FrmCatalogoProdServ_KeyDown;
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private ToolStripButton salvarToolStripButton1;
        private ToolStripButton btnLimpar;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvProdutos;
        private DataGridViewCheckBoxColumn select;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn prodNome;
        private DataGridViewTextBoxColumn custoProd;
        private DataGridViewTextBoxColumn vrVendaProd;
        private DataGridViewTextBoxColumn vrPromo;
        private DataGridViewTextBoxColumn pDesconto;
        private DataGridViewCheckBoxColumn pix;
        private DataGridViewTextBoxColumn vrLucro;
        private DataGridViewTextBoxColumn linkProd;
        private DataGridViewTextBoxColumn catProd;
        private DataGridViewTextBoxColumn grupoProd;
        private DataGridViewTextBoxColumn descricao;
        private DataGridViewTextBoxColumn tags;
        private TextBox txtNomeCatalogo;
        private Label label1;
        private TextBox txtNomePublicoAlvo;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton4;
        private ToolStripButton btnVerPublicoAlvo;
        private Label label21;
        private TextBox txtDescricao;
        private Button btnExcluir;
        private Button btnProximo;
        private Button btnAnterior;
        private CheckBox chkAtivoInativo;
        private TextBox txtLucroMedio;
        private Label label4;
        private TextBox txtCustoMedio;
        private Label label3;
        private ToolStripButton toolStripButton6;
        private Label label5;
        private TextBox txtPesquisaCatalogo;
        private Label label6;
        private DateTimePicker dtCriacao;
        private Button btnSalvarAlteracoes;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStrip toolStrip3;
        private ToolStripButton imprimirToolStripButton;
        private TextBox txtQtdProdutos;
        private Label label7;
        private ToolStripButton toolStripButton5;
        private ToolStripButton btnListarProdutos;
    }
}