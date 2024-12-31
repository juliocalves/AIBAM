using AIBAM.Classes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AIBAM
{
    public class ChatClient
    {
        public event Action<string> OnMessageReceived;
        public event Action<string> OnConect;
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _serverAddress;
        private readonly int _serverPort;

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        public ChatClient(string serverAddress, int serverPort)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        {
            _serverAddress = serverAddress;
            _serverPort = serverPort;
        }

        public async Task Connect(Func<Task> onConnected)
        {
            int maxRetries = 3; // Número máximo de tentativas
            int delayBetweenRetries = 10000; // Tempo de espera entre tentativas (em milissegundos)

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    // Tenta conectar ao servidor
                    _client = new TcpClient();
                    await _client.ConnectAsync(_serverAddress, _serverPort);
                    _stream = _client.GetStream();
                    OnConect?.Invoke("Conectado ao servidor com sucesso!");

                    // Chama o método para executar após a conexão bem-sucedida
                    if (onConnected != null)
                    {
                        await onConnected();
                    }

                    break; // Sai do loop se a conexão for bem-sucedida
                }
                catch (Exception ex)
                {
                    if (attempt == maxRetries)
                    {
                        OnConect?.Invoke($"Erro ao conectar ao servidor após {maxRetries} tentativas: {ex.Message}");
                    }
                    else
                    {
                        OnConect?.Invoke($"Tentativa {attempt} de {maxRetries} falhou. Tentando novamente em {delayBetweenRetries / 1000} segundos...");
                        await Task.Delay(delayBetweenRetries); // Aguarda antes da próxima tentativa
                    }
                }
            }
        }


        // Método para verificar se o processo está em execução
        private bool IsProcessRunning(string processName)
        {
            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)).Length > 0;
        }
        public string AppendToJson(string json, object appendData)
        {
            // Converte o JSON existente em um JObject
            JObject jsonObject = JObject.Parse(json);

            // Converte o objeto a ser adicionado em um JObject
            JObject appendObject = JObject.FromObject(appendData);

            // Faz o "append" das propriedades do novo objeto ao JSON original
            foreach (var property in appendObject.Properties())
            {
                jsonObject[property.Name] = property.Value;
            }

            // Retorna o JSON atualizado como string
            return jsonObject.ToString(Formatting.Indented);
        }

        public async Task SendMessage(ChatData message, Modelo modelo = null)
        {
            if (_stream == null)
            {
                MessageBox.Show("Conexão não estabelecida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string json = JsonConvert.SerializeObject(message, Newtonsoft.Json.Formatting.Indented);
                if (modelo != null)
                {
                    json = AppendToJson(json, modelo);
                }
                
                // Enviar mensagem
                byte[] data = Encoding.UTF8.GetBytes(json);
                await _stream.WriteAsync(data, 0, data.Length);

                // Buffer para armazenar a resposta
                byte[] responseBuffer = new byte[1024];
                int bytesRead;

                // Continue lendo enquanto houver dados
                do
                {
                    bytesRead = await _stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                    if (bytesRead > 0)
                    {
                        // Converte o buffer UTF-8 para string
                        string partialResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        // Deserializa o JSON para um objeto GeminiChunk
                        //GeminiChunk geminiChunk = JsonConvert.DeserializeObject<GeminiChunk>(partialResponse);

                        // Dispara o evento para o trecho de mensagem recebido
                        OnMessageReceived?.Invoke(partialResponse);
                    }
                }
                while (bytesRead > 0); // Continua enquanto houver dados
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }

        public async Task<string> CarregarListaAsync()
        {
            try
            {
                // Conecta ao servidor, se ainda não conectado
                if (_client == null || !_client.Connected)
                {
                    await Connect(async () =>
                    {
                        OnConect?.Invoke("Conexão estabelecida para listar modelos.");
                    });
                }

                // Envia o comando listar_modelos
                var chatData = new ChatData
                {
                    Command = "listar_modelos"
                };

                string json = JsonConvert.SerializeObject(chatData, Newtonsoft.Json.Formatting.Indented);
                // Enviar mensagem
                byte[] data = Encoding.UTF8.GetBytes(json);
                await _stream.WriteAsync(data, 0, data.Length);

                // Buffer para armazenar a resposta
                byte[] responseBuffer = new byte[1024];
                int bytesRead;
                string response = "";
              
                bytesRead = await _stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                if (bytesRead > 0)
                {
                    // Converte o buffer UTF-8 para string
                    string partialResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
                    // Dispara o evento para o trecho de mensagem recebido
                    response = partialResponse;
                }
              

              

                // Envia o comando sair
                var sairData = new ChatData
                {
                    Command = "sair"
                };
                await SendMessage(sairData);
                json = JsonConvert.SerializeObject(sairData, Newtonsoft.Json.Formatting.Indented);
                // Enviar mensagem
                data = Encoding.UTF8.GetBytes(json);
                await _stream.WriteAsync(data, 0, data.Length);

                return response;
            }
            catch (Exception ex)
            {
                OnConect?.Invoke($"Erro ao carregar a lista de modelos: {ex.Message}");
                return $"Erro: {ex.Message}";
            }
        }


        public class ChatData() {
            public string? Command { get; set; }
            public string? Modelo { get; set; }
            public string? OpcaoModelo { get; set; }
            public string? Prompt { get; set; }
            public string? Path { get; set; }
            public string?ImgPath {get;set;}
        }

    }
}
