#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using db;
using db.data;
using wServer.realm.entities;

#endregion

namespace wServer.realm.worlds
{
    public class PlayerHouse : World
    {
        public PlayerHouse(bool isLimbo, ClientProcessor psr = null)
        {
            Id = HOUSE;
            Name = "House";
            Background = 0;
            AllowTeleport = true;
            if (!(IsLimbo = isLimbo))
            {
                base.FromWorldMap(
                    typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.house.wmap"));
            }
            //switch (Level())
            //{
            //    case 0:
            //        base.FromWorldMap(
            //            typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall0.wmap"));
            //        break;
            //    case 1:
            //        base.FromWorldMap(
            //            typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall1.wmap"));
            //        break;
            //    case 2:
            //        base.FromWorldMap(
            //            typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall2.wmap"));
            //        break;
            //    case 3:
            //        base.FromWorldMap(
            //            typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall3.wmap"));
            //        break;
            //}    
        }


        //public string House { get; set; }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new PlayerHouse(false, psr));
        }


        //public int Level()
        //{
        //    using (var dbx = new Database())
        //    {
        //        var id = dbx.GetHouseId(House);
        //        return dbx.GetHouseLevel(id);
        //    }
        //}
    }
}