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
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            label21 = new Label();
            txtNome = new TextBox();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            produtoControl1 = new Controles.ProdutoControl();
            groupBox2 = new GroupBox();
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
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, salvarToolStripButton1, toolStripButton1, toolStripButton2 });
            toolStrip4.Location = new Point(860, 20);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(118, 25);
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
            novaToolStripButton1.ToolTipText = "Novo Prompt";
            // 
            // abrirToolStripButton1
            // 
            abrirToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton1.Image = (Image)resources.GetObject("abrirToolStripButton1.Image");
            abrirToolStripButton1.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton1.Name = "abrirToolStripButton1";
            abrirToolStripButton1.Size = new Size(23, 22);
            abrirToolStripButton1.Text = "&Abrir";
            abrirToolStripButton1.ToolTipText = "Abrir Prompt ";
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
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.botao_de_deletar;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "&Limpar Catalogo";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.excluir_arquivo;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "&Remover Selecionados";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 1);
            label21.Name = "label21";
            label21.Size = new Size(70, 15);
            label21.TabIndex = 7;
            label21.Text = "DESCRIÇÃO";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.Ivory;
            txtNome.CharacterCasing = CharacterCasing.Upper;
            txtNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtNome.Location = new Point(12, 22);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(475, 23);
            txtNome.TabIndex = 6;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 48);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(987, 433);
            splitContainer1.SplitterDistance = 216;
            splitContainer1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(produtoControl1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(987, 216);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "PRODUTO";
            // 
            // produtoControl1
            // 
            produtoControl1.Location = new Point(9, 15);
            produtoControl1.Name = "produtoControl1";
            produtoControl1.Size = new Size(971, 200);
            produtoControl1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProdutos);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(987, 213);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "LISTA PRODUTOS";
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProdutos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProdutos.Location = new Point(9, 37);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowTemplate.Height = 25;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(971, 141);
            dgvProdutos.TabIndex = 0;
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
            // FrmCatalogoProdServ
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 478);
            Controls.Add(splitContainer1);
            Controls.Add(label21);
            Controls.Add(txtNome);
            Controls.Add(toolStrip4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "FrmCatalogoProdServ";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CATALOGO";
            Load += FrmCatalogoProdServ_Load;
            KeyDown += FrmCatalogoProdServ_KeyDown;
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private ToolStripButton salvarToolStripButton1;
        private Label label21;
        private TextBox txtNome;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Controles.ProdutoControl produtoControl1;
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
    }
}