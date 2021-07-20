# ProductCatalog
Тестовый пример - Каталог продуктов

# Конфигурирование приложения
Приложение имеет следующие обязательные переменные окружения\секреты:
`App:Storage:ConnectionString` - строка подключения к БД

# Запуск приложение
## Убедиться что установлены инструменты
dotnet ef

## Если не установлены, установить
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

## Запусить миграции
dotnet ef database update --project .\src\ProductCatalog.Storage.Sqlite --startup-project .\src\ProductCatalog.Web

## Запустить приложение