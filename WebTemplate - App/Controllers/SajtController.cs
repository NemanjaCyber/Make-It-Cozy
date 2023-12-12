namespace WebTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class IspitController : ControllerBase
{
    public SajtContext Context { get; set; }

    public IspitController(SajtContext context)
    {
        Context = context;
    }

    [HttpGet("VratiSajtSaSvimKontekstom/{naziv}")]
    public async Task<ActionResult> VratiSajtSaSvimKontekstom(string naziv)
    {
        var podaci=await Context.Sajt!
            .Where(q=>q.Naziv==naziv)
            .Select(x=>new{
                id=x.ID,
                naziv=x.Naziv,
                biljke=x.Biljke,
                lampe=x.Lampe,
                saksije=x.Saksije
            }).ToListAsync();

        return Ok(podaci);
    }

    [HttpPost("DodajBiljku/{naziv}/{cena}/{daLiCveta}/{list}/{drvenastaZeljasta}/{zivotniVek}/{zaliha}/{sajtId}")]
    public async Task<ActionResult> DodajBiljku(string naziv,int cena, bool daLiCveta, string list, string drvenastaZeljasta, int zivotniVek, int zaliha, int sajtId)
    {
        if(cena<0)
        {
            return BadRequest("Nevalidan unos cene.");
        }

        if(zivotniVek<0)
        {
            return BadRequest("Nevalidan zivotni vek.");
        }

        var b=new Biljka();

        b.SajtId=await Context.Sajt!.FindAsync(sajtId);
        b.Naziv=naziv;
        b.Cena=cena;
        b.DaLiCveta=daLiCveta;
        b.List=list;
        b.DrvenastaZeljasta=drvenastaZeljasta;
        b.ZivotniVek=zivotniVek;
        b.Zaliha=zaliha;

        try
        {
            Context.Biljke!.Add(b);
            await Context.SaveChangesAsync();
            return Ok(b);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPut("KupiLampu/{lampaNaziv}")]
    public async Task<ActionResult> KupiLampu(string lampaNaziv)
    {
        var l=await Context.Lampe!.Where(p=>p.Naziv==lampaNaziv).FirstOrDefaultAsync();
        if(l==null)
        {
            return BadRequest("Lampa ne postoji");
        }

        if(l.Zaliha<0)
        {
            return BadRequest("Nema vise na stanju");
        }

        l.Zaliha--;
        try
        {
            Context.Lampe!.Update(l);
            await Context.SaveChangesAsync();
            return Ok(l);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("KupiSaksiju/{saksijaNaziv}")]
    public async Task<ActionResult> KupiSaksiju(string saksijaNaziv)
    {
        var l=await Context.Saksije!.Where(p=>p.Naziv==saksijaNaziv).FirstOrDefaultAsync();
        if(l==null)
        {
            return BadRequest("Saksija ne postoji");
        }

        if(l.Zaliha<0)
        {
            return BadRequest("Nema vise na stanju");
        }

        l.Zaliha--;
        try
        {
            Context.Saksije!.Update(l);
            await Context.SaveChangesAsync();
            return Ok(l);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("KupiBiljku/{biljkaNaziv}")]
    public async Task<ActionResult> KupiBiljku(string biljkaNaziv)
    {
        var l=await Context.Biljke!.Where(p=>p.Naziv==biljkaNaziv).FirstOrDefaultAsync();
        if(l==null)
        {
            return BadRequest("Biljka ne postoji");
        }

        if(l.Zaliha<0)
        {
            return BadRequest("Nema vise na stanju");
        }

        l.Zaliha--;
        try
        {
            Context.Biljke!.Update(l);
            await Context.SaveChangesAsync();
            return Ok(l);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("OstaviKomentarIOcenuBiljka/{komentar}/{ocena}/{biljkaId}")]
    public async Task<ActionResult> OstaviKomentarIOcenuBiljka(string komentar, int ocena, int biljkaId)
    {
        if(ocena <1 || ocena >5 )
        {
            return BadRequest("Nevalidna ocena");
        }

        var kio=new KomentarIOcena();
        kio.Komentar=komentar;
        kio.Ocena=ocena;
        kio.Biljka=await Context.Biljke!.Where(p=>p.ID==biljkaId).FirstOrDefaultAsync();
        kio.Lampa=null;
        kio.Saksija=null;
        try
        {
            Context.KomentarIOcena!.Add(kio);
            await Context.SaveChangesAsync();
            return Ok(kio);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("OstaviKomentarIOcenuLampa/{komentar}/{ocena}/{lampaId}")]
    public async Task<ActionResult> OstaviKomentarIOcenuLampa(string komentar, int ocena, int lampaId)
    {
        if(ocena <1 || ocena >5 )
        {
            return BadRequest("Nevalidna ocena");
        }

        var kio=new KomentarIOcena();
        kio.Komentar=komentar;
        kio.Ocena=ocena;
        kio.Lampa=await Context.Lampe!.Where(p=>p.ID==lampaId).FirstOrDefaultAsync();
        kio.Biljka=null;
        kio.Saksija=null;
        try
        {
            Context.KomentarIOcena!.Add(kio);
            await Context.SaveChangesAsync();
            return Ok(kio);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("OstaviKomentarIOcenuSaksija/{komentar}/{ocena}/{saksijaId}")]
    public async Task<ActionResult> OstaviKomentarIOcenuSaksija(string komentar, int ocena, int saksijaId)
    {
        if(ocena <1 || ocena >5 )
        {
            return BadRequest("Nevalidna ocena");
        }

        var kio=new KomentarIOcena();
        kio.Komentar=komentar;
        kio.Ocena=ocena;
        kio.Saksija=await Context.Saksije!.Where(p=>p.ID==saksijaId).FirstOrDefaultAsync();
        kio.Lampa=null;
        kio.Biljka=null;
        try
        {
            Context.KomentarIOcena!.Add(kio);
            await Context.SaveChangesAsync();
            return Ok(kio);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("VratiRatingZaBiljku/{biljkaId}")]
    public async Task<ActionResult> VratiRatingZaBiljku(int biljkaId)
    {
        var podaci=await Context.KomentarIOcena!
            .Where(p=>p.Biljka!.ID==biljkaId)
            .Select(x=>new{
                komentar=x.Komentar,
                ocena=x.Ocena
            }).ToListAsync();
        
        return Ok(podaci);
    }

    [HttpGet("VratiRatingZaSaksiju/{saksijaId}")]
    public async Task<ActionResult> VratiRatingZaSaksiju(int saksijaId)
    {
        var podaci=await Context.KomentarIOcena!
            .Where(p=>p.Saksija!.ID==saksijaId)
            .Select(x=>new{
                komentar=x.Komentar,
                ocena=x.Ocena
            }).ToListAsync();
        
        return Ok(podaci);
    }

    [HttpGet("VratiRatingZaLampu/{lampaId}")]
    public async Task<ActionResult> VratiRatingZaLampu(int lampaId)
    {
        var podaci=await Context.KomentarIOcena!
            .Where(p=>p.Lampa!.ID==lampaId)
            .Select(x=>new{
                komentar=x.Komentar,
                ocena=x.Ocena
            }).ToListAsync();
        
        return Ok(podaci);
    }
}
