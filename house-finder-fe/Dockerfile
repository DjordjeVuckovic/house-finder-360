# Step 1: Build app
FROM node:18 AS build
WORKDIR /app
ARG BUILD_MODE=production

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build --mode=${BUILD_MODE}

# Step 2: Serve the app using Nginx
FROM nginx:alpine

COPY --from=build /app/dist /usr/share/nginx/html

COPY nginx.conf /etc/nginx/conf.d/default.conf
