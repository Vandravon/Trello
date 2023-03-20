using System;
using System.Collections.Generic;

namespace Trellov2.Models;

public partial class Commentaire
{
    public int IdCommentaire { get; set; }

    public string? Contenu { get; set; }

    public DateTime DateCreation { get; set; }

    public int IdCarte { get; set; }

    public int IdUtilisateur { get; set; }

    public virtual Carte IdCarteNavigation { get; set; } = null!;

    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;

    public Commentaire() {
        this.IdCommentaire = 0;
    }

    public Commentaire(string contenu, Carte idCarteNavigation, Utilisateur idUtilisateurNavigation, DateTime dateCreation = default)
	{
        this.IdCommentaire = 0;
		this.Contenu = contenu;
		this.DateCreation = dateCreation;
		this.IdCarteNavigation = idCarteNavigation;
		this.IdCarte = idCarteNavigation.IdCarte;
		this.IdUtilisateurNavigation = idUtilisateurNavigation;
		this.IdUtilisateur = idUtilisateurNavigation.IdUtilisateur;
	}
    	public Carte GetCarte()
	{
		return this.IdCarteNavigation;
	}

	public Utilisateur GetUtilisateur()
	{
		return this.IdUtilisateurNavigation;
	}
    
}
