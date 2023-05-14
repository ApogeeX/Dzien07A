using Microsoft.AspNetCore.Mvc;
using System;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        static IList<Person> peopleList = new List<Person>()
        {
            new Person { PersonId = 1, PersonName = "Jan Kowalski", PersonAge = 15},
            new Person { PersonId = 6, PersonName = "Marian Kowalski", PersonAge = 33},
            new Person { PersonId = 4, PersonName = "Piotr Paczkowski", PersonAge = 42},
            new Person { PersonId = 3, PersonName = "Tomasz Tomaszewski", PersonAge = 35},
            new Person { PersonId = 5, PersonName = "Dorota Dorocińska", PersonAge = 40},
            new Person { PersonId = 2, PersonName = "Bogdan Bogdański", PersonAge = 18},
        };
        public IActionResult Index()
        {
            return View(peopleList.OrderBy(x => x.PersonId).ToList());
        }

        public IActionResult Edit(int id)
        {
            var person = peopleList.Where(x => x.PersonId == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        public IActionResult Create(int id)
        {
            var p = new Person { PersonId = id, PersonAge=0, PersonName=""};
            return View(p);
        }

        public IActionResult CreateConfirmed(Person person)
        {
            peopleList.Add(person);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var person = peopleList.Where(x => x.PersonId == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            //update
            var p = peopleList.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            peopleList.Remove(p);
            peopleList.Add(person);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = peopleList.Where(x => x.PersonId == id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
           
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Person person)
        {
            var p = peopleList.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }

            peopleList.Remove(p);
            return RedirectToAction("Index");
        }
    }
}
