using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicListExample.Models
{
    public class Child
    {
        [Display(Name = "Child Id")]
        public Guid Id { get; set; }

        [Display(Name = "Child Name")]
        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public Child()
        {
            Id = Guid.NewGuid();
        }
    }
}
