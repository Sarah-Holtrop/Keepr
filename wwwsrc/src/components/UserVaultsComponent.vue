<template>
  <div class="UserVaultsComponent">
    <div class="row">
      <div class="col">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#vaultModal">
          Create Vault
        </button>
        <div class="modal fade" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="vaultModalLabel"
          aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="vaultModalLabel">New Vault</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <form @submit.prevent="createVault">
                  <input type="text" name="name" placeholder="name" v-model="newVault.name">
                  <input type="text" name="description" placeholder="description" v-model="newVault.description">
                  <button class="btn btn-success" type="submit">New Vault</button>
                </form>
              </div>
              <!-- <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div> -->
            </div>
          </div>
        </div>
      </div>
    </div>
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
      return {
        newVault: {
          name: "",
          description: ""
        }
      }
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
      },
      createVault(v) {
        let vault = {
          name: this.newVault.name,
          description: this.newVault.description
        }
        this.$store.dispatch("createVault", vault)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>