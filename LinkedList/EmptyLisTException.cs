using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class EmptyLisTException : Exception
    {
        public EmptyLisTException() : base("The LisT is empty.") { }
        public EmptyLisTException(string msg) : base(msg) { }
        public EmptyLisTException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
