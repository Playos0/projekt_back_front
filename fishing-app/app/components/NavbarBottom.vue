<script setup lang="ts">
import { Icon } from "@iconify/vue";
</script>

<template>
  <nav class="navbarBottom">
    <div class="menu">
      <Icon class="navItem" icon="mdi:storefront-outline" />
      Sklep
      <Icon icon="mdi:chevron-down" />
      <div class="dropdown">
        <NuxtLink class="navItem" to="/rods">Wędki</NuxtLink>
        <NuxtLink class="navItem" to="/reels">Kołowrotki</NuxtLink>
        <NuxtLink class="navItem" to="/lures">Przynęty</NuxtLink>
        <NuxtLink class="navItem" to="/accessories">Akcesoria</NuxtLink>
      </div>
    </div>
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
.menu {
  position: relative;
  cursor: pointer;
  padding: 10px 0;
}
.menu:hover {
  color: orange;
}
.menu svg {
  font-size: 20px;
  margin-right: 5px;
  width: 20px;
  height: 20px;
  color: orange;
}

.dropdown {
  position: absolute;
  background-color: #353535;
  padding: 10px;
  border-radius: 5px;
  min-width: 150px;
  flex-direction: column;
  opacity: 0;
  transform: translateY(-10px);
  transition: all 0.2s ease;
}
.dropdown a {
  display: block;
  padding: 5px 0;
}

.menu:hover .dropdown {
  opacity: 1;
  transform: translateY(0);
}
.navItem svg {
  margin-right: 5px;
  width: 20px;
  height: 20px;
  color: orange;
}
</style>
