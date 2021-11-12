namespace Sintaxis_1
{
    /*
    Requerimiento 1: Valor: 10 Colocar en el Log fecha y hora de analisis
    Requerimiento 2: Valor: 10 Indentar la matriz de trancision 
    Requerimiento 3: Valor: 40 Agregar el operador de flujo de salida >>
    Requerimiento 4: Valor: 40 Agregar el operador de flujo de entrada <<
    
    */
    public class Lenguaje:Sintaxis
    {
        // Programa	-> 	Librerias Main
        public void Programa()
        {
            Librerias();
            Main();
        }
        // Librerias->	#include<identificador(.h)?> Librerias?
        private void Librerias()
        {
            Match("#");
            Match("include");
            Match("<");
            Match(Tipos.identificador);
            if(getContenido()==".")
            {
                Match(".");
                Match("h");
            }
            Match(">");
            if(getContenido()=="#")
            {
                Librerias();
            }
        }
        // Main		->	void main() { numero; }
        private void Main()
        {
            Match("void");
            Match("main");
            Match("(");
            Match(")");
            Match("{");
            Match(Tipos.numero);
            Match(";");
            Match("}");
        }
    }
}