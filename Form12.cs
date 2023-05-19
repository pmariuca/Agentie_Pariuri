using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agentie_Pariuri
{
    public partial class Form12 : Form
    {
        public bool IsImageDropAllowed
        {
            get { return userControl11.IsImageDropAllowed; }
            set { userControl11.SetImageDropAllowed(value); }
        }

        public Form12()
        {
            InitializeComponent();
        }
    }
}
