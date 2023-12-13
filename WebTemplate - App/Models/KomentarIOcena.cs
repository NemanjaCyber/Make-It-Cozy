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
        [JsonIgnore]
        public Lampa? Lampa {get;set;}
        [JsonIgnore]
        public Saksija? Saksija{get;set;}
    }
}