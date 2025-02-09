<script setup>
import {ref, onMounted} from 'vue';
import axios from '../axios';
import {useRouter} from 'vue-router';

// Definisikan data dan fungsi
const tasks = ref([]);
const router = useRouter();

const fetchTasks = async () => {
  try {
    const response = await axios.get('/WorkTasks');
    tasks.value = response.data;
  } catch (error) {
    console.error('Error fetching tasks:', error);
  }
};

// Panggil fetchTasks saat komponen dipasang
onMounted(fetchTasks);

const viewActions = (taskId) => {
  router.push(`/action-task/${taskId}`);
};

// Function to navigate back to dashboard
const goToDashboard = () => {
  router.push('/');
};
</script>

<template>
  <div class="view-task">
    <h1>View Task</h1>
    <button @click="goToDashboard" class="dashboard-button">Go to Dashboard</button>
    <table>
      <thead>
      <tr>
        <th>Task Name</th>
        <th>Type</th>
        <th>Status</th>
        <th>Due Date</th>
        <th>Instruction</th>
        <th>Attachment</th>
        <th>Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="task in tasks" :key="task.workTaskId">
        <td>{{ task.workTaskName }}</td>
        <td>{{ task.workTaskTypeCode }}</td>
        <td>{{ task.workTaskStatusCode }}</td>
        <td>{{ new Date(task.dueDate).toLocaleDateString() }}</td>
        <td>{{ task.instruction }}</td>
        <td>
          <a :href="task.attachment" target="_blank">{{ task.attachment }}</a>
        </td>
        <td>
          <button @click="viewActions(task.workTaskId)">View Actions</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.view-task {
  max-width: 800px;
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

button {
  padding: 5px 10px;
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

a {
  text-decoration: none;
  color: #1a73e8;
}

a:hover {
  text-decoration: underline;
}
</style>
