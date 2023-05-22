using Microsoft.EntityFrameworkCore;
using JORDAN_2T.Infrastructure.Interfaces;
using JORDAN_2T.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace JORDAN_2T.Infrastructure.Data;

public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
{
    private MvcMovieContext _context;
    public SubCategoryRepository(MvcMovieContext context) : base(context)
    {
        _context=context;
    }
    public SubCategory CreateNewSubCategory()
    {
        SubCategory Subcategory = new SubCategory();
        
        Subcategory.CategoryId = 0;

        Subcategory.Name= "New SubCategory";

        return Subcategory;
    }
    public SubCategory GetSubCategory(int id)
    {
        var Subcategory = _dbSet.Single(i => i.Id == id);
        
        return Subcategory;
    }
   

}