﻿using System.ComponentModel.DataAnnotations;

namespace RazorPagesFeladat.Models
{
    public class BarlangModel
    {

        [Key] public int Id { get; set; }
        public string Nev { get; set; }
        public int Hossz { get; set; }
        public int Kiterjedes { get; set; }
        public int Melyseg { get; set; }
        public int Magassag { get; set; }
        public string Telepules { get; set; }
    }
}
