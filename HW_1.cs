int n = 0;
string? s=null;
for (bool success = false; !success;)
{
    Console.WriteLine("Введите размерноcть таблицы: ");
    var tableDimension = Console.ReadLine();
    success = int.TryParse(tableDimension, out n);
    if (success)
    {
        //ide ругается, что нужно проверить переменную tableDimension на null, но это делает int.TryParse (?)
        n = int.Parse(tableDimension);
        if (n is >= 1 and <= 6)
             break;
        else
            success = false;
        //(n >= 1 && n <= 6) ? break :
        // попробовал использовать Элвиса, но, очевидно, сделал что-то не так и шарп выдает ошибки :(
    }
}

//Console.WriteLine(n);

for (bool success=true; success;)
{
    Console.WriteLine("Введите произвольный текст: ");
    var randomText = Console.ReadLine();
    success = IsNullOrEmpty(randomText);
    if (!success)
    {
        s = randomText;
        break;
    }
}

//Console.WriteLine(s);

//создал метод, потому что не знал о существовании string.IsNullOrEmpty и решил оставить, как есть
static bool IsNullOrEmpty(string? s)
{
    bool result;
    result = s == null || s == string.Empty;
    return result;
}

var charactersNumber = (n - 1) * 2 + s.Length + 2;

//Console.WriteLine($"\n{charactersNumber}");

var stringWidth = 2 + (n - 1) * 2;
var maxWidth2 = 5 + stringWidth;
var maxWidth3 = maxWidth2 + 3;

//я не знаю, если честно, почему в разделе условия здесь поставил stringNumber<100
//только при сравнении с каким либо числом цикл перестает быть бесконечным, и это пока для меня непонятно :(
while(stringWidth<40)
{
    for (var stringNumber = 0; stringNumber < maxWidth3; stringNumber++)
{
    //здесь придумал костыль, чтобы учитывать 2 условия для переменной stringNumber (для случая со второй строкой)
    switch (stringNumber,stringNumber)
    {
        case (0,0):
        case (5,5):
            Console.WriteLine();
            for (var i = 0; i < charactersNumber; i++)
                Console.Write("+");
            break;
        
        case (1,1):
        case (4,4):
            for (var addStrings = 0; addStrings < (n - 1); addStrings++)
            {
                Console.Write("\n+");
                var i = 0;
                while (i < charactersNumber - 2)
                {
                    Console.Write(" ");
                    i++;
                }

                Console.Write("+");
            }
            break;
        
        case (3,3):
            Console.Write("\n+");

            for (var i = 0; i < n - 1; i++)
                Console.Write(" ");

            Console.Write(s);

            for (var i = 0; i < n - 1; i++)
                Console.Write(" ");

            Console.Write("+");
            break;
        
        //в  условии здесь попытался вписать переменную через такой костыль, 
        //потому что логика шарпа и switch, в частности, не позволяет делать это напрямую :(
        case (var value, > 5) when  value < maxWidth2 &&  stringNumber % 2 == 0:
            Console.WriteLine();
            for (var i = 0; i < Math.Round(charactersNumber / 2.0); i++)
            {
                Console.Write(" ");
                Console.Write("+");
            }
            break;
        
        //из-за правил деления целых чисел в шарпе при нечетных числах
        //вторая строка получалась не полностью заполненной
        //пытался пофиксить это во1 double делением (добавил точку у 2)
        //и во2 методом Math.Round с округлением до целого и модом округления
        case (var value, > 5) when  value< maxWidth2 && stringNumber % 2 == 1:
            Console.WriteLine();
            for (var i = 0; i < Math.Round(charactersNumber / 2.0, MidpointRounding.AwayFromZero); i++)
            {
                Console.Write("+");
                Console.Write(" ");
            }
            break;
        
        case (>0, var value) when value == maxWidth2:
            Console.WriteLine();
            for (var i = 0; i < charactersNumber; i++)
                Console.Write("+");
            break;
        
        case(var value, >0 ) when value == maxWidth2+1:
            Console.WriteLine();
            for (var i=0; i<charactersNumber; i++)
            {
                for (var j = 0; j < charactersNumber; j++)
                {
                    var isPlus = i == j || i+j == charactersNumber-1 ? "+" : " ";
                    Console.Write(isPlus);
                }
                Console.WriteLine();
            }
            break;
        
        case(var value,>0) when value == maxWidth2+2:
            for (var i = 0; i < charactersNumber; i++)
                Console.Write("+");
            break;
    }
}
break;
}
Console.ReadKey();




