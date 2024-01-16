
using System.ComponentModel.DataAnnotations;

namespace TestApiMovie.Contract.Request
{
    public class UpsertCategoryRequest
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryDescription { get; set; }
    }
}
