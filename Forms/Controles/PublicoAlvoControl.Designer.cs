namespace AIBAM.Controles
{
    partial class PublicoAlvoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicoAlvoControl));
            txtOutrasInf = new TextBox();
            label16 = new Label();
            gbNivelConsciencia = new GroupBox();
            radioButton8 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox1 = new GroupBox();
            txtPropostaValor = new TextBox();
            label2 = new Label();
            txtNomePublico = new TextBox();
            label1 = new Label();
            txtDescricaoPublicoAlvo = new TextBox();
            label15 = new Label();
            groupBox2 = new GroupBox();
            cboRegiao = new ComboBox();
            label6 = new Label();
            txtCidade = new TextBox();
            label5 = new Label();
            txtEstado = new TextBox();
            label4 = new Label();
            txtPais = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            lstOcupacoes = new AdicionarListaControl();
            gbGenero = new GroupBox();
            radioButton16 = new RadioButton();
            radioButton15 = new RadioButton();
            radioButton14 = new RadioButton();
            radioButton13 = new RadioButton();
            radioButton12 = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton10 = new RadioButton();
            radioButton9 = new RadioButton();
            gbRangeIdade = new GroupBox();
            nIdadeFinal = new NumericUpDown();
            label14 = new Label();
            nIdadeInicial = new NumericUpDown();
            label13 = new Label();
            cboNivelAcademico = new ComboBox();
            label17 = new Label();
            groupBox4 = new GroupBox();
            lstDiferenciais = new AdicionarListaControl();
            lstDores = new AdicionarListaControl();
            lstInteresses = new AdicionarListaControl();
            groupBox5 = new GroupBox();
            txtTicketMedio = new TextBox();
            label9 = new Label();
            txtReceitaAnualMedia = new TextBox();
            label8 = new Label();
            txtTamanhoMercado = new TextBox();
            label7 = new Label();
            toolStrip4 = new ToolStrip();
            novaToolStripButton1 = new ToolStripButton();
            abrirToolStripButton1 = new ToolStripButton();
            salvarToolStripButton = new ToolStripButton();
            salvarToolStripButton1 = new ToolStripButton();
            gbNivelConsciencia.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            gbGenero.SuspendLayout();
            gbRangeIdade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nIdadeFinal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nIdadeInicial).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // txtOutrasInf
            // 
            txtOutrasInf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtOutrasInf.Location = new Point(653, 32);
            txtOutrasInf.Multiline = true;
            txtOutrasInf.Name = "txtOutrasInf";
            txtOutrasInf.Size = new Size(355, 136);
            txtOutrasInf.TabIndex = 5;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(653, 10);
            label16.Name = "label16";
            label16.Size = new Size(111, 15);
            label16.TabIndex = 36;
            label16.Text = "Outras informações";
            // 
            // gbNivelConsciencia
            // 
            gbNivelConsciencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbNivelConsciencia.Controls.Add(radioButton8);
            gbNivelConsciencia.Controls.Add(radioButton7);
            gbNivelConsciencia.Controls.Add(radioButton6);
            gbNivelConsciencia.Controls.Add(radioButton5);
            gbNivelConsciencia.Controls.Add(radioButton4);
            gbNivelConsciencia.Controls.Add(radioButton3);
            gbNivelConsciencia.Location = new Point(361, 10);
            gbNivelConsciencia.Name = "gbNivelConsciencia";
            gbNivelConsciencia.Size = new Size(286, 158);
            gbNivelConsciencia.TabIndex = 4;
            gbNivelConsciencia.TabStop = false;
            gbNivelConsciencia.Text = "NÍVEL CONSCIÊNCIA";
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(12, 134);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(116, 19);
            radioButton8.TabIndex = 5;
            radioButton8.Text = "Cliente fidelizado";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(12, 111);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(267, 19);
            radioButton7.TabIndex = 4;
            radioButton7.Text = "Totalmente consciente e pronto para comprar";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(12, 88);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(201, 19);
            radioButton6.TabIndex = 3;
            radioButton6.Text = "Consciente do produto/categoria";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(12, 63);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(144, 19);
            radioButton5.TabIndex = 2;
            radioButton5.Text = "Consciente da solucao";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(12, 38);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(155, 19);
            radioButton4.TabIndex = 1;
            radioButton4.Text = "Consciente do problema";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Location = new Point(12, 15);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(163, 19);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "Inconsciente do problema";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtPropostaValor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNomePublico);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDescricaoPublicoAlvo);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtOutrasInf);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(gbNivelConsciencia);
            groupBox1.Location = new Point(0, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1019, 178);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "INFORMAÇÕES GERAIS";
            // 
            // txtPropostaValor
            // 
            txtPropostaValor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPropostaValor.Location = new Point(6, 128);
            txtPropostaValor.Name = "txtPropostaValor";
            txtPropostaValor.Size = new Size(353, 23);
            txtPropostaValor.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 111);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 40;
            label2.Text = "PROPOSTA DE VALOR";
            // 
            // txtNomePublico
            // 
            txtNomePublico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomePublico.Location = new Point(6, 39);
            txtNomePublico.Name = "txtNomePublico";
            txtNomePublico.Size = new Size(353, 23);
            txtNomePublico.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 38;
            label1.Text = "NOME";
            // 
            // txtDescricaoPublicoAlvo
            // 
            txtDescricaoPublicoAlvo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescricaoPublicoAlvo.Location = new Point(6, 80);
            txtDescricaoPublicoAlvo.Name = "txtDescricaoPublicoAlvo";
            txtDescricaoPublicoAlvo.Size = new Size(353, 23);
            txtDescricaoPublicoAlvo.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 63);
            label15.Name = "label15";
            label15.Size = new Size(70, 15);
            label15.TabIndex = 20;
            label15.Text = "DESCRIÇÃO";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(cboRegiao);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtCidade);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtEstado);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtPais);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(0, 89);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(689, 75);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "SEGMENTAÇÃO GEOGRÁFICA";
            // 
            // cboRegiao
            // 
            cboRegiao.BackColor = Color.LavenderBlush;
            cboRegiao.FormattingEnabled = true;
            cboRegiao.Items.AddRange(new object[] { "Região Metropolitana", "Zona Rural", "Centro Urbano", "Região Portuária", "Região Industrial", "Área Comercial", "Distrito Tecnológico", "Polo Agroindustrial", "Polo Petroquímico", "Zona Franca", "Região Litorânea", "Polo Turístico", "Eixo Rodoviário", "Área Metropolitana Expandida", "Região de Fronteira", "Região de Alto Crescimento Econômico", "Centro Histórico", "Região Periférica", "Polo Educacional", "Região de Logística e Transporte" });
            cboRegiao.Location = new Point(465, 44);
            cboRegiao.Name = "cboRegiao";
            cboRegiao.Size = new Size(204, 23);
            cboRegiao.TabIndex = 47;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(465, 26);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 46;
            label6.Text = "REGIÃO";
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(300, 43);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(159, 23);
            txtCidade.TabIndex = 43;
            txtCidade.Text = "SÃO PAULO";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(300, 26);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 44;
            label5.Text = "CIDADE";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(135, 43);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(159, 23);
            txtEstado.TabIndex = 41;
            txtEstado.Text = "SÃO PAULO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 26);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 42;
            label4.Text = "ESTADO";
            // 
            // txtPais
            // 
            txtPais.Location = new Point(6, 44);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(122, 23);
            txtPais.TabIndex = 39;
            txtPais.Text = "BRASIL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 27);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 40;
            label3.Text = "PAÍS";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(lstOcupacoes);
            groupBox3.Controls.Add(gbGenero);
            groupBox3.Controls.Add(gbRangeIdade);
            groupBox3.Controls.Add(cboNivelAcademico);
            groupBox3.Controls.Add(label17);
            groupBox3.Location = new Point(0, 188);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1019, 173);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "SEGMENTAÇÃO DEMOGRÁFICA";
            // 
            // lstOcupacoes
            // 
            lstOcupacoes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstOcupacoes.Descricao = "OCUPAÇÕES DO PUBLICO ALVO";
            lstOcupacoes.Location = new Point(691, 22);
            lstOcupacoes.Name = "lstOcupacoes";
            lstOcupacoes.NomeLista = "OCUPACAO_PUBLICO_ALVO";
            lstOcupacoes.Size = new Size(325, 151);
            lstOcupacoes.TabIndex = 4;
            // 
            // gbGenero
            // 
            gbGenero.Controls.Add(radioButton16);
            gbGenero.Controls.Add(radioButton15);
            gbGenero.Controls.Add(radioButton14);
            gbGenero.Controls.Add(radioButton13);
            gbGenero.Controls.Add(radioButton12);
            gbGenero.Controls.Add(radioButton11);
            gbGenero.Controls.Add(radioButton10);
            gbGenero.Controls.Add(radioButton9);
            gbGenero.Location = new Point(351, 22);
            gbGenero.Name = "gbGenero";
            gbGenero.Size = new Size(331, 65);
            gbGenero.TabIndex = 3;
            gbGenero.TabStop = false;
            gbGenero.Text = "GÊNERO";
            // 
            // radioButton16
            // 
            radioButton16.AutoSize = true;
            radioButton16.Location = new Point(108, 41);
            radioButton16.Name = "radioButton16";
            radioButton16.Size = new Size(105, 19);
            radioButton16.TabIndex = 6;
            radioButton16.Text = "GENDERQUEER";
            radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            radioButton15.AutoSize = true;
            radioButton15.Location = new Point(9, 42);
            radioButton15.Name = "radioButton15";
            radioButton15.Size = new Size(93, 19);
            radioButton15.TabIndex = 5;
            radioButton15.Text = "PANGÊNERO";
            radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            radioButton14.AutoSize = true;
            radioButton14.Location = new Point(230, 19);
            radioButton14.Name = "radioButton14";
            radioButton14.Size = new Size(78, 19);
            radioButton14.TabIndex = 4;
            radioButton14.Text = "AGÊNERO";
            radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            radioButton13.AutoSize = true;
            radioButton13.Location = new Point(147, 19);
            radioButton13.Name = "radioButton13";
            radioButton13.Size = new Size(83, 19);
            radioButton13.TabIndex = 3;
            radioButton13.Text = "N BINARIO";
            radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new Point(84, 19);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new Size(62, 19);
            radioButton12.TabIndex = 2;
            radioButton12.Text = "TRANS";
            radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new Point(44, 19);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new Size(36, 19);
            radioButton11.TabIndex = 1;
            radioButton11.Text = "M";
            radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Checked = true;
            radioButton10.Location = new Point(231, 42);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(63, 19);
            radioButton10.TabIndex = 7;
            radioButton10.TabStop = true;
            radioButton10.Text = "TODOS";
            radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(9, 19);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(31, 19);
            radioButton9.TabIndex = 0;
            radioButton9.Text = "F";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // gbRangeIdade
            // 
            gbRangeIdade.Controls.Add(nIdadeFinal);
            gbRangeIdade.Controls.Add(label14);
            gbRangeIdade.Controls.Add(nIdadeInicial);
            gbRangeIdade.Controls.Add(label13);
            gbRangeIdade.Location = new Point(7, 22);
            gbRangeIdade.Name = "gbRangeIdade";
            gbRangeIdade.Size = new Size(121, 61);
            gbRangeIdade.TabIndex = 1;
            gbRangeIdade.TabStop = false;
            gbRangeIdade.Text = "RANGE IDADE";
            // 
            // nIdadeFinal
            // 
            nIdadeFinal.Location = new Point(59, 31);
            nIdadeFinal.Name = "nIdadeFinal";
            nIdadeFinal.Size = new Size(47, 23);
            nIdadeFinal.TabIndex = 5;
            nIdadeFinal.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(55, 12);
            label14.Name = "label14";
            label14.Size = new Size(15, 15);
            label14.TabIndex = 4;
            label14.Text = "A";
            // 
            // nIdadeInicial
            // 
            nIdadeInicial.Location = new Point(6, 31);
            nIdadeInicial.Name = "nIdadeInicial";
            nIdadeInicial.Size = new Size(47, 23);
            nIdadeInicial.TabIndex = 3;
            nIdadeInicial.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(2, 12);
            label13.Name = "label13";
            label13.Size = new Size(21, 15);
            label13.TabIndex = 2;
            label13.Text = "De";
            // 
            // cboNivelAcademico
            // 
            cboNivelAcademico.BackColor = Color.LavenderBlush;
            cboNivelAcademico.FormattingEnabled = true;
            cboNivelAcademico.Items.AddRange(new object[] { "Ensino Fundamental Incompleto", "Ensino Fundamental Completo", "Ensino Médio Incompleto", "Ensino Médio Completo", "Técnico", "Graduação Incompleta", "Graduação Completa", "Pós-Graduação Incompleta", "Pós-Graduação Completa", "Mestrado Incompleto", "Mestrado Completo", "Doutorado Incompleto", "Doutorado Completo", "MBA", "Livre Docência", "Pós-Doutorado" });
            cboNivelAcademico.Location = new Point(134, 47);
            cboNivelAcademico.Name = "cboNivelAcademico";
            cboNivelAcademico.Size = new Size(204, 23);
            cboNivelAcademico.TabIndex = 2;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(134, 29);
            label17.Name = "label17";
            label17.Size = new Size(95, 15);
            label17.TabIndex = 42;
            label17.Text = "Nível acadêmico";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(lstDiferenciais);
            groupBox4.Controls.Add(lstDores);
            groupBox4.Controls.Add(lstInteresses);
            groupBox4.Location = new Point(0, 358);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1019, 182);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "SEGMENTAÇÃO COMPORTAMENTAL";
            // 
            // lstDiferenciais
            // 
            lstDiferenciais.Descricao = "DIREFERENCIAIS COMPETITIVOS";
            lstDiferenciais.Location = new Point(684, 22);
            lstDiferenciais.Name = "lstDiferenciais";
            lstDiferenciais.NomeLista = "DIFERENCIAIS_COMPETITIVOS";
            lstDiferenciais.Size = new Size(326, 148);
            lstDiferenciais.TabIndex = 3;
            // 
            // lstDores
            // 
            lstDores.Descricao = "DORES DO PUBLICO ALVO";
            lstDores.Location = new Point(348, 22);
            lstDores.Name = "lstDores";
            lstDores.NomeLista = "DORES_PUBLICO_ALVO";
            lstDores.Size = new Size(325, 148);
            lstDores.TabIndex = 2;
            // 
            // lstInteresses
            // 
            lstInteresses.Descricao = "INTERESSES DO PUBLICO ALVO";
            lstInteresses.Location = new Point(10, 22);
            lstInteresses.Name = "lstInteresses";
            lstInteresses.NomeLista = "INTERESSES_PUBLICO_ALVO";
            lstInteresses.Size = new Size(327, 148);
            lstInteresses.TabIndex = 1;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(txtTicketMedio);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(txtReceitaAnualMedia);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(txtTamanhoMercado);
            groupBox5.Controls.Add(label7);
            groupBox5.Location = new Point(0, 534);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1019, 97);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "SEGMENTAÇÃO DE VOLUME";
            // 
            // txtTicketMedio
            // 
            txtTicketMedio.Location = new Point(470, 39);
            txtTicketMedio.Name = "txtTicketMedio";
            txtTicketMedio.Size = new Size(219, 23);
            txtTicketMedio.TabIndex = 3;
            txtTicketMedio.TextAlign = HorizontalAlignment.Right;
            txtTicketMedio.KeyPress += txtTicketMedio_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(470, 22);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 44;
            label9.Text = "TICKET MÉDIO";
            // 
            // txtReceitaAnualMedia
            // 
            txtReceitaAnualMedia.Location = new Point(240, 39);
            txtReceitaAnualMedia.Name = "txtReceitaAnualMedia";
            txtReceitaAnualMedia.Size = new Size(219, 23);
            txtReceitaAnualMedia.TabIndex = 2;
            txtReceitaAnualMedia.TextAlign = HorizontalAlignment.Right;
            txtReceitaAnualMedia.KeyPress += txtReceitaAnualMedia_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(240, 22);
            label8.Name = "label8";
            label8.Size = new Size(132, 15);
            label8.TabIndex = 42;
            label8.Text = "RECEITA ANUAL MÉDIA";
            // 
            // txtTamanhoMercado
            // 
            txtTamanhoMercado.Location = new Point(10, 39);
            txtTamanhoMercado.Name = "txtTamanhoMercado";
            txtTamanhoMercado.Size = new Size(219, 23);
            txtTamanhoMercado.TabIndex = 1;
            txtTamanhoMercado.TextAlign = HorizontalAlignment.Right;
            txtTamanhoMercado.KeyPress += txtTamanhoMercado_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 22);
            label7.Name = "label7";
            label7.Size = new Size(147, 15);
            label7.TabIndex = 40;
            label7.Text = "TAMANHO DO MERCADO";
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, salvarToolStripButton });
            toolStrip4.Location = new Point(951, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(72, 25);
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
            novaToolStripButton1.Text = "&Novo Publico Alvo";
            novaToolStripButton1.ToolTipText = "Novo Publico Alvo";
            novaToolStripButton1.Click += novaToolStripButton1_Click;
            // 
            // abrirToolStripButton1
            // 
            abrirToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton1.Image = (Image)resources.GetObject("abrirToolStripButton1.Image");
            abrirToolStripButton1.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton1.Name = "abrirToolStripButton1";
            abrirToolStripButton1.Size = new Size(23, 22);
            abrirToolStripButton1.Text = "$Abrir Publico Alvo";
            abrirToolStripButton1.ToolTipText = "Abrir Publico Alvo";
            abrirToolStripButton1.Click += abrirToolStripButton1_Click;
            // 
            // salvarToolStripButton
            // 
            salvarToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton.Image = (Image)resources.GetObject("salvarToolStripButton.Image");
            salvarToolStripButton.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton.Name = "salvarToolStripButton";
            salvarToolStripButton.Size = new Size(23, 22);
            salvarToolStripButton.Text = "&Salvar Publico Alvo";
            salvarToolStripButton.Click += salvarToolStripButton_Click;
            // 
            // salvarToolStripButton1
            // 
            salvarToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton1.Image = (Image)resources.GetObject("salvarToolStripButton1.Image");
            salvarToolStripButton1.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton1.Name = "salvarToolStripButton1";
            salvarToolStripButton1.Size = new Size(23, 22);
            salvarToolStripButton1.Text = "&Salvar Publico Alvo";
            salvarToolStripButton1.ToolTipText = "Salvar Publico Alvo";
            // 
            // PublicoAlvoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "PublicoAlvoControl";
            Size = new Size(1019, 634);
            Load += PublicoAlvoControl_Load;
            gbNivelConsciencia.ResumeLayout(false);
            gbNivelConsciencia.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbGenero.ResumeLayout(false);
            gbGenero.PerformLayout();
            gbRangeIdade.ResumeLayout(false);
            gbRangeIdade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nIdadeFinal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nIdadeInicial).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtOutrasInf;
        private Label label16;
        private GroupBox gbNivelConsciencia;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtPropostaValor;
        private Label label2;
        private TextBox txtNomePublico;
        private Label label1;
        private TextBox txtDescricaoPublicoAlvo;
        private Label label15;
        private TextBox txtEstado;
        private Label label4;
        private TextBox txtPais;
        private Label label3;
        private TextBox txtCidade;
        private Label label5;
        private ComboBox cboRegiao;
        private Label label6;
        private GroupBox groupBox3;
        private GroupBox gbGenero;
        private RadioButton radioButton16;
        private RadioButton radioButton15;
        private RadioButton radioButton14;
        private RadioButton radioButton13;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private RadioButton radioButton9;
        private GroupBox gbRangeIdade;
        private NumericUpDown nIdadeFinal;
        private Label label14;
        private NumericUpDown nIdadeInicial;
        private Label label13;
        private ComboBox cboNivelAcademico;
        private Label label17;
        private AdicionarListaControl lstOcupacoes;
        private GroupBox groupBox4;
        private AdicionarListaControl lstDiferenciais;
        private AdicionarListaControl lstDores;
        private AdicionarListaControl lstInteresses;
        private GroupBox groupBox5;
        private TextBox txtTamanhoMercado;
        private Label label7;
        private TextBox txtReceitaAnualMedia;
        private Label label8;
        private TextBox txtTicketMedio;
        private Label label9;
        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private ToolStripButton salvarToolStripButton1;
        private ToolStripButton salvarToolStripButton;
    }
}
