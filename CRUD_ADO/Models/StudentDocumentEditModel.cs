namespace CRUD_ADO.Models
{
    public class StudentDocumentEditModel
    {
         public int StudentId { get; set; } 
         
        public int DocId { get; set; }   

        public IFormFile DocFile { get; set; }  
    }
}
