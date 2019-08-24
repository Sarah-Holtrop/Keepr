<template>
  <div>
    <div class="home">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </div>
  </div>
</template>

<script>

  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getAllKeeps")
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

    }
  };
</script>