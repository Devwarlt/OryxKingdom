#region

using db;

#endregion

namespace wServer.realm.worlds
{
    public class PlayerHouse : World
    {
        public PlayerHouse()
        {
            Id = HOUSE;
            Name = "House";
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
        }

        public override World GetInstance(ClientProcessor psr)
        {
            return RealmManager.AddWorld(new PlayerHouse());
        }

        public string House { get; set; }

        public int Level()
        {
            using (var dbx = new Database())
            {
                var id = dbx.GetHouseId(House);
                return dbx.GetHouseLevel(id);
            }
        }
    }
}