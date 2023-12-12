namespace Models
{
    [Table("Saksija")]
    public class Saksija
    {
        [Key]
        public int ID {get;set;}

        [Required]
        public string? Naziv {get;set;}

        [Required]
        public int Cena {get;set;}

        [Required]
        public int Visina {get;set;}

        [Required]
        public int Sirina {get;set;}

        [Required]
        public string? Boja {get;set;}

        [Required]
        public string? Materijal {get;set;}

        [Required]
        public int Zaliha {get;set;}

        public string? Slika {get;set;}
        
        [JsonIgnore]
        [Required]
        public Sajt? SajtId {get;set;}

        public List<KomentarIOcena>? KomentariIOcene {get;set;}
    }
}