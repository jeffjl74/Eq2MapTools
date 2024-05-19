using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EQ2MapTools
{
    public partial class FormLogOrder : Form
    {
        List<string> logFiles = new List<string>();

        public FormLogOrder()
        {
            InitializeComponent();
        }

        public FormLogOrder(List<string> files)
        {
            InitializeComponent();
            logFiles = files;
        }

        private void FormLogOrder_Load(object sender, EventArgs e)
        {
            foreach (string file in logFiles)
            {
                listView1.Items.Add(file);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item != null)
                listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse pointer.
            Point targetPoint =
                listView1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the index of the item closest to the mouse pointer.
            int targetIndex = listView1.InsertionMark.NearestIndex(targetPoint);

            // Confirm that the mouse pointer is not over the dragged item.
            if (targetIndex > -1)
            {
                // Determine whether the mouse pointer is to the left or
                // the right of the midpoint of the closest item and set
                // the InsertionMark.AppearsAfterItem property accordingly.
                Rectangle itemBounds = listView1.GetItemRect(targetIndex);
                if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    listView1.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    listView1.InsertionMark.AppearsAfterItem = false;
                }
            }

            // Set the location of the insertion mark. If the mouse is
            // over the dragged item, the targetIndex value is -1 and
            // the insertion mark disappears.
            listView1.InsertionMark.Index = targetIndex;
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            listView1.InsertionMark.Index = -1;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the index of the insertion mark;
            int targetIndex = listView1.InsertionMark.Index;

            // If the insertion mark is not visible, exit the method.
            if (targetIndex == -1)
            {
                return;
            }

            // If the insertion mark is to the right of the item with
            // the corresponding index, increment the target index.
            if (listView1.InsertionMark.AppearsAfterItem)
            {
                targetIndex++;
            }

            // Retrieve the dragged item.
            if (e == null || e.Data == null)
                return;

            ListViewItem? draggedItem = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
            if (draggedItem == null)
                return;

            // Insert a copy of the dragged item at the target index.
            // A copy must be inserted before the original item is removed
            // to preserve item index values. 
            listView1.Items.Insert(
                targetIndex, (ListViewItem)draggedItem.Clone());

            // Remove the original copy of the dragged item.
            listView1.Items.Remove(draggedItem);

            // fix the list
            logFiles.Clear();
            foreach (ListViewItem item in listView1.Items)
                logFiles.Add(item.Text);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if(e == null || e.Graphics == null || e.Bounds == Rectangle.Empty)
                return;
            Graphics g = e.Graphics;    //alias these while the interpreter knows they are not null
            Rectangle rect = e.Bounds;

            g.FillRectangle(Brushes.LightBlue, rect); //Fill header with color

            //Adjust the position of the text to be vertically centered
            string? header = e?.Header?.Text;
            if (header == null)
                header = "File";
            int yOffset = (rect.Height - g.MeasureString(header, listView1.Font).ToSize().Height) / 2;
            Rectangle newBounds = new Rectangle(rect.X, rect.Y + yOffset, rect.Width, rect.Height - yOffset);

            g.DrawString(header, listView1.Font, Brushes.Black, newBounds);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }

}
