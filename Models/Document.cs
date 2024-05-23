namespace document_manager_asp.net.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumPages { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }

        public Document()
        {
        }
    }
}
