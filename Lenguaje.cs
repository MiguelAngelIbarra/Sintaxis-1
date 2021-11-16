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
        // Programa	-> 	Librerias Variables Main
        public void Programa()
        {
            Librerias();
            Variables();
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
        //Variables ->  tipoDato ListaIdentificadores; Variables?
        private void Variables()
        {
            Match(Tipos.tipoDato);
            ListaIdentificadores();
            Match(Tipos.finSentencia);
            if(getClasificacion()==Tipos.tipoDato) //recursividad de Variables
            {
                Variables();
            }
        }
        //ListaIdentificadores ->  identificador (,ListaIdentificadores)?
        private void ListaIdentificadores()
        {
            Match(Tipos.identificador);
            if(getContenido()==",")//recursividad de lista
            {
                Match(",");
                ListaIdentificadores();
            }
        }
        // Main  ->	void main() BloqueInstrucciones
        private void Main()
        {
            Match("void");
            Match("main");
            Match("(");
            Match(")");
            BloqueInstrucciones();
        }
        // BloqueInstrucciones ->  {}
        private void BloqueInstrucciones()
        {
            Match("{");
            Match("}");
        }

    }
}