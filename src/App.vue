<template>
  <div>

     <router-link to="/test">页面一</router-link>

     <router-view v-if="isRouterAlive"/>

  </div>
</template>

<script>
export default {

  provide(){
    return{
      reload: this.reload
    }
  },

  data(){
    return{
      isRouterAlive: true
    }
  },

  methods:{
    reload(){
      this.isRouterAlive = false
      this.$nextTick(() => {
        this.isRouterAlive = true
      })
    }
  }

}
</script>
