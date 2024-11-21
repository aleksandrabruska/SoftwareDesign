using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    internal class PipelinesStringCompression
    {
        private readonly int _nStrings;
        private readonly int _stringLength;
        private readonly string _charsInString;

        double _avgCompressionRatio = 0;

        public PipelinesStringCompression(string charsInString, int nStrings, int stringLength)
        {
            _charsInString = charsInString;
            _nStrings = nStrings;
            _stringLength = stringLength;
        }

        public void Run()
        {
            BlockingCollection<(string, int)> fromGenerateToCompress = new BlockingCollection<(string, int)>();
            BlockingCollection<(string, string, int)> fromCompressToUpdateRatio = new BlockingCollection<(string, string, int)>();
            //BlockingCollection<double> result = new BlockingCollection<double>();
           // BlockingCollection<>
            Task t1 = Task.Run(() => GenerateStage(fromGenerateToCompress));
            Task t2 = Task.Run(() => CompressStage(fromGenerateToCompress, fromCompressToUpdateRatio));
            Task t3 = Task.Run(() => UpdateRatioStage(fromCompressToUpdateRatio));
            Task.WaitAll(t1, t2, t3);
            //Console.WriteLine(_avgCompressionRatio);



        }

        void GenerateStage(BlockingCollection<(string, int)> output)
        {
            try
            {
                for(int i = 0; i < _nStrings; i++) {
                //foreach(var item in input.GetConsumingEnumerable())
                    var random = new Random();
                    var result = new string(Enumerable.Repeat(_charsInString, _stringLength).Select(s => s[random.Next(s.Length)]).ToArray());
                    output.Add((result, i));
                    //Console.WriteLine(result);
                }
            }
            finally
            {
                output.CompleteAdding();
            }

        }

        void CompressStage(BlockingCollection<(string, int)> input, BlockingCollection<(string, string, int)> output)
        {
            try
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    string str = item.Item1;
                    var result = "";
                    for (var i = 0; i < str.Length; i++)
                    {
                        var j = i;
                        result += str[i];
                        while ((j < str.Length) && (str[i] == str[j]))
                            j++;

                        if (j > i + 1)
                        {
                            result += (j - i);
                            i = j - 1;
                        }
                    }
                    //Console.WriteLine(result);
                    output.Add((str, result, item.Item2));
                }
            }
            finally
            {
                output.CompleteAdding();
            }
        }


        void UpdateRatioStage(BlockingCollection<(string, string, int)> input)
        {
            
            try
            {
                foreach (var item in input.GetConsumingEnumerable()) {
                    _avgCompressionRatio = (((item.Item3 * _avgCompressionRatio) + (double)((item.Item2).Length) / ((item.Item1).Length)) / ((item.Item3) + 1));
                    //Console.WriteLine("r" + _avgCompressionRatio);
                }
            }
            finally
            {

            }
        }

    }
}
