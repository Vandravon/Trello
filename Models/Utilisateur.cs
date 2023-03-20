using System;
using System.Collections.Generic;

namespace Trellov2.Models;
public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string? AdresseEmail { get; set; }

    public string MotDePasse { get; set; } = null!;

    public DateTime DateInscription { get; set; }

    public virtual List<Commentaire> IdCommentaires { get; } = new List<Commentaire>();

	public virtual List<ProjetUtilisateur> ProjetUtilisateurs { get; } = new();

    public Utilisateur() {
    }

	public Utilisateur(string nom, string email, string motDePasse)
	{
		this.Nom = nom;
		this.AdresseEmail = email;
		this.MotDePasse = motDePasse;
		this.DateInscription = DateTime.Now;
	}

	public List<ProjetUtilisateur> GetProjetUtilisateurs()
	{
		return this.ProjetUtilisateurs;
	}

	public List<Commentaire> GetCommentaires()
	{
		return this.IdCommentaires;
	}

}
