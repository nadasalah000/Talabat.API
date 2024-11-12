using AdminDashBoard.Models;
using AutoMapper;
using Talabat.Core.Entites;

namespace AdminDashBoard.Helper
{
    public class MapsProfile:Profile
    {
        public MapsProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
