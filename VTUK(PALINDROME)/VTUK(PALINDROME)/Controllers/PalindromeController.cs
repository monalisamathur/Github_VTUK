using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Data;


namespace VTUK_PALINDROME_.Controllers
{
    [RoutePrefix("api/Palindrome")]


    public class PalindromeApiController : ApiController
    {
        private MySqlConnection con;

        private void connection()
        {

            //establishing a mysql connection

            string connectionString = "SERVER=127.0.0.1;" + "DATABASE=esgdbo;" + "UID=root;" + "PASSWORD=admin;";

            con = new MySqlConnection(connectionString);
           

        }
        //Get api/Palindrome/CheckPalindrome?palindromeStr
        [HttpGet]
        [Route("CheckPalindrome")]
        public Boolean isPalindrome(string palindromeStr)
        {
            Boolean retr = true;
            try
            {
                if (!String.IsNullOrEmpty(palindromeStr) && !String.IsNullOrWhiteSpace(palindromeStr))
                {
                    palindromeStr = palindromeStr.Replace(" ", "");
                    int len = palindromeStr.Length;

                    for (int i = 0; i < len / 2; i++)
                    {
                        if (palindromeStr[i] != palindromeStr[len - 1 - i])
                        {
                            retr = false;
                            break;
                        }
                    }
                }
                else
                {
                    retr = false;
                }



            }
            catch (Exception e)
            {
                retr = false;
                Console.WriteLine(e.Message);
            }


            return retr;
        }


        [HttpGet]
        [Route("CheckPalindromeSql")]
        public Boolean isPalindromeSQL(string palindromeStr)
        {
            Boolean retr = true;

            try
            {
                if (!String.IsNullOrEmpty(palindromeStr) && !String.IsNullOrWhiteSpace(palindromeStr))
                {
                    palindromeStr = palindromeStr.Replace(" ", "");

                    connection();

                    //sql function call
                    MySqlCommand cmd = new MySqlCommand("check_palindrome;", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new MySqlParameter("@str", palindromeStr));
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", MySqlDbType.Int32);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    int result = (int)returnParameter.Value;

                    if (result != 1)
                    {
                        retr = false;
                    }


                }
                else
                {
                    retr = false;
                }

            }

            catch (Exception e)
            {
                retr = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }


            return retr;
        }
    }
}
