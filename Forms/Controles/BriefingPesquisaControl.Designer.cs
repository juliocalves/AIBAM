namespace AIBAM.Forms.Controles
{
    partial class BriefingPesquisaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BriefingPesquisaControl));
            toolStrip6 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            label22 = new Label();
            txtDescricaoPromptPEsquisa = new TextBox();
            tabControlConfPesquisa = new TabControl();
            tabPage = new TabPage();
            toolStrip7 = new ToolStrip();
            btnNovoPublicoAlvo = new ToolStripButton();
            btnAbrirPublicoAlvo = new ToolStripButton();
            textBox2 = new TextBox();
            label31 = new Label();
            lstObjetivosEspecificosPesquisa = new AdicionarListaControl();
            txtContextoProblema = new TextBox();
            label30 = new Label();
            txtJustificativa = new TextBox();
            label29 = new Label();
            txtPerguntaPesquisa = new TextBox();
            label28 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label24 = new Label();
            txtTituloPesquisa = new TextBox();
            cboModeloPesquisa = new ComboBox();
            label23 = new Label();
            tabPagePublicoAlvoPesquisa = new TabPage();
            toolStrip6.SuspendLayout();
            tabControlConfPesquisa.SuspendLayout();
            tabPage.SuspendLayout();
            toolStrip7.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip6
            // 
            toolStrip6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip6.Dock = DockStyle.None;
            toolStrip6.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip6.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 });
            toolStrip6.Location = new Point(955, 25);
            toolStrip6.Name = "toolStrip6";
            toolStrip6.RenderMode = ToolStripRenderMode.Professional;
            toolStrip6.Size = new Size(95, 25);
            toolStrip6.TabIndex = 8;
            toolStrip6.Text = "toolStrip6";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "&Nova";
            toolStripButton2.ToolTipText = "Novo Prompt";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(23, 22);
            toolStripButton3.Text = "&Abrir";
            toolStripButton3.ToolTipText = "Abrir Prompt ";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(23, 22);
            toolStripButton4.Text = "&Salvar Prompt";
            toolStripButton4.ToolTipText = "Salvar Prompt";
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = Properties.Resources.bate_papo;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(23, 22);
            toolStripButton5.Text = "&Enviar Prompt";
            toolStripButton5.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(2, 6);
            label22.Name = "label22";
            label22.Size = new Size(121, 15);
            label22.TabIndex = 7;
            label22.Text = "DESCRIÇÃO PROMPT";
            // 
            // txtDescricaoPromptPEsquisa
            // 
            txtDescricaoPromptPEsquisa.BackColor = Color.Ivory;
            txtDescricaoPromptPEsquisa.CharacterCasing = CharacterCasing.Upper;
            txtDescricaoPromptPEsquisa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtDescricaoPromptPEsquisa.Location = new Point(2, 27);
            txtDescricaoPromptPEsquisa.Name = "txtDescricaoPromptPEsquisa";
            txtDescricaoPromptPEsquisa.Size = new Size(491, 23);
            txtDescricaoPromptPEsquisa.TabIndex = 6;
            // 
            // tabControlConfPesquisa
            // 
            tabControlConfPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlConfPesquisa.Controls.Add(tabPage);
            tabControlConfPesquisa.Controls.Add(tabPagePublicoAlvoPesquisa);
            tabControlConfPesquisa.Location = new Point(4, 90);
            tabControlConfPesquisa.Name = "tabControlConfPesquisa";
            tabControlConfPesquisa.SelectedIndex = 0;
            tabControlConfPesquisa.Size = new Size(1051, 393);
            tabControlConfPesquisa.TabIndex = 9;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(toolStrip7);
            tabPage.Controls.Add(textBox2);
            tabPage.Controls.Add(label31);
            tabPage.Controls.Add(lstObjetivosEspecificosPesquisa);
            tabPage.Controls.Add(txtContextoProblema);
            tabPage.Controls.Add(label30);
            tabPage.Controls.Add(txtJustificativa);
            tabPage.Controls.Add(label29);
            tabPage.Controls.Add(txtPerguntaPesquisa);
            tabPage.Controls.Add(label28);
            tabPage.Controls.Add(textBox1);
            tabPage.Controls.Add(label9);
            tabPage.Controls.Add(label27);
            tabPage.Controls.Add(label26);
            tabPage.Controls.Add(label25);
            tabPage.Controls.Add(dateTimePicker2);
            tabPage.Controls.Add(dateTimePicker1);
            tabPage.Controls.Add(label24);
            tabPage.Controls.Add(txtTituloPesquisa);
            tabPage.Controls.Add(cboModeloPesquisa);
            tabPage.Controls.Add(label23);
            tabPage.Location = new Point(4, 24);
            tabPage.Name = "tabPage";
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(1043, 365);
            tabPage.TabIndex = 0;
            tabPage.Text = "BRIEFING";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // toolStrip7
            // 
            toolStrip7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip7.Dock = DockStyle.None;
            toolStrip7.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip7.Items.AddRange(new ToolStripItem[] { btnNovoPublicoAlvo, btnAbrirPublicoAlvo });
            toolStrip7.Location = new Point(1505, 115);
            toolStrip7.Name = "toolStrip7";
            toolStrip7.RenderMode = ToolStripRenderMode.Professional;
            toolStrip7.Size = new Size(49, 25);
            toolStrip7.TabIndex = 54;
            toolStrip7.Text = "toolStrip7";
            // 
            // btnNovoPublicoAlvo
            // 
            btnNovoPublicoAlvo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNovoPublicoAlvo.Image = (Image)resources.GetObject("btnNovoPublicoAlvo.Image");
            btnNovoPublicoAlvo.ImageTransparentColor = Color.Magenta;
            btnNovoPublicoAlvo.Name = "btnNovoPublicoAlvo";
            btnNovoPublicoAlvo.Size = new Size(23, 22);
            btnNovoPublicoAlvo.Text = "&Nova";
            btnNovoPublicoAlvo.ToolTipText = "Novo Prompt";
            // 
            // btnAbrirPublicoAlvo
            // 
            btnAbrirPublicoAlvo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAbrirPublicoAlvo.Image = (Image)resources.GetObject("btnAbrirPublicoAlvo.Image");
            btnAbrirPublicoAlvo.ImageTransparentColor = Color.Magenta;
            btnAbrirPublicoAlvo.Name = "btnAbrirPublicoAlvo";
            btnAbrirPublicoAlvo.Size = new Size(23, 22);
            btnAbrirPublicoAlvo.Text = "&Abrir";
            btnAbrirPublicoAlvo.ToolTipText = "Abrir Prompt ";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Ivory;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBox2.Location = new Point(333, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(327, 23);
            textBox2.TabIndex = 53;
            textBox2.TabStop = false;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(340, 99);
            label31.Name = "label31";
            label31.Size = new Size(125, 15);
            label31.TabIndex = 52;
            label31.Text = "PERFIL PUBLICO ALVO";
            // 
            // lstObjetivosEspecificosPesquisa
            // 
            lstObjetivosEspecificosPesquisa.Descricao = "OBJETIVOS ESPECIFICOS";
            lstObjetivosEspecificosPesquisa.Location = new Point(2, 94);
            lstObjetivosEspecificosPesquisa.Name = "lstObjetivosEspecificosPesquisa";
            lstObjetivosEspecificosPesquisa.NomeLista = "OBJETIVOS_ESPECIFICOS_PESQUISA";
            lstObjetivosEspecificosPesquisa.Size = new Size(326, 148);
            lstObjetivosEspecificosPesquisa.TabIndex = 51;
            // 
            // txtContextoProblema
            // 
            txtContextoProblema.BackColor = Color.Ivory;
            txtContextoProblema.CharacterCasing = CharacterCasing.Upper;
            txtContextoProblema.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtContextoProblema.Location = new Point(666, 70);
            txtContextoProblema.Name = "txtContextoProblema";
            txtContextoProblema.Size = new Size(371, 23);
            txtContextoProblema.TabIndex = 50;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(670, 55);
            label30.Name = "label30";
            label30.Size = new Size(132, 15);
            label30.TabIndex = 49;
            label30.Text = "CONTEXTO PROBLEMA";
            // 
            // txtJustificativa
            // 
            txtJustificativa.BackColor = Color.Ivory;
            txtJustificativa.CharacterCasing = CharacterCasing.Upper;
            txtJustificativa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtJustificativa.Location = new Point(335, 70);
            txtJustificativa.Name = "txtJustificativa";
            txtJustificativa.Size = new Size(327, 23);
            txtJustificativa.TabIndex = 48;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(339, 55);
            label29.Name = "label29";
            label29.Size = new Size(83, 15);
            label29.TabIndex = 47;
            label29.Text = "JUSTIFICATIVA";
            // 
            // txtPerguntaPesquisa
            // 
            txtPerguntaPesquisa.BackColor = Color.Ivory;
            txtPerguntaPesquisa.CharacterCasing = CharacterCasing.Upper;
            txtPerguntaPesquisa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtPerguntaPesquisa.Location = new Point(710, 24);
            txtPerguntaPesquisa.Name = "txtPerguntaPesquisa";
            txtPerguntaPesquisa.Size = new Size(327, 23);
            txtPerguntaPesquisa.TabIndex = 46;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(714, 9);
            label28.Name = "label28";
            label28.Size = new Size(122, 15);
            label28.TabIndex = 45;
            label28.Text = "PERGUNTA PESQUISA";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Ivory;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            textBox1.Location = new Point(2, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(327, 23);
            textBox1.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 55);
            label9.Name = "label9";
            label9.Size = new Size(97, 15);
            label9.TabIndex = 42;
            label9.Text = "OBJETIVO GERAL";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(891, 6);
            label27.Name = "label27";
            label27.Size = new Size(0, 15);
            label27.TabIndex = 39;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(612, 6);
            label26.Name = "label26";
            label26.Size = new Size(78, 15);
            label26.TabIndex = 38;
            label26.Text = "Data Termino";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(511, 6);
            label25.Name = "label25";
            label25.Size = new Size(63, 15);
            label25.TabIndex = 37;
            label25.Text = "Data Inicio";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(609, 25);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(95, 23);
            dateTimePicker2.TabIndex = 36;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(508, 25);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(95, 23);
            dateTimePicker1.TabIndex = 35;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(188, 6);
            label24.Name = "label24";
            label24.Size = new Size(79, 15);
            label24.TabIndex = 34;
            label24.Text = "Titulo Projeto";
            // 
            // txtTituloPesquisa
            // 
            txtTituloPesquisa.BackColor = Color.Ivory;
            txtTituloPesquisa.CharacterCasing = CharacterCasing.Upper;
            txtTituloPesquisa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtTituloPesquisa.Location = new Point(185, 24);
            txtTituloPesquisa.Name = "txtTituloPesquisa";
            txtTituloPesquisa.Size = new Size(317, 23);
            txtTituloPesquisa.TabIndex = 33;
            // 
            // cboModeloPesquisa
            // 
            cboModeloPesquisa.BackColor = Color.LavenderBlush;
            cboModeloPesquisa.FormattingEnabled = true;
            cboModeloPesquisa.Items.AddRange(new object[] { "Pesquisa de Mercado", "Pesquisa de Segmentação", "Pesquisa de Produto", "Pesquisa de Preço", "Pesquisa de Promoção", "Pesquisa de Distribuição", "Pesquisa de UX", "Pesquisa de ciências sociais" });
            cboModeloPesquisa.Location = new Point(2, 24);
            cboModeloPesquisa.Name = "cboModeloPesquisa";
            cboModeloPesquisa.Size = new Size(177, 23);
            cboModeloPesquisa.TabIndex = 1;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(6, 6);
            label23.Name = "label23";
            label23.Size = new Size(112, 15);
            label23.TabIndex = 32;
            label23.Text = "MODELO PESQUISA";
            // 
            // tabPagePublicoAlvoPesquisa
            // 
            tabPagePublicoAlvoPesquisa.Location = new Point(4, 24);
            tabPagePublicoAlvoPesquisa.Name = "tabPagePublicoAlvoPesquisa";
            tabPagePublicoAlvoPesquisa.Padding = new Padding(3);
            tabPagePublicoAlvoPesquisa.Size = new Size(1043, 365);
            tabPagePublicoAlvoPesquisa.TabIndex = 1;
            tabPagePublicoAlvoPesquisa.Text = "PUBLICO ALVO";
            tabPagePublicoAlvoPesquisa.UseVisualStyleBackColor = true;
            // 
            // BriefingPesquisaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlConfPesquisa);
            Controls.Add(toolStrip6);
            Controls.Add(label22);
            Controls.Add(txtDescricaoPromptPEsquisa);
            Name = "BriefingPesquisaControl";
            Size = new Size(1059, 573);
            toolStrip6.ResumeLayout(false);
            toolStrip6.PerformLayout();
            tabControlConfPesquisa.ResumeLayout(false);
            tabPage.ResumeLayout(false);
            tabPage.PerformLayout();
            toolStrip7.ResumeLayout(false);
            toolStrip7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip6;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private Label label22;
        private TextBox txtDescricaoPromptPEsquisa;
        private TabControl tabControlConfPesquisa;
        private TabPage tabPage;
        private ToolStrip toolStrip7;
        private ToolStripButton btnNovoPublicoAlvo;
        private ToolStripButton btnAbrirPublicoAlvo;
        private TextBox textBox2;
        private Label label31;
        private AdicionarListaControl lstObjetivosEspecificosPesquisa;
        private TextBox txtContextoProblema;
        private Label label30;
        private TextBox txtJustificativa;
        private Label label29;
        private TextBox txtPerguntaPesquisa;
        private Label label28;
        private TextBox textBox1;
        private Label label9;
        private Label label27;
        private Label label26;
        private Label label25;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label24;
        private TextBox txtTituloPesquisa;
        private ComboBox cboModeloPesquisa;
        private Label label23;
        private TabPage tabPagePublicoAlvoPesquisa;
    }
}
