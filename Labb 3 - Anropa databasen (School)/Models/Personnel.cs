using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen__School_.Models
{
    public partial class Personnel
    {
        public int PersonnelId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Position { get; set; }
    }
}
