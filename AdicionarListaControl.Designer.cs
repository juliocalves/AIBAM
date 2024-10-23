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
            txtInteresse = new TextBox();
            lblDescricao = new Label();
            ckList = new CheckedListBox();
            SuspendLayout();
            // 
            // btnSalvarLista
            // 
            btnSalvarLista.Image = Properties.Resources.data;
            btnSalvarLista.Location = new Point(255, 17);
            btnSalvarLista.Name = "btnSalvarLista";
            btnSalvarLista.Size = new Size(25, 25);
            btnSalvarLista.TabIndex = 12;
            btnSalvarLista.UseVisualStyleBackColor = true;
            // 
            // btnCarregarLista
            // 
            btnCarregarLista.Image = Properties.Resources.importar;
            btnCarregarLista.Location = new Point(231, 17);
            btnCarregarLista.Name = "btnCarregarLista";
            btnCarregarLista.Size = new Size(25, 25);
            btnCarregarLista.TabIndex = 11;
            btnCarregarLista.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Image = Properties.Resources.adicionar__1_;
            btnAdicionar.Location = new Point(207, 17);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(25, 25);
            btnAdicionar.TabIndex = 10;
            btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // txtInteresse
            // 
            txtInteresse.Location = new Point(3, 17);
            txtInteresse.Name = "txtInteresse";
            txtInteresse.Size = new Size(203, 23);
            txtInteresse.TabIndex = 9;
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
            ckList.Size = new Size(277, 94);
            ckList.TabIndex = 7;
            // 
            // AdicionarListaControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSalvarLista);
            Controls.Add(btnCarregarLista);
            Controls.Add(btnAdicionar);
            Controls.Add(txtInteresse);
            Controls.Add(lblDescricao);
            Controls.Add(ckList);
            Name = "AdicionarListaControl1";
            Size = new Size(286, 148);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvarLista;
        private Button btnCarregarLista;
        private Button btnAdicionar;
        private TextBox txtInteresse;
        private Label lblDescricao;
        private CheckedListBox ckList;
    }
}
