import { createRouter, createWebHistory } from 'vue-router'
import InstructionView from '../views/InstructionView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'instruction',
      component: InstructionView
    },
    {
      path: '/validate',
      name: 'validate',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/ValidatorView.vue')
    }
  ]
})

export default router
