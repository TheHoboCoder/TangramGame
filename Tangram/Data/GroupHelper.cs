using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangram.Data.DataModels;

namespace Tangram.Data
{
    class GroupHelper:DatabaseHelper
    {

        public GroupHelper(MySqlConnection connection) : base(connection)
        {
            //groups = new Repository(connection, TableInfoHolder.getInfo("groups"));
            //childs = new Repository(connection, TableInfoHolder.getInfo("childs"));
        }

        //public int GetGroupIdByUserId(int userId)
        //{
        //    groups.Upload("id_user = " + userId);
        //    if (groups.Table.Rows.Count == 0)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(groups.Table.Rows[0][TableInfoHolder.getInfo("groups").IdName]);
        //    }
        //}

        //public int GetUserIdByGroupId(int groupId)
        //{
        //    groups.Upload("id_group = '" + groupId.ToString()+"'");
        //    if (groups.Table.Rows.Count == 0)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(groups.Table.Rows[0][TableInfoHolder.getInfo("users").IdName]);
        //    }
        //}

        //public void getChildrenInGroup(int groupId)
        //{
        //    childs.Upload(" id_group = '" + groupId.ToString() + "'");
        //}



        //public Repository groups;
        //public Repository childs;
    }
}
