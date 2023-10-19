using P2P_Final_v0._001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2P_Final_v0._001.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OwnerSignUp()
        {
            Account account = new Account();
            account.AccountType = Account.Account_Type.Owner;
            return View(account);
        }

        [HttpPost]
        public ActionResult OwnerSignUp(Account account)
        {
            if(ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    account.AccountType = Account.Account_Type.Owner;
                    if (db.Accounts.Single(u => u.Username == account.Username) != null)
                    {
                        ViewBag.Message = "There is already an account with the username: " + account.Surname + " please try another one";
                        return View();
                    }
                    if (db.Accounts.Single(u => u.Email == account.Email) != null)
                    {
                        ViewBag.Message = "There is already an account with the email: " + account.Surname + " please try another one";
                        return View();
                    }
                    else
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();
                    }
                }
                ModelState.Clear();
                ViewBag.Message = account.Name + " " + account.Surname + " successfully registered.";
                return RedirectToAction("Login");
            }
            return View(account);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            using (MyDBContext db = new MyDBContext())
            {
                try
                {
                    var usr = db.Accounts.Single(u => u.Username == account.Username && u.Password == account.Password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.AccountID.ToString();
                        Session["UserName"] = usr.Username.ToString();
                        ViewBag.Message = usr.Name + " " + usr.Surname + " successfully logging in.";
                        if (usr.AccountType == Account.Account_Type.Owner)
                        {

                            return RedirectToAction("Index","Owner");
                        }
                        if (usr.AccountType == Account.Account_Type.Admin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Renter");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Error Could not Login.";
                        ModelState.AddModelError("", "username or password is wrong.");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = "username or password is wrong. <br/>" + "Error: " + e.Message;
                    ModelState.AddModelError("", "username or password is wrong. " + "Error: " + e.Message);
                }
            }
            return View(account);
        }

        public ActionResult RenterSignUp()
        {
            Account account = new Account();
            account.AccountType = Account.Account_Type.Renter;
            return View(account);
        }

        [HttpPost]
        public ActionResult RenterSignUp(Account account)
        {
            if (ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    account.AccountType = Account.Account_Type.Renter;
                    if (db.Accounts.Single(u => u.Username == account.Username) != null)
                    {
                        ViewBag.Message = "There is already an account with the username: " + account.Surname +" please try another one";
                        return View();
                    }
                    if (db.Accounts.Single(u => u.Email == account.Email) != null)
                    {
                        ViewBag.Message = "There is already an account with the email: " + account.Surname + " please try another one";
                        return View();
                    }
                    else
                    {
                        db.Accounts.Add(account);
                        db.SaveChanges();
                    }
                }
                ModelState.Clear();
                ViewBag.Message = account.Name + " " + account.Surname + " successfully registered.";
                return RedirectToAction("Login");
            }
            return View(account);
        }

        public ActionResult UserProfile()
        {
            if (Session["UserID"] != null)
            {
                using (MyDBContext db = new MyDBContext()) 
                {
                    int id = Int32.Parse(Session["UserID"].ToString());
                    var usr = db.Accounts.Find(id);
                    if(usr != null)
                    {
                        return View(usr);
                    }
                    else 
                    {
                        ViewBag.Message = " Something went wrong while trying to retrieve UserProfile.";
                        return View(usr);
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

    }
}