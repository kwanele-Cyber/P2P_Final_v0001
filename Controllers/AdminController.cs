using P2P_Final_v0._001.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P2P_Final_v0._001.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [RequireHttps]
        public ActionResult Index()
        {
            if(Session["UserID"] != null)
            {
                MyDBContext db = new MyDBContext();
                ViewBag.TotalBookings = 0; //db.Bookings.Count();
                ViewBag.TotalRevenue = 0;
                ViewBag.BounceRate = 0;
                ViewBag.TotalCustomers = db.Accounts.Count();
                ViewBag.TotalCars = db.Cars.Count();

                ViewBag.Users = db.Accounts.ToList();

                List<Car> cars = db.Cars.ToList();

                return View(cars);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }

        public ActionResult Cars()
        {
            using (MyDBContext db = new MyDBContext())
            {
                ViewBag.Cars = db.Cars.ToList();
                return View();
            }
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cars([Bind(Include = "carID,Make,Model,Varient,Year,BodyType,Mileage,Color,FuelType,NumberPlate,Transmission,Description,Location,Address,Price")] Car car)
        {
            MyDBContext db = new MyDBContext();
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        public ActionResult EditCar(int id)
        {

            using (MyDBContext db = new MyDBContext())
            {
                var car = db.Cars.Find(id);
                return View(car);
            }
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carID,Make,Model,Varient,Year,BodyType,Mileage,Color,FuelType,NumberPlate,Transmission,Description,Location,Address,Price")] Car car)
        {
            MyDBContext db = new MyDBContext();
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public ActionResult CarDetails(int? id)
        {
            using (MyDBContext db = new MyDBContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Car car = db.Cars.Find(id);
                if (car == null)
                {
                    return HttpNotFound();
                }
                return View(car);
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            MyDBContext db = new MyDBContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyDBContext db = new MyDBContext();
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Rentals()
        {
            return View();
        }

        public ActionResult Customers()
        {
            using (MyDBContext db = new MyDBContext())
            {
                return View(db.Accounts.ToList());
            }
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> UserDetails(int? id)
        {
            MyDBContext db = new MyDBContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> CreateUser([Bind(Include = "AccountID,Name,Surname,Email,CellphoneNumber,Username,Password,DateOfBirth,AccountType,ProfilePic")] Account account)
        {
            MyDBContext db = new MyDBContext();
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                await db.SaveChangesAsync();
                return RedirectToAction("Customers");
            }

            return View(account);
        }

        public ActionResult Returns()
        {
            return View();
        }

        public ActionResult EditUser(int? id)
        {
            Account account = new Account();
            if(id != null)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    try
                    {
                        account = db.Accounts.Find(id);
                    }
                    catch(Exception e)
                    {
                        ViewBag.Message = "Error: " + e.Message;
                        account = new Account();
                    }
                }
            }
            
            return View("CreateUser",account);
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> DeleteUser(int? id)
        {
            MyDBContext db = new MyDBContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ComformDeleteUser(int id)
        {
            MyDBContext db = new MyDBContext();
            Account account = await db.Accounts.FindAsync(id);
            db.Accounts.Remove(account);
            await db.SaveChangesAsync();
            return RedirectToAction("Customers");
        }

    }
}