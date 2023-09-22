using System.Data;
using System.Data.SqlClient;

internal class Program

{

    public static void Connection(){

        string ConnectionString="Data Source=LTIN426056\\MSSQLSERVER12; Initial Catalog=CategoryDb; Integrated Security=True;";
        SqlConnection? con=null;
        try{

            con=new SqlConnection(ConnectionString);// Creating a Connection to Sql Server 
            // open a connection
            con.Open();

            if (con.State == ConnectionState.Open )
            {
                Console.WriteLine("Connection Created Successfully ");
            }
            String Query = "Select * from Categories";
            SqlCommand sqlCommand =new SqlCommand(Query,con);
            SqlDataReader data= sqlCommand.ExecuteReader();

            while (data.Read())
            {   
               
                Console.Write("CategoryID : " + " " + data["CategoryID"] + " "+"CategoryName : " +" "+ data["CategoryName"] + " " + "DisplayOrder : " + data["DisplayOrder"]);
                Console.WriteLine(" ");

            }
 
        }catch(SqlException ex){
             Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Program.Connection();
        Console.ReadLine();
        

       
       
    }
}