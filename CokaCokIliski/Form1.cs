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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStudent student = new FormStudent();
            student.Show();
        }

        private void eğitmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTeacher teacher = new FormTeacher();
            teacher.Show();
        }

        private void eğitmenÖğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccociate accociate = new FormAccociate();
            accociate.Show();
        }
    }
}
