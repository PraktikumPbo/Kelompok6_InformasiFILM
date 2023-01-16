namespace ASPFILM.Models
{
    public class UpdateFilmViewModel
    {
        public Guid Id { get; set; }
        public string Judul { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Durasi { get; set; }
        public string Rilis { get; set; }
        public string Sinopsis { get; set; }
    }
}
