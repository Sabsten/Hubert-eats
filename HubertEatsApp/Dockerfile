FROM node AS builder
WORKDIR /usr/src/app/hubert-eats/frontend/
COPY . .
RUN npm install && npm run build

##################################
# Installe nginx sur le conteneur docker
FROM nginx 
# On se place dans le repertoire du serveur nginx
WORKDIR /usr/share/nginx/html
# Copie notre application vue dedans
COPY --from=builder /usr/src/app/hubert-eats/frontend/dist/ .