namespace AIBAM
{
    partial class AdicionarListaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarListaControl));
            txtItem = new TextBox();
            lblDescricao = new Label();
            ckList = new CheckedListBox();
            toolStrip4 = new ToolStrip();
            toolNovoItemLista = new ToolStripButton();
            toolAbrirLista = new ToolStripButton();
            toolSalvarLista = new ToolStripButton();
            toolLimparLista = new ToolStripButton();
            toolRemoverSelecionados = new ToolStripButton();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            lblNomeLista = new Label();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // txtItem
            // 
            txtItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtItem.CharacterCasing = CharacterCasing.Upper;
            txtItem.Location = new Point(0, 17);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(206, 23);
            txtItem.TabIndex = 1;
            txtItem.KeyDown += txtItem_KeyDown;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(0, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(69, 15);
            lblDescricao.TabIndex = 8;
            lblDescricao.Text = "INTERESSES";
            // 
            // ckList
            // 
            ckList.Dock = DockStyle.Bottom;
            ckList.FormattingEnabled = true;
            ckList.Location = new Point(0, 54);
            ckList.Name = "ckList";
            ckList.Size = new Size(326, 94);
            ckList.TabIndex = 7;
            ckList.TabStop = false;
            ckList.KeyDown += ckList_KeyDown;
            ckList.MouseDoubleClick += ckList_MouseDoubleClick;
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolNovoItemLista, toolAbrirLista, toolSalvarLista, toolLimparLista, toolRemoverSelecionados });
            toolStrip4.Location = new Point(208, 17);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(118, 25);
            toolStrip4.TabIndex = 9;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolNovoItemLista
            // 
            toolNovoItemLista.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolNovoItemLista.Image = (Image)resources.GetObject("toolNovoItemLista.Image");
            toolNovoItemLista.ImageTransparentColor = Color.Magenta;
            toolNovoItemLista.Name = "toolNovoItemLista";
            toolNovoItemLista.Size = new Size(23, 22);
            toolNovoItemLista.Text = "&Novo Item";
            toolNovoItemLista.ToolTipText = "Novo Item";
            toolNovoItemLista.Click += toolNovoItemLista_Click;
            // 
            // toolAbrirLista
            // 
            toolAbrirLista.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolAbrirLista.Image = (Image)resources.GetObject("toolAbrirLista.Image");
            toolAbrirLista.ImageTransparentColor = Color.Magenta;
            toolAbrirLista.Name = "toolAbrirLista";
            toolAbrirLista.Size = new Size(23, 22);
            toolAbrirLista.Text = "&Abrir Lista";
            toolAbrirLista.ToolTipText = "Abrir Lista";
            toolAbrirLista.Click += toolAbrirLista_Click;
            // 
            // toolSalvarLista
            // 
            toolSalvarLista.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolSalvarLista.Image = (Image)resources.GetObject("toolSalvarLista.Image");
            toolSalvarLista.ImageTransparentColor = Color.Magenta;
            toolSalvarLista.Name = "toolSalvarLista";
            toolSalvarLista.Size = new Size(23, 22);
            toolSalvarLista.Text = "&Salvar Lista";
            toolSalvarLista.ToolTipText = "Salvar Lista";
            toolSalvarLista.Click += toolSalvarLista_Click;
            // 
            // toolLimparLista
            // 
            toolLimparLista.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolLimparLista.Image = Properties.Resources.botao_de_deletar;
            toolLimparLista.ImageTransparentColor = Color.Magenta;
            toolLimparLista.Name = "toolLimparLista";
            toolLimparLista.RightToLeft = RightToLeft.No;
            toolLimparLista.Size = new Size(23, 22);
            toolLimparLista.Text = "&Limpar Lista";
            toolLimparLista.Click += toolLimparLista_Click;
            // 
            // toolRemoverSelecionados
            // 
            toolRemoverSelecionados.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolRemoverSelecionados.Image = Properties.Resources.excluir_arquivo;
            toolRemoverSelecionados.ImageTransparentColor = Color.Magenta;
            toolRemoverSelecionados.Name = "toolRemoverSelecionados";
            toolRemoverSelecionados.Size = new Size(23, 22);
            toolRemoverSelecionados.Text = "&Remover Selecionados";
            toolRemoverSelecionados.Click += toolRemoverSelecionados_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblNomeLista
            // 
            lblNomeLista.AutoSize = true;
            lblNomeLista.Location = new Point(164, 3);
            lblNomeLista.Name = "lblNomeLista";
            lblNomeLista.Size = new Size(38, 15);
            lblNomeLista.TabIndex = 10;
            lblNomeLista.Text = "label1";
            lblNomeLista.Visible = false;
            // 
            // AdicionarListaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblNomeLista);
            Controls.Add(toolStrip4);
            Controls.Add(txtItem);
            Controls.Add(lblDescricao);
            Controls.Add(ckList);
            Name = "AdicionarListaControl";
            Size = new Size(326, 148);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtItem;
        private Label lblDescricao;
        private CheckedListBox ckList;
        private ToolStrip toolStrip4;
        private ToolStripButton toolNovoItemLista;
        private ToolStripButton toolAbrirLista;
        private ToolStripButton toolSalvarLista;
        private ToolStripButton toolLimparLista;
        private ToolStripButton toolRemoverSelecionados;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Label lblNomeLista;
    }
}
