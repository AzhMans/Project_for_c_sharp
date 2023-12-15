namespace WebApplication1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Biography { get; set; }

        public string PlotFieldExpert{ get; set; }
    
        public ICollection<Book> Books { get; set; }
    }

}
