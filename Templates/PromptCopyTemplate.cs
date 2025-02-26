using AIBAM.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Templates
{
    public class PromptCopyTemplate
    {
        public PromptCopyTemplate(PromptCopy promptCopy)
        {
            this.promptCopy = promptCopy;
        }

        PromptCopy promptCopy;

        #region GERA TEXTO DE COPY PARAMETRIZADO

        public string MontaPrompt()
        {
            string copy = $@"
Você é um copywriter experiente com mais de 25 anos de carreira e possui um MBA especializado, além de um histórico de campanhas premiadas. Sua expertise é criar textos publicitários persuasivos e envolventes para promover produtos, serviços ou ideias em mídias variadas, como impressa, digital, TV e rádio.

Seu objetivo principal é criar mensagens que:
- Despertem interesse
- Gerem impacto emocional
- Induzam o leitor a tomar uma ação específica, como realizar uma compra, inscrever-se, solicitar mais informações, ou compartilhar conteúdo

Para isso, você emprega técnicas de redação persuasiva e estratégias de marketing alinhadas ao público-alvo e aos objetivos do cliente.


### Diretrizes a serem seguidas:

1. **Narrativa Empática**  
   Use as informações fornecidas para:
   - Destacar dores e necessidades do público para gerar identificação
   - Apresentar o produto/serviço como a solução ideal para esses problemas
   - Enfatizar benefícios transformacionais, mostrando o “antes e depois” para o público
   - Antecipar objeções e tratá-las de forma empática
   - Conduzir o público do problema à solução com uma narrativa emocional

2. **Nível de Consciência do Público-Alvo**  
   Adapte a abordagem da cópia conforme o nível de prontidão e conhecimento do público:
   - **Inconscientes do problema:** abordagem educacional
   - **Conscientes do problema:** foco na identificação da dor
   - **Conscientes da solução:** apresentação da solução
   - **Conscientes do produto:** destaque de diferenciais e benefícios
   - **Totalmente conscientes:** oferta irresistível
   - **Clientes já convertidos:** reforço para decisão e fidelização

### Instruções para criação de peças de texto
- Primeiro, avalie o **Briefing** detalhado do cliente.
- Segundo, analise a **Definição do público-alvo** para alinhar a abordagem.
- Terceiro, verifique os **Controles** para a criação da peça conforme solicitado.


---

{GerarTextoBriefing()}

---

{GerarTextoPublicoAlvo()}

---

{GerarTextoControles()}

---
";


            return copy;
        }

        private string GerarTextoControles()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("## Controles de criação:");

            // Entonação
            texto.AppendLine($"**Entonação:** {promptCopy.controlesCopy.Entonacao}");

            // Originalidade
            texto.AppendLine($"**Originalidade:** {promptCopy.controlesCopy.Originalidade}");

            // Sentimentos
            if (promptCopy.controlesCopy.Sentimento?.Count > 0)
            {
                texto.AppendLine("### Sentimentos:");
                foreach (var sentimento in promptCopy.controlesCopy.Sentimento)
                {
                    texto.AppendLine($"- {sentimento}");
                }
            }

            // Perspectiva
            texto.AppendLine($"**Perspectiva:** {promptCopy.controlesCopy.Perspectiva}");

            // Palavras-chave
            if (promptCopy.controlesCopy.PalavrasChave?.Count > 0)
            {
                texto.AppendLine("### Palavras-chave:");
                foreach (var palavraChave in promptCopy.controlesCopy.PalavrasChave)
                {
                    texto.AppendLine($"- {palavraChave}");
                }
            }

            return texto.ToString();
        }

        private string GerarTextoPublicoAlvo()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("## Público-Alvo:");

            // Informações Gerais
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Nome))
                texto.AppendLine($"**Nome:** {promptCopy.publicoAlvo.Nome}\n");

            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Descricao))
                texto.AppendLine($"**Descrição:** {promptCopy.publicoAlvo.Descricao}\n");

            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.PropostaValor))
                texto.AppendLine($"**Proposta de Valor:** {promptCopy.publicoAlvo.PropostaValor}\n");

            // Segmentação Geográfica
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Pais) ||
                !string.IsNullOrEmpty(promptCopy.publicoAlvo.Estado) ||
                !string.IsNullOrEmpty(promptCopy.publicoAlvo.Cidade) ||
                !string.IsNullOrEmpty(promptCopy.publicoAlvo.Regiao))
            {
                texto.AppendLine("### Segmentação Geográfica:");
                if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Pais))
                    texto.AppendLine($"- **País:** {promptCopy.publicoAlvo.Pais}");
                if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Estado))
                    texto.AppendLine($"- **Estado:** {promptCopy.publicoAlvo.Estado}");
                if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Cidade))
                    texto.AppendLine($"- **Cidade:** {promptCopy.publicoAlvo.Cidade}");
                if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Regiao))
                    texto.AppendLine($"- **Região:** {promptCopy.publicoAlvo.Regiao}");
                texto.AppendLine();
            }

            // Segmentação Demográfica
            texto.AppendLine($"**Idade:** de {promptCopy.publicoAlvo.IdadeInicial} a {promptCopy.publicoAlvo.IdadeFinal} anos.\n");
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.Genero))
                texto.AppendLine($"**Gênero:** {promptCopy.publicoAlvo.Genero}\n");
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.NivelAcademico))
                texto.AppendLine($"**Nível Acadêmico:** {promptCopy.publicoAlvo.NivelAcademico}\n");

            // Ocupações
            if (promptCopy.publicoAlvo.Ocupacoes?.Count > 0)
            {
                texto.AppendLine("### Ocupações:");
                foreach (var ocupacao in promptCopy.publicoAlvo.Ocupacoes)
                    texto.AppendLine($"- {ocupacao}");
                texto.AppendLine();
            }

            // Segmentação Comportamental
            if (promptCopy.publicoAlvo.Interesses?.Count > 0)
            {
                texto.AppendLine("### Interesses:");
                foreach (var interesse in promptCopy.publicoAlvo.Interesses)
                    texto.AppendLine($"- {interesse}");
                texto.AppendLine();
            }

            if (promptCopy.publicoAlvo.Dores?.Count > 0)
            {
                texto.AppendLine("### Dores do público:");
                foreach (var dor in promptCopy.publicoAlvo.Dores)
                    texto.AppendLine($"- {dor}");
                texto.AppendLine();
            }

            if (promptCopy.publicoAlvo.DiferenciaisCompetitivos?.Count > 0)
            {
                texto.AppendLine("### Diferenciais Competitivos:");
                foreach (var diferencial in promptCopy.publicoAlvo.DiferenciaisCompetitivos)
                    texto.AppendLine($"- {diferencial}");
                texto.AppendLine();
            }

            // Nível de Consciência
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.NivelConsciencia))
                texto.AppendLine($"**Nível de Consciência:** {promptCopy.publicoAlvo.NivelConsciencia}\n");

            // Outras Informações
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.OutrasInformacoes))
            {
                texto.AppendLine("### Outras Informações:");
                texto.AppendLine($"- {promptCopy.publicoAlvo.OutrasInformacoes}");
                texto.AppendLine();
            }

            // Segmentação de Volume
            if (promptCopy.publicoAlvo.TamanhoMercado > 0 ||
                promptCopy.publicoAlvo.ReceitaAnualMedia.HasValue ||
                promptCopy.publicoAlvo.TicketMedio.HasValue)
            {
                texto.AppendLine("### Segmentação de Volume:");
                if (promptCopy.publicoAlvo.TamanhoMercado > 0)
                    texto.AppendLine($"- **Tamanho do Mercado:** {promptCopy.publicoAlvo.TamanhoMercado}");
                if (promptCopy.publicoAlvo.ReceitaAnualMedia.HasValue)
                    texto.AppendLine($"- **Receita Anual Média:** {promptCopy.publicoAlvo.ReceitaAnualMedia.Value:C}");
                if (promptCopy.publicoAlvo.TicketMedio.HasValue)
                    texto.AppendLine($"- **Ticket Médio:** {promptCopy.publicoAlvo.TicketMedio.Value:C}");
                texto.AppendLine();
            }

            return texto.ToString();
        }



        public string GerarTextoBriefing()
        {
            StringBuilder briefingTexto = new StringBuilder();

            // Início do briefing
            briefingTexto.AppendLine("## Briefing:");

            // Tipo de Venda
            briefingTexto.AppendLine($"**Tipo de Venda:** {promptCopy.briefing.TipoVenda} \n");

            // Marca
            briefingTexto.AppendLine($"**Marca:** **{promptCopy.briefing.Marca}** \n");

            // Ideia Promovida
            briefingTexto.AppendLine($"**Ideia Promovida:** {promptCopy.briefing.IdeiaPromovida} \n");

            // Canal de vendas
            briefingTexto.AppendLine($"**Canal de Vendas:** [Site]({promptCopy.briefing.LinkSite}) \n");

            // Segmento e Subsegmento de Negócio
            briefingTexto.AppendLine($"**Segmento de Negócio:** {promptCopy.briefing.SegmentoNegocio} \n");
            briefingTexto.AppendLine($"**Subsegmento de Negócio:** {promptCopy.briefing.SubSegmentoNegocio} \n");

            // Lançamento de produto/serviço
            briefingTexto.AppendLine($"**É lançamento de produto ou serviço?:** {promptCopy.briefing.ELancamentoProdServ} \n");

            // Portfólio
            briefingTexto.AppendLine($"**Portfólio:** [Catálogo]({promptCopy.briefing.LinkCatalogoProdServ}) \n");

            // Observações
            briefingTexto.AppendLine($"**Observações:** {promptCopy.briefing.Observacoes} \n");

            // Informações sobre Produto ou Serviço
            briefingTexto.AppendLine($"**Informações sobre Produto ou Serviço:** {promptCopy.briefing.InformacoesProdServ} \n");

            // Objetivos
            briefingTexto.AppendLine($"**Objetivo Geral:** {promptCopy.briefing.ObjetivoGeral} \n");

            if (promptCopy.briefing.ObjetivoEspecifico?.Count > 0)
            {
                briefingTexto.AppendLine("### Objetivos Específicos:");
                foreach (var objtivo in promptCopy.briefing.ObjetivoEspecifico)
                {
                    briefingTexto.AppendLine($"- {objtivo}");
                }
            }
            
            // Destino do Copy
            briefingTexto.AppendLine($"**Este texto é para:** {promptCopy.briefing.DestinoCopy} \n");

            // Mensagem a ser Transmitida
            briefingTexto.AppendLine($"**Mensagem a ser Transmitida:** {promptCopy.briefing.MensagemTransmitida} \n");

            // Metas da Campanha
            briefingTexto.AppendLine("### Metas da Campanha:");
            briefingTexto.AppendLine($"- **Adição ao Carrinho:** {(promptCopy.briefing.metasCampanhas.AdicaoCarrinho ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Cadastro de Formulário:** {(promptCopy.briefing.metasCampanhas.CadastroFrm ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Cliques no Link:** {(promptCopy.briefing.metasCampanhas.Clickslink ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Compartilhamentos:** {(promptCopy.briefing.metasCampanhas.Compartilhamentos ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Desempenho:** {(promptCopy.briefing.metasCampanhas.Desempenho ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Engajamento:** {(promptCopy.briefing.metasCampanhas.Engajamento ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Interação:** {(promptCopy.briefing.metasCampanhas.Interacao ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Permanência na Página:** {(promptCopy.briefing.metasCampanhas.PermanenciaPag ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Registro:** {(promptCopy.briefing.metasCampanhas.Registro ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Seguidores:** {(promptCopy.briefing.metasCampanhas.Seguidores ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Vendas:** {(promptCopy.briefing.metasCampanhas.Vendas ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- **Visualizações:** {(promptCopy.briefing.metasCampanhas.Vizualizacoes ? "Sim" : "Não")}\n");

            // Final do briefing

            return briefingTexto.ToString();
        }

        #endregion
    }
}
