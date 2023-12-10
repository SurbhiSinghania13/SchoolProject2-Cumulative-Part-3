using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject2.Models;
using System.Diagnostics;

namespace SchoolProject2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }
        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
  
            return View(SelectedTeacher);
        }


        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }


        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create( string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {


            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Routes to the "Teacher Update" Page.
        /// </summary>
        /// 
        /// <param name="id">Teacher id</param>
        /// 
        /// <returns>"Update Teacher" webpage which provides the current information of the teacher and asks the user for new information as part of a form.</returns>
        /// 
        /// <example>GET : /Teacher/Update/2</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        /// <summary>
        /// Receives a POST request which contains new values of the teacher of existing teacher and redirects that to the Teacher Show page. 
        /// </summary>
        /// <param name="id">Id of the teacher to update</param>
        /// <param name="TeacherFname">The updated first name of the teacher</param>
        /// <param name="TeacherLname">The updated last name of the teacher</param>
        /// <param name="EmployeeNumber">The updated employee number of the teacher.</param>
        /// <param name="Salary">The updated salary of the teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/2
        /// {
        ///	    "TeacherFname":"Linda",
        ///	    "TeacherLname":"Chan",
        ///	    "EmployeeNumber":"T382",
        ///	    "Salary":"89.22"             // updating the salary
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {
            Teacher TeachrInfo = new Teacher();
            TeachrInfo.TeacherFname = TeacherFname;
            TeachrInfo.TeacherLname = TeacherLname;
            TeachrInfo.EmployeeNumber = EmployeeNumber;
            TeachrInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeachrInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}