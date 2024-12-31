namespace AIBAM
{
    partial class FrmListar
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListar));
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            toolStripProduto = new ToolStrip();
            btnCarregarFonteDados = new ToolStripButton();
            btnSalvarLista = new ToolStripButton();
            btnCriarVariantesProduto = new ToolStripButton();
            dgvView = new DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStripProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvView).BeginInit();
            SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvView);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 25;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(toolStripProduto);
            splitContainer2.Size = new Size(800, 25);
            splitContainer2.SplitterDistance = 662;
            splitContainer2.TabIndex = 0;
            // 
            // toolStripProduto
            // 
            toolStripProduto.Dock = DockStyle.Fill;
            toolStripProduto.GripStyle = ToolStripGripStyle.Hidden;
            toolStripProduto.Items.AddRange(new ToolStripItem[] { btnCarregarFonteDados, btnSalvarLista, btnCriarVariantesProduto });
            toolStripProduto.Location = new Point(0, 0);
            toolStripProduto.Name = "toolStripProduto";
            toolStripProduto.RenderMode = ToolStripRenderMode.Professional;
            toolStripProduto.Size = new Size(134, 25);
            toolStripProduto.TabIndex = 1;
            toolStripProduto.Text = "toolStrip1";
            // 
            // btnCarregarFonteDados
            // 
            btnCarregarFonteDados.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCarregarFonteDados.Image = Properties.Resources.carregar_dados;
            btnCarregarFonteDados.ImageTransparentColor = Color.Magenta;
            btnCarregarFonteDados.Name = "btnCarregarFonteDados";
            btnCarregarFonteDados.Size = new Size(23, 22);
            btnCarregarFonteDados.Text = "&CARREGAR DADOS CSV";
            btnCarregarFonteDados.Visible = false;
            btnCarregarFonteDados.Click += btnCarregarFonteDados_Click;
            // 
            // btnSalvarLista
            // 
            btnSalvarLista.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSalvarLista.Image = Properties.Resources.pasta1;
            btnSalvarLista.ImageTransparentColor = Color.Magenta;
            btnSalvarLista.Name = "btnSalvarLista";
            btnSalvarLista.Size = new Size(23, 22);
            btnSalvarLista.Text = "&SALVAR TODOS ITENS";
            btnSalvarLista.Visible = false;
            btnSalvarLista.Click += btnSalvarLista_Click;
            // 
            // btnCriarVariantesProduto
            // 
            btnCriarVariantesProduto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCriarVariantesProduto.Image = Properties.Resources.duplicado;
            btnCriarVariantesProduto.ImageTransparentColor = Color.Magenta;
            btnCriarVariantesProduto.Name = "btnCriarVariantesProduto";
            btnCriarVariantesProduto.Size = new Size(23, 22);
            btnCriarVariantesProduto.Text = "&CRIAR VARIANTES PRODUTOS";
            btnCriarVariantesProduto.Click += btnCriarVariantesProduto_Click;
            // 
            // dgvView
            // 
            dgvView.AllowUserToAddRows = false;
            dgvView.AllowUserToDeleteRows = false;
            dgvView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = Color.MediumAquamarine;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvView.BackgroundColor = SystemColors.ButtonHighlight;
            dgvView.BorderStyle = BorderStyle.None;
            dgvView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgvView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvView.Columns.AddRange(new DataGridViewColumn[] { Select });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvView.DefaultCellStyle = dataGridViewCellStyle2;
            dgvView.Dock = DockStyle.Fill;
            dgvView.Location = new Point(0, 0);
            dgvView.Name = "dgvView";
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Size = new Size(800, 421);
            dgvView.TabIndex = 2;
            dgvView.CellMouseDoubleClick += dgvView_MouseDoubleClick;
            dgvView.CellValueChanged += dgvView_CellValueChanged;
            // 
            // Select
            // 
            Select.HeaderText = "";
            Select.Name = "Select";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmListar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmListar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Lista";
            Load += FrmListar_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStripProduto.ResumeLayout(false);
            toolStripProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvView;
        private SplitContainer splitContainer2;
        private ToolStrip toolStripProduto;
        private ToolStripButton btnCarregarFonteDados;
        private OpenFileDialog openFileDialog1;
        private ToolStripButton btnSalvarLista;
        private ToolStripButton btnCriarVariantesProduto;
        private DataGridViewCheckBoxColumn Select;
    }
}