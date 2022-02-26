using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;    
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }
        
        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetListWithCategoryByWriterBM(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categories = (from x in categoryManager.GetList().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
           ViewBag.Categories = categories;   
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);

            List<SelectListItem> categories = (from x in categoryManager.GetList().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()

                                               }).ToList();
            ViewBag.Categories = categories;

            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;

                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter","Blog");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage); 
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogValue= blogManager.TGetById(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categories = (from x in categoryManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text=x.CategoryName,
                                                   Value=x.CategoryID.ToString()

                                               }).ToList();
                                               
            ViewBag.Categories = categories;

            var blogValue = blogManager.TGetById(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog guncellenecekBlog)
        {
            guncellenecekBlog.WriterID = 1;
            guncellenecekBlog.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            guncellenecekBlog.BlogStatus = true;
            blogManager.TUpdate(guncellenecekBlog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
