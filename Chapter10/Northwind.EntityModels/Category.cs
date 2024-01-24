﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.EntityModels;

public class Category 
{

    public int CategoryId{ get; set; }
    public string Name { get; set; } = null!;
    [Column(TypeName = "ntext")]
    public string? Description{ get; set; } 
    public virtual ICollection<Product> Products{ get; set; } = new HashSet<Product>(); 

}