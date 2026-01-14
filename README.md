# TestWpfApp
Создать десктопное WPF-приложение на базе платформы .NET 8.0.
Приложение должно предоставлять возможность чтения и изменения некого
набора переменных среды в графическом формате.
Внешний вид UI должен соответствовать изображенному в Приложении №4,
но Pixel-perfect верстка при этом не требуется.
Вводимые Пользователем значения переменных могут быть только текстовые
и на практике не иметь ограничений по длине.
При запуске производится чтение переменных и вывод их на экран, либо
инициализация значениями по-умолчанию, если какая-либо из переменных не
существует.
Все записанные переменные и их значения должны быть доступны другим
приложениям и сохраняться даже после перезапуска ОС.
Дополнительные условия:
1. Подключить конфигурационный файл appsettings.json, в котором
описать набор имен используемых переменных среды в виде массива
строк.
2. Все факты изменения переменных среды должны фиксироваться в файл
логов, формат названия следующий:
test-sms-wpf-app-yyyyMMdd.log
Формат самих сообщений устанавливает Исполнитель на свое
усмотрение.
Для чтения конфигурационного файла и логирования допускается
использование популярных библиотек.

## Clone:

Clone this repo to your local machine using: https://github.com/MaxIvanov8/StartUpAppsViewer

## Visual Studio Build

Build .sln using Visual Studio.

## Prerequisites
Have Visual Studio 2015 or newer installed.

## Verify Installation
You can verify the project builds correctly from Visual Studio using Build -> Build Solution.

## Translations
This project can be translated into Russian.

## Support
If you are having issues, please let me know.

## Author

MaxIvanov: https://github.com/MaxIvanov8
