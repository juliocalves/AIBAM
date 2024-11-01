using AIBAM.Classes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIBAM
{
    public class Utils
    {
        private readonly Action<string> statusUpdater;

        // Construtor que aceita uma função para atualizar o status
        public Utils(Action<string> statusUpdater)
        {
            this.statusUpdater = statusUpdater;
        }

        public string ObterTextoGroupBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }

        public List<string> ObterItensSelecionado(CheckedListBox ckList)
        {
            List<string> itensSelecionados = new List<string>();
            foreach (var item in ckList.CheckedItems)
            {
                itensSelecionados.Add(item?.ToString());
            }
            return itensSelecionados;
        }

        public void SaveToJson(dynamic obj, string nome)
        {
            string directoryPath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS");
            string filePath = Path.Combine(directoryPath, $"{nome}.json");

            try
            {
                string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
                statusUpdater?.Invoke("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                statusUpdater?.Invoke($"Erro ao salvar os dados: {ex.Message}");
            }
        }
        public void SaveDataSetToJson(dynamic newItem, string nome)
        {
            string directoryPath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS");
            string filePath = Path.Combine(directoryPath, $"{nome}.json");

            // Cria o diretório caso ele não exista
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            List<dynamic> itemList = new List<dynamic>();

            try
            {
                // Carrega a lista existente se o arquivo já existir
                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    itemList = JsonConvert.DeserializeObject<List<dynamic>>(existingJson) ?? new List<dynamic>();
                }

                // Adiciona o novo item à lista
                itemList.Add(newItem);

                // Serializa e salva a lista atualizada no arquivo
                string updatedJson = JsonConvert.SerializeObject(itemList, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);

                // Atualiza o status
                statusUpdater?.Invoke("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                statusUpdater?.Invoke($"Erro ao salvar os dados: {ex.Message}");
            }
        }

        public void EditItemInJson(string filePath, Guid itemId, Produto updatedItem)
        {
            filePath = Path.Combine(Settings.Default.DiretorioRaiz, filePath);
            if (!File.Exists(filePath))
            {
                statusUpdater?.Invoke("Arquivo JSON não encontrado.");
                return;
            }

            try
            {
                var json = File.ReadAllText(filePath);
                var jsonArray = JArray.Parse(json);

                var itemToUpdate = jsonArray.FirstOrDefault(item => (Guid)item["Id"] == itemId);
                if (itemToUpdate != null)
                {
                    var updatedJObject = JObject.FromObject(updatedItem); // Converte Produto para JObject
                    foreach (var prop in updatedJObject.Properties())
                    {
                        itemToUpdate[prop.Name] = prop.Value; // Atualiza propriedades
                    }

                    File.WriteAllText(filePath, jsonArray.ToString());
                    statusUpdater?.Invoke("Item atualizado com sucesso!");
                }
                else
                {
                    statusUpdater?.Invoke("Item não encontrado.");
                }
            }
            catch (Exception ex)
            {
                statusUpdater?.Invoke($"Erro ao atualizar o item: {ex.Message}");
            }
        }
    }
}
