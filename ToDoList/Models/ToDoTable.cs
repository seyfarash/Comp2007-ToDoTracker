//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToDoTable
    {
        public string username { get; set; }
        public string task { get; set; }
        public int taskID { get; set; }
        public int priority { get; set; }
        public System.DateTime dueDate { get; set; }
        public Nullable<int> points { get; set; }
    }
}
