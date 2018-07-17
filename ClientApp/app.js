import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css'
import App from 'views/app-root'

Vue.prototype.$http = axios;

Vue.use(ElementUI);


sync(store, router)

const app = new Vue({
    store,
    router,
    ...App
})

export {
    app,
    router,
    store
}

// const requireComponent = require.context(
//     // The relative path of the components folder
//     './views',
//     // Whether or not to look in subfolders
//     false,
//     // The regular expression used to match base component filenames
//     /Base[A-Z]\w+\.(vue|js)$/
//   )
  
//   requireComponent.keys().forEach(fileName => {
//     // Get component config
//     const componentConfig = requireComponent(fileName)
  
//     // Get PascalCase name of component
//     const componentName = upperFirst(
//       camelCase(
//         // Strip the leading `'./` and extension from the filename
//         fileName.replace(/^\.\/(.*)\.\w+$/, '$1')
//       )
//     )
  
//     // Register component globally
//     Vue.component(
//       componentName,
//       // Look for the component options on `.default`, which will
//       // exist if the component was exported with `export default`,
//       // otherwise fall back to module's root.
//       componentConfig.default || componentConfig
//     )
//   })