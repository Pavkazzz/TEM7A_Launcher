using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher.Module.Document
{
    public partial class PDFViewer : UserControl
    {
        public PDFViewer(string _fileName)
        {
            InitializeComponent();
            this.axAcroPDF1.LoadFile(_fileName);
        }
    }
}
