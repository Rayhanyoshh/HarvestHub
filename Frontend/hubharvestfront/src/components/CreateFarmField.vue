<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import apiClient from '../axios';
import { useToast } from 'vue-toastification';

const toast = useToast();
const router = useRouter(); // Mengimpor useRouter untuk navigasi

// Define form fields
const farmSiteId = ref(null);
const farmFieldName = ref('');
const location = ref('');
const rowWidth = ref(0);
const farmFieldColorHexCode = ref('#00FF00');
const farmFieldRowDirection = ref('');
const primaryCropId = ref(null);
const farmSites = ref([]);
const crops = ref([]);

// Fetch FarmSites and Crops from API
const fetchFarmSitesAndCrops = async () => {
  try {
    const farmSitesResponse = await apiClient.get('/FarmSites');
    farmSites.value = farmSitesResponse.data;

    const cropsResponse = await apiClient.get('/Crops');
    crops.value = cropsResponse.data;
  } catch (error) {
    console.error('Error fetching Farm Sites or Crops:', error);
    toast.error('Failed to load Farm Sites or Crops.');
  }
};

// Call fetchFarmSitesAndCrops on component mount
onMounted(fetchFarmSitesAndCrops);

const createFarmField = async () => {
  const farmFieldData = {
    farmSiteId: farmSiteId.value,
    farmFieldName: farmFieldName.value,
    location: location.value,
    rowWidth: rowWidth.value,
    farmFieldColorHexCode: farmFieldColorHexCode.value,
    farmFieldRowDirection: farmFieldRowDirection.value,
    primaryCropId: primaryCropId.value,
  };

  try {
    await apiClient.post('/FarmFields', farmFieldData);
    toast.success('Farm Field created successfully.');
    // Reset form fields
    farmSiteId.value = null;
    farmFieldName.value = '';
    location.value = '';
    rowWidth.value = 0;
    farmFieldColorHexCode.value = '#00FF00';
    farmFieldRowDirection.value = '';
    primaryCropId.value = null;
  } catch (error) {
    console.error('Error creating Farm Field:', error);
    toast.error('Failed to create Farm Field.');
  }
};

// Function to navigate back to dashboard
const goToDashboard = () => {
  router.push('/');
};
</script>

<template>
  <div class="create-farmfield">
    <h1>Create New FarmField</h1>
    <button @click="goToDashboard" class="dashboard-button">Go to Dashboard</button>
    <form @submit.prevent="createFarmField">
      <div class="form-group">
        <label for="farmSiteId">Farm Site</label>
        <select id="farmSiteId" v-model="farmSiteId" required>
          <option v-for="site in farmSites" :key="site.farmSiteId" :value="site.farmSiteId">
            {{ site.farmSiteName }}
          </option>
        </select>
      </div>
      <div class="form-group">
        <label for="farmFieldName">Farm Field Name</label>
        <input type="text" id="farmFieldName" v-model="farmFieldName" required/>
      </div>
      <div class="form-group">
        <label for="location">Location</label>
        <input type="text" id="location" v-model="location" required/>
      </div>
      <div class="form-group">
        <label for="rowWidth">Row Width (in acres)</label>
        <input type="number" step="0.01" id="rowWidth" v-model="rowWidth" required/>
      </div>
      <div class="form-group">
        <label for="farmFieldColorHexCode">Color Hex Code</label>
        <input type="color" id="farmFieldColorHexCode" v-model="farmFieldColorHexCode" required/>
        <input type="text" v-model="farmFieldColorHexCode" readonly />
      </div>
      <div class="form-group">
        <label for="farmFieldRowDirection">Row Direction</label>
        <input type="text" id="farmFieldRowDirection" v-model="farmFieldRowDirection" required/>
      </div>
      <div class="form-group">
        <label for="primaryCropId">Primary Crop</label>
        <select id="primaryCropId" v-model="primaryCropId" required>
          <option v-for="crop in crops" :key="crop.cropId" :value="crop.cropId">
            {{ crop.cropCode }}
          </option>
        </select>
      </div>
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<style scoped>
.create-farmfield {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  margin-bottom: 5px;
}

.form-group input,
.form-group select {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
  margin-top: 5px;
}

button {
  padding: 10px 20px;
  border: none;
  background-color: #4caf50;
  color: white;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #45a049;
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
