using System;
using System.Collections.Generic;
using System.Text;

namespace Fiber.Errors
{
    public struct Error
    {
        public string Title;
        public string Message;

        public Error(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
