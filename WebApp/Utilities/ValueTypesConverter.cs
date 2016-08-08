using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApp.Utilities
{
    public class ValueTypesConverter
    {

        private Dictionary<Type, SqlDbType> typesDictionary = new Dictionary<Type, SqlDbType> {
                { typeof(string), SqlDbType.VarChar},
                { typeof(int), SqlDbType.Int },
                { typeof(DateTime), SqlDbType.DateTime },
                { typeof(Sex), SqlDbType.TinyInt }
            };

        public SqlDbType GetSQLType(Type type)
        {
            return typesDictionary[type];
        }
    }
}