using Domain.Entity;
using Domain.Repository;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        readonly IUnitOfWork uow;
        public CategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public void CreateNewCategory(CategoryDto category)
        {
            this.uow.CategoriesRepository.Create(new Category
            {
                Name = category.Name,
                Products = new List<Product>()
            }) ;

            this.uow.SaveChanges();
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = this.uow.CategoriesRepository.GetAll();

            return categories.Select((c) => new CategoryDto
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                Name = c.Name,
                Products = c.Products
            }).ToList() ;
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = this.uow.CategoriesRepository.Get(id);
            return new CategoryDto
            {
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                Name = category.Name,
                Products = category.Products
            };
        }

        public void RemoveCategoryById(int id)
        {
            this.uow.CategoriesRepository.Remove(id);
            this.uow.SaveChanges();
        }

        public void UpdateCategory(CategoryDto category)
        {
            this.uow.CategoriesRepository.Update(new Category
            {
                Id = category.Id,
                CreatedAt = category.CreatedAt,
                Name = category.Name,
                Products = category.Products
            });
            this.uow.SaveChanges();
        }
    }
}
