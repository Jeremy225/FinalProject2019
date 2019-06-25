using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject2019.Models;
using FinalProject2019.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject2019.Controllers
{
    public class QuotesController : Controller
    {
        public IActionResult Index()
        {
            musicQuotesRepo repo = new musicQuotesRepo();

            QuoteIndexViewModel viewModel = new QuoteIndexViewModel();
            viewModel.Quotes = repo.GetAllQuotes();

            return View(viewModel);
        }
        public IActionResult Delete(int quoteId)
        {
            musicQuotesRepo repo = new musicQuotesRepo();
            repo.DeleteQuote(quoteId);

            return RedirectToAction("Index", "Quotes");
        }
        public IActionResult NewQuote ()
        {
            return View();
        }


        public IActionResult Add(string quote, string song, string artist, string genre)
        {
            musicQuotesRepo repo = new musicQuotesRepo();
            repo.InsertQuote(quote, song, artist, genre);

            return RedirectToAction("Index", "Quotes");
        }


    }
}