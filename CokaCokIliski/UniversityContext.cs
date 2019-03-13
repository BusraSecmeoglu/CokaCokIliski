namespace CokaCokIliski
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("name=UniversiteContext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }

    [Table("Student")]
    public class Student
    {
        public Student()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

       //public int TeacherId { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public override string ToString()
        {
            return this.StudentName + ' ' + this.StudentSurname;
        }
    }

    [Table("Teacher")]
    public class Teacher
    {
        public Teacher()
        {
            this.Students = new HashSet<Student>();
        }
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        //public int StudentId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}