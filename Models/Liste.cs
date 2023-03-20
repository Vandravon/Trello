using System;
using System.Collections.Generic;

namespace Trellov2.Models;

public partial class Liste
{
    public int IdListe { get; set; }

    public string Nom { get; set; } = null!;

    public virtual List<Carte> Cartes { get; } = new List<Carte>();

    public int? IdProjet { get; set; }

    public virtual Projet? IdProjetNavigation { get; set; } = null!;

    public Liste()
	{

    }
    public Liste(string nom, Projet projet)
	{
		this.Nom = nom;
		this.IdProjetNavigation = projet;
		this.IdProjet = projet.IdProjet;
		projet.IdListes.Add(this);
	}

    	public void AddCarte(Carte carte)
	{
		this.Cartes.Add(carte);
		carte.IdListeNavigation = this;
		carte.IdListe = this.IdListe;
	}

	public void RemoveCarte(Carte carte)
	{
		this.Cartes.Remove(carte);
		carte.IdListeNavigation = null!;
		carte.IdListe = 0;
	}

	public void SetProjet(Projet projet)
	{
		this.IdProjetNavigation = projet;
		this.IdProjet = projet.IdProjet;
	}

	public void RemoveProjet()
	{
		this.IdProjetNavigation = null;
		this.IdProjet = 0;
	}

	public List<Carte> GetCartes()
	{
		return this.Cartes;
	}

	public void insertCarte(Carte carte, int index)
	{
		this.Cartes.Insert(index, carte);
		carte.IdListeNavigation = this;
		carte.IdListe = this.IdListe;
	}
    
}
