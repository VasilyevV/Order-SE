using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace Order_SE
{
    internal class OrderPrint
    {
        public static Word.Application WordApp = new Word.Application();

        internal static void Print(Dictionary<string, string> Dataorder, string pathOrder)//создание ордера
        {
            var Doc = WordApp.Documents.Open(@"C:\dotnet\Order SE\Order SE\Files\Template.docx", 0, false);

            foreach (var VARIABLE in Dataorder)
            {
                FindReplace(VARIABLE.Key, VARIABLE.Value);
            }

            string path = pathOrder + " - " + Dataorder["[Name]"] + ".docx";

            Doc.SaveAs(FileName: path); //сохранение ордера 

            Doc.Close();
            Marshal.FinalReleaseComObject(Doc);

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        internal static void FindReplace(string str_old, string str_new)//поиск и замена ключевых слов в шаблоне документа
        {
            Word.Find find = WordApp.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                MatchSoundsLike: Type.Missing, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue,
                Format: false, ReplaceWith: Type.Missing, Replace: Word.WdReplace.wdReplaceAll);
        }
    }
}
