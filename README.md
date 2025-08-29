# AdvertisingPlatformsreadme_text 
=================================

Сервис подбора рекламных площадок по регионам (локациям).
Рекламодатель может загрузить список площадок и потом искать, какие площадки доступны в конкретном регионе.

Инструкция по запуску веб-сервиса:
----------------------------------
1. Установите .NET 7.0 SDK или новее (https://dotnet.microsoft.com/download/dotnet/7.0)
2. Склонируйте репозиторий:
   git clone https://github.com/b3st4rt3d/AdvertisingPlatforms.git
   cd advertising-platforms
3. Перейдите в каталог с проектом Web API:
   cd AdvertisingPlatforms
4. Запустите веб-сервис:
   dotnet run
5. После запуска сервис будет доступен по адресу:
   http://localhost:5081
6. Проверить работу API можно через:
   - Postman или Insomnia

Примеры API:
------------
1. Загрузка файла (POST /api/platforms/upload)
Body: FormData
    - Key = file
    - Value = platforms.txt

2. Поиск площадок по региону (GET /api/platforms/search?location=/ru/svrd)
Пример ответа:
[
  "Крутая реклама",
  "Ревдинский рабочий",
  "Яндекс.Директ"
]

Unit тесты:
-----------
Запуск тестов:
dotnet test
