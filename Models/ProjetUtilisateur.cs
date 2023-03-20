using System;
using System.Collections.Generic;

namespace Trellov2.Models;

public class ProjetUtilisateur 
{

    public int IdProjet {get; set;}
    public Projet projetNav {get; set;}
    public int IdUtilisateur {get; set;}
    public Utilisateur UtilisateurNav {get; set;}
    public virtual List<Utilisateur> Utilisateurs { get; } = new ();
    public virtual List<Projet> Projets { get; } = new ();

    public ProjetUtilisateur()
    {

    }

    public ProjetUtilisateur(Projet projet, Utilisateur utilisateur)
    {
        this.projetNav = projet;
        this.IdProjet = projet.IdProjet;
        this.UtilisateurNav = utilisateur;
        this.IdUtilisateur = utilisateur.IdUtilisateur;
    }    

    public List<Utilisateur> GetUtilisateurs()
	{
		return this.Utilisateurs;
	}

    public List<Projet> GetProjets()
	{
		return this.Projets;
	}

}