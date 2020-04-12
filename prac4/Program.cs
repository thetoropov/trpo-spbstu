using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac4
{
    /// <summary>
    /// Интерфейс браузера
    /// </summary>
    public interface IWebBrouser
    {
        string Map();
        string Search();
        string Pictures();
        string Music();
        string Video();
        string Translate();
        string Storage();
        string Mail();
        string Weather();
        string News();
    }
    /// <summary>
    /// Класс контролер Google
    /// </summary>
    public class GoogleControler : IWebBrouser
    {
        /// <summary>
        /// Карты
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Map()
        {
            return "Google MapService";
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Search()
        {
            return "Google SearchService";
        }
        /// <summary>
        /// Картинки
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Pictures()
        {
            return "Google PicturesService";
        }
        /// <summary>
        /// Музыка
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Music()
        {
            return "Google MusicService";
        }
        /// <summary>
        /// Видео
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Video()
        {
            return "Google VideoService";
        }
        /// <summary>
        /// Перевод
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Translate()
        {
            return "Google TranslateService";
        }
        /// <summary>
        /// Диск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Storage()
        {
            return "Google StorageService";
        }
        /// <summary>
        /// Почта
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Mail()
        {
            return "Google MailService";
        }
        /// <summary>
        /// Погода
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Weather()
        {
            return "Google WeatherService";
        }
        /// <summary>
        /// Новости
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string News()
        {
            return  "Google NewsService";
        }
    }
    /// <summary>
    /// Класс контролер Yandex
    /// </summary>
    public class YandexControler : IWebBrouser
    {
        /// <summary>
        /// Карты
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Map()
        {
            return "Yandex MapService";
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Search()
        {
            return "Yandex SearchService";
        }
        /// <summary>
        /// Картинки
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Pictures()
        {
            return "Yandex PicturesService";
        }
        /// <summary>
        /// Музыка
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Music()
        {
            return "Yandex MusicService";
        }
        /// <summary>
        /// Видео
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Video()
        {
            return "Yandex VideoService";
        }
        /// <summary>
        /// Перевод
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Translate()
        {
            return "Yandex TranslateService";
        }
        /// <summary>
        /// Диск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Storage()
        {
            return "Yandex StorageService";
        }
        /// <summary>
        /// Почта
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Mail()
        {
            return "Yandex MailService";
        }
        /// <summary>
        /// Погода
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Weather()
        {
            return "Yandex WeatherService";
        }
        /// <summary>
        /// Новости
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string News()
        {
            return "Yandex NewsService";
        }
    }
    /// <summary>
    /// Класс контролер Baidu
    /// </summary>
    public class BaiduControler : IWebBrouser
    {
        /// <summary>
        /// Карты
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Map()
        {
            return "Baidu MapService";
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Search()
        {
            return "Baidu SearchService";
        }
        /// <summary>
        /// Картинки
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Pictures()
        {
            return "Baidu PicturesService";
        }
        /// <summary>
        /// Музыка
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Music()
        {
            return "Baidu MusicService";
        }
        /// <summary>
        /// Видео
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Video()
        {
            return "Baidu VideoService";
        }
        /// <summary>
        /// Перевод
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Translate()
        {
            return "Baidu TranslateService";
        }
        /// <summary>
        /// Диск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Storage()
        {
            return "Baidu StorageService";
        }
        /// <summary>
        /// Почта
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Mail()
        {
            return "Baidu MailService";
        }
        /// <summary>
        /// Погода
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string Weather()
        {
            return "Baidu WeatherService";
        }
        /// <summary>
        /// Новости
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string News()
        {
            return "Baidu NewsService";
        }
    }
    /// <summary>
    /// Класс Браузер
    /// </summary>
    public class WebBrouser
    {
        private IWebBrouser brouser;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cservice">Название сервиса</param>
        public WebBrouser(IWebBrouser cservice)
        {
            this.brouser = cservice;
        }
        /// <summary>
        /// Карты
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceMap()
        {
            return brouser.Map();
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceSearch()
        {
            return brouser.Search();
        }
        /// <summary>
        /// Картинки
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServicePictures()
        {
            return brouser.Pictures();
        }
        /// <summary>
        /// Музыка
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceMusic()
        {
            return brouser.Music();
        }
        /// <summary>
        /// Видео
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceVideo()
        {
            return brouser.Video();
        }
        /// <summary>
        /// Перевод
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceTranslate()
        {
            return brouser.Translate();
        }
        /// <summary>
        /// Диск
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceStorage()
        {
            return brouser.Storage();
        }
        /// <summary>
        /// Почта
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceMail()
        {
            return brouser.Mail();
        }
        /// <summary>
        /// Погода
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceWeather()
        {
            return brouser.Weather();
        }
        /// <summary>
        /// Новости
        /// </summary>
        /// <returns>Строка с названием сервиса</returns>
        public string webServiceNews()
        {
            return brouser.News();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] str_parts = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            WebBrouser brouser;

            if (str_parts[0] == "Google")
            {
                brouser = new WebBrouser(new GoogleControler());

                for (int i = 1; i < str_parts.Length; i++)
                {
                    if (str_parts[i] == "Map")
                    {
                        Console.WriteLine(brouser.webServiceMap());
                    }

                    else if (str_parts[i] == "Search")
                    {
                        Console.WriteLine(brouser.webServiceSearch());
                    }

                    else if (str_parts[i] == "Pictures")
                    {
                        Console.WriteLine(brouser.webServicePictures());
                    }

                    else if (str_parts[i] == "Music")
                    {
                        Console.WriteLine(brouser.webServiceMusic());
                    }

                    else if (str_parts[i] == "Video")
                    {
                        Console.WriteLine(brouser.webServiceVideo());
                    }

                    else if (str_parts[i] == "Translate")
                    {
                        Console.WriteLine(brouser.webServiceTranslate());
                    }

                    else if (str_parts[i] == "Storage")
                    {
                        Console.WriteLine(brouser.webServiceStorage());
                    }

                    else if (str_parts[i] == "Mail")
                    {
                        Console.WriteLine(brouser.webServiceMail());
                    }

                    else if (str_parts[i] == "Weather")
                    {
                        Console.WriteLine(brouser.webServiceWeather());
                    }

                    else if (str_parts[i] == "News")
                    {
                        Console.WriteLine(brouser.webServiceNews());
                    }

                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }

            else if (str_parts[0] == "Yandex")
            {
                brouser = new WebBrouser(new YandexControler());

                for (int i = 1; i < str_parts.Length; i++)
                {
                    if (str_parts[i] == "Map")
                    {
                        Console.WriteLine(brouser.webServiceMap());
                    }

                    else if (str_parts[i] == "Search")
                    {
                        Console.WriteLine(brouser.webServiceSearch());
                    }

                    else if (str_parts[i] == "Pictures")
                    {
                        Console.WriteLine(brouser.webServicePictures());
                    }

                    else if (str_parts[i] == "Music")
                    {
                        Console.WriteLine(brouser.webServiceMusic());
                    }

                    else if (str_parts[i] == "Video")
                    {
                        Console.WriteLine(brouser.webServiceVideo());
                    }

                    else if (str_parts[i] == "Translate")
                    {
                        Console.WriteLine(brouser.webServiceTranslate());
                    }

                    else if (str_parts[i] == "Storage")
                    {
                        Console.WriteLine(brouser.webServiceStorage());
                    }

                    else if (str_parts[i] == "Mail")
                    {
                        Console.WriteLine(brouser.webServiceMail());
                    }

                    else if (str_parts[i] == "Weather")
                    {
                        Console.WriteLine(brouser.webServiceWeather());
                    }

                    else if (str_parts[i] == "News")
                    {
                        Console.WriteLine(brouser.webServiceNews());
                    }

                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }

            else if (str_parts[0] == "Baidu")
            {
                brouser = new WebBrouser(new BaiduControler());

                for (int i = 1; i < str_parts.Length; i++)
                {
                    if (str_parts[i] == "Map")
                    {
                        Console.WriteLine(brouser.webServiceMap());
                    }

                    else if (str_parts[i] == "Search")
                    {
                        Console.WriteLine(brouser.webServiceSearch());
                    }

                    else if (str_parts[i] == "Pictures")
                    {
                        Console.WriteLine(brouser.webServicePictures());
                    }
                    else if (str_parts[i] == "Music")
                    {
                        Console.WriteLine(brouser.webServiceMusic());
                    }

                    else if (str_parts[i] == "Video")
                    {
                        Console.WriteLine(brouser.webServiceVideo());
                    }

                    else if (str_parts[i] == "Translate")
                    {
                        Console.WriteLine(brouser.webServiceTranslate());
                    }

                    else if (str_parts[i] == "Storage")
                    {
                        Console.WriteLine(brouser.webServiceStorage());
                    }

                    else if (str_parts[i] == "Mail")
                    {
                        Console.WriteLine(brouser.webServiceMail());
                    }

                    else if (str_parts[i] == "Weather")
                    {
                        Console.WriteLine(brouser.webServiceWeather());
                    }

                    else if (str_parts[i] == "News")
                    {
                        Console.WriteLine(brouser.webServiceNews());
                    }

                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }

            else
            {
                Console.WriteLine("Error");
            }

            Console.ReadKey();
        }
    }
}
