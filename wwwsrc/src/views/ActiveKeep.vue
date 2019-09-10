<template>
  <div class="ActiveKeep">
    <div class="row">
      <div class="col">
        <h1>{{activeKeep.name}}</h1>
        <h4>{{activeKeep.description}}</h4>
        <img :src="activeKeep.img" alt="keep image">
        <p>Keeps: {{activeKeep.keeps}} || Shares: {{activeKeep.shares}} || Views: {{activeKeep.views}}</p>
        <div class="btn-group dropright">
          <button type="button" class="btn btn-success dropdown-toggle" data-toggle="dropdown">Add to vault</button>
          <div class="dropdown-menu">
            <li v-for="vault in userVaults">
              <a class="dropdown-item" href="#">{{vault.name}}</a>
            </li>
          </div>
        </div>
        <!-- #### -->
        <div v-for="vault in userVaults">
          <hr>
          <p>{{vault.name}}</p>
          <button @click="addToVault(vault.id, activeKeep.id)">Add to this vault!</button>

          <hr>
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
        // console.log(newVaultKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>