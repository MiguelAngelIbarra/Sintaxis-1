using System;
namespace Sintaxis_1
{
    /* 
    Requerimiento 1: Se requiere indicar en que linea esta el error lexico o sintactico
    Requerimiento 2: Modificar la gramatica para conciderar la negacion. Ejemplo: 
                     if(!a<0) osea el signo de admiracion es optativo
    Requerimiento 3: Modificar el metodo Condicion y el metodo For, segun la gramatica
    Requerimiento 4: Agregar la producción de Switch
                     switch(Expresion)
                     varios case: Instruccion | BloqueInstrucciones con un break; optativo
                     y un default: Instruccion | BloqueInstrucciones optativo
    Requerimiento 5: Codificar el metodo Switch
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
            if(getContenido() != "}") 
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
            else
            {
                Asignacion();
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
            Match("if");
            Match("(");
            Condicion();
            Match(")");
            if(getContenido()!="{")
            {
                Instruccion();
            }
            else
            {
                BloqueInstrucciones();
            }
            //? 
            if(getContenido()=="else")
            {
                Match("else");
                if(getContenido()!="{")
                {
                    Instruccion();
                }
                else
                {
                    BloqueInstrucciones();
                }
            }
        }
        // Condicion -> numero | identificador opRelacional numero | identificador 
        private void Condicion()
        {
           if(getClasificacion()==Tipos.numero)
           {
               Match(Tipos.numero);
           }
           else
           {
               Match(Tipos.identificador);
           }

           Match(Tipos.opRelacional);

           if(getClasificacion()==Tipos.numero)
           {
               Match(Tipos.numero);
           }
           else
           {
               Match(Tipos.identificador);
           }
        }
        // For -> for(identificador=numero; Condicion; identificador incTermino) BloqueInstrucciones | Instruccion
        private void For()
        {
            Match("for");
            Match("(");
            Match(Tipos.identificador);
            Match("=");
            Match(Tipos.numero);
            Match(Tipos.finSentencia);
            Condicion();
            Match(Tipos.finSentencia);
            Match(Tipos.identificador);
            Match(Tipos.incTermino);
            Match(")");
            if(getContenido()!="{")
            {
                Instruccion();
            }
            else
            {
                BloqueInstrucciones();
            }
        }
        // While -> while(Condicion) BloqueInstrucciones | Instruccion
        private void While()
        {
            Match("while");
            Match("(");
            Condicion();
            Match(")");
            if(getContenido()!="{")
            {
                Instruccion();
            }
            else
            {
                BloqueInstrucciones();
            }
        }
        //Asignacion  -> identificador = Expresion;
        private void Asignacion()
        {
            Match(Tipos.identificador);
            Match(Tipos.asignacion);
            Expresion();
            Match(Tipos.finSentencia);
        }
        // Expresion  -> Termino MasTermino 
        private void Expresion()
        {
            Termino();
            MasTermino();
        }
        // MasTermino -> (opTermino Termino)? 
        private void MasTermino()
        {
            if(getClasificacion()==Tipos.opTermino)
            {
                Match(Tipos.opTermino);
                Termino();
            }
        }
        // Termino	  -> Factor PorFactor 
        private void Termino()
        {
            Factor();
            PorFactor();
        }
        // PorFactor  -> (opFactor Factor)?
        private void PorFactor()
        {
            if(getClasificacion()==Tipos.opFactor)
            {
                Match(Tipos.opFactor);
                Factor();
            }
        }
        // Factor	  -> numero | identificador | (Expresion) 
        private void Factor()
        {
            if(getClasificacion()==Tipos.numero)
           {
               Match(Tipos.numero);
           }
           else if(getClasificacion()==Tipos.identificador)
           {
               Match(Tipos.identificador);
           }
           else
           {
               Match("(");
               Expresion();
               Match(")");
           }
        }
    }
}