// See https://aka.ms/new-console-template for more information
using Answers;
using System.Reflection;

Console.WriteLine("Advent of Code 2023");

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();

var answerProviderTypes = types
    .Where(t => t.IsClass && t.IsAssignableTo(typeof(IAnswerProvider)))
    .OrderBy(t => t.GetCustomAttribute<OutputOrderAttribute>()?.SortOrder ?? double.MaxValue)
    .ThenBy(t => t.Name);

foreach (var answerProviderType in answerProviderTypes)
{
    var constructor = answerProviderType.GetConstructor(Array.Empty<Type>());
    var answerProvider = (IAnswerProvider)constructor.Invoke(null);

    var input = await InputHelper.GetInputLines(answerProvider.InputPath);
    var answer = answerProvider.GetAnswer(input);

    Console.WriteLine($"{answerProvider.DayName}: {answer}");
}