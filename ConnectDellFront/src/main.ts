import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import VueCookies from 'vue-cookies'
import axios, { isCancel, AxiosError } from 'axios';

const app = createApp(App);

app.use(router);
app.use(VueCookies, { expires: '1d'})

app.mount('#app');