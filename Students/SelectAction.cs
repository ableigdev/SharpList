using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class SelectAction : Form
    {
        private int m_Answer; 
        public SelectAction()
        {
            InitializeComponent();
        }

        public int answer
        {
            get
            {
                return m_Answer;
            }
        }

        private void Button_Group_Click(object sender, EventArgs e)
        {
            m_Answer = 0;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button_Student_Click(object sender, EventArgs e)
        {
            m_Answer = 1;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectAction_Load(object sender, EventArgs e)
        {
            m_Answer = 3; // Unknown answer
        }
    }
}
