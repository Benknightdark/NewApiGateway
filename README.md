# Usage
```bash
# 啟動ApiGateway和Api服務
docker-compose up -d 

# 取得jwt token
curl --location --request GET 'http://localhost:5757/token'  --header 'Content-Type: application/json'

# 呼叫有jwt授權的api
curl --location --request GET 'http://localhost:5757/auth/api1/call' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer [YOUR TOKEN]'

# 呼叫一般api
curl --location --request GET 'http://localhost:5757/api1/ping' \
--header 'Content-Type: application/json'
```