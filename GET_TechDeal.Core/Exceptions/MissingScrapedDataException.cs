using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Core.Exceptions
{
    public class WebScrapingException : Exception
    {
        public WebScrapingException() : base() { }
        public WebScrapingException(string message) : base(message) { }
        public WebScrapingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
