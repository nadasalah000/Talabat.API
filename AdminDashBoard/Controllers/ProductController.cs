using AdminDashBoard.Helper;
using AdminDashBoard.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Stripe;
using Talabat.Core;
using Talabat.Core.Entites;

namespace AdminDashBoard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        { 
            var Products = await _unitOfWork.Repository<Product>().GetAllAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductViewModel>>(Products);
            return View(mappedProducts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Image != null)
                {
                    model.PictureUrl = PictureSettings.UploadFile(model.Image, "Products");
                }
                else
                {
                    model.PictureUrl = "images/Products/boot-ang2.png";
                }
                var mappedProduct = _mapper.Map<ProductViewModel, Product>(model);
                await _unitOfWork.Repository<Product>().AddAsync(mappedProduct);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var Product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            var mappedProduct = _mapper.Map<Product,ProductViewModel>(Product);
            return View(mappedProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Image != null)
                {
                    if(model.PictureUrl != null)
                    {
                        PictureSettings.DeleteFole(model.PictureUrl, "Products");
                        model.PictureUrl = PictureSettings.UploadFile(model.Image, "Products");
                    }
                }
                var product = _mapper.Map<ProductViewModel,Product>(model);
                _unitOfWork.Repository<Product>().Update(product);
                var result = await _unitOfWork.CompleteAsync();
                 if(result>0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            var mappedProduct = _mapper.Map<Product,ProductViewModel>(product);
            return View(mappedProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            try
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(model.Id);
                if(product.PictureUrl != null)
                {
                    PictureSettings.DeleteFole(product.PictureUrl, "Products");
                }
                _unitOfWork.Repository<Product>().Delete(product);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(model);
            }
        }
    }
}
