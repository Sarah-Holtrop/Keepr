<template>
  <div>
    <div class="home">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
      <form @submit.prevent="createVault">
        <input type="text" name="name" placeholder="name" v-model="newVault.name">
        <input type="text" name="description" placeholder="description" v-model="newVault.description">
        <button class="btn btn-success" type="submit">New Vault</button>
      </form>
    </div>
    <div class="row">
      <div class="col">
        <!-- will be v-for -->
        <UserVaultsComponent></UserVaultsComponent>
      </div>
    </div>
  </div>
</template>

<script>
  import UserVaultsComponent from '../components/UserVaultsComponent.vue'

  export default {
    name: "home",
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    mounted() {
      this.$store.dispatch("getVaultsByUserId")
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
      createVault(v) {
        let vault = {
          name: this.newVault.name,
          description: this.newVault.description
        }
        this.$store.dispatch("createVault", vault)
      }
    },
    components: {
      UserVaultsComponent
    }
  };
</script>