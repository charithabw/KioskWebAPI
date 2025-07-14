namespace KioskWebAPI.Models
{

    public class CategoryGetModel
    {
        public int CategoryID { get; set; }
        public string? CatEng { get; set; }
        public string? CatSin { get; set; }
        public string? CatTam { get; set; }

        public bool IsActive { get; set; }

        public string? ImagePath { get; set; }

        public int? ModifiedBy { get; set; }

        public int? CreatedBy { get; set; }







    }
}
