<template>
  <div>
    <h1>Data dari Backend</h1>
    <ul>
      <li v-for="item in items" :key="item.id">{{ item.name }}</li>
    </ul>
  </div>
</template>

<script>
import apiClient from '../axios';

export default {
  data() {
    return {
      items: []
    };
  },
  mounted() {
    this.fetchItems();
  },
  methods: {
    async fetchItems() {
      try {
        const response = await apiClient.get('/items'); // Gantilah dengan endpoint API Anda
        this.items = response.data;
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }
  }
};
</script>
