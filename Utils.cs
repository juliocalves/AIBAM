using AIBAM.Classes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIBAM
{
    public class Utils
    {
        private readonly Action<string> statusUpdater;
        private readonly Action atualizaBarraProgresso;
        // Construtor que aceita uma função para atualizar o status
        public Utils(Action<string> statusUpdater, Action atualizaBarraProgresso)
        {
            this.statusUpdater = statusUpdater;
            this.atualizaBarraProgresso = atualizaBarraProgresso;
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
      
        public void SetSelectedValue(CheckedListBox ckList, List<string> itens)
        {
            // Itera sobre todos os itens no CheckedListBox
            for (int i = 0; i < ckList.Items.Count; i++)
            {
                // Verifica se o texto do item atual está na lista de itens fornecida
                if (itens.Contains(ckList.Items[i].ToString()))
                {
                    // Marca o item se estiver na lista
                    ckList.SetItemChecked(i, true);
                }
                else
                {
                    // Desmarca o item se não estiver na lista
                    ckList.SetItemChecked(i, false);
                }
            }
        }
        public void SetSelectedValue(GroupBox groupBox, string value)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = radioButton.Text == value;
                }
            }
        }
        public void ApenasDecimal(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado é um número, vírgula ou tecla de controle (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // Se não for, cancela o evento, impedindo o caractere de ser inserido
                e.Handled = true;
            }

            // Evita a inserção de mais de uma vírgula
            TextBox txtBox = sender as TextBox;
            if (e.KeyChar == ',' && txtBox.Text.Contains(","))
            {
                e.Handled = true;
            }
        }
        public void AbrirFormulario<T>(Form parent, Action<T> configuracao = null, bool IsIndependent = false) where T : Form, new()
        {
            if (IsIndependent)
            {
                T form = new T();
                form.Show();
                return;
            }

            // Verifica se o formulário já está aberto
            var formAberto = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (formAberto == null)
            {
                // Cria uma nova instância do formulário
                T form = new T();

                if (parent.IsMdiContainer)
                {
                    // Configura como filho MDI se o pai for um container MDI
                    form.MdiParent = parent;
                    form.WindowState = FormWindowState.Normal; // Opcional: abrir maximizado
                }

                // Aplica configurações adicionais, se fornecidas
                configuracao?.Invoke(form);

                form.Show(); // Exibe o formulário
            }
            else
            {
                formAberto.WindowState = FormWindowState.Normal;
                // Traz o formulário existente para frente
                formAberto.Focus();
            }
        }

        // Método para configurar temas
        public void SetarThema(Form form, string tema)
        {
            if (tema.Equals("black", StringComparison.OrdinalIgnoreCase))
            {
                // Configurações para o tema escuro
                form.BackColor = Color.FromArgb(30, 30, 30);
                form.ForeColor = Color.White;

                foreach (Control control in form.Controls)
                {
                    AplicarTemaEscuro(control);
                }
            }
            else if (tema.Equals("white", StringComparison.OrdinalIgnoreCase))
            {
                // Configurações para o tema claro
                form.BackColor = Color.White;
                form.ForeColor = Color.Black;

                foreach (Control control in form.Controls)
                {
                    AplicarTemaClaro(control);
                }
            }
            else
            {
                throw new ArgumentException("Tema inválido. Use 'black' ou 'white'.");
            }
        }

        private void AplicarTemaEscuro(Control control)
        {
            control.BackColor = Color.FromArgb(30, 30, 30);
            control.ForeColor = Color.White;

            if (control is TabControl tabControl)
            {
                tabControl.Appearance = TabAppearance.FlatButtons;
                tabControl.ItemSize = new Size(100, 30);
                tabControl.SizeMode = TabSizeMode.Fixed;
                tabControl.BackColor = Color.FromArgb(45, 45, 45);
                tabControl.ForeColor = Color.White;
            }

            foreach (Control child in control.Controls)
            {
                AplicarTemaEscuro(child);
            }
        }

        private void AplicarTemaClaro(Control control)
        {
            control.BackColor = Color.White;
            control.ForeColor = Color.Black;

            if (control is TabControl tabControl)
            {
                tabControl.Appearance = TabAppearance.FlatButtons;
                tabControl.ItemSize = new Size(100, 30);
                tabControl.SizeMode = TabSizeMode.Fixed;
                tabControl.BackColor = Color.LightGray;
                tabControl.ForeColor = Color.Black;
            }

            foreach (Control child in control.Controls)
            {
                AplicarTemaClaro(child);
            }
        }

    }
}
