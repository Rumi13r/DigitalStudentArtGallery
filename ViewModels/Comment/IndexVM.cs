namespace DigitalStudentArtGallery.ViewModels.Comment
{
    public class IndexVM
    {
        public List<DigitalStudentArtGallery.Entities.PostsEntities> Posts { get; set; }
        public List<DigitalStudentArtGallery.Entities.CommentsEntities> Comments { get; set; }

        public int Id { get; set; }
    }
}
