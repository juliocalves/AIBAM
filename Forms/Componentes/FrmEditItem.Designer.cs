namespace AIBAM.Componentes
{
    partial class FrmEditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditItem));
            textBoxEdit = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // textBoxEdit
            // 
            textBoxEdit.CharacterCasing = CharacterCasing.Upper;
            textBoxEdit.Location = new Point(12, 16);
            textBoxEdit.Name = "textBoxEdit";
            textBoxEdit.Size = new Size(456, 23);
            textBoxEdit.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 24);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.ForeColor = SystemColors.ControlLight;
            btnCancelar.Location = new Point(312, 56);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = SystemColors.GradientActiveCaption;
            btnSalvar.Location = new Point(393, 56);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Aplicar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FrmEditItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 91);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(textBoxEdit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditItem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIBAM | Editar item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEdit;
        private Label label1;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}