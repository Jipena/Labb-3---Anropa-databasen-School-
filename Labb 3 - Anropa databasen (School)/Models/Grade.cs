using System;
using System.Collections.Generic;

namespace Labb_3___Anropa_databasen__School_.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int? Grade1 { get; set; }
        public DateTime? DateOfGrade { get; set; }
        public int? FkSubjectId { get; set; }
        public int? FkStudentId { get; set; }

        public virtual Student? FkStudent { get; set; }
        public virtual Subject? FkSubject { get; set; }
    }
}
