using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answers;
internal interface IAnswerProvider
{
    public string DayId { get; }

    public int GetAnswer();

    public void PrintAnswer() => Console.WriteLine($"Day {DayId}: {GetAnswer()}");
}
