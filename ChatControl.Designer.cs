namespace AIBAM
{
    partial class ChatControl
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
            rTxtChat = new RichTextBox();
            SuspendLayout();
            // 
            // rTxtChat
            // 
            rTxtChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTxtChat.Location = new Point(0, 0);
            rTxtChat.Name = "rTxtChat";
            rTxtChat.ReadOnly = true;
            rTxtChat.RightToLeft = RightToLeft.No;
            rTxtChat.Size = new Size(831, 415);
            rTxtChat.TabIndex = 0;
            rTxtChat.TabStop = false;
            rTxtChat.Text = "";
            // 
            // ChatControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rTxtChat);
            Name = "ChatControl";
            Size = new Size(831, 415);
            ResumeLayout(false);
        }

        #endregion

        public RichTextBox rTxtChat;
    }
}
