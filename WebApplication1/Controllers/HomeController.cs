using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BookDbAdd _bookDbAdd;
            // создаем контекст данных
            BookContext db = new BookContext();
        //public HomeController(BookDbAdd bookDbAdd)
        //{
        //    _bookDbAdd = bookDbAdd;
        //}
        public ActionResult Index()
            {
                // получаем из бд все объекты Book
                IEnumerable<Book> books = db.Books;
                // передаем все объекты в динамическое свойство Books в ViewBag
                ViewBag.Books = books;
                // возвращаем представление
                return View();
            }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            //ViewBag.BookId = id;
            return View(id);
        }
        [HttpPost]
        public string Buy(Purchase purchase, int id)
        {
            purchase.Date = DateTime.Now;
            purchase.BookId = id;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + purchase.Person + ", за покупку!";
        }




    }
}
