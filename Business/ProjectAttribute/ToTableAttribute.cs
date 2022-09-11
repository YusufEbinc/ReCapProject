using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ProjectAttribute
{
    [AttributeUsage(AttributeTargets.Class |AttributeTargets.Method)]
   public class ToTableAttribute:Attribute
    {
        string _tableName;
        
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
