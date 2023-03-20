using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trellov2.Models;

public partial class TrelloContext : DbContext
{
    public TrelloContext()
    {
        /*Database.EnsureDeleted();
        Database.EnsureCreated();
        Console.WriteLine("DB lancée!");

        Utilisateur SU = new Utilisateur("Vincent", "vincent@dupont.com", "1234");
        Utilisateurs.Add(SU);
        SaveChanges();

        Projet projetBase = new Projet("Premier projet", "Tout premier projet");
        Projets.Add(projetBase);
        SaveChanges();

        ProjetUtilisateur tableLiaison = new ProjetUtilisateur(projetBase, SU);
        ProjetUtilisateurs.Add(tableLiaison);
        SaveChanges();

        Liste listeUne = new Liste("Premiere liste", projetBase);
        Listes.Add(listeUne);
        SaveChanges();

        Liste listeDeux = new Liste("Deuxième liste", projetBase);
        Listes.Add(listeDeux);
        SaveChanges();

        Carte carteUn = new Carte("Carte 1", "Je suis la carte 1", listeUne);
        Cartes.Add(carteUn);
        SaveChanges();

        Carte carteDeux = new Carte("Carte 2", "Je suis la carte 2", listeUne);
        Cartes.Add(carteDeux);
        SaveChanges();

        Carte carteTrois = new Carte("Carte 3", "Je suis la carte 3", listeUne);
        Cartes.Add(carteTrois);
        SaveChanges();



        Utilisateur test = new Utilisateur("test", "test@test", "1234");
        Utilisateurs.Add(test);
        SaveChanges();

        Projet projetTest = new Projet("Test projet", "Tout premier test");
        Projets.Add(projetTest);
        SaveChanges();

        ProjetUtilisateur tableLiaisonTest = new ProjetUtilisateur(projetTest, test);
        ProjetUtilisateurs.Add(tableLiaisonTest);
        SaveChanges();

        Liste listeTest = new Liste("Test liste", projetTest);
        Listes.Add(listeTest);
        SaveChanges();

        Carte carteTest = new Carte("Carte test", "Je suis la carte test", listeTest);
        Cartes.Add(carteTest);
        SaveChanges();*/

    }

    public virtual DbSet<Carte> Cartes { get; set; }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Etiquette> Etiquettes { get; set; }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<ProjetUtilisateur> ProjetUtilisateurs {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;database=trellodos;user=root;password=admin1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carte>(entity =>
        {
            entity.HasKey(e => e.IdCarte).HasName("PRIMARY");
            entity.HasOne(d => d.IdListeNavigation).WithMany(p => p.Cartes)
                .HasForeignKey(d => d.IdListe);
        });

        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.HasKey(e => e.IdCommentaire).HasName("PRIMARY");
            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.IdCommentaires)
                .HasForeignKey(d => d.IdCarte);

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.IdCommentaires)
                .HasForeignKey(d => d.IdUtilisateur);
        });

        modelBuilder.Entity<Etiquette>(entity =>
        {
            entity.HasKey(e => e.IdEtiquette).HasName("PRIMARY");
            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.IdEtiquettes)
                .HasForeignKey(d => d.IdCarte);
        });

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.HasKey(e => e.IdListe).HasName("PRIMARY");
            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.IdListes)
                .HasForeignKey(d => d.IdProjet);
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.IdProjet).HasName("PRIMARY");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PRIMARY");
        });

        modelBuilder.Entity<ProjetUtilisateur>(entity =>
        {
            entity.HasKey(e => new { e.IdProjet, e.IdUtilisateur}).HasName("PRIMARY");
            entity.HasOne(e => e.projetNav).WithMany(e => e.ProjetUtilisateurs);
            entity.HasOne(e => e.UtilisateurNav).WithMany(e => e.ProjetUtilisateurs);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
