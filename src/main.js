import Vue from 'vue'
import VueAxios from 'vue-axios'
import axios from 'axios'

import router from './router'

import App from './App'


Vue.config.productionTip = false

axios.defaults.withCredentials=true

Vue.use(VueAxios, axios)

new Vue({
  router,

  components: { App },
}).$mount('#app')
