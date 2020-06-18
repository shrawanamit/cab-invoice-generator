using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            UserIdCanNotBeEmpty, UserIdCanNotBeNull
        }

        public ExceptionType type { get; set; }

        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
