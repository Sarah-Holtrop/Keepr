<template>
  <div class="vaultKeep">
    <div class="row">
      <div class="col" v-for="vk in vaultKeeps">
        <div class="card">
          <div class="card-header">
            <h4>{{vk.name}}</h4>
          </div>
          <div class="card-body">
            <img :src="vk.img" alt="vague image" class="thumbnail">
          </div>
          <div class="card-footer">
            <p>views: {{vk.views}} || keeps: {{vk.keeps}} || shares: {{vk.shares}}</p>
            <button class="btn btn-danger">Remove from Vault</button>
            <!-- TODO remove from vault method -->
          </div>
        </div>
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