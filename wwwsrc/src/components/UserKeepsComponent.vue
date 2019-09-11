<template>
  <div class="userKeep">
    <div class="row">
      <div class="col">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#keepModal">
          Create Keep
        </button>
        <div class="modal fade" id="keepModal" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel"
          aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="keepModalLabel">New Keep</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <form @submit.prevent="addKeep(newKeep)">
                  <input type="text" name="name" placeholder="keep name" v-model="newKeep.name">
                  <input type="text" name="description" placeholder="keep description" v-model="newKeep.description">
                  <input type="text" name="img" placeholder="image url" v-model="newKeep.img">
                  <label for="isPrivate">Is this a public keep?</label>
                  <input type="radio" name="isPrivate" :value="false" v-model="newKeep.isPrivate" checked>yes
                  <input type="radio" name="isPrivate" :value="true" v-model="newKeep.isPrivate">no

                </form>
              </div>
              <div class="modal-footer">
                <button class="btn btn-success" type="submit">New Keep</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
        <!-- #### -->
      </div>
    </div>
    <div class="row">
      <div class="col-4" v-for="uk in userKeeps">
        <div class="card">
          <div class="card-header">
            <h4>{{uk.name}}</h4>
          </div>
          <div class="card-body">
            <img :src="uk.img" alt="vague image" class="img-thumbnail">
          </div>
          <div class="card-footer">
            <p>views: {{uk.views}} || keeps: {{uk.keeps}} || shares: {{uk.shares}}</p>
            <button @click="deleteKeep(uk)" class="btn btn-danger">Delete keep</button>
            <button @click="viewKeep(uk)" class="btn btn-info">View Keep</button>
          </div>
        </div>
      </div>
    </div>


  </div>
</template>


<script>
  export default {
    name: 'userKeep',
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: false
        }
      }
    },
    // TODO I saved a public keep that someone else made, I should be able to see it in my keeps
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      },

    },
    methods: {
      viewKeep(keep) {
        this.$store.dispatch("viewKeep", keep)
        this.$router.push({ name: "ActiveKeep", params: { kId: keep.id } })
      },
      deleteKeep(keep) {
        // debugger
        this.$store.dispatch("deleteKeep", keep.id)
      },
      addKeep(newKeep) {
        this.$store.dispatch("addKeep", newKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>
  .card {
    width: 20rem;

  }

  /* img {
    height: 150px;
    width: 150px;
  } */
</style>