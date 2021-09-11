using Domain.Repository;
using DotLiquid.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPeopleService> _peopleService;

        private readonly Lazy<ICategoryService> _categoryService;

        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _peopleService = new Lazy<IPeopleService>(() => new PeopleService(unitOfWork));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(unitOfWork));
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork));
        }

        

        public IPeopleService PeopleService => _peopleService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IProductService ProductService => _productService.Value;

    }
}
