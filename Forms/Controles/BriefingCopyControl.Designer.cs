namespace AIBAM.Forms.Controles
{
    partial class BriefingCopyControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BriefingCopyControl));
            txtObjetivoGeral = new TextBox();
            lstObjetivosEspecificos = new AdicionarListaControl();
            lblArquivo = new Label();
            txtIdeiaPromovida = new TextBox();
            label12 = new Label();
            gBMetas = new GroupBox();
            chkInteracao = new CheckBox();
            chkSeguidores = new CheckBox();
            chkRegistro = new CheckBox();
            chkDesempenho = new CheckBox();
            ckAdicao = new CheckBox();
            chkCompartilhamento = new CheckBox();
            chkVizualizacao = new CheckBox();
            chkPermanencia = new CheckBox();
            chkEngajamento = new CheckBox();
            chkVenda = new CheckBox();
            chkCadastro = new CheckBox();
            chkClick = new CheckBox();
            cboDestinoCopy = new ComboBox();
            label11 = new Label();
            cboSubSegmentos = new ComboBox();
            label10 = new Label();
            cboSegmento = new ComboBox();
            label8 = new Label();
            gBLancamento = new GroupBox();
            rdbNao = new RadioButton();
            rdbSim = new RadioButton();
            txtObservacoes = new TextBox();
            label7 = new Label();
            txtLinkCatalogo = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtLinkSite = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtMarca = new TextBox();
            label2 = new Label();
            gBTipoVenda = new GroupBox();
            rdbServico = new RadioButton();
            rdbProduto = new RadioButton();
            txtInforProdServ = new TextBox();
            label1 = new Label();
            toolStrip5 = new ToolStrip();
            toolStripButtonAdicionarArquivo = new ToolStripButton();
            toolStripButtonRemoverArquivo = new ToolStripButton();
            txtMensagemCopy = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            toolStrip4 = new ToolStrip();
            novaToolStripButton1 = new ToolStripButton();
            abrirToolStripButton1 = new ToolStripButton();
            salvarToolStripButton = new ToolStripButton();
            gBMetas.SuspendLayout();
            gBLancamento.SuspendLayout();
            gBTipoVenda.SuspendLayout();
            toolStrip5.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // txtObjetivoGeral
            // 
            txtObjetivoGeral.AcceptsReturn = true;
            txtObjetivoGeral.AcceptsTab = true;
            txtObjetivoGeral.AllowDrop = true;
            txtObjetivoGeral.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObjetivoGeral.Location = new Point(0, 262);
            txtObjetivoGeral.Multiline = true;
            txtObjetivoGeral.Name = "txtObjetivoGeral";
            txtObjetivoGeral.ScrollBars = ScrollBars.Vertical;
            txtObjetivoGeral.Size = new Size(691, 54);
            txtObjetivoGeral.TabIndex = 154;
            // 
            // lstObjetivosEspecificos
            // 
            lstObjetivosEspecificos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstObjetivosEspecificos.Descricao = "OBJETIVOS ESPECIFICOS";
            lstObjetivosEspecificos.Location = new Point(697, 177);
            lstObjetivosEspecificos.Name = "lstObjetivosEspecificos";
            lstObjetivosEspecificos.NomeLista = "OBJETIVOS_ESPECIFICOS_COPY";
            lstObjetivosEspecificos.Size = new Size(326, 148);
            lstObjetivosEspecificos.TabIndex = 153;
            // 
            // lblArquivo
            // 
            lblArquivo.AutoSize = true;
            lblArquivo.ForeColor = Color.Maroon;
            lblArquivo.Location = new Point(772, 115);
            lblArquivo.Name = "lblArquivo";
            lblArquivo.Size = new Size(0, 15);
            lblArquivo.TabIndex = 152;
            // 
            // txtIdeiaPromovida
            // 
            txtIdeiaPromovida.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdeiaPromovida.Location = new Point(492, 43);
            txtIdeiaPromovida.Name = "txtIdeiaPromovida";
            txtIdeiaPromovida.PlaceholderText = "Descreva a ideia geral do texto";
            txtIdeiaPromovida.Size = new Size(530, 23);
            txtIdeiaPromovida.TabIndex = 131;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(0, 363);
            label12.Name = "label12";
            label12.Size = new Size(297, 15);
            label12.TabIndex = 151;
            label12.Text = "MENSAGEM A SER TRANSMITIDA COM A CAMPANHA";
            // 
            // gBMetas
            // 
            gBMetas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gBMetas.Controls.Add(chkInteracao);
            gBMetas.Controls.Add(chkSeguidores);
            gBMetas.Controls.Add(chkRegistro);
            gBMetas.Controls.Add(chkDesempenho);
            gBMetas.Controls.Add(ckAdicao);
            gBMetas.Controls.Add(chkCompartilhamento);
            gBMetas.Controls.Add(chkVizualizacao);
            gBMetas.Controls.Add(chkPermanencia);
            gBMetas.Controls.Add(chkEngajamento);
            gBMetas.Controls.Add(chkVenda);
            gBMetas.Controls.Add(chkCadastro);
            gBMetas.Controls.Add(chkClick);
            gBMetas.Location = new Point(515, 322);
            gBMetas.Name = "gBMetas";
            gBMetas.Size = new Size(511, 82);
            gBMetas.TabIndex = 139;
            gBMetas.TabStop = false;
            gBMetas.Text = "METAS";
            // 
            // chkInteracao
            // 
            chkInteracao.AutoSize = true;
            chkInteracao.Location = new Point(282, 13);
            chkInteracao.Name = "chkInteracao";
            chkInteracao.Size = new Size(75, 19);
            chkInteracao.TabIndex = 7;
            chkInteracao.Text = "Interação";
            chkInteracao.UseVisualStyleBackColor = true;
            // 
            // chkSeguidores
            // 
            chkSeguidores.AutoSize = true;
            chkSeguidores.Location = new Point(419, 13);
            chkSeguidores.Name = "chkSeguidores";
            chkSeguidores.Size = new Size(84, 19);
            chkSeguidores.TabIndex = 10;
            chkSeguidores.Text = "Seguidores";
            chkSeguidores.UseVisualStyleBackColor = true;
            // 
            // chkRegistro
            // 
            chkRegistro.AutoSize = true;
            chkRegistro.Location = new Point(282, 51);
            chkRegistro.Name = "chkRegistro";
            chkRegistro.Size = new Size(69, 19);
            chkRegistro.TabIndex = 9;
            chkRegistro.Text = "Registro";
            chkRegistro.UseVisualStyleBackColor = true;
            // 
            // chkDesempenho
            // 
            chkDesempenho.AutoSize = true;
            chkDesempenho.Location = new Point(146, 31);
            chkDesempenho.Name = "chkDesempenho";
            chkDesempenho.Size = new Size(96, 19);
            chkDesempenho.TabIndex = 5;
            chkDesempenho.Text = "Desempenho";
            chkDesempenho.UseVisualStyleBackColor = true;
            // 
            // ckAdicao
            // 
            ckAdicao.AutoSize = true;
            ckAdicao.Location = new Point(10, 14);
            ckAdicao.Name = "ckAdicao";
            ckAdicao.Size = new Size(112, 19);
            ckAdicao.TabIndex = 1;
            ckAdicao.Text = "Adição Carrinho";
            ckAdicao.UseVisualStyleBackColor = true;
            // 
            // chkCompartilhamento
            // 
            chkCompartilhamento.AutoSize = true;
            chkCompartilhamento.Location = new Point(146, 13);
            chkCompartilhamento.Name = "chkCompartilhamento";
            chkCompartilhamento.Size = new Size(132, 19);
            chkCompartilhamento.TabIndex = 4;
            chkCompartilhamento.Text = "Compartilhamentos";
            chkCompartilhamento.UseVisualStyleBackColor = true;
            // 
            // chkVizualizacao
            // 
            chkVizualizacao.AutoSize = true;
            chkVizualizacao.Location = new Point(419, 50);
            chkVizualizacao.Name = "chkVizualizacao";
            chkVizualizacao.Size = new Size(95, 19);
            chkVizualizacao.TabIndex = 12;
            chkVizualizacao.Text = "Vizualizações";
            chkVizualizacao.UseVisualStyleBackColor = true;
            // 
            // chkPermanencia
            // 
            chkPermanencia.AutoSize = true;
            chkPermanencia.Location = new Point(282, 32);
            chkPermanencia.Name = "chkPermanencia";
            chkPermanencia.Size = new Size(134, 19);
            chkPermanencia.TabIndex = 8;
            chkPermanencia.Text = "Permanência Página";
            chkPermanencia.UseVisualStyleBackColor = true;
            // 
            // chkEngajamento
            // 
            chkEngajamento.AutoSize = true;
            chkEngajamento.Location = new Point(146, 48);
            chkEngajamento.Name = "chkEngajamento";
            chkEngajamento.Size = new Size(96, 19);
            chkEngajamento.TabIndex = 6;
            chkEngajamento.Text = "Engajamento";
            chkEngajamento.UseVisualStyleBackColor = true;
            // 
            // chkVenda
            // 
            chkVenda.AutoSize = true;
            chkVenda.Location = new Point(419, 32);
            chkVenda.Name = "chkVenda";
            chkVenda.Size = new Size(58, 19);
            chkVenda.TabIndex = 11;
            chkVenda.Text = "Venda";
            chkVenda.UseVisualStyleBackColor = true;
            // 
            // chkCadastro
            // 
            chkCadastro.AutoSize = true;
            chkCadastro.Location = new Point(10, 32);
            chkCadastro.Name = "chkCadastro";
            chkCadastro.Size = new Size(134, 19);
            chkCadastro.TabIndex = 2;
            chkCadastro.Text = "Cadastro Formulario";
            chkCadastro.UseVisualStyleBackColor = true;
            // 
            // chkClick
            // 
            chkClick.AutoSize = true;
            chkClick.Location = new Point(10, 51);
            chkClick.Name = "chkClick";
            chkClick.Size = new Size(82, 19);
            chkClick.TabIndex = 3;
            chkClick.Text = "Clicks Link";
            chkClick.UseVisualStyleBackColor = true;
            // 
            // cboDestinoCopy
            // 
            cboDestinoCopy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboDestinoCopy.BackColor = Color.LavenderBlush;
            cboDestinoCopy.FormattingEnabled = true;
            cboDestinoCopy.ItemHeight = 15;
            cboDestinoCopy.Items.AddRange(new object[] { "E-mail Marketing", "Landing Page", "Página de Vendas", "Anúncios em Redes Sociais", "Blog Post (SEO)", "Roteiro para Vídeos", "Descrição de Produtos E-commerce", "Teste A/B", "Webinar/Palestras Online", "Conteúdo de Rede Social para Aumento de Audiência", "Impresso", "Radio" });
            cboDestinoCopy.Location = new Point(0, 337);
            cboDestinoCopy.Name = "cboDestinoCopy";
            cboDestinoCopy.Size = new Size(509, 23);
            cboDestinoCopy.TabIndex = 150;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(0, 320);
            label11.Name = "label11";
            label11.Size = new Size(89, 15);
            label11.TabIndex = 149;
            label11.Text = "DESTINO COPY";
            // 
            // cboSubSegmentos
            // 
            cboSubSegmentos.BackColor = Color.LavenderBlush;
            cboSubSegmentos.FormattingEnabled = true;
            cboSubSegmentos.Items.AddRange(new object[] { "Tecnologia da Informação (TI)", "Educação", "Saúde e Bem-Estar", "Alimentação e Bebidas", "Varejo", "Turismo e Hotelaria", "Construção Civil e Imobiliário", "Entretenimento e Cultura", "Finanças e Seguros", "Logística e Transporte", "Indústria", "Moda e Beleza", "Agronegócio", "Energia e Sustentabilidade", "Comunicação e Marketing" });
            cboSubSegmentos.Location = new Point(492, 88);
            cboSubSegmentos.Name = "cboSubSegmentos";
            cboSubSegmentos.Size = new Size(237, 23);
            cboSubSegmentos.TabIndex = 134;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(488, 74);
            label10.Name = "label10";
            label10.Size = new Size(92, 15);
            label10.TabIndex = 148;
            label10.Text = "SUB SEGMENTO";
            // 
            // cboSegmento
            // 
            cboSegmento.BackColor = Color.LavenderBlush;
            cboSegmento.FormattingEnabled = true;
            cboSegmento.Items.AddRange(new object[] { "Tecnologia da Informação (TI)", "Educação", "Saúde e Bem-Estar", "Alimentação e Bebidas", "Varejo", "Turismo e Hotelaria", "Construção Civil e Imobiliário", "Entretenimento e Cultura", "Finanças e Seguros", "Logística e Transporte", "Indústria", "Moda e Beleza", "Agronegócio", "Energia e Sustentabilidade", "Comunicação e Marketing" });
            cboSegmento.Location = new Point(309, 88);
            cboSegmento.Name = "cboSegmento";
            cboSegmento.Size = new Size(177, 23);
            cboSegmento.TabIndex = 133;
            cboSegmento.SelectedIndexChanged += cboSegmento_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 246);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 147;
            label8.Text = "OBJETIVO GERAL";
            // 
            // gBLancamento
            // 
            gBLancamento.Controls.Add(rdbNao);
            gBLancamento.Controls.Add(rdbSim);
            gBLancamento.Location = new Point(734, 70);
            gBLancamento.Name = "gBLancamento";
            gBLancamento.Size = new Size(138, 41);
            gBLancamento.TabIndex = 135;
            gBLancamento.TabStop = false;
            gBLancamento.Text = "É UM LANÇAMENTO?";
            // 
            // rdbNao
            // 
            rdbNao.AutoSize = true;
            rdbNao.Checked = true;
            rdbNao.Location = new Point(81, 16);
            rdbNao.Name = "rdbNao";
            rdbNao.Size = new Size(51, 19);
            rdbNao.TabIndex = 1;
            rdbNao.TabStop = true;
            rdbNao.Text = "NÃO";
            rdbNao.UseVisualStyleBackColor = true;
            // 
            // rdbSim
            // 
            rdbSim.AutoSize = true;
            rdbSim.Location = new Point(12, 16);
            rdbSim.Name = "rdbSim";
            rdbSim.Size = new Size(45, 19);
            rdbSim.TabIndex = 0;
            rdbSim.Text = "SIM";
            rdbSim.UseVisualStyleBackColor = true;
            // 
            // txtObservacoes
            // 
            txtObservacoes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObservacoes.Location = new Point(309, 133);
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.Size = new Size(714, 23);
            txtObservacoes.TabIndex = 137;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(305, 117);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 146;
            label7.Text = "OBSERVAÇÕES";
            // 
            // txtLinkCatalogo
            // 
            txtLinkCatalogo.Location = new Point(0, 133);
            txtLinkCatalogo.Name = "txtLinkCatalogo";
            txtLinkCatalogo.PlaceholderText = "Cole o link do catalogo";
            txtLinkCatalogo.Size = new Size(303, 23);
            txtLinkCatalogo.TabIndex = 136;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 117);
            label6.Name = "label6";
            label6.Size = new Size(295, 15);
            label6.TabIndex = 145;
            label6.Text = "VOCÊ POSSUI UM CATALOGO DE PRODUTO/SERVIÇO?";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(305, 74);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 144;
            label5.Text = "SEGMENTO";
            // 
            // txtLinkSite
            // 
            txtLinkSite.Location = new Point(0, 88);
            txtLinkSite.Name = "txtLinkSite";
            txtLinkSite.PlaceholderText = "Cole o link de seu site";
            txtLinkSite.Size = new Size(303, 23);
            txtLinkSite.TabIndex = 132;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 72);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 143;
            label4.Text = "VOCÊ TEM UM SITE?";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(492, 28);
            label3.Name = "label3";
            label3.Size = new Size(163, 15);
            label3.TabIndex = 142;
            label3.Text = "IDEIA QUE SERÁ PROMOVIDA";
            // 
            // txtMarca
            // 
            txtMarca.CharacterCasing = CharacterCasing.Upper;
            txtMarca.Location = new Point(160, 43);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "Diga o nome de sua marca";
            txtMarca.Size = new Size(326, 23);
            txtMarca.TabIndex = 130;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 27);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 141;
            label2.Text = "QUAL É SUA MARCA?";
            // 
            // gBTipoVenda
            // 
            gBTipoVenda.Controls.Add(rdbServico);
            gBTipoVenda.Controls.Add(rdbProduto);
            gBTipoVenda.Location = new Point(0, 25);
            gBTipoVenda.Name = "gBTipoVenda";
            gBTipoVenda.Size = new Size(154, 41);
            gBTipoVenda.TabIndex = 129;
            gBTipoVenda.TabStop = false;
            gBTipoVenda.Text = "O QUE VOCÊ VENDE?";
            // 
            // rdbServico
            // 
            rdbServico.AutoSize = true;
            rdbServico.Location = new Point(86, 16);
            rdbServico.Name = "rdbServico";
            rdbServico.Size = new Size(63, 19);
            rdbServico.TabIndex = 1;
            rdbServico.Text = "Serviço";
            rdbServico.UseVisualStyleBackColor = true;
            // 
            // rdbProduto
            // 
            rdbProduto.AutoSize = true;
            rdbProduto.Checked = true;
            rdbProduto.Location = new Point(12, 16);
            rdbProduto.Name = "rdbProduto";
            rdbProduto.Size = new Size(68, 19);
            rdbProduto.TabIndex = 0;
            rdbProduto.TabStop = true;
            rdbProduto.Text = "Produto";
            rdbProduto.UseVisualStyleBackColor = true;
            // 
            // txtInforProdServ
            // 
            txtInforProdServ.AcceptsReturn = true;
            txtInforProdServ.AcceptsTab = true;
            txtInforProdServ.AllowDrop = true;
            txtInforProdServ.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInforProdServ.Location = new Point(0, 177);
            txtInforProdServ.Multiline = true;
            txtInforProdServ.Name = "txtInforProdServ";
            txtInforProdServ.ScrollBars = ScrollBars.Vertical;
            txtInforProdServ.Size = new Size(690, 66);
            txtInforProdServ.TabIndex = 138;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 159);
            label1.Name = "label1";
            label1.Size = new Size(235, 15);
            label1.TabIndex = 140;
            label1.Text = "INFORMAÇÕES SOBRE PRODUTO/SERVIÇO";
            // 
            // toolStrip5
            // 
            toolStrip5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip5.Dock = DockStyle.None;
            toolStrip5.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripButtonAdicionarArquivo, toolStripButtonRemoverArquivo });
            toolStrip5.Location = new Point(1007, 74);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.RenderMode = ToolStripRenderMode.Professional;
            toolStrip5.Size = new Size(26, 25);
            toolStrip5.TabIndex = 155;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButtonAdicionarArquivo
            // 
            toolStripButtonAdicionarArquivo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonAdicionarArquivo.Image = Properties.Resources.anexar_arquivo;
            toolStripButtonAdicionarArquivo.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdicionarArquivo.Name = "toolStripButtonAdicionarArquivo";
            toolStripButtonAdicionarArquivo.Size = new Size(23, 22);
            toolStripButtonAdicionarArquivo.Text = "&Importar Arquivo";
            toolStripButtonAdicionarArquivo.Click += toolStripButtonAdicionarArquivo_Click;
            // 
            // toolStripButtonRemoverArquivo
            // 
            toolStripButtonRemoverArquivo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRemoverArquivo.Image = Properties.Resources.remover_arquivo;
            toolStripButtonRemoverArquivo.ImageTransparentColor = Color.Magenta;
            toolStripButtonRemoverArquivo.Name = "toolStripButtonRemoverArquivo";
            toolStripButtonRemoverArquivo.Size = new Size(23, 22);
            toolStripButtonRemoverArquivo.Text = "&Remover arquivo";
            toolStripButtonRemoverArquivo.Visible = false;
            toolStripButtonRemoverArquivo.Click += toolStripButtonRemoverArquivo_Click;
            // 
            // txtMensagemCopy
            // 
            txtMensagemCopy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMensagemCopy.Location = new Point(0, 381);
            txtMensagemCopy.Name = "txtMensagemCopy";
            txtMensagemCopy.Size = new Size(511, 23);
            txtMensagemCopy.TabIndex = 156;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip4
            // 
            toolStrip4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { novaToolStripButton1, abrirToolStripButton1, salvarToolStripButton });
            toolStrip4.Location = new Point(934, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.RenderMode = ToolStripRenderMode.Professional;
            toolStrip4.Size = new Size(103, 25);
            toolStrip4.TabIndex = 157;
            toolStrip4.Text = "toolStrip4";
            // 
            // novaToolStripButton1
            // 
            novaToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            novaToolStripButton1.Image = (Image)resources.GetObject("novaToolStripButton1.Image");
            novaToolStripButton1.ImageTransparentColor = Color.Magenta;
            novaToolStripButton1.Name = "novaToolStripButton1";
            novaToolStripButton1.Size = new Size(23, 22);
            novaToolStripButton1.Text = "&Novo Briefing";
            novaToolStripButton1.ToolTipText = "Novo Briefing";
            novaToolStripButton1.Click += novaToolStripButton1_Click;
            // 
            // abrirToolStripButton1
            // 
            abrirToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            abrirToolStripButton1.Image = (Image)resources.GetObject("abrirToolStripButton1.Image");
            abrirToolStripButton1.ImageTransparentColor = Color.Magenta;
            abrirToolStripButton1.Name = "abrirToolStripButton1";
            abrirToolStripButton1.Size = new Size(23, 22);
            abrirToolStripButton1.Text = "&Abrir Briefing";
            abrirToolStripButton1.ToolTipText = "Abrir Briefing";
            abrirToolStripButton1.Click += abrirToolStripButton1_Click;
            // 
            // salvarToolStripButton
            // 
            salvarToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            salvarToolStripButton.Image = (Image)resources.GetObject("salvarToolStripButton.Image");
            salvarToolStripButton.ImageTransparentColor = Color.Magenta;
            salvarToolStripButton.Name = "salvarToolStripButton";
            salvarToolStripButton.Size = new Size(23, 22);
            salvarToolStripButton.Text = "&Salvar Briefing";
            salvarToolStripButton.Click += salvarToolStripButton_Click;
            // 
            // BriefingCopyControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip4);
            Controls.Add(txtMensagemCopy);
            Controls.Add(toolStrip5);
            Controls.Add(txtObjetivoGeral);
            Controls.Add(lstObjetivosEspecificos);
            Controls.Add(lblArquivo);
            Controls.Add(txtIdeiaPromovida);
            Controls.Add(label12);
            Controls.Add(gBMetas);
            Controls.Add(cboDestinoCopy);
            Controls.Add(label11);
            Controls.Add(cboSubSegmentos);
            Controls.Add(label10);
            Controls.Add(cboSegmento);
            Controls.Add(label8);
            Controls.Add(gBLancamento);
            Controls.Add(txtObservacoes);
            Controls.Add(label7);
            Controls.Add(txtLinkCatalogo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtLinkSite);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMarca);
            Controls.Add(label2);
            Controls.Add(gBTipoVenda);
            Controls.Add(txtInforProdServ);
            Controls.Add(label1);
            Name = "BriefingCopyControl";
            Size = new Size(1033, 410);
            gBMetas.ResumeLayout(false);
            gBMetas.PerformLayout();
            gBLancamento.ResumeLayout(false);
            gBLancamento.PerformLayout();
            gBTipoVenda.ResumeLayout(false);
            gBTipoVenda.PerformLayout();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtObjetivoGeral;
        private AdicionarListaControl lstObjetivosEspecificos;
        private Label lblArquivo;
        private TextBox txtIdeiaPromovida;
        private Label label12;
        private GroupBox gBMetas;
        private CheckBox chkInteracao;
        private CheckBox chkSeguidores;
        private CheckBox chkRegistro;
        private CheckBox chkDesempenho;
        private CheckBox ckAdicao;
        private CheckBox chkCompartilhamento;
        private CheckBox chkVizualizacao;
        private CheckBox chkPermanencia;
        private CheckBox chkEngajamento;
        private CheckBox chkVenda;
        private CheckBox chkCadastro;
        private CheckBox chkClick;
        private ComboBox cboDestinoCopy;
        private Label label11;
        private ComboBox cboSubSegmentos;
        private Label label10;
        private ComboBox cboSegmento;
        private Label label8;
        private GroupBox gBLancamento;
        private RadioButton rdbNao;
        private RadioButton rdbSim;
        private TextBox txtObservacoes;
        private Label label7;
        private TextBox txtLinkCatalogo;
        private Label label6;
        private Label label5;
        private TextBox txtLinkSite;
        private Label label4;
        private Label label3;
        private TextBox txtMarca;
        private Label label2;
        private GroupBox gBTipoVenda;
        private RadioButton rdbServico;
        private RadioButton rdbProduto;
        private TextBox txtInforProdServ;
        private Label label1;
        private ToolStrip toolStrip5;
        private ToolStripButton toolStripButtonAdicionarArquivo;
        private ToolStripButton toolStripButtonRemoverArquivo;
        private TextBox txtMensagemCopy;
        private OpenFileDialog openFileDialog1;
        private ToolStrip toolStrip4;
        private ToolStripButton novaToolStripButton1;
        private ToolStripButton abrirToolStripButton1;
        private ToolStripButton salvarToolStripButton;
    }
}
