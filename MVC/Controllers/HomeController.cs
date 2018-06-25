using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
		
			return View();
		}

		public ActionResult InduvidualSummary()
		{
			IEnumerable<Person> personlist;
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.GetAsync("Person").Result;
			personlist = httpClientresponse.Content.ReadAsAsync<IEnumerable<Person>>().Result;
			return View(personlist);
		}

		
	}
}