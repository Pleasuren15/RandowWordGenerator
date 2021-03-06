using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandowWordGenerator.Models;
using RandomWordsGeneratorDLL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RandowWordGenerator.Controllers
{
    public class HomeController : Controller
    {
        RandomWordsGenerator _RandomWordsGenerator { get; set; }
        public HomeController()
        {
            _RandomWordsGenerator = new RandomWordsGenerator();
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index(int _iNumberOfWordsMax = 200, int _iNumberOfParagraphsMax = 10)
        {
            ViewBag.RandomWords = "Randomly generated wordswill be placed here";
            ViewBag.EmptyString = "";
            PopulateDLLs(_iNumberOfWordsMax, _iNumberOfParagraphsMax);
            return View();
        }

        [HttpPost]
        public IActionResult Index(RandomWordsViewModel model)
        {
            ViewBag.EmptyString = "";
            if (ModelState.IsValid)
            {
                ViewBag.RandomWords = _RandomWordsGenerator.GetRandomWords(model.NumberOfOWords, new RandomWordsGenerator.WordLengthRange(model.MinimumWordLength, model.MaximumWordLength), model.FirstLetter, model.LastLetter);
            }
            PopulateDLLs(50, 10);
            return View();
        }

        private void PopulateDLLs(int _iNumberOfWordsMax, int _iNumberOfParagraphsMax)
        {
            List<int> lstNumbers = new List<int>();
            for (int i = 1; i <= _iNumberOfWordsMax; i++)
                lstNumbers.Add(i);
            ViewBag.NumberOfWords = new SelectList(lstNumbers, "NumberOfOWords");

            lstNumbers = new List<int>();
            for (int i = 1; i <= _iNumberOfParagraphsMax; i++)
                lstNumbers.Add(i);
            ViewBag.NumberOfParagraphs = new SelectList(lstNumbers, "NumberOfParagraphs");

            lstNumbers = new List<int>();
            for (int i = 1; i <= 15; i++)
                lstNumbers.Add(i);
            ViewBag.LengthOfWords = new SelectList(lstNumbers, "MinimumWordLength");
            ViewBag.LengthOfWords = new SelectList(lstNumbers, "MaximumWordLength");

            string sLetters = "abcdefghijklmnopqrstuvwxyz";
            List<string> lstLetters = new List<string>();
            for (int i = 0; i < sLetters.Length; i++)
                lstLetters.Add(sLetters[i].ToString());
            ViewBag.FirstLetter = new SelectList(lstLetters, "FirstLetter");
            ViewBag.LastLetter = new SelectList(lstLetters, "LastLetter");
        }
    }
}
