using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicListExample.Models
{
    public class Parent
    {
        [Display(Name = "Parent Id")]
        public Guid Id { get; set; }

        [Display(Name = "Parent Name")]
        public string Name { get; set; }

        public IList<Child> Children { get; set; }

        public Parent()
        {
            Id = Guid.NewGuid();
            Children = new List<Child>();
        }
    }
}
