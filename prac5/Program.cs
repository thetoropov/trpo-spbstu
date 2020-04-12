using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac5
{
    /// <summary>
    /// Класс Пользователь
    /// </summary>
    class User
    {
        /// <summary>
        /// Создать приложение
        /// </summary>
        /// <param name="facade">Интерфейс для работы</param>
        public void CreateApp(VisualStudio facade)
        {
            facade.Start();
            facade.Stop();
        }
    }


    /// <summary>
    /// Класс VisualStudio
    /// </summary>
    class VisualStudio
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctexteditor">Текстовый редактор</param>
        /// <param name="ccompiller">Компилятор</param>
        /// <param name="cclr">Общеязыковая исполняющая среда</param>
        public VisualStudio(TextEditor ctexteditor, Compiller ccompiller, CLR cclr)
        {
            this.textEditor = ctexteditor;
            this.compiller = ccompiller;
            this.clr = cclr;
        }

        /// <summary>
        /// Выполнить
        /// </summary>
        public void Start()
        {
            textEditor.WriteCode();
            textEditor.SaveCode();
            compiller.CompileApp();
            clr.ExecuteApp();
        }

        /// <summary>
        /// Остановить
        /// </summary>
        public void Stop()
        {
            clr.CompleteApp();
        }
    }


    /// <summary>
    /// Класс Текстовый редактор
    /// </summary>
    class TextEditor
    {
        /// <summary>
        /// Написание кода
        /// </summary>
        public void WriteCode()
        {
            Console.WriteLine("Writing code");
        }

        /// <summary>
        /// Сохранение кода
        /// </summary>
        public void SaveCode()
        {
            Console.WriteLine("Saving code");
        }
    }


    /// <summary>
    /// Класс Компилятор
    /// </summary>
    class Compiller
    {
        /// <summary>
        /// Компиляция приложения
        /// </summary>
        public void CompileApp()
        {
            Console.WriteLine("Compiling the application");
        }
    }


    /// <summary>
    /// Класс Общеязыковая исполняющая среда
    /// </summary>
    class CLR
    {
        /// <summary>
        /// Выполнение приложения
        /// </summary>
        public void ExecuteApp()
        {
            Console.WriteLine("Application running");
        }

        /// <summary>
        /// Завершение приложения
        /// </summary>
        public void CompleteApp()
        {
            Console.WriteLine("Application completion");
        }
    }


    class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudio ide = new VisualStudio(textEditor, compiller, clr);

            User programmer = new User();
            programmer.CreateApp(ide);

            Console.ReadKey();
        }
    }
}

