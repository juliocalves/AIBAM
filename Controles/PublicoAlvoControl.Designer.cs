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
            listDiferenciais = new AdicionarListaControl();
            lstDores = new AdicionarListaControl();
            lstOcupacoes = new AdicionarListaControl();
            lstInteresses = new AdicionarListaControl();
            txtOutrasInf = new TextBox();
            label16 = new Label();
            gbGenero = new GroupBox();
            radioButton16 = new RadioButton();
            radioButton15 = new RadioButton();
            radioButton14 = new RadioButton();
            radioButton13 = new RadioButton();
            radioButton12 = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton10 = new RadioButton();
            radioButton9 = new RadioButton();
            gbNivelConsciencia = new GroupBox();
            radioButton8 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            txtPropostaValor = new TextBox();
            label15 = new Label();
            cboNivelAcademico = new ComboBox();
            label17 = new Label();
            gbRangeIdade = new GroupBox();
            nIdadeFinal = new NumericUpDown();
            label14 = new Label();
            nIdadeInicial = new NumericUpDown();
            label13 = new Label();
            gbGenero.SuspendLayout();
            gbNivelConsciencia.SuspendLayout();
            gbRangeIdade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nIdadeFinal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nIdadeInicial).BeginInit();
            SuspendLayout();
            // 
            // listDiferenciais
            // 
            listDiferenciais.Descricao = "DIFERENCIAIS COMPETITIVOS";
            listDiferenciais.Location = new Point(3, 226);
            listDiferenciais.Name = "listDiferenciais";
            listDiferenciais.NomeLista = "DIFERENCIAIS_COMPETITIVOS";
            listDiferenciais.Size = new Size(327, 148);
            listDiferenciais.TabIndex = 31;
            // 
            // lstDores
            // 
            lstDores.Descricao = "DORES DO PUBLICO ALVO";
            lstDores.Location = new Point(664, 72);
            lstDores.Name = "lstDores";
            lstDores.NomeLista = "DORES_PUBLICO_ALVO";
            lstDores.Size = new Size(325, 148);
            lstDores.TabIndex = 30;
            // 
            // lstOcupacoes
            // 
            lstOcupacoes.Descricao = "OCUPAÇÕES DO PUBLICO ALVO";
            lstOcupacoes.Location = new Point(331, 72);
            lstOcupacoes.Name = "lstOcupacoes";
            lstOcupacoes.NomeLista = "OCUPACAO_PUBLICO_ALVO";
            lstOcupacoes.Size = new Size(325, 148);
            lstOcupacoes.TabIndex = 29;
            // 
            // lstInteresses
            // 
            lstInteresses.Descricao = "INTERESSES DO PUBLICO ALVO";
            lstInteresses.Location = new Point(3, 72);
            lstInteresses.Name = "lstInteresses";
            lstInteresses.NomeLista = "INTERESSES_PUBLICO_ALVO";
            lstInteresses.Size = new Size(327, 148);
            lstInteresses.TabIndex = 28;
            // 
            // txtOutrasInf
            // 
            txtOutrasInf.Location = new Point(634, 233);
            txtOutrasInf.Multiline = true;
            txtOutrasInf.Name = "txtOutrasInf";
            txtOutrasInf.Size = new Size(355, 136);
            txtOutrasInf.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(635, 220);
            label16.Name = "label16";
            label16.Size = new Size(167, 15);
            label16.TabIndex = 36;
            label16.Text = "Outras informações relevantes";
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
            gbGenero.Location = new Point(130, 3);
            gbGenero.Name = "gbGenero";
            gbGenero.Size = new Size(308, 65);
            gbGenero.TabIndex = 25;
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
            // gbNivelConsciencia
            // 
            gbNivelConsciencia.Controls.Add(radioButton8);
            gbNivelConsciencia.Controls.Add(radioButton7);
            gbNivelConsciencia.Controls.Add(radioButton6);
            gbNivelConsciencia.Controls.Add(radioButton5);
            gbNivelConsciencia.Controls.Add(radioButton4);
            gbNivelConsciencia.Controls.Add(radioButton3);
            gbNivelConsciencia.Location = new Point(333, 219);
            gbNivelConsciencia.Name = "gbNivelConsciencia";
            gbNivelConsciencia.Size = new Size(286, 154);
            gbNivelConsciencia.TabIndex = 32;
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
            // txtPropostaValor
            // 
            txtPropostaValor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPropostaValor.Location = new Point(657, 21);
            txtPropostaValor.Name = "txtPropostaValor";
            txtPropostaValor.Size = new Size(332, 23);
            txtPropostaValor.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(654, 4);
            label15.Name = "label15";
            label15.Size = new Size(99, 15);
            label15.TabIndex = 35;
            label15.Text = "Proposta de Valor";
            // 
            // cboNivelAcademico
            // 
            cboNivelAcademico.BackColor = Color.LavenderBlush;
            cboNivelAcademico.FormattingEnabled = true;
            cboNivelAcademico.Items.AddRange(new object[] { "Ensino Fundamental Incompleto", "Ensino Fundamental Completo", "Ensino Médio Incompleto", "Ensino Médio Completo", "Técnico", "Graduação Incompleta", "Graduação Completa", "Pós-Graduação Incompleta", "Pós-Graduação Completa", "Mestrado Incompleto", "Mestrado Completo", "Doutorado Incompleto", "Doutorado Completo", "MBA", "Livre Docência", "Pós-Doutorado" });
            cboNivelAcademico.Location = new Point(444, 21);
            cboNivelAcademico.Name = "cboNivelAcademico";
            cboNivelAcademico.Size = new Size(204, 23);
            cboNivelAcademico.TabIndex = 26;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(444, 4);
            label17.Name = "label17";
            label17.Size = new Size(95, 15);
            label17.TabIndex = 34;
            label17.Text = "Nível acadêmico";
            // 
            // gbRangeIdade
            // 
            gbRangeIdade.Controls.Add(nIdadeFinal);
            gbRangeIdade.Controls.Add(label14);
            gbRangeIdade.Controls.Add(nIdadeInicial);
            gbRangeIdade.Controls.Add(label13);
            gbRangeIdade.Location = new Point(3, 3);
            gbRangeIdade.Name = "gbRangeIdade";
            gbRangeIdade.Size = new Size(121, 61);
            gbRangeIdade.TabIndex = 24;
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
            // PublicoAlvoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listDiferenciais);
            Controls.Add(lstDores);
            Controls.Add(lstOcupacoes);
            Controls.Add(lstInteresses);
            Controls.Add(txtOutrasInf);
            Controls.Add(label16);
            Controls.Add(gbGenero);
            Controls.Add(gbNivelConsciencia);
            Controls.Add(txtPropostaValor);
            Controls.Add(label15);
            Controls.Add(cboNivelAcademico);
            Controls.Add(label17);
            Controls.Add(gbRangeIdade);
            Name = "PublicoAlvoControl";
            Size = new Size(996, 385);
            gbGenero.ResumeLayout(false);
            gbGenero.PerformLayout();
            gbNivelConsciencia.ResumeLayout(false);
            gbNivelConsciencia.PerformLayout();
            gbRangeIdade.ResumeLayout(false);
            gbRangeIdade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nIdadeFinal).EndInit();
            ((System.ComponentModel.ISupportInitialize)nIdadeInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AdicionarListaControl listDiferenciais;
        private AdicionarListaControl lstDores;
        private AdicionarListaControl lstOcupacoes;
        private AdicionarListaControl lstInteresses;
        private TextBox txtOutrasInf;
        private Label label16;
        private GroupBox gbGenero;
        private RadioButton radioButton16;
        private RadioButton radioButton15;
        private RadioButton radioButton14;
        private RadioButton radioButton13;
        private RadioButton radioButton12;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private RadioButton radioButton9;
        private GroupBox gbNivelConsciencia;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private TextBox txtPropostaValor;
        private Label label15;
        private ComboBox cboNivelAcademico;
        private Label label17;
        private GroupBox gbRangeIdade;
        private NumericUpDown nIdadeFinal;
        private Label label14;
        private NumericUpDown nIdadeInicial;
        private Label label13;
    }
}
