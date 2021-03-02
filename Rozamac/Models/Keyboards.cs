using System.Diagnostics;

namespace Rozamac.Models
{
    public static class Keyboards
    {
        public static void showKeyboard()
        {
            Process.Start("osk.exe");
        }
    }
}
