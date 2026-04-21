// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  modules: ['@pinia/nuxt'],

  css: [
    'vuetify/styles',
    '@mdi/font/css/materialdesignicons.css'
  ],

  build: {
    transpile: ['vuetify']
  }
})
