using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Domain.Exceptions
{
    public class UnauthorizedCustomException(string message) : Exception(message)
    {

    }
}
