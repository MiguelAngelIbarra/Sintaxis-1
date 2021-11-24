using System;
using System.IO;

namespace Sintaxis_1
{
    public class Error
    {
        public void error(string message, int linea, StreamWriter log)
        {
            Console.WriteLine(message + " linea " + linea);
            log.WriteLine(message + " linea " + linea);
        }
    }
}