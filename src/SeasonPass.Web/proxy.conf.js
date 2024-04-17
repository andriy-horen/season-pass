const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
    ? env.ASPNETCORE_URLS.split(';')[0]
    : 'https://localhost:3001';

console.log(`Proxy enabled targeting: ${target}`);

module.exports = {
  '/api/**': {
    target,
    secure: false,
    changeOrigin: true,
  },
};
