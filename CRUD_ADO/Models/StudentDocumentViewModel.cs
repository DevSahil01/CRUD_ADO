namespace CRUD_ADO.Models
{
    public class StudentDocumentViewModel
    {
        public int StudentId { get; set; }  
        public int DocumentId { get; set; }  
        public string DocumentName { get; set; }    

        public string FilePath { get; set; }    
        public string FileName { get; set; }

    }
}
