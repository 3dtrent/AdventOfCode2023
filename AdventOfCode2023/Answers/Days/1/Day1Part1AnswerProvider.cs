using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Answers.Days._1;
internal class Day1Part1AnswerProvider : IAnswerProvider
{
    private readonly string[] _inputLines;

    public Day1Part1AnswerProvider(string[] inputLines)
    {
        _inputLines = inputLines;
    }

    public string DayId => "1.1";

    public int GetAnswer()
    {
        return 1;
    }
}
