<script setup lang="ts">
import { useCartStore } from "@/stores/cart";
import { Icon } from "@iconify/vue";
const cart = useCartStore();
</script>

<template>
  <nav class="navbarTop">
    <div class="leftSection">
      <NuxtLink class="navItem" to="/">
        <Icon icon="mdi:fishbowl-outline" />
        <span class="brand">Wędkarski Świat</span>
      </NuxtLink>
      <div class="search">
        <input type="text" placeholder="Wyszukaj..." />
        <button>
          <Icon icon="mdi:magnify" />
        </button>
      </div>
    </div>
    <div class="rightSection">
      <NuxtLink class="navItem" to="/login">
        <Icon icon="mdi:user-circle" />
        Login
      </NuxtLink>
      <NuxtLink class="navItem" to="/contact">
        <Icon icon="mdi:phone-in-talk" />
        Kontakt
      </NuxtLink>
      <NuxtLink class="navItem" to="/cart">
        <Icon icon="mdi:shopping-cart" />
        Koszyk ({{ cart.totalQuantity || 0 }})
      </NuxtLink>
    </div>
  </nav>
</template>

<style scoped>
.navbarTop {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-image: linear-gradient(to right, rgb(199, 128, 35), black);
  font-size: 20px;
  font-weight: 750;
  height: 100px;
}
.leftSection {
  display: flex;
  align-items: center;
  height: 100%;
  padding: 30px;
  background-image: url('~/components/rybakNav.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 0 30px 30px 0;
  gap: 50px;
}
.rightSection {
  height: 100%;
  width: 600px;
  flex: 1;
  display: flex;
  justify-content: space-evenly;
  align-items: center;
}
.brand {
  letter-spacing: 3px;
  font-size: 30px;
}
.navItem {
  display: flex;
  align-items: center;
  transition: color 0.3s;
}
.navItem:hover {
  color: orange;
}
a {
  color: white;
  text-decoration: none;
}
.search {
  border: 1px solid orange;
  background-color: rgba(17, 20, 19, 0.5);
  display: flex;
}
input {
  background: transparent;
  border: none;
  color: white;
  padding: 10px;
  outline: none;
}
input::placeholder {
  color: rgba(255, 255, 255, 0.7);
}
button {
  background: transparent;
  color: white;
  cursor: pointer;
  border: none;
  padding: 10px;
}
.navItem svg {
  margin-right: 5px;
  width: 30px;
  height: 30px;
  color: orange;
}
</style>
