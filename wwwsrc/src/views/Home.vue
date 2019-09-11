<template>
  <div>
    <div class="home">
      <div class="row">
        <div class="col">
          <h1>Welcome Home {{user.username}}</h1>
          <button class="btn btn-danger" v-if="user.id" @click="logout">logout</button>
          <router-link v-else :to="{name: 'login'}">Login</router-link>
          <div class="row justify-content-center">
            <router-link :to="{name: 'AllPublicKeeps'}">Browse All Keeps</router-link>
          </div>
          <!-- <div class="row justify-content-center"> -->
          <!-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
              Create Vault
            </button>
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
              aria-hidden="true">
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">New Keep</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <form @submit.prevent="createVault">
                      <input type="text" name="name" placeholder="name" v-model="newVault.name">
                      <input type="text" name="description" placeholder="description" v-model="newVault.description">
                    </form>
                  </div>
                  <div class="modal-footer">
                    <button class="btn btn-success" type="submit">New Vault</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                  </div>
                </div>
              </div>
            </div> -->
          <!-- </div> -->
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <!-- will be v-for -->
        <h3>Your Vaults:</h3>
        <UserVaultsComponent></UserVaultsComponent>
        <h3>Your Keeps:</h3>
        <UserKeepsComponent></UserKeepsComponent>
      </div>
    </div>
  </div>
</template>

<script>
  import UserVaultsComponent from '../components/UserVaultsComponent.vue'
  import UserKeepsComponent from '../components/UserKeepsComponent.vue'

  export default {
    name: "home",
    data() {
      return {
        // newVault: {
        //   name: "",
        //   description: ""
        // }
      }
    },
    mounted() {
      this.$store.dispatch("getVaultsByUserId");
      this.$store.dispatch("getKeepsByUserId")
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      // createVault(v) {
      //   let vault = {
      //     name: this.newVault.name,
      //     description: this.newVault.description
      //   }
      //   this.$store.dispatch("createVault", vault)
      // }
    },
    components: {
      UserVaultsComponent,
      UserKeepsComponent
    }
  };
</script>