namespace CRUD_ADO.Models
{
    public class StudentViewModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }    

        public string Email { get; set; }

        public string Phone { get; set; }   

        public int Age { get; set; }    

        public int DeptId { get; set;  }
         
        public string Gender { get; set; }

        public int isActive     { get; set; }   
        public string DepartmentName {  get; set; } 
        
    }
}
