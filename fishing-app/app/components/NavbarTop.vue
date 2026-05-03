<script setup lang="ts">
import { useCartStore } from "@/stores/cart";
import { Icon } from "@iconify/vue";
const cart = useCartStore();
</script>

<template>
  <nav class="navbarTop">
    <NuxtLink to="/">
      <Icon icon="mdi:fishbowl-outline" />
      <span class="brand">Wędkarski Świat</span>
    </NuxtLink>
    <div class="search">
      <input type="text" placeholder="Search..." />
      <button>
        <Icon icon="mdi:magnify" />
      </button>
    </div>
    <NuxtLink class="navItem" to="/login">
      <Icon icon="mdi:user-circle" />
      Login</NuxtLink
    >
    <NuxtLink class="navItem" to="/contact">
      <Icon icon="mdi:phone-in-talk" />
      Kontakt</NuxtLink
    >
    <NuxtLink class="navItem" to="/cart">
      <Icon icon="mdi:shopping-cart" />
      Koszyk ({{ cart?.items?.length || 0 }})</NuxtLink
    >
  </nav>
</template>

<style scoped>
.navbarTop {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: #1a3c40;
  padding: 15px;
  font-size: 20px;
  font-weight: 750;
  /* background-image: url('rybak.jpg'); */
  background-size: cover;
  background-position: center;
}
.brand {
  letter-spacing: 3px;
}
.navItem:hover {
  color: #78c0a8;
}
a {
  color: white;
  text-decoration: none;
}
.search {
  background: rgba(255, 255, 255, 0.1);
  border: 1px solid #78c0a8;
  color: white;
  placeholder {
    color: #ccc;
  }
}
.icon {
  font-weight: 1000;
}
</style>
