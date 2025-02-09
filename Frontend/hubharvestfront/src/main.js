import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import Toast from 'vue-toastification';
import 'vue-toastification/dist/index.css';

const options = {
    // Opsi konfigurasi untuk vue-toastification
    position: 'top-right',
    timeout: 3000,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: false
};

const app = createApp(App);

app.use(router);
app.use(Toast, options);

app.mount('#app');
