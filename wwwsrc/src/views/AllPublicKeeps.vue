<template>
  <div class="AllPublicKeeps">
    <h1>All Keeps</h1>
    <div class="row">
      <div class="col-4" v-for="keep in publicKeeps">
        <div class="card">
          <div class="card-header">
            <h4>{{keep.name}}</h4>
          </div>
          <div class="card-body">
            <img :src="keep.img" alt="vague image" class="img-thumbnail">
          </div>
          <div class="card-footer">
            <p>views: {{keep.views}} || keeps: {{keep.keeps}} || shares: {{keep.shares}}</p>
            <!-- <button @click="deleteKeep(uk)" class="btn btn-danger">Delete keep</button> -->
            <button @click="viewKeep(keep)" class="btn btn-info">View Keep</button>
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
    name: 'AllPublicKeeps',
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    data() {
      return {}
    },
    computed: {
      publicKeeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      viewKeep(keep) {
        this.$store.dispatch("viewKeep", keep)
        this.$router.push({ name: "ActiveKeep", params: { kId: keep.id } })
      },
    },
    components: {}
  }
</script>


<style scoped>

</style>