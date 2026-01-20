using System.ComponentModel.DataAnnotations;

namespace CRUD_ADO.Models
{
    public class Student
    {
        public int Id { get; set; }  
     
        public String Name { get; set; }
        public String Email { get; set;  }

        public string Phone { get; set;  }
        public int Age { get; set; }

        public string Gender { get; set; }    

        [Required]
        public int DeptId { get; set; }


    }
}
