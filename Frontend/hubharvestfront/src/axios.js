import axios from 'axios';
import { useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';

const apiClient = axios.create({
    baseURL: 'http://localhost:5177/api', // Gunakan URL HTTP
    headers: {
        'Content-Type': 'application/json'
    }
});

// Tambahkan interceptor untuk menyertakan token pada setiap permintaan
apiClient.interceptors.request.use(config => {
    const token = localStorage.getItem('jwtToken');
    console.log('Interceptor berjalan. Token yang ditemukan:', token);
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
        console.log('Header Authorization:', config.headers.Authorization);
    }
    return config;
});

// Tambahkan interceptor untuk menangani error 401
apiClient.interceptors.response.use(
    response => response,
    error => {
        if (error.response && error.response.status === 401) {
            const router = useRouter();
            const toast = useToast();

            // Tampilkan notifikasi bahwa sesi telah berakhir
            toast.error('Session has expired. Please log in again.');

            // Arahkan pengguna ke halaman login
            router.push('/login');

            // Hentikan eksekusi dan kembalikan janji yang ditolak
            return Promise.reject(error);
        }
        return Promise.reject(error);
    }
);

export default apiClient;
