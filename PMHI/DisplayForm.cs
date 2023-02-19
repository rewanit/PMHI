using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMHI
{
    public partial class DisplayForm : Form
    {
        private readonly IEnumerator<ShowModel> showModelsEnumerator;


        public DisplayForm(IEnumerable<ShowModel> showModels)
        {
            InitializeComponent();
            this.showModelsEnumerator = showModels.GetEnumerator();
        }


      




    }
}
