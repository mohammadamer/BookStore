using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }

    }
}
