<template>
  <div class="ActiveKeep">
    <router-link :to="{name: 'home'}">Dashboard</router-link>
    <div class="row">
      <div class="col">
        <div class="card">
          <div class="card-header">
            <h1 class="card-header">{{activeKeep.name}}</h1>
          </div>
          <div class="card-body">
            <h4>{{activeKeep.description}}</h4>
            <img :src="activeKeep.img" alt="keep image">
          </div>
          <div class="card-footer">
            <div class="row">
              <div class="col-2">
                <div class="btn-group dropright">
                  <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">Add to
                    vault</button>
                  <div class="dropdown-menu">
                    <li v-for="vault in userVaults">
                      <a class="dropdown-item" @click="addToVault(vault.id, activeKeep.id)" href="#">{{vault.name}}</a>
                    </li>
                  </div>
                </div>
              </div>
              <div class="col">
                <p>Keeps: {{activeKeep.keeps}} || Shares: {{activeKeep.shares}} || Views: {{activeKeep.views}}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>

  export default {
    name: 'ActiveKeep',
    // mounted() {
    //   this.$store.dispatch("getVaultsByUserId")
    // },
    mounted() {
      // debugger
      this.$store.dispatch("getKeepById", this.$route.params.kId)
    },
    data() {
      return {
        // newVaultKeep: {
        //   vaultId: "",
        //   keepId: ""
        // }
      }
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      },
      userVaults() {
        return this.$store.state.userVaults
      }
    },
    methods: {
      addToVault(vaultid, keepid) {
        // debugger
        let newVaultKeep = {
          vaultId: vaultid,
          keepId: keepid
        }
        this.$store.dispatch("addKeepToVault", newVaultKeep)

      }
    },
    components: {}
  }
</script>


<style scoped>

</style>