using System.Diagnostics;

namespace AIBAM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cria e inicia uma nova thread para executar o script Python
            //Thread pythonScriptThread = new Thread(ExecutePythonScript);
            //pythonScriptThread.IsBackground = true; // Define como uma thread de fundo
            //pythonScriptThread.Start();

            // Executa a interface gr�fica principal
            Application.Run(new FrmPrincipal());
        }

        /// <summary>
        /// M�todo que executa o script Python.
        /// </summary>
        private static void ExecutePythonScript()
        {
            string pythonExePath = @"C:\Users\sirja\AppData\Local\Programs\Python\Python311\python.exe";
            string scriptPath = @"A:\DESKTOP\WSocket\gemini.py";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = scriptPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true // N�o mostrar uma janela de console
            };

            using Process process = new Process();
            process.StartInfo = startInfo;

            // Captura a sa�da do script Python
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine(e.Data); // Ou use um m�todo para exibir na interface gr�fica
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine("Error: " + e.Data); // Ou use um m�todo para exibir na interface gr�fica
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit(); // Espera o script terminar
        }
    }
}
