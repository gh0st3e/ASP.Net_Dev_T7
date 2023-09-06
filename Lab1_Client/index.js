const express = require('express');
const fs = require('fs');
const path = require('path');

const app = express();
const port = 3000;

// Middleware для обработки CORS
app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', '*'); // Разрешить доступ всем доменам (*), можно изменить на конкретный домен
  res.header('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept');
  next();
});

// Роут для отдачи HTML страницы
app.get('/', (req, res) => {
  // Путь к HTML файлу
  const filePath = path.join(__dirname, 'index.html');

  // Чтение HTML файла
  fs.readFile(filePath, 'utf8', (err, htmlContent) => {
    if (err) {
      // Если произошла ошибка при чтении файла, отправить ошибку на клиент
      res.status(500).send('Internal Server Error');
    } else {
      // Установить заголовок Content-Type как text/html
      res.header('Content-Type', 'text/html');
      // Отправить HTML содержимое на клиент
      res.status(200).send(htmlContent);
    }
  });
});

// Запуск сервера
app.listen(port, () => {
  console.log(`Сервер запущен на порту ${port}`);
});
