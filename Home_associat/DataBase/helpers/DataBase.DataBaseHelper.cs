

using System.Collections.Generic;

namespace Home_assoc
{
    static partial class DataBase
    {
        static internal class DataBaseHelper
        {
            static internal string WhereFormateHelper(Dictionary<string, string> WhereCouple)
            {
                int count = WhereCouple.Count;
                string WhereCond = " WHERE is_zip = 0 ";

                if (count > 0)
                {
                    WhereCond += " AND ";
                    int i = 0;
                    foreach (var keyValue in WhereCouple)
                    {
                        if(keyValue.Value!= "NULL")
                        {
                            string[] spliter = keyValue.Value.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                            if (spliter[0] == "=")
                            {
                                WhereCond += keyValue.Key + " " + spliter[0] + " '" + spliter[1] + "'";
                            }
                            else
                            {
                                WhereCond += keyValue.Key + " " + string.Join(" ", spliter);
                            }
                        }
                        else
                        {
                            WhereCond += keyValue.Key + " = "  + keyValue.Value;
                        }
                        i++;
                        if (i < count)
                        {
                            WhereCond += " AND ";
                        }
                    }
                }

                return WhereCond;
            }
            static internal (string, string) InsertFormateHelper(Dictionary<string, string> InsertCouple)
            {
                string Collumn = string.Empty;
                string Vall = string.Empty;
                int count = InsertCouple.Count;

                if (count > 0)
                {
                    int i = 0;
                    foreach (var keyValue in InsertCouple)
                    {
                        Collumn += keyValue.Key;
                        Vall += " '" + keyValue.Value + "' ";
                        i++;

                        if (i < count)
                        {
                            Collumn += ", ";
                            Vall += ", ";
                        }
                    }
                }

                return (Collumn, Vall);
            }

            static internal (string, string) SelectFormateHelper(List<string> selectedCOll,
                Dictionary<string, string> WhereCouple)
            {
                string Collumn = string.Empty;
                string WhereCond = WhereFormateHelper(WhereCouple);

                int count = selectedCOll.Count;

                if (count > 0)
                {
                    int i = 0;
                    foreach (var item in selectedCOll)
                    {
                        Collumn += item;
                        i++;
                        if (i < count)
                        {
                            Collumn += ", ";
                        }
                    }
                }
                else
                {
                    Collumn += " * ";
                }

                return (Collumn, WhereCond);
            }

            static internal string UpdateFormateHelper(Dictionary<string, string> UpdCouple)
            {
                string SetString = string.Empty;
                int count = UpdCouple.Count;

                if (count > 0)
                {
                    SetString += "SET ";
                    int i = 0;
                    foreach (var keyValue in UpdCouple)
                    {
                        SetString += keyValue.Key + " = '" + keyValue.Value+"'";
                        i++;
                        if (i < count)
                        {
                            SetString += ", ";
                        }
                    }
                }

                return SetString;
            }
        }
    }
}
