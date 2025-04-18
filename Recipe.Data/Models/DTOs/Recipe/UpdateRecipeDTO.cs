﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Recipe
{
    public class UpdateRecipeDTO
    {
        public Guid RecipeID { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public IFormFile? Image { get; set; }
        public Guid CategoryID { get; set; }
        public List<string> Hashtags { get; set; }
    }
}
