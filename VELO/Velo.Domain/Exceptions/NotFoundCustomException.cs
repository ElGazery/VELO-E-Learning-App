using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Domain.Exceptions
{

    public class NotFoundCustomException(string msg) : Exception(msg)
    {

    }
}
