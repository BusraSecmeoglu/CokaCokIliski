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
    public partial class FormTeacher : Form
    {
        UniversityContext db = new UniversityContext();

        public FormTeacher()
        {
            InitializeComponent();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            lists();

        }


        private void lists()
        {
            var list = db.Teachers.Select(x => new
            {
                x.TeacherId,
                x.TeacherName,
                x.TeacherSurname
            }).ToList();
            dataGridView1.DataSource = list;
            txtTeacherName.Clear();
            txtTeacherName.Focus();
            txtTeacherSurname.Clear();
            txtTeacherSurname.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Teacher teacher = new Teacher();
            teacher.TeacherName = txtTeacherName.Text;
            teacher.TeacherSurname = txtTeacherSurname.Text;
            db.Teachers.Add(teacher);
            db.SaveChanges();
            lists();
        }
    }

}
