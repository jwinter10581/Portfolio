using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Vehicles()
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetAll();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();
            model.BodyStyles = new SelectList(BodyStyleRepositoryFactory.GetRepository().GetAll(), "BodyStyleType", "BodyStyleType");
            model.Colors = new SelectList(ColorRepositoryFactory.GetRepository().GetAll(), "ColorName", "ColorName");
            model.Interiors = new SelectList(InteriorRepositoryFactory.GetRepository().GetAll(), "InteriorName", "InteriorName");
            model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
            model.Models = new SelectList(ModelRepositoryFactory.GetRepository().GetAll(), "ModelName", "ModelName");
            model.Transmissions = new SelectList(TransmissionRepositoryFactory.GetRepository().GetAll(), "TransmissionType", "TransmissionType");
            model.VehicleTypes = new SelectList(VehicleTypeRepositoryFactory.GetRepository().GetAll(), "VehicleTypeName", "VehicleTypeName");
            model.Vehicle = new Vehicle();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddVehicle(VehicleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (VehicleRepositoryFactory.GetRepository().GetAll().Any(v => v.VINNumber == model.Vehicle.VINNumber))
                    {
                        model.BodyStyles = new SelectList(BodyStyleRepositoryFactory.GetRepository().GetAll(), "BodyStyleType", "BodyStyleType");
                        model.Colors = new SelectList(ColorRepositoryFactory.GetRepository().GetAll(), "ColorName", "ColorName");
                        model.Interiors = new SelectList(InteriorRepositoryFactory.GetRepository().GetAll(), "InteriorName", "InteriorName");
                        model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
                        model.Models = new SelectList(ModelRepositoryFactory.GetRepository().GetAll(), "ModelName", "ModelName");
                        model.Transmissions = new SelectList(TransmissionRepositoryFactory.GetRepository().GetAll(), "TransmissionType", "TransmissionType");
                        model.VehicleTypes = new SelectList(VehicleTypeRepositoryFactory.GetRepository().GetAll(), "VehicleTypeName", "VehicleTypeName");

                        ModelState.AddModelError("", "VIN already exists in database, please try again.");
                        return View(model);
                    }

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images/Vehicle");
                        //string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string fileName = "inventory-" + model.Vehicle.VINNumber;
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + " (" + counter.ToString() + ")" + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFilePath = Path.GetFileName(filePath);
                    }

                    VehicleRepositoryFactory.GetRepository().Insert(model.Vehicle);

                    return RedirectToAction("EditVehicle", "Admin", new { @id = model.Vehicle.VINNumber });
                }
                catch (Exception ex)
                {
                    throw new Exception("Add Vehicle was unsuccessful.");
                }
            }
            else
            {
                model.BodyStyles = new SelectList(BodyStyleRepositoryFactory.GetRepository().GetAll(), "BodyStyleType", "BodyStyleType");
                model.Colors = new SelectList(ColorRepositoryFactory.GetRepository().GetAll(), "ColorName", "ColorName");
                model.Interiors = new SelectList(InteriorRepositoryFactory.GetRepository().GetAll(), "InteriorName", "InteriorName");
                model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
                model.Models = new SelectList(ModelRepositoryFactory.GetRepository().GetAll(), "ModelName", "ModelName");
                model.Transmissions = new SelectList(TransmissionRepositoryFactory.GetRepository().GetAll(), "TransmissionType", "TransmissionType");
                model.VehicleTypes = new SelectList(VehicleTypeRepositoryFactory.GetRepository().GetAll(), "VehicleTypeName", "VehicleTypeName");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditVehicle(string id)
        {
            if (id is null)
            {
                return RedirectToAction("Vehicles", "Admin");
            }

            var model = new VehicleEditViewModel();
            model.BodyStyles = new SelectList(BodyStyleRepositoryFactory.GetRepository().GetAll(), "BodyStyleType", "BodyStyleType");
            model.Colors = new SelectList(ColorRepositoryFactory.GetRepository().GetAll(), "ColorName", "ColorName");
            model.Interiors = new SelectList(InteriorRepositoryFactory.GetRepository().GetAll(), "InteriorName", "InteriorName");
            model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
            model.Models = new SelectList(ModelRepositoryFactory.GetRepository().GetAll(), "ModelName", "ModelName");
            model.Transmissions = new SelectList(TransmissionRepositoryFactory.GetRepository().GetAll(), "TransmissionType", "TransmissionType");
            model.VehicleTypes = new SelectList(VehicleTypeRepositoryFactory.GetRepository().GetAll(), "VehicleTypeName", "VehicleTypeName");
            model.Vehicle = VehicleRepositoryFactory.GetRepository().GetById(id);
            model.OldVIN = model.Vehicle.VINNumber;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditVehicle(VehicleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var oldVehicle = VehicleRepositoryFactory.GetRepository().GetById(model.OldVIN);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images/Vehicle");
                        //string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string fileName = "inventory-" + model.Vehicle.VINNumber;
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savePath, fileName + " (" + counter.ToString() + ")" + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFilePath = Path.GetFileName(filePath);

                        var oldPath = Path.Combine(savePath, oldVehicle.ImageFilePath);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        model.Vehicle.ImageFilePath = oldVehicle.ImageFilePath;
                    }

                    VehicleRepositoryFactory.GetRepository().Update(model.Vehicle, model.OldVIN);

                    return RedirectToAction("Vehicles", "Admin");
                }
                catch (Exception ex)
                {
                    throw new Exception("Edit Vehicle was unsuccessful.");
                }
            }
            else
            {
                model.BodyStyles = new SelectList(BodyStyleRepositoryFactory.GetRepository().GetAll(), "BodyStyleType", "BodyStyleType");
                model.Colors = new SelectList(ColorRepositoryFactory.GetRepository().GetAll(), "ColorName", "ColorName");
                model.Interiors = new SelectList(InteriorRepositoryFactory.GetRepository().GetAll(), "InteriorName", "InteriorName");
                model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
                model.Models = new SelectList(ModelRepositoryFactory.GetRepository().GetAll(), "ModelName", "ModelName");
                model.Transmissions = new SelectList(TransmissionRepositoryFactory.GetRepository().GetAll(), "TransmissionType", "TransmissionType");
                model.VehicleTypes = new SelectList(VehicleTypeRepositoryFactory.GetRepository().GetAll(), "VehicleTypeName", "VehicleTypeName");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Users()
        {
            var model = EmployeeRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            var model = new EmployeeAddViewModel();
            model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
            model.Employee = new Employee();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(EmployeeAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userMgr = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

                    if (userMgr.FindByEmail(model.Employee.EmployeeEmail) != null)
                    {
                        #region Prevents user from creating account with same email.
                        ModelState.AddModelError("", "User already exists");
                        model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
                        return View(model);
                        #endregion

                        #region Used for Mock Repo to allow creation of same account.
                        //var oldUser = userMgr.FindByEmail(model.Employee.EmployeeEmail);
                        //userMgr.Delete(oldUser);

                        //if (EmployeeRepositoryFactory.GetRepository().GetByAspNetId(oldUser.Id) != null)
                        //{
                        //    EmployeeRepositoryFactory.GetRepository().Delete(oldUser.Id);
                        //}
                        #endregion
                    }

                    var user = new AppUser
                    {
                        UserName = model.Employee.EmployeeEmail,
                        Email = model.Employee.EmployeeEmail
                    };

                    userMgr.Create(user, model.Password);
                    userMgr.AddToRole(user.Id, model.Employee.RoleName.ToLower());

                    EmployeeRepositoryFactory.GetRepository().Insert(model.Employee);

                    return RedirectToAction("Users", "Admin");
                }
                catch (Exception ex)
                {
                    throw new Exception("Add User was unsuccessful.");
                }
            }
            else
            {
                model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditUser(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", "Employee not found, try again.");
                return RedirectToAction("Users", "Admin");
            }

            var model = new EmployeeEditViewModel();
            model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
            model.Employee = EmployeeRepositoryFactory.GetRepository().GetByEmployeeId(id);
            model.OldEmail = model.Employee.EmployeeEmail;
            model.OldRole = model.Employee.RoleName;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldEmployee = EmployeeRepositoryFactory.GetRepository().GetByEmployeeId(model.Employee.EmployeeId);

                if (oldEmployee is null) // Something didn't work, try again
                {
                    ModelState.AddModelError("", "Employee not found, try again.");
                    model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
                    return View(model);
                }
                try
                {
                    var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                    var updatedUser = userManager.FindByEmail(oldEmployee.EmployeeEmail);

                    updatedUser.UserName = model.Employee.EmployeeEmail;
                    updatedUser.Email = model.Employee.EmployeeEmail;

                    if (model.Password is null)
                    {
                        await userManager.UpdateAsync(updatedUser);
                    }
                    else
                    {
                        var provider = new DpapiDataProtectionProvider("GuildCars");
                        userManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("ChangePassword"));
                        var token = await userManager.GeneratePasswordResetTokenAsync(updatedUser.Id);
                        await userManager.ResetPasswordAsync(updatedUser.Id, token, model.Password);
                        await userManager.UpdateAsync(updatedUser);
                    }

                    userManager.RemoveFromRole(updatedUser.Id, oldEmployee.RoleName.ToLower());
                    userManager.AddToRole(updatedUser.Id, model.Employee.RoleName.ToLower());

                    EmployeeRepositoryFactory.GetRepository().Update(model.Employee);
                    return RedirectToAction("Users", "Admin");
                }
                catch (Exception ex)
                {
                    throw new Exception("Edit User was unsuccessful.");
                }
            }
            else
            {
                model.Roles = new SelectList(RoleRepositoryFactory.GetRepository().GetAll(), "RoleName", "RoleName");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Makes()
        {
            var model = new MakeAddViewModel();
            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.NewMake = new Make();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Makes(MakeAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (MakeRepositoryFactory.GetRepository().GetAll().Any(m => m.MakeName.ToLower() == model.NewMake.MakeName.ToLower()))
                    {
                        model.Makes = MakeRepositoryFactory.GetRepository().GetAll();

                        ModelState.AddModelError("", "Make Name already exists in database, please try again.");
                        return View(model);
                    }

                    model.NewMake.EmployeeId = EmployeeRepositoryFactory.GetRepository().GetByEmployeeEmail(AuthorizeUtilities.GetEmail(this)).EmployeeId; // Grabs AspNetUser Id & Converts to Employee ID
                    model.NewMake.EmployeeEmail = AuthorizeUtilities.GetEmail(this);
                    MakeRepositoryFactory.GetRepository().Insert(model.NewMake);

                    ModelState.Clear();
                    model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
                    model.NewMake = new Make();
                    return View(model);
                }
                catch (Exception ex)
                {
                    throw new Exception("Adding Make was unsuccessful.");
                }
            }
            else
            {
                model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Models()
        {
            var model = new ModelAddViewModel();
            model.Models = ModelRepositoryFactory.GetRepository().GetAll();
            model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
            model.NewModel = new Model();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Models(ModelAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelRepositoryFactory.GetRepository().GetAll().Any(m => m.ModelName.ToLower() == model.NewModel.ModelName.ToLower()))
                    {
                        model.Models = ModelRepositoryFactory.GetRepository().GetAll();
                        model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");

                        ModelState.AddModelError("", "Model Name already exists in database, please try again.");
                        return View(model);
                    }

                    model.NewModel.EmployeeId = EmployeeRepositoryFactory.GetRepository().GetByEmployeeEmail(AuthorizeUtilities.GetEmail(this)).EmployeeId; // Grabs AspNetUser Id & Converts to Employee ID
                    model.NewModel.EmployeeEmail = AuthorizeUtilities.GetEmail(this);
                    ModelRepositoryFactory.GetRepository().Insert(model.NewModel);

                    ModelState.Clear();
                    model.Models = ModelRepositoryFactory.GetRepository().GetAll();
                    model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
                    model.NewModel = new Model();
                    return View(model);
                }
                catch (Exception ex)
                {
                    throw new Exception("Adding Model was unsuccessful.");
                }
            }
            else
            {
                model.Models = ModelRepositoryFactory.GetRepository().GetAll();
                model.Makes = new SelectList(MakeRepositoryFactory.GetRepository().GetAll(), "MakeName", "MakeName");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Specials()
        {
            var model = new SpecialAddViewModel();
            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();
            model.Special = new Special();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Specials(SpecialAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SpecialRepositoryFactory.GetRepository().Insert(model.Special);

                    ModelState.Clear();
                    model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();
                    model.Special = new Special();
                    return View(model);
                }
                catch (Exception ex)
                {
                    throw new Exception("Adding Special was unsuccessful.");
                }
            }
            else
            {
                model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();
                return View(model);
            }
        }
    }
}