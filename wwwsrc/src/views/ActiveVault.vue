<template>
  <div class="ActiveVault">
    <router-link :to="{name: 'home'}">Dashboard</router-link>
    <div class="row">
      <div class="col">
        <h2>{{activeVault.name}}</h2>
        <h2>{{activeVault.description}}</h2>
        <vaultKeeps></vaultKeeps>
      </div>
      <!-- <div class="row">
      </div> -->
    </div>
  </div>

  </div>
</template>


<script>
  import vaultKeeps from "../components/VaultKeepsComponent.vue"
  export default {
    name: 'ActiveVault',
    mounted() {
      this.$store.dispatch("getVaultById", this.$route.params.vId)
    },
    data() {
      return {}
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      }
    },
    methods: {},
    components: {
      vaultKeeps
    }
  }
</script>


<style scoped>

</style>