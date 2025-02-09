<script setup>
import { ref, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import axios from '../axios';
import { useToast } from 'vue-toastification';

const route = useRoute();
const router = useRouter(); // Mengimpor useRouter untuk navigasi
const toast = useToast();

const workTaskId = route.params.id; // Mengambil ID WorkTask dari URL
const task = ref(null);

const fetchTask = async () => {
  try {
    const response = await axios.get(`/WorkTasks/${workTaskId}`);
    task.value = response.data;
  } catch (error) {
    console.error('Error fetching task:', error);
    toast.error('Failed to load task data.');
  }
};

const pauseTask = async () => {
  try {
    await axios.put(`/WorkTasks/${workTaskId}/pause`); // Menggunakan PUT
    toast.success('Task paused successfully.');
    await fetchTask(); // Refresh data task
  } catch (error) {
    console.error('Error pausing task:', error);
    toast.error('Failed to pause task.');
  }
};

const cancelTask = async () => {
  try {
    await axios.put(`/WorkTasks/${workTaskId}/cancel`); // Menggunakan PUT
    toast.success('Task cancelled successfully.');
    await fetchTask(); // Refresh data task
  } catch (error) {
    console.error('Error cancelling task:', error);
    toast.error('Failed to cancel task.');
  }
};

const completeTask = async () => {
  try {
    await axios.put(`/WorkTasks/${workTaskId}/complete`); // Menggunakan PUT
    toast.success('Task completed successfully.');
    await fetchTask(); // Refresh data task
  } catch (error) {
    console.error('Error completing task:', error);
    toast.error('Failed to complete task.');
  }
};

// Function to navigate back to view-task
const goToViewTask = () => {
  router.push('/view-task');
};

onMounted(fetchTask);
</script>

<template>
  <div class="action-task" v-if="task">
    <h1>{{ task.workTaskName }}</h1>
    <button @click="goToViewTask" class="view-task-button">Go to View Task</button>
    <div class="task-info">
      <p><strong>Status:</strong> {{ task.workTaskStatusCode }}</p>
      <p><strong>Due Date:</strong> {{ formatDate(task.dueDate) }}</p>
      <p><strong>Instruction:</strong> {{ task.instruction }}</p>
      <p><strong>Attachment:</strong> <a :href="task.attachment" target="_blank">{{ task.attachment }}</a></p>
      <!-- Tampilkan label Overdue jika dueDate telah lewat -->
      <p v-if="isOverdue(task.dueDate)" class="overdue-label">Overdue</p>
    </div>
    <div class="task-actions">
      <button @click="pauseTask">Pause</button>
      <button @click="cancelTask">Cancel</button>
      <button @click="completeTask">Complete</button>
    </div>
  </div>
  <div v-else>
    <p>Loading task data...</p>
  </div>
</template>

<script>
export default {
  name: 'ActionTask',
  methods: {
    formatDate(dateStr) {
      const date = new Date(dateStr);
      return date.toLocaleDateString();
    },
    isOverdue(dueDate) {
      const due = new Date(dueDate);
      const now = new Date();
      return due < now;
    },
  },
};
</script>

<style scoped>
.action-task {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

.task-info {
  margin-bottom: 20px;
}

.task-info p {
  font-size: 16px;
  margin: 5px 0;
}

.overdue-label {
  color: red;
  font-weight: bold;
}

.task-actions button {
  margin-right: 10px;
  padding: 10px 20px;
  border: none;
  background-color: #4caf50;
  color: white;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.task-actions button:hover {
  background-color: #45a049;
}

.task-actions button:nth-child(2) {
  background-color: #f44336;
}

.task-actions button:nth-child(2):hover {
  background-color: #e53935;
}

.view-task-button {
  margin-bottom: 20px;
  padding: 10px 20px;
  border: none;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s;
}

.view-task-button:hover {
  background-color: #0056b3;
}
</style>
