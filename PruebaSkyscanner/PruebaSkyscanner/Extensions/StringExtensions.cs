using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSkyscanner.Extensions
{
    /// <summary>
    /// String extension
    /// </summary>
    public static class StringExtensions
    {
        private static readonly string[] separators = { ".", "," };

        private const string AUmlaut = "Ä";
        private const string Ae = "Ae";

        private const string OUmlaut = "Ö";
        private const string Oe = "Oe";

        private const string UUmlaut = "Ü";
        private const string Ue = "Ue";

        private const string SharpS = "ß";
        private const string Ss = "ss";

        /// <summary>
        /// Trims string.
        /// If string is null then String.Empty is returned.
        /// </summary>
        public static string MakeNotNullAndTrim(this string value)
        {
            return value == null ? String.Empty : value.Trim();
        }

        /// <summary>
        /// If string is string.Enpty then null is returned.
        /// Othervise value is retuen as it passed.
        /// </summary>
        public static string MakeNullIfEmpty(this string value)
        {
            return (value == null || String.IsNullOrWhiteSpace(value)) ? null : value;
        }

        /// <summary>
        /// Returns a new trimmed string padded with '0'.
        /// </summary>
        /// <param name="stringValue">Input string.</param>
        /// <param name="totalWidth">Total width.</param>
        /// <returns>Padded string or empty string.</returns>
        public static string TrimAndPadLeft(this string stringValue, int totalWidth)
        {
            return (stringValue ?? String.Empty).Trim().PadLeft(totalWidth, '0');
        }

        /// <summary>
        /// Returns a new string padded with '0' or empty string.
        /// </summary>
        /// <param name="sapValue">Input string.</param>
        /// <param name="totalWidth">Total width.</param>
        /// <returns>Padded string or empty string.</returns>
        public static string PadZeroLeftIfNotNull(this string sapValue, int totalWidth)
        {
            return !String.IsNullOrWhiteSpace(sapValue)
                       ? sapValue.Trim().PadLeft(totalWidth, '0')
                       : String.Empty;
        }




        /// <summary>
        /// Returns a new string padded with '0' or empty string.
        /// </summary>
        /// <param name="sapValue">Input string.</param>
        /// <param name="totalWidth">Total width.</param>
        /// <returns>Padded string or empty string.</returns>
        public static string PadZeroRightIfNotNull(this string sapValue, int totalWidth)
        {
            return !String.IsNullOrWhiteSpace(sapValue)
                       ? sapValue.Trim().PadRight(totalWidth, '0')
                       : String.Empty;
        }

        /// <summary>
        /// String as boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AsTrue(this string value)
        {
            bool result;
            if (String.IsNullOrWhiteSpace(value) ||
                !Boolean.TryParse(value, out result))
            {
                return false;
            }
            return result;
        }
        /// <summary>
        /// Replaces seprarator from another culture with current culture symbol
        /// </summary>
        public static string NormalizeNumberDecimalSeparator(this string text)
        {
            if (text == null)
            {
                return null;
            }

            var currentCultureSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var wrongSeparator = separators.FirstOrDefault(sep => sep != currentCultureSeparator);

            return text.Replace(wrongSeparator, currentCultureSeparator);
        }

        /// <summary>
        ///  Truncates string
        /// </summary>
        public static string Truncate(this string source, int length)
        {
            if (!String.IsNullOrEmpty(source) && source.Length > length)
            {
                return source.Substring(0, length);
            }

            return source;
        }



        /// <summary>
        /// Get normalized string. It could be used in search
        /// </summary>
        /// <param name="stringValue">Input string to be treated</param>
        /// <returns>Processed string with double single quote</returns>
        public static string GetStringForSearchWithSingleQuote(this string stringValue)
        {
            return (!string.IsNullOrWhiteSpace(stringValue)) &&
                  stringValue.Trim().Length > 0 && stringValue.Trim().Contains('\'')
                    ? stringValue.Trim().Replace("'", "''")
                    : stringValue;
        }

        /// <summary>
        /// Replace O or o by Zero
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string ReplaceLetterOByZero(this string stringValue)
        {
            return stringValue.Contains("O") || stringValue.Contains("o")
                ? stringValue.Replace("O", "0").Replace("o", "0")
                : stringValue;
        }

        public static string ReplaceSymbols(this string stringValue)
        {
            var cleaned = stringValue.Replace("\r\n","").Replace("[", " ").Replace("]", " ").Replace("\"", " ");
            return cleaned;
        }

        /// <summary>
        /// Checks string is Null or Empty and if contains *
        /// </summary>
        /// <param name="stringValue">String value</param>
        /// <returns>TRUE if strings meets any condition</returns>
        public static bool FilterIsNullOrEmpty(this string stringValue)
        {
            return String.IsNullOrEmpty(stringValue) || stringValue.Contains('*');
        }

        /// <summary>
        /// Compares two strings (case insensetive and culture invariant)
        /// </summary>
        /// <param name="stringValue">String value</param>
        /// <param name="comparable">Comparable string value</param>
        /// <returns>TRUE if strings equals</returns>
        public static bool IsEqual(this string stringValue, string comparable)
        {
            return String.Equals(stringValue, comparable, StringComparison.InvariantCultureIgnoreCase);
        }

       
        /// <summary>
        /// Converts string to nullable<double> 
        /// </summary>
        public static double? ToDouble(this string value)
        {
            double doubleValue;
            return double.TryParse(value, out doubleValue)
                ? doubleValue
                : (double?)null;
        }

        /// <summary>
        /// Converts string to nullable<long> 
        /// </summary>
        public static long? ToLong(this string value)
        {
            long longValue;
            return long.TryParse(value, out longValue)
                ? longValue
                : (long?)null;
        }



        /// <summary>
        /// Converts string to nullable<int> 
        /// </summary>
        public static int? ToInt(this string value)
        {
            int intValue;
            return int.TryParse(value, out intValue)
                ? intValue
                : (int?)null;
        }

        /// <summary>
        /// Trimed string contains two or more characters 
        /// </summary>
        public static bool HasAtLeastTwoChars(this string stringValue)
        {
            return HasAtLeastCharsNumber(stringValue, 2);
        }

        public static bool HasAtLeastOneChar(this string stringValue)
        {
            return HasAtLeastCharsNumber(stringValue, 1);
        }
        /// <summary>
        /// If string contains (>=) at least [minLength] chars.
        /// </summary>
        /// <param name="stringValue">Input string.</param>
        /// <param name="minLength">min length.</param>
        /// <returns>TRUE if contains. Else FALSE.</returns>
        public static bool HasAtLeastCharsNumber(this string stringValue, int minLength)
        {
            return (!String.IsNullOrWhiteSpace(stringValue) && stringValue.Trim().Length >= minLength);
        }
        /// <summary> Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of type <see cref="string"/>, using the specified separator between each member.
        /// It additionally ignores <see cref="string.Empty"/> like <see cref="string.Join(string, IEnumerable{string})"/> ignores 'null' and doesn't add a separator if an item is empty or 'null'. 
        /// </summary>
        /// <remarks> Based on implementation of <see cref="string.Join(string, IEnumerable{string})"/>. </remarks>
        /// <param name="separator"> The string to use as a separator. separator is included in the returned string only if values has more than one element. </param>
        /// <param name="values"> A collection that contains the strings to concatenate. </param>
        /// <returns> A string that consists of the members of values delimited by the separator string. If values has no members, the method returns <see cref="string.Empty"/>. </returns>
        public static string Join(this IEnumerable<string> values, string separator)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            if (separator == null)
                separator = String.Empty;

            using (IEnumerator<string> en = values.GetEnumerator())
            {
                if (!en.MoveNext())
                    return String.Empty;

                StringBuilder result = new StringBuilder();
                if (!String.IsNullOrEmpty(en.Current))
                {
                    result.Append(en.Current);
                }

                while (en.MoveNext())
                {
                    if (!String.IsNullOrEmpty(en.Current))
                    {
                        if (result.Length > 0)
                        {
                            result.Append(separator);
                        }
                        result.Append(en.Current);
                    }
                }
                return result.ToString();
            }
        }

        /// <summary>
        /// Check wether all characters are in upper case
        /// </summary>
        public static bool IsUpper(this string value)
        {
            return value == null ||
                   value.All(ch => !Char.IsLetter(ch) || Char.IsUpper(ch));
        }

        /// <summary>
        /// Compare string with ignore case
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string instance, string secondString)
        {
            return string.Compare(instance, secondString, StringComparison.CurrentCultureIgnoreCase) == 0;
        }

        /// <summary>
        /// Compare string with ignoring case.
        /// And take null as empty in comparison
        /// </summary>
        public static bool EqualsIgnoreCaseAndNullAsEmpty(this string instance, string secondString)
        {
            if (String.IsNullOrEmpty(instance) && String.IsNullOrEmpty(secondString))
            {
                return true;
            }

            return EqualsIgnoreCase(instance, secondString);
        }

        /// <summary>
        /// Replaces lower case umlauts with their respective digraph.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The digraph.</returns>
        public static string ReplaceLowerCaseUmlauts(this string value)
        {
            return value.Replace(AUmlaut.ToLower(), Ae.ToLower())
                .Replace(OUmlaut.ToLower(), Oe.ToLower())
                .Replace(UUmlaut.ToLower(), Ue.ToLower())
                .Replace(SharpS, Ss);
        }

        /// <summary>
        /// Replaces upper case umlauts with their respective digraph.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="capsLockMode">The caps lock mode.</param>
        /// <returns>The digraph.</returns>
        public static string ReplaceUpperCaseUmlauts(this string value, bool capsLockMode)
        {
            return value.Replace(AUmlaut, capsLockMode ? Ae.ToUpper() : Ae)
                .Replace(OUmlaut, capsLockMode ? Oe.ToUpper() : Oe)
                .Replace(UUmlaut, capsLockMode ? Ue.ToUpper() : Ue);
        }
    }
}
