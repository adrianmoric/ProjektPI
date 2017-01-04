using System;
using System.Collections;
using Mono.Data.Sqlite;


namespace ProjektProgramsko
{
	public static class BPFilm
	{
		public static void Spremi(Film k)
		{
			BP.otvoriKonekciju();

			SqliteCommand command = BP.komanda();
			command.CommandText = @"create table if not exist film (

			id integer primary key autoincrement,
			godina DateTime,
			naziv string,
			trajanje integer,
			cijena double,
			tagovi string,
			opis string)"; 

		}



		public static List<Knjiga> DohvatiSve()
		{
			List<Film> listaFilmova = new List<Knjiga>();

			BP.otvoriKonekciju();

			SqliteCommand command = BP.komanda();

			command.CommandText = "Select * from film, sadrzaj where film.id_sadrzaj = sadrzaj.id";

			SqliteDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				Film k = new Film();

				k.Id = (int)(Int64)reader["id"];
				k.Naziv = (string)reader["naziv"];
				k.Tagovi = (string)reader["tagovi"];

				listaFilmova.Add(k);
			}

			reader.Dispose();
			command.Dispose();

			return listaFilmova;
	}
}

