<script setup>
import { ref, onMounted } from 'vue';
import apiClient from '../axios';
import { useToast } from 'vue-toastification';
import { useRouter } from 'vue-router';

const toast = useToast();
const router = useRouter(); // Mengimpor useRouter untuk navigasi
const farmFields = ref([]);

// Fetch Farm Fields from API
const fetchFarmFields = async () => {
  try {
    const response = await apiClient.get('/FarmFields');
    farmFields.value = response.data;
  } catch (error) {
    console.error('Error fetching Farm Fields:', error);
    toast.error('Failed to load Farm Fields.');
  }
};

// Call fetchFarmFields on component mount
onMounted(fetchFarmFields);

// Function to navigate back to dashboard
const goToDashboard = () => {
  router.push('/');
};
</script>

<template>
  <div class="view-farmfield">
    <h1>View Farm Fields</h1>
    <button @click="goToDashboard" class="dashboard-button">Go to Dashboard</button>
    <table>
      <thead>
      <tr>
        <th>Farm Field ID</th>
        <th>Farm Site ID</th>
        <th>Farm Field Name</th>
        <th>Farm Field Code</th>
        <th>Row Width</th>
        <th>Row Direction</th>
        <th>Color Hex Code</th>
        <th>Created Date</th>
        <th>Modified Date</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="field in farmFields" :key="field.farmFieldId">
        <td>{{ field.farmFieldId }}</td>
        <td>{{ field.farmSiteId }}</td>
        <td>{{ field.farmFieldName }}</td>
        <td>{{ field.farmFieldCode }}</td>
        <td>{{ field.rowWidth }}</td>
        <td>{{ field.farmFieldRowDirection }}</td>
        <td>{{ field.farmFieldColorHexCode }}</td>
        <td>{{ new Date(field.createdDate).toLocaleString() }}</td>
        <td>{{ new Date(field.modifiedDate).toLocaleString() }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.view-farmfield {
  max-width: 1000px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th, td {
  padding: 10px;
  border: 1px solid #ddd;
}

th {
  background-color: #f4f4f4;
}

td {
  text-align: left;
}

.dashboard-button {
  margin-bottom: 20px;
  padding: 10px 20px;
  border: none;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.dashboard-button:hover {
  background-color: #0056b3;
}
</style>
