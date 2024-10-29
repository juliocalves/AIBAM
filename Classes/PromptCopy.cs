namespace AIBAM.Classes
{
    public class PromptCopy
    {
        public PromptCopy()
        {
            this.briefing = new();
            this.publicoAlvo = new();
            this.controlesCopy = new();
        }

        public string DescricaoCopy { get; set; }
        public BriefingCopy briefing { get; set; }
        public PublicoAlvo publicoAlvo { get; set; }
        public ControlesCopy controlesCopy { get; set; }
    }
}
