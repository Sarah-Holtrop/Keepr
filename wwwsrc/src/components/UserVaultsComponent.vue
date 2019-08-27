<template>
  <div class="UserVaultsComponent">
    <div class="row">
      <div class="col-4" v-for="vault in userVaults">
        <div class="card">
          <div class="card-header">
            <h3>{{vault.name}}</h3>
          </div>
          <div class="card-body">
            <h4>{{vault.description}}</h4>
          </div>
          <div class="card-footer">
            <button @click="enterVault(vault)" class="btn btn-info">Enter Vault</button>
            <button @click="deleteVault(vault.id)" class="btn btn-danger">delete vault</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'UserVaultsComponent',

    data() {
      return {}
    },
    computed: {
      userVaults() {
        return this.$store.state.userVaults
      }
    },
    methods: {
      enterVault(vault) {
        // console.log(vault.id)
        this.$router.push({ name: "ActiveVault", params: { vId: vault.id } })
      },
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>