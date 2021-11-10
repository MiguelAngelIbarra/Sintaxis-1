using System;

namespace Sintaxis_1
{
    public class Sintaxis:Lexico
    {
        public Sintaxis()
        {
            NextToken();
        }

        public void Match(string Espera) //compara el contenido contra la gramatica  
        {
            if(getContenido()==Espera)
            {
                NextToken();
            }
            else
            {
                Console.WriteLine("ERROR DE SINTAXIS: Se espera un " + Espera);
                log.WriteLine("ERROR DE SINTAXIS: Se espera un " + Espera);
            }
        }

        public void Match(Tipos Espera) //compara la Clasificacion contra la gramatica 
        {
            if(getClasificacion()==Espera)
            {
                NextToken();
            }
            else
            {
                Console.WriteLine("ERROR DE SINTAXIS: Se espera un " + Espera);
                log.WriteLine("ERROR DE SINTAXIS: Se espera un " + Espera);
            }
        }

    }
}