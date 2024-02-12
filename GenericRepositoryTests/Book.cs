using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryTests
{
    public class Book : IIdable
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
    }
}
