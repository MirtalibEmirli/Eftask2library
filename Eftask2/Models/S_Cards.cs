namespace Eftask2.Models
{
    public class S_Cards : BaseEntity
    {
        public int Id_Student { get; set; }
        public int Id_Book { get; set; }
        public int Id_Lib { get; set; }
        public DateOnly DateIn { get; set; }
        public DateOnly DateOut { get; set; }

        public Book Book { get; set; }
        public Librarian Lib { get; set; }
        public Student Student { get; set; }

    }
}