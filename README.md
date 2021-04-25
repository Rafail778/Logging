# Logging - система логирования событий в файл

## API

Для работы с системой логирования используется класс `LogToFile`

### Формат сообщений

`<дата и время> <тип сообщения> <сообщение>`

- `<дата и время>` - текущая дата и время в длинном формате на момент записи сообщения
- `<тип сообщения>`:
    - **INFO** - информационные сообщения
    - **ERROR** - сообщения об критичных ошибках
    - **SUCCESS** - сообщения об успешных действиях
    - **WARNING** - предупреждающие сообщения / сообщения об некритичных ошибках
    
- `<сообщение>` - ваш текст сообщения

### Конструкторы

- `LogToFile()` Конструктор по умолчанию задаёт значение имени файла как `log.log`
- `LogToFile(path)` Конструктор с параметром пути файла - `path`, который имеет тип `string`. При передаче пустого `path` вызовется исключение с сообщением - *"Пустой путь к файлу"*

### Методы

- `LogInfo(message)` Метод записи информационных сообщений. Текст сообщения передаётся в`message`.
- `LogError(message)` Метод записи сообщений об ошибке. Текст сообщения передаётся в `message`
- `LogSuccess(message)` Метод записи сообщений об успехе. Текст сообщения передаётся в `message`
- `LogWarning(message)` Метод записи предупреждающих сообщений. Текст сообщения передаётся в `message`
- `LogCustom(type, message)` Метод записи свободных(свой тип) сообщений. Текст сообщения передаётся в `message`. Тип сообщения указывается в `type`.