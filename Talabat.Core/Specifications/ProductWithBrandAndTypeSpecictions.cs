using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndTypeSpecictions:BaseSpecifications<Product>
    {
        public ProductWithBrandAndTypeSpecictions(ProductSpecParams Pramas)
            :base(P =>
            (string.IsNullOrEmpty(Pramas.Search)|| P.Name.ToLower().Contains(Pramas.Search))
            &&
            (!Pramas.BrandId.HasValue || P.ProductBrandId == Pramas.BrandId)
            &&
            (!Pramas.TypeId.HasValue || P.ProductTypeId == Pramas.TypeId))
        { 
          Includes.Add(P=>P.ProductType);
            Includes.Add(P=>P.ProductBrand);
            if(!string.IsNullOrEmpty(Pramas.Sort))
            {
                switch(Pramas.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P=>P.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            ApplyPagination(Pramas.PageSize * (Pramas.PageIndex - 1), Pramas.PageSize);
        }
        public ProductWithBrandAndTypeSpecictions(int id):base(P=>P.Id ==id)
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
        }
    }
}
