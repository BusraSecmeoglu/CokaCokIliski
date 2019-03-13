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
    public partial class FormAccociate : Form
    {
        UniversityContext db = new UniversityContext();
        private List<Student> student;
        private Teacher teacher;
        int selectedId;

        public FormAccociate()
        {
            InitializeComponent();
            db = new UniversityContext();
            teacher = null;
            student = new List<Student>();
        }


        private void FormAccociate_Load(object sender, EventArgs e)
        {
            TeacherFill();
            StudentFill();

        }


        private void btnIlişkilendir_Click(object sender, EventArgs e)
        {

            foreach (int index in listBox1.SelectedIndices)
            {
                teacher.Students.Add(student[index]);
            }

            db.SaveChanges();
            StudentFill();
            TeacherFill();
            DgvAccociateFill();
        }



        private void ComboLists()
        {
            var list = db.Teachers.Select(x => new
            {
                x.TeacherName,
                x.TeacherId
            }).OrderBy(x => x.TeacherName).ToList();

            comboBox1.DisplayMember = "TeacherName";
            comboBox1.DataSource = list;
        }
        private void ListBoxLists()
        {
            var list = db.Students.Select(x => new
            {
                x.StudentName,
                x.StudentSurname,

            }).ToList();
            listBox1.DataSource = list;
            listBox1.DisplayMember = "StudentName";
            listBox1.ValueMember = "StudentSurname";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            teacher = (Teacher)comboBox1.SelectedItem;
            dataGridView1.DataSource = teacher.Students.ToList();
            StudentFill();
        }

        private void TeacherFill()
        {
            //var list = _db.Teachers.Select(x => new
            //{
            //    x.TeacherId,
            //    x.TeacherName,
            //    x.TeacherSurName

            //}).OrderBy(x => x.TeacherId).ToList();
            //comboBox1.DisplayMember = "TeacherName";
            //comboBox1.ValueMember = "TeacherId";
            //comboBox1.DataSource = list;

            comboBox1.DisplayMember = "TeacherName";
            comboBox1.ValueMember = "TeacherId";
            comboBox1.DataSource = db.Teachers.ToList();
        }
        private void StudentFill()
        {
            listBox1.Items.Clear();
            student = db.Students.ToList();
            student.ForEach(o => listBox1.Items.Add(o.ToString()));
        }


        private void DgvAccociateFill()
        {
            dataGridView1.DataSource = teacher.Students.ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

    }
}
