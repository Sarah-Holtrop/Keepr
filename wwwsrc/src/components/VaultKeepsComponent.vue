<template>
  <div class="vaultKeep">
    <div class="row">
      <div class="col" v-for="vk in vaultKeeps">
        <h4>{{vk.name}}</h4>
        <img :src="vk.img" alt="vague image">
        <p>{{vk.views}}</p>
      </div>
    </div>


  </div>
</template>


<script>
  export default {
    name: 'vaultKeep',
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>