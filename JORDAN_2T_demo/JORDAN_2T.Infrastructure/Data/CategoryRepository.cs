using Microsoft.EntityFrameworkCore;
using JORDAN_2T.Infrastructure.Interfaces;
using JORDAN_2T.ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace JORDAN_2T.Infrastructure.Data;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private MvcMovieContext _context;
    public CategoryRepository(MvcMovieContext context) : base(context)
    {
        _context=context;
    }

    public Category CreateNewCategory()
    {
        Category category = new Category();
        
        category.Name= "New Category";

        return category;
    }

    public Category GetCategory(int id)
    {
        var category = _dbSet.Single(i => i.Id == id);
        
        return category;
    }
    
    
}