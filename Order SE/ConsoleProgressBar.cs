namespace Order_SE
{
    public class ConsoleProgressBar//Отображение прогресса выполнения
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Length { get; set; }

        public ConsoleProgressBar(int left, int top, int length)
        {
            Left = left;
            Top = top;
            Length = length;
        }

        public void ShowProgress(int progress)
        {
            (int left, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(Left, Top);
            Console.Write($"{new string('▓', progress)}{new string('░', Length - progress)}");
            Console.SetCursorPosition(left, top);
        }
    }
}
