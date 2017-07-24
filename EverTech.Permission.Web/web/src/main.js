import babelpolyfill from 'babel-polyfill'
import Vue from 'vue'
import App from './App'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-default/index.css'
import VueRouter from 'vue-router'
import store from './vuex/store'
import Vuex from 'vuex'
import VueResource from 'vue-resource'
import NProgress from 'nprogress'//页面顶部进度条
import 'nprogress/nprogress.css'

import Login from './components/Login.vue'
import Home from './components/Home.vue'
import Main from './components/Main.vue'
import Table from './components/nav1/Table.vue'
import Form from './components/nav1/Form.vue'
import Page3 from './components/nav1/Page3.vue'
import Page4 from './components/nav2/Page4.vue'
import Page5 from './components/nav2/Page5.vue'
import Page6 from './components/nav3/Page6.vue'
import echarts from './components/charts/echarts.vue'

Vue.use(ElementUI)
Vue.use(VueRouter)
Vue.use(Vuex)
Vue.use(VueResource)

const routes = [
  {
    path: '/login',
    component: Login,
    hidden: true//不显示在导航中
  },
  //{ path: '/main', component: Main },
  {
    path: '/',
    component: Home,
    name: '用户管理',
    iconCls: 'fa fa-user-o',//图标样式class
    children: [
      //{ path: '/main', component: Main },
      { path: '/table', component: Table, name: '用户列表' },
      { path: '/form', component: Form, name: '创建用户' },
      { path: '/page3', component: Page3, name: '配置用户角色' },
      { path: '/page3', component: Page3, name: '配置用户区域' },
    ]
  },
  {
    path: '/',
    component: Home,
    name: '角色管理',
    iconCls: 'fa fa-users',
    children: [
      { path: '/page4', component: Page4, name: '角色列表' },
      { path: '/page5', component: Page5, name: '创建角色' },
      { path: '/page55', component: Page5, name: '配置角色权限' }
    ]
  },
  {
    path: '/',
    component: Home,
    name: '权限管理',
    iconCls: 'fa fa-street-view',
    //leaf: true,//只有一个节点
    children: [
      { path: '/page6', component: Page6, name: '菜单权限' },
      { path: '/page66', component: Page6, name: '按钮权限' },
      { path: '/page666', component: Page6, name: '功能权限' },
      { path: '/page666', component: Page6, name: '特殊权限' },
    ]
  },
  {
    path: '/',
    component: Home,
    name: '区域管理',
    iconCls: 'fa fa-map-o',
    children: [
      { path: '/echarts', component: echarts, name: '行政城市' },
      { path: '/echarts', component: echarts, name: '城市分组' },
    ]
  },
  {
    path: '/',
    component: Home,
    name: '接口管理',
    iconCls: 'fa fa-plug',
    children: [
      { path: '/echarts', component: echarts, name: '用户接口' }
    ]
  },
  {
    path: '/',
    component: Home,
    name: '系统管理',
    iconCls: 'fa fa-cog',
    children: [
      { path: '/echarts', component: echarts, name: '字典管理' },
      { path: '/echarts', component: echarts, name: '修改密码' },
      { path: '/echarts', component: echarts, name: '系统配置' },
    ]
  }

]

const router = new VueRouter({
  routes
})

router.beforeEach((to, from, next) => {
  NProgress.start();
  next()
})

router.afterEach(transition => {
  NProgress.done();
});

new Vue({
  el: '#app',
  template: '<App/>',
  router,
  store,
  components: { App }
  //render: h => h(Login)
}).$mount('#app') 

//router.replace('/login')

