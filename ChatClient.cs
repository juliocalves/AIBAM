using AIBAM.Classes;
using Newtonsoft.Json;

using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

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

        public async Task Connect()
        {
            int maxRetries = 3; // Número máximo de tentativas
            int delayBetweenRetries = 10000; // Tempo de espera entre tentativas (em milissegundos)
            string serviceName = "aibam_service.exe"; // Nome do executável
            string executionDirectory = @"A:\\DESKTOP\\WSocket\\dist";//AppDomain.CurrentDomain.BaseDirectory; // Diretório do executável
            string servicePath = Path.Combine(executionDirectory, serviceName); // Caminho completo do serviço

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    // Verifica se o processo está em execução
                    if (!IsProcessRunning(serviceName))
                    {
                        if (File.Exists(servicePath))
                        {
                            // Inicia o processo se ele não estiver em execução
                            Process.Start(servicePath);
                            OnConect?.Invoke($"{serviceName} iniciado.");
                            await Task.Delay(5000); // Aguarda 5 segundos para o serviço iniciar
                        }
                        else
                        {
                            throw new FileNotFoundException($"O arquivo {serviceName} não foi encontrado no diretório {executionDirectory}.");
                        }
                    }

                    // Tenta conectar ao servidor
                    _client = new TcpClient();
                    await _client.ConnectAsync(_serverAddress, _serverPort);
                    _stream = _client.GetStream();
                    OnConect?.Invoke("Conectado ao servidor com sucesso!");
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


        public async Task SendMessage(string message)
        {
            if (_stream == null)
            {
                MessageBox.Show("Conexão não estabelecida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Enviar mensagem
                byte[] data = Encoding.UTF8.GetBytes(message);
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
    }
}
