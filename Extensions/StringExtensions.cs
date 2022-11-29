namespace ProductivityTools.CodeGenerator.Extensions
{
    //public static class StringExtension
    //{
    //    public static string ToCamelCase(this string str)
    //    {
    //        if (!string.IsNullOrEmpty(str) && str.Length > 1)
    //        {
    //            return char.ToLowerInvariant(str[0]) + str.Substring(1);
    //        }
    //        return str.ToLowerInvariant();
    //    }
    //}

    //Or

    public static class StringExtension
    {

        public static string FormatToDotNetType(this string str)
        {
            string strReturn = "";
            if (str == null) return "";
            switch (str)
            {
                case "bigint":
                    strReturn = "ToInt64";
                    break;
                case "integer":
                    strReturn = "ToInt32";
                    break;
                case "character varying":
                    strReturn = "ToString";
                    break;
                case "date":
                    strReturn = "ToDateTime";
                    break;
                case "boolean":
                    strReturn = "ToBoolean";
                    break;
                default:
                    break;
            }
            return strReturn;
        }


        public static string FormatToDomainType(this string str)
        {
            string strReturn = "";
            if (str == null) return "";
            switch (str)
            {
                case "bigint":
                    strReturn = "Int64";
                    break;
                case "integer":
                    strReturn = "int";
                    break;
                case "character varying":
                    strReturn = "string";
                    break;
                case "date":
                    strReturn = "DateTime";
                    break;
                case "boolean":
                    strReturn = "bool";
                    break;
                default:
                    break;
            }
            return strReturn;
        }


        public static string FormatToSPParameterType(this string str)
        {
            string strReturn = "";
            if (str == null) return "";
            switch (str)
            {
                case "bigint":
                    strReturn = "BIGINT";
                    break;
                case "integer":
                    strReturn = "INTEGER";
                    break;
                case "character varying":
                    strReturn = "VARCHAR";
                    break;
                case "date":
                    strReturn = "DATE";
                    break;
                case "boolean":
                    strReturn = "BOOLEAN";
                    break;
                default:
                    break;
            }
            return strReturn;
        }


        public static string FormatToParameterCommandType(this string str)
        {
            string strReturn = "";
            if (str == null) return "";
            switch (str)
            {
                case "bigint":
                    strReturn = "Bigint";
                    break;
                case "integer":
                    strReturn = "Integer";
                    break;
                case "character varying":
                    strReturn = "Text";
                    break;
                case "date":
                    strReturn = "Date";
                    break;
                case "boolean":
                    strReturn = "Boolean";
                    break;
                default:
                    break;
            }
            return strReturn;
        }

        public static string FormatToDomainParameter(this string str)
        {
            return !string.IsNullOrEmpty(str) && str.Length > 1 ? char.ToLower(str[0]) + str.Substring(1) : str.ToLowerInvariant();
        }


        public static string FormatToFirstUpCamelCase(this string str)
        {
            return !string.IsNullOrEmpty(str) && str.Length > 1 ? char.ToUpperInvariant(str[0]) + str.Substring(1) : str.ToLowerInvariant();
        }


        public static string FormatToCamelCaseRemoveUnderline(this string str)
        {
            if (!str.Contains("_")) return str.FormatToFirstUpCamelCase();

            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                string[] splited = str.Split('_');
                string strReturn = "";

                foreach (string s in splited)
                    strReturn += s.FormatToFirstUpCamelCase();

                return strReturn;
            }

            return str.FormatToFirstUpCamelCase();

        }

    }


}
