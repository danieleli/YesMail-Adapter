using System;

namespace SC.YesMailAdapter.Attributes
{
    public class SideTableTolkenAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}