using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book 
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
        public bool IsBestSeller { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
