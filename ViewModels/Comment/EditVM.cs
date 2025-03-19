namespace DigitalStudentArtGallery.ViewModels.Comment
{
    public class EditVM
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int Id { get; internal set; }
        public object Title { get; internal set; }
        public object Description { get; internal set; }
        public object Type { get; internal set; }
    }
}
