using System;
using System.Collections.Generic;

namespace Trellov2.Models;

public partial class Projet
{
    public int IdProjet { get; set; }

    public string Nom { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime DateCreation { get; set; }

    public virtual List<Liste> IdListes { get; } = new List<Liste>();

	public virtual List<ProjetUtilisateur> ProjetUtilisateurs { get; } = new();


    public Projet() {
    }


	public Projet(string nom, string? description)
	{
		this.Nom = nom;
		this.Description = description;
		this.DateCreation = DateTime.Now;
	}

	public void AddListe(Liste liste)
	{
		this.IdListes.Add(liste);
		liste.IdProjetNavigation = this;
	}

	public List<Liste> GetListes()
	{
		return this.IdListes;
	}
	public List<ProjetUtilisateur> GetProjetUtilisateurs()
	{
		return this.ProjetUtilisateurs;
	}
    
}
