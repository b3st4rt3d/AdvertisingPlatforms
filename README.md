# AdvertisingPlatformsreadme_text 
=================================

Сервис подбора рекламных площадок по регионам (локациям).
Рекламодатель может загрузить список площадок и потом искать, какие площадки доступны в конкретном регионе.

Функциональность:
-----------------
- Загрузка файла с рекламными площадками и регионами
- Поиск площадок по указанной локации (например /ru, /ru/svrd, /ru/msk)
- REST API с поддержкой Swagger
- Unit-тесты для проверки работы сервиса

Структура проекта:
------------------
AdvertisingPlatforms/
 ├── Controllers/
 │    └── PlatformsController.cs      # API контроллер
 ├── Services/
 │    └── PlatformsService.cs         # Логика работы с площадками
 ├── Models/
 │    └── AdvertisingPlatform.cs      # Модель рекламной площадки
 ├── Tests/
 │    └── PlatformsServiceTests.cs    # Unit тесты
 ├── AdvertisingPlatforms.http        # HTTP-запросы для тестирования в VS
 ├── README.txt
 └── Program.cs / Startup.cs          # Точка входа

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
Формат файла (platforms.txt):
Яндекс.Директ:/ru
Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik
Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl
Крутая реклама:/ru/svrd

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

Используемые технологии:
------------------------
- .NET 7.0 Web API
- Swagger (Swashbuckle.AspNetCore)
- xUnit для тестов

Автор: Your Name
"""

file_path = "/mnt/data/readme.txt"
with open(file_path, "w", encoding="utf-8") as f:
    f.write(readme_text)

file_path
