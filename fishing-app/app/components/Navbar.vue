<template>
  <nav class="navbar">
    <NuxtLink to="/">
      <div class="logo">
        <span class="icon">🎣</span>
        <span class="brand">Wędkarski Świat</span>
      </div>
    </NuxtLink>
    <NuxtLink class="navItem" to="/login">Login</NuxtLink>
    <NuxtLink class="navItem" to="/shop">Shop</NuxtLink>
    <NuxtLink class="navItem" to="/fishing-grounds">Fishing Grounds</NuxtLink>
    <NuxtLink class="navItem" to="/cart">Cart ({{ cart?.items?.length || 0 }})</NuxtLink>
  </nav>
</template>

<script setup lang="ts">
import { useCartStore } from "@/stores/cart";
const cart = useCartStore();
</script>
<style scoped>
.navbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: linear-gradient(90deg, #1a3c40 0%, #112a2d 100%);
  padding: 15px 30px;
  position: relative;
  font-size: 1.1rem;
  font-weight: 500;
}
.logo {
  display: flex;
  align-items: center;
  gap: 10px;
  font-size: 1.5rem;
  font-weight: bold;
  color: #f4f1de;
  cursor: pointer;
}
.brand {
  letter-spacing: 3px;
}
.navItem:hover {
  color: #78C0A8;
}
a {
  color: white;
  text-decoration: none;
}
</style>
