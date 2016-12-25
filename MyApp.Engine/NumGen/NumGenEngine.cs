using Common.Logging;
using System;

namespace MyApp.Engine.NumGen
{
    public class NumGenEngine
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(NumGenEngine));
        public static readonly Random rnd = new Random();

        public int GenerateNumber()
        {
            var number = rnd.Next();
            logger.InfoFormat("Generating Number: {0}", number);

            return rnd.Next();
        }
    }
}
