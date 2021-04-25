using System;
using System.IO;
using System.Security;

namespace Logging
{
    public class LogToFile
    {
        private string _path;

        public LogToFile()
        {
            _path = "log.log";
        }

        public LogToFile(string path)
        {
            if (path == string.Empty)
            {
                throw new Exception("Пустой путь к файлу");
            }
            _path = path; //TODO Прописать проверку возможности использования пути к файлу
        }

        private void WriteToFile(string message)
        {
            try
            {
                using var file = new StreamWriter(_path, true);
                file.WriteLine(message);
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Отказано в доступе");
            }
            catch (ArgumentException)
            {
                throw new Exception(
                    "Параметр path пуст или path содержит имя системного устройства (com1, com2 и т. д.)");
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("Указан недопустимый путь (например, он ведет на несопоставленный диск)");
            }
            catch (IOException)
            {
                throw new Exception(
                    "Параметр path включает неверный или недопустимый синтаксис имени файла, имени каталога или метки тома");
            }
            catch (SecurityException)
            {
                throw new Exception("У вызывающего объекта отсутствует необходимое разрешение");
            }
        }

        public void LogInfo(string message)
        {
            WriteToFile($"{DateTime.Now:u} INFO {message}");
        }
        public void LogError(string message)
        {
            WriteToFile($"{DateTime.Now:u} ERROR {message}");
        }
        public void LogSuccess(string message)
        {
            WriteToFile($"{DateTime.Now:u} SUCCESS {message}");
        }
        public void LogWarning(string message)
        {
            WriteToFile($"{DateTime.Now:u} WARNING {message}");
        }
        
        public void LogCustom(string type, string message)
        {
            WriteToFile($"{DateTime.Now:u} {type} {message}");
        }
    }
}