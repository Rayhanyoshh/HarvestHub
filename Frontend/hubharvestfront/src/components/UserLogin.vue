<template>
  <div class="login">
    <h1>User Login</h1>
    <form @submit.prevent="login">
      <div>
        <label for="email">Email:</label>
        <input type="email" v-model="email" required />
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" v-model="password" required />
      </div>
      <button type="submit">Login</button>
    </form>
  </div>
</template>

<script>
import apiClient from '../axios';
import { useToast } from 'vue-toastification';

export default {
  name: 'UserLogin',
  data() {
    return {
      email: '',
      password: ''
    };
  },
  methods: {
    async login() {
      const toast = useToast();
      try {
        const response = await apiClient.post('/Auth/login', {
          email: this.email,
          password: this.password
        });
        const token = response.data.token;

        // Simpan token di local storage
        localStorage.setItem('jwtToken', token);

        // Tampilkan notifikasi berhasil
        toast.success('Login berhasil!');

        // Redirect ke halaman utama atau dashboard
        this.$router.push('/');
      } catch (error) {
        console.error('Login failed:', error);
        toast.error('Login gagal. Silakan coba lagi.');
      }
    }
  }
};
</script>

<style scoped>
.login {
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
.login h1 {
  text-align: center;
}
.login form {
  display: flex;
  flex-direction: column;
}
.login form div {
  margin-bottom: 10px;
}
.login form label {
  font-weight: bold;
}
.login form input {
  padding: 8px;
  font-size: 16px;
}
.login form button {
  padding: 10px;
  font-size: 16px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
.login form button:hover {
  background-color: #0056b3;
}
</style>
