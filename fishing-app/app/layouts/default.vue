<script setup lang="ts">
import Navbar from '~/components/Navbar.vue'
</script>
<template>
  <div>
    <Navbar />
    <main>
      <slot />
    </main>
    <AppFooter />
  </div>
</template>
