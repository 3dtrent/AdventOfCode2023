using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers;
internal interface IAnswerProvider
{
    public string DayName { get; }

    public string InputPath { get; }

    public int GetAnswer(string[] inputLines);

    public void PrintAnswer(string[] inputLines) => Console.WriteLine($"{DayName}: {GetAnswer(inputLines)}");
}
