namespace Models
{
    [Table("Biljka")]
    public class Biljka
    {
        [Key]
        public int ID {get;set;}

        [Required]
        public string? Naziv {get;set;}

        [Required]
        public int Cena {get;set;}

        [Required]
        public bool DaLiCveta {get;set;}

        [Required]
        public string? List {get;set;}

        [Required]
        public string? DrvenastaZeljasta {get;set;}

        [Required]
        public int ZivotniVek {get;set;}

        [Required]
        public int Zaliha {get;set;}

        public string? Slika {get;set;}

        [JsonIgnore]
        [Required]
        public Sajt? SajtId {get;set;}

        public List<KomentarIOcena>? KomentariIOcene {get;set;}
    }
}