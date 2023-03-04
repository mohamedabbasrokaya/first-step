using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace first_step.Models
{
    public class category
    {
       
            public int id { get; set; }

            [Required, StringLength(256)]
            public string Name { get; set; }

            public List<cource> cources { get; set; }
            
        }
    }

