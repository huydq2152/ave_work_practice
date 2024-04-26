using System;
using System.IO;
using System.Text;

namespace Contract
{
    public class Service
    {
        private readonly string _fileName;

        private readonly uint[] _wordsArr;

        private int _startIndex;

        public Service(string fileName, uint[] wordsArr, int startIndex)
        {
            _fileName = fileName;
            _wordsArr = wordsArr;
            _startIndex = startIndex;
        }

        private readonly Base26 _base26 = new Base26();

        public void ReadLine()
        {
            try
            {
                const int bufferSize = 128;
                using var fileStream = File.OpenRead(_fileName);
                using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize);
                while (streamReader.ReadLine() is { } line)
                {
                    var tempArr = line.ToLower().Split(';', StringSplitOptions.RemoveEmptyEntries);

                    for (var i = 0; i < 10; i++)
                    {
                        _wordsArr[_startIndex] = _base26.StringToUint(tempArr[i].ToLower());
                        _startIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
