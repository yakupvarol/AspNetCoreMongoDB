using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDB.Helper
{
    public class HelperMongo
    {
        public long Random()
        { 
            return Convert.ToInt64(DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Millisecond) + new Random().Next(); 
        }
    }
}
