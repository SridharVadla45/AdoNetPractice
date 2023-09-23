using System.Data;using System.Data.SqlClient;internal class Program{     private static string ConnectionString = "Data Source=LTIN426056\\MSSQLSERVER12; Initial Catalog=CategoryDb; Integrated Security=True;";     private static SqlConnection? con = null;    public static void Connection(){                try{            con=new SqlConnection(ConnectionString);// Creating a Connection to Sql Server             // open a connection            con.Open();            if (con.State == ConnectionState.Open )            {                Console.WriteLine("Connection Created Successfully ");            }        }catch(SqlException ex){             Console.WriteLine(ex.Message);        }          }    public static void InsertRecord()    {                string Query1 = "insert into [CategoryDb].[dbo].[Categories] values(@CategoryName,@DisplayOrder);";        SqlCommand sqlCommand=new SqlCommand(Query1,Program.con);        int changes = sqlCommand.ExecuteNonQuery();        if(changes > 0)        {            Console.WriteLine("A new Record is inserted into the database");        }        Console.ReadLine();    }    public static void DisplayRecords()    {        String Query = "Select * from Categories";        SqlCommand sqlCommand = new SqlCommand(Query, con);        SqlDataReader data = sqlCommand.ExecuteReader();        while (data.Read())        {            Console.Write("CategoryID : " + " " + data["CategoryID"] + " " + "CategoryName : " + " " + data["CategoryName"] + " " + "DisplayOrder : " + data["DisplayOrder"]);            Console.WriteLine(" ");        }    }    public static void DeleteRecord(int CategoryID)
    {
        string query = "Delete from [CategoryDb].[dbo].[Categories] where CategoryID == CategoryID ";
        var sqlCommand=new SqlCommand(query,con);
        int changes=sqlCommand.ExecuteNonQuery();
        if(changes > 0 )
        {
            Console.WriteLine("A Record is Deleted from the table !");
        }
    }        private static void Main(string[] args)    {               Program.Connection();

       

        Program.con.Close();        if (Program.con.State == ConnectionState.Closed)        {            Console.WriteLine(" Connection is Closed");        }        Console.ReadLine();           }}