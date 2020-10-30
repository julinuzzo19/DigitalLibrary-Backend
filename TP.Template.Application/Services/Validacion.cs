using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace TP2.Template.Application.Services
{
    public  class Validacion
    {
        
        public static bool ValidarEmail(string email)
        {

            string expresion = @"\w+.?\w+@\w[^_.]+\.com";

             Regex regex = new Regex(expresion);

            Match match = regex.Match(email);
            
           
           bool resultado= match.Success == true ? true : false;

            return resultado;

        }

        public static bool ValidarDni(string dni)
        {

            string dato = dni.Substring(0,8);

            string expresion = @"\d{5,6}[^\s.,_]\S";

            Regex regex = new Regex(expresion);

            Match match = regex.Match(dato);


            bool resultado = match.Success == true ? true : false;

            return resultado;

        }


        public static bool ValidarNombre(string nombre)
        {

            string expresion = @"^(?!.* (?: |$))[a-zA-Z]+$";

            Regex regex = new Regex(expresion);

            Match match = regex.Match(nombre);


            bool resultado = match.Success == true ? true : false;

            return resultado;
        }

        public static bool ValidarFecha(string fecha)
        {

            string expresion = @"^\d?\d[-/]\d?\d[-/]\d\d\d\d$";

            Regex regex = new Regex(expresion);

            Match match = regex.Match(fecha);

            bool resultado = match.Success == true ? true : false;
            
            return resultado;
        }
    }
}
            