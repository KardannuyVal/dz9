using System;
public interface ICipher
{
string Encode(string input);
string Decode(string input);
}
public class ACipher : ICipher
{
public string Encode(string input)
{
char[] chars = input.ToCharArray();
for (int i = 0; i < chars.Length; i++)
{
chars[i]++;
}
return new string(chars);
}
public string Decode(string input)
{
char[] chars = input.ToCharArray();
for (int i = 0; i < chars.Length; i++)
{
chars[i]--;
}
return new string(chars);
}
}
public class BCipher : ICipher
{
public string Encode(string input)
{
char[] chars = input.ToCharArray();
for (int i = 0; i < chars.Length; i++)
{
if (char.IsLetter(chars[i]))
{
char baseChar = char.IsUpper(chars[i]) ? 'A' : 'a';
chars[i] = (char)(baseChar + ('Z' - chars[i] + baseChar));
}
}
return new string(chars);
}
public string Decode(string input)
{
char[] chars = input.ToCharArray();
for (int i = 0; i < chars.Length; i++)
{
if (char.IsLetter(chars[i]))
{
char baseChar = char.IsUpper(chars[i]) ? 'A' : 'a';
chars[i] = (char)(baseChar + ('Z' - chars[i] + baseChar));
}
}
return new string(chars);
}
}
class Program
{
static void Main()
{
Console.WriteLine("Первое задание");
ICipher aCipher = new ACipher();
ICipher bCipher = new BCipher();
Console.Write("Введите сообщение: ");
string input = Console.ReadLine();
string aEncoded = aCipher.Encode(input);
string bEncoded = bCipher.Encode(input);
Console.WriteLine($"Зашифровано ACipher: {aEncoded}");
Console.WriteLine($"Зашифровано BCipher: {bEncoded}");
string aDecoded = aCipher.Decode(aEncoded);
string bDecoded = bCipher.Decode(bEncoded);
Console.WriteLine($"Расшифровано ACipher: {aDecoded}");
Console.WriteLine($"Расшифровано BCipher: {bDecoded}");
Console.WriteLine("\nВторое задание");
Console.Write("Введите цвет точки: ");
string pointColor = Console.ReadLine();
bool pointVisibility = GetBooleanInput("Точка видима? (да/нет):");
Point point = new Point(pointColor, pointVisibility);
Console.Write("Введите цвет окружности: ");
string circleColor = Console.ReadLine();
bool circleVisibility = GetBooleanInput("Окружность видима? (да/нет):");
double circleRadius = GetDoubleInput("Введите радиус окружности:");
Circle circle = new Circle(circleColor, circleVisibility, circleRadius);
Console.Write("Введите цвет прямоугольника: ");
string rectangleColor = Console.ReadLine();
bool rectangleVisibility = GetBooleanInput("Прямоугольник видим? (да/нет):");
double rectangleWidth = GetDoubleInput("Введите ширину прямоугольника:");
double rectangleHeight = GetDoubleInput("Введите высоту прямоугольника:");
Rectangle rectangle = new Rectangle(rectangleColor, rectangleVisibility, rectangleWidth, rectangleHeight);
double pointMoveByX = GetDoubleInput("Введите горизонтальное перемещение для точки:");
double pointMoveByY = GetDoubleInput("Введите вертикальное перемещение для точки:");
point.Move(pointMoveByX, pointMoveByY);
double circleMoveByX = GetDoubleInput("Введите горизонтальное перемещение для окружности:");
double circleMoveByY = GetDoubleInput("Введите вертикальное перемещение для окружности:");
circle.Move(circleMoveByX, circleMoveByY);
double rectangleMoveByX = GetDoubleInput("Введите горизонтальное перемещение для прямоугольника:");
double rectangleMoveByY = GetDoubleInput("Введите вертикальное перемещение для прямоугольника:");
rectangle.Move(rectangleMoveByX, rectangleMoveByY);
Console.WriteLine("\nИнформация о точке:");
point.DisplayInformation();
Console.WriteLine("\nИнформация об окружности:");
circle.DisplayInformation();
Console.WriteLine("\nИнформация о прямоугольнике:");
rectangle.DisplayInformation();
}
static double GetDoubleInput(string prompt)
{
double result;
while (true)
{
Console.Write(prompt);
if (double.TryParse(Console.ReadLine(), out result))
{
return result;
}
else
{
Console.WriteLine("Некорректный ввод. Пожалуйста, введите правильное число.");
}
}
}
static bool GetBooleanInput(string prompt)
{
while (true)
{
Console.Write(prompt);
string input = Console.ReadLine().ToLower();
if (input == "да")
{
return true;
}
else if (input == "нет")
{
return false;
}
else
{
Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
}
}
}
}
public class Figure
{
private string color;
private bool visibility;
private double x;
private double y;
public Figure(string color, bool visibility, double x = 0, double y = 0)
{
this.color = color;
this.visibility = visibility;
this.x = x;
this.y = y;
}
public void Move(double deltaX, double deltaY)
{
x += deltaX;
y += deltaY;
}
public void ChangeColor(string newColor)
{
color = newColor;
}
public void ChangeVisibility()
{
visibility = !visibility;
}
public virtual void DisplayInformation()
{
Console.WriteLine($"Цвет: {color}");
Console.WriteLine($"Видимость: {visibility}");
Console.WriteLine($"Положение: ({x}, {y})");
}
}
public class Point : Figure
{
public Point(string color, bool visibility, double x = 0, double y = 0) : base(color, visibility, x, y)
{
}
}
public class Circle : Point
{
private double radius;
public Circle(string color, bool visibility, double radius, double x = 0, double y = 0) : base(color, visibility, x, y)
{
this.radius = radius;
}
public override void DisplayInformation()
{
base.DisplayInformation();
Console.WriteLine($"Радиус: {radius}");
Console.WriteLine($"Площадь: {CalculateArea()}");
}
private double CalculateArea()
{
return Math.PI * radius * radius;
}
}
public class Rectangle : Point
{
private double width;
private double height;
public Rectangle(string color, bool visibility, double width, double height, double x = 0, double y = 0) : base(color, visibility, x, y)
{
this.width = width;
this.height = height;
}
public override void DisplayInformation()
{
base.DisplayInformation();
Console.WriteLine($"Ширина: {width}");
Console.WriteLine($"Высота: {height}");
Console.WriteLine($"Площадь: {CalculateArea()}");
}
private double CalculateArea()
{
return width * height;
}
}