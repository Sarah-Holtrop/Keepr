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
            <button class="btn btn-info">Enter Vault</button>
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
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>