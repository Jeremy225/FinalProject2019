using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FinalProject2019.Models;

namespace FinalProject2019
{
    class musicQuotesRepo
    {
        private const string connStr = "Server=localhost;Database=musicquotes;Uid=root;Pwd=Password;";
        public List<Quote> GetAllQuotes()
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            List<Quote> quotes = new List<Quote>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT quoteID, quote, song, artist, genre FROM quotes;";

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Quote quote = new Quote()
                    {
                        Id = (int)dataReader["QuoteID"],
                        quote = dataReader["quote"].ToString(),
                        song = dataReader["song"].ToString(),
                        artist = dataReader["artist"].ToString(),
                        genre = dataReader["genre"].ToString(),
                    };

                    quotes.Add(quote);
                }

                return quotes;
            }
        }

        public int InsertQuote(string quote, string song, string artist, string genre)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Quotes (quote, song, artist, genre) " +
                                  "VALUES (@quote, @song, @artist, @genre);";
                cmd.Parameters.AddWithValue("quote", quote);
                cmd.Parameters.AddWithValue("song", song);
                cmd.Parameters.AddWithValue("artist", artist);
                cmd.Parameters.AddWithValue("genre", genre);

                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateQuote(Quote quote)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Quotes SET quote = @quote, song = @song , artist = @artist, genre = @genre" +
                                  "WHERE quoteID = @qid";
                cmd.Parameters.AddWithValue("quote", quote.quote);
                cmd.Parameters.AddWithValue("song", quote.song);
                cmd.Parameters.AddWithValue("artist", quote.artist);
                cmd.Parameters.AddWithValue("qid", quote.Id);

                return cmd.ExecuteNonQuery();
            }
        }

        public void DeleteQuote(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM quotes " +
                                                    "WHERE quoteID=" + id, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Quote> GetQuotesByQuote(string quote)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            List<Quote> quotes = new List<Quote>();

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT quoteID, quote, song, artist, genre  " +
                                  "FROM quotes " +
                                  "WHERE Name = @xyz " +
                                  "ORDER BY quoteID";
                cmd.Parameters.AddWithValue("xyz", quote);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Quote quotte = new Quote()
                    {
                        Id = (int)dataReader["quoteID"],
                        quote = dataReader["quote"].ToString(),
                        song = dataReader["song"].ToString(),
                        artist = dataReader["artist"].ToString(),
                        genre = dataReader["genre"].ToString(),
                    };

                    quotes.Add(quotte);
                }

                return quotes;
            }
        }

        public Quote GetQuote(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT quoID, quote, song, artist, genre " +
                                  "FROM quotes" +
                                  "WHERE quoID=" + id;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    ;
                    Quote quote = new Quote()
                    {
                        quote = dataReader["quote"].ToString(),
                        Id = (int)dataReader["quote.tID"],
                        song = dataReader["song"].ToString(),
                        artist = dataReader["artist"].ToString(),
                        genre = dataReader["genre"].ToString(),
           
                    };

                    return quote;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

