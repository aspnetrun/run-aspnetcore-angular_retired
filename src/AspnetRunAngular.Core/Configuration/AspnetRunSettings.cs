using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRunAngular.Core.Configuration
{
    public class AspnetRunSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string AspnetRunConnection { get; set; }
    }
}
