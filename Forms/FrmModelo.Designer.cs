namespace AIBAM.Forms
{
    partial class FrmModelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModelo));
            label1 = new Label();
            txtNomeModelo = new TextBox();
            txtIdentificacaoModelo = new TextBox();
            label2 = new Label();
            adicionarListaControl1 = new AdicionarListaControl();
            txtDescricacaoModelo = new TextBox();
            label3 = new Label();
            btnAplicar = new Button();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnProximo = new Button();
            btnAnterior = new Button();
            btnEditar = new Button();
            btnAbrirChat = new Button();
            tabControl1 = new TabControl();
            tabPageModelosChat = new TabPage();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            cboModelName = new ComboBox();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tabPageModelosChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 55);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome Modelo";
            // 
            // txtNomeModelo
            // 
            txtNomeModelo.CharacterCasing = CharacterCasing.Lower;
            txtNomeModelo.Location = new Point(0, 73);
            txtNomeModelo.Name = "txtNomeModelo";
            txtNomeModelo.Size = new Size(350, 23);
            txtNomeModelo.TabIndex = 2;
            // 
            // txtIdentificacaoModelo
            // 
            txtIdentificacaoModelo.CharacterCasing = CharacterCasing.Lower;
            txtIdentificacaoModelo.Location = new Point(0, 118);
            txtIdentificacaoModelo.Name = "txtIdentificacaoModelo";
            txtIdentificacaoModelo.Size = new Size(350, 23);
            txtIdentificacaoModelo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 100);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 2;
            label2.Text = "Identificação Modelo (Chave)";
            // 
            // adicionarListaControl1
            // 
            adicionarListaControl1.Descricao = "REGRAS MODELO";
            adicionarListaControl1.Dock = DockStyle.Bottom;
            adicionarListaControl1.Location = new Point(0, 221);
            adicionarListaControl1.Name = "adicionarListaControl1";
            adicionarListaControl1.NomeLista = "label1";
            adicionarListaControl1.SeparaPorVirgula = true;
            adicionarListaControl1.Size = new Size(350, 148);
            adicionarListaControl1.TabIndex = 5;
            // 
            // txtDescricacaoModelo
            // 
            txtDescricacaoModelo.Location = new Point(0, 165);
            txtDescricacaoModelo.Name = "txtDescricacaoModelo";
            txtDescricacaoModelo.Size = new Size(350, 23);
            txtDescricacaoModelo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 147);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 5;
            label3.Text = "Instrução Modelo";
            // 
            // btnAplicar
            // 
            btnAplicar.Dock = DockStyle.Right;
            btnAplicar.Location = new Point(275, 0);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(75, 34);
            btnAplicar.TabIndex = 6;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(200, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 34);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.Dock = DockStyle.Right;
            btnExcluir.ForeColor = SystemColors.ControlLightLight;
            btnExcluir.Location = new Point(-75, 0);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 46);
            btnExcluir.TabIndex = 10;
            btnExcluir.TabStop = false;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnProximo
            // 
            btnProximo.Dock = DockStyle.Right;
            btnProximo.Location = new Point(75, 0);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 46);
            btnProximo.TabIndex = 9;
            btnProximo.Text = "PRÓXIMO";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Dock = DockStyle.Right;
            btnAnterior.Enabled = false;
            btnAnterior.Location = new Point(0, 0);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 46);
            btnAnterior.TabIndex = 8;
            btnAnterior.Text = "ANTERIOR";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.Image = Properties.Resources.editar;
            btnEditar.Location = new Point(320, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(27, 23);
            btnEditar.TabIndex = 10;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAbrirChat
            // 
            btnAbrirChat.Enabled = false;
            btnAbrirChat.Image = Properties.Resources.toque;
            btnAbrirChat.Location = new Point(292, 3);
            btnAbrirChat.Name = "btnAbrirChat";
            btnAbrirChat.Size = new Size(27, 23);
            btnAbrirChat.TabIndex = 11;
            btnAbrirChat.UseVisualStyleBackColor = true;
            btnAbrirChat.Click += btnAbrirChat_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageModelosChat);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(364, 441);
            tabControl1.TabIndex = 12;
            // 
            // tabPageModelosChat
            // 
            tabPageModelosChat.Controls.Add(splitContainer1);
            tabPageModelosChat.Location = new Point(4, 24);
            tabPageModelosChat.Name = "tabPageModelosChat";
            tabPageModelosChat.Padding = new Padding(3);
            tabPageModelosChat.Size = new Size(356, 413);
            tabPageModelosChat.TabIndex = 0;
            tabPageModelosChat.Text = "Instruções";
            tabPageModelosChat.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnExcluir);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnProximo);
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Size = new Size(350, 407);
            splitContainer1.SplitterDistance = 373;
            splitContainer1.TabIndex = 13;
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
            splitContainer2.Panel1.Controls.Add(cboModelName);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(txtNomeModelo);
            splitContainer2.Panel1.Controls.Add(btnAbrirChat);
            splitContainer2.Panel1.Controls.Add(adicionarListaControl1);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(txtDescricacaoModelo);
            splitContainer2.Panel1.Controls.Add(txtIdentificacaoModelo);
            splitContainer2.Panel1.Controls.Add(btnEditar);
            splitContainer2.Panel1.Controls.Add(label3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(btnCancelar);
            splitContainer2.Panel2.Controls.Add(btnAplicar);
            splitContainer2.Size = new Size(350, 407);
            splitContainer2.SplitterDistance = 369;
            splitContainer2.TabIndex = 0;
            // 
            // cboModelName
            // 
            cboModelName.FormattingEnabled = true;
            cboModelName.Location = new Point(0, 29);
            cboModelName.Name = "cboModelName";
            cboModelName.Size = new Size(350, 23);
            cboModelName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 12;
            label4.Text = "IA Nome";
            // 
            // FrmModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 441);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmModelo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Novo Modelo";
            Load += FrmModelo_Load;
            KeyDown += FrmModelo_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPageModelosChat.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtNomeModelo;
        private TextBox txtIdentificacaoModelo;
        private Label label2;
        private AdicionarListaControl adicionarListaControl1;
        private TextBox txtDescricacaoModelo;
        private Label label3;
        private Button btnAplicar;
        private Button btnCancelar;
        private Button btnExcluir;
        private Button btnProximo;
        private Button btnAnterior;
        private Button btnEditar;
        private Button btnAbrirChat;
        private TabControl tabControl1;
        private TabPage tabPageModelosChat;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ComboBox cboModelName;
        private Label label4;
    }
}