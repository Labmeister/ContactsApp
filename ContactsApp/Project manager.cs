using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {

        /// <summary>
        /// константа содержащая путь
        /// </summary>
        private static string _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\1";
        public static void SaveToFile(project data, string file)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };

            ////Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, data);
            }
        }
        /// <summary>
        /// Сохранения списка заметок в путь по умолчанию
        /// </summary>
        /// <param name="data">список заметок </param>
        public static void SaveToFile(project data)
        {
            SaveToFile(data, _path);
        }
        public static project LoadFromFile(string file)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                return (project)serializer.Deserialize<project>(reader);
            }
        }
        /// <summary>
        /// Загрузка списка из файла в путь по умолчанию
        /// </summary>
        /// <returns>Возвращает список заметок</returns>
        public static project LoadFromFile()
        {
            return LoadFromFile(_path);
        }
    }
}
