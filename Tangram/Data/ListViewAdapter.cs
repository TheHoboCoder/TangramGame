using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    public class ListViewAdapter
    {
        private int FilteredUserID = 1;


        private const int IMAGE_SIZE = 100;
        private ImageList figureImages;
        private List<ListViewGroup> figureGroups;
        private List<ListViewItem> items;
        private ListView listView;

        public ListViewAdapter(List<FigureGroup> groups, List<Figure> figures, ListView source, int teacherID)
        {
            source.Groups.Clear();
            source.Items.Clear();
            listView = source;
            FilteredUserID = teacherID;

            figureGroups = new List<ListViewGroup>();
            foreach (FigureGroup group in groups)
            {
                AddGroup(group);
            }

            figureImages = new ImageList();
            figureImages.ColorDepth = ColorDepth.Depth24Bit;
            figureImages.ImageSize = new System.Drawing.Size(IMAGE_SIZE, IMAGE_SIZE);

            source.LargeImageList = figureImages;
            items = new List<ListViewItem>();

            foreach (Figure fig in figures)
            {
                AddFigure(fig);
            }

        }


        public void Filter(int groupId)
        {
            listView.Items.Clear();
            ListViewGroup group  = figureGroups.Find(gr => gr.Name == "group_" + groupId.ToString());
            var filteredItems = items.Where(i => i.Group.Equals(group));
            listView.Items.AddRange(filteredItems.ToArray());
        }

        public void Filter(bool exclude)
        {
            listView.Items.Clear();
            if (exclude)
            {
                var filteredItems = items.Where(i => Convert.ToInt32(i.Tag) != FilteredUserID);
                listView.Items.AddRange(filteredItems.ToArray());
            }
            else
            {
                var filteredItems = items.Where(i => Convert.ToInt32(i.Tag) == FilteredUserID);
                listView.Items.AddRange(filteredItems.ToArray());
            }
           
        }

        public void Filter(int groupId, bool exclude)
        {
            listView.Items.Clear();
            ListViewGroup group = figureGroups.Find(gr => gr.Name == "group_" + groupId.ToString());
            if (exclude)
            {
                var filteredItems = items.Where(i => Convert.ToInt32(i.Tag) != FilteredUserID && i.Group.Equals(group));
                listView.Items.AddRange(filteredItems.ToArray());
            }
            else
            {
                var filteredItems = items.Where(i => Convert.ToInt32(i.Tag) == FilteredUserID && i.Group.Equals(group));
                listView.Items.AddRange(filteredItems.ToArray());
            }
        }

        public void ShowAll()
        {
            listView.Items.Clear();
            listView.Items.AddRange(items.ToArray());
        }

        public ListViewGroup GetGroup(int id)
        {
            return figureGroups.Find(gr => gr.Name == "group_" + id.ToString());
        }

        public ListViewItem GetItem(int id)
        {
            return items.Find(gr => gr.Name == "figure_" + id.ToString());
        }

        public void RemoveItem(ListViewItem item)
        {
            items.Remove(item);
            figureImages.Images.RemoveAt(item.ImageIndex);
            try
            {
                listView.Items.Remove(item);
            }
            catch (Exception)
            {

            }
        }
        public void RemoveGroup(ListViewGroup group)
        {
            figureGroups.Remove(group);
            listView.Groups.Remove(group);
        }

        public void UpdateFigure(Figure f)
        {
            ListViewItem item = GetItem(f.Id);
            item.Text = f.FigureName;
            figureImages.Images[items.IndexOf(item)] = f.TangramElement.getIcon(System.Drawing.Color.White);
        }



        public void AddGroup(FigureGroup group)
        {
            ListViewGroup gr = new ListViewGroup();
            gr.Header = group.Name;
            gr.Name = "group_"+group.Id.ToString();
            figureGroups.Add(gr);
            listView.Groups.Add(gr);
            gr.Tag = figureGroups.Count -1;
        }

        public void AddFigure(Figure f)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = f.FigureName;
            listViewItem.Name = "figure_"+f.Id.ToString();
            figureImages.Images.Add(f.TangramElement.getIcon(System.Drawing.Color.White));
            //figureImages.Images.Add(f.TangramElement.figureImage);
            listViewItem.Group = figureGroups.Find(gr=>gr.Name == "group_"+f.Group_id.ToString());
            listViewItem.ImageIndex = figureImages.Images.Count - 1;
            listViewItem.Tag = f.User_id;
            items.Add(listViewItem);
            listView.Items.Add(listViewItem);
        }
    }
}
