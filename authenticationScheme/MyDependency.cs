using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authenticationScheme
{
    public class MyDependency : IMyDependency
    {
        private ILogger<MyDependency> _logger;
        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public Task WriteMessage(string message)
        {
            //Console.WriteLine(
            //    $"MyDependecy.WriteMessage called. Message:{message}"
            //    );

            _logger.LogInformation
                (
                 $"MyDependecy.WriteMessage called. Message:{message}"
                );

            return Task.FromResult(0);

        }
    }
}
