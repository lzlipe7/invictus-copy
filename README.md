---

### 📄 **`README.md`**

````markdown
# 🧠 Invictus Copy

Sistema de geração automática de copies de marketing usando inteligência artificial (OpenAI), com frontend em Vue + Vite e backend em ASP.NET Core.

---

## 🚀 Tecnologias

- **Frontend:** Vue 3, Vite, Axios, TailwindCSS
- **Backend:** ASP.NET Core
- **IA:** OpenAI API (chat completions)
- **Estilo:** Dark com roxo neon futurista 😎

---

## 📦 Como rodar o projeto local

### 🔧 Pré-requisitos
- Node.js (recomendado: 18+)
- .NET SDK (recomendado: 7.0+)
- Uma chave da OpenAI (ex: `sk-...`)

---

### 🔙 Backend

1. Vá para a pasta do backend:
   ```bash
   cd backend/Invictus.API
````

2. Crie o arquivo de configuração:

   ```bash
   copy appsettings.example.json appsettings.json
   ```

3. Abra o `appsettings.json` e coloque sua OpenAI Key.

4. Instale os pacotes (se necessário) e rode:

   ```bash
   dotnet restore
   dotnet run
   ```

A API vai rodar em:
👉 `http://localhost:5093`

---

### 🎨 Frontend

1. Vá para a pasta do frontend:

   ```bash
   cd frontend
   ```

2. Crie o arquivo `.env` com a URL da sua API:

   ```bash
   copy .env.example .env
   ```

3. Instale as dependências:

   ```bash
   npm install
   ```

4. Rode o servidor:

   ```bash
   npm run dev
   ```

A aplicação vai abrir em:
👉 `http://localhost:5173`

---

## 🛡️ Segurança

Lembre de **NUNCA subir sua chave da OpenAI**. Use `.env` e `appsettings.json` no `.gitignore`.

---

## 🧪 Exemplo de Prompt

* Produto: "Tênis Nike Air Max"
* Tom: "Engraçado"
* Público: "Jovem"
* Tipo do post: "Story"

---

## 🖥️ Feito por:

-ALEXSANDHER ANGEL
-1986097

-LUIZ FELIPE ROSA
-1996870

-NATAN DEL BONI
-1999528
