<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import apiClient from '../axios';
import { useToast } from 'vue-toastification';

const toast = useToast();
const router = useRouter(); // Mengimpor useRouter untuk navigasi

// Define form fields
const workTaskTypes = ref([]);
const farmFields = ref([]);
const selectedFarmFieldId = ref(null);
const selectedTaskTypeCode = ref('');
const taskName = ref('');
const dueDate = ref('');
const instruction = ref('');
const attachment = ref(''); // Hanya menyimpan nama file

// Fetch WorkTaskTypes dan FarmFields dari API
const fetchWorkTaskTypesAndFarmFields = async () => {
  try {
    const workTaskTypesResponse = await apiClient.get('/WorkTaskTypes');
    workTaskTypes.value = workTaskTypesResponse.data;

    const farmFieldsResponse = await apiClient.get('/FarmFields');
    farmFields.value = farmFieldsResponse.data;
  } catch (error) {
    console.error('Error fetching work task types or farm fields:', error);
    toast.error('Failed to load Work Task Types or Farm Fields.');
  }
};

// Panggil fetchWorkTaskTypesAndFarmFields saat komponen dipasang
onMounted(fetchWorkTaskTypesAndFarmFields);

const handleFileUpload = (event) => {
  const file = event.target.files[0];
  if (file) {
    attachment.value = file.name; // Simpan hanya nama file
  }
};

const saveTask = async () => {
  try {
    const taskData = {
      farmFieldId: selectedFarmFieldId.value,
      workTaskTypeCode: selectedTaskTypeCode.value,
      dueDate: new Date(dueDate.value).toISOString(),
      instruction: instruction.value,
      workTaskName: taskName.value,
      attachment: attachment.value // Hanya mengirim nama file
    };

    // Simpan field yang kosong untuk ditampilkan dalam pesan error
    let missingFields = [];

    if (!selectedFarmFieldId.value) missingFields.push('Farm Field');
    if (!selectedTaskTypeCode.value) missingFields.push('Work Task Type');
    if (!dueDate.value) missingFields.push('Due Date');
    if (!taskName.value) missingFields.push('Task Name');
    if (!instruction.value) missingFields.push('Instruction');

    // Jika ada field yang kosong, tampilkan pesan error
    if (missingFields.length > 0) {
      toast.error(`Please fill in: ${missingFields.join(', ')}`);
      return;
    }

    const response = await apiClient.post('/WorkTasks', taskData);
    console.log('Task saved successfully:', response.data)
    toast.success('Task saved successfully!');
    // Reset form setelah berhasil menyimpan
    selectedFarmFieldId.value = '';
    selectedTaskTypeCode.value = '';
    dueDate.value = '';
    instruction.value = '';
    taskName.value = '';
    attachment.value = '';
  } catch (error) {
    console.error('Error saving task:', error);
    toast.error('Failed to save task.');
  }
};

// Function to navigate back to dashboard
const goToDashboard = () => {
  router.push('/');
};
</script>

<template>
  <div class="task-form">
    <h2 class="task-form__title">Create a Task</h2>
    <button @click="goToDashboard" class="dashboard-button">Go to Dashboard</button>
    <div class="task-form__field">
      <label for="taskType" class="task-form__label">Select Task Type</label>
      <select id="taskType" v-model="selectedTaskTypeCode" class="task-form__select">
        <option v-for="type in workTaskTypes" :key="type.id" :value="type.workTaskTypeCode">
          {{ type.workTaskTypeCode }}
        </option>
      </select>
    </div>
    <div class="task-form__field">
      <label for="field" class="task-form__label">Field</label>
      <select id="field" v-model="selectedFarmFieldId" class="task-form__select">
        <option v-for="field in farmFields" :key="field.id" :value="field.farmFieldId">
          {{ field.farmFieldName }}
        </option>
      </select>
    </div>
    <div class="task-form__field">
      <label for="taskName" class="task-form__label">Task Name</label>
      <input type="text" id="taskName" v-model="taskName" class="task-form__input" />
    </div>
    <div class="task-form__field">
      <label for="dueDate" class="task-form__label">Due Date</label>
      <input type="datetime-local" id="dueDate" v-model="dueDate" class="task-form__input" />
    </div>
    <div class="task-form__field">
      <label for="instruction" class="task-form__label">Instruction</label>
      <textarea id="instruction" v-model="instruction" class="task-form__textarea"></textarea>
    </div>
    <div class="task-form__field">
      <label for="attachments" class="task-form__label">Attachments</label>
      <input type="file" id="attachments" @change="handleFileUpload" class="task-form__input" />
    </div>
    <div class="task-form__buttons">
      <button class="task-form__button" @click="$emit('cancel')">Cancel</button>
      <button class="task-form__button" @click="saveTask">Save</button>
    </div>
  </div>
</template>

<style scoped>
.task-form {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 4px;
  background-color: #f9f9f9;
}
.task-form__title {
  text-align: center;
  margin-bottom: 20px;
}
.task-form__field {
  margin-bottom: 15px;
}
.task-form__label {
  display: block;
  margin-bottom: 5px;
}
.task-form__input,
.task-form__select,
.task-form__textarea {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
.task-form__textarea {
  height: 100px;
}
.task-form__buttons {
  display: flex;
  justify-content: space-between;
}
.task-form__button {
  padding: 10px 15px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
.task-form__button:hover {
  background-color: #e0e0e0;
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
