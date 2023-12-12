namespace Models
{
    [Table("KomentariIOcena")]
    public class KomentarIOcena
    {
        [Key]
        public int ID {get;set;}

        [Required]
        public string? Komentar {get;set;}

        [Required]
        public int Ocena {get;set;}

        [JsonIgnore]
        public Biljka? Biljka {get;set;}
        public Lampa? Lampa {get;set;}
        public Saksija? Saksija{get;set;}
    }
}