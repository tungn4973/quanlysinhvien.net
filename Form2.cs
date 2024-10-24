using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
        }
        // Danh sách sinh viên
        private List<Student> studentList = new List<Student>();

        // Tải dữ liệu mẫu
        private void LoadData()
        {
            studentList.Add(new Student { Id = "SV001", Name = "Nguyen Van A", Class = "Lop 12A1" });
            studentList.Add(new Student { Id = "SV002", Name = "Le Thi B", Class = "Lop 12A2" });

            dgvStudents.DataSource = null;
            dgvStudents.DataSource = studentList;
        }

        // Nút "Thêm"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student newStudent = new Student
            {
                Id = txtStudentId.Text,
                Name = txtStudentName.Text,
                Class = txtStudentClass.Text
            };

            studentList.Add(newStudent);
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = studentList;
        }

        // Nút "Sửa"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                Student selectedStudent = dgvStudents.SelectedRows[0].DataBoundItem as Student;

                selectedStudent.Id = txtStudentId.Text;
                selectedStudent.Name = txtStudentName.Text;
                selectedStudent.Class = txtStudentClass.Text;

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentList;
            }
        }

        // Nút "Xóa"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                Student selectedStudent = dgvStudents.SelectedRows[0].DataBoundItem as Student;
                studentList.Remove(selectedStudent);

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentList;
            }
        }

        // Sự kiện chọn hàng
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                Student selectedStudent = dgvStudents.SelectedRows[0].DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    txtStudentId.Text = selectedStudent.Id;
                    txtStudentName.Text = selectedStudent.Name;
                    txtStudentClass.Text = selectedStudent.Class;
                }
            }
        }

    }
}
