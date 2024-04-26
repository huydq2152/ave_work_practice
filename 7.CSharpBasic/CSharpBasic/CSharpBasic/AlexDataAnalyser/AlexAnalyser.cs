using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Contract;

namespace AlexDataAnalyser
{
    public class AlexAnalyser : IDataAnalyser
    {
        public string Author => "Mike Dang";

        public string Path
        {
            get;
            private set;
        }

        public AlexAnalyser(string path)
        {
            this.Path = path;
        }

        public Stopwatch stopWatch = new Stopwatch();
        private readonly Base26 _base26 = new Base26();

        private void ReadFolder(string folderPath, uint[] wordsArr)
        {
            try
            {
                var i = 0;
                var threads = new List<Thread>();
                var listFilePath = Directory.GetFiles(folderPath);
                foreach (var filePath in listFilePath)
                {
                    if (File.Exists(filePath))
                    {
                        var service = new Service(filePath, wordsArr, i * 4999990);
                        var thread = new Thread(service.ReadLine)
                        {
                            Priority = ThreadPriority.Highest
                        };

                        threads.Add(thread);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine(filePath + " does not exist");
                    }
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void GetTopTenStrings(string path)
        {
            //read Folder
            stopWatch.Start();
            var wordsArr = new uint[49999900];
            ReadFolder(path, wordsArr);
            stopWatch.Stop();
            PrintTimer("create wordsArr time is :  ");

            //Get top 10 string
            stopWatch.Reset();
            stopWatch.Start();
            Array.Sort(wordsArr);

            var i = 0;
            var wordsArrLength = wordsArr.Length;

            var listFrequentOfWords = new int[wordsArrLength];
            var k = 0;

            for (; i < wordsArrLength; i++)
            {
                if (wordsArr[i] != 0)
                {
                    var frequentCount = 0;
                    int j;
                    for (j = i + 1; j < wordsArrLength; j++)
                    {
                        if (wordsArr[j] != wordsArr[i])
                        {
                            frequentCount = j - i; i = j;
                             break;
                        }
                    }
                    listFrequentOfWords[k] = frequentCount;
                    wordsArr[k] = wordsArr[j];
                    k++;
                }
            }

            Array.Sort(listFrequentOfWords, wordsArr);

            for (var index = listFrequentOfWords.Length - 1; index > listFrequentOfWords.Length - 11; index--)
            {
                Console.WriteLine(_base26.UintToString(wordsArr[index]) + " : " + listFrequentOfWords[index]);
            }

            stopWatch.Stop();
            PrintTimer("after read folder , get 10 most frequent words time is :  ");
        }

        public void PrintTimer(string title)
        {
            var ts = stopWatch.Elapsed;
            var elapsedTime = $"{ts.Seconds:00}.{ts.Milliseconds / 10:00}s";
            Console.WriteLine(title + elapsedTime);
        }
    }
}
