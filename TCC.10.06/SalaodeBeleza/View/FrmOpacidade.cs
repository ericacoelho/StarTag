using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace SalaodeBeleza
{
    public partial class FrmOpacidade : Form
    {
        public FrmOpacidade()
        {
            InitializeComponent();
        }

        private void FrmOpacidade_Load(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        //private void FrmOpacidade_Load(object sender, EventArgs e)
        //{
        //    SolidColorBrush mySolidColorBrush = new SolidColorBrush(Colors.Gray);
        //    mySolidColorBrush.Opacity = 0.25;
        //    FrmOpacidade.mySolidColorBrush();
        //}

        //private static void mySolidColorBrush()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
