using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CrossCutting
{
    public static class ExtensionString
    {
        public static bool EsNumero(this string value)
        {
            int numero;
            return value != null && Int32.TryParse(value, out numero);
        }

        public static bool EsDecimal(this string value)
        {
            decimal numero;
            return value != null && decimal.TryParse(value, out numero);
        }

        public static string Repeat(this char charToRepeat, int repeat)
        {

            return new string(charToRepeat, repeat);
        }

        public static string Repeat(this string stringToRepeat, int repeat)
        {
            var builder = new StringBuilder(repeat * stringToRepeat.Length);
            for (int i = 0; i < repeat; i++)
            {
                builder.Append(stringToRepeat);
            }
            return builder.ToString();
        }

        public static bool EsFechaValida(this string value, out DateTime fecha, FormatoFecha formatoFecha = FormatoFecha.Peru)
        {
            /*
             * Otra forma:
             DateTime.TryParseExact(pValues["FechaInicioDelegado"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio)
             */

            DateTime dtFecha;
            CultureInfo culture = formatoFecha == FormatoFecha.Peru ? new CultureInfo("es-PE") : new CultureInfo("en-US");

            bool resultado = DateTime.TryParse(value, culture, DateTimeStyles.None, out dtFecha); // Si la conversion falla dtFecha retorna MinValue

            fecha = dtFecha;

            return resultado;
        }

        public static string InterpretarFuncion(this string value)
        {
            var texto = string.Empty;
            if (value.IndexOf("()", StringComparison.Ordinal) > -1)
            {
                switch (value.ToUpper())
                {
                    case "FECHA()":
                        texto = DateTime.Now.ToString("dd/MM/yyyy");
                        break;
                    case "HORA()":
                        texto = DateTime.Now.ToString("HH:mm:ss");
                        break;
                    case "FECHAHORA()":
                        texto = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                }
            }
            else
            {
                texto = value;
            }

            return texto;
        }

        public static string LimpiarCaracteres(this string value)
        {
            var texto = value.Replace(";", string.Empty).Replace(".", string.Empty).Replace(",", string.Empty).Replace("  ", " ").TrimEnd().TrimStart();

            return texto;
        }

        public static string RemoverTildes(this string value)
        {
            //transformación UNICODE
            string textoNormalizado = value.Normalize(NormalizationForm.FormD);

            Regex reg = new Regex("[^a-zA-Z0-9. ]");
            string textoSinTildes = reg.Replace(textoNormalizado, "");

            return textoSinTildes;
        }

        public static string RemoverInvalidos(this string value)
        {

            var textoValido = value.Replace("\"", "''").Replace(@"\", @"\\");

            return textoValido;
        }

        public static string ConvertirHtml(this string value)
        {
            var textoNormalizado = value.Replace("\r\n", "<br/>").Replace("\t", " ").Replace("\n", "<br/>");
            return textoNormalizado;
        }

        public static string CapitalizarTexto(this string strCadena)
        {
            TextInfo ti = Thread.CurrentThread.CurrentCulture.TextInfo;

            return ti.ToTitleCase(strCadena.Trim().ToLower());
        }

        public static string ToPlainText(this string value)
        {
            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            var result = value.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating spaces because browsers ignore them
            result = Regex.Replace(result,@"( )+", " ");

            //Replace vocales
            result = result.Replace("&aacute;", "á");
            result = result.Replace("&eacute;", "é");
            result = result.Replace("&iacute;", "í");
            result = result.Replace("&oacute;", "ó");
            result = result.Replace("&uacute;", "ú");
            result = result.Replace("&ntilde;", "ñ");

            result = result.Replace("&Aacute;", "Á");
            result = result.Replace("&Eacute;", "É");
            result = result.Replace("&Iacute;", "Í");
            result = result.Replace("&Oacute;", "Ó");
            result = result.Replace("&Uacute;", "Ú");
            result = result.Replace("&Ntilde;", "Ñ");

            result = result.Replace("<p>"," ");
            result = result.Replace("</p>", " ");

            // Remove the header (prepare first by clearing attributes)
            result = Regex.Replace(result,
                     @"<( )*head([^>])*>", "<head>",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"(<( )*(/)( )*head( )*>)", "</head>",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     "(<head>).*(</head>)", string.Empty,
                     RegexOptions.IgnoreCase);

            // remove all scripts (prepare first by clearing attributes)
            result = Regex.Replace(result,
                     @"<( )*script([^>])*>", "<script>",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"(<( )*(/)( )*script( )*>)", "</script>",
                     RegexOptions.IgnoreCase);
            //result = Regex.Replace(result,
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty,
            //         RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"(<script>).*(</script>)", string.Empty,
                     RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = Regex.Replace(result,
                     @"<( )*style([^>])*>", "<style>",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"(<( )*(/)( )*style( )*>)", "</style>",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     "(<style>).*(</style>)", string.Empty,
                     RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = Regex.Replace(result,@"<( )*td([^>])*>", "\t",RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = Regex.Replace(result,
                     @"<( )*br( )*>", "\r",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"<( )*li( )*>", "\r",
                     RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            //result = Regex.Replace(result,
            //         @"<( )*div([^>])*>", "\r\r",
            //         RegexOptions.IgnoreCase);
            //result = Regex.Replace(result,
            //         @"<( )*tr([^>])*>", "\r\r",
            //         RegexOptions.IgnoreCase);
            //result = Regex.Replace(result,
            //         @"<( )*p([^>])*>", "\r\r",
            //         RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything that's enclosed inside < >
            result = Regex.Replace(result,
                     @"<[^>]*>", string.Empty,
                     RegexOptions.IgnoreCase);

            // replace special characters:
            result = Regex.Replace(result,
                     @" ", " ",
                     RegexOptions.IgnoreCase);

            result = Regex.Replace(result,
                     @"&bull;", " * ",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&lsaquo;", "<",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&rsaquo;", ">",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&trade;", "(tm)",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&frasl;", "/",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&lt;", "<",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&gt;", ">",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&copy;", "(c)",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&reg;", "(r)",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     @"&(.{2,6});", string.Empty,
                     RegexOptions.IgnoreCase);

            // for testing
            //Regex.Replace(result,
            //       this.txtRegex.Text,string.Empty,
            //       RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4.
            // Prepare first to remove any whitespaces in between
            // the escaped characters and remove redundant tabs in between line breaks
            result = Regex.Replace(result,
                     "(\r)( )+(\r)", "\r\r",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     "(\t)( )+(\t)", "\t\t",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     "(\t)( )+(\r)", "\t\r",
                     RegexOptions.IgnoreCase);
            result = Regex.Replace(result,
                     "(\r)( )+(\t)", "\r\t",
                     RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = Regex.Replace(result,
                     "(\r)(\t)+(\r)", "\r\r",
                     RegexOptions.IgnoreCase);
            // Remove multiple tabs following a line break with just one tab
            result = Regex.Replace(result,
                     "(\r)(\t)+", "\r\t",
                     RegexOptions.IgnoreCase);
            // Initial replacement target string for line breaks
            string breaks = "\r\r\r";
            // Initial replacement target string for tabs
            string tabs = "\t\t\t\t\t";
            for (int index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // That's it.
            return result;
        }
    }

    public enum FormatoFecha
    {
        Peru,
        EEUU
    }

}
