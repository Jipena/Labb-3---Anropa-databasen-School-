using Labb_3___Anropa_databasen__School_.Data;
using Labb_3___Anropa_databasen__School_.Models;

namespace Labb_3___Anropa_databasen__School_
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("1. Hämta personal (SQL)");
            Console.WriteLine("2. Hämta alla elever (EF)");
            Console.WriteLine("3. Hämta alla elever i en viss klass (EF)");
            Console.WriteLine("4. Hämta alla betyg som satts den senaste månaden (SQL)");
            Console.WriteLine("5. Hämta en lista med alla kurser ach det snittbetyg som eleverna fått på den kursen" +
                   "samt det högsta och lägsta betyget som någon fått i kursen (SQL)");
            Console.WriteLine("6. Lägga till nya elever (SQL)");
            Console.WriteLine("7. Lägga till ny personal (EF)");

            Console.WriteLine();
            Console.WriteLine("Make a Choice between 1 and 7!");
            int menuChoice = Convert.ToInt32(Console.ReadLine());

            if (menuChoice >= 1 | menuChoice <= 7)
            {
                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. Alla anställda");
                        Console.WriteLine("2. Anställda Lärare");
                        Console.WriteLine("3. Anställda Rektorer");
                        Console.WriteLine("4. Anställda Administratörer");
                        Console.WriteLine();
                        Console.WriteLine("Make a choice between 1 and 4!");
                        int menuChoice2 = Convert.ToInt32(Console.ReadLine());
                        if (menuChoice2 >= 1 | menuChoice2 <= 4)
                        {
                            switch (menuChoice2)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("//Select * from Personnel");
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("//Select * from Personnel p \r\nwhere p.Position = 'Teacher'");
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("//Select * from Personnel p \r\nwhere p.Position = 'Principal'");
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("//Select * from Personnel p \r\nwhere p.Position = 'Administrator'");
                                    break;
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("1. Sortera Elever");
                        Console.WriteLine("3. Return");
                        Console.WriteLine();
                        Console.WriteLine("Make a choice between 1 and 2!");
                        int menuChoice3 = Convert.ToInt32(Console.ReadLine());
                        if (menuChoice3 == 1 | menuChoice3 == 2)
                        {
                            switch (menuChoice3)
                            {
                                case 1:
                                    Console.Clear();
                                    using (var context1 = new SchoolContext())
                                    {
                                        Console.WriteLine("1. Sortera på Förnamn Ascending");
                                        Console.WriteLine("2. Sortera på Förnamn Descending");
                                        Console.WriteLine("3. Sortera på Efternamn Ascending");
                                        Console.WriteLine("4. Sortera på Efternamn Descending");
                                        Console.WriteLine("Gör ett val");
                                        int Userinput = Convert.ToInt32(Console.ReadLine());
                                        if (Userinput == 1)
                                        {
                                            var myStudents = from c in context1.Students
                                                             orderby c.FirstName ascending
                                                             select c;

                                            foreach (var student in myStudents)
                                            {
                                                Console.WriteLine(student.FirstName + " " + student.LastName);
                                            }
                                        }
                                        else if (Userinput == 2)
                                        {
                                            var myStudents = from c in context1.Students
                                                             orderby c.FirstName descending
                                                             select c;

                                            foreach (var student in myStudents)
                                            {
                                                Console.WriteLine(student.FirstName + " " + student.LastName);
                                            }
                                        }
                                        else if (Userinput == 3)
                                        {
                                            var myStudents = from c in context1.Students
                                                             orderby c.LastName ascending
                                                             select c;

                                            foreach (var student in myStudents)
                                            {
                                                Console.WriteLine(student.FirstName + " " + student.LastName);
                                            }
                                        }
                                        else if (Userinput == 4)
                                        {
                                            var myStudents = from c in context1.Students
                                                             orderby c.LastName descending
                                                             select c;

                                            foreach (var student in myStudents)
                                            {
                                                Console.WriteLine(student.FirstName + " " + student.LastName);
                                            }
                                        }
                                    }   
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Return");
                                    break;
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("1. Alla klasser");
                        Console.WriteLine("2. Return");
                        Console.WriteLine();
                        Console.WriteLine("Make a choice between 1 and 2!");
                        int menuChoice4 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (menuChoice4 == 1)
                        {
                            List<Class> myClasses = null;
                            using (var context2 = new SchoolContext())
                            {
                                myClasses = context2.Classes.ToList();
                                                

                                foreach (var classes in myClasses)
                                {
                                    Console.WriteLine(classes.ClassName);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Välj en av klasserna för att se vilka elever som går i den");
                            int menuChoice5 = Convert.ToInt32(Console.ReadLine());
                            var classChoice = myClasses.ToArray()[menuChoice5 -1];
                            using (var context3 = new SchoolContext())
                            {
                                var myStudents = from c in context3.Students
                                                 where c.FkClassId == classChoice.ClassId
                                                 select c;
                                
                                foreach (var student in myStudents)
                                {
                                    Console.WriteLine(student.FirstName + " " + student.LastName + " " + classChoice.ClassName);
                                }

                            }
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("4");
                        /*Select 
                        g.Grade,
                        g.DateOfGrade,
                        s.FirstName,
                        s.LastName,
                        sub.SubjectName
                        From Grade g
                        inner join Student s ON s.StudentId = g.FK_StudentId
                        inner join [Subject] sub ON sub.SubjectId = g.FK_SubjectId
                        Where g.DateOfGrade between DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE())-1, 0) And DATEADD(MONTH, DATEDIFF(MONTH, -1, GETDATE())-1, -1)*/
                        break;

                    case 5:
                        Console.WriteLine("5");
                        /*
                        Select s.SubjectName
	                    ,AVG(g.Grade) as AvgGrade
	                    ,MAX(g.Grade) as HighestGrade
	                    ,MIN(g.Grade) as LowestGrade
                        from Grade g
                        inner join [Subject] s ON s.SubjectId = g.FK_SubjectId
                        group by s.SubjectId, s.SubjectName
                         */
                        break;

                    case 6:
                        Console.WriteLine("6");
                        /*
                        Insert into Student (FirstName, LastName, Phone#, City, SocialSecurityNumber, FK_ClassId)
                        Values ('Leif', 'Jansson', '0703322441', 'Sundsvall', '9204231297', 1)
                         */
                        break;

                    case 7:
                        
                        SchoolContext context = new SchoolContext();
                        Personnel p1 = new Personnel();
                        Console.WriteLine("Skriv in förnamn");
                        p1.FirstName = Console.ReadLine();
                        Console.WriteLine("Skriv in efternamn");
                        p1.LastName = Console.ReadLine();
                        Console.WriteLine("Phone#");
                        p1.Phone = Console.ReadLine();
                        Console.WriteLine("Skriv in position");
                        p1.Position = Console.ReadLine();
                        Console.WriteLine("Skriv in Stad");
                        p1.City = Console.ReadLine();

                        //var person = context.Personnel.Find(10);
                        //context.Personnel.Remove(person);
                        context.Personnel.Add(p1);
                        context.SaveChanges();

                        Console.WriteLine("Databasen är uppdaterad");

                        break;
                }
            }
        }
    }
}
