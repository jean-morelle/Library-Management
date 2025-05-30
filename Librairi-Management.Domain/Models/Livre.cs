﻿namespace Library_Management.Models
{
    public class Livre
    {
        public Guid Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    }
}
