using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandTypeSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandTypeSpecification(PaginationParams paginationParams)
            : base(x => (!paginationParams.BrandId.HasValue || x.ProductBrandId == paginationParams.BrandId) &&
                        (!paginationParams.TypeId.HasValue || x.ProductTypeId == paginationParams.TypeId))
        {
            AddInclue(x => x.ProductType);
            AddInclue(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            ApplyPaging(paginationParams.PageSize * (paginationParams.PageIndex - 1), paginationParams.PageSize);

            if (!string.IsNullOrEmpty(paginationParams.Sort))
            {
                switch (paginationParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithBrandTypeSpecification(int id) : base(x => x.Id == id)
        {
            AddInclue(x => x.ProductType);
            AddInclue(x => x.ProductBrand);
        }
    }
}
