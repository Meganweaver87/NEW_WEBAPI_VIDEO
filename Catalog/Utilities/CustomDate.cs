using System.ComponentModel.DataAnnotations;

using MongoDB.Driver;


namespace Catalog.Utilities
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
            : base(typeof(DateTime), 
                    DateTime.Now.AddYears(-123).ToShortDateString(),
                    DateTime.Now.ToShortDateString()) 
        { } // empty body
    }

}

