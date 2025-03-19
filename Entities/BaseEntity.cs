using System.ComponentModel.DataAnnotations;

namespace DigitalStudentArtGallery.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
