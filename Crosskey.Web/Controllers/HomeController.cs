﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Models;
using Services.Interfaces;

namespace Crosskey.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoanService _service;

        public HomeController(ILogger<HomeController> logger,
            ILoanService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            //var result = await _service.RunAsync().ConfigureAwait(false);
            //ViewBag["LoanValue"] = result;
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Customer customer)
        {
            var result = _service.RunAsync(customer);
            return Content(result);
        }

        private static void Print(List<string> loanString)
        {
            Console.OutputEncoding = Encoding.UTF8;
            loanString.ForEach(Console.WriteLine);
        }
    }
}