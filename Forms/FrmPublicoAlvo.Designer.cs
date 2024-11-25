namespace AIBAM.Forms
{
    partial class FrmPublicoAlvo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPublicoAlvo));
            btnAnterior = new Button();
            btnProximo = new Button();
            btnExcluir = new Button();
            label1 = new Label();
            txtProcurarPub = new TextBox();
            publicoAlvoControl1 = new AIBAM.Controles.PublicoAlvoControl();
            btnSalvarAlteracoes = new Button();
            toolStrip3 = new ToolStrip();
            imprimirToolStripButton = new ToolStripButton();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnterior.Location = new Point(858, 709);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 2;
            btnAnterior.Text = "ANTERIOR";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnProximo
            // 
            btnProximo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProximo.Location = new Point(939, 709);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 1;
            btnProximo.Text = "PRÓXIMO";
            btnProximo.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.IndianRed;
            btnExcluir.ForeColor = SystemColors.ControlLightLight;
            btnExcluir.Location = new Point(777, 709);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 3;
            btnExcluir.TabStop = false;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 4;
            label1.Text = "PROCURAR PÚBLICO ALVO";
            // 
            // txtProcurarPub
            // 
            txtProcurarPub.BackColor = Color.LavenderBlush;
            txtProcurarPub.Location = new Point(3, 27);
            txtProcurarPub.Name = "txtProcurarPub";
            txtProcurarPub.Size = new Size(483, 23);
            txtProcurarPub.TabIndex = 5;
            // 
            // publicoAlvoControl1
            // 
            publicoAlvoControl1.Location = new Point(2, 57);
            publicoAlvoControl1.Name = "publicoAlvoControl1";
            publicoAlvoControl1.Size = new Size(1019, 634);
            publicoAlvoControl1.TabIndex = 6;
            // 
            // btnSalvarAlteracoes
            // 
            btnSalvarAlteracoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarAlteracoes.BackColor = Color.DarkOliveGreen;
            btnSalvarAlteracoes.ForeColor = SystemColors.ControlLight;
            btnSalvarAlteracoes.Location = new Point(858, 709);
            btnSalvarAlteracoes.Name = "btnSalvarAlteracoes";
            btnSalvarAlteracoes.Size = new Size(156, 23);
            btnSalvarAlteracoes.TabIndex = 12;
            btnSalvarAlteracoes.Text = "SALVAR ALTERAÇÕES";
            btnSalvarAlteracoes.UseVisualStyleBackColor = false;
            btnSalvarAlteracoes.Visible = false;
            // 
            // toolStrip3
            // 
            toolStrip3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toolStrip3.Dock = DockStyle.None;
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.Items.AddRange(new ToolStripItem[] { imprimirToolStripButton });
            toolStrip3.Location = new Point(995, 25);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.RenderMode = ToolStripRenderMode.Professional;
            toolStrip3.Size = new Size(26, 25);
            toolStrip3.TabIndex = 15;
            toolStrip3.Text = "toolStrip3";
            toolStrip3.Visible = false;
            // 
            // imprimirToolStripButton
            // 
            imprimirToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            imprimirToolStripButton.Image = (Image)resources.GetObject("imprimirToolStripButton.Image");
            imprimirToolStripButton.ImageTransparentColor = Color.Magenta;
            imprimirToolStripButton.Name = "imprimirToolStripButton";
            imprimirToolStripButton.Size = new Size(23, 22);
            imprimirToolStripButton.Text = "&Imprimir Publico Alvo";
            // 
            // FrmPublicoAlvo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 744);
            Controls.Add(toolStrip3);
            Controls.Add(btnSalvarAlteracoes);
            Controls.Add(publicoAlvoControl1);
            Controls.Add(txtProcurarPub);
            Controls.Add(label1);
            Controls.Add(btnExcluir);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmPublicoAlvo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Publico Alvo";
            Load += FrmPublicoAlvo_Load;
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnterior;
        private Button btnProximo;
        private Button btnExcluir;
        private Label label1;
        private TextBox txtProcurarPub;
        private AIBAM.Controles.PublicoAlvoControl publicoAlvoControl1;
        private Button btnSalvarAlteracoes;
        private ToolStrip toolStrip3;
        private ToolStripButton imprimirToolStripButton;
    }
}