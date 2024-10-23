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
            btnSalvarLista = new Button();
            btnCarregarLista = new Button();
            btnAdicionar = new Button();
            txtItem = new TextBox();
            lblDescricao = new Label();
            ckList = new CheckedListBox();
            SuspendLayout();
            // 
            // btnSalvarLista
            // 
            btnSalvarLista.Image = Properties.Resources.data;
            btnSalvarLista.Location = new Point(261, 13);
            btnSalvarLista.Name = "btnSalvarLista";
            btnSalvarLista.Size = new Size(30, 30);
            btnSalvarLista.TabIndex = 4;
            btnSalvarLista.UseVisualStyleBackColor = true;
            // 
            // btnCarregarLista
            // 
            btnCarregarLista.Image = Properties.Resources.importar;
            btnCarregarLista.Location = new Point(233, 13);
            btnCarregarLista.Name = "btnCarregarLista";
            btnCarregarLista.Size = new Size(30, 30);
            btnCarregarLista.TabIndex = 3;
            btnCarregarLista.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Image = Properties.Resources.adicionar__1_;
            btnAdicionar.Location = new Point(206, 13);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(30, 30);
            btnAdicionar.TabIndex = 2;
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // txtItem
            // 
            txtItem.Location = new Point(3, 17);
            txtItem.Name = "txtItem";
            txtItem.Size = new Size(203, 23);
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
            ckList.FormattingEnabled = true;
            ckList.Location = new Point(3, 48);
            ckList.Name = "ckList";
            ckList.Size = new Size(288, 94);
            ckList.TabIndex = 7;
            ckList.TabStop = false;
            ckList.KeyDown += ckList_KeyDown;
            // 
            // AdicionarListaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSalvarLista);
            Controls.Add(btnCarregarLista);
            Controls.Add(btnAdicionar);
            Controls.Add(txtItem);
            Controls.Add(lblDescricao);
            Controls.Add(ckList);
            Name = "AdicionarListaControl";
            Size = new Size(294, 148);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvarLista;
        private Button btnCarregarLista;
        private Button btnAdicionar;
        private TextBox txtItem;
        private Label lblDescricao;
        private CheckedListBox ckList;
    }
}
