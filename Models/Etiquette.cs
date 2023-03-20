using System;
using System.Collections.Generic;

namespace Trellov2.Models;

public partial class Etiquette
{
    public int IdEtiquette { get; set; }

    public string Nom { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public int IdCarte { get; set; }

    public virtual Carte IdCarteNavigation { get; set; } = null!;

    public Etiquette() {
        this.IdEtiquette = 0;
    }
    	public Etiquette(string nom, string couleur, Carte idCartenavigation)
	{
        this.IdEtiquette = 0;
		this.Nom = nom;
		this.Couleur = couleur;
		this.IdCarteNavigation = idCartenavigation;
		this.IdCarte = idCartenavigation.IdCarte;
	}

	public List<Carte> GetCartes()
	{
		return new List<Carte> { IdCarteNavigation };
	}
    
}
