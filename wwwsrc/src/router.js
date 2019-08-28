import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import ActiveVault from './views/ActiveVault.vue'
// @ts-ignore
import ActiveKeep from './views/ActiveKeep.vue'
// @ts-ignore
import AllPublicKeeps from './views/AllPublicKeeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults/:vId',
      name: 'ActiveVault',
      component: ActiveVault
    },
    {
      path: '/keeps/:kId',
      name: 'ActiveKeep',
      component: ActiveKeep
    },
    {
      path: '/all',
      name: 'AllPublicKeeps',
      component: AllPublicKeeps
    }
  ]
})
