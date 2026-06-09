import { defineStore } from 'pinia';

export interface CartItem {
  id: number;
  name: string;
  price: number;
  image?: string;
  quantity: number; 
}

export const useCartStore = defineStore('cart', {
  state: () => ({
    items: [] as CartItem[],
    notification: null as string | null
  }),

  actions: {
    addItem(product: any, quantity: number = 1) {
      const existingItem = this.items.find(item => item.id === product.id);
      if (existingItem) {
        existingItem.quantity += quantity;
      } else {
        this.items.push({ ...product, quantity: quantity });
      }
      this.notification = `Dodano: ${product.name} do koszyka!`;
      setTimeout(() => this.notification = null, 2000);
    },
    
    removeItem(itemId: number) {
      this.items = this.items.filter(item => item.id !== itemId);
    }
  },
  
  getters: {
    totalPrice: (state) => {
      return state.items.reduce((total, item) => total + (item.price * item.quantity), 0);
    },
    totalQuantity: (state) => {
      return state.items.reduce((total, item) => total + item.quantity, 0);
    }
  }
});
