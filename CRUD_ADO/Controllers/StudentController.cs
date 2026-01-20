using CRUD_ADO.DAL;
using Microsoft.AspNetCore.Mvc;

using CRUD_ADO.Models;
using Microsoft.AspNetCore.Routing.Constraints;
namespace CRUD_ADO.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDAL _dal; 


        //connection string get passed 
        public StudentController(IConfiguration config)
        {
            _dal = new StudentDAL(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            return View(_dal.readAll());
        }


        //Creating the user 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(StudentCreateViewModel vm)
        {
            Console.WriteLine($"FILES COUNT: {Request.Form.Files.Count}");

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Field: {entry.Key}, Error: {error.ErrorMessage}");
                    }
                }
                
                return View(vm);
            }
            
          
            int studentId=  _dal.Insert(vm.student);


            if(vm.SelectedDocuments != null)
            {
                 foreach(var DocId in vm.SelectedDocuments)
                {
                    _dal.InsertStudentDocuments(studentId, DocId);
                }
            }

            //Console.WriteLine(vm.student.DeptId);
            


            if (vm.SelectedDocuments != null && vm.DocumentFiles != null)
            {
                for (int i = 0; i < vm.SelectedDocuments.Count; i++)
                {
                    int docId = vm.SelectedDocuments[i];
                    var file = vm.DocumentFiles[i];

                    if (file != null && file.Length > 0)
                    {
                        string uniqueName = Guid.NewGuid() + "_" + file.FileName;
                        string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                        Directory.CreateDirectory(uploadDir);

                        string fullPath = Path.Combine(uploadDir, uniqueName);

                        using var stream = new FileStream(fullPath, FileMode.Create);
                        file.CopyTo(stream);

                        _dal.InsertStudentDocumentFiles(
                            studentId,
                            docId,
                            file.FileName,
                            "/uploads/" + uniqueName
                        );
                    }
                }
            }


            TempData["Success"] = "Student created successfully";



            return RedirectToAction("Index");
        }

        // Deleting the user 
        public IActionResult Delete(int id)
        {
            var student = _dal.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult delete(Student student)
        {
            var studentInfo = _dal.GetStudentById(student.Id);
            if(studentInfo == null)
            {
                return NotFound(); 
            }
            _dal.DeleteStudent(student); 
            return RedirectToAction("Index");
        }

        //update routes
        public IActionResult Update(int id)
        {
             var student= _dal.GetStudentById(id);
          
             if( student == null)
            {
                return NotFound(); 
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult update(StudentViewModel student)
        {
            Console.WriteLine(student.Gender);
            var studentInfo = _dal.GetStudentById(student.Id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            Student student1 = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Age = student.Age,
                Gender = student.Gender,
                DeptId = student.DeptId,
            };
            _dal.UpdateStudent(student1);
            return RedirectToAction("Index");
        }

        public IActionResult AjaxController()
        {
            return Content("hello from ajax controller ");
        }


        public IActionResult getDepartments()
        {
            var departments = _dal.GetAllDepartments();
            return Json(departments);
        }

        public IActionResult getDocumentTypes()
        {
            var documentTypes = _dal.GetAllDocTypes();

            return Json(documentTypes);
        }

        public IActionResult ViewDocuments(int Id)
        {
            var docs = _dal.GetStudentDocuments(Id);
            return View(docs);
        }

        public IActionResult EditDocumentPage(int DocId,int StudentId)
        {
            return View(new StudentDocumentEditModel { 
                    DocId=DocId,
                    StudentId=StudentId
            }
                );
        }

        [HttpPost]
        public IActionResult EditDocument(StudentDocumentEditModel sd)
        {
            var file = sd.DocFile;
            if (file != null && file.Length > 0)
            {
                string uniqueName = Guid.NewGuid() + "_" + file.FileName;
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadDir);

                string fullPath = Path.Combine(uploadDir, uniqueName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(stream);

                _dal.UpdateStudentDocumentFile(
                    sd.StudentId,
                    sd.DocId,
                    file.FileName,
                    "/uploads/" + uniqueName
                );
            }


            TempData["Success"] = "Document Updated successfully";

            return RedirectToAction("ViewDocuments");
        }
    }
}
