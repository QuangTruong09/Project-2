using Microsoft.AspNetCore.Mvc.Rendering;
using JORDAN_2T.ApplicationCore.Models;
using System.Collections.Generic;

namespace JORDAN_2T.ApplicationCore.ViewModels;

public class CategoryVM
{

     public int Id {get;set;}
    public string? Name {get;set;}
    public  IEnumerable<Category> category {get;set;}
    
}