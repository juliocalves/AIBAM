
let currentBotMessageId = null;
let isTyping = false;
let accumulatedMessage = "";
// Função para adicionar mensagem do usuário
function addUserMessage(message) {
    const chatContainer = document.getElementById('chat-container');
    const messageDiv = document.createElement('div');
    messageDiv.className = 'user-message';
    messageDiv.textContent = message;
    chatContainer.appendChild(messageDiv);

}

// Função para criar ou atualizar uma mensagem do bot
async function addOrUpdateBotMessage(message, isFinalFragment = false) {
    const chatContainer = document.getElementById('chat-container');

    // Cria um novo elemento para a mensagem se não houver nenhum em construção
    if (!currentBotMessageId) {
        currentBotMessageId = generateUniqueId();
        const messageDiv = document.createElement('div');
        messageDiv.id = currentBotMessageId;
        messageDiv.className = 'bot-message';
        chatContainer.appendChild(messageDiv);
    }

    // Acumula o conteúdo da mensagem
    accumulatedMessage += message;

    const messageDiv = document.getElementById(currentBotMessageId);

    if (isFinalFragment) {
        // Verifica se a digitação está em andamento
        if (isTyping) {
            // Aguarda até que a digitação atual termine
            await waitUntilTypingEnds();
        }

        // Atualiza o conteúdo final da mensagem
        messageDiv.innerHTML = message;
        resetTypingState(); // Reseta estado de digitação
    } else {
        // Caso não seja o fragmento final, inicia a digitação se não estiver em andamento
        if (!isTyping) {
            isTyping = true;
            typeWriterEffect(messageDiv, accumulatedMessage, 50, () => {
                isTyping = false; // Digitação concluída
            });
        }
    }

    scrollToBottom();
}

// Objeto para armazenar o índice atual por elemento
const typingState = new Map();

// Função para digitar texto como uma máquina de escrever com callback
function typeWriterEffect(element, text, speed = 10, callback = null) {
    // Recupera o índice atual ou inicia em 0
    let index = typingState.get(element) || element.textContent.length;
    const remainingText = text.slice(index);

    function type() {
        if (index < text.length) {
            element.innerHTML += text.charAt(index); // Adiciona o próximo caractere
            index++;
            typingState.set(element, index); // Atualiza o estado de digitação
            scrollToBottom(); // Atualiza o scroll enquanto digita
            setTimeout(type, speed);
        } else {
            typingState.delete(element); // Remove o estado ao final
            if (callback) {
                callback(); // Chama o callback ao finalizar
            }
        }
    }

    type();
}


// Aguarda até que o estado de digitação termine
function waitUntilTypingEnds() {
    return new Promise((resolve) => {
        const interval = setInterval(() => {
            if (!isTyping) {
                clearInterval(interval);
                resolve();
            }
        }, 50); // Verifica o estado a cada 50ms
    });
}

// Reseta o estado de digitação e libera o ID da mensagem atual
function resetTypingState() {
    isTyping = false;
    accumulatedMessage = "";
    currentBotMessageId = null;
}

// Função para rolar o contêiner para o final
function scrollToBottom() {
    //const chatContainer = document.getElementById('chat-container');
    //if (chatContainer) {
    //    chatContainer.scrollTop = chatContainer.scrollHeight;
    //}
    window.scroll(0, document.body.scrollHeight);
    return document.body.scrollHeight;
}

// Gera um ID único para a mensagem
function generateUniqueId() {
    return `bot-message-${Date.now()}-${Math.random().toString(36).substr(2, 9)}`;
}

function addCards(cards) {
    const container = document.getElementById('card-container');

    if (!container) {
        console.error('Elemento card-container não encontrado.');
        return;
    }

    // Itera pelos cards e os adiciona ao container
    cards.forEach(card => {
        // Cria o elemento card
        const cardElement = document.createElement('div');
        cardElement.className = 'card';

        // Adiciona o texto do card
        const textElement = document.createElement('div');
        textElement.className = 'card-text';
        textElement.textContent = card.text;
        cardElement.appendChild(textElement);

        // Adiciona o botão de ação
        const buttonElement = document.createElement('button');
        buttonElement.className = 'card-button';
        buttonElement.textContent = 'Selecionar';
        // Adiciona um evento que pega o texto do card no clique
        buttonElement.onclick = () => {
            const text = textElement.textContent; // Recupera o texto do card
            window.chrome.webview.postMessage(text); // Envia o texto para o C#
        };

        cardElement.appendChild(buttonElement);

        // Adiciona o card ao container
        container.appendChild(cardElement);
    });
}


async function addProdutosSimilares(message, isFinalFragment = false) {
    // Localiza o container onde os produtos similares serão exibidos

    const chatContainer = document.getElementById('response');

    // Cria um novo elemento para a mensagem se não houver nenhum em construção
    if (!currentBotMessageId) {
        currentBotMessageId = generateUniqueId();
        const messageDiv = document.createElement('div');
        messageDiv.id = currentBotMessageId;
        messageDiv.className = 'bot-message';
        chatContainer.appendChild(messageDiv);
    }

    // Acumula o conteúdo da mensagem
    accumulatedMessage += message;

    const messageDiv = document.getElementById(currentBotMessageId);

    if (isFinalFragment) {
        // Verifica se a digitação está em andamento
        if (isTyping) {
            // Aguarda até que a digitação atual termine
            await waitUntilTypingEnds();
        }

        // Atualiza o conteúdo final da mensagem
        messageDiv.innerHTML = message;
        resetTypingState(); // Reseta estado de digitação
    } else {
        // Caso não seja o fragmento final, inicia a digitação se não estiver em andamento
        if (!isTyping) {
            isTyping = true;
            typeWriterEffect(messageDiv, accumulatedMessage, 25, () => {
                isTyping = false; // Digitação concluída
            });
        }
    }

    scrollToBottom();

   }

