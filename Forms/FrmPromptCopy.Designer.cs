namespace AIBAM.Forms
{
    partial class FrmPromptCopy
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPromptCopy));
            splitContainer1 = new SplitContainer();
            toolStrip4 = new ToolStrip();
            novaToolStripButton1 = new ToolStripButton();
            abrirToolStripButton1 = new ToolStripButton();
            salvarToolStripButton1 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            label21 = new Label();
            txtNomePromptCopy = new TextBox();
            tabCopy = new TabControl();
            tabPageBriefing = new TabPage();
            briefingCopyControl1 = new Controles.BriefingCopyControl();
            tabPagePublicoCopy = new TabPage();
            publicoAlvoControl1 = new AIBAM.Controles.PublicoAlvoControl();
            tabControles = new TabPage();
            lstPalavrasChave = new AdicionarListaControl();
            nOriginalidade = new NumericUpDown();
            label20 = new Label();
            gbPerspectiva = new GroupBox();
            radioButton19 = new RadioButton();
            radioButton18 = new RadioButton();
            radioButton17 = new RadioButton();
            ckSentimentos = new CheckedListBox();
            label19 = new Label();
            nEntonacao = new NumericUpDown();
            label18 = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip4.SuspendLayout();
            tabCopy.SuspendLayout();
            tabPageBriefing.SuspendLayout();
            tabPagePublicoCopy.SuspendLayout();
            tabControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nOriginalidade).BeginInit();
            gbPerspectiva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nEntonacao).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(toolStrip4);
            splitContainer1.Panel1.Controls.Add(label21);
            splitContainer1.Panel1.Controls.Add(txtNomePromptCopy);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabCopy);
            splitContainer1.Size = new Size(1140, 606);
            splitContainer1.SplitterDistance = 59;
            splitContainer1.TabIndex = 0;
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, salvarToolStripButton1, toolStripButton1 });
            toolStrip4.Location = new Point(1036, 9);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(95, 25);
            toolStrip4.TabIndex = 6;
            toolStrip4.Text = "toolStrip4";
            // 
            // novaToolStripButton1
            // 
            novaToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            novaToolStripButton1.Image = (Image)resources.GetObject("novaToolStripButton1.Image");
            novaToolStripButton1.ImageTransparentColor = Color.Magenta;
            novaToolStripButton1.Name = "novaToolStripButton1";
            novaToolStripButton1.Size = new Size(23, 22);
            novaToolStripButton1.Text = "&Nova";
            novaToolStripButton1.ToolTipText = "Novo Prompt";
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
            abrirToolStripButton1.ToolTipText = "Abrir Prompt ";
            abrirToolStripButton1.Click += abrirToolStripButton1_Click;
            // 
            // salvarToolStripButton1
            // 
            salvarToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton1.Image = (Image)resources.GetObject("salvarToolStripButton1.Image");
            salvarToolStripButton1.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton1.Name = "salvarToolStripButton1";
            salvarToolStripButton1.Size = new Size(23, 22);
            salvarToolStripButton1.Text = "&Salvar Prompt";
            salvarToolStripButton1.ToolTipText = "Salvar Prompt";
            salvarToolStripButton1.Click += salvarToolStripButton1_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.bate_papo;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "&Enviar Prompt";
            toolStripButton1.TextDirection = ToolStripTextDirection.Horizontal;
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(2, 6);
            label21.Name = "label21";
            label21.Size = new Size(121, 15);
            label21.TabIndex = 5;
            label21.Text = "DESCRIÇÃO PROMPT";
            // 
            // txtNomePromptCopy
            // 
            txtNomePromptCopy.BackColor = Color.Ivory;
            txtNomePromptCopy.CharacterCasing = CharacterCasing.Upper;
            txtNomePromptCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtNomePromptCopy.Location = new Point(2, 27);
            txtNomePromptCopy.Name = "txtNomePromptCopy";
            txtNomePromptCopy.Size = new Size(491, 23);
            txtNomePromptCopy.TabIndex = 4;
            // 
            // tabCopy
            // 
            tabCopy.AccessibleRole = AccessibleRole.None;
            tabCopy.Controls.Add(tabPageBriefing);
            tabCopy.Controls.Add(tabPagePublicoCopy);
            tabCopy.Controls.Add(tabControles);
            tabCopy.Dock = DockStyle.Fill;
            tabCopy.Location = new Point(0, 0);
            tabCopy.Name = "tabCopy";
            tabCopy.SelectedIndex = 0;
            tabCopy.Size = new Size(1140, 543);
            tabCopy.TabIndex = 1;
            // 
            // tabPageBriefing
            // 
            tabPageBriefing.BackColor = SystemColors.Window;
            tabPageBriefing.Controls.Add(briefingCopyControl1);
            tabPageBriefing.Location = new Point(4, 24);
            tabPageBriefing.Name = "tabPageBriefing";
            tabPageBriefing.Padding = new Padding(3);
            tabPageBriefing.Size = new Size(1132, 515);
            tabPageBriefing.TabIndex = 0;
            tabPageBriefing.Text = "BRIEFING";
            // 
            // briefingCopyControl1
            // 
            briefingCopyControl1.Dock = DockStyle.Fill;
            briefingCopyControl1.Location = new Point(3, 3);
            briefingCopyControl1.Name = "briefingCopyControl1";
            briefingCopyControl1.Size = new Size(1126, 509);
            briefingCopyControl1.TabIndex = 0;
            // 
            // tabPagePublicoCopy
            // 
            tabPagePublicoCopy.AutoScroll = true;
            tabPagePublicoCopy.Controls.Add(publicoAlvoControl1);
            tabPagePublicoCopy.Location = new Point(4, 24);
            tabPagePublicoCopy.Name = "tabPagePublicoCopy";
            tabPagePublicoCopy.Padding = new Padding(3);
            tabPagePublicoCopy.Size = new Size(1132, 515);
            tabPagePublicoCopy.TabIndex = 1;
            tabPagePublicoCopy.Text = "PUBLICO ALVO";
            tabPagePublicoCopy.ToolTipText = "DEFINIÇÃO DE PUBLICO ALVO";
            tabPagePublicoCopy.UseVisualStyleBackColor = true;
            // 
            // publicoAlvoControl1
            // 
            publicoAlvoControl1.AutoScroll = true;
            publicoAlvoControl1.Dock = DockStyle.Fill;
            publicoAlvoControl1.Location = new Point(3, 3);
            publicoAlvoControl1.Name = "publicoAlvoControl1";
            publicoAlvoControl1.Size = new Size(1126, 509);
            publicoAlvoControl1.TabIndex = 0;
            // 
            // tabControles
            // 
            tabControles.Controls.Add(lstPalavrasChave);
            tabControles.Controls.Add(nOriginalidade);
            tabControles.Controls.Add(label20);
            tabControles.Controls.Add(gbPerspectiva);
            tabControles.Controls.Add(ckSentimentos);
            tabControles.Controls.Add(label19);
            tabControles.Controls.Add(nEntonacao);
            tabControles.Controls.Add(label18);
            tabControles.Location = new Point(4, 24);
            tabControles.Name = "tabControles";
            tabControles.Padding = new Padding(3);
            tabControles.Size = new Size(1132, 515);
            tabControles.TabIndex = 2;
            tabControles.Text = "CONTROLES";
            tabControles.UseVisualStyleBackColor = true;
            // 
            // lstPalavrasChave
            // 
            lstPalavrasChave.Descricao = "PALAVRAS CHAVE";
            lstPalavrasChave.Location = new Point(591, 2);
            lstPalavrasChave.Name = "lstPalavrasChave";
            lstPalavrasChave.NomeLista = "PALAVRAS_CHAVE_COPY";
            lstPalavrasChave.Size = new Size(326, 148);
            lstPalavrasChave.TabIndex = 6;
            // 
            // nOriginalidade
            // 
            nOriginalidade.AccessibleDescription = " 1-Pouco Original e 10-Muito Original";
            nOriginalidade.AccessibleName = " 1-Pouco Original e 10-Muito Original";
            nOriginalidade.AccessibleRole = AccessibleRole.ToolTip;
            nOriginalidade.AllowDrop = true;
            nOriginalidade.BackColor = Color.AliceBlue;
            nOriginalidade.BorderStyle = BorderStyle.FixedSingle;
            nOriginalidade.Location = new Point(8, 65);
            nOriginalidade.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nOriginalidade.Name = "nOriginalidade";
            nOriginalidade.Size = new Size(76, 23);
            nOriginalidade.TabIndex = 2;
            nOriginalidade.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nOriginalidade.Enter += nOriginalidade_Enter;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 48);
            label20.Name = "label20";
            label20.Size = new Size(78, 15);
            label20.TabIndex = 5;
            label20.Text = "Originalidade";
            // 
            // gbPerspectiva
            // 
            gbPerspectiva.Controls.Add(radioButton19);
            gbPerspectiva.Controls.Add(radioButton18);
            gbPerspectiva.Controls.Add(radioButton17);
            gbPerspectiva.Location = new Point(476, 2);
            gbPerspectiva.Name = "gbPerspectiva";
            gbPerspectiva.Size = new Size(110, 100);
            gbPerspectiva.TabIndex = 4;
            gbPerspectiva.TabStop = false;
            gbPerspectiva.Text = "PERSPECTIVA";
            // 
            // radioButton19
            // 
            radioButton19.AutoSize = true;
            radioButton19.Location = new Point(8, 73);
            radioButton19.Name = "radioButton19";
            radioButton19.Size = new Size(81, 19);
            radioButton19.TabIndex = 2;
            radioButton19.TabStop = true;
            radioButton19.Text = "3º PESSOA";
            radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            radioButton18.AutoSize = true;
            radioButton18.Checked = true;
            radioButton18.Location = new Point(8, 48);
            radioButton18.Name = "radioButton18";
            radioButton18.Size = new Size(81, 19);
            radioButton18.TabIndex = 1;
            radioButton18.TabStop = true;
            radioButton18.Text = "2º PESSOA";
            radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            radioButton17.AutoSize = true;
            radioButton17.Location = new Point(8, 23);
            radioButton17.Name = "radioButton17";
            radioButton17.Size = new Size(81, 19);
            radioButton17.TabIndex = 0;
            radioButton17.TabStop = true;
            radioButton17.Text = "1º PESSOA";
            radioButton17.UseVisualStyleBackColor = true;
            // 
            // ckSentimentos
            // 
            ckSentimentos.CheckOnClick = true;
            ckSentimentos.FormattingEnabled = true;
            ckSentimentos.Items.AddRange(new object[] { "Alegria", "Tristeza", "Raiva", "Medo", "Surpresa", "Confiança", "Esperança", "Nostalgia", "Ansiedade", "Gratidão", "Empatia", "Amor", "Frustração", "Excitação", "Curiosidade", "Alívio", "Satisfação", "Inspiração", "Orgulho", "Desespero" });
            ckSentimentos.Location = new Point(93, 20);
            ckSentimentos.MultiColumn = true;
            ckSentimentos.Name = "ckSentimentos";
            ckSentimentos.Size = new Size(377, 130);
            ckSentimentos.TabIndex = 3;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(90, 6);
            label19.Name = "label19";
            label19.Size = new Size(68, 15);
            label19.TabIndex = 2;
            label19.Text = "Sentimento";
            // 
            // nEntonacao
            // 
            nEntonacao.AccessibleDescription = " 1-Muito Informal e 10-Muito Formal";
            nEntonacao.AccessibleName = " 1-Muito Informal e 10-Muito Formal";
            nEntonacao.AccessibleRole = AccessibleRole.ToolTip;
            nEntonacao.AllowDrop = true;
            nEntonacao.BackColor = Color.AliceBlue;
            nEntonacao.BorderStyle = BorderStyle.FixedSingle;
            nEntonacao.Location = new Point(8, 21);
            nEntonacao.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nEntonacao.Name = "nEntonacao";
            nEntonacao.Size = new Size(76, 23);
            nEntonacao.TabIndex = 1;
            nEntonacao.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nEntonacao.Enter += nEntonacao_Enter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 6);
            label18.Name = "label18";
            label18.Size = new Size(63, 15);
            label18.TabIndex = 0;
            label18.Text = "Entonação";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmPromptCopy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 606);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPromptCopy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Copywriting";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            tabCopy.ResumeLayout(false);
            tabPageBriefing.ResumeLayout(false);
            tabPagePublicoCopy.ResumeLayout(false);
            tabControles.ResumeLayout(false);
            tabControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nOriginalidade).EndInit();
            gbPerspectiva.ResumeLayout(false);
            gbPerspectiva.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nEntonacao).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private ToolStripButton salvarToolStripButton1;
        private ToolStripButton toolStripButton1;
        private Label label21;
        private TextBox txtNomePromptCopy;
        private TabControl tabCopy;
        private TabPage tabPageBriefing;
        private Controles.BriefingCopyControl briefingCopyControl1;
        private TabPage tabPagePublicoCopy;
        private AIBAM.Controles.PublicoAlvoControl publicoAlvoControl1;
        private TabPage tabControles;
        private AdicionarListaControl lstPalavrasChave;
        private NumericUpDown nOriginalidade;
        private Label label20;
        private GroupBox gbPerspectiva;
        private RadioButton radioButton19;
        private RadioButton radioButton18;
        private RadioButton radioButton17;
        private CheckedListBox ckSentimentos;
        private Label label19;
        private NumericUpDown nEntonacao;
        private Label label18;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolTip toolTip1;
    }
}