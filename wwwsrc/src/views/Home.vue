<template>
  <div>
    <div class="home">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
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
    // mounted() {
    //   this.$store.dispatch("getAllKeeps")
    // },
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
      }
    },
    components: {
      UserVaultsComponent
    }
  };
</script>