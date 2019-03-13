using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CokaCokIliski
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        UniversityContext db = new UniversityContext();

        private void FormStudent_Load(object sender, EventArgs e)
        {
            lists();
        }

        public void lists()
        {
            var list = db.Students.Select(x => new
            {
                x.StudentName,
                x.StudentSurname,

            }).ToList();
            dataGridView1.DataSource = list;
            txtStudentName.Clear();
            txtStudentName.Focus();
            txtStudentSurname.Clear();
            txtStudentSurname.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

                Student student = new Student();
                student.StudentName = txtStudentName.Text;
                student.StudentSurname = txtStudentSurname.Text;
                db.Students.Add(student);
                db.SaveChanges();
                lists();
        }
    }
}
