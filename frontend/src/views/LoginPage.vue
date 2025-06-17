<template>
  <div class="min-h-screen bg-zinc-950 text-white flex flex-col items-center justify-center p-4">
    <div class="bg-zinc-900 p-6 rounded-2xl shadow-2xl w-full max-w-md flex flex-col space-y-4 border border-purple-800/40">
      <h1 class="text-4xl font-bold text-center text-purple-400 mb-4 tracking-wider">INVICTUS Copy’s</h1>
      <div class="flex flex-col space-y-4 overflow-auto max-h-[400px] p-2 border border-zinc-700 rounded-lg bg-zinc-800 backdrop-blur-sm">
        <div
          v-for="(msg, index) in messages"
          :key="index"
          :class="[
            'max-w-[80%] py-2 px-4 rounded-xl break-words text-sm transition-all duration-300 ease-in-out',
            msg.sender === 'user' ? 'bg-purple-600 self-end text-white shadow-lg' : 'bg-zinc-700 self-start text-gray-300 shadow-md'
          ]"
        >
          {{ msg.text }}
        </div>
      </div>
      <form @submit.prevent="handleSubmit" class="flex space-x-3 mt-2">
        <input
          v-model="inputText"
          type="text"
          placeholder="Descreva seu produto..."
          class="flex-grow p-3 rounded-xl bg-zinc-800 text-white border border-purple-500/30 focus:outline-none focus:ring-2 focus:ring-purple-500 placeholder-gray-400 transition-all duration-300"
        />
        <button
          type="submit"
          :disabled="loading"
          class="px-6 py-3 bg-gradient-to-br from-purple-600 to-purple-800 hover:from-purple-700 hover:to-purple-900 shadow-lg rounded-xl text-white font-semibold disabled:opacity-50 transition-all duration-300 animate-neon"
        >
          {{ loading ? 'Gerando...' : 'Enviar' }}
        </button>
      </form>
      <div v-if="error" class="text-red-500 text-center mt-2">{{ error }}</div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const inputText = ref('')
const messages = ref([])
const loading = ref(false)
const error = ref('')

async function handleSubmit() {
  if (!inputText.value.trim()) return
  error.value = ''
  loading.value = true
  messages.value.push({ sender: 'user', text: inputText.value })

  try {
    const payload = {
      tipoPost: 'post',
      tom: 'informal',
      publico: 'jovens',
      produto: inputText.value
    }

    const response = await axios.post('http://localhost:5093/generate-copy', payload)
    const generatedCopy = response.data.copy || 'Nenhuma copy gerada.'
    messages.value.push({ sender: 'bot', text: generatedCopy })
  } catch (err) {
    error.value = 'Erro ao gerar a copy, tenta de novo aí.'
  } finally {
    loading.value = false
    inputText.value = ''
  }
}
</script>

<style>
body {
  margin: 0;
  font-family: 'Inter', sans-serif;
}

@keyframes neonPulse {
  0% { box-shadow: 0 0 5px #a855f7, 0 0 10px #a855f7; }
  50% { box-shadow: 0 0 20px #a855f7, 0 0 40px #a855f7; }
  100% { box-shadow: 0 0 5px #a855f7, 0 0 10px #a855f7; }
}

.animate-neon {
  animation: neonPulse 2s infinite;
}
</style>