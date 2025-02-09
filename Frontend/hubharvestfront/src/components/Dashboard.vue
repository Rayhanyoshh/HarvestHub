<script setup>
import { defineComponent } from 'vue';

defineComponent({
  name: 'dashboardPage'
});
</script>
<template>
  <div class="dashboard">
    <h1>Welcome to Harvest Hub</h1>
    <div class="navigation">
      <router-link to="/createnewTask" class="nav-link">Create New Task</router-link>
      <router-link to="/view-task" class="nav-link">View Task</router-link>
      <router-link to="/create-farmfield" class="nav-link">Create FarmField</router-link>
      <router-link to="/view-farmfield" class="nav-link">View FarmField</router-link>
      <router-link to="/login" class="nav-link">Login</router-link>
    </div>
  </div>
</template>

<style scoped>
.dashboard {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

.navigation {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.nav-link {
  display: block;
  margin: 10px 0;
  padding: 10px 20px;
  border: 1px solid #ccc;
  border-radius: 4px;
  text-decoration: none;
  color: #333;
  transition: background-color 0.3s, color 0.3s;
}

.nav-link:hover {
  background-color: #f0f0f0;
  color: #000;
}
</style>
