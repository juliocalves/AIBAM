using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Data;

namespace AIBAM.Classes
{
    public class Modelo()
    {
        public string? NomeModelo { get; set; }
        public string? IdentificacaoModelo { get; set; }
        public string? DescricaoModelo { get; set; }
        public List<string>? RegrasModelo { get; set; }
        public string? IANome { get; set; }
        public double? Temperatura { get; set; }
        public int? LimiteTokens { get; set; }
        public string? FiltroAssedio { get; set; }
        public string? FiltroDiscurso { get; set; }
        public string? FiltroPerigoso { get; set; }
        public string? FiltroSexualmente { get; set; }
        public Tuple<List<string>, List<string>>? ExemplosEntradaSaida { get; set; } = new Tuple<List<string>, List<string>>(new List<string>(), new List<string>());
        public class ModeloManager
        {
            public List<Modelo> CarregarModelos()
            {
                var modelos = new List<Modelo>();
                var pathModelos = Settings.Default.modelosPath;

                if (!File.Exists(pathModelos))
                    return modelos;

                try
                {
                    var jsonContent = File.ReadAllText(pathModelos);
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);

                    if (jsonObject != null)
                    {
                        foreach (var modeloEntry in jsonObject)
                        {
                            var nomeModelo = modeloEntry.Key;
                            var modeloDetalhes = modeloEntry.Value as JObject;

                            if (modeloDetalhes != null)
                            {
                                foreach (var identificacaoEntry in modeloDetalhes)
                                {
                                    var identificacaoModelo = identificacaoEntry.Key;
                                    var propriedades = identificacaoEntry.Value as JObject;

                                    var descricaoModelo = propriedades?["descricao"]?.ToString() ?? identificacaoEntry.Value.ToString();
                                    var iaNome = propriedades?["model_name"]?.ToString() ?? "default";
                                    var detalhesModelo = propriedades?["detalhes"] is JArray detalhesArray
                                        ? detalhesArray.Select(d => d.ToString()).ToList()
                                        : new List<string>();
                                    // Inicializa as listas para armazenar as entradas e saídas
                                    Tuple<List<string>, List<string>> inputOutput;

                                    if (propriedades?["exemplos_entrada_saida"] is JObject exemplosObj)
                                    {
                                        // Extrai as listas de entrada e saída do JSON
                                        var entradas = exemplosObj["entrada"]?.ToObject<List<string>>() ?? new List<string>();
                                        var saidas = exemplosObj["saida"]?.ToObject<List<string>>() ?? new List<string>();

                                        // Cria a tupla com as listas de entradas e saídas
                                        inputOutput = new Tuple<List<string>, List<string>>(entradas, saidas);
                                    }
                                    else
                                    {
                                        // Caso não haja exemplos no JSON, define como tupla com listas vazias
                                        inputOutput = new Tuple<List<string>, List<string>>(new List<string>(), new List<string>());
                                    }

                                    // Recupera os valores dos filtros
                                    var filtros = propriedades?["filtros"] as JObject;
                                    var filtroAssedio = filtros?["assedio"]?.ToString() ?? "N/A";
                                    var filtroDiscurso = filtros?["discurso"]?.ToString() ?? "N/A";
                                    var filtroSexual = filtros?["sexual"]?.ToString() ?? "N/A";
                                    var filtroPerigoso = filtros?["perigoso"]?.ToString() ?? "N/A";
                                    var temperatura = Convert.ToDouble(propriedades?["temperatura"]?.ToString());
                                    var tokens = Convert.ToInt32(propriedades?["limite_tokens"]?.ToString());
                                    modelos.Add(new Modelo
                                    {
                                        NomeModelo = nomeModelo,
                                        IdentificacaoModelo = identificacaoModelo,
                                        DescricaoModelo = descricaoModelo,
                                        RegrasModelo = detalhesModelo,
                                        IANome = iaNome,
                                        FiltroAssedio = filtroAssedio,
                                        FiltroDiscurso = filtroDiscurso,
                                        FiltroSexualmente = filtroSexual,
                                        FiltroPerigoso = filtroPerigoso,
                                        Temperatura = temperatura,
                                        LimiteTokens = tokens,
                                        ExemplosEntradaSaida = inputOutput
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao carregar os modelos: {ex.Message}");
                }

                return modelos;
            }
            public void SalvarModelo(Modelo modelo)
            {
                var pathModelos = Settings.Default.modelosPath;

                try
                {
                    // Verifica se o arquivo de modelos existe e carrega seu conteúdo
                    var jsonObject = new Dictionary<string, object>();

                    if (File.Exists(pathModelos))
                    {
                        var jsonContent = File.ReadAllText(pathModelos);
                        jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent) ?? new Dictionary<string, object>();
                    }

                    // Adiciona ou atualiza o modelo
                    if (!jsonObject.ContainsKey(modelo.NomeModelo))
                    {
                        jsonObject[modelo.NomeModelo] = new JObject();
                    }

                    var modeloDetalhes = jsonObject[modelo.NomeModelo] as JObject;
                    if (modeloDetalhes != null)
                    {
                        if (!modeloDetalhes.ContainsKey(modelo.IdentificacaoModelo))
                        {
                            modeloDetalhes[modelo.IdentificacaoModelo] = new JObject();
                        }

                        var propriedades = modeloDetalhes[modelo.IdentificacaoModelo] as JObject;
                        if (propriedades != null)
                        {
                            propriedades["descricao"] = modelo.DescricaoModelo;
                            propriedades["detalhes"] = new JArray(modelo.RegrasModelo);
                            propriedades["model_name"] = modelo.IANome;
                            propriedades["limite_tokens"] = modelo.LimiteTokens;
                            propriedades["temperatura"] = modelo.Temperatura;
                            propriedades["filtros"] = new JObject
                            {
                                ["assedio"] = modelo.FiltroAssedio,
                                ["discurso"] = modelo.FiltroDiscurso,
                                ["sexual"] = modelo.FiltroSexualmente,
                                ["perigoso"] = modelo.FiltroPerigoso
                            };
                            var exemplosEntrada = modelo.ExemplosEntradaSaida.Item1; // Lista de entradas
                            var exemplosSaida = modelo.ExemplosEntradaSaida.Item2;  // Lista de saídas
                                                         // Cria a estrutura JSON com os exemplos
                            var exemplosEntradaSaida = new JObject
                            {
                                ["entrada"] = new JArray(exemplosEntrada),
                                ["saida"] = new JArray(exemplosSaida)
                            };

                            // Adiciona ao JSON de propriedades
                            propriedades["exemplos_entrada_saida"] = exemplosEntradaSaida;
                        }
                    }

                    // Serializa o conteúdo e grava no arquivo
                    var updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(pathModelos, updatedJsonContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar o modelo: {ex.Message}");
                }
            }
        }
    }
}
