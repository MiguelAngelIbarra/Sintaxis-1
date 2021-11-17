namespace Sintaxis_1
{
    /*
    Requerimiento 1: Programar produccion If
    Requerimiento 2: Programar produccion Condicion
    Requerimiento 3: Programar produccion For
    Requerimiento 4: Programar produccion While
        CADA UNO VALE 25 PUNTOS.
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
        // BloqueInstrucciones ->  {ListaInstrucciones}
        private void BloqueInstrucciones()
        {
            Match("{");
            ListaInstrucciones();
            Match("}");
        }
        // ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones()
        {
            Instruccion();
            if(getContenido() !="}")
            {
                ListaInstrucciones();
            }
        }
        // Instruccion -> Printf  | Scanf | If | For | While
        private void Instruccion()
        {
            if(getContenido() == "printf")
            {
                Printf();
            }
            else if(getContenido() == "scanf")
            {
                Scanf();
            }
            else if(getContenido() == "if")
            {
                If();
            }
            else if(getContenido() == "for")
            {
                For();
            }
            else if(getContenido() == "while")
            {
                While();
            }
        }
        // Printf -> printf(cadena (,ListaIdentificadores)?);
        private void Printf()
        {
            Match("printf");
            Match("(");
            Match(Tipos.Cadena);
            if(getContenido() == ",")
            {
                Match(",");
                ListaIdentificadores();
            }
            Match(")");
            Match(Tipos.finSentencia);
        } 
        // Scanf -> scanf(cadena,ListadeAmpersas);
        private void Scanf()
        {
            Match("scanf");
            Match("(");
            Match(Tipos.Cadena);
            Match(",");
            ListadeAmpersas();
            Match(")");
            Match(Tipos.finSentencia);
        } 
        // ListadeAmpersas -> & identificador(,ListadeAmpersas)?
        private void ListadeAmpersas()
        {
            Match("&");
            Match(Tipos.identificador);
            if(getContenido()==",")
            {
                Match(",");
                ListadeAmpersas();
            }
        }
        // If -> if(Condicion) BloqueInstrucciones | Intruccion (else BloqueInstrcciones | Instruccion)?
        private void If()
        {

        }
        // Condicion -> numero | identificador oprRelacional numero | identificador 
        private void Condicion()
        {

        }
        // For -> for(identificador=numero; Condicion; identificador incTermino) BloqueInstrucciones | Instruccion
        private void For()
        {

        }
        // While -> while(Condicion) BloqueInstrucciones | Instruccion
        private void While()
        {

        }
        

    }
}