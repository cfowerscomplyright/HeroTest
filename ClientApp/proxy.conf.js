const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:5898';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/heroes",
      "/brand",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    },
    timeout: 300000
  }
]

module.exports = PROXY_CONFIG;
