const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
      '^/api': {
        target: 'http://localhost:5177', // Backend yang benar
        changeOrigin: true,
        secure: false,
      }
    }
  }
});
