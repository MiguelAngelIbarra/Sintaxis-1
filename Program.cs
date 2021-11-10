using System;

namespace Sintaxis_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sintaxis L = new Sintaxis();
           
            L.Match("#"); //dice que le primero deber ser #
            L.Match("include");
            L.Match("<");
            L.Match(Token.Tipos.identificador);
            L.Match(".");
            L.Match("h");
            L.Match(">");
            
            L.Match("#"); //dice que le primero deber ser #
            L.Match("include");
            L.Match("<");
            L.Match(Token.Tipos.identificador);
            L.Match(".");
            L.Match("h");
            L.Match(">");

           /* while(!L.FinAchivo())
            {
                L.NextToken();
                
            }*/

        }
    }
}
