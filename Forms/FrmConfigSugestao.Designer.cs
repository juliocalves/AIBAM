namespace AIBAM.Forms
{
    partial class FrmConfigSugestao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigSugestao));
            pnlModelSettings = new Panel();
            groupBox4 = new GroupBox();
            tbPerigoso = new TrackBar();
            label8 = new Label();
            label7 = new Label();
            tbDiscurso = new TrackBar();
            label6 = new Label();
            tbAssedio = new TrackBar();
            label5 = new Label();
            groupBox2 = new GroupBox();
            tbTokens = new TrackBar();
            txtTokens = new TextBox();
            groupBox1 = new GroupBox();
            tbTemperatura = new TrackBar();
            txtTemperatura = new TextBox();
            groupBox3 = new GroupBox();
            cboModelName = new ComboBox();
            splitContainer1 = new SplitContainer();
            groupBox5 = new GroupBox();
            adicionarListaControl1 = new AdicionarListaControl();
            txtDescricacaoModelo = new TextBox();
            label3 = new Label();
            txtIdentificacaoModelo = new TextBox();
            label2 = new Label();
            txtNomeModelo = new TextBox();
            label1 = new Label();
            splitContainer2 = new SplitContainer();
            groupBox9 = new GroupBox();
            groupBox8 = new GroupBox();
            splitContainer3 = new SplitContainer();
            groupBox7 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            groupBox6 = new GroupBox();
            cboFormatoSaida = new ComboBox();
            groupBox10 = new GroupBox();
            adicionarListaControl3 = new AdicionarListaControl();
            adicionarListaControl2 = new AdicionarListaControl();
            splitContainer4 = new SplitContainer();
            btnCancelar = new Button();
            btnSalvar = new Button();
            groupBox11 = new GroupBox();
            tbSexual = new TrackBar();
            txtSeparador = new TextBox();
            pnlModelSettings.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbPerigoso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDiscurso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbAssedio).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTokens).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbTemperatura).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox6.SuspendLayout();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSexual).BeginInit();
            SuspendLayout();
            // 
            // pnlModelSettings
            // 
            pnlModelSettings.AutoScroll = true;
            pnlModelSettings.BorderStyle = BorderStyle.Fixed3D;
            pnlModelSettings.Controls.Add(groupBox4);
            pnlModelSettings.Controls.Add(groupBox2);
            pnlModelSettings.Controls.Add(groupBox1);
            pnlModelSettings.Controls.Add(groupBox3);
            pnlModelSettings.Dock = DockStyle.Fill;
            pnlModelSettings.Location = new Point(0, 0);
            pnlModelSettings.Name = "pnlModelSettings";
            pnlModelSettings.Size = new Size(213, 158);
            pnlModelSettings.TabIndex = 25;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tbPerigoso);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(tbSexual);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(tbDiscurso);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(tbAssedio);
            groupBox4.Controls.Add(label5);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 150);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(192, 255);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Filtros segurança";
            // 
            // tbPerigoso
            // 
            tbPerigoso.Dock = DockStyle.Top;
            tbPerigoso.LargeChange = 32;
            tbPerigoso.Location = new Point(3, 214);
            tbPerigoso.Maximum = 5;
            tbPerigoso.Name = "tbPerigoso";
            tbPerigoso.Size = new Size(186, 45);
            tbPerigoso.TabIndex = 11;
            tbPerigoso.TickStyle = TickStyle.None;
            tbPerigoso.Scroll += tbPerigoso_Scroll;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Top;
            label8.Location = new Point(3, 199);
            label8.Name = "label8";
            label8.Size = new Size(62, 15);
            label8.TabIndex = 12;
            label8.Text = "PERIGOSO";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Location = new Point(3, 139);
            label7.Name = "label7";
            label7.Size = new Size(145, 15);
            label7.TabIndex = 10;
            label7.Text = "SEXUALMENTE EXPLÍCITO";
            // 
            // tbDiscurso
            // 
            tbDiscurso.Dock = DockStyle.Top;
            tbDiscurso.LargeChange = 32;
            tbDiscurso.Location = new Point(3, 94);
            tbDiscurso.Maximum = 5;
            tbDiscurso.Name = "tbDiscurso";
            tbDiscurso.Size = new Size(186, 45);
            tbDiscurso.TabIndex = 7;
            tbDiscurso.TickStyle = TickStyle.None;
            tbDiscurso.Scroll += tbDiscurso_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(3, 79);
            label6.Name = "label6";
            label6.Size = new Size(111, 15);
            label6.TabIndex = 8;
            label6.Text = "DISCURSO DE ÓDIO";
            // 
            // tbAssedio
            // 
            tbAssedio.Dock = DockStyle.Top;
            tbAssedio.LargeChange = 32;
            tbAssedio.Location = new Point(3, 34);
            tbAssedio.Maximum = 5;
            tbAssedio.Name = "tbAssedio";
            tbAssedio.Size = new Size(186, 45);
            tbAssedio.TabIndex = 5;
            tbAssedio.TickStyle = TickStyle.None;
            tbAssedio.Scroll += tbAssedio_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(3, 19);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 6;
            label5.Text = "ASSÉDIO";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbTokens);
            groupBox2.Controls.Add(txtTokens);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(192, 50);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Limite tokens saída";
            // 
            // tbTokens
            // 
            tbTokens.Dock = DockStyle.Left;
            tbTokens.LargeChange = 32;
            tbTokens.Location = new Point(3, 19);
            tbTokens.Maximum = 8192;
            tbTokens.Name = "tbTokens";
            tbTokens.Size = new Size(95, 28);
            tbTokens.TabIndex = 4;
            tbTokens.TickStyle = TickStyle.None;
            tbTokens.Scroll += tbTokens_Scroll;
            // 
            // txtTokens
            // 
            txtTokens.Dock = DockStyle.Right;
            txtTokens.Location = new Point(137, 19);
            txtTokens.Name = "txtTokens";
            txtTokens.Size = new Size(52, 23);
            txtTokens.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbTemperatura);
            groupBox1.Controls.Add(txtTemperatura);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(192, 50);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Temperatura";
            // 
            // tbTemperatura
            // 
            tbTemperatura.Dock = DockStyle.Left;
            tbTemperatura.Location = new Point(3, 19);
            tbTemperatura.Maximum = 200;
            tbTemperatura.Name = "tbTemperatura";
            tbTemperatura.Size = new Size(95, 28);
            tbTemperatura.TabIndex = 1;
            tbTemperatura.TickStyle = TickStyle.None;
            tbTemperatura.Scroll += tbTemperatura_Scroll;
            // 
            // txtTemperatura
            // 
            txtTemperatura.Dock = DockStyle.Right;
            txtTemperatura.Location = new Point(137, 19);
            txtTemperatura.Name = "txtTemperatura";
            txtTemperatura.Size = new Size(52, 23);
            txtTemperatura.TabIndex = 2;
            txtTemperatura.KeyPress += txtTemperatura_KeyPress;
            txtTemperatura.Leave += txtTemperatura_Leave;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboModelName);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(192, 50);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "IA Nome";
            // 
            // cboModelName
            // 
            cboModelName.Dock = DockStyle.Bottom;
            cboModelName.FormattingEnabled = true;
            cboModelName.Location = new Point(3, 24);
            cboModelName.Name = "cboModelName";
            cboModelName.Size = new Size(186, 23);
            cboModelName.TabIndex = 25;
            cboModelName.SelectedIndexChanged += cboModelName_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 19);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlModelSettings);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox5);
            splitContainer1.Size = new Size(971, 158);
            splitContainer1.SplitterDistance = 213;
            splitContainer1.TabIndex = 26;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(adicionarListaControl1);
            groupBox5.Controls.Add(txtDescricacaoModelo);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(txtIdentificacaoModelo);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(txtNomeModelo);
            groupBox5.Controls.Add(label1);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(754, 158);
            groupBox5.TabIndex = 13;
            groupBox5.TabStop = false;
            groupBox5.Text = "MODELO INSTRUÇÃO";
            // 
            // adicionarListaControl1
            // 
            adicionarListaControl1.Descricao = "REGRAS MODELO";
            adicionarListaControl1.Dock = DockStyle.Right;
            adicionarListaControl1.Location = new Point(428, 19);
            adicionarListaControl1.Name = "adicionarListaControl1";
            adicionarListaControl1.NomeLista = "label1";
            adicionarListaControl1.SeparaPorVirgula = true;
            adicionarListaControl1.Size = new Size(323, 136);
            adicionarListaControl1.TabIndex = 10;
            // 
            // txtDescricacaoModelo
            // 
            txtDescricacaoModelo.AcceptsTab = true;
            txtDescricacaoModelo.Location = new Point(1, 131);
            txtDescricacaoModelo.Multiline = true;
            txtDescricacaoModelo.Name = "txtDescricacaoModelo";
            txtDescricacaoModelo.Size = new Size(423, 23);
            txtDescricacaoModelo.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1, 113);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 9;
            label3.Text = "Instrução Modelo";
            // 
            // txtIdentificacaoModelo
            // 
            txtIdentificacaoModelo.Location = new Point(1, 84);
            txtIdentificacaoModelo.Name = "txtIdentificacaoModelo";
            txtIdentificacaoModelo.Size = new Size(423, 23);
            txtIdentificacaoModelo.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 66);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 7;
            label2.Text = "Identificação Modelo (Chave)";
            // 
            // txtNomeModelo
            // 
            txtNomeModelo.Location = new Point(1, 43);
            txtNomeModelo.Name = "txtNomeModelo";
            txtNomeModelo.Size = new Size(423, 23);
            txtNomeModelo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 25);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome Modelo";
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
            splitContainer2.Panel1.Controls.Add(groupBox9);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox8);
            splitContainer2.Size = new Size(977, 383);
            splitContainer2.SplitterDistance = 180;
            splitContainer2.TabIndex = 27;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(splitContainer1);
            groupBox9.Dock = DockStyle.Fill;
            groupBox9.Location = new Point(0, 0);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(977, 180);
            groupBox9.TabIndex = 27;
            groupBox9.TabStop = false;
            groupBox9.Text = "Configurações Modelo";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(splitContainer3);
            groupBox8.Dock = DockStyle.Fill;
            groupBox8.Location = new Point(0, 0);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(977, 199);
            groupBox8.TabIndex = 4;
            groupBox8.TabStop = false;
            groupBox8.Text = "Configurações Saída";
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 19);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(groupBox11);
            splitContainer3.Panel1.Controls.Add(groupBox7);
            splitContainer3.Panel1.Controls.Add(groupBox6);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(groupBox10);
            splitContainer3.Size = new Size(971, 177);
            splitContainer3.SplitterDistance = 298;
            splitContainer3.TabIndex = 3;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(numericUpDown1);
            groupBox7.Dock = DockStyle.Top;
            groupBox7.Location = new Point(0, 57);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(298, 57);
            groupBox7.TabIndex = 4;
            groupBox7.TabStop = false;
            groupBox7.Text = "Quantidade Sugestões";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Left;
            numericUpDown1.Location = new Point(3, 19);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(55, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(cboFormatoSaida);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(298, 57);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "Formato Saída";
            // 
            // cboFormatoSaida
            // 
            cboFormatoSaida.Dock = DockStyle.Fill;
            cboFormatoSaida.FormattingEnabled = true;
            cboFormatoSaida.Items.AddRange(new object[] { "MARKDOWN", "TEXTO", "LISTA SEPARADA POR VIRGULA" });
            cboFormatoSaida.Location = new Point(3, 19);
            cboFormatoSaida.Name = "cboFormatoSaida";
            cboFormatoSaida.Size = new Size(292, 23);
            cboFormatoSaida.TabIndex = 1;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(adicionarListaControl3);
            groupBox10.Controls.Add(adicionarListaControl2);
            groupBox10.Dock = DockStyle.Fill;
            groupBox10.Location = new Point(0, 0);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(669, 177);
            groupBox10.TabIndex = 2;
            groupBox10.TabStop = false;
            groupBox10.Text = "Instrução comparativa (opcional)";
            // 
            // adicionarListaControl3
            // 
            adicionarListaControl3.Descricao = "EXEMPLOS DE SAÍDA";
            adicionarListaControl3.Dock = DockStyle.Right;
            adicionarListaControl3.Location = new Point(340, 19);
            adicionarListaControl3.Name = "adicionarListaControl3";
            adicionarListaControl3.NomeLista = "label1";
            adicionarListaControl3.SeparaPorVirgula = true;
            adicionarListaControl3.Size = new Size(326, 155);
            adicionarListaControl3.TabIndex = 1;
            // 
            // adicionarListaControl2
            // 
            adicionarListaControl2.Descricao = "EXEMPLOS DE ENTRADA";
            adicionarListaControl2.Dock = DockStyle.Left;
            adicionarListaControl2.Location = new Point(3, 19);
            adicionarListaControl2.Name = "adicionarListaControl2";
            adicionarListaControl2.NomeLista = "label1";
            adicionarListaControl2.SeparaPorVirgula = true;
            adicionarListaControl2.Size = new Size(326, 155);
            adicionarListaControl2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(btnCancelar);
            splitContainer4.Panel2.Controls.Add(btnSalvar);
            splitContainer4.Size = new Size(977, 419);
            splitContainer4.SplitterDistance = 383;
            splitContainer4.TabIndex = 28;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(673, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 32);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.DarkSeaGreen;
            btnSalvar.Dock = DockStyle.Right;
            btnSalvar.ForeColor = SystemColors.ControlLightLight;
            btnSalvar.Location = new Point(825, 0);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(152, 32);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar Configuração";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(txtSeparador);
            groupBox11.Dock = DockStyle.Top;
            groupBox11.Location = new Point(0, 114);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(298, 57);
            groupBox11.TabIndex = 5;
            groupBox11.TabStop = false;
            groupBox11.Text = "Seperador";
            // 
            // tbSexual
            // 
            tbSexual.Dock = DockStyle.Top;
            tbSexual.LargeChange = 32;
            tbSexual.Location = new Point(3, 154);
            tbSexual.Maximum = 5;
            tbSexual.Name = "tbSexual";
            tbSexual.Size = new Size(186, 45);
            tbSexual.TabIndex = 9;
            tbSexual.TickStyle = TickStyle.None;
            tbSexual.Scroll += tbSexual_Scroll;
            // 
            // txtSeparador
            // 
            txtSeparador.Location = new Point(9, 22);
            txtSeparador.Name = "txtSeparador";
            txtSeparador.Size = new Size(100, 23);
            txtSeparador.TabIndex = 0;
            // 
            // FrmConfigSugestao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(977, 419);
            Controls.Add(splitContainer4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmConfigSugestao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConfigSugestao";
            Load += FrmConfigSugestao_Load;
            pnlModelSettings.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbPerigoso).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDiscurso).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbAssedio).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbTokens).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbTemperatura).EndInit();
            groupBox3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbSexual).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlModelSettings;
        private GroupBox groupBox4;
        private TrackBar tbPerigoso;
        private Label label8;
        private Label label7;
        private TrackBar tbDiscurso;
        private Label label6;
        private TrackBar tbAssedio;
        private Label label5;
        private GroupBox groupBox2;
        private TrackBar tbTokens;
        private TextBox txtTokens;
        private GroupBox groupBox1;
        private TrackBar tbTemperatura;
        private TextBox txtTemperatura;
        private GroupBox groupBox3;
        private ComboBox cboModelName;
        private SplitContainer splitContainer1;
        private GroupBox groupBox5;
        private AdicionarListaControl adicionarListaControl1;
        private TextBox txtDescricacaoModelo;
        private Label label3;
        private TextBox txtIdentificacaoModelo;
        private Label label2;
        private TextBox txtNomeModelo;
        private Label label1;
        private SplitContainer splitContainer2;
        private ComboBox cboFormatoSaida;
        private NumericUpDown numericUpDown1;
        private SplitContainer splitContainer3;
        private GroupBox groupBox7;
        private GroupBox groupBox6;
        private GroupBox groupBox8;
        private GroupBox groupBox9;
        private AdicionarListaControl adicionarListaControl2;
        private AdicionarListaControl adicionarListaControl3;
        private GroupBox groupBox10;
        private SplitContainer splitContainer4;
        private Button btnSalvar;
        private Button btnCancelar;
        private GroupBox groupBox11;
        private TrackBar tbSexual;
        private TextBox txtSeparador;
    }
}