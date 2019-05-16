import Vue from 'vue'
import Router from 'vue-router'

const Test = ()=>import('@/components/Test')


Vue.use(Router)

const router =  new Router({

  mode: 'history',

  routes: [
    {
      path: '/test',
      component: Test
    }
  ]
})

router.beforeEach((to, from, next) =>{
  if(to.meta.requireAuth){
    next()
  }else{
    next()
  }
})

export default router
