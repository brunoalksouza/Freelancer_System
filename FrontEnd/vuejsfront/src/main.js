import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle'
import '@fortawesome/fontawesome-free/css/all.min.css'
import toastrPlugin from '@/services/toastr'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

createApp(App).use(router).use(toastrPlugin).mount('#app')
