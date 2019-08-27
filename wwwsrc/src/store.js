import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    userVaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setUserVaults(state, data) {
      state.userVaults = data
    },
    setActiveVault(state, data) {
      state.activeVault = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
    }
  },
  actions: {
    // #region AUTH STUFF
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    // #endregion

    // #region KEEP METHODS
    async getAllKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        console.log(res.data)
        commit("setKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    // #endregion
    // #region VAULT METHODS
    async getVaultsByUserId({ commit, dispatch }) {
      // debugger
      try {
        let res = await api.get('vaults')
        console.log(res.data)
        commit("setUserVaults", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getVaultById({ commit, dispatch }, payload) {
      try {
        let res = await api.get('vaults/' + payload)
        commit("setActiveVault", res.data)
        dispatch("getKeepsByVaultId", payload)
        // let res = await api.get('vaults/' + payload.id)
      } catch (error) {
        console.error(error)
      }
    },
    async createVault({ commit, dispatch }, payload) {
      try {
        await api.post('vaults', payload)
        dispatch('getVaultsByUserId')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        await api.delete('vaults/' + payload)
        console.log('Vault deleted')
        dispatch('getVaultsByUserId')
      } catch (error) {
        console.error(error)
      }
    },
    // #endregion
    // #region VAULTKEEP METHODS
    async getKeepsByVaultId({ commit, dispatch }, payload) {
      let res = await api.get('vaultkeeps/' + payload, payload)
      commit("setVaultKeeps", res.data)
      console.log(res.data)
    }
    // #endregion
  }
})
