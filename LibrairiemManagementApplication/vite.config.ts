import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    // Les appels /api sont redirigés vers l'API ASP.NET Core (profil "Library_Management")
    proxy: {
      '/api': {
        target: process.env.API_URL ?? 'http://localhost:5207',
        changeOrigin: true,
      },
    },
  },
})
