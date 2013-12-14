using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;
using db;
using MySql.Data.MySqlClient;

namespace server.credits
{
    internal class add : IRequestHandler
    {
        public void HandleRequest(HttpListenerContext context)
        {
            string status;
            using (var db = new Database())
            {
                NameValueCollection query = HttpUtility.ParseQueryString(context.Request.Url.Query);

                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT id FROM accounts WHERE uuid=@uuid";
                cmd.Parameters.AddWithValue("@uuid", query["guid"]);
                object id = cmd.ExecuteScalar();
                if (id != null)
                {
                    int amount = int.Parse(query["jwt"]);
                    string guid = (query["guid"]);
                    cmd.CommandText = "UPDATE stats SET credits = credits + " + amount.ToString() + " WHERE accId=" + id.ToString();
                    var queryint = cmd.ExecuteNonQuery();
                    //Console.WriteLine(queryint.ToString() + id.ToString() + guid + amount);
                    if (queryint == 0)
                    {
                        using (var db1 = new Database())
                        {
                            var cmd1 = db.CreateQuery();
                            cmd1.CommandText = "INSERT INTO stats(accId,fame,totalFame,credits,totalCredits) VALUES (" + id.ToString() + ",0,0," + (100 + amount) + ",0)";
                            //Console.WriteLine("second try: " + cmd1.ExecuteNonQuery());
                            status = "Purchase successful!";
                            var res = Encoding.UTF8.GetBytes(
    @"<html>
    <head>
        <title>Purchase!</title>
    </head>
    <body style='background: #333333'>
        <h1 style='color: #EEEEEE; text-align: center'>
            " + status + @"
        </h1>
    </body>
</html>");
                            context.Response.OutputStream.Write(res, 0, res.Length);
                        }
                    }
                    else
                    {
                        status = "Purchase successful!";
                        var res = Encoding.UTF8.GetBytes(
@"<html>
    <head>
        <title>Purchase!</title>
    </head>
    <body style='background: #333333'>
        <h1 style='color: #EEEEEE; text-align: center'>
            " + status + @"
        </h1>
    </body>
</html>");
                        context.Response.OutputStream.Write(res, 0, res.Length);
                    }
                }


                else
                {
                    status = "Account does not exist!";

                    var res = Encoding.UTF8.GetBytes(
    @"<html>
    <head>
        <title>Purchase!</title>
    </head>
    <body style='background: #333333'>
        <h1 style='color: #EEEEEE; text-align: center'>
            " + status + @"
        </h1>
    </body>
</html>");
                    context.Response.OutputStream.Write(res, 0, res.Length);
                }
            }
        }
        int actualcredits(int accId)
        {
            using (var db = new Database())
            {
                int creditss = 0;
                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT credits FROM stats WHERE accId=@accId";
                cmd.Parameters.AddWithValue("@accId", accId);
                if (cmd.ExecuteScalar() != null)
                {
                    //Console.WriteLine(accId.ToString() + " => " + creditss.ToString());
                    return creditss = (int)cmd.ExecuteScalar();
                }
                //Console.WriteLine(accId.ToString() +" => " +creditss.ToString());
                return creditss;
            }
        }
    }
}