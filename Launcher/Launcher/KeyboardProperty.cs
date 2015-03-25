using System.Diagnostics;

namespace Launcher
{
   public static class KeyboardProperty
    {
       /// <summary>
       /// Запуск метода вызова клавиатуры.
       /// </summary>
      public static void KeyboardRun() 
       {
           Process.Start(@"C:\\Program Files\\Common Files\\microsoft shared\\ink\\tabtip.exe");
       }

       /// <summary>
       /// Завершение процесса вызова клавиатуры.
       /// </summary>
       public static void KeyboardClose()  
       {
         // Process. 
       }
    }
}
