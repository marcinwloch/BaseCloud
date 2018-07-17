import login from 'views/login/LoginView'
import system from 'views/system/SystemView'

import dashboard from './views/system/pages/DashboardPage'
import settings from './views/system/pages/SettingsPage'

export const routes = [
    { path: '/Login', component: login, display: 'Login', style: 'glyphicon glyphicon-login' },
    {
        //path: '/', component: system, name: 'system',
          path: '/system', component: system, name: 'system',
        children: [
            { path: 'Dashboard', compenent: dashboard, name: 'dashboardPage' },
            { path: 'Settings', compenent: settings, name: 'settings' }
        ]
    }
]