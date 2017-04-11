using Microsoft.AspNetCore.Mvc;
using RetroMarket.Models;
using System.Linq;
using RetroMarket.Models.ViewModels;
using Sakura.AspNetCore;
using System.Collections.Generic;

namespace RetroMarket.Controllers
{

    public class ProductController : Controller
    {
        private IProductRepository repository;
        // public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ActionResult List(string category, string ordretri = null, string motrecherche = null, string champrec = null, int page = 1)
        {
            List<ProductsListViewModel> liste_vm = new List<ProductsListViewModel>();

            var product = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where<Product>(delegate (Product p)
                    {
                        if (motrecherche != null && champrec != null)
                        {
                            if (champrec == "Nom")
                            {
                                if (p.Category == category)
                                    return p.Name.ToUpper().Contains(motrecherche.ToUpper());
                                else if (category == null)
                                    return p.Name.ToUpper().Contains(motrecherche.ToUpper());
                                return false;
                            }
                            else if (champrec == "Description")
                            {
                                if (p.Category == category)
                                    return p.Description.ToUpper().Contains(motrecherche.ToUpper());
                                else if (category == null)
                                    return p.Description.ToUpper().Contains(motrecherche.ToUpper());
                                return false;
                            }
                        }
                        if (p.Category == category)
                            return true;
                        else if (category == null)
                            return true;
                        return false;
                    })
                    .OrderBy<Product, object>(delegate (Product p)
                    {
                        if (ordretri != null)
                        {
                            if (ordretri == "Nom")
                                return p.Name;
                            else if (ordretri == "Prix")
                                return p.Price;
                        }
                        return p.ProductID;
                    }),
                // .Skip((page - 1) * PageSize)
                //  .Take(PageSize),
                // PagingInfo = new PagingInfo
                // {
                //     CurrentPage = page,
                //     ItemsPerPage = PageSize,
                //     TotalItems = category == null ?
                //         repository.Products.Count() :
                //         repository.Products.Where(e =>
                //             e.Category == category).Count()
                // },
                CurrentCategory = category
            };

            // foreach (var p in product.Products)
            // {
            //     liste_vm.Add(new ProductsListViewModel());
            // }

            if (Request.IsAjaxRequest())
                return PartialView("_ListListeProduitsPartial", product.Products.ToPagedList<Product>(5, page));
            else
                return View(product.Products.ToPagedList<Product>(5, page));
        }
    }
}
