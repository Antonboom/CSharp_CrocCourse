** Восстановить проект **
```
dotnet restore
dotnet build
```

** Запустить unit-тесты **

Перейти в проект *.Tests
```
dotnet test
```

### Lab 2
Задание на вторую лабораторную работу:
написать статический метод класса
```csharp
public static bool CouldBuild(string longWord, string smallWord) {...};
```
метод должен проверять, можно ли построить слово smallWord из букв, входящих в слово longWord (каждую букву слова longWord можно использовать только один раз).

