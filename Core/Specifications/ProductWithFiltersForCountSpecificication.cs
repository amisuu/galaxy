using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecificication : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecificication(PaginationParams paginationParams)
            : base(x =>
                (!paginationParams.BrandId.HasValue || x.ProductBrandId == paginationParams.BrandId) &&
                (!paginationParams.TypeId.HasValue || x.ProductTypeId == paginationParams.TypeId)
            )
        {

        }
    }
}
