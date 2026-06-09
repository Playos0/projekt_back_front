<template>
  <Teleport to="body">
    <Transition name="fade">
      <div v-if="cart.notification" class="my-custom-notification">
        {{ cart.notification }}
      </div>
    </Transition>
  </Teleport>
</template>

<script setup lang="ts">
import { useCartStore } from '~/stores/cart'
const cart = useCartStore()
</script>

<style>
.my-custom-notification {
  position: fixed;
  bottom: 20px;
  right: 20px;
  padding: 16px 24px;
  background: #333;
  color: white;
  border-radius: 8px;
  z-index: 9999;
  font-weight: bold;
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
