using Microsoft.AspNetCore.Mvc;
using Talabat.Core;
using Talabat.Core.Entites;

namespace AdminDashBoard.Controllers
{
	public class TypeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public TypeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IActionResult> Index()
		{
			var types = await _unitOfWork.Repository<ProductType>().GetAllAsync();
			return View(types);
		}
		public async Task<IActionResult> Create(ProductType type)
		{
			try
			{
				await _unitOfWork.Repository<ProductType>().AddAsync(type);
				await _unitOfWork.CompleteAsync();
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ModelState.AddModelError("Name", "Please Enter new Brand Name");
				return View("Index", await _unitOfWork.Repository<ProductType>().GetAllAsync());
			}
		}
		public async Task<IActionResult> Delete(int id)
		{
			var type = await _unitOfWork.Repository<ProductType>().GetByIdAsync(id);
			_unitOfWork.Repository<ProductType>().Delete(type);
			await _unitOfWork.CompleteAsync();
			return RedirectToAction("Index");
		}
	}
}
