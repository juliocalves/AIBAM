import os
from dotenv import load_dotenv
import google.generativeai as genai

# Carregue variáveis de ambiente do arquivo .env
load_dotenv()

# Configure sua chave de API (nunca compartilhe sua chave em código público!)
API_KEY = os.getenv("GEMINI_API_KEY")
if API_KEY is None:
    raise ValueError("A chave da API não foi encontrada. Verifique o arquivo .env.")

# Configura a chave da API do Google
genai.configure(api_key=API_KEY)

generation_config = {
    'candidate_count':1,
    'temperature':0.2
}

model = genai.GenerativeModel(model_name='gemini-1.5-flash', generation_config=generation_config)

chat = model.start_chat(history=[])  # Inicia o chat

# Inicializa o modelo de chat e faz o streaming da resposta
def start_chat(txt):

    # Envia a mensagem e recebe a resposta em stream
    try:
        response = chat.send_message(txt, stream=True)
    except Exception as e:
        print(f"Erro ao enviar mensagem para o modelo: {e}")
        yield "Erro ao processar a solicitação. Tente novamente mais tarde."

    
    # Armazena as partes da resposta conforme são recebidas
    full_response = ""
    
    for chunk in response:
        fragment = chunk.text
        full_response += fragment  # Concatena o fragmento ao resultado completo
        # yield fragment

    # yield tratar_texto(full_response)  # Retorna o resultado completo no final
    yield full_response  # Retorna o resultado completo no final

def tratar_texto(txt):
    texto = ""
    for caracter in txt:
        if caracter not in "#*@$%&''-+.*/=+-_":
            texto += caracter
    return texto

def get_chat_history():
    history_md = []
    for message in chat.history:
        role = '**user**' if message.role == 'user' else '**model**'
        text_parts = [part.text for part in message.parts]
        full_message = ' '.join(text_parts)
        history_md.append(f'{role}: {full_message}')
    print(history_md)
    return "\n\n".join(history_md)

# Se chamado como um script, executa o chat com um prompt padrão
if __name__ == "__main__":
    import sys
    prompt_text = sys.argv[1] if len(sys.argv) > 1 else "O que preciso para implementar corretamente o Gemini em meu projeto pessoal?"

    # Chama a função que retorna fragmentos
    for fragment in start_chat(prompt_text):
        print(fragment)  # Exibe cada fragmento recebido em tempo real
    #get_chat_history()
