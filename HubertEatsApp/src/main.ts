import { createApp } from 'vue'
import { createPinia, storeToRefs } from 'pinia'

import App from './App.vue'
import router from './router'
import './assets/main.css'
import { useAuthStore } from './stores/auth'

const app = createApp(App)

app.use(createPinia())
app.use(router);

app.mount('#app')