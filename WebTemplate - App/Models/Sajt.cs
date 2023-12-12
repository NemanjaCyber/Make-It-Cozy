namespace Models
{
    [Table("Sajt")]
    public class Sajt
    {
        [Key]
        public int ID {get;set;}
        [Required]
        public string? Naziv {get;set;}
        public List<Biljka>? Biljke {get;set;}
        public List<Lampa>? Lampe {get;set;}
        public List<Saksija>? Saksije {get;set;}
    }
}