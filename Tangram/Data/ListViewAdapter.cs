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

        public enum UserFilterMode {
            NONE,
            EXCEPT,
            INCLUDE
        }

        public UserFilterMode FilterMode { get; set; }

        public int FilteredGroup { get; set; }


        private const int IMAGE_SIZE = 50;
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
            FilterMode = UserFilterMode.NONE;
            FilteredGroup = -1;

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


        public void Filter()
        {
            if(FilteredGroup==-1 && FilterMode == UserFilterMode.NONE)
            {
                return;
            }


            if(FilteredGroup != -1)
            {
                listView.Items.Clear();
                listView.Groups.Clear();

                listView.Groups.Add(figureGroups.Find(gr => gr.Name == "group_" + FilteredGroup.ToString()));
                
                //var filtredItems= items.Where(i=>i)
            }

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
            listViewItem.Name = f.Id.ToString();
            figureImages.Images.Add(f.TangramElement.getIcon(System.Drawing.Color.White));
            listViewItem.Group = figureGroups.Find(gr=>gr.Name ==f.Group_id.ToString());
            listViewItem.ImageIndex = figureImages.Images.Count - 1;
            listViewItem.Tag = figureImages.Images.Count - 1;
            listView.Items.Add(listViewItem);
        }
    }
}
