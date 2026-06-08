<script setup lang="ts">
import { Icon } from "@iconify/vue";
</script>

<template>
  <nav class="navbarBottom">
    <NuxtLink class="navItem" to="/shop">
      <Icon class="navItem" icon="mdi:storefront-outline" />
      Sklep</NuxtLink>
    <NuxtLink class="navItem" to="/fishing-grounds">
      <Icon icon="lucide-lab:pond" />
      Łowiska</NuxtLink
    >
    <NuxtLink class="navItem" to="/boats">
      <Icon icon="mdi:sail-boat" />
      Łódki</NuxtLink
    >
    <NuxtLink class="navItem" to="/subscriptions">
      <Icon icon="mdi:subscriptions" />
      Subskrypcje</NuxtLink
    >
  </nav>
</template>

<style scoped>
.navbarBottom {
  background-color: #353535;
  display: flex;
  justify-content: space-around;
  align-items: center;
  gap: 20px;
  padding: 10px 20px;
  z-index: 1000;
  position: sticky;
  height: 70px;
}
a {
  color: #f1f1f1;
  text-decoration: none;
  font-size: 20px;
  transition: color 0.3s;
}
a:hover {
  color: orange;
}
.navItem svg {
  margin-right: 5px;
  width: 20px;
  height: 20px;
  color: orange;
}
</style>
