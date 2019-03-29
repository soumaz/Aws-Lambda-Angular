FROM stefanscherer/node-windows

COPY . /app

WORKDIR /app

RUN npm install

EXPOSE 7070

ENTRYPOINT node_modules\.bin\http-server -p 7070