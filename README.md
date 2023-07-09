<br/>

<div align="center">
  <a href="https://github.com/miu-miu-enjoyers/excemath">
    <img src="https://github.com/miu-miu-enjoyers/excemath/assets/47981548/ef6f10fa-f517-4210-a90c-583b96b1f925" alt="Логотип" width="200" height="200">
  </a>
  
<h3 align="center"><font size="7"> excemath </font></h3>

  <p align="center">
  Хочеш підготуватись до національного мультипредметного тесту або сесії з математики, при цьому не поринаючи у море книжок? Цей додаток дозволить тобі удосконалити свої навички з розв'язування математичних задач різних видів!
    <br/>
    <a href="https://github.com/github_username/repo_name"></a>
</div>
 
 ## Що це?
 **excemath** - інтерактивний тренажер з математики, що дозволить тобі вирішувати математичні задачі різних видів та переглядати їхній покроковий розв'язок. 
 
 ## Як цим користуватися?
  1. Налаштуй [excemath API](https://github.com/miu-miu-enjoyers/excemath-api) за гайдом у readme-файлі на сторінці репозиторію.
 2. За тим саме гайдом виконай хостинг та отримай адресу, за допомогою якої можна звернутися до API.
 3. Заміни значення `urlBase` у [ApiClient.cs](https://github.com/miu-miu-enjoyers/excemath/blob/master/excemath/Models/ApiClient.cs) (39 рядок коду) на отриману адресу.
 4. Обов'язково прочитай, яким чином варто заносити математичні задачі у базу даних; у випадку, якщо формат задачі є некоректним, її відображення у додатку може бути неправильним, або ж сам додаток може працювати нестабільно.

## Технології, якими ми користувалися
Ми використовували платформу для створення крос-платформних додатків [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui) як основу нашого проєкту. Рендер прикладів відбувається за допомогою рушія [CSharpMath](https://github.com/verybadcat/CSharpMath) та API [SkiaSharp](https://github.com/mono/SkiaSharp). Валідація відповідей API відбувається за допомогою бібліотеки [FluentValidation](https://docs.fluentvalidation.net/en/latest/).

## Хто створив цей додаток?
Ми - команда [**miu-miu enjoyers**](https://github.com/miu-miu-enjoyers) - студенти Національного університету "Львівська політехніка". Наш проєкт було створено до пітчинґу з дисципліни "Програмування та командна робота", де ми посіли перше місце! (йоу)
