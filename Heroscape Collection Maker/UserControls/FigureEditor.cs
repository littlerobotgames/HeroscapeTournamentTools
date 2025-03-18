using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heroscape_Collection_Maker.UserControls
{
    public partial class FigureEditor : UserControl
    {
        public int cardId = 0;
        public string cardName = string.Empty;
        public int amount = 0;
        public FigureEditor(int _id, string _cardName, int _amount)
        {
            InitializeComponent();
            
            cardId = _id;
            cardName = _cardName;
            amount = _amount;

            labelName.Text = cardName;
            numericUpDownAmount.Value = amount;
        }

        private void amountChanged(object sender, EventArgs e)
        {
            amount = Convert.ToInt32(numericUpDownAmount.Value);
        }
        public void SetAmount(int _amount)
        {
            amount = _amount;
            numericUpDownAmount.Value = amount;
        }
    }
}
