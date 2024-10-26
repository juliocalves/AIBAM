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

        public ChatClient(string serverAddress, int serverPort)
        {
            _serverAddress = serverAddress;
            _serverPort = serverPort;
        }
        public async Task Connect()
        {
            int maxRetries = 3;  // Número máximo de tentativas
            int delayBetweenRetries = 10000;  // Tempo de espera entre tentativas (em milissegundos)

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    _client = new TcpClient();
                    await _client.ConnectAsync(_serverAddress, _serverPort);
                    _stream = _client.GetStream();
                    OnConect?.Invoke("Conectado ao servidor com sucesso!");
                    break;  // Sai do loop se a conexão for bem-sucedida
                }
                catch (Exception ex)
                {
                    if (attempt == maxRetries)
                    {
                        OnConect?.Invoke($"Erro ao conectar ao servidor após {maxRetries} tentativas: {ex.Message}");
                    }
                    else
                    {
                        OnConect?.Invoke($"Tentativa {attempt} de {maxRetries} falhou. Tentando novamente em 20 segundos...");
                        await Task.Delay(delayBetweenRetries);  // Aguarda 20 segundos antes da próxima tentativa
                    }
                }
            }
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
                        string partialResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

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
