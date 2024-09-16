Описание:<br />
• Приложение "Постер", представляющий список карточек, содержащих заголовок, текст и кнопки "Прочитано", "Не прочитано".<br />
• Пагинация реализована на основе смещения — иногда называемая пагинацией набора ключей или пагинацией на основе поиска.<br />
  "Бесконечная прокрутка" реализована с помощью пакета "react-infinite-scroll-component".<br />
• В проекте "Poster.Tests" реализовано тестирование backend части.<br />
• Хранение постов вынесено в глобальное хранилище состояний с помощью Redux.<br />
• В файле "appsettings.json", секции "Cors" проекта Poster.WebApi необходимо указать адрес сервера на котором располагается "Фронтенд" часть для выполнения
  кросс-доменные запросы.<br />
• В файле ".env" проекта Poster.UI для переменной "VITE_POSTS_SERVER" необходимо указать адрес сервера "Poster.WebApi" для выполнения запросов на управление постами.<br />
• База данных заполняется тестовыми данными в количестве 1500 штук.
<br />
Frontend:<br />
• React<br />
• Axios<br />
• Redux<br />
• Typescript<br />
<br />
Backend:<br />
• .NET 8<br />
• Swagger<br />
• EntityFramework, SqlLite<br />
• Clean arhitecture<br />
• Testing - XUnit, Moq<br />

<br /> 
Внешний вид пользовательского интерфейса<br /> 
https://github.com/user-attachments/assets/2bc0ce84-d3b0-4787-afd9-72f163725909
<br /> 
<br /> 
Инструкция по сборке:<br /> 
- Установить git<br /> 
- Клонировать репозиторий командой: git clone https://github.com/metvsploit/TestTask<br /> <br /> 
Frontend:<br /> 
- Установить NodeJs v20+<br /> 
- В файле ".env" проекта Poster.UI для переменной "VITE_POSTS_SERVER" указать адрес сервера к которому будут выполняться запросы на управление записями<br /> 
- Запустить командную строку, перейти в каталог проекта Poster.UI.<br /> 
- Установить зависимости командой: npm i.<br /> 
- Собрать проект командой: npm run build.<br /> 
- Перейти в созданную папку Poster.UI/dist через командную строку.<br /> 
- Создать и запустить сервер командой: npx http-server.<br /> 
  <br /> 
Backend:<br /> <br /> 
- Установить .NET 8.<br /> 
- С помощью командной строки перейти в папку "Poster" и ввести команду: dotnet restore.<br /> 
- Собрать проект командой: dotnet publish -c Release.<br /> 
- Перейти в каталог ~Poster\Poster.WebApi\bin\Release\net8.0\publish<br /> 
- Открыть файл appsettings.json, в секции "Cors" указать адрес "frontend" сервера, созданного на предыдущих шагах.<br /> 
- Для изменения адреса "по-умолчанию" backend-сервера в файл appsettings.json можно добавить секцию  "Urls": "address"<br /> 
- Открыть файл "Poster.WebApi.exe"<br /> 
