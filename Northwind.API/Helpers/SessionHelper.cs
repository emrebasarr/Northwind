﻿using Newtonsoft.Json;

namespace Northwind.API.Helpers
{
    public class SessionHelper
    {
       
        //Set
        public static void SetJsonProduct(ISession session, string key, object value)
        {
            //session
            session.SetString(key, JsonConvert.SerializeObject(value));

        }


        //Get
        public static T GetProductFromJson<T>(ISession session, string key)
        {
            var result = session.GetString(key);

            if (result == null)
            {
                return default(T);
            }
            else
            {
                var deserialize = JsonConvert.DeserializeObject<T>(result);
                return deserialize;
            }
        }
    }
}
