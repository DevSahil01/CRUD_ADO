namespace CRUD_ADO.Models
{
    public class StudentCreateViewModel
    {
         public Student student {  get; set; }

        public List<int> SelectedDocuments { get; set; }    
         public List<IFormFile> DocumentFiles { get; set; }   
    }
}
