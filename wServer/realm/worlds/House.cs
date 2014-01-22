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
        public PlayerHouse(string house)
        {
            Id = GHALL;
            House = house;
            Name = "Home";
            Background = 0;
            AllowTeleport = true;
            switch (Level())
            {
                case 0:
                    base.FromWorldMap(
                        typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall0.wmap"));
                    break;
                case 1:
                    base.FromWorldMap(
                        typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall1.wmap"));
                    break;
                case 2:
                    base.FromWorldMap(
                        typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall2.wmap"));
                    break;
                case 3:
                    base.FromWorldMap(
                        typeof (RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.ghall3.wmap"));
                    break;
            }
            //base.FromWorldMap(typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.guildhall0old.wmap"));            
        }

        public string House { get; set; }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new PlayerHouse(House));
        }

        public int Level()
        {
            using (var dbx = new Database())
            {
                var id = dbx.GetGuildId(House);
                return dbx.GetGuildLevel(id);
            }
        }
        //public PlayerHouse(bool isLimbo, ClientProcessor psr = null)
        //{
        //    Id = HOUSE;
        //    Name = "House";
        //    Background = 0;
        //    AllowTeleport = true;
        //    if (!(IsLimbo = isLimbo))
        //    {
        //        base.FromWorldMap(
        //            typeof(RealmManager).Assembly.GetManifestResourceStream("wServer.realm.worlds.house.wmap"));
        //    } 
        //}

        //public override World GetInstance(ClientProcessor psr)
        //{
        //    return RealmManager.AddWorld(new PlayerHouse(false, psr));
        //}
    }
}