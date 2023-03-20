namespace Trellov2.Models;

public partial class Carte
{
    public int IdCarte { get; set; }

    public string? Titre { get; set; }

    public string? Description { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual List<Commentaire> IdCommentaires { get; } = new List<Commentaire>();

    public virtual List<Etiquette> IdEtiquettes { get; } = new List<Etiquette>();

    public int IdListe { get; set; }

    public virtual Liste IdListeNavigation { get; set; } = null!;

    public Carte()
    {

    }

    public Carte(string titre, string? description, Liste liste)
    {
        this.Titre = titre;
        this.Description = description;
        this.DateCreation = DateTime.Now;
		this.IdListeNavigation = liste;
		this.IdListe = liste.IdListe;
    }


    public void addCommentaire(Commentaire newCommentaire)
	{
		this.IdCommentaires.Add(newCommentaire);
	}

    public void removeCommentaire(Commentaire oldCommentaire)
	{
		this.IdCommentaires.Remove(oldCommentaire);
	}

    public void addEtiquette(Etiquette newEtiquette)
	{
		this.IdEtiquettes.Add(newEtiquette);
	}

    public void removeEtiquette(Etiquette oldEtiquette)
	{
		this.IdEtiquettes.Remove(oldEtiquette);
	}

    	public void changeTitre(string newTitre)
	{
		this.Titre = newTitre;
	}

	public void changeDescription(string newDescription)
	{
		this.Description = newDescription;
	}

	public List<Commentaire> GetCommentaires()
	{
		return this.IdCommentaires;
	}

	public List<Etiquette> GetEtiquettes()
	{
		return this.IdEtiquettes;
	}

    
}
