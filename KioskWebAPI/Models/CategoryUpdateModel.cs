namespace KioskWebAPI.Models
{
    public class CategoryUpdateModel
    {
        //public int CategoryId { get; set; }
        public string? CatEng { get; set; }
        public string? CatSin { get; set; }
        public string? CatTam { get; set; }
        public int ModifiedBy { get; set; }

       
        public string? ImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}