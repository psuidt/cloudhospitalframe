using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EfwControls.HISControl.BedCard.Controls
{
    internal class BedItem : UserControl
    {
        public int BedIndex { get; set; }

        public BedInfo Bed { get; set; }
    }
}
