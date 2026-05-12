import {defineStore} from 'pinia';

export const useCartStore = defineStore('cart', {
    state: () => ({
        items: [] as { id: number; name: string; price: number }[]
    }),

    actions: {
        addItem(item: { id: number; name: string; price: number }) {
            this.items.push(item);
        },
        removeItem(itemId: number) {
            this.items = this.items.filter(item => item.id !== itemId);
        }
    },
    getters: {
        totalPrice: (state) => {
            return state.items.reduce((total, item) => total + item.price, 0);
        }
    }
});

