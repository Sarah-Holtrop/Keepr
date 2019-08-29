<template>
  <div class="vaultKeep">
    <div class="row">
      <!-- <div v-for="vkd in vaultKeepDatas"> -->
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
            <button @click="removeFromVault(vk)" class="btn btn-danger">Remove from
              Vault</button>
            <!-- TODO remove from vault method, NOT a delete method(maybe try a delete to make sure my auth works) -->
          </div>
        </div>
      </div>
      <!-- </div> -->
    </div>


  </div>
</template>


<script>
  export default {
    name: 'vaultKeep',
    mounted() {
      this.$store.dispatch('getVaultKeepDatas', this.$route.params.vId);
      // this.$store.dispatch('getKeepsByVaultId', this.$route.params.vId)
    },
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },
      vault() {
        return this.$store.state.activeVault
      },
      vaultKeepDatas() {
        return this.$store.state.vaultKeepDatas
      }
    },
    methods: {
      removeFromVault(keep) {
        // debugger
        let vaultKeep = {
          vaultId: this.$route.params.vId,
          keepId: keep.id
        }
        // console.log(vaultKeep)
        this.$store.dispatch("removeFromVault", vaultKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>