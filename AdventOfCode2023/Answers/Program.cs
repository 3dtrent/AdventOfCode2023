// See https://aka.ms/new-console-template for more information
using Answers;
using System.Reflection;

Console.WriteLine("Advent of Code 2023");

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();
var answerProviderTypes = types.Where(t => t.IsClass && t.IsAssignableTo(typeof(IAnswerProvider)));
foreach (var answerProviderType in answerProviderTypes)
{
    var input = await InputHelper.GetInputLines(@"Days\1\Input1.txt");
    var constructor = answerProviderType.GetConstructor(new Type[] { typeof(string[]) });
    var answerProvider = (IAnswerProvider)constructor.Invoke(new object?[] { input });
    var answer = answerProvider.GetAnswer();
    Console.WriteLine($"Day {answerProvider.DayId}: {answer}");
}