<template>
  <div class="HomeKeepsComponent">
    <div class="row">
      <div class="col" v-for="keep in keeps">
        <h4>{{keep.name}}</h4>
        <img class="image" :src="keep.img" alt="sharkos?">
      </div>
    </div>

  </div>
</template>


<script>
  import HomeKeepsComponent from '../components/HomeKeepsComponent.vue'

  export default {
    name: 'HomeKeepsComponent',
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    data() {
      return {}
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>
  .image {
    height: 250px;
    width: 250px
  }
</style>