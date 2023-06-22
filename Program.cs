using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

string InputString;
bool isRussian;
//Проверка на наличие русских букв
do
{
    Console.Write("Введите строку: ");
    InputString = Console.ReadLine();
    isRussian = Regex.IsMatch(InputString, @"[А-Яа-яёЁ]");

    if (isRussian)
    {
        Console.Write("Ошибка повторите ввод! ");
        continue;
    }
    break;
} while (true);


Console.WriteLine();
Console.WriteLine("\t\t\tМеню выбора операций");
Console.WriteLine("===================================================================================");
Console.WriteLine("\t1 -  Нахождение слова содержащее максимальное колличество цифр");
Console.WriteLine("\t2 -  Найти самое длинное слово, и определить сколько раз оно встречалось в тексте");
Console.WriteLine("\t3 -  Замена цифр от 0 до 9 на слова");
Console.WriteLine("\t4 -  Вывод сначала вопросительных, затем восклицательных предложений");
Console.WriteLine("\t5 -  Вывод предложений без запятых");
Console.WriteLine("\t6 -  Поиск слов начинаюихся и заканчивающихся на одну и ту же букву");
Console.WriteLine("===================================================================================");
string symbolOperation;
bool checkSymbolOperation;
int parseSymbolOperation;
do
{
    Console.Write("Введите операцию ");
    symbolOperation = Console.ReadLine();
    checkSymbolOperation = int.TryParse(symbolOperation, out parseSymbolOperation);
    if (checkSymbolOperation == false)
    {
        Console.Write("Ошибка повторите ввод! ");
        continue;

    }
    break;
} while (true);
// операция находения слова с наибольшим колличеством чисел
switch (parseSymbolOperation)
{
    case 1:
        string[] splitString = InputString.Split(new char[] { ' ' });
        int maxCount = 0;
        string maxCountString = "";
        foreach (string substring in splitString)
        {
            int countNumber = 0;
            for (int i = 0; i < substring.Length; i++)
            {

                if (char.IsDigit(substring[i]))
                {
                    countNumber++;

                }

            }
            if (countNumber > maxCount)
            {
                maxCount = countNumber;
                maxCountString = substring;

            }


        }
        Console.WriteLine($"Максимальное колличество чисел [{maxCount}] находится в слове [{maxCountString}]");


        break;
    //нахождение самого длинного слова и определение сколько раз оно повторялось в тексте
    case 2:
        {
            char[] delimiter = new char[] { ' ', '!', '?', '.', ',', ':', ';', '-', '+', '*', '/' };
            string[] splitString1 = InputString.Split(delimiter);
            var maxLenghWordInString = "";
            int countRepeatWordInString = 0;
            foreach (string word in splitString1)
            {

                if (word.Length > maxLenghWordInString.Length)
                {
                    maxLenghWordInString = word;
                    countRepeatWordInString++;

                }
            }
            Console.WriteLine($"Самое длинное слово в строке {maxLenghWordInString}");
            Console.WriteLine($"Колличество повторений данного слова = {countRepeatWordInString}");
            break;


        }
        //замена всех чисел словами
    case 3:
        {
            var sbReplase = new StringBuilder(InputString);
            sbReplase.Replace("0", "zero");
            sbReplase.Replace("1", "one");
            sbReplase.Replace("2", "two");
            sbReplase.Replace("3", "three");
            sbReplase.Replace("4", "four");
            sbReplase.Replace("5", "five");
            sbReplase.Replace("6", "six");
            sbReplase.Replace("7", "seven");
            sbReplase.Replace("8", "eight");
            sbReplase.Replace("9", "nine");
            InputString = sbReplase.ToString();
            Console.WriteLine(InputString);
         }
        break;
        // сначала вопросительные потом восклицательные
    case 4:
        {
            var tempString = InputString;
            tempString = tempString.Replace("!", "!__");
            tempString = tempString.Replace("?", "?__");
            var tempString1 = tempString.Split("__");
            foreach (string aSentenceInTheText in tempString1)
            {
                if (aSentenceInTheText.Contains('?'))
                {
                    
                    Console.WriteLine(aSentenceInTheText);
                }

                else if (aSentenceInTheText.Contains('!'))
                {
                    
                    Console.WriteLine(aSentenceInTheText);
                }
               
            }

        }
        break;
    case 5:
        {
            var tempString = InputString;
            tempString = tempString.Replace("!", "!__");
            tempString = tempString.Replace("?", "?__");
            var tempString1 = tempString.Split("__");
            foreach (string aSentenceInTheText in tempString1)
            {
                if (!aSentenceInTheText.Contains(','))
                {

                    Console.WriteLine(aSentenceInTheText);
                }

                
            }
        }
        break;
    case 6:
        {
            char[] delimiter = new char[] { ' ', '!', '?', '.', ',', ':', ';', '-', '+', '*', '/' };
            string[] splitString6 = InputString.Split(delimiter);
           

            foreach (string word in splitString6)
            {
                if (word.Length >= 2)
                {
                    var firstSymbol = word[0];
                    var endSymbol = word[word.Length - 1];
                    if (firstSymbol == endSymbol)
                    {
                        Console.WriteLine(word);
                    }
                    

                }
            }





        }
        break;
    default:
        Console.WriteLine("Bye Bye!");
        break;







}



 