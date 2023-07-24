using MVC_CRUD_Application.DatabaseModel;
using MVC_CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Application.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Details/5
        public ActionResult GetAllStudentDetails()
        {
            clsStudentDatabase objStudentModel = new clsStudentDatabase();
            ModelState.Clear();
            return View(objStudentModel.GetAllStudents());
        }

        //GET: Student/Create
        public ActionResult AddStudent()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult AddStudent(clsStudentModel objStudent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsStudentDatabase objStudentDatabase = new clsStudentDatabase();
                    if (objStudentDatabase.AddStudent(objStudent))
                    {
                        ViewBag.AlertMsg = "Student Data Added SuccessFully";
                    }
                }
                return RedirectToAction("GetAllStudentDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult EditStudentDetails(int id)
        {
            clsStudentDatabase objStudentDatabase = new clsStudentDatabase();
            return View(objStudentDatabase.GetAllStudents().Find(std => std.StudentId == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult EditStudentDetails(int id, clsStudentModel objStudentModel)
        {
            try
            {
                // TODO: Add update logic here
                clsStudentDatabase objStudentDatabase = new clsStudentDatabase();
                objStudentDatabase.UpdateStudent(objStudentModel);

                return RedirectToAction("GetAllStudentDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Deletestd(int id)
        {
            try
            {
                clsStudentDatabase objStudentDataBase = new clsStudentDatabase();
                if (objStudentDataBase.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Employees Details Deleted SuccessFully";
                }
                return RedirectToAction("GetAllStudentDetails");
            }
            catch (Exception)
            {

                return View();
            }

        }
    }
}
